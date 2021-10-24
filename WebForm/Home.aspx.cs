using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session
            if (Session["IsLoggedIn"] == null)
                Response.Redirect("Login.aspx");

            //Quary String
            if (Request.QueryString["language"] != null && Request.QueryString["Name"] != null)
            {
                string Language = Request.QueryString["language"];
                string Name = Request.QueryString["Name"];

                if(Language.ToLower().Trim() == "arabic")
                {
                    lblMessage.Text = " أهلا بك" + Name;
                }
                else
                {
                    lblMessage.Text = "Welcome To You " + Name;
                }

            }

            //Application
            lblVstorCount.Text = "Count of visitor for website is " + Application["VisitorsCount"].ToString();


            //PreviousPage
            if (Page.PreviousPage != null)
            {
                lblCount.Text = "You Try Login " + ((Login)Page.PreviousPage).count.ToString() + "times";
            }

        }
    }
}