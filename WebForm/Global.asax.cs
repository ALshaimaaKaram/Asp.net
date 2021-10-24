using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebForm
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["VisitorsCount"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            int Count = int.Parse(Application["VisitorsCount"].ToString());
            Count++;
            Application["VisitorsCount"] = Count;
        }

    }
}