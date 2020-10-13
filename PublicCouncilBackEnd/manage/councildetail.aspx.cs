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
    public partial class WebForm11 : System.Web.UI.Page
    {
        #region(SQL FUNCTIONS)

       
        private bool CheckAccount(string login, string subdomain, bool ISDELETE)
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

        private void GetPCOUNCIL(string USER_ID)
        {
            SqlDataAdapter getPC =
                new SqlDataAdapter(
                    new SqlCommand(@"SELECT 
                                                                               ISACTIVE,
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

                                                                               FROM PC_USERS

                                                                               WHERE 
                                                                                USER_ID      = @USER_ID "));

            getPC.SelectCommand.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;

            DataTable pc = SQL.SELECT(getPC);

            if (pc.Rows[0]["ISACTIVE"].ToString().ToLower() == "false")
            {
                inputISACTIVE.Items.FindByValue("0").Selected = true;
            }
            else
            {
                inputISACTIVE.Items.FindByValue("1").Selected = true;
            }

            foreach (ListItem item in inputMembershipType.Items)
            {

                if (item.Value.ToString() == pc.Rows[0]["USER_MEMBERSHIP_TYPE"].ToString().ToLower())
                {
                    try
                    {
                        inputMembershipType.Items.FindByValue(item.Value.ToString()).Selected = true;
                    }
                    catch
                    {

                    }
                }
            }

            foreach (ListItem item in inputCity.Items)
            {

                if (item.Value.ToString() == pc.Rows[0]["PC_CITY"].ToString().ToLower())
                {
                    try
                    {
                        inputCity.Items.FindByValue(item.Value.ToString()).Selected = true;
                    }
                    catch (Exception ex)
                    {
                        //  Debug.WriteLine(ex.Message);
                    }
                }
            }

            foreach (ListItem item in categorySelect.Items)
            {

                if (item.Value.ToString() == pc.Rows[0]["PC_CATEGORY"].ToString().ToLower())
                {
                    try
                    {
                        categorySelect.Items.FindByValue(item.Value.ToString()).Selected = true;
                    }
                    catch
                    {

                    }
                }
            }

            inputLoginName.Text = pc.Rows[0]["USER_LOGIN"].ToString().ToLower();

            inputPCdomain.Text = pc.Rows[0]["USER_PCDOMAIN"].ToString().ToLower();

            inputName.Text = pc.Rows[0]["USER_NAME"].ToString().ToLower();

            inputSurname.Text = pc.Rows[0]["USER_SURNAME"].ToString().ToLower();

            inputLoginName.Text = pc.Rows[0]["USER_LOGIN"].ToString().ToLower();

            inputEmail.Text = pc.Rows[0]["PC_EMAIL"].ToString().ToLower();

            inputMobile.Text = pc.Rows[0]["USER_MOBILE"].ToString().ToLower();

            inputTelephone.Text = pc.Rows[0]["PC_TELEPHONE"].ToString().ToLower();

            inputWeb.Text = pc.Rows[0]["PC_WEBADDRESS"].ToString().ToLower();

            inputPCname.Text = pc.Rows[0]["PC_NAME"].ToString().ToLower();

            GetLogos(pc.Rows[0]["USER_SERIAL"].ToString(), false);

        }
        private void InsertUser()
        {
            Session["NEW_USER_SERIAL"] = Helper.MakeSerial();

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

            if (inputISACTIVE.SelectedItem.Text == "Bəli")
            {
                insertUser.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            }
            else
            {
                insertUser.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = false;
            }

            insertUser.Parameters.Add("@ISONLINE", SqlDbType.Bit).Value = false;

            insertUser.Parameters.Add("@USER_MEMBERSHIP", SqlDbType.NVarChar).Value = "pc";
            insertUser.Parameters.Add("@USER_MEMBERSHIP_TYPE", SqlDbType.NVarChar).Value = "user";
            insertUser.Parameters.Add("@USER_LOGIN", SqlDbType.NVarChar).Value = inputLoginName.Text;
            insertUser.Parameters.Add("@USER_PASSWORD", SqlDbType.NVarChar).Value = Crypto.MD5crypt(inputPassword.Text);
            insertUser.Parameters.Add("@USER_SERIAL", SqlDbType.NVarChar).Value = Session["NEW_USER_SERIAL"] as string;
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

            InsertLogo(Session["NEW_USER_SERIAL"] as string);
        }

        private void UpdateUser(string USER_SERIAL,string USER_ID)
        {
           

            #region(Update)

            SqlCommand updateUser = new SqlCommand();

            if (!string.IsNullOrEmpty(inputPassword.Text))
            {
                updateUser =    new SqlCommand(@"UPDATE PC_USERS SET 
                                                        
		                                                
                                                         ISACTIVE              = @ISACTIVE              ,                                                      
                                                         USER_MEMBERSHIP       = @USER_MEMBERSHIP       ,
                                                         USER_MEMBERSHIP_TYPE  = @USER_MEMBERSHIP_TYPE  ,
                                                         USER_LOGIN            = @USER_LOGIN            ,
                                                         USER_PASSWORD         = @USER_PASSWORD         ,
                                                         USER_PCDOMAIN         = @USER_PCDOMAIN         ,
                                                         USER_NAME             = @USER_NAME             ,
                                                         USER_SURNAME          = @USER_SURNAME          ,
                                                         USER_MOBILE           = @USER_MOBILE           ,
                                                         PC_NAME               = @PC_NAME               ,
                                                         PC_TELEPHONE          = @PC_TELEPHONE          ,
                                                         PC_EMAIL              = @PC_EMAIL              ,
                                                         PC_WEBADDRESS         = @PC_WEBADDRESS         ,                                                      
                                                         PC_CITY               = @PC_CITY               ,
                                                         PC_CATEGORY           = @PC_CATEGORY
	                                                    
                                                         WHERE USER_ID = @USER_ID
                                                        
	                                                	   ");
                updateUser.Parameters.Add("@USER_PASSWORD", SqlDbType.NVarChar).Value = Crypto.MD5crypt(inputPassword.Text);
            }
            else
            {
                updateUser = new SqlCommand(@"UPDATE PC_USERS SET 
                                                        
		                                                
                                                         ISACTIVE              = @ISACTIVE              , 
                                                         USER_MEMBERSHIP       = @USER_MEMBERSHIP       ,
                                                         USER_MEMBERSHIP_TYPE  = @USER_MEMBERSHIP_TYPE  ,
                                                         USER_LOGIN            = @USER_LOGIN            ,
                                                         USER_PASSWORD         = @USER_PASSWORD         ,
                                                       
                                                         USER_PCDOMAIN         = @USER_PCDOMAIN         ,
                                                         USER_NAME             = @USER_NAME             ,
                                                         USER_SURNAME          = @USER_SURNAME          ,
                                                         USER_MOBILE           = @USER_MOBILE           ,
                                                         PC_NAME               = @PC_NAME               ,
                                                         PC_TELEPHONE          = @PC_TELEPHONE          ,
                                                         PC_EMAIL              = @PC_EMAIL              ,
                                                         PC_WEBADDRESS         = @PC_WEBADDRESS         ,                                                      
                                                         PC_CITY               = @PC_CITY               ,                                                       
                                                         PC_CATEGORY           = @PC_CATEGORY
	                                                    
                                                         WHERE ISER_ID = @USER_ID
                                                        
	                                                	   ");
            }


            updateUser.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID ;

            if (inputISACTIVE.SelectedItem.Text=="Bəli")
            {
                updateUser.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value =true ;
            }
            else
            {
                updateUser.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = false;
            }

            updateUser.Parameters.Add("@USER_MEMBERSHIP", SqlDbType.NVarChar).Value = "pc";
            updateUser.Parameters.Add("@USER_MEMBERSHIP_TYPE", SqlDbType.NVarChar).Value = inputMembershipType.SelectedValue;
            updateUser.Parameters.Add("@USER_LOGIN", SqlDbType.NVarChar).Value = inputLoginName.Text;
            
            updateUser.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value = inputPCdomain.Text;
            updateUser.Parameters.Add("@USER_NAME", SqlDbType.NVarChar).Value = inputName.Text;
            updateUser.Parameters.Add("@USER_SURNAME", SqlDbType.NVarChar).Value = inputSurname.Text;
            updateUser.Parameters.Add("@PC_NAME", SqlDbType.NVarChar).Value = inputPCname.Text;
            updateUser.Parameters.Add("@PC_TELEPHONE", SqlDbType.NVarChar).Value = inputTelephone.Text;
            updateUser.Parameters.Add("@USER_MOBILE", SqlDbType.NVarChar).Value = inputMobile.Text;
            updateUser.Parameters.Add("@PC_EMAIL", SqlDbType.NVarChar).Value = inputEmail.Text;
            updateUser.Parameters.Add("@PC_WEBADDRESS", SqlDbType.NVarChar).Value = inputWeb.Text;
            updateUser.Parameters.Add("@PC_CITY", SqlDbType.NVarChar).Value = inputCity.SelectedItem.Text;
            updateUser.Parameters.Add("@PC_CATEGORY", SqlDbType.NVarChar).Value = categorySelect.SelectedValue;



            SQL.COMMAND(updateUser);
            #endregion

            UpdateLogo(USER_SERIAL,USER_ID);
        }


        #endregion


        #region(LOGO)
        private void GetLogos(string LOGO_SERIAL, bool ISDELETE)
        {
            SqlDataAdapter getLogos = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                                   DATA_ID,
                                                                                   USER_ID,
                                                                                   LOGO_TITLE,
                                                                                   LOGO_IMG
                                                                            FROM PC_SITELOGOS
                                                                            WHERE ISDELETE          = @ISDELETE    AND
                                                                                   LOGO_SERIAL      = @LOGO_SERIAL   
                                                                                 "));


            getLogos.SelectCommand.Parameters.Add("@LOGO_SERIAL", SqlDbType.NVarChar).Value = LOGO_SERIAL;

            getLogos.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = ISDELETE;

            DataTable DT = SQL.SELECT(getLogos);


            logoImage.ImageUrl = "/Images/logos/" + DT.Rows[0]["LOGO_IMG"].ToString();

            //  Session["LOGOISACTIVE"] = DT.Rows[0]["ISACTIVE"].ToString();
        }
        private void InsertLogo(string USER_SERIAL)
        {




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
                                                                                   
                                                                                     LOGO_SERIAL
	                                                                                )
                                                                              VALUES
                                                                                    (
	                                                                            	 @ISDELETE,
                                                                                     @ISACTIVE,
                                                                                     @LOGO_TITLE,
                                                                                     @LOGO_IMG,
                                                                                     
                                                                                     @LOGO_SERIAL
	                                                                            	)
                                                                                    ");

                    insertLogo.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                    insertLogo.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;

                    insertLogo.Parameters.Add("@LOGO_TITLE", SqlDbType.NVarChar).Value = postedFile.FileName;
                    insertLogo.Parameters.Add("@LOGO_IMG", SqlDbType.NVarChar).Value = logoName;



                    insertLogo.Parameters.Add("@LOGO_SERIAL", SqlDbType.NVarChar).Value = USER_SERIAL;

                    SQL.COMMAND(insertLogo);

                    postedFile.SaveAs(Server.MapPath("/Images/logos/" + logoName));
                }
            }



        }
        private void UpdateLogo(string USER_SERIAL, string USER_ID)
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
						                                    LOGO_IMG   = @LOGO_IMG,
                                                            USER_ID    = @USER_ID
					                                        WHERE 
                                                                 
                                                                  LOGO_SERIAL = @LOGO_SERIAL
                                                                  ");

                updateLogo.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;
                updateLogo.Parameters.Add("@LOGO_IMG", SqlDbType.NVarChar).Value = logoName;
                updateLogo.Parameters.Add("@LOGO_TITLE", SqlDbType.NVarChar).Value = logoFile.FileName;


                logoFile.SaveAs(Server.MapPath("/Images/logos/" + logoName));

            }
            else
            {
                updateLogo = new SqlCommand(@"UPDATE PC_SITELOGOS  SET  USER_ID = @USER_ID  WHERE LOGO_SERIAL = @LOGO_SERIAL");

               
                updateLogo.Parameters.Add("@USER_ID", SqlDbType.NVarChar).Value = USER_ID;
            }

            updateLogo.Parameters.Add("@LOGO_SERIAL", SqlDbType.NVarChar).Value = USER_SERIAL;

            SQL.COMMAND(updateLogo);
        }


        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["PC"] as string == "SELECTED")
                {
                    GetPCOUNCIL(Session["PC_ID"] as string);

                    try
                    {
                        btnConfirm.Text = "Dəyiş";
                        btnConfirm.CssClass = "btn btn-warning";
                    }
                    catch 
                    {
                        
                    }
                }

            }
           
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Session["PC"] as string == "SELECTED")
            {

                UpdateUser(Session["PC_SERIAL"] as string, Session["PC_ID"] as string);

            }
            else
            {
                if (CheckAccount(inputLoginName.Text, inputPCdomain.Text, false))
                {
                    errorLiteral.Text = @"<div class='text-danger'>Bu istifadəçi artıq bazada mövcuddur.</div>";
                    return;
                }

                InsertUser();
            }



            Session["PC"] = null;
            Session["PC_ID"] = null;
            Session["PC_SERIAL"] = null;
            Session["NEW_USER_SERIAL"] = null;

            Response.Redirect("/manage/councils");
        }
    }
}