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
    private float m_maxPrice = -1;
    private string m_lastWebSite = "";
    private string m_curStatusStr = "";
    private bool m_bWait = false;
    public Form1()
    {
      InitializeComponent();
    }
    
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      if(MessageBox.Show("确定要关闭吗?","退出", MessageBoxButtons.YesNo) != DialogResult.Yes)
      {
        e.Cancel = true;
        return;
      }
      DataManager.instance.Release();
      TryStopServer(true);
    }

    private void ClearBtn_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("确定要清除当前所有数据？", "Warning", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
      {
        return;
      }
      DataManager.instance.Clear();
    }

    private void StartBtn_Click(object sender, EventArgs e)
    {
      ShowWait(true, "服务开启中");
      try
      {
        if (TargetUrlTex.Text.Length <= 0)
        {
          MessageBox.Show("请填入外卖网址");
          return;
        }

        if (m_lastWebSite != "" && TargetUrlTex.Text != m_lastWebSite && DataManager.instance.ordersDataTable.Rows.Count > 0)
        {
          MessageBox.Show("网址已更改，请先清楚原有数据");
          return;
        }

        int curPort = 0;
        if (!int.TryParse(PortTex.Text, out curPort) || curPort <= 0)
        {
          MessageBox.Show("端口错误");
          return;
        }

        List<WebSiteAnalyseResult> result;
        string shopName;
        var errorMsg = WebSiteAnalyser.Analyser(TargetUrlTex.Text, out result, out shopName);

        if (errorMsg != "")
        {
          MessageBox.Show(errorMsg);
          return;
        }

        DataManager.instance.ClearMenuData();
        foreach (var ret in result)
        {
          DataManager.instance.AddNewMenuData(ret.name, ret.prise, ret.has_ex, ret.img_path, ret.boxprise);
        }
        m_lastWebSite = TargetUrlTex.Text;
        
        string webSiteStr = WebSiteGenerator.GetWebSiteStr("订餐吧", shopName, TargetUrlTex.Text, m_maxPrice, calcBoxPriseChb.Checked, DataManager.instance.menuData);
        if (webSiteStr == "")
        {
          MessageBox.Show("网页生成失败");
          return;
        }

        TryStopServer();
        var curIp = Dns.GetHostAddresses(Dns.GetHostName()).Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First();
        m_curServer = new MainHttpServer(curIp, curPort);
        DataManager.allowOrder = allowOrderChb.Checked;
        MainHttpServer.webSetString = webSiteStr;
        m_httpThread = new Thread(new ThreadStart(m_curServer.listen));
        m_httpThread.IsBackground = true;
        m_httpThread.Start();

        PutOutUrlTex.Text = curIp.ToString() + ":" + curPort;

        MessageBox.Show("服务开启成功");

        StartBtn.Visible = false;
        StopBtn.Visible = true;
        SetStatusMsg("服务已开启");
      }
      catch(Exception ex)
      {
        MessageBox.Show("error:" + ex.Message);
      }
      finally
      {
        ShowWait(false);
      }
    }

    private void StopBtn_Click(object sender, EventArgs e)
    {
      ShowWait(true, "服务关闭中");
      if (!TryStopServer())
      {
        ShowWait(false);
        return;
      }
      MessageBox.Show("服务已停止");
      StartBtn.Visible = true;
      StopBtn.Visible = false;
      ShowWait(false);
      SetStatusMsg("服务已停止");
    }

    private bool TryStopServer(bool bForce = false)
    {
      if (null != m_httpThread && null != m_curServer && m_curServer.isActive)
      {
        if (!bForce && MessageBox.Show("当前已有网络服务正在运行，是否终止当前服务？", "Warning", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
        {
          return false;
        }

        m_curServer.isActive = false;
        while (m_httpThread.IsAlive)
        {
          Thread.Sleep(500);
        }
        m_curServer = null;
        m_httpThread = null;
      }
      return true;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      if(DateTime.Now.Hour <= 14)
      {
        LunchRad.Checked = true;
      }
      else
      {
        DinnerRad.Checked = true;
      }

      ShowWait(true, "初始化中");

      DataManager.instance.Init(this);
      DetailGrid.DataSource = DataManager.instance.detailDataTable.DefaultView;
      OrderGrid.DataSource = DataManager.instance.ordersDataTable.DefaultView;
      TotalGrid.DataSource = DataManager.instance.totalDataTable.DefaultView;
      WebResourceManager.instance.Init();
      ShowWait(false);
      SetStatusMsg("准备就绪");
      splitContainer1.SplitterDistance = (int)(splitContainer1.Width * 0.6);
      splitContainer2.SplitterDistance = (int)(splitContainer2.Height * 0.7);

      if (!float.TryParse(MaxMoneyTex.Text, out m_maxPrice))
      {
        m_maxPrice = -1;
      }
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

    private void DetailGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
    {
      if (ShowAllChb.Checked)
        return;
      var detailTable = DataManager.instance.detailDataTable;
      var orderTable = DataManager.instance.ordersDataTable;
      if (null == detailTable || null == orderTable || e.RowIndex < 0 || e.RowIndex >= DetailGrid.Rows.Count)
      {
        return;
      }
      var tarRow = DetailGrid.Rows[e.RowIndex].DataBoundItem as DataRowView;
      if (null == tarRow)
        return;
      orderTable.DefaultView.RowFilter = "customer = '"+ tarRow["name"] + "'";
    }

    private void MaxMoneyTex_TextChanged(object sender, EventArgs e)
    {
      if(!float.TryParse(MaxMoneyTex.Text, out m_maxPrice))
      {
        m_maxPrice = -1;
      }
      DetailGrid.Refresh();
    }

    private void DetailGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if(m_maxPrice > 0 && e.ColumnIndex >= 0 &&　e.ColumnIndex < DetailGrid.Columns.Count && DetailGrid.Columns[e.ColumnIndex].Name == "totalPrise")
      {
        var tarCell = DetailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
        if(m_maxPrice < (float)tarCell.Value)
        {
          tarCell.Style.BackColor = System.Drawing.Color.Red;
        }
        else
        {
          tarCell.Style.BackColor = tarCell.OwningRow.DefaultCellStyle.BackColor;
        }
      }
    }

    private void DetailGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
      if (m_maxPrice > 0 && e.ColumnIndex == 2 && e.Value is float && (float)e.Value > m_maxPrice)
      {
        e.CellStyle.BackColor = Color.Red;
      }
    }

    private void AllPeopleChb_CheckedChanged(object sender, EventArgs e)
    {
      DataManager.instance.showDefaultPeople = AllPeopleChb.Checked;
    }

    private void ShowAllChb_CheckedChanged(object sender, EventArgs e)
    {
      OrderGrid.Columns["customer"].Visible = ShowAllChb.Checked;
      if(ShowAllChb.Checked)
      {
        DataManager.instance.ordersDataTable.DefaultView.RowFilter = "";
      }
    }

    private void ShowWait(bool bShow, string waitMsg = "")
    {
      StatusStripLabel.Text = bShow ? (waitMsg.Length > 0 ? waitMsg + ",请稍等..." : "请稍等...") : m_curStatusStr;
      m_bWait = bShow;
    }

    private void SetStatusMsg(string status)
    {
      m_curStatusStr = status;
      if (!m_bWait)
      {
        StatusStripLabel.Text = m_curStatusStr;
      }
    }

    private void allowOrderChb_CheckStateChanged(object sender, EventArgs e)
    {
      DataManager.allowOrder = allowOrderChb.Checked;
    }
  }
}
