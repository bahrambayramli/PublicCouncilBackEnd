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
    public partial class WebForm13 : System.Web.UI.Page
    {

        #region(SQL FUNCTIONS)
        private void GetMembers(string PC_ID, bool ISDELETE, GridView GRID)
        {
            SqlDataAdapter getMember = new SqlDataAdapter(new SqlCommand(@"SELECT ROW_NUMBER() OVER(ORDER BY MEMBER_ID DESC) AS '#' ,
                                                                                  MEMBER_ID,
                                                                                  MEMBER_NAME,
                                                                                  MEMBER_SURNAME

                                                                            FROM PC_MEMBERS

                                                                            WHERE ISDELETE     = @ISDELETE AND
                                                                                  PC_ID        = @PC_ID"));
            getMember.SelectCommand.Parameters.Add("@PC_ID", SqlDbType.Int).Value = PC_ID;
            getMember.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = ISDELETE;

            GRID.DataSource = SQL.SELECT(getMember);
            GRID.DataBind();

        }

        public void DeleteLogo(string ID)
        {
            SqlCommand deletenews = new SqlCommand(@"Update PC_MEMBERS SET ISDELETE=@ISDELETE WHERE MEMBER_ID = @MEMBER_ID");
            deletenews.Parameters.Add("@MEMBER_ID", SqlDbType.Int).Value = ID;
            deletenews.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = true;
            SQL.COMMAND(deletenews);
            GetMembers(Session["USER_ID"] as string, false, MemberList);//?

        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["MEMBER"] = null;
                GetMembers(Session["PC_ID"] as string, false, MemberList);
            }
        }

        protected void MemberList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager) { return; }
            try { e.Row.Cells[1].Visible = false; } catch { }
            
        }

        protected void MemberList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            MemberList.PageIndex = e.NewPageIndex;
            GetMembers(Session["USR_SERIAL"] as string, false, MemberList);
        }

        protected void MemberList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["MEMBER"] = "SELECTED";
            Session["MEMBER_ID"] = MemberList.SelectedRow.Cells[1].Text;
            Response.Redirect("/manage/memberdetail");
        }

        protected void delete_member_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
                string id = MemberList.Rows[rowIndex].Cells[1].Text;
                DeleteLogo(id);

            }
            catch 
            {
               
            }
        }

        protected void newMember_Click(object sender, EventArgs e)
        {
          
        }

        protected void newMember_Click1(object sender, EventArgs e)
        {
            Session["MEMBER"] = null;
            Response.Redirect("/manage/memberdetail");
        }
    }
}