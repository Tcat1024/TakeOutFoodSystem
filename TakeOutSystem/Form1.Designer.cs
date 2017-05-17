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
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.ExportBtn = new System.Windows.Forms.Button();
      this.LunchRad = new System.Windows.Forms.RadioButton();
      this.DinnerRad = new System.Windows.Forms.RadioButton();
      this.PutOutUrlTex = new System.Windows.Forms.TextBox();
      this.PortTex = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // TargetUrlTex
      // 
      this.TargetUrlTex.Location = new System.Drawing.Point(66, 12);
      this.TargetUrlTex.Name = "TargetUrlTex";
      this.TargetUrlTex.Size = new System.Drawing.Size(264, 21);
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
      // PutOutBtn
      // 
      this.PutOutBtn.Location = new System.Drawing.Point(655, 12);
      this.PutOutBtn.Name = "PutOutBtn";
      this.PutOutBtn.Size = new System.Drawing.Size(75, 23);
      this.PutOutBtn.TabIndex = 2;
      this.PutOutBtn.Text = "发布";
      this.PutOutBtn.UseVisualStyleBackColor = true;
      this.PutOutBtn.Click += new System.EventHandler(this.PutOutBtn_Click);
      // 
      // MaxMoneyTex
      // 
      this.MaxMoneyTex.Location = new System.Drawing.Point(401, 11);
      this.MaxMoneyTex.Name = "MaxMoneyTex";
      this.MaxMoneyTex.Size = new System.Drawing.Size(40, 21);
      this.MaxMoneyTex.TabIndex = 6;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(336, 15);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(59, 12);
      this.label2.TabIndex = 5;
      this.label2.Text = "人均限额:";
      // 
      // dataGridView1
      // 
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Location = new System.Drawing.Point(12, 72);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowTemplate.Height = 23;
      this.dataGridView1.Size = new System.Drawing.Size(637, 442);
      this.dataGridView1.TabIndex = 9;
      // 
      // ExportBtn
      // 
      this.ExportBtn.Location = new System.Drawing.Point(655, 476);
      this.ExportBtn.Name = "ExportBtn";
      this.ExportBtn.Size = new System.Drawing.Size(75, 23);
      this.ExportBtn.TabIndex = 10;
      this.ExportBtn.Text = "导出";
      this.ExportBtn.UseVisualStyleBackColor = true;
      // 
      // LunchRad
      // 
      this.LunchRad.AutoSize = true;
      this.LunchRad.Location = new System.Drawing.Point(447, 15);
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
      this.DinnerRad.Location = new System.Drawing.Point(500, 15);
      this.DinnerRad.Name = "DinnerRad";
      this.DinnerRad.Size = new System.Drawing.Size(47, 16);
      this.DinnerRad.TabIndex = 12;
      this.DinnerRad.TabStop = true;
      this.DinnerRad.Text = "晚饭";
      this.DinnerRad.UseVisualStyleBackColor = true;
      // 
      // PutOutUrlTex
      // 
      this.PutOutUrlTex.Location = new System.Drawing.Point(390, 41);
      this.PutOutUrlTex.Name = "PutOutUrlTex";
      this.PutOutUrlTex.ReadOnly = true;
      this.PutOutUrlTex.Size = new System.Drawing.Size(340, 21);
      this.PutOutUrlTex.TabIndex = 13;
      // 
      // PortTex
      // 
      this.PortTex.Location = new System.Drawing.Point(600, 12);
      this.PortTex.Name = "PortTex";
      this.PortTex.Size = new System.Drawing.Size(40, 21);
      this.PortTex.TabIndex = 14;
      this.PortTex.Text = "8080";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(559, 15);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(35, 12);
      this.label3.TabIndex = 15;
      this.label3.Text = "端口:";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(742, 526);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.PortTex);
      this.Controls.Add(this.PutOutUrlTex);
      this.Controls.Add(this.DinnerRad);
      this.Controls.Add(this.LunchRad);
      this.Controls.Add(this.ExportBtn);
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.MaxMoneyTex);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.PutOutBtn);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.TargetUrlTex);
      this.Name = "Form1";
      this.Text = "Form1";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox TargetUrlTex;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button PutOutBtn;
    private System.Windows.Forms.TextBox MaxMoneyTex;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.Button ExportBtn;
    private System.Windows.Forms.RadioButton LunchRad;
    private System.Windows.Forms.RadioButton DinnerRad;
    private System.Windows.Forms.TextBox PutOutUrlTex;
    private System.Windows.Forms.TextBox PortTex;
    private System.Windows.Forms.Label label3;
  }
}

