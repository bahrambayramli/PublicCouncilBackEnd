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
    public partial class WebForm7 : System.Web.UI.Page
    {
        #region(SQL FUNCTIONS)
        private void GetPartners(string PARTNER_ID)
        {
            SqlDataAdapter getPartners = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                            ROW_NUMBER() OVER(ORDER BY DATA_ID DESC) AS '#' ,
	                                                                        DATA_ID,
                                                                            PARTNERS_TITLE,
                                                                            PARTNERS_IMG,
                                                                            PARTNERS_LINK
                                                                          
                                                                        FROM PC_PARTNERS WHERE 
                                                                             ISDELETE = @ISDELETE AND
                                                                             ISACTIVE = @ISACTIVE AND
                                                                             DATA_ID  = @DATA_ID"));
            getPartners.SelectCommand.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = PARTNER_ID;
            getPartners.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            getPartners.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;

            DataTable DT = new DataTable();

            DT = SQL.SELECT(getPartners);

            partnername.Text = DT.Rows[0]["PARTNERS_TITLE"].ToString();
            partnerli.Text = DT.Rows[0]["PARTNERS_LINK"].ToString();
            mainimg.ImageUrl = $"~/Images/{DT.Rows[0]["PARTNERS_IMG"].ToString()}";

        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["PARTNER"] as string == "SELECTED")
                {
                    GetPartnersData(Session["PARTNERSID"] as string);
                }
            }
        }

        protected void partnerConfirm_Click(object sender, EventArgs e)
        {

        }

        protected void partnerdetail_back_Click(object sender, EventArgs e)
        {

        }

        #region(PartnersList)

        #endregion
    }
}