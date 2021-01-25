using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PublicCouncilBackEnd
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        #region(SQL FUNCTIONS)
        private void GetPages(string LANG, string PAGE)
        {
            SqlDataAdapter getPage;
            switch (LANG)
            {
                case "az":
                    {
                        getPage = new SqlDataAdapter(new SqlCommand(@"SELECT DATA_ID , PAGE_DATA_AZ FROM PC_TOPPAGES WHERE PAGE=@PAGE "));
                        getPage.SelectCommand.Parameters.Add("@PAGE", SqlDbType.NVarChar).Value = PAGE;
                        aboususInfo.Text = SQL.SELECT(getPage).Rows[0]["PAGE_DATA_AZ"].ToString();
                        break;
                    }
                case "en":
                    {
                        getPage = new SqlDataAdapter(new SqlCommand(@"SELECT DATA_ID , PAGE_DATA_EN FROM PC_TOPPAGES WHERE PAGE=@PAGE "));
                        getPage.SelectCommand.Parameters.Add("@PAGE", SqlDbType.NVarChar).Value = PAGE;
                        aboususInfo.Text = SQL.SELECT(getPage).Rows[0]["PAGE_DATA_EN"].ToString();
                        break;
                    }

                default:
                    {
                        getPage = new SqlDataAdapter(new SqlCommand(@"SELECT DATA_ID , PAGE_DATA_AZ FROM PC_TOPPAGES WHERE PAGE=@PAGE "));
                        getPage.SelectCommand.Parameters.Add("@PAGE", SqlDbType.NVarChar).Value = PAGE;
                        aboususInfo.Text = SQL.SELECT(getPage).Rows[0]["PAGE_DATA_AZ"].ToString();
                        break;
                    }

            }
            getPage = null;
          //  return 
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Convert.ToString(Page.RouteData.Values["language"]).ToLower())
            {
                case "az":
                    {
                        pageName.Text = "Haqqımızda";
                        break;
                    }
                case "en":
                    {
                        pageName.Text = "About Us";
                        break;
                    }
                default:
                    {
                        pageName.Text = "Haqqımızda";
                        break;
                    }
            }

            GetPages(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), "ABOUTUS");

        }
    }
}