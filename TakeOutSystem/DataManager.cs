using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

namespace TakeOutSystem
{
  public class DataManager
  {
    private class MenuDta
    {
      public int id;
      public string name;
      public float prise;
      public MenuDta(int _id, string _name, float _prise)
      {
        id = _id;
        name = _name;
        prise = _prise;
      }
    }
    public DataTable DetailTable = new DataTable();
    public DataTable TotalTable = new DataTable();

    public static DataManager Instance
    {
      get
      {
        return s_instance;
      }
    }
    private Dictionary<int, MenuDta> m_menuData = new Dictionary<int, MenuDta>();
    private Dictionary<string, List<Tuple<int, int>>> m_orderData = new Dictionary<string, List<Tuple<int, int>>>();
    private static DataManager s_instance = new DataManager();

    public bool Init()
    {
      return true;
    }

    public void AddNewMenuData(int id, string name, float prise)
    {
      MenuDta target;
      if (m_menuData.TryGetValue(id, out target))
      {
        target.name = name;
        target.prise = prise;
      }
      else
      {
        m_menuData[id] = new MenuDta(id, name, prise);
      }
    }

    public string AnalyseOrderData(string serilizedStr)
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
      m_orderData[name] = orderList;

      return "success";
    }

    public void Clear()
    {
      DetailTable.Clear();
      TotalTable.Clear();
      m_orderData.Clear();
    }
  }
}
