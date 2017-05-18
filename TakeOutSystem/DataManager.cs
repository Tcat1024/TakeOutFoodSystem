using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TakeOutSystem
{
  public class MenuData
  {
    public int id;
    public string name;
    public float prise;
    public MenuData(int _id, string _name, float _prise)
    {
      id = _id;
      name = _name;
      prise = _prise;
    }
  }
  public class DataManager
  {
    private class AnalysedData
    {
      public string name;
      public List<Tuple<int, int>> orders;
      public AnalysedData(string _name, List<Tuple<int, int>> _orders)
      {
        name = _name;
        orders = _orders;
      }
    }

    public class DetailData
    {
      public string name { get; set; }
      public List<Tuple<int, int>> orders { get; set; }
      public string detailStr { get; set; }
      public float totalPrise { get; set; }
    }

    public class TotalData
    {
      public int id { get; set; }
      public string name { get; set; }
      public float prise { get; set; }
      public int num { get; set; }
    }


    public List<MenuData> menuData
    {
      get
      {
        return m_menuData;
      }
    }

    public List<DetailData> detailDataList = new List<DetailData>();
    public List<TotalData> totalDataList = new List<TotalData>();

    public delegate void DataChangedEventHandler();
    public event DataChangedEventHandler OnDataChanged;

    public static DataManager instance
    {
      get
      {
        return s_instance;
      }
    }

    private delegate void InvokeDelegate();
    private List<MenuData> m_menuData = new List<MenuData>();
    private Dictionary<string, List<float>> m_dicMenuPrises = new Dictionary<string, List<float>>();
    private Dictionary<string, int> m_dicDetailName = new Dictionary<string, int>();
    private InterlockedQueue<AnalysedData> m_analysedDatas = new InterlockedQueue<AnalysedData>();
    private Thread m_refreshThread;
    private Control m_mainThreadControl;
    private static DataManager s_instance = new DataManager();

    ~DataManager()
    {
      if(null != m_refreshThread && m_refreshThread.IsAlive)
      {
        try
        {
          m_refreshThread.Abort();
        }
        catch
        {

        }
        finally
        {
          m_refreshThread = null;
        }
      }
    }

    public bool Init(Control mainControl)
    {
      m_mainThreadControl = mainControl;

      if (null == m_refreshThread)
      {
        m_refreshThread = new Thread(RefreshThread);
        m_refreshThread.IsBackground = true;
        m_refreshThread.Start();
      }
      return true;
    }

    public void Release()
    {
      if (null != m_refreshThread && m_refreshThread.IsAlive)
      {
        try
        {
          m_refreshThread.Abort();
        }
        catch
        {

        }
        finally
        {
          m_refreshThread = null;
        }
      }
      m_mainThreadControl = null;
    }

    public void AddNewMenuData(string name, float prise)
    {
      List<float> prises;
      if (m_dicMenuPrises.TryGetValue(name, out prises))
      {
        foreach(var p in prises)
        {
          if (prise == p)
            return;
        }
        prises.Add(prise);
      }
      else
        m_dicMenuPrises[name] = new List<float>() { prise };
      m_menuData.Add(new MenuData(m_menuData.Count, name, prise));
    }

    public string AnalyseOrderDataAsyn(string serilizedStr)
    {
      //if(m_menuData.Keys.Count <= 0)
      //{
      //  return "Error：未录入菜单，请联系服务器";
      //}
      Match nameMatch = Regex.Match(serilizedStr, @"\[name:(\S+?)\]");
      if (!nameMatch.Success || nameMatch.Groups.Count <= 0)
        return "Error：姓名不正确";

      string name = nameMatch.Groups[1].Value;
      var anaResult = Regex.Matches(serilizedStr, @"\[id\S+?:(\d+?)\],\[num\S+?:(\d+?)\]");
      if(anaResult.Count <= 0)
      {
        return "Error：解析错误";
      }
      List<Tuple<int, int>> orderList = new List<Tuple<int, int>>();
      foreach (Match match in anaResult)
      {
        if (match.Groups.Count < 2)
          continue;
        orderList.Add(new Tuple<int, int>(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value)));
      }

      m_analysedDatas.Enqueue(new AnalysedData(name, orderList));
      
      return "success";
    }

    public void Clear()
    {
      detailDataList.Clear();
      totalDataList.Clear();
    }

    private void RefreshThread()
    {
      InvokeDelegate method = InvokeMethod;
      while (true)
      {
        Thread.Sleep(500);
        if (null != m_mainThreadControl)
          m_mainThreadControl.BeginInvoke(method);
      }
    }

    private void InvokeMethod()
    {
      bool bChanged = false;
      AnalysedData data;
      while (m_analysedDatas.TryDequeue(out data))
      {
        if (!bChanged)
          bChanged = true;
        DetailData detail;
        int idx;
        if(!m_dicDetailName.TryGetValue(data.name, out idx))
        {
          if(null == data.orders || data.orders.Count <= 0)
          {
            continue;
          }
          detail = new DetailData();
          detail.name = data.name;
          m_dicDetailName[data.name] = detailDataList.Count;
          detailDataList.Add(detail);
        }
        else
        {
          if (null == data.orders || data.orders.Count <= 0)
          {
            m_dicDetailName.Remove(data.name);
            detailDataList.RemoveAt(idx);
            continue;
          }
          detail = detailDataList[idx];
        }
        detail.orders = data.orders;
        
        StringBuilder builder = new StringBuilder();
        float totalPrise = 0f;
        foreach (var order in detail.orders)
        {
          if (order.Item1 < 0 || order.Item1 >= m_menuData.Count)
          {
            continue;
          }
          var tarData = m_menuData[order.Item1];
          builder.Append(tarData.name);
          builder.Append("(");
          builder.Append(tarData.prise);
          builder.Append(")x");
          builder.Append(order.Item2);
          totalPrise += tarData.prise * order.Item2;
        }
        detail.detailStr = builder.ToString();
        detail.totalPrise = totalPrise;
      }
      if (bChanged)
      {
        totalDataList.Clear();
        int[] nums = new int[m_menuData.Count];
        foreach(var detail in detailDataList)
        {
          foreach(var order in detail.orders)
          {
            nums[order.Item1] += order.Item2;
          }
        }
        for(int i= 0; i < nums.Length; ++i)
        {
          if (nums[i] <= 0)
            continue;
          var total = new TotalData();
          total.id = i;
          total.name = m_menuData[i].name;
          total.num = nums[i];
          total.prise = m_menuData[i].prise;
          totalDataList.Add(total);
        }
        OnDataChanged();
      }
    }
  }
}
