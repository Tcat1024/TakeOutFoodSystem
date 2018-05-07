using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;

namespace TakeOutSystem
{

  public class WebSiteAnalyseResult
  {
    public string name;
    public float prise;
    public float boxprise;
    public bool has_ex;
    public string img_path;

    public string Serialize()
    {
      return string.Format("{0}_{1}_{2}_{3}", name, prise, has_ex, img_path);
    }
  }

  public class WebSiteAnalyser
  {
    static public string Analyser(string weburl, out List<WebSiteAnalyseResult> results, out string shopName)
    {
      results = null;
      shopName = "";
      if (weburl.Length <= 8 || (weburl.Substring(0, 8) != "https://" && weburl.Substring(0, 7) != "http://"))
      {
        weburl = "https://" + weburl;
      }

      WebClient MyWebClient = new WebClient();
      
      //MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据

      Byte[] pageData;
      try
      {
        pageData = MyWebClient.DownloadData(weburl); //从指定网站下载数据
        if (pageData == null || pageData.Length == 0)
        {
          return "网址错误";
        }
      }
      catch(Exception e)
      {
        return "网址无法访问：" + e.Message;
      }

      //string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句            

      string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句

      var startMatch = Regex.Match(weburl, "//");
      int startIdx = 0;
      List<WebSiteAnalyseResult> unproResult;
      if (startMatch != null)
      {
        startIdx = startMatch.Index + 2;
      }
      if (weburl.Substring(startIdx, 16) == "waimai.baidu.com")
      {
        unproResult = BaiDuWaiMaiAnalyser.Analyse(pageHtml, out shopName);
      }
      else
      {
        return "不支持的网站";
      }

      if(null == unproResult || unproResult.Count <= 0)
      {
        return "网站解析错误";
      }

      HashSet<string> nameSet = new HashSet<string>();
      results = new List<WebSiteAnalyseResult>(unproResult.Count);
      foreach(var node in unproResult)
      {
        if(nameSet.Add(node.Serialize()))
        {
          results.Add(node);
        }
      }
      return "";
    }
  }

  public class BaiDuWaiMaiAnalyser
  {
    static public List<WebSiteAnalyseResult> Analyse(string webStr, out string shopName)
    {

      var shopNameMatch = Regex.Match(webStr, "<section class=\"basicinfo\">[\\s,\\S]*?<div class=\"one-line\">\\s*?<h2>(\\S+?)</h2>");
      shopName = null != shopNameMatch ? shopNameMatch.Groups[1].Value : "未知商贩";

      var orderMatches = Regex.Matches(webStr, "<li class=\"list-item\" data=\"[\\S,\\s]+?\\$[\\S,\\s]+?\\$[\\S,\\s]+?\\$(\\d+?)\\$(\\d+?(\\.\\d+?|\\d*?))\\$[\\S,\\s]+?</li>");
      List<WebSiteAnalyseResult> result = new List<WebSiteAnalyseResult>(orderMatches.Count);
      foreach (Match match in orderMatches)
      {
        WebSiteAnalyseResult tarResult = new WebSiteAnalyseResult();
        if (Regex.IsMatch(match.Value, "<div class=\"m-sel-icon\" unselectable=\"on\">"))
        {
          tarResult.has_ex = false;
        }
        else if (Regex.IsMatch(match.Value, "<div class=\"m-sel-icon\">"))
        {
          tarResult.has_ex = true;
        }
        else
        {
          continue;
        }


        bool useOriginPrise = false;
        var activity = Regex.Match(match.Value, "dishActivityId=\"\\d+?\"");
        // 有活动
        if(null != activity && activity.Success)
        {
          var orderLimite = Regex.Match(match.Value, "orderlimit=\"(\\d+?)\"");
          int limiteNum;
          if (null != orderLimite && orderLimite.Success && int.TryParse(orderLimite.Groups[1].Value, out limiteNum) && limiteNum < 10)
          {
            useOriginPrise = true;
          }
        }

        var priseMath = useOriginPrise ? Regex.Match(match.Value, "<div class=\"m-price\">[\\s,\\S]*?<del>\\s*?<strong>&#165;(\\d+?(\\.\\d+?|\\d*?))起?</strong>\\s*?</del>") : Regex.Match(match.Value, "<div class=\"m-price\">[\\s,\\S]*?<strong>&#165;(\\d+?(\\.\\d+?|\\d*?))起?</strong>");
        if (null == priseMath || !priseMath.Success)
          continue;
        tarResult.prise = float.Parse(priseMath.Groups[1].Value);

        var boxpriseScaleMatch = float.Parse(match.Groups[1].Value);
        var boxpriseMatch = float.Parse(match.Groups[2].Value);
        tarResult.boxprise = boxpriseMatch * boxpriseScaleMatch;

        var nameMatch = Regex.Match(match.Value, "<div class=\"info fl\">\\s*?<h3\\s*data-title=\"([\\S,\\s]+?)\" data-content=\"([\\S,\\s]+?)\"");
        if (null == nameMatch || !nameMatch.Success)
          continue;
        tarResult.name = nameMatch.Groups[1].Value;

        var imgMatch = Regex.Match(match.Value, "<div class=\"bg-img\" style=\"background: url\\(([\\S,\\s]+?)\\)");
        if (null != imgMatch && imgMatch.Success)
        {
          tarResult.img_path = imgMatch.Groups[1].Value;
        }

        result.Add(tarResult);

      }
      return result;
    }
  }

}
