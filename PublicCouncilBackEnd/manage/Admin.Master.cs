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
            Session.Timeout = 90; //30 is number of minutes

            if (Session["USER_MEMBERSHIP_TYPE"] as string != "admin")
            {
                managepartners.Visible  = false;
                managesponsors.Visible  = false;
                managepages.Visible     = false;
                managearchive.Visible   = false;
                manageLogo.Visible      = false;
                managesocial.Visible    = false;
            }
            else
            {
                //managepartners.Visible  = false;
                //managesponsors.Visible  = false;
                //managepages.Visible     = false;
                //managearchive.Visible   = false;
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