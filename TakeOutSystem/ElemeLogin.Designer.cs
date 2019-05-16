namespace TakeOutSystem
{
  partial class ElemeLogin
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.label1 = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.button2 = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.buttonRefreshPic = new System.Windows.Forms.Button();
      this.buttonEnterPicCode = new System.Windows.Forms.Button();
      this.textBoxPicCode = new System.Windows.Forms.TextBox();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(37, 27);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(215, 12);
      this.label1.TabIndex = 0;
      this.label1.Text = "饿了么网站必须登录才能使用，FKELEME";
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(84, 61);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(230, 21);
      this.textBox1.TabIndex = 1;
      this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(37, 64);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(41, 12);
      this.label2.TabIndex = 2;
      this.label2.Text = "手机号";
      // 
      // button1
      // 
      this.button1.Enabled = false;
      this.button1.Location = new System.Drawing.Point(320, 59);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 3;
      this.button1.Text = "获取验证码";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(84, 88);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(230, 21);
      this.textBox2.TabIndex = 4;
      this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(37, 91);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(41, 12);
      this.label3.TabIndex = 5;
      this.label3.Text = "验证码";
      // 
      // button2
      // 
      this.button2.Enabled = false;
      this.button2.Location = new System.Drawing.Point(177, 124);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 6;
      this.button2.Text = "登录";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.SystemColors.Control;
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.textBoxPicCode);
      this.panel1.Controls.Add(this.buttonEnterPicCode);
      this.panel1.Controls.Add(this.buttonRefreshPic);
      this.panel1.Controls.Add(this.pictureBox1);
      this.panel1.Location = new System.Drawing.Point(62, 27);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(297, 120);
      this.panel1.TabIndex = 7;
      this.panel1.Visible = false;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Location = new System.Drawing.Point(12, 11);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(192, 65);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // buttonRefreshPic
      // 
      this.buttonRefreshPic.Location = new System.Drawing.Point(210, 32);
      this.buttonRefreshPic.Name = "buttonRefreshPic";
      this.buttonRefreshPic.Size = new System.Drawing.Size(75, 23);
      this.buttonRefreshPic.TabIndex = 1;
      this.buttonRefreshPic.Text = "刷新";
      this.buttonRefreshPic.UseVisualStyleBackColor = true;
      this.buttonRefreshPic.Click += new System.EventHandler(this.buttonRefreshPic_Click);
      // 
      // buttonEnterPicCode
      // 
      this.buttonEnterPicCode.Location = new System.Drawing.Point(210, 88);
      this.buttonEnterPicCode.Name = "buttonEnterPicCode";
      this.buttonEnterPicCode.Size = new System.Drawing.Size(75, 23);
      this.buttonEnterPicCode.TabIndex = 2;
      this.buttonEnterPicCode.Text = "确定";
      this.buttonEnterPicCode.UseVisualStyleBackColor = true;
      this.buttonEnterPicCode.Click += new System.EventHandler(this.buttonEnterPicCode_Click);
      // 
      // textBoxPicCode
      // 
      this.textBoxPicCode.Location = new System.Drawing.Point(12, 88);
      this.textBoxPicCode.Name = "textBoxPicCode";
      this.textBoxPicCode.Size = new System.Drawing.Size(192, 21);
      this.textBoxPicCode.TabIndex = 3;
      this.textBoxPicCode.TextChanged += new System.EventHandler(this.textBoxPicCode_TextChanged);
      // 
      // ElemeLogin
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(427, 174);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.textBox2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.label1);
      this.Name = "ElemeLogin";
      this.Text = "饿了么登录";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TextBox textBoxPicCode;
    private System.Windows.Forms.Button buttonEnterPicCode;
    private System.Windows.Forms.Button buttonRefreshPic;
    private System.Windows.Forms.PictureBox pictureBox1;
  }
}