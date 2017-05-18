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
    private Size m_smallSize = new Size(1007, 100);
    private Size m_bigSize = new Size(1007, 705);
    private Thread m_httpThread;
    private HttpServer m_curServer;
    private float m_maxPrise = -1;
    public Form1()
    {
      InitializeComponent();
    }
    

    private void PutOutBtn_Click(object sender, EventArgs e)
    {
      if (TargetUrlTex.Text.Length <= 0)
      {
        MessageBox.Show("请填入外卖网址");
        return;
      }

      int curPort = 0;
      if(!int.TryParse(PortTex.Text, out curPort) || curPort <= 0)
      {
        MessageBox.Show("端口错误");
        return;
      }

      DataManager.instance.AddNewMenuData("测试1", 28);
      DataManager.instance.AddNewMenuData("测试2", 38);
      DataManager.instance.AddNewMenuData("测试3", 4);
      DataManager.instance.AddNewMenuData("测试2", 38);
      DataManager.instance.AddNewMenuData("测试1", 26);

      string webSiteStr = WebSiteGenerator.GetWebSiteStr("MMORPG订餐", "紫光园", TargetUrlTex.Text, m_maxPrise, DataManager.instance.menuData);
      if(webSiteStr == "")
      {
        MessageBox.Show("网页生成失败");
        return;
      }

      TryStopServer();
      var curIp = Dns.GetHostAddresses(Dns.GetHostName()).Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First();
      m_curServer = new MainHttpServer(curIp, curPort);
      MainHttpServer.webSetString = webSiteStr;
      m_httpThread = new Thread(new ThreadStart(m_curServer.listen));
      m_httpThread.IsBackground = true;
      m_httpThread.Start();

      PutOutUrlTex.Text = curIp.ToString() + ":" + curPort;
      ShowOpenGroup(true);
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
      DataManager.instance.Release();
      TryStopServer(true);
    }

    private void ClearBtn_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("确定要清除当前所有数据？", "Warning", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
      {
        return;
      }
    }

    private void StopBtn_Click(object sender, EventArgs e)
    {
      TryStopServer();
      if(null == DataManager.instance.ordersDataTable ||DataManager.instance.ordersDataTable.Rows.Count <= 0)
        ShowOpenGroup(false);
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
      ShowOpenGroup(false);

      ShowWait(true, "初始化中,");

      DataManager.instance.Init(this);
      DetailGrid.DataSource = DataManager.instance.detailDataTable.DefaultView;
      OrderGrid.DataSource = DataManager.instance.ordersDataTable.DefaultView;
      //TotalGrid.DataSource = DataManager.instance.totalDataList;
      WebResourceManager.instance.Init();
      ShowWait(false);
      splitContainer1.SplitterDistance = (int)(splitContainer1.Width * 0.7);
      splitContainer2.SplitterDistance = (int)(splitContainer2.Height * 0.7);

      if (!float.TryParse(MaxMoneyTex.Text, out m_maxPrise))
      {
        m_maxPrise = -1;
      }
    }

    private void ShowOpenGroup(bool bShow)
    {
      if(bShow)
      {
        OpenGroup.Visible = true;
        this.MaximumSize = Size.Empty;
        this.MinimumSize = m_bigSize;
      }
      else
      {
        OpenGroup.Visible = false;
        this.MinimumSize = m_smallSize;
        this.MaximumSize = m_smallSize;
      }
    }

    private void ShowWait(bool bShow, string desc = "")
    {
      if(bShow)
      {
        WaitPanel.Show();
        WaitLabel.Text = desc + "请稍等..";
        WaitLabel.Location = new Point(Size.Width>>1, Size.Height>>1);
      }
      else
      {
        WaitPanel.Hide();
      }
    }

    private void DetailGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
    {
      var detailTable = DataManager.instance.detailDataTable;
      var orderTable = DataManager.instance.ordersDataTable;
      if (null == detailTable || null == orderTable || e.RowIndex < 0 || e.RowIndex >= detailTable.Rows.Count)
      {
        return;
      }
      var tarRow = detailTable.Rows[e.RowIndex];
      orderTable.DefaultView.RowFilter = "customer = '"+ tarRow["name"] + "'";
    }

    private void MaxMoneyTex_TextChanged(object sender, EventArgs e)
    {
      if(!float.TryParse(MaxMoneyTex.Text, out m_maxPrise))
      {
        m_maxPrise = -1;
      }
      DetailGrid.Refresh();
    }

    private void DetailGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if(m_maxPrise > 0 && e.ColumnIndex >= 0 &&　e.ColumnIndex < DetailGrid.Columns.Count && DetailGrid.Columns[e.ColumnIndex].Name == "totalPrise")
      {
        var tarCell = DetailGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
        if(m_maxPrise < (float)tarCell.Value)
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
      if (m_maxPrise > 0 && e.ColumnIndex == 1 && e.Value is float && (float)e.Value > m_maxPrise)
      {
        e.CellStyle.BackColor = Color.Red;
      }
    }
  }
}
