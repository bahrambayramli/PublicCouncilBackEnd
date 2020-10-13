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
    public partial class WebForm5 : System.Web.UI.Page
    {
        #region(SQL FUNCTIONS)
        private void GetLogos(string LOGO_ID, bool ISDELETE, string USER_ID)
        {
            SqlDataAdapter getLogos = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                                   DATA_ID,
                                                                                   USER_ID,
                                                                                   LOGO_TITLE,
                                                                                   LOGO_IMG
                                                                            FROM PC_SITELOGOS
                                                                            WHERE ISDELETE     = @ISDELETE    AND
                                                                                  DATA_ID      = @DATA_ID     AND
                                                                                  USER_ID  = @USER_ID"));


            getLogos.SelectCommand.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = LOGO_ID;
            getLogos.SelectCommand.Parameters.Add("@USER_ID", SqlDbType.NVarChar).Value = USER_ID;
            getLogos.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = ISDELETE;

            DataTable DT = SQL.SELECT(getLogos);

            logoname.Text = DT.Rows[0]["LOGO_TITLE"].ToString();
            logoImage.ImageUrl = "/Images/logos/" + DT.Rows[0]["LOGO_IMG"].ToString();

          //  Session["LOGOISACTIVE"] = DT.Rows[0]["ISACTIVE"].ToString();
        }

        private void UpdateLogo(string LOGO_ID, string USER_ID)
        {
            //Update
            //1. Logo text
            //2.Logo image
            //if the logo file input has files need to add the new image to /Uploads/logos folder and update in sql 
            //if the logo file input has not file need to update only logo text
            SqlCommand updateLogo = new SqlCommand();

            if (logoFile.HasFile)
            {
                string extension = Path.GetExtension(logoFile.FileName).ToLower();
                if ((extension != ".jpg") &&
                    (extension != ".jpeg") &&
                    (extension != ".bmp") &&
                    (extension != ".png") &&
                    (extension != ".gif") &&
                    (extension != ".tif") &&
                    (extension != ".tiff")) return;

                string logoName = Helper.SetName(extension);

                updateLogo = new SqlCommand(@"UPDATE PC_SITELOGOS 
                                                            SET  
						                                    LOGO_TITLE = @LOGO_TITLE,
						                                    LOGO_IMG   = @LOGO_IMG
					                                        WHERE 
                                                                  DATA_ID     =  @DATA_ID  AND
                                                                  USER_ID =  @USER_ID
                                                                  ");
                updateLogo.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = LOGO_ID;
                updateLogo.Parameters.Add("@USER_ID", SqlDbType.NVarChar).Value = USER_ID;
                updateLogo.Parameters.Add("@LOGO_TITLE", SqlDbType.NVarChar).Value = logoname.Text;
                updateLogo.Parameters.Add("@LOGO_IMG", SqlDbType.NVarChar).Value = logoName;
                updateLogo.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = false;

                logoFile.SaveAs(Server.MapPath("/Images/logos/" + logoName));

            }
            else
            {
                updateLogo = new SqlCommand(@"UPDATE DATA_SITELOGOS 
                                                                         SET   
                                                                               LOGO_TITLE = @LOGO_TITLE   
					                                                     WHERE 
                                                                               DATA_ID    =   @DATA_ID    AND
                                                                               USER_ID =  @USER_ID 
                                                                             ");
                updateLogo.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = LOGO_ID;
                updateLogo.Parameters.Add("@LOGO_TITLE", SqlDbType.NVarChar).Value = logoname.Text;
                updateLogo.Parameters.Add("@USER_ID", SqlDbType.NVarChar).Value = USER_ID;
            }

            SQL.COMMAND(updateLogo);
        }

        private void InsertLogo(string USER_ID)
        {
            string logoSerial = Helper.MakeSerial();

          

            if (logoFile.HasFile)
            {
                string extension = Path.GetExtension(logoFile.FileName).ToLower();
                if ((extension != ".jpg") &&
                    (extension != ".jpeg") &&
                    (extension != ".bmp") &&
                    (extension != ".png") &&
                    (extension != ".gif") &&
                    (extension != ".tif") &&
                    (extension != ".tiff")) return;

                foreach (HttpPostedFile postedFile in logoFile.PostedFiles)
                {
                    string logoName = Helper.SetName(extension);

                    SqlCommand insertLogo = new SqlCommand(@"INSERT INTO PC_SITELOGOS
                                                                                    (
	                                                                                 ISDELETE,
                                                                                     ISACTIVE,
                                                                                     LOGO_TITLE,
                                                                                     LOGO_IMG,
                                                                                     USER_ID,
                                                                                     LOGO_SERIAL
	                                                                                )
                                                                              VALUES
                                                                                    (
	                                                                            	 @ISDELETE,
                                                                                     @ISACTIVE,
                                                                                     @LOGO_TITLE,
                                                                                     @LOGO_IMG,
                                                                                     @USER_ID,
                                                                                     @LOGO_SERIAL
	                                                                            	)
                                                                                    ");

                    insertLogo.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                    insertLogo.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;

                    insertLogo.Parameters.Add("@LOGO_TITLE", SqlDbType.NVarChar).Value = logoname.Text;
                    insertLogo.Parameters.Add("@LOGO_IMG", SqlDbType.NVarChar).Value = logoName;

                    insertLogo.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;

                    insertLogo.Parameters.Add("@LOGO_SERIAL", SqlDbType.NVarChar).Value = logoSerial;

                    SQL.COMMAND(insertLogo);

                    postedFile.SaveAs(Server.MapPath("/Images/logos/" + logoName));
                }
            }

          

        }
        #endregion




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["LOGO"] as string == "SELECTED")
                {
                    try
                    {
                        GetLogos(Session["LOGO_ID"] as string, false, Session["USER_ID"] as string);
                    }
                    catch (Exception ex)
                    {
                       // Log.LogCreator(Server.MapPath("~/Logs/logs.txt"), ex.Message);
                    }

                    try
                    {
                        logoConfirm.Text = "Dəyiş";
                        logoConfirm.CssClass = "btn btn-warning";
                    }
                    catch (Exception ex)
                    {
                       // Log.LogCreator(Server.MapPath("~/Logs/logs.txt"), ex.Message);
                    }
                }
            }
        }

        protected void logodetail_back_Click(object sender, EventArgs e)
        {
            Session["LOGO"] = null;
            Session["LOGO_ID"] = null;

            Response.Redirect("/manage/logos");
        }

        protected void logoConfirm_Click(object sender, EventArgs e)
        {
            if (Session["LOGO"] as string == "SELECTED")
            {
                UpdateLogo(Session["LOGO_ID"] as string, Session["USER_ID"] as string);
            }
            else
            {
                InsertLogo(Session["USER_ID"] as string);
            }

           

            Session["LOGO"] = null;
            Session["LOGO_ID"] = null;

            Response.Redirect("/manage/logos");
        }
    }
}