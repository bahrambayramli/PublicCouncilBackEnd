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
        private bool CheckAccount(string login, string subdomain,bool ISDELETE)
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
        private string GetDate()
        {
            SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand("SELECT FORMAT (SYSDATETIME() ,'dd/MM/yyyy HH:mm' ) as DataTime"));
            return SQL.SELECT(adapter).Rows[0]["DataTime"].ToString();
        }
        private void InsertUser()
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
                                                         PC_CITY,
                                                        
                                                         CREATED_DATE,
                                                         PC_CATEGORY
	                                                    )
                                                  VALUES
                                                        (
		                                                 @ISDELETE,
                                                         @ISACTIVE,
                                                         @ISONLINE,
                                                         @USER_MEMBERSHIP,
                                                         @USER_MEMBERSHIP_TYPE,
                                                         @USER_LOGIN,
                                                         @USER_PASSWORD,
                                                         @USER_SERIAL,
                                                         @USER_PCDOMAIN,
                                                         @USER_NAME,
                                                         @USER_SURNAME,                                                      
                                                         @USER_MOBILE,
                                                         @PC_NAME,
                                                         @PC_TELEPHONE,
                                                         @PC_EMAIL,
                                                         @PC_WEBADDRESS,
                                                         @PC_COUNTRY,
                                                         @PC_CITY,
                                                         
                                                         @CREATED_DATE,
                                                         @PC_CATEGORY
                                                        
	                                                	   )");

            insertUser.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            insertUser.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = false;
            insertUser.Parameters.Add("@ISONLINE", SqlDbType.Bit).Value = false;

            insertUser.Parameters.Add("@USER_MEMBERSHIP", SqlDbType.NVarChar).Value = "pc";
            insertUser.Parameters.Add("@USER_MEMBERSHIP_TYPE", SqlDbType.NVarChar).Value = "user";
            insertUser.Parameters.Add("@USER_LOGIN", SqlDbType.NVarChar).Value = inputLoginName.Text;
            insertUser.Parameters.Add("@USER_PASSWORD", SqlDbType.NVarChar).Value = Crypto.MD5crypt(inputPassword.Text);
            insertUser.Parameters.Add("@USER_SERIAL", SqlDbType.NVarChar).Value = Session["user_register_serial"] as string;
            insertUser.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value = inputPCdomain.Text;
            insertUser.Parameters.Add("@USER_NAME", SqlDbType.NVarChar).Value = inputName.Text;
            insertUser.Parameters.Add("@USER_SURNAME", SqlDbType.NVarChar).Value = inputSurname.Text;
            insertUser.Parameters.Add("@PC_NAME", SqlDbType.NVarChar).Value = inputPCname.Text;
           
            insertUser.Parameters.Add("@PC_TELEPHONE", SqlDbType.NVarChar).Value = inputTelephone.Text;
            insertUser.Parameters.Add("@USER_MOBILE", SqlDbType.NVarChar).Value = inputMobile.Text;
            insertUser.Parameters.Add("@PC_EMAIL", SqlDbType.NVarChar).Value = inputEmail.Text;
            insertUser.Parameters.Add("@PC_WEBADDRESS", SqlDbType.NVarChar).Value = inputWeb.Text;
            insertUser.Parameters.Add("@PC_COUNTRY", SqlDbType.NVarChar).Value = "Azərbaycan";
            insertUser.Parameters.Add("@PC_CITY", SqlDbType.NVarChar).Value = inputCity.SelectedItem.Text;
           
            DateTime createdDate = DateTime.ParseExact(GetDate(), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            insertUser.Parameters.Add("@CREATED_DATE", SqlDbType.Date).Value = createdDate.ToString(); ;
            insertUser.Parameters.Add("@PC_CATEGORY", SqlDbType.NVarChar).Value = categorySelect.SelectedValue;
           


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

            InsertUser();
            Response.Redirect("/login");
        }
    }
}