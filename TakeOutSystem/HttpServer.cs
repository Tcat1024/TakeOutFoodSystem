using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TakeOutSystem
{
  public abstract class HttpServer
  {

    public bool IsActive = false;
    protected int port;
    protected IPAddress ip;
    TcpListener listener;

    public HttpServer(IPAddress ip, int port)
    {
      this.port = port;
      this.ip = ip;
    }

    public void listen()
    {
      try
      {
        IsActive = true;
        listener = new TcpListener(ip, port);
        listener.Start();
        while (IsActive)
        {
          TcpClient s = listener.AcceptTcpClient();
          HttpProcessor processor = new HttpProcessor(s, this);
          Thread thread = new Thread(new ThreadStart(processor.process));
          thread.Start();
          Thread.Sleep(1);
        }
      }
      finally
      {
        if(listener!= null)
          listener.Stop();
      }
    }

    public abstract void handleGETRequest(HttpProcessor p);
    public abstract void handlePOSTRequest(HttpProcessor p, StreamReader inputData);
  }
}