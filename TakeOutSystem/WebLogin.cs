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
            m_ChromeBrowser.LifeSpanHandler = new OpenPageSelf();
            m_ChromeBrowser.AddressChanged += OnAddressChanged;
            this.Controls.Add(m_ChromeBrowser);
            m_ChromeBrowser.Dock = DockStyle.Fill;
        }

        private void OnAddressChanged(object sender, AddressChangedEventArgs e)
        {
            Url = e.Address;
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

    /// <summary>
    /// 在自己窗口打开链接
    /// </summary>
    internal class OpenPageSelf : ILifeSpanHandler
    {
        public bool DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            return false;
        }

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl,
string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures,
IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;
            chromiumWebBrowser.Load(targetUrl);
            return true; //Return true to cancel the popup creation copyright by codebye.com.
        }
    }
}
