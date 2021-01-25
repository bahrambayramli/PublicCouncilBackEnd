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
        private DataTable GetPages(string PAGE)
        {
            SqlDataAdapter getPage = new SqlDataAdapter(new SqlCommand(@"SELECT DATA_ID , PAGE_DATA_AZ, PAGE_DATA_EN FROM PC_TOPPAGES WHERE PAGE=@PAGE "));

            getPage.SelectCommand.Parameters.Add("@PAGE", SqlDbType.NVarChar).Value = PAGE;

            

            return SQL.SELECT(getPage);


        }

        private void UpdatePages(string PAGE, string PAGETEXTAZ, string PAGETEXTEN)
        {
            SqlCommand updatePage = new SqlCommand(@"UPDATE PC_TOPPAGES SET 
                                                            PAGE_DATA_AZ=@PAGE_DATA_AZ ,
                                                            PAGE_DATA_EN=@PAGE_DATA_EN 
                                                            WHERE PAGE=@PAGE");
            updatePage.Parameters.Add("@PAGE_DATA_AZ", SqlDbType.NVarChar).Value = PAGETEXTAZ;
            updatePage.Parameters.Add("@PAGE_DATA_EN", SqlDbType.NVarChar).Value = PAGETEXTEN;
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
                    CKEditorAboutUsAz.Text = GetPages("ABOUTUS").Rows[0]["PAGE_DATA_AZ"].ToString();
                    CKEditorAboutUsEn.Text = GetPages("ABOUTUS").Rows[0]["PAGE_DATA_EN"].ToString();

                }
                catch 
                {

                  
                }

                try
                {
                    CKEditorContactUsAz.Text = GetPages("CONTACTUS").Rows[0]["PAGE_DATA_AZ"].ToString();
                    CKEditorContactUsEn.Text = GetPages("CONTACTUS").Rows[0]["PAGE_DATA_EN"].ToString();
                }
                catch 
                {

                    
                }
            }
        }



        protected void btnABOUTUS_SAVE_Click(object sender, EventArgs e)
        {
            UpdatePages("ABOUTUS", CKEditorAboutUsAz.Text, CKEditorAboutUsEn.Text);
        }


        protected void btnCONTACTUS_SAVE_Click(object sender, EventArgs e)
        {
            UpdatePages("CONTACTUS", CKEditorContactUsAz.Text, CKEditorContactUsEn.Text);
        }
    }
}