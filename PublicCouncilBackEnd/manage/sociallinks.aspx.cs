using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PublicCouncilBackEnd.manage
{
    public partial class WebForm18 : System.Web.UI.Page
    {
        #region(SQL FUNCTIONS)
        private void GetSocialLinks()
        {
            SqlDataAdapter getLinks = new SqlDataAdapter(new SqlCommand(@"
                                                                        SELECT 

                                                                        ROW_NUMBER() OVER(ORDER BY SOCIAL_LINK_ID DESC) AS '#'   ,
                                                                        SOCIAL_LINK_ID                                           ,
                                                                        SOCIAL_LINK_NAME                                         ,
                                                                        SOCIAL_LINK_URL
                                                                        
                                                                        FROM PC_SOCIAL_LINKS

                                                                        WHERE
                                                                             SOCIAL_LINK_ISDELETE = @SOCIAL_LINK_ISDELETE AND
                                                                             SOCIAL_LINK_ISACTIVE = @SOCIAL_LINK_ISACTIVE
                                                                            "));

            getLinks.SelectCommand.Parameters.Add("@SOCIAL_LINK_ISDELETE", SqlDbType.Bit).Value = false;
            getLinks.SelectCommand.Parameters.Add("@SOCIAL_LINK_ISACTIVE", SqlDbType.Bit).Value = true;

            SocialLinks.DataSource = SQL.SELECT(getLinks);
            SocialLinks.DataBind();
        }

        private void DeleteSocialLink(string SOCIAL_LINK_ID)
        {
            SqlCommand deleteSocialLink = new SqlCommand(@"UPDATE PC_SOCIAL_LINKS SET SOCIAL_LINK_ISDELETE = @SOCIAL_LINK_ISDELETE , SOCIAL_LINK_ISDELETE = @SOCIAL_LINK_ISDELETE  WHERE SOCIAL_LINK_ID = @SOCIAL_LINK_ID");
            deleteSocialLink.Parameters.Add("@SOCIAL_LINK_ISDELETE", SqlDbType.Bit).Value = true;
            deleteSocialLink.Parameters.Add("@SOCIAL_LINK_ISACTIVE", SqlDbType.Bit).Value = false;
            deleteSocialLink.Parameters.Add("@SOCIAL_LINK_ID", SqlDbType.Int).Value = SOCIAL_LINK_ID;

            SQL.COMMAND(deleteSocialLink);


        }
        #endregion

        #region(SOCIAL LINKS GRIDVIEW EVENTS)
        protected void SocialLinks_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager) { return; }
            try { e.Row.Cells[1].Visible = false; } catch { }
        }

        protected void SocialLinks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SocialLinks.PageIndex = e.NewPageIndex;
            //GetSocialLinks
            try
            {
                GetSocialLinks();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> sociallinks.aspx >> GetSocialLinks method, Log:{ex.Message}");
            }
        }

        protected void SocialLinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SOCIAL_LINK"] = "SELECTED";
            Session["SOCIAL_LINK_ID"] = SocialLinks.SelectedRow.Cells[1].Text;
            Response.Redirect("/manage/sociallinkdetail");
        }
        #endregion

        #region(NEW AND DELETE BUTTONS EVENTS)

        protected void new_SOCIAL_link_Click(object sender, EventArgs e)
        {
            Session["SOCIAL_LINK"]      = null;
            Session["SOCIAL_LINK_ID"]   = null;
            Response.Redirect("/manage/sociallinkdetail");
        }

        protected void delete_link_Click(object sender, EventArgs e)
        {
            //DeleteSocialLink
            try
            {
                int rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
                string id = SocialLinks.Rows[rowIndex].Cells[1].Text;

                DeleteSocialLink(id);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> sociallinks.aspx >> DeleteSocialLink method, Log:{ex.Message}");
            }

            //GetSocialLinks
            try
            {
                GetSocialLinks();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> sociallinks.aspx >> GetSocialLinks method, Log:{ex.Message}");
            }
        }

        #endregion

        private void RunSocialLinks()
        {
            //GetSocialLinks
            try
            {
                GetSocialLinks();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> sociallinks.aspx >> GetSocialLinks method, Log:{ex.Message}");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //RunSocialLinks
            try
            {
                RunSocialLinks();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> sociallinks.aspx >> RunSocialLinks method, Log:{ex.Message}");
            }
        }
    }
}