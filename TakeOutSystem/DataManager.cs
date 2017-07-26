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
    public bool has_ex;
    public string img_path;
    public float box_prise;
    public MenuData(int _id, string _name, float _prise, bool _has_ex, string _img_path, float _box_prise)
    {
      id = _id;
      name = _name;
      prise = _prise;
      has_ex = _has_ex;
      img_path = _img_path;
      box_prise = _box_prise;
    }
  }
  public class DataManager
  {

    private class OrderDetail
    {
      public int id;
      public int num;
      public string ex;
      public OrderDetail(int _id, int _num, string _ex = "")
      {
        id = _id;
        num = _num;
        ex = _ex.Trim();
      }
    }

    private class OrderCompare : IEqualityComparer<DataRow>
    {
      public bool Equals(DataRow x, DataRow y)
      {
        return x["order_id"].ToString() == y["order_id"].ToString() && x["order_ex"].ToString() == y["order_ex"].ToString();
      }

      public int GetHashCode(DataRow obj)
      {
        string retCode = string.Format("{0}_{1}", obj["order_id"], obj["order_ex"]);
        return retCode.GetHashCode();
      }
    }

    private class AnalysedData
    {
      public string name;
      public List<OrderDetail> orders;
      public AnalysedData(string _name, List<OrderDetail> _orders)
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

    public bool showDefaultPeople
    {
      get
      {
        return m_showDefaultPople;
      }
      set
      {
        if (m_showDefaultPople == value)
          return;
        m_showDefaultPople = value;
        if(null != detailDataTable)
        {
          detailDataTable.DefaultView.RowFilter = value ? "" : "detailStr not in ('')";
        }
      }
    }


    public DataTable detailDataTable;
    public DataTable ordersDataTable;
    public DataTable totalDataTable;
    static public bool allowOrder = true;
    public delegate void DataChangedEventHandler();

    public static DataManager instance
    {
      get
      {
        return s_instance;
      }
    }

    private Object m_tableLock = new Object();
    private bool m_showDefaultPople = true;
    private List<string> m_defaultNameList = new List<string>();
    private HashSet<string> m_defaultNameSet = new HashSet<string>();
    private delegate void InvokeDelegate();
    private DataSet m_allDataSet = new DataSet();
    private List<MenuData> m_menuData = new List<MenuData>();
    private Dictionary<string, List<float>> m_dicMenuPrises = new Dictionary<string, List<float>>();
    private InterlockedQueue<AnalysedData> m_analysedDatas = new InterlockedQueue<AnalysedData>();
    private Thread m_refreshThread;
    private Control m_mainThreadControl;
    private OrderCompare m_defaultOrderCompare = new OrderCompare();
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
      InitDefaultNamesConfig();

      m_mainThreadControl = mainControl;
      m_allDataSet.Tables.Clear();
      detailDataTable = m_allDataSet.Tables.Add("details");
      ordersDataTable = m_allDataSet.Tables.Add("orders");
      totalDataTable = m_allDataSet.Tables.Add("total");
      ordersDataTable.Columns.Add(new DataColumn("customer", typeof(string)));
      ordersDataTable.Columns.Add(new DataColumn("order_id", typeof(int)));
      ordersDataTable.Columns.Add(new DataColumn("order_name", typeof(string)));
      ordersDataTable.Columns.Add(new DataColumn("order_prise", typeof(float)));
      ordersDataTable.Columns.Add(new DataColumn("order_num", typeof(int)));
      ordersDataTable.Columns.Add(new DataColumn("order_ex", typeof(string)));
      ordersDataTable.Columns.Add(new DataColumn("total_prise", typeof(float), "order_prise*order_num"));
      ordersDataTable.PrimaryKey = new DataColumn[] { ordersDataTable.Columns["customer"], ordersDataTable.Columns["order_id"]};

      detailDataTable.Columns.Add(new DataColumn("name", typeof(string)));
      detailDataTable.Columns.Add(new DataColumn("detailStr", typeof(string)));

      m_allDataSet.Relations.Add("customer_name", detailDataTable.Columns["name"], ordersDataTable.Columns["customer"]);
      detailDataTable.Columns.Add(new DataColumn("total_prise", typeof(float), "Sum(Child.total_prise)"));
      detailDataTable.PrimaryKey = new DataColumn[] { detailDataTable.Columns["name"] };

      totalDataTable.Columns.Add(new DataColumn("order_id", typeof(int)));
      totalDataTable.Columns.Add(new DataColumn("order_name", typeof(string)));
      totalDataTable.Columns.Add(new DataColumn("order_ex", typeof(string)));
      totalDataTable.PrimaryKey = new DataColumn[] { totalDataTable.Columns["order_id"], totalDataTable.Columns["order_ex"] };
      m_allDataSet.Relations.Add("order_id", new DataColumn[] { totalDataTable.Columns["order_id"], totalDataTable.Columns["order_ex"] }, new DataColumn[] { ordersDataTable.Columns["order_id"], ordersDataTable.Columns["order_ex"] });
      totalDataTable.Columns.Add(new DataColumn("total_num", typeof(int), "Sum(Child.order_num)"));

      totalDataTable.DefaultView.Sort = "order_id";
      showDefaultPeople = showDefaultPeople;

      Clear();

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

    public void ClearMenuData()
    {
      m_menuData.Clear();
      m_dicMenuPrises.Clear();
    }

    public void AddNewMenuData(string name, float prise, bool has_ex, string img_path, float box_prise)
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
      m_menuData.Add(new MenuData(m_menuData.Count, name, prise, has_ex, img_path, box_prise));
    }

    public string AnalyseOrderDataAsyn(string serilizedStr)
    {
      if(serilizedStr.Substring(0, 5).ToLower() == "query") // 查询指令
      {
        Match nameMatch = Regex.Match(serilizedStr, @"\[name:([\s,\S]+?)\]");
        if (!nameMatch.Success || nameMatch.Groups.Count <= 0)
          return "Error：姓名不正确";
        string name = nameMatch.Groups[1].Value.Trim().Replace(" ","");
        if (name.Length == 0)
          return "Error：姓名不正确";
        lock (m_tableLock)
        {
          if(detailDataTable == null)
          {
            return "无订餐数据";
          }
          var rowData = detailDataTable.Select("name='" + name + "'");
          string resultString;
          if (rowData.Length == 0 || (resultString = rowData[0]["detailStr"].ToString()).Length == 0)
            return "尚无您的订餐数据";
          return resultString;
        }
      }
      else
      {
        if (!allowOrder)
        {
          return "当前订餐已关闭，无法点餐；\r\n查询功能可正常使用;";
        }

        if (m_menuData.Count <= 0)
        {
          return "Error：未录入菜单，请联系服务器";
        }
        Match nameMatch = Regex.Match(serilizedStr, @"\[name:([\S,\s]+?)\]");
        if (!nameMatch.Success || nameMatch.Groups.Count <= 0)
          return "Error：姓名不正确";

        string name = nameMatch.Groups[1].Value.Trim().Replace(" ", "");
        if (name.Length == 0)
          return "Error：姓名不正确";
        var anaResult = Regex.Matches(serilizedStr, @"\[id\S+?:(\d+?)\],\[num\S+?:(\d+?)\],\[ex\S+?:([\S,\s]*?)\]");
        List<OrderDetail> orderList = new List<OrderDetail>();
        foreach (Match match in anaResult)
        {
          if (match.Groups.Count < 4)
            continue;
          orderList.Add(new OrderDetail(int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value), match.Groups[3].Value.ToString()));
        }

        m_analysedDatas.Enqueue(new AnalysedData(name, orderList));

        return "恭喜你，订餐成功！";
      }
    }

    public void Clear()
    {
      foreach (DataTable table in m_allDataSet.Tables)
      {
        table.Rows.Clear();
      }
      if(null != detailDataTable && m_defaultNameList.Count > 0)
      {
        detailDataTable.BeginLoadData();
        foreach (var name in m_defaultNameList)
        {
          var tarRow = detailDataTable.NewRow();
          tarRow["name"] = name;
          detailDataTable.Rows.Add(tarRow);
        }
        detailDataTable.EndLoadData();
      }
    }

    private void InitDefaultNamesConfig()
    {
      var path = Directory.GetCurrentDirectory() + "/configs/defaultNames.txt";
      if (!File.Exists(path))
        return;
      var file = File.ReadAllText(path);
      var names = file.Split(new char[] { ' ', '\r', '\n', '\t' },StringSplitOptions.RemoveEmptyEntries);
      m_defaultNameList.Clear();
      m_defaultNameSet.Clear();
      foreach(var name in names)
      {
        if(m_defaultNameSet.Add(name))
        {
          m_defaultNameList.Add(name);
        }
      }
    }

    private void RefreshThread()
    {
      try
      {
        InvokeDelegate method = InvokeMethod;
        while (true)
        {
          Thread.Sleep(500);
          if (null != m_mainThreadControl)
            m_mainThreadControl.BeginInvoke(method);
        }
      }
      catch(Exception e)
      {
        MessageBox.Show(e.Message);
      }
    }

    private void InvokeMethod()
    {
      if (detailDataTable == null || ordersDataTable == null)
        return;
      bool bChanged = false;
      AnalysedData data;
      lock(m_tableLock)
      {
        while (m_analysedDatas.TryDequeue(out data))
        {
          if (!bChanged)
          {
            bChanged = true;
            detailDataTable.BeginLoadData();
            ordersDataTable.BeginLoadData();
          }
          DataRow tarRow = null;
          if ((tarRow = detailDataTable.Rows.Find(data.name)) == null)
          {
            if (data.orders.Count <= 0)
              continue;
            StringBuilder detailStrBuilder = new StringBuilder();
            foreach (var order in data.orders)
            {
              if (order.id < 0 || order.id >= m_menuData.Count)
                continue;
              if (detailStrBuilder.Length == 0)
              {
                tarRow = detailDataTable.NewRow();
                tarRow["name"] = data.name;
                detailDataTable.Rows.Add(tarRow);
              }
              var menudata = m_menuData[order.id];
              var newRow = ordersDataTable.NewRow();
              newRow["customer"] = data.name;
              newRow["order_id"] = order.id;
              newRow["order_name"] = menudata.name;
              newRow["order_prise"] = menudata.prise;
              newRow["order_num"] = order.num;
              newRow["order_ex"] = order.ex;
              ordersDataTable.Rows.Add(newRow);

              detailStrBuilder.Append(",");
              detailStrBuilder.Append(menudata.name);
              if (order.ex.Length > 0)
              {
                detailStrBuilder.Append("(");
                detailStrBuilder.Append(order.ex);
                detailStrBuilder.Append(")");
              }
              detailStrBuilder.Append("x");
              detailStrBuilder.Append(order.num);
            }

            if (detailStrBuilder.Length > 0)
            {
              tarRow["detailStr"] = detailStrBuilder.Remove(0, 1).ToString();
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
              if ((m_defaultNameSet.Count == 0 || !m_defaultNameSet.Contains(data.name)))
                detailDataTable.Rows.Remove(tarRow);
              else
                tarRow["detailStr"] = "";
              continue;
            }
            StringBuilder detailStrBuilder = new StringBuilder();
            foreach (var order in data.orders)
            {
              if (order.id < 0 || order.id >= m_menuData.Count)
                continue;
              var menudata = m_menuData[order.id];
              var newRow = ordersDataTable.NewRow();
              newRow["customer"] = data.name;
              newRow["order_id"] = order.id;
              newRow["order_name"] = menudata.name;
              newRow["order_prise"] = menudata.prise;
              newRow["order_num"] = order.num;
              newRow["order_ex"] = order.ex;
              ordersDataTable.Rows.Add(newRow);

              detailStrBuilder.Append(",");
              detailStrBuilder.Append(menudata.name);
              if (order.ex.Length > 0)
              {
                detailStrBuilder.Append("(");
                detailStrBuilder.Append(order.ex);
                detailStrBuilder.Append(")");
              }
              detailStrBuilder.Append("x");
              detailStrBuilder.Append(order.num);
            }
            if (detailStrBuilder.Length == 0)
            {
              if ((m_defaultNameSet.Count == 0 || !m_defaultNameSet.Contains(data.name)))
                detailDataTable.Rows.Remove(tarRow);
              else
                tarRow["detailStr"] = "";
              continue;
            }
            tarRow["detailStr"] = detailStrBuilder.Remove(0, 1).ToString();
          }
        }
        if (bChanged)
        {
          totalDataTable.BeginLoadData();
          totalDataTable.Rows.Clear();
          var distinctRows = ordersDataTable.AsEnumerable().Distinct<DataRow>(m_defaultOrderCompare);
          foreach (var row in distinctRows)
          {
            var newRow = totalDataTable.NewRow();
            newRow["order_id"] = row["order_id"];
            newRow["order_ex"] = row["order_ex"];
            newRow["order_name"] = row["order_name"];
            totalDataTable.Rows.Add(newRow);
          }
          totalDataTable.EndLoadData();
          detailDataTable.EndLoadData();
          ordersDataTable.EndLoadData();
        }
      }
    }
  }
}
