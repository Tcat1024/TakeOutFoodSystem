using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace TakeOutSystem
{
  public class MainHttpServer : HttpServer
  {
    public static string WebSetString;
    private string m_rootPath;
    public MainHttpServer(IPAddress ip, int port)
            : base(ip, port)
    {
      m_rootPath = Directory.GetCurrentDirectory();
    }
    public override void handleGETRequest(HttpProcessor p)
    {
      Console.WriteLine("request: {0}", p.http_url);
      if(p.http_url == "/")
      {
        p.writeSuccess();
        p.outputStream.Write(WebSetString);
      }
      else
      {
        string tarPath = m_rootPath + p.http_url;
        if (File.Exists(tarPath))
        {
          p.writeSuccess();
          File.Open(tarPath, FileMode.Open, FileAccess.Read).CopyTo(p.outputStream.BaseStream);
        }
        else
        {
          p.writeFailure();
        }
      }
    }

    public override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
    {
      Console.WriteLine("POST request: {0}", p.http_url);
      string data = inputData.ReadToEnd();

      p.outputStream.WriteLine("<html><body><h1>test server</h1>");
      p.outputStream.WriteLine("<a href=/test>return</a><p>");
      p.outputStream.WriteLine("postbody: <pre>{0}</pre>", data);


    }
  }
}