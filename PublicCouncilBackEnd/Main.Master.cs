using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PublicCouncilBackEnd
{
    public partial class Main : System.Web.UI.MasterPage
    {
        public void GetNavigations(string lang)
        {
            switch (lang)
            {
                case "az":
                    {
                        NAV_AZ.DataSource = SQLFUNC.GetNavigations(lang, false, true);
                        NAV_AZ.DataBind();
                        break;
                    }
                case "en":
                    {
                        NAV_EN.DataSource = SQLFUNC.GetNavigations(lang, false, true);
                        NAV_EN.DataBind();
                        break;
                    }
                case "ru":
                    {
                        NAV_RU.DataSource = SQLFUNC.GetNavigations(lang, false, true);
                        NAV_RU.DataBind();
                        break;
                    }
                default:
                    {
                        NAV_AZ.DataSource = SQLFUNC.GetNavigations(lang, false, true);
                        NAV_AZ.DataBind();
                        break;
                    }
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            GetNavigations(Page.RouteData.Values["LANGUAGE"] as string);


        }
    }
}