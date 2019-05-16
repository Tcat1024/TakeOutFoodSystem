using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TakeOutSystem
{
  public partial class ElemeLogin : Form
  {
    public CookieCollection CurCookies { get { return m_CurCookies; } }

    private string m_CurPicHash;
    private string m_CurPicCode;
    private CookieCollection m_CurCookies;
    private string m_Token;
    public ElemeLogin()
    {
      InitializeComponent();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      Login();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      RequestCode();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      UpdateButtonState();
    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {
      UpdateButtonState();
    }

    private void UpdateButtonState()
    {
      button1.Enabled = !string.IsNullOrEmpty(textBox1.Text);
      button2.Enabled = !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text);
    }

    private void UpdatePicButtonState()
    {
      buttonEnterPicCode.Enabled = !string.IsNullOrEmpty(textBoxPicCode.Text);
    }

    // 请求验证码
    private void RequestCode()
    {
      string url = "https://h5.ele.me/restapi/eus/login/mobile_send_code";  //验证码页面
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
      request.Accept = "*/*";
      request.Method = "POST";
      request.UserAgent = "Mozilla/5.0";
      request.ContentType = "application/json; charset=utf-8";
      request.CookieContainer = new CookieContainer();
      var contentStr = string.Format("{{\"mobile\":\"{0}\",\"captcha_value\":\"{1}\",\"captcha_hash\":\"{2}\",\"scf\":\"ms\"}}", textBox1.Text, string.IsNullOrEmpty(m_CurPicCode) ? "" : m_CurPicCode, string.IsNullOrEmpty(m_CurPicHash) ? "" : m_CurPicHash);
      byte[] postdatabyte = Encoding.UTF8.GetBytes(contentStr);
      request.ContentLength = postdatabyte.Length;
      request.AllowAutoRedirect = true;
      string errorMsg = null;
      using (Stream stream = request.GetRequestStream())
      {
        stream.Write(postdatabyte, 0, postdatabyte.Length);
      }
      bool needPicCode = true;
      try
      {
        string responseContent = null;
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
          m_CurCookies = response.Cookies;
          using (var stream = response.GetResponseStream())
          {
            Byte[] buffer = new Byte[response.ContentLength];
            int offset = 0, actuallyRead = 0;
            do
            {
              actuallyRead = stream.Read(buffer, offset, buffer.Length - offset);
              offset += actuallyRead;
            }
            while (actuallyRead > 0);
            responseContent = System.Text.Encoding.UTF8.GetString(buffer);
          }
        }
        if (!string.IsNullOrEmpty(responseContent))
        {
          var group = Regex.Match(responseContent, "\"validate_token\":\"([^\"]*?)\"");
          if (null != group && group.Success)
          {
            m_Token = group.Groups[1].Value;
            needPicCode = false;
          }
        }

      }
      catch(Exception ex) // 需要输入验证码
      {
        errorMsg = ex.Message;
      }

      if(needPicCode)
      {
        RequestPicCode();
      }

      //MemoryStream ms = null;
      //using (var stream = response.GetResponseStream())
      //{
      //  Byte[] buffer = new Byte[response.ContentLength];
      //  int offset = 0, actuallyRead = 0;
      //  do
      //  {
      //    actuallyRead = stream.Read(buffer, offset, buffer.Length - offset);
      //    offset += actuallyRead;
      //  }
      //  while (actuallyRead > 0);
      //  ms = new MemoryStream(buffer);
      //}
      //response.Close();

      //cookies = request.CookieContainer; //保存cookies
      //strCookies = request.CookieContainer.GetCookieHeader(request.RequestUri); //把cookies转换成字符串

      //BitmapImage bi = new BitmapImage();
      //bi.BeginInit();
      //bi.StreamSource = (Stream)ms;
      //bi.EndInit();
      //imgValidate.Source = bi;
    }

    private void Login()
    {
      string url = "https://h5.ele.me/restapi/eus/login/login_by_mobile";  //验证码页面
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
      request.Accept = "*/*";
      request.Method = "POST";
      request.UserAgent = "Mozilla/5.0";
      request.ContentType = "application/json; charset=utf-8";
      request.CookieContainer = new CookieContainer();
      var contentStr = string.Format("{{\"mobile\":\"{0}\",\"validate_code\":\"{1}\",\"validate_token\":\"{2}\",\"scf\":\"ms\"}}", textBox1.Text, textBox2.Text, m_Token);
      byte[] postdatabyte = Encoding.UTF8.GetBytes(contentStr);
      request.ContentLength = postdatabyte.Length;
      using (Stream stream = request.GetRequestStream())
      {
        stream.Write(postdatabyte, 0, postdatabyte.Length);
      }
      bool success = false;
      string errorMsg = null;
      try
      {
        //string responseContent = null;
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
          m_CurCookies = response.Cookies;
          success = true;
          //using (var stream = response.GetResponseStream())
          //{
          //  Byte[] buffer = new Byte[response.ContentLength];
          //  int offset = 0, actuallyRead = 0;
          //  do
          //  {
          //    actuallyRead = stream.Read(buffer, offset, buffer.Length - offset);
          //    offset += actuallyRead;
          //  }
          //  while (actuallyRead > 0);
          //  responseContent = System.Text.Encoding.UTF8.GetString(buffer);
          //}
        }
        //if (!string.IsNullOrEmpty(responseContent))
        //{
        //  var group = Regex.Match(responseContent, "\"message\":\"([^\"]*?)\"");
        //  if (null != group && group.Success)
        //  {
        //    errorMsg = group.Groups[1].Value;
        //    success = true;
        //  }
        //}
      }
      catch (Exception ex) // 需要输入验证码
      {
        errorMsg = ex.Message;
      }
      if (success)
      {
        DialogResult = DialogResult.Yes;
      }
      else
      {
        MessageBox.Show(string.Format("登录失败，{0}", errorMsg));
      }
    }


    private void RequestPicCode()
    {
      try
      {
        bool success = false;
        HttpWebRequest picRequest = (HttpWebRequest)WebRequest.Create("https://h5.ele.me/restapi/eus/v3/captchas");
        picRequest.Accept = "*/*";
        picRequest.Method = "POST";
        picRequest.UserAgent = "Mozilla/5.0";
        picRequest.ContentType = "application/json; charset=utf-8";
        picRequest.CookieContainer = new CookieContainer();
        var contentStr = "{\"captcha_str\":\"" + textBox1.Text + "\"}";
        var postdatabyte = Encoding.UTF8.GetBytes(contentStr);
        picRequest.ContentLength = postdatabyte.Length;

        using (Stream stream = picRequest.GetRequestStream())
        {
          stream.Write(postdatabyte, 0, postdatabyte.Length);
        }
        string responseContent = null;
        CookieCollection cookies = null;
        using (HttpWebResponse picResponse = (HttpWebResponse)picRequest.GetResponse())
        {
          cookies = picResponse.Cookies;
          using (var stream = picResponse.GetResponseStream())
          {
            Byte[] buffer = new Byte[picResponse.ContentLength];
            int offset = 0, actuallyRead = 0;
            do
            {
              actuallyRead = stream.Read(buffer, offset, buffer.Length - offset);
              offset += actuallyRead;
            }
            while (actuallyRead > 0);
            responseContent = System.Text.Encoding.UTF8.GetString(buffer);
          }
        }
        if (!string.IsNullOrEmpty(responseContent))
        {
          var group = Regex.Match(responseContent, "\"captcha_hash\":\"([^\"]*?)\"");
          if(null != group && group.Success)
          {
            m_CurPicHash = group.Groups[1].Value;
            group = Regex.Match(responseContent, "\"captcha_image\":\"data:image/[^;]*?;base64,([^\"]*?)\"");
            if (null != group && group.Success)
            {
              var picUrl = group.Groups[1].Value;
              var picStream = new MemoryStream(Convert.FromBase64String(picUrl));
              pictureBox1.Image = Image.FromStream(picStream);
              success = true;
            }
          }

        }
        panel1.Visible = success;
        textBoxPicCode.Text = "";
      }
      catch(Exception ex)
      {
        MessageBox.Show(string.Format("获取验证码错误，{0}", ex.Message));
      }
      
    }


    private void textBoxPicCode_TextChanged(object sender, EventArgs e)
    {
      UpdatePicButtonState();
    }

    private void buttonEnterPicCode_Click(object sender, EventArgs e)
    {
      m_CurPicCode = textBoxPicCode.Text;
      panel1.Visible = false;
      RequestCode();
    }

    private void buttonRefreshPic_Click(object sender, EventArgs e)
    {
      RequestPicCode();
    }
  }
}
