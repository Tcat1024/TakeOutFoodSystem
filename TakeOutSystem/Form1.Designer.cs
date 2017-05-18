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
      this.TargetUrlTex = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.PutOutBtn = new System.Windows.Forms.Button();
      this.MaxMoneyTex = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.DetailGrid = new System.Windows.Forms.DataGridView();
      this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.totalPrise = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ExportBtn = new System.Windows.Forms.Button();
      this.LunchRad = new System.Windows.Forms.RadioButton();
      this.DinnerRad = new System.Windows.Forms.RadioButton();
      this.PutOutUrlTex = new System.Windows.Forms.TextBox();
      this.PortTex = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.ClearBtn = new System.Windows.Forms.Button();
      this.OrderGrid = new System.Windows.Forms.DataGridView();
      this.order_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.total_prise = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.order_prise = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.order_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.StopBtn = new System.Windows.Forms.Button();
      this.OpenGroup = new System.Windows.Forms.GroupBox();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.TotalGrid = new System.Windows.Forms.DataGridView();
      this.panel1 = new System.Windows.Forms.Panel();
      this.WaitPanel = new System.Windows.Forms.Panel();
      this.WaitLabel = new System.Windows.Forms.Label();
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
      this.WaitPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // TargetUrlTex
      // 
      this.TargetUrlTex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TargetUrlTex.Location = new System.Drawing.Point(88, 15);
      this.TargetUrlTex.Margin = new System.Windows.Forms.Padding(4);
      this.TargetUrlTex.Name = "TargetUrlTex";
      this.TargetUrlTex.Size = new System.Drawing.Size(351, 25);
      this.TargetUrlTex.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 19);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(75, 15);
      this.label1.TabIndex = 1;
      this.label1.Text = "外卖网址:";
      // 
      // PutOutBtn
      // 
      this.PutOutBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.PutOutBtn.Location = new System.Drawing.Point(873, 15);
      this.PutOutBtn.Margin = new System.Windows.Forms.Padding(4);
      this.PutOutBtn.Name = "PutOutBtn";
      this.PutOutBtn.Size = new System.Drawing.Size(100, 29);
      this.PutOutBtn.TabIndex = 2;
      this.PutOutBtn.Text = "发布";
      this.PutOutBtn.UseVisualStyleBackColor = true;
      this.PutOutBtn.Click += new System.EventHandler(this.PutOutBtn_Click);
      // 
      // MaxMoneyTex
      // 
      this.MaxMoneyTex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.MaxMoneyTex.Location = new System.Drawing.Point(535, 14);
      this.MaxMoneyTex.Margin = new System.Windows.Forms.Padding(4);
      this.MaxMoneyTex.Name = "MaxMoneyTex";
      this.MaxMoneyTex.Size = new System.Drawing.Size(52, 25);
      this.MaxMoneyTex.TabIndex = 6;
      this.MaxMoneyTex.TextChanged += new System.EventHandler(this.MaxMoneyTex_TextChanged);
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(448, 19);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(75, 15);
      this.label2.TabIndex = 5;
      this.label2.Text = "人均限额:";
      // 
      // DetailGrid
      // 
      this.DetailGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DetailGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.totalPrise});
      this.DetailGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DetailGrid.Location = new System.Drawing.Point(0, 0);
      this.DetailGrid.Margin = new System.Windows.Forms.Padding(4);
      this.DetailGrid.Name = "DetailGrid";
      this.DetailGrid.RowTemplate.Height = 23;
      this.DetailGrid.Size = new System.Drawing.Size(544, 300);
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
      // totalPrise
      // 
      this.totalPrise.DataPropertyName = "total_prise";
      this.totalPrise.HeaderText = "总合(元)";
      this.totalPrise.Name = "totalPrise";
      // 
      // ExportBtn
      // 
      this.ExportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ExportBtn.Location = new System.Drawing.Point(873, 539);
      this.ExportBtn.Margin = new System.Windows.Forms.Padding(4);
      this.ExportBtn.Name = "ExportBtn";
      this.ExportBtn.Size = new System.Drawing.Size(100, 29);
      this.ExportBtn.TabIndex = 10;
      this.ExportBtn.Text = "导出";
      this.ExportBtn.UseVisualStyleBackColor = true;
      // 
      // LunchRad
      // 
      this.LunchRad.AutoSize = true;
      this.LunchRad.Checked = true;
      this.LunchRad.Location = new System.Drawing.Point(4, 4);
      this.LunchRad.Margin = new System.Windows.Forms.Padding(4);
      this.LunchRad.Name = "LunchRad";
      this.LunchRad.Size = new System.Drawing.Size(58, 19);
      this.LunchRad.TabIndex = 11;
      this.LunchRad.TabStop = true;
      this.LunchRad.Text = "午饭";
      this.LunchRad.UseVisualStyleBackColor = true;
      // 
      // DinnerRad
      // 
      this.DinnerRad.AutoSize = true;
      this.DinnerRad.Location = new System.Drawing.Point(69, 4);
      this.DinnerRad.Margin = new System.Windows.Forms.Padding(4);
      this.DinnerRad.Name = "DinnerRad";
      this.DinnerRad.Size = new System.Drawing.Size(58, 19);
      this.DinnerRad.TabIndex = 12;
      this.DinnerRad.Text = "晚饭";
      this.DinnerRad.UseVisualStyleBackColor = true;
      // 
      // PutOutUrlTex
      // 
      this.PutOutUrlTex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.PutOutUrlTex.Location = new System.Drawing.Point(404, 25);
      this.PutOutUrlTex.Margin = new System.Windows.Forms.Padding(4);
      this.PutOutUrlTex.Name = "PutOutUrlTex";
      this.PutOutUrlTex.ReadOnly = true;
      this.PutOutUrlTex.Size = new System.Drawing.Size(452, 25);
      this.PutOutUrlTex.TabIndex = 13;
      // 
      // PortTex
      // 
      this.PortTex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.PortTex.Location = new System.Drawing.Point(800, 15);
      this.PortTex.Margin = new System.Windows.Forms.Padding(4);
      this.PortTex.Name = "PortTex";
      this.PortTex.Size = new System.Drawing.Size(52, 25);
      this.PortTex.TabIndex = 14;
      this.PortTex.Text = "8080";
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(745, 19);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(45, 15);
      this.label3.TabIndex = 15;
      this.label3.Text = "端口:";
      // 
      // ClearBtn
      // 
      this.ClearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ClearBtn.Location = new System.Drawing.Point(873, 82);
      this.ClearBtn.Margin = new System.Windows.Forms.Padding(4);
      this.ClearBtn.Name = "ClearBtn";
      this.ClearBtn.Size = new System.Drawing.Size(100, 29);
      this.ClearBtn.TabIndex = 16;
      this.ClearBtn.Text = "清空";
      this.ClearBtn.UseVisualStyleBackColor = true;
      this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
      // 
      // OrderGrid
      // 
      this.OrderGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.OrderGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.order_name,
            this.customer,
            this.order_id,
            this.total_prise,
            this.order_prise,
            this.order_num});
      this.OrderGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.OrderGrid.Location = new System.Drawing.Point(0, 0);
      this.OrderGrid.Margin = new System.Windows.Forms.Padding(4);
      this.OrderGrid.Name = "OrderGrid";
      this.OrderGrid.RowTemplate.Height = 23;
      this.OrderGrid.Size = new System.Drawing.Size(544, 249);
      this.OrderGrid.TabIndex = 17;
      // 
      // order_name
      // 
      this.order_name.DataPropertyName = "order_name";
      this.order_name.HeaderText = "名称";
      this.order_name.Name = "order_name";
      // 
      // customer
      // 
      this.customer.DataPropertyName = "customer";
      this.customer.HeaderText = "姓名";
      this.customer.Name = "customer";
      this.customer.Visible = false;
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
      // 
      // order_num
      // 
      this.order_num.DataPropertyName = "order_num";
      this.order_num.HeaderText = "数量";
      this.order_num.Name = "order_num";
      // 
      // StopBtn
      // 
      this.StopBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.StopBtn.Location = new System.Drawing.Point(873, 21);
      this.StopBtn.Margin = new System.Windows.Forms.Padding(4);
      this.StopBtn.Name = "StopBtn";
      this.StopBtn.Size = new System.Drawing.Size(100, 29);
      this.StopBtn.TabIndex = 18;
      this.StopBtn.Text = "停止";
      this.StopBtn.UseVisualStyleBackColor = true;
      this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
      // 
      // OpenGroup
      // 
      this.OpenGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.OpenGroup.Controls.Add(this.splitContainer1);
      this.OpenGroup.Controls.Add(this.PutOutUrlTex);
      this.OpenGroup.Controls.Add(this.StopBtn);
      this.OpenGroup.Controls.Add(this.ExportBtn);
      this.OpenGroup.Controls.Add(this.ClearBtn);
      this.OpenGroup.Location = new System.Drawing.Point(0, 45);
      this.OpenGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.OpenGroup.MinimumSize = new System.Drawing.Size(989, 612);
      this.OpenGroup.Name = "OpenGroup";
      this.OpenGroup.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.OpenGroup.Size = new System.Drawing.Size(989, 612);
      this.OpenGroup.TabIndex = 19;
      this.OpenGroup.TabStop = false;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer1.Location = new System.Drawing.Point(0, 57);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.TotalGrid);
      this.splitContainer1.Size = new System.Drawing.Size(856, 553);
      this.splitContainer1.SplitterDistance = 544;
      this.splitContainer1.TabIndex = 20;
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
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
      this.splitContainer2.Size = new System.Drawing.Size(544, 553);
      this.splitContainer2.SplitterDistance = 300;
      this.splitContainer2.TabIndex = 0;
      // 
      // TotalGrid
      // 
      this.TotalGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.TotalGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TotalGrid.Location = new System.Drawing.Point(0, 0);
      this.TotalGrid.Margin = new System.Windows.Forms.Padding(4);
      this.TotalGrid.Name = "TotalGrid";
      this.TotalGrid.RowTemplate.Height = 23;
      this.TotalGrid.Size = new System.Drawing.Size(308, 553);
      this.TotalGrid.TabIndex = 19;
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.Controls.Add(this.DinnerRad);
      this.panel1.Controls.Add(this.LunchRad);
      this.panel1.Location = new System.Drawing.Point(604, 12);
      this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(133, 30);
      this.panel1.TabIndex = 19;
      // 
      // WaitPanel
      // 
      this.WaitPanel.Controls.Add(this.WaitLabel);
      this.WaitPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.WaitPanel.Location = new System.Drawing.Point(0, 0);
      this.WaitPanel.Margin = new System.Windows.Forms.Padding(4);
      this.WaitPanel.Name = "WaitPanel";
      this.WaitPanel.Size = new System.Drawing.Size(989, 658);
      this.WaitPanel.TabIndex = 19;
      this.WaitPanel.Visible = false;
      // 
      // WaitLabel
      // 
      this.WaitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.WaitLabel.AutoSize = true;
      this.WaitLabel.Location = new System.Drawing.Point(448, 324);
      this.WaitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.WaitLabel.Name = "WaitLabel";
      this.WaitLabel.Size = new System.Drawing.Size(76, 15);
      this.WaitLabel.TabIndex = 0;
      this.WaitLabel.Text = "请稍等...";
      this.WaitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.ClientSize = new System.Drawing.Size(989, 658);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.OpenGroup);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.PortTex);
      this.Controls.Add(this.MaxMoneyTex);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.PutOutBtn);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.TargetUrlTex);
      this.Controls.Add(this.WaitPanel);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "Form1";
      this.Text = "Form1";
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
      this.WaitPanel.ResumeLayout(false);
      this.WaitPanel.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox TargetUrlTex;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button PutOutBtn;
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
    private System.Windows.Forms.Button StopBtn;
    private System.Windows.Forms.GroupBox OpenGroup;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel WaitPanel;
    private System.Windows.Forms.Label WaitLabel;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.DataGridView TotalGrid;
    private System.Windows.Forms.DataGridViewTextBoxColumn name;
    private System.Windows.Forms.DataGridViewTextBoxColumn totalPrise;
    private System.Windows.Forms.DataGridViewTextBoxColumn order_name;
    private System.Windows.Forms.DataGridViewTextBoxColumn customer;
    private System.Windows.Forms.DataGridViewTextBoxColumn order_id;
    private System.Windows.Forms.DataGridViewTextBoxColumn total_prise;
    private System.Windows.Forms.DataGridViewTextBoxColumn order_prise;
    private System.Windows.Forms.DataGridViewTextBoxColumn order_num;
  }
}

