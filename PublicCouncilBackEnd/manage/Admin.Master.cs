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
            Session["USER_ID"] = "1";
        }

        protected void manageExit_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/login");
        }
    }
}