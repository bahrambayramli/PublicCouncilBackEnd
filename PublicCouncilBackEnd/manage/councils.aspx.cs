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
    public partial class WebForm10 : System.Web.UI.Page
    {
        #region(SQL FUNCTIONS)

        private void GETPCOUNCILS()
        {
            SqlDataAdapter getPC = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                              ROW_NUMBER() OVER(ORDER BY CREATED_DATE DESC) AS '#' ,
                                                                              USER_ID,
                                                                              USER_SERIAL,
                                                                              USER_NAME,
                                                                              USER_SURNAME,
                                                                              PC_NAME,
                                                                              USER_MEMBERSHIP,
                                                                              USER_MEMBERSHIP_TYPE,
                                                                              USER_PCDOMAIN
                                                                        FROM  PC_USERS
                                                                        WHERE USER_LOGIN != @USER_LOGIN AND
                                                                              ISDELETE    = @ISDELETE 
                                                                                        "));

            getPC.SelectCommand.Parameters.Add("@USER_LOGIN", SqlDbType.NVarChar).Value = "admin";
            getPC.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;

            PCLists.DataSource = SQL.SELECT(getPC);
            PCLists.DataBind();
        }


        private void DeleteData(string POSTID)
        {
            SqlCommand deletePC = new SqlCommand(@"Update PC_USERS SET ISDELETE=@ISDELETE,ISACTIVE=@ISACTIVE WHERE USER_ID = @USER_ID");
            deletePC.Parameters.Add("@USER_ID", SqlDbType.Int).Value = POSTID;
            deletePC.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = false;
            deletePC.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = true;
            SQL.COMMAND(deletePC);
            GETPCOUNCILS();

        }

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            GETPCOUNCILS();
        }

        protected void PCLists_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager) { return; }

            try { e.Row.Cells[1].Visible = false; } catch { }
            try { e.Row.Cells[2].Visible = false; } catch { }
            try { e.Row.Cells[7].Visible = false; } catch { }
        }

        protected void PCLists_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PCLists.PageIndex = e.NewPageIndex;
            GETPCOUNCILS();
        }

        protected void PCLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["PC"] = "SELECTED";
            Session["PC_ID"] = PCLists.SelectedRow.Cells[1].Text;
            Session["PC_SERIAL"] = PCLists.SelectedRow.Cells[2].Text;
            Response.Redirect("/manage/councildetail");
        }

        protected void delete_pc_Click(object sender, EventArgs e)
        {
            //int rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            try
            {
                int rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
                //int registrantId = int.Parse(NewsList.Rows[0].Cells[1].Text);
                string id = PCLists.Rows[rowIndex].Cells[1].Text;
                DeleteData(id);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        protected void new_pc_Click(object sender, EventArgs e)
        {
            Session["PC"]     =  null;
            Session["PC_ID"]  =  null;
            Response.Redirect("/manage/councildetail");
        }
    }
}