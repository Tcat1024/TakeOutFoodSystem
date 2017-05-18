using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace TakeOutSystem
{
  public class WebResourceManager
  {
    static public WebResourceManager instance
    {
      get
      {
        return s_instance;
      }
    }

    public bool isIniting
    {
      get
      {
        return m_initThread == null || !m_initThread.IsAlive;
      }
    }

    private string m_rootPath = "/wwwroot/";
    private Thread m_initThread;
    private Dictionary<string, MemoryStream> m_dicFiles = new Dictionary<string, MemoryStream>();
    static private WebResourceManager s_instance = new WebResourceManager();

    public void Init()
    {
      if(m_initThread != null && m_initThread.IsAlive)
      {
        return;
      }
      m_initThread = new Thread(InitImp);
      m_initThread.IsBackground = true;
      m_initThread.Start();
      m_initThread.Join();
    }

    public bool TryGetsource(string resourcePath, out MemoryStream data)
    {
      if (resourcePath[0] != '/')
        resourcePath = "/" + resourcePath;
      if(!m_dicFiles.TryGetValue(resourcePath, out data))
      {
        return false;
      }
      return true;
    }

    private void InitImp()
    {
      var rootPath = Directory.GetCurrentDirectory() + m_rootPath;
      if(!Directory.Exists(rootPath))
      {
        return;
      }
      m_dicFiles.Clear();
      DirectoryInfo rootInfo = new DirectoryInfo(rootPath);
      InitDir(rootInfo, "/");
    }

    private void InitDir(DirectoryInfo rootInfo, string rootPath)
    {
      var fileInfos = rootInfo.GetFiles();
      foreach(var fileInfo in fileInfos)
      {
        using (var file = File.Open(fileInfo.FullName, FileMode.Open, FileAccess.Read))
        {
          var stream = new MemoryStream();
          file.CopyTo(stream);
          m_dicFiles[rootPath + fileInfo.Name] = stream;
        }
      }
      var dirInfos = rootInfo.GetDirectories();
      foreach(var dirInfo in dirInfos)
      {
        InitDir(dirInfo, rootPath + dirInfo.Name + "/");
      }
    }
  }
}