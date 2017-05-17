using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace TakeOutSystem
{
  public partial class Form1 : Form
  {
    private Thread m_httpThread;
    private HttpServer m_curServer;
    public Form1()
    {
      InitializeComponent();
    }
    

    private void PutOutBtn_Click(object sender, EventArgs e)
    {
      //if(TargetUrlTex.Text.Length <= 0)
      //{
      //  MessageBox.Show("请填入外卖网址");
      //  return;
      //}

      int curPort = 0;
      if(!int.TryParse(PortTex.Text, out curPort) || curPort <= 0)
      {
        MessageBox.Show("端口错误");
        return;
      }
      var curIp = Dns.GetHostAddresses(Dns.GetHostName()).Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First();

      string webSiteStr = GenerateWebSite();
      if(webSiteStr == "")
      {
        MessageBox.Show("网页生成失败");
        return;
      }

      if(null != m_httpThread && null != m_curServer &&　m_curServer.IsActive)
      {
        if(MessageBox.Show("当前已有网络服务正在运行，是否终止当前服务？", "Warning", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
        {
          return;
        }

        m_curServer.IsActive = false;
        while (m_httpThread.IsAlive)
        {
          Thread.Sleep(500);
        }
      }
      
      m_curServer = new MainHttpServer(curIp, curPort);
      MainHttpServer.WebSetString = webSiteStr;
      m_httpThread = new Thread(new ThreadStart(m_curServer.listen));
      m_httpThread.IsBackground = true;
      m_httpThread.Start();

      PutOutUrlTex.Text = curIp.ToString() + ":" + curPort;
    }


    private string GenerateWebSite()
    {
      string rootPath = Directory.GetCurrentDirectory();
      if (!File.Exists(rootPath + "\\Web.html"))
      {
        return "";
      }
      return File.ReadAllText(rootPath + "\\Web.html");
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
    }
  }
}
