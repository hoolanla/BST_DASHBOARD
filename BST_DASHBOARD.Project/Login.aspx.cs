using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using BST_DASHBOARD.Project.Models;
using System.Configuration;

namespace BST_DASHBOARD.Project.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (UserName.Text == ConfigurationManager.AppSettings["Username"] && Password.Text == ConfigurationManager.AppSettings["Password"])  
                {

                    Session["Admin"] = "True";
                    Response.Redirect("Inside.aspx");
                }
                else
                {
                    Response.Redirect("~/authorize.aspx");
                }
            }
        }
    }
}