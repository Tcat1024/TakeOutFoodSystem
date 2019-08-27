using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace TakeOutSystem
{
    public partial class WebLogin : Form
    {
        public string Content;
        public string Url;
        private ChromiumWebBrowser m_ChromeBrowser;
        public WebLogin(string url)
        {
            InitializeComponent();
            if(!Cef.IsInitialized)
            {
                CefSettings setting = new CefSettings();
                setting.PersistSessionCookies = true;
                setting.PersistUserPreferences = true;
                setting.IgnoreCertificateErrors = true;
                setting.CachePath = System.IO.Directory.GetCurrentDirectory() + "/CefCache/";
                CefSharp.Cef.Initialize(setting);
            }
            m_ChromeBrowser = new ChromiumWebBrowser(url);
            this.Controls.Add(m_ChromeBrowser);
            m_ChromeBrowser.Dock = DockStyle.Fill;
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            var task = m_ChromeBrowser.GetSourceAsync();
            task.Wait();
            Content = task.Result;
            DialogResult = DialogResult.OK;
        }

        private void WebLogin_Shown(object sender, EventArgs e)
        {
        }

        private void WebLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Cef.Shutdown();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            m_ChromeBrowser.Reload();
        }
    }
}
