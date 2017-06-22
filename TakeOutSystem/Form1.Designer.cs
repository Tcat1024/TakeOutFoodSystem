namespace TakeOutSystem
{
  partial class Form1
  {
    /// <summary>
    /// 必需的设计器变量。
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 清理所有正在使用的资源。
    /// </summary>
    /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows 窗体设计器生成的代码

    /// <summary>
    /// 设计器支持所需的方法 - 不要修改
    /// 使用代码编辑器修改此方法的内容。
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.TargetUrlTex = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.MaxMoneyTex = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.DetailGrid = new System.Windows.Forms.DataGridView();
      this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.detailStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.totalPrise = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ExportBtn = new System.Windows.Forms.Button();
      this.LunchRad = new System.Windows.Forms.RadioButton();
      this.DinnerRad = new System.Windows.Forms.RadioButton();
      this.PutOutUrlTex = new System.Windows.Forms.TextBox();
      this.PortTex = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.ClearBtn = new System.Windows.Forms.Button();
      this.OrderGrid = new System.Windows.Forms.DataGridView();
      this.customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.order_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.order_ex = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.total_prise = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.order_prise = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.order_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.OpenGroup = new System.Windows.Forms.GroupBox();
      this.allowOrderChb = new System.Windows.Forms.CheckBox();
      this.ShowAllChb = new System.Windows.Forms.CheckBox();
      this.AllPeopleChb = new System.Windows.Forms.CheckBox();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.TotalGrid = new System.Windows.Forms.DataGridView();
      this.total_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.total_ex = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.total_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.total_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.panel1 = new System.Windows.Forms.Panel();
      this.StartBtn = new System.Windows.Forms.Button();
      this.StopBtn = new System.Windows.Forms.Button();
      this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
      this.StatusStripLabel = new System.Windows.Forms.ToolStripLabel();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.BottomStrip = new System.Windows.Forms.ToolStrip();
      this.BoxPriceTex = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.DetailGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.OrderGrid)).BeginInit();
      this.OpenGroup.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TotalGrid)).BeginInit();
      this.panel1.SuspendLayout();
      this.BottomStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // TargetUrlTex
      // 
      this.TargetUrlTex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TargetUrlTex.Location = new System.Drawing.Point(66, 12);
      this.TargetUrlTex.Name = "TargetUrlTex";
      this.TargetUrlTex.Size = new System.Drawing.Size(369, 21);
      this.TargetUrlTex.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(7, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(59, 12);
      this.label1.TabIndex = 1;
      this.label1.Text = "外卖网址:";
      // 
      // MaxMoneyTex
      // 
      this.MaxMoneyTex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.MaxMoneyTex.Location = new System.Drawing.Point(506, 12);
      this.MaxMoneyTex.Name = "MaxMoneyTex";
      this.MaxMoneyTex.Size = new System.Drawing.Size(40, 21);
      this.MaxMoneyTex.TabIndex = 6;
      this.MaxMoneyTex.TextChanged += new System.EventHandler(this.MaxMoneyTex_TextChanged);
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(441, 15);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(59, 12);
      this.label2.TabIndex = 5;
      this.label2.Text = "人均限额:";
      // 
      // DetailGrid
      // 
      this.DetailGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DetailGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.detailStr,
            this.totalPrise});
      this.DetailGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DetailGrid.Location = new System.Drawing.Point(0, 0);
      this.DetailGrid.Name = "DetailGrid";
      this.DetailGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
      this.DetailGrid.RowTemplate.Height = 23;
      this.DetailGrid.Size = new System.Drawing.Size(368, 214);
      this.DetailGrid.TabIndex = 9;
      this.DetailGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DetailGrid_CellPainting);
      this.DetailGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DetailGrid_CellValueChanged);
      this.DetailGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DetailGrid_RowEnter);
      // 
      // name
      // 
      this.name.DataPropertyName = "name";
      this.name.HeaderText = "姓名";
      this.name.Name = "name";
      // 
      // detailStr
      // 
      this.detailStr.DataPropertyName = "detailStr";
      this.detailStr.HeaderText = "详细";
      this.detailStr.Name = "detailStr";
      this.detailStr.Width = 250;
      // 
      // totalPrise
      // 
      this.totalPrise.DataPropertyName = "total_prise";
      this.totalPrise.HeaderText = "总价(元)";
      this.totalPrise.Name = "totalPrise";
      this.totalPrise.Width = 80;
      // 
      // ExportBtn
      // 
      this.ExportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ExportBtn.Location = new System.Drawing.Point(883, 568);
      this.ExportBtn.Name = "ExportBtn";
      this.ExportBtn.Size = new System.Drawing.Size(75, 23);
      this.ExportBtn.TabIndex = 10;
      this.ExportBtn.Text = "导出";
      this.ExportBtn.UseVisualStyleBackColor = true;
      this.ExportBtn.Visible = false;
      // 
      // LunchRad
      // 
      this.LunchRad.AutoSize = true;
      this.LunchRad.Checked = true;
      this.LunchRad.Location = new System.Drawing.Point(3, 3);
      this.LunchRad.Name = "LunchRad";
      this.LunchRad.Size = new System.Drawing.Size(47, 16);
      this.LunchRad.TabIndex = 11;
      this.LunchRad.TabStop = true;
      this.LunchRad.Text = "午饭";
      this.LunchRad.UseVisualStyleBackColor = true;
      // 
      // DinnerRad
      // 
      this.DinnerRad.AutoSize = true;
      this.DinnerRad.Location = new System.Drawing.Point(52, 3);
      this.DinnerRad.Name = "DinnerRad";
      this.DinnerRad.Size = new System.Drawing.Size(47, 16);
      this.DinnerRad.TabIndex = 12;
      this.DinnerRad.Text = "晚饭";
      this.DinnerRad.UseVisualStyleBackColor = true;
      // 
      // PutOutUrlTex
      // 
      this.PutOutUrlTex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.PutOutUrlTex.Location = new System.Drawing.Point(531, 20);
      this.PutOutUrlTex.Name = "PutOutUrlTex";
      this.PutOutUrlTex.ReadOnly = true;
      this.PutOutUrlTex.Size = new System.Drawing.Size(340, 21);
      this.PutOutUrlTex.TabIndex = 9;
      // 
      // PortTex
      // 
      this.PortTex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.PortTex.Location = new System.Drawing.Point(828, 12);
      this.PortTex.Name = "PortTex";
      this.PortTex.Size = new System.Drawing.Size(40, 21);
      this.PortTex.TabIndex = 10;
      this.PortTex.Text = "8080";
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(787, 15);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(35, 12);
      this.label3.TabIndex = 15;
      this.label3.Text = "端口:";
      // 
      // ClearBtn
      // 
      this.ClearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ClearBtn.Location = new System.Drawing.Point(883, 17);
      this.ClearBtn.Name = "ClearBtn";
      this.ClearBtn.Size = new System.Drawing.Size(75, 23);
      this.ClearBtn.TabIndex = 16;
      this.ClearBtn.Text = "清空";
      this.ClearBtn.UseVisualStyleBackColor = true;
      this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
      // 
      // OrderGrid
      // 
      this.OrderGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.OrderGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customer,
            this.order_name,
            this.order_ex,
            this.order_id,
            this.total_prise,
            this.order_prise,
            this.order_num});
      this.OrderGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.OrderGrid.Location = new System.Drawing.Point(0, 0);
      this.OrderGrid.Name = "OrderGrid";
      this.OrderGrid.RowTemplate.Height = 23;
      this.OrderGrid.Size = new System.Drawing.Size(368, 335);
      this.OrderGrid.TabIndex = 17;
      // 
      // customer
      // 
      this.customer.DataPropertyName = "customer";
      this.customer.HeaderText = "姓名";
      this.customer.Name = "customer";
      this.customer.Visible = false;
      // 
      // order_name
      // 
      this.order_name.DataPropertyName = "order_name";
      this.order_name.HeaderText = "菜名";
      this.order_name.Name = "order_name";
      // 
      // order_ex
      // 
      this.order_ex.DataPropertyName = "order_ex";
      this.order_ex.HeaderText = "备注";
      this.order_ex.Name = "order_ex";
      this.order_ex.Width = 150;
      // 
      // order_id
      // 
      this.order_id.DataPropertyName = "order_id";
      this.order_id.HeaderText = "ID";
      this.order_id.Name = "order_id";
      this.order_id.Visible = false;
      // 
      // total_prise
      // 
      this.total_prise.DataPropertyName = "total_prise";
      this.total_prise.HeaderText = "总价";
      this.total_prise.Name = "total_prise";
      this.total_prise.Visible = false;
      // 
      // order_prise
      // 
      this.order_prise.DataPropertyName = "order_prise";
      this.order_prise.HeaderText = "价格";
      this.order_prise.Name = "order_prise";
      this.order_prise.Width = 60;
      // 
      // order_num
      // 
      this.order_num.DataPropertyName = "order_num";
      this.order_num.HeaderText = "数量";
      this.order_num.Name = "order_num";
      this.order_num.Width = 60;
      // 
      // OpenGroup
      // 
      this.OpenGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.OpenGroup.Controls.Add(this.allowOrderChb);
      this.OpenGroup.Controls.Add(this.ShowAllChb);
      this.OpenGroup.Controls.Add(this.AllPeopleChb);
      this.OpenGroup.Controls.Add(this.splitContainer1);
      this.OpenGroup.Controls.Add(this.PutOutUrlTex);
      this.OpenGroup.Controls.Add(this.ExportBtn);
      this.OpenGroup.Controls.Add(this.ClearBtn);
      this.OpenGroup.Location = new System.Drawing.Point(0, 36);
      this.OpenGroup.Margin = new System.Windows.Forms.Padding(2);
      this.OpenGroup.MinimumSize = new System.Drawing.Size(742, 490);
      this.OpenGroup.Name = "OpenGroup";
      this.OpenGroup.Padding = new System.Windows.Forms.Padding(2);
      this.OpenGroup.Size = new System.Drawing.Size(970, 626);
      this.OpenGroup.TabIndex = 19;
      this.OpenGroup.TabStop = false;
      // 
      // allowOrderChb
      // 
      this.allowOrderChb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.allowOrderChb.AutoSize = true;
      this.allowOrderChb.Checked = true;
      this.allowOrderChb.CheckState = System.Windows.Forms.CheckState.Checked;
      this.allowOrderChb.Location = new System.Drawing.Point(886, 82);
      this.allowOrderChb.Name = "allowOrderChb";
      this.allowOrderChb.Size = new System.Drawing.Size(72, 16);
      this.allowOrderChb.TabIndex = 23;
      this.allowOrderChb.Text = "允许订餐";
      this.allowOrderChb.UseVisualStyleBackColor = true;
      this.allowOrderChb.CheckStateChanged += new System.EventHandler(this.allowOrderChb_CheckStateChanged);
      // 
      // ShowAllChb
      // 
      this.ShowAllChb.AutoSize = true;
      this.ShowAllChb.Location = new System.Drawing.Point(147, 22);
      this.ShowAllChb.Margin = new System.Windows.Forms.Padding(2);
      this.ShowAllChb.Name = "ShowAllChb";
      this.ShowAllChb.Size = new System.Drawing.Size(72, 16);
      this.ShowAllChb.TabIndex = 22;
      this.ShowAllChb.Text = "显示总表";
      this.ShowAllChb.UseVisualStyleBackColor = true;
      this.ShowAllChb.CheckedChanged += new System.EventHandler(this.ShowAllChb_CheckedChanged);
      // 
      // AllPeopleChb
      // 
      this.AllPeopleChb.AutoSize = true;
      this.AllPeopleChb.Checked = true;
      this.AllPeopleChb.CheckState = System.Windows.Forms.CheckState.Checked;
      this.AllPeopleChb.Location = new System.Drawing.Point(9, 22);
      this.AllPeopleChb.Margin = new System.Windows.Forms.Padding(2);
      this.AllPeopleChb.Name = "AllPeopleChb";
      this.AllPeopleChb.Size = new System.Drawing.Size(120, 16);
      this.AllPeopleChb.TabIndex = 21;
      this.AllPeopleChb.Text = "是否显示未订餐人";
      this.AllPeopleChb.UseVisualStyleBackColor = true;
      this.AllPeopleChb.CheckedChanged += new System.EventHandler(this.AllPeopleChb_CheckedChanged);
      // 
      // splitContainer1
      // 
      this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer1.Location = new System.Drawing.Point(0, 46);
      this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.TotalGrid);
      this.splitContainer1.Size = new System.Drawing.Size(870, 552);
      this.splitContainer1.SplitterDistance = 368;
      this.splitContainer1.SplitterWidth = 3;
      this.splitContainer1.TabIndex = 20;
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.DetailGrid);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.OrderGrid);
      this.splitContainer2.Size = new System.Drawing.Size(368, 552);
      this.splitContainer2.SplitterDistance = 214;
      this.splitContainer2.SplitterWidth = 3;
      this.splitContainer2.TabIndex = 0;
      // 
      // TotalGrid
      // 
      this.TotalGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.TotalGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.total_name,
            this.total_ex,
            this.total_num,
            this.total_id});
      this.TotalGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TotalGrid.Location = new System.Drawing.Point(0, 0);
      this.TotalGrid.Name = "TotalGrid";
      this.TotalGrid.RowTemplate.Height = 23;
      this.TotalGrid.Size = new System.Drawing.Size(499, 552);
      this.TotalGrid.TabIndex = 19;
      // 
      // total_name
      // 
      this.total_name.DataPropertyName = "order_name";
      this.total_name.HeaderText = "名称";
      this.total_name.Name = "total_name";
      // 
      // total_ex
      // 
      this.total_ex.DataPropertyName = "order_ex";
      this.total_ex.HeaderText = "备注";
      this.total_ex.Name = "total_ex";
      this.total_ex.Width = 150;
      // 
      // total_num
      // 
      this.total_num.DataPropertyName = "total_num";
      this.total_num.HeaderText = "数量";
      this.total_num.Name = "total_num";
      this.total_num.Width = 60;
      // 
      // total_id
      // 
      this.total_id.DataPropertyName = "order_id";
      this.total_id.HeaderText = "ID";
      this.total_id.Name = "total_id";
      this.total_id.Visible = false;
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.Controls.Add(this.DinnerRad);
      this.panel1.Controls.Add(this.LunchRad);
      this.panel1.Location = new System.Drawing.Point(681, 10);
      this.panel1.Margin = new System.Windows.Forms.Padding(2);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(100, 24);
      this.panel1.TabIndex = 19;
      // 
      // StartBtn
      // 
      this.StartBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.StartBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StartBtn.BackgroundImage")));
      this.StartBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.StartBtn.Font = new System.Drawing.Font("幼圆", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.StartBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(66)))), ((int)(((byte)(2)))));
      this.StartBtn.Location = new System.Drawing.Point(883, 4);
      this.StartBtn.Name = "StartBtn";
      this.StartBtn.Size = new System.Drawing.Size(75, 32);
      this.StartBtn.TabIndex = 8;
      this.StartBtn.Text = " 开始";
      this.StartBtn.UseVisualStyleBackColor = true;
      this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
      // 
      // StopBtn
      // 
      this.StopBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.StopBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StopBtn.BackgroundImage")));
      this.StopBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.StopBtn.Font = new System.Drawing.Font("幼圆", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.StopBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
      this.StopBtn.Location = new System.Drawing.Point(883, 4);
      this.StopBtn.Name = "StopBtn";
      this.StopBtn.Size = new System.Drawing.Size(75, 32);
      this.StopBtn.TabIndex = 21;
      this.StopBtn.Text = " 停止";
      this.StopBtn.UseVisualStyleBackColor = true;
      this.StopBtn.Visible = false;
      this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
      // 
      // toolStripLabel2
      // 
      this.toolStripLabel2.Name = "toolStripLabel2";
      this.toolStripLabel2.Size = new System.Drawing.Size(175, 22);
      this.toolStripLabel2.Text = "@Github.Tcat1024.W.H.M@o";
      // 
      // StatusStripLabel
      // 
      this.StatusStripLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.StatusStripLabel.Name = "StatusStripLabel";
      this.StatusStripLabel.Size = new System.Drawing.Size(68, 22);
      this.StatusStripLabel.Text = "服务未开启";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
      // 
      // BottomStrip
      // 
      this.BottomStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.BottomStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.StatusStripLabel,
            this.toolStripSeparator1});
      this.BottomStrip.Location = new System.Drawing.Point(0, 638);
      this.BottomStrip.Name = "BottomStrip";
      this.BottomStrip.Size = new System.Drawing.Size(970, 25);
      this.BottomStrip.TabIndex = 24;
      this.BottomStrip.Text = "BottomStrip";
      // 
      // BoxPriceTex
      // 
      this.BoxPriceTex.Location = new System.Drawing.Point(605, 12);
      this.BoxPriceTex.Name = "BoxPriceTex";
      this.BoxPriceTex.Size = new System.Drawing.Size(49, 21);
      this.BoxPriceTex.TabIndex = 7;
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(552, 15);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(47, 12);
      this.label4.TabIndex = 25;
      this.label4.Text = "餐盒费:";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(970, 663);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.BoxPriceTex);
      this.Controls.Add(this.BottomStrip);
      this.Controls.Add(this.StartBtn);
      this.Controls.Add(this.StopBtn);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.OpenGroup);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.PortTex);
      this.Controls.Add(this.MaxMoneyTex);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.TargetUrlTex);
      this.Name = "Form1";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.Text = "订餐吧";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.DetailGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.OrderGrid)).EndInit();
      this.OpenGroup.ResumeLayout(false);
      this.OpenGroup.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
      this.splitContainer2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.TotalGrid)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.BottomStrip.ResumeLayout(false);
      this.BottomStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox TargetUrlTex;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox MaxMoneyTex;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DataGridView DetailGrid;
    private System.Windows.Forms.Button ExportBtn;
    private System.Windows.Forms.RadioButton LunchRad;
    private System.Windows.Forms.RadioButton DinnerRad;
    private System.Windows.Forms.TextBox PutOutUrlTex;
    private System.Windows.Forms.TextBox PortTex;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button ClearBtn;
    private System.Windows.Forms.DataGridView OrderGrid;
    private System.Windows.Forms.GroupBox OpenGroup;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.DataGridViewTextBoxColumn name;
    private System.Windows.Forms.DataGridViewTextBoxColumn detailStr;
    private System.Windows.Forms.DataGridViewTextBoxColumn totalPrise;
    private System.Windows.Forms.CheckBox AllPeopleChb;
    private System.Windows.Forms.Button StartBtn;
    private System.Windows.Forms.Button StopBtn;
    private System.Windows.Forms.DataGridViewTextBoxColumn customer;
    private System.Windows.Forms.DataGridViewTextBoxColumn order_name;
    private System.Windows.Forms.DataGridViewTextBoxColumn order_ex;
    private System.Windows.Forms.DataGridViewTextBoxColumn order_id;
    private System.Windows.Forms.DataGridViewTextBoxColumn total_prise;
    private System.Windows.Forms.DataGridViewTextBoxColumn order_prise;
    private System.Windows.Forms.DataGridViewTextBoxColumn order_num;
    private System.Windows.Forms.CheckBox ShowAllChb;
    private System.Windows.Forms.DataGridView TotalGrid;
    private System.Windows.Forms.DataGridViewTextBoxColumn total_name;
    private System.Windows.Forms.DataGridViewTextBoxColumn total_ex;
    private System.Windows.Forms.DataGridViewTextBoxColumn total_num;
    private System.Windows.Forms.DataGridViewTextBoxColumn total_id;
    private System.Windows.Forms.ToolStripLabel toolStripLabel2;
    private System.Windows.Forms.ToolStripLabel StatusStripLabel;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStrip BottomStrip;
    private System.Windows.Forms.CheckBox allowOrderChb;
    private System.Windows.Forms.TextBox BoxPriceTex;
    private System.Windows.Forms.Label label4;
  }
}

