using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PublicCouncilBackEnd.manage
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        #region(SQL FUNCTIONS)
        private string GetPages(string PAGE)
        {
            SqlDataAdapter getPage = new SqlDataAdapter(new SqlCommand(@"SELECT DATA_ID , PAGE_DATA FROM PC_TOPPAGES WHERE PAGE=@PAGE "));

            getPage.SelectCommand.Parameters.Add("@PAGE", SqlDbType.NVarChar).Value = PAGE;

            return SQL.SELECT(getPage).Rows[0]["PAGE_DATA"].ToString();


        }

        private void UpdatePages(string PAGE, string PAGETEXT)
        {
            SqlCommand updatePage = new SqlCommand(@"UPDATE PC_TOPPAGES SET PAGE_DATA=@PAGE_DATA WHERE PAGE=@PAGE");
            updatePage.Parameters.Add("@PAGE_DATA", SqlDbType.NVarChar).Value = PAGETEXT;
            updatePage.Parameters.Add("@PAGE", SqlDbType.NVarChar).Value = PAGE;
            SQL.COMMAND(updatePage);
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    CKEditorAboutUs.Text = GetPages("ABOUTUS");
                }
                catch 
                {

                  
                }

                try
                {
                    CKEditorContactUs.Text = GetPages("CONTACTUS");
                }
                catch 
                {

                    
                }
            }
        }



        protected void btnABOUTUS_SAVE_Click(object sender, EventArgs e)
        {
            UpdatePages("ABOUTUS", CKEditorAboutUs.Text);
        }


        protected void btnCONTACTUS_SAVE_Click(object sender, EventArgs e)
        {
            UpdatePages("CONTACTUS", CKEditorContactUs.Text);
        }
    }
}