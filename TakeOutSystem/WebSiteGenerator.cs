using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TakeOutSystem
{
  public class WebSiteGenerator
  {
    static private string htmlTemplatePath = "/Web.html";
    static private string contentTemplatePath = "/Content.html";
    static public string GetWebSiteStr(string title, string restName, string targetWebSite, float priseMax, List<MenuData> menuDatas)
    {
      if (null == menuDatas || menuDatas.Count <= 0)
        return "";
      string fullPath = Directory.GetCurrentDirectory() + htmlTemplatePath;
      if(!File.Exists(fullPath))
      {
        return "";
      }
      string contentPath = Directory.GetCurrentDirectory() + contentTemplatePath;
      if(!File.Exists(contentPath))
      {
        return "";
      }
      string result = File.ReadAllText(fullPath);
      string contentTemplate = File.ReadAllText(contentPath);
      StringBuilder contentBuilder = new StringBuilder();
      foreach(var data in menuDatas)
      {
        contentBuilder.AppendFormat(contentTemplate, data.id, data.name, data.prise, data.has_ex.ToString());
      }
      return string.Format(result, title, restName, priseMax <= 0 ? "" : priseMax.ToString(), targetWebSite, contentBuilder.ToString());
    }
  }
}