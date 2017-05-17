using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace TakeOutSystem
{
  public class MsgHandler : IHttpHandler
  {
    public bool IsReusable
    {
      get
      {
        return true;
      }
    }
    public void ProcessRequest(System.Web.HttpContext context)
    {
      throw new NotImplementedException();
    }
  }
}