﻿namespace TakeOutSystem
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
      this.ExportBtn = new System.Windows.Forms.Button();
      this.LunchRad = new System.Windows.Forms.RadioButton();
      this.DinnerRad = new System.Windows.Forms.RadioButton();
      this.PutOutUrlTex = new System.Windows.Forms.TextBox();
      this.PortTex = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.ClearBtn = new System.Windows.Forms.Button();
      this.TotalGrid = new System.Windows.Forms.DataGridView();
      this.StopBtn = new System.Windows.Forms.Button();
      this.OpenGroup = new System.Windows.Forms.GroupBox();
      this.panel1 = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.DetailGrid)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TotalGrid)).BeginInit();
      this.OpenGroup.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // TargetUrlTex
      // 
      this.TargetUrlTex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TargetUrlTex.Location = new System.Drawing.Point(88, 15);
      this.TargetUrlTex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
      this.PutOutBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
      this.MaxMoneyTex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.MaxMoneyTex.Name = "MaxMoneyTex";
      this.MaxMoneyTex.Size = new System.Drawing.Size(52, 25);
      this.MaxMoneyTex.TabIndex = 6;
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
      this.DetailGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.DetailGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DetailGrid.Location = new System.Drawing.Point(7, 58);
      this.DetailGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.DetailGrid.Name = "DetailGrid";
      this.DetailGrid.RowTemplate.Height = 23;
      this.DetailGrid.Size = new System.Drawing.Size(849, 428);
      this.DetailGrid.TabIndex = 9;
      // 
      // ExportBtn
      // 
      this.ExportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ExportBtn.Location = new System.Drawing.Point(873, 539);
      this.ExportBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.ExportBtn.Name = "ExportBtn";
      this.ExportBtn.Size = new System.Drawing.Size(100, 29);
      this.ExportBtn.TabIndex = 10;
      this.ExportBtn.Text = "导出";
      this.ExportBtn.UseVisualStyleBackColor = true;
      // 
      // LunchRad
      // 
      this.LunchRad.AutoSize = true;
      this.LunchRad.Location = new System.Drawing.Point(4, 4);
      this.LunchRad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
      this.DinnerRad.Location = new System.Drawing.Point(70, 4);
      this.DinnerRad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.DinnerRad.Name = "DinnerRad";
      this.DinnerRad.Size = new System.Drawing.Size(58, 19);
      this.DinnerRad.TabIndex = 12;
      this.DinnerRad.TabStop = true;
      this.DinnerRad.Text = "晚饭";
      this.DinnerRad.UseVisualStyleBackColor = true;
      // 
      // PutOutUrlTex
      // 
      this.PutOutUrlTex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.PutOutUrlTex.Location = new System.Drawing.Point(404, 25);
      this.PutOutUrlTex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.PutOutUrlTex.Name = "PutOutUrlTex";
      this.PutOutUrlTex.ReadOnly = true;
      this.PutOutUrlTex.Size = new System.Drawing.Size(452, 25);
      this.PutOutUrlTex.TabIndex = 13;
      // 
      // PortTex
      // 
      this.PortTex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.PortTex.Location = new System.Drawing.Point(800, 15);
      this.PortTex.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
      this.ClearBtn.Location = new System.Drawing.Point(873, 83);
      this.ClearBtn.Margin = new System.Windows.Forms.Padding(4);
      this.ClearBtn.Name = "ClearBtn";
      this.ClearBtn.Size = new System.Drawing.Size(100, 29);
      this.ClearBtn.TabIndex = 16;
      this.ClearBtn.Text = "清空";
      this.ClearBtn.UseVisualStyleBackColor = true;
      this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
      // 
      // TotalGrid
      // 
      this.TotalGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TotalGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.TotalGrid.Location = new System.Drawing.Point(7, 496);
      this.TotalGrid.Margin = new System.Windows.Forms.Padding(4);
      this.TotalGrid.Name = "TotalGrid";
      this.TotalGrid.RowTemplate.Height = 23;
      this.TotalGrid.Size = new System.Drawing.Size(849, 110);
      this.TotalGrid.TabIndex = 17;
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
      this.OpenGroup.Controls.Add(this.PutOutUrlTex);
      this.OpenGroup.Controls.Add(this.StopBtn);
      this.OpenGroup.Controls.Add(this.DetailGrid);
      this.OpenGroup.Controls.Add(this.TotalGrid);
      this.OpenGroup.Controls.Add(this.ExportBtn);
      this.OpenGroup.Controls.Add(this.ClearBtn);
      this.OpenGroup.Location = new System.Drawing.Point(0, 45);
      this.OpenGroup.MinimumSize = new System.Drawing.Size(989, 613);
      this.OpenGroup.Name = "OpenGroup";
      this.OpenGroup.Size = new System.Drawing.Size(989, 613);
      this.OpenGroup.TabIndex = 19;
      this.OpenGroup.TabStop = false;
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.Controls.Add(this.DinnerRad);
      this.panel1.Controls.Add(this.LunchRad);
      this.panel1.Location = new System.Drawing.Point(604, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(134, 30);
      this.panel1.TabIndex = 19;
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
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "Form1";
      this.Text = "Form1";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.DetailGrid)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TotalGrid)).EndInit();
      this.OpenGroup.ResumeLayout(false);
      this.OpenGroup.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
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
    private System.Windows.Forms.DataGridView TotalGrid;
    private System.Windows.Forms.Button StopBtn;
    private System.Windows.Forms.GroupBox OpenGroup;
    private System.Windows.Forms.Panel panel1;
  }
}

