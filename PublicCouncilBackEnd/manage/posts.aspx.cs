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
    public partial class WebForm2 : System.Web.UI.Page
    {

        #region(SQL FUNCTIONS)
        private void GetNews(string userid)
        {
            SqlDataAdapter getnews = new SqlDataAdapter(
                                     new SqlCommand(@"SELECT  
                                                       ROW_NUMBER() OVER(ORDER BY POST_DATE DESC) AS '#' ,
	                                                                                                  DATA_ID,
                                                                                                      POST_SEOAZ,
                                                                                                      POST_SEOEN,
                                                                                                      POST_SITECATEGORYAZ,
                                                                                                      POST_SITESUBCATEGORYAZ,
                                                                                                      POST_DATE
                                                                                                     
                                                                                                      FROM PC_POSTS 
                                                                                                            WHERE
                                                                                                            USER_ID = @USER_ID AND
                                                                                                            ISACTIVE =@ISACTIVE AND
                                                                                                            ISDELETE =@ISDELETE"));
            getnews.SelectCommand.Parameters.Add("@USER_ID", SqlDbType.Int).Value = userid;
            getnews.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            getnews.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;

            PostsList.DataSource = SQL.SELECT(getnews);
            PostsList.DataBind();
        }

        private void DeleteData(string USERID)
        {
            SqlCommand deletenews = new SqlCommand(@"Update DATA_NEWS SET ISDELETE=@ISDELETE,ISACTIVE=@ISACTIVE WHERE DATA_ID = @DATA_ID");
            deletenews.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = USERID;
            deletenews.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = false;
            deletenews.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = true;
            SQL.COMMAND(deletenews);
            GetNews(Session["USER_ID"] as string);

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            GetNews(Session["USER_ID"] as string);
        }

        protected void new_post_Click(object sender, EventArgs e)
        {
            Session["POST"] = "NEW";
            Response.Redirect("/manage/postdetail");
        }
        protected void deletePost_Click(object sender, EventArgs e)
        {
            DeleteData(Session["USER_ID"] as string);
        }

        #region(Post List)
        protected void PostsList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager) { return; }

            try { e.Row.Cells[1].Visible = false; } catch { }
            try { e.Row.Cells[2].Visible = true; } catch { }
            try { e.Row.Cells[3].Visible = false; } catch { }
           
        }

        protected void PostsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            PostsList.PageIndex = e.NewPageIndex;
            GetNews(Session["USER_ID"] as string);
        }

        protected void PostsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["POST"] = "SELECTED";
            Response.Redirect("/manage/postdetail");
        }
        #endregion




    }
}