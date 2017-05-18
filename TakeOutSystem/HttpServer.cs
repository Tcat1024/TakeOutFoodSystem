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

    public bool isActive = false;
    protected int m_port;
    protected IPAddress m_ip;
    private TcpListener m_listener;

    public HttpServer(IPAddress ip, int port)
    {
      this.m_port = port;
      this.m_ip = ip;
    }

    public void listen()
    {
      try
      {
        isActive = true;
        m_listener = new TcpListener(m_ip, m_port);
        m_listener.Start();
        while (isActive)
        {
          var task = m_listener.AcceptTcpClientAsync();
          while (isActive && !task.IsCompleted) ;
          if(!isActive)
            break;
          TcpClient s = task.Result;
          HttpProcessor processor = new HttpProcessor(s, this);
          Thread thread = new Thread(new ThreadStart(processor.process));
          thread.Start();
          Thread.Sleep(1);
        }
      }
      finally
      {
        if(m_listener != null)
          m_listener.Stop();
      }
    }

    public abstract void handleGETRequest(HttpProcessor p);
    public abstract void handlePOSTRequest(HttpProcessor p, StreamReader inputData);
  }
}