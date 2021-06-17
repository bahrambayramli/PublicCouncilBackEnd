using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PublicCouncilBackEnd.manage
{
    public partial class WebForm19 : System.Web.UI.Page
    {
        #region(SQL FUNCTIONS)

        private void GetLink(string SOCIAL_LINK_ID)
        {
            SqlDataAdapter getLink = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                                SOCIAL_LINK_NAME     ,
                                                                                SOCIAL_LINK_URL      ,
                                                                                SOCIAL_LINK_VALUE    ,
                                                                                SOCIAL_LINK_ICON

                                                                                FROM PC_SOCIAL_LINKS
                                                                         WHERE 

                                                                         SOCIAL_LINK_ID       = @SOCIAL_LINK_ID       AND
                                                                         SOCIAL_LINK_ISDELETE = @SOCIAL_LINK_ISDELETE AND
                                                                         SOCIAL_LINK_ISACTIVE = @SOCIAL_LINK_ISACTIVE"));

            getLink.SelectCommand.Parameters.Add(@"SOCIAL_LINK_ID", SqlDbType.Int).Value = SOCIAL_LINK_ID;
            getLink.SelectCommand.Parameters.Add(@"SOCIAL_LINK_ISDELETE", SqlDbType.Int).Value = false;
            getLink.SelectCommand.Parameters.Add(@"SOCIAL_LINK_ISACTIVE", SqlDbType.Int).Value = true;

            DataTable DT = SQL.SELECT(getLink);

            text_link_name.Text = DT.Rows[0]["SOCIAL_LINK_NAME"].ToString();
            text_link_url.Text = DT.Rows[0]["SOCIAL_LINK_URL"].ToString();
            text_link_icon.Text = DT.Rows[0]["SOCIAL_LINK_ICON"].ToString();


        }

        private void InsertLink()
        {
            SqlCommand insertLink = new SqlCommand(@"INSERT INTO PC_SOCIAL_LINKS
                                                                            (
                                                                                SOCIAL_LINK_NAME         ,
                                                                                SOCIAL_LINK_URL          ,
                                                                                SOCIAL_LINK_VALUE        ,
                                                                                SOCIAL_LINK_ICON         ,
                                                                                SOCIAL_LINK_ISDELETE     ,
                                                                                SOCIAL_LINK_ISACTIVE
                                                                            )
                                                                            VALUES
                                                                            (
                                                                                @SOCIAL_LINK_NAME        ,
                                                                                @SOCIAL_LINK_URL         ,
                                                                                @SOCIAL_LINK_VALUE       ,
                                                                                @SOCIAL_LINK_ICON        ,
                                                                                @SOCIAL_LINK_ISDELETE    ,
                                                                                @SOCIAL_LINK_ISACTIVE
                                                                            )");

            insertLink.Parameters.Add(@"SOCIAL_LINK_ISDELETE", SqlDbType.Bit).Value = false;
            insertLink.Parameters.Add(@"SOCIAL_LINK_ISACTIVE", SqlDbType.Bit).Value = true;
            insertLink.Parameters.Add(@"SOCIAL_LINK_URL", SqlDbType.NVarChar).Value = text_link_url.Text;
            insertLink.Parameters.Add(@"SOCIAL_LINK_VALUE", SqlDbType.NVarChar).Value = text_link_name.Text;
            insertLink.Parameters.Add(@"SOCIAL_LINK_ICON", SqlDbType.NVarChar).Value = text_link_icon.Text;
            insertLink.Parameters.Add(@"SOCIAL_LINK_NAME", SqlDbType.NVarChar).Value = text_link_name.Text;


            SQL.COMMAND(insertLink);

        }

        private void UpdateLink(string MEDIA_LINK_ID)
        {
            SqlCommand updateLink = new SqlCommand(@"UPDATE PC_SOCIAL_LINKS

                                                            SET
                                                                 SOCIAL_LINK_NAME    = @SOCIAL_LINK_NAME          ,
                                                                 SOCIAL_LINK_URL     = @SOCIAL_LINK_URL           ,
                                                                 SOCIAL_LINK_VALUE   = @SOCIAL_LINK_VALUE         ,
                                                                 SOCIAL_LINK_ICON    = @SOCIAL_LINK_ICON         

                                                             WHERE

                                                                SOCIAL_LINK_ID = @SOCIAL_LINK_ID");

            updateLink.Parameters.Add(@"SOCIAL_LINK_NAME", SqlDbType.NVarChar).Value = text_link_name.Text;
            updateLink.Parameters.Add(@"SOCIAL_LINK_URL", SqlDbType.NVarChar).Value = text_link_url.Text;
            updateLink.Parameters.Add(@"SOCIAL_LINK_VALUE", SqlDbType.NVarChar).Value = text_link_name.Text;
            updateLink.Parameters.Add(@"SOCIAL_LINK_ICON", SqlDbType.NVarChar).Value = text_link_icon.Text;
            updateLink.Parameters.Add(@"SOCIAL_LINK_ID", SqlDbType.Int).Value = MEDIA_LINK_ID;

            SQL.COMMAND(updateLink);
        }

        #endregion

        #region(CONFIRM AND BACK BUTTON'S)
        protected void back_button_Click(object sender, EventArgs e)
        {
            Session["SOCIAL_LINK"]      = null;
            Session["SOCIAL_LINK_ID"]   = null;
            Response.Redirect("/manage/sociallinks");
        }

        protected void button_confitm_Click(object sender, EventArgs e)
        {
            if (Session["SOCIAL_LINK"] as string == "SELECTED")
            {
                //UpdateLink
                try
                {
                    UpdateLink(Session["SOCIAL_LINK_ID"] as string);
                }
                catch (Exception ex)
                {
                    Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> sociallinkdetail.aspx >> UpdateLink method, Log:{ex.Message}");
                }
            }
            else
            {
                //InsertLink
                try
                {
                    InsertLink();
                }
                catch (Exception ex)
                {
                    Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> sociallinkdetail.aspx >> InsertLink method, Log:{ex.Message}");
                }
            }
            Session["SOCIAL_LINK"]      = null;
            Session["SOCIAL_LINK_ID"]   = null;
            Response.Redirect("/manage/sociallinks");
        }
        #endregion

        private void RunMediaLinkDetail()
        {
            if (!IsPostBack)
            {
                if (Session["SOCIAL_LINK"] as string == "SELECTED")
                {
                    //GetLink
                    try
                    {
                        GetLink(Session["SOCIAL_LINK_ID"] as string);
                    }
                    catch (Exception ex)
                    {
                        Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> sociallinkdetail.aspx >> GetLink method, Log:{ex.Message}");
                    }

                    button_confitm.Text     = "Dəyiş";
                    button_confitm.CssClass = "btn btn-warning btn-round";
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //RunMediaLinkDetail
            try
            {
                RunMediaLinkDetail();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main Master >> sociallinkdetail.aspx >> RunMediaLinkDetail method, Log:{ex.Message}");
            }
        }
    }
}