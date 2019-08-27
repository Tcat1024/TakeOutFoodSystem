using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

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
    public enum WebSite
    {
      None,
      StarEleme,
      Eleme,
    }

    private static WebSite s_CurWebSite = WebSite.None;
    private static CookieCollection s_CurCookies;

    private delegate List<WebSiteAnalyseResult> AnalyseFunc(string html, out string name);
    static public string Analyser(string weburl, out List<WebSiteAnalyseResult> results, out string shopName, out string realUrl)
    {
      results = null;
      shopName = "";
      realUrl = weburl;
      if (weburl.Length <= 8 || (weburl.Substring(0, 8) != "https://" && weburl.Substring(0, 7) != "http://"))
      {
        weburl = "https://" + weburl;
      }
      var startMatch = Regex.Match(weburl, "//");
      int startIdx = 0;
      AnalyseFunc func = null;
      if (startMatch != null)
      {
        startIdx = startMatch.Index + 2;
      }
      if (weburl.Substring(startIdx, 11) == "star.ele.me")
      {
        func = BaiDuWaiMaiAnalyser.Analyse;
        s_CurWebSite = WebSite.StarEleme;
        s_CurCookies = null;
      }
      else if (weburl.Substring(startIdx, 10) == "www.ele.me")
      {
        if (s_CurWebSite != WebSite.Eleme || null == s_CurCookies)
        {
          var dialog = new ElemeLogin();
          if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.Yes)
          {
            return "网站进入失败";
          }
          s_CurCookies = dialog.CurCookies;
        }

        func = ElemeAnalyser.Analyse;
        s_CurWebSite = WebSite.Eleme;
      }
      else
      {
        return "不支持的网站";
      }
      
      var waitForm = new WebLogin(weburl);
      //waitForm.cookies = s_CurCookies;
      if (waitForm.ShowDialog() != DialogResult.OK)
      {
        return "网站链接失败";
      }
      realUrl = waitForm.Url;
      //WebClient MyWebClient = new WebClient();
      //if (null != s_CurCookies)
      //{
      //  var cookieC = new CookieContainer();

      //  StringBuilder cookieContent = new StringBuilder(s_CurCookies.Count);
      //  cookieContent.AppendFormat("{{{0}}}={{{1}}}", s_CurCookies[0].Name, s_CurCookies[0].Value);
      //  for (int i = 1; i < s_CurCookies.Count; ++i)
      //  {
      //    cookieContent.AppendFormat(";{{{0}}}={{{1}}}", s_CurCookies[i].Name, s_CurCookies[i].Value);
      //  }
      //  MyWebClient.Headers.Add(HttpRequestHeader.Cookie, cookieContent.ToString());
      //}

      ////MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据

      //Byte[] pageData;
      //try
      //{
      //  pageData = MyWebClient.DownloadData(weburl); //从指定网站下载数据
      //  if (pageData == null || pageData.Length == 0)
      //  {
      //    return "网址错误";
      //  }
      //}
      //catch (Exception e)
      //{
      //  return "网址无法访问：" + e.Message;
      //}

      //string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句            

      //string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句

      List<WebSiteAnalyseResult> unproResult = func(waitForm.Content, out shopName);

      if (null == unproResult || unproResult.Count <= 0)
      {
        return "网站解析错误";
      }

      HashSet<string> nameSet = new HashSet<string>();
      results = new List<WebSiteAnalyseResult>(unproResult.Count);
      foreach (var node in unproResult)
      {
        if (nameSet.Add(node.Serialize()))
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

      var shopNameMatch = Regex.Match(webStr, "<section class=\"basicinfo\">[\\s,\\S]*?<div class=\"one-line\">\\s*?<h2>(\\S+?)</h2>", RegexOptions.IgnoreCase);
      shopName = null != shopNameMatch ? shopNameMatch.Groups[1].Value : "未知商贩";

      var orderMatches = Regex.Matches(webStr, "<li class=\"list-item\" data=\"[\\S,\\s]+?\\$[\\S,\\s]+?\\$[\\S,\\s]+?\\$(\\d+?)\\$(\\d+?(\\.\\d+?|\\d*?))\\$[\\S,\\s]+?</li>", RegexOptions.IgnoreCase);
      List<WebSiteAnalyseResult> result = new List<WebSiteAnalyseResult>(orderMatches.Count);
      foreach (Match match in orderMatches)
      {
        WebSiteAnalyseResult tarResult = new WebSiteAnalyseResult();
        if (Regex.IsMatch(match.Value, "<div class=\"m-sel-icon\" unselectable=\"on\">", RegexOptions.IgnoreCase))
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
        var activity = Regex.Match(match.Value, "dishActivityId=\"\\d+?\"", RegexOptions.IgnoreCase);
        // 有活动
        if (null != activity && activity.Success)
        {
          var orderLimite = Regex.Match(match.Value, "orderlimit=\"(\\d+?)\"", RegexOptions.IgnoreCase);
          int limiteNum;
          if (null != orderLimite && orderLimite.Success && int.TryParse(orderLimite.Groups[1].Value, out limiteNum) && limiteNum < 10)
          {
            useOriginPrise = true;
          }
        }

        var priseMath = useOriginPrise ? Regex.Match(match.Value, "<div class=\"m-price\">[\\s,\\S]*?<del>\\s*?<strong>¥(\\d+?(\\.\\d+?|\\d*?))起?</strong>\\s*?</del>", RegexOptions.IgnoreCase) : Regex.Match(match.Value, "<div class=\"m-price\">[\\s,\\S]*?<strong>¥(\\d+?(\\.\\d+?|\\d*?))起?</strong>", RegexOptions.IgnoreCase);
        if (null == priseMath || !priseMath.Success)
          continue;
        tarResult.prise = float.Parse(priseMath.Groups[1].Value);

        var boxpriseScaleMatch = float.Parse(match.Groups[1].Value);
        var boxpriseMatch = float.Parse(match.Groups[2].Value);
        tarResult.boxprise = boxpriseMatch * boxpriseScaleMatch;

        var nameMatch = Regex.Match(match.Value, "<div class=\"info fl\">\\s*?<h3[\\S,\\s]*?data-title=\"([\\S,\\s]+?)\" data-content=\"([\\S,\\s]+?)\"", RegexOptions.IgnoreCase);
        if (null == nameMatch || !nameMatch.Success)
          continue;
        tarResult.name = nameMatch.Groups[1].Value;

        var imgMatch = Regex.Match(match.Value, "<div class=\"bg-img\" style=\"background: url\\(([\\S,\\s]+?)\\)", RegexOptions.IgnoreCase);
        if (null != imgMatch && imgMatch.Success)
        {
          tarResult.img_path = imgMatch.Groups[1].Value;
        }

        result.Add(tarResult);

      }
      return result;
    }
  }
  public class ElemeAnalyser
  {
    static public List<WebSiteAnalyseResult> Analyse(string webStr, out string shopName)
    {

      var shopNameMatch = Regex.Match(webStr, "<div class=\"shopguide-info\">[\\s,\\S]*?<div class=\"shopguide-info-wrapper\">\\s*?<div>\\s*?<h1[^>]*?>(\\S+?)</h1>");
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
        if (null != activity && activity.Success)
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

        var nameMatch = Regex.Match(match.Value, "<div class=\"info fl\">\\s*?<h3[\\S,\\s]*?data-title=\"([\\S,\\s]+?)\" data-content=\"([\\S,\\s]+?)\"");
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
