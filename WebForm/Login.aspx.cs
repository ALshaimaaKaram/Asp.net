using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class Login : System.Web.UI.Page
    {
        public int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                dpdownLang.Items.Add("Arabic");
                dpdownLang.Items.Add("English");

                ViewState["Count"] = count;

                //Cookies
                if (Request.Cookies["Cookie"] != null)
                {
                    txtName.Text = Request.Cookies["Cookie"].Values["userName"].ToString();
                }
            }

            count = int.Parse(ViewState["Count"].ToString());

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (count <= 5)
                {
                    string userName = txtName.Text;
                    string password = txtPassword.Text;


                    if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                    {
                        lblMessage.Text = "InValid Name Or Password";
                        lblMessage.Visible = true;
                        count = int.Parse(ViewState["Count"].ToString());
                        count++;
                        ViewState["Count"] = count;
                        return;
                    }

                    //Session
                    Session["IsLoggedIn"]
                             = new
                             {
                                 UserName = userName,
                                 Password = password
                             };
                    //Cookies
                    if (ckbRemember.Checked)
                    {
                        HttpCookie Cookie = new HttpCookie("Cookie");
                        Cookie.Values.Add("userName", txtName.Text);
                        Response.Cookies.Add(Cookie);
                    }
                    else
                    {
                        Response.Cookies["Cookie"].Expires = DateTime.Now.AddDays(-1);
                    }

                    Server.Transfer($"Home.aspx?language={dpdownLang.Text}&Name={txtName.Text}");
                }
                else
                {
                    lblMessage.Text = "Try Again Later";
                    lblMessage.Visible = true;
                }
            }
        }

        protected void mailValidation_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Contains("@iti.gov.eg"))
            {
                args.IsValid = true;
            }
            else
                args.IsValid = false;
        }
    }
}