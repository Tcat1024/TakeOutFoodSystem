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

    public List<MenuData> menuData
    {
      get
      {
        return m_menuData;
      }
    }

    public DataTable detailDataTable;
    public DataTable ordersDataTable;
    public DataTable totalDataTable;
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
    private DataSet m_allDataSet = new DataSet();
    private List<MenuData> m_menuData = new List<MenuData>();
    private Dictionary<string, List<float>> m_dicMenuPrises = new Dictionary<string, List<float>>();
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
      m_allDataSet.Tables.Clear();
      detailDataTable = m_allDataSet.Tables.Add("details");
      ordersDataTable = m_allDataSet.Tables.Add("orders");
      ordersDataTable.Columns.Add(new DataColumn("customer", typeof(string)));
      ordersDataTable.Columns.Add(new DataColumn("order_id", typeof(int)));
      ordersDataTable.Columns.Add(new DataColumn("order_name", typeof(string)));
      ordersDataTable.Columns.Add(new DataColumn("order_prise", typeof(float)));
      ordersDataTable.Columns.Add(new DataColumn("order_num", typeof(int)));
      ordersDataTable.Columns.Add(new DataColumn("total_prise", typeof(float), "order_prise*order_num"));
      ordersDataTable.PrimaryKey = new DataColumn[] { ordersDataTable.Columns["customer"], ordersDataTable.Columns["order_id"] };

      detailDataTable.Columns.Add(new DataColumn("name", typeof(string)));

      m_allDataSet.Relations.Add("customer_name", detailDataTable.Columns["name"], ordersDataTable.Columns["customer"]);
      detailDataTable.Columns.Add(new DataColumn("total_prise", typeof(float), "Sum(Child.total_prise)"));
      detailDataTable.PrimaryKey = new DataColumn[] { detailDataTable.Columns["name"] };
      ordersDataTable.DefaultView.RowFilter = "customer = ''";
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
      if (m_menuData.Count <= 0)
      {
        return "Error：未录入菜单，请联系服务器";
      }
      Match nameMatch = Regex.Match(serilizedStr, @"\[name:(\S+?)\]");
      if (!nameMatch.Success || nameMatch.Groups.Count <= 0)
        return "Error：姓名不正确";

      string name = nameMatch.Groups[1].Value;
      var anaResult = Regex.Matches(serilizedStr, @"\[id\S+?:(\d+?)\],\[num\S+?:(\d+?)\]");
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
      foreach(DataTable table in m_allDataSet.Tables)
      {
        table.Rows.Clear();
      }
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
      if (detailDataTable == null || ordersDataTable == null)
        return;
      bool bChanged = false;
      AnalysedData data;
      detailDataTable.BeginLoadData();
      ordersDataTable.BeginLoadData();
      while (m_analysedDatas.TryDequeue(out data))
      {
        if (!bChanged)
          bChanged = true;
        DataRow tarRow = null;
        if ((tarRow = detailDataTable.Rows.Find(data.name)) == null)
        {
          if (data.orders.Count <= 0)
            continue;
          bool trueAdd = false;
          foreach(var order in data.orders)
          {
            if (order.Item1 < 0 || order.Item1 >= m_menuData.Count)
              continue;
            if (!trueAdd)
            {
              trueAdd = true;
              tarRow = detailDataTable.NewRow();
              tarRow["name"] = data.name;
              detailDataTable.Rows.Add(tarRow);
            }
            var menudata = m_menuData[order.Item1];
            var newRow = ordersDataTable.NewRow();
            newRow["customer"] = data.name;
            newRow["order_id"] = order.Item1;
            newRow["order_name"] = menudata.name;
            newRow["order_prise"] = menudata.prise;
            newRow["order_num"] = order.Item2;
            ordersDataTable.Rows.Add(newRow);
          }
        }
        else
        {
          DataRow[] childRows = tarRow.GetChildRows("customer_name");
          foreach (var childRow in childRows)
          {
            ordersDataTable.Rows.Remove(childRow);
          }
          if (data.orders.Count <= 0)
          {
            detailDataTable.Rows.Remove(tarRow);
            continue;
          }
          bool trueAdd = false;
          foreach (var order in data.orders)
          {
            if (order.Item1 < 0 || order.Item1 >= m_menuData.Count)
              continue;
            if (!trueAdd)
              trueAdd = true;
            var menudata = m_menuData[order.Item1];
            var newRow = ordersDataTable.NewRow();
            newRow["customer"] = data.name;
            newRow["order_id"] = order.Item1;
            newRow["order_name"] = menudata.name;
            newRow["order_prise"] = menudata.prise;
            newRow["order_num"] = order.Item2;
            ordersDataTable.Rows.Add(newRow);
          }
          if(!trueAdd)
          {
            detailDataTable.Rows.Remove(tarRow);
            continue;
          }
        }
      }
      detailDataTable.EndLoadData();
      ordersDataTable.EndLoadData();
    }
  }
}
