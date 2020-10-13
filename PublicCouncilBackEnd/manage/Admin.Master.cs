using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PublicCouncilBackEnd.manage
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["ISLOGIN"] as string != "USERISEXIST")
            {
                Response.Redirect("/login");
            }

            if (Session["USER_MEMBERSHIP_TYPE"] as string == "admin")
            {
                pcnameLink.NavigateUrl = "http://publiccouncil.ml";
                pcNameText.Text = "publiccouncil.ml";
              //  _ngoprofile.Visible = false;

            }
            else if (Session["USER_MEMBERSHIP_TYPE"] as string == "user")
            {
                pcnameLink.NavigateUrl = $"http://{ Session["USER_PCDOMAIN"] as string}.publiccouncil.ml";
                pcNameText.Text = ($"{Session["USER_PCDOMAIN"] as string}.publiccouncil.ml").ToLower();
                //.Visible = false;
                managepartners.Visible = false;
                managesponsors.Visible = false;
                managepcouncils.Visible = false;
            }
            else
            {
               // _adversting.Visible = false;
                managepartners.Visible = false;
                managesponsors.Visible = false;
                managepcouncils.Visible = false;
            }

            userName.Text = $"{Session["USER_NAME"] as string} {Session["USER_SURNAME"]}";
          
           
        }

        protected void manageExit_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/login");
        }
    }
}