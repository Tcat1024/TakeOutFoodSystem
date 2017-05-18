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
    public static string webSetString;
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
        p.writeSuccess(HttpProcessor.ContentType.HTML, webSetString.Length);
        p.outputStream.Write(webSetString);
      }
      else
      {
        MemoryStream stream;
        var tarType = HttpProcessor.GetContentType(p.http_url.Substring(p.http_url.LastIndexOf('.')));
        if (tarType < HttpProcessor.ContentType.NUM && WebResourceManager.instance.TryGetsource(p.http_url, out stream))
        {
          p.writeSuccess(tarType, (int)stream.Length);
          p.outputStream.Flush();
          stream.WriteTo(p.outputStream.BaseStream);
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
      string result = DataManager.instance.AnalyseOrderDataAsyn(data);
      p.writeSuccess(HttpProcessor.ContentType.XML, result.Length);
      p.outputStream.Write(result);
      //p.outputStream.Write();
    }
  }
}