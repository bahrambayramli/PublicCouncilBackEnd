using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PublicCouncilBackEnd.manage
{
    public partial class WebForm8 : System.Web.UI.Page
    {


        #region(SQL FUNCTIONS)
        private void GetPartners()
        {
            SqlDataAdapter getPartners = new SqlDataAdapter(new SqlCommand(@"   SELECT 
                                                                                ROW_NUMBER() OVER(ORDER BY DATA_ID DESC) AS '#' ,
	                                                                            DATA_ID,
                                                                                SPONSOR_TITLE,
                                                                                SPONSOR_LINK
                                                                          
                                                                        FROM PC_SPONSORS WHERE 
                                                    
                                                                             ISDELETE=@ISDELETE AND
                                                                             ISACTIVE=@ISACTIVE"));

            getPartners.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            getPartners.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            SponsorList.DataSource = SQL.SELECT(getPartners);
            SponsorList.DataBind();

        }

        public void DeletePartner(string PARTNER_ID)
        {
            SqlCommand deletenews = new SqlCommand(@"Update PC_SPONSORS SET ISDELETE=@ISDELETE,ISACTIVE=@ISACTIVE WHERE DATA_ID = @DATA_ID");
            deletenews.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = PARTNER_ID;
            deletenews.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = false;
            deletenews.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = true;
            SQL.COMMAND(deletenews);
            GetPartners();

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //Partner doesn't need the USER ID becaouse this case is only showing in Super Admin
            GetPartners();
        }

        protected void new_sponsor_Click(object sender, EventArgs e)
        {
            Session["SPONSOR"] = null;
            Session["SPONSOR_ID"] = null;
            Response.Redirect("/manage/sponsordetail");
        }

        protected void delete_sponsor_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
                string id = SponsorList.Rows[rowIndex].Cells[1].Text;
                DeletePartner(id);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        #region(Sponsors List)
        protected void SponsorList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager) { return; }

            try { e.Row.Cells[1].Visible = false; } catch { }
        }
        protected void SponsorList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SponsorList.PageIndex = e.NewPageIndex;
            GetPartners();

        }

        protected void SponsorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SPONSOR"] = "SELECTED";
            Session["SPONSOR_ID"] = SponsorList.SelectedRow.Cells[1].Text;
            Response.Redirect("/manage/sponsordetail");
        }
        #endregion

    }
}