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
        private void GetPosts(string USER_ID)
        {
            SqlDataAdapter getnews = new SqlDataAdapter();
            if (string.IsNullOrEmpty(USER_ID)||USER_ID=="1")
            {
                getnews = new SqlDataAdapter(
                                   new SqlCommand(@"SELECT  
                                                       ROW_NUMBER() OVER(ORDER BY POST_DATE DESC) AS '#' ,
	                                                                                                  DATA_ID,
	                                                                                                  USER_ID,
                                                                                                      POST_SEOAZ,
                                                                                                      POST_SEOEN,
                                                                                                      POST_SITECATEGORYAZ,
                                                                                                      POST_SITESUBCATEGORYAZ,
                                                                                                      POST_DATE
                                                                                                     
                                                                                                      FROM PC_POSTS 
                                                                                                            WHERE
                                                                                                           
                                                                                                            ISACTIVE =@ISACTIVE AND
                                                                                                            ISDELETE =@ISDELETE "));
              
            }
           
            else
            {
                getnews = new SqlDataAdapter(
                                   new SqlCommand(@"SELECT  
                                                       ROW_NUMBER() OVER(ORDER BY POST_DATE DESC) AS '#' ,
	                                                                                                  DATA_ID,
	                                                                                                  USER_ID,
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
                getnews.SelectCommand.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;
            }

           
            
            getnews.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            getnews.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;

            PostsList.DataSource = SQL.SELECT(getnews);
            PostsList.DataBind();
        }
        
        private void DeleteData(string POSTID)
        {
            SqlCommand deletenews = new SqlCommand(@"Update PC_POSTS SET ISDELETE=@ISDELETE,ISACTIVE=@ISACTIVE WHERE DATA_ID = @DATA_ID");
            deletenews.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = POSTID;
            deletenews.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = false;
            deletenews.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = true;
            SQL.COMMAND(deletenews);
            GetPosts(pcSelectList.SelectedValue);

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["USER_MEMBERSHIP_TYPE"] as string == "user")
            {
                GetPosts(Session["USER_ID"] as string);
                pcSelectList.Visible = false;
            }
            else
            {
                GetPosts(pcSelectList.SelectedValue);
            }
           
        }

        protected void new_post_Click(object sender, EventArgs e)
        {
            Session["POST"] = "NEW";
            Session["POSTID"] = null;
            Response.Redirect("/manage/postdetail");
        }

        protected void delete_post_Click(object sender, EventArgs e)
        {
            //int rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            try
            {
                int rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
                //int registrantId = int.Parse(NewsList.Rows[0].Cells[1].Text);
                string id = PostsList.Rows[rowIndex].Cells[1].Text;
                DeleteData(id);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        #region(Post List)
        protected void PostsList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager) { return; }

            try { e.Row.Cells[1].Visible = false; } catch { }
            try { e.Row.Cells[2].Visible = false; } catch { }
            try { e.Row.Cells[3].Visible = true; } catch { }
            try { e.Row.Cells[4].Visible = false; } catch { }


        }

        protected void PostsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            PostsList.PageIndex = e.NewPageIndex;
            
            GetPosts(pcSelectList.SelectedValue);
        }

        protected void PostsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["POST"] = "SELECTED";
            Session["POSTID"] = PostsList.SelectedRow.Cells[1].Text ;
            Session["POST_USER_ID"] = PostsList.SelectedRow.Cells[2].Text;
            Response.Redirect("/manage/postdetail");
        }

        #endregion

        protected void pcSelectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPosts(pcSelectList.SelectedValue);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = "";
            search = search + " AND POST_SEOAZ like  @POST_SEOAZ";

            SqlDataAdapter getnews = new SqlDataAdapter();
            if (string.IsNullOrEmpty(pcSelectList.SelectedValue) || pcSelectList.SelectedValue == "1")
            {
                getnews = new SqlDataAdapter(
                                   new SqlCommand(@"SELECT  
                                                       ROW_NUMBER() OVER(ORDER BY POST_DATE DESC) AS '#' ,
	                                                                                                  DATA_ID,
	                                                                                                  USER_ID,
                                                                                                      POST_SEOAZ,
                                                                                                      POST_SEOEN,
                                                                                                      POST_SITECATEGORYAZ,
                                                                                                      POST_SITESUBCATEGORYAZ,
                                                                                                      POST_DATE
                                                                                                     
                                                                                                      FROM PC_POSTS 
                                                                                                            WHERE
                                                                                                           
                                                                                                            ISACTIVE =@ISACTIVE AND
                                                                                                            ISDELETE =@ISDELETE  AND 1=1 " + search));

            }

            else
            {
                getnews = new SqlDataAdapter(
                                   new SqlCommand(@"SELECT  
                                                       ROW_NUMBER() OVER(ORDER BY POST_DATE DESC) AS '#' ,
	                                                                                                  DATA_ID,
	                                                                                                  USER_ID,
                                                                                                      POST_SEOAZ,
                                                                                                      POST_SEOEN,
                                                                                                      POST_SITECATEGORYAZ,
                                                                                                      POST_SITESUBCATEGORYAZ,
                                                                                                      POST_DATE
                                                                                                     
                                                                                                      FROM PC_POSTS 
                                                                                                            WHERE
                                                                                                            USER_ID = @USER_ID AND
                                                                                                            ISACTIVE =@ISACTIVE AND
                                                                                                            ISDELETE =@ISDELETE AND 1=1 " + search));
                getnews.SelectCommand.Parameters.Add("@USER_ID", SqlDbType.Int).Value = pcSelectList.SelectedValue;
            }

            getnews.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            getnews.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            getnews.SelectCommand.Parameters.Add("@POST_SEOAZ", SqlDbType.NVarChar).Value = "%"+ inputSearch.Text+ "%";

            PostsList.DataSource = SQL.SELECT(getnews);
            PostsList.DataBind();

            search = null;

        }

        protected void btnGetAll_Click(object sender, EventArgs e)
        {
            GetPosts("");
        }
    }
}