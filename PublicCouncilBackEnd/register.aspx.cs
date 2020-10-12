using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PublicCouncilBackEnd
{
    public partial class WebForm11 : System.Web.UI.Page
    {

        #region(SQL FUNCTIONS)
        public bool CheckAccount(string login, string subdomain,bool ISDELETE)
        {

            SqlDataAdapter checkAccount = new SqlDataAdapter(new SqlCommand(@"
                                                                                SELECT	
                                                                                		USER_LOGIN,                                                                             		
                                                                                		USER_PCDOMAIN

                                                                                 FROM   PC_USERS

                                                                                 WHERE	
                                                                                        USER_LOGIN     = @USER_LOGIN      AND
                                                                                        USER_PCDOMAIN  = @USER_PCDOMAIN   AND
                                                                                        ISDELETE       = @ISDELETE       
                                                                                		 "));

            checkAccount.SelectCommand.Parameters.Add("@USER_LOGIN", SqlDbType.NVarChar).Value = login;
            checkAccount.SelectCommand.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value = subdomain;
            checkAccount.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = ISDELETE;


            DataTable dt = SQL.SELECT(checkAccount);

            if (dt.Rows.Count > 0)
            {
                return true; //user is exist
            }
            else
            {
                return false; //is not
            }


        }

        public void InsertUser()
        {
            Session["user_register_serial"] = Helper.MakeSerial();

            #region(Register)

            SqlCommand insertUser = new SqlCommand(@"INSERT INTO PC_USERS
                                                        (
		                                                 ISDELETE,
                                                         ISACTIVE,
                                                         ISONLINE,
                                                         USER_MEMBERSHIP,
                                                         USER_MEMBERSHIP_TYPE,
                                                         USER_LOGIN,
                                                         USER_PASSWORD,
                                                         USER_SERIAL,
                                                         USER_PCDOMAIN,
                                                         USER_NAME,
                                                         USER_SURNAME,
                                                         USER_MOBILE,
                                                         PC_NAME,
                                                         PC_TELEPHONE,
                                                         PC_EMAIL,
                                                         PC_WEBADDRESS,
                                                         PC_COUNTRY,
                                                         PC_CITY
                                                         PC_ADDRESS,
                                                         CREATED_DATE,
                                                         PC_CATEGORY
	                                                    )
                                                  VALUES
                                                        (
		                                                 @ISDELETE,
                                                         @ISACTIVE,
                                                         @ISONLINE,
                                                         @MONTHLY,
                                                         @USER_MEMBERSHIP,
                                                         @USER_MEMBERSHIP_TYPE,
                                                         @USER_LOGIN,
                                                         @USER_PASSWORD,
                                                         @USER_SERIAL,
                                                         @USER_PCDOMAIN,
                                                         @USER_NAME,
                                                         @USER_SURNAME,
                                                         @USER_BIRTHDATE,
                                                         @USER_MOBILE,
                                                         @USER_GENDER,
                                                         @PC_NAME,
                                                         @PC_ACTIVITY,
                                                         @PC_TELEPHONE,
                                                         @PC_EMAIL,
                                                         @PC_WEBADDRESS,
                                                         @PC_COUNTRY,
                                                         @PC_CITY
                                                         @PC_ADDRESS,
                                                         @PC_SERVICES,
                                                         @PC_ABOUT,
                                                         @CREATED_DATE,
                                                         @PC_CATEGORY
                                                        
	                                                	   )");

            insertUser.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            insertUser.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = false;
            insertUser.Parameters.Add("@ISONLINE", SqlDbType.Bit).Value = false;
           

            SQL.COMMAND(insertUser);
            #endregion

            

            #region(Logo Upload)
            //Logo upload
            if (logoUpload.HasFile)
            {
                string extension = Path.GetExtension(logoUpload.FileName).ToLower();
                if ((extension != ".jpg") &&
                    (extension != ".jpeg") &&
                    (extension != ".bmp") &&
                    (extension != ".png") &&
                    (extension != ".gif") &&
                    (extension != ".tif") &&
                    (extension != ".tiff")) return;

                string logoName = Helper.SetName(extension);


                SqlCommand insertLOGO = new SqlCommand(@"INSERT INTO PC_SITELOGOS
                                                                                       (
                                                                            			ISDELETE,
                                                                            			ISACTIVE,
                                                                            			LOGO_TITLE,
                                                                            			LOGO_IMG,                                                                            			
                                                                            			LOGO_SERIAL
                                                                            		   )
                                                                                 VALUES
                                                                                      ( 
                                                                                        @ISDELETE,
                                                                            			@ISACTIVE,
                                                                            			@LOGO_TITLE,
                                                                            			@LOGO_IMG,                                                                            			
                                                                            			@LOGO_SERIAL
                                                                                      )");

                insertLOGO.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;

                insertLOGO.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;

                insertLOGO.Parameters.Add("@LOGO_TITLE", SqlDbType.NVarChar).Value = logoUpload.FileName;

                insertLOGO.Parameters.Add("@LOGO_IMG", SqlDbType.NVarChar).Value = logoName;

                insertLOGO.Parameters.Add("@LOGO_SERIAL", SqlDbType.NVarChar).Value = Session["user_register_serial"] as string;

                SQL.COMMAND(insertLOGO);

                logoUpload.SaveAs(Server.MapPath("~/Images/logos/" + logoName));
            }
            #endregion
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (CheckAccount(inputLoginName.Text, inputPCdomain.Text, false))
            {
                errorLiteral.Text = @"<div class='text-danger'>Bu istifadəçi artıq bazada mövcuddur.</div>";
                return;
            }


            Response.Redirect("/login");
        }
    }
}