using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TakeOutSystem
{
  public partial class Form2 : Form
  {
    [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool InternetSetCookie(string lpszUrlName, string lbszCookieName, string lpszCookieData);
    public Form2()
    {
      InitializeComponent();
    }

    public string url;
    public CookieCollection cookies;
    public string content;

    private void Form2_Shown(object sender, EventArgs e)
    {
      if(null != cookies)
      {
        foreach(Cookie cookie in cookies)
        {
          InternetSetCookie(url, null, cookie.ToString());
        }
      }
      webBrowser1.Navigate(new Uri(url));
    }

    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
      if (webBrowser1.ReadyState < WebBrowserReadyState.Complete) return;
      content = webBrowser1.DocumentText;
      DialogResult = DialogResult.OK;
    }
  }
}
