using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace PublicCouncilBackEnd
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        #region(HELPER FUNCTIONS)
        public string SetName(string FILE_EXTENSION)
        {

            return Guid.NewGuid().ToString().Replace("-", "") +
                                                DateTime.Now.Day.ToString() +
                                                DateTime.Now.Month.ToString() +
                                                DateTime.Now.Year.ToString() +
                                                DateTime.Now.Minute.ToString() +
                                                DateTime.Now.Second.ToString() +
                                                DateTime.Now.Millisecond + FILE_EXTENSION;
        }
        private void SendEmail(string SENDER_MAIL, string SENDER_PASSWORD, string RECEVIER_MAIL, string PC_NAME, string EMAIL_MESSAGE)
        {
            MailMessage mail = new MailMessage();

            //set the addresses 
            mail.From                           = new MailAddress(SENDER_MAIL); //IMPORTANT: This must be same as your smtp authentication address.
            mail.To.Add(RECEVIER_MAIL);

            //set the content 
            mail.Subject                        = "Yeni İctimai Şura";
            mail.Body                           = $"'{PC_NAME}' {EMAIL_MESSAGE}";
            //send the message 
            SmtpClient smtp                     = new SmtpClient("mail5018.site4now.net");

            //IMPORANT:  Your smtp login email MUST be same as your FROM address. 
            NetworkCredential Credentials       = new NetworkCredential(SENDER_MAIL, SENDER_PASSWORD);
            smtp.UseDefaultCredentials          = false;
            smtp.Credentials                    = Credentials;
            smtp.Port                           = 8889;    //alternative port number is 8889
            smtp.EnableSsl                      = false;
            smtp.Send(mail);
        }

        private bool CheckImageValidation(string IMAGE_EXT)
        {
            bool isValid = true;


            if (IMAGE_EXT != ".jpg" && IMAGE_EXT != ".jpeg" && IMAGE_EXT != ".bmp" && IMAGE_EXT != ".png" && IMAGE_EXT != ".gif" && IMAGE_EXT != ".tif" && IMAGE_EXT != ".tiff")
            {
                isValid = false;
            }

            return isValid;
            
        }

        public void MadeImage(FileUpload FL, string IMAGE_NAME, int WIDTH, int HEIGHT)
        {
            //check the image extrension type
            string extension                        = Path.GetExtension(FL.FileName).ToLower();
            System.Drawing.Image orginal            = System.Drawing.Image.FromStream(FL.PostedFile.InputStream);
            //chnaged the converted image size
            Bitmap finalImage                       = new Bitmap(orginal, WIDTH, HEIGHT);
            finalImage.Save(Server.MapPath("/images/logos/" + IMAGE_NAME), System.Drawing.Imaging.ImageFormat.Jpeg);//Convert to JPEG format
            finalImage.Dispose();
        }

        public void SaveEmptyPCImage(string IMAGE_NAME, string IMAGE_TEXT, string SAVE_DIRECOTORY)
        {
            System.Drawing.Image bitmap = (System.Drawing.Image)Bitmap.FromFile(Server.MapPath("/images/Untitled.png"));
            //set image     
            //draw the image object using a Graphics object    
            Graphics graphicsImage = Graphics.FromImage(bitmap);

            //Set the alignment based on the coordinates       
            StringFormat stringformat = new StringFormat();
            stringformat.Alignment = StringAlignment.Center;
            stringformat.LineAlignment = StringAlignment.Center;

            //Set the font color/format/size etc..      

            Color StringColor = System.Drawing.ColorTranslator.FromHtml("#933eea");//direct color adding    
            string Str_TextOnImage = IMAGE_TEXT;//Your Text On Image    

            graphicsImage.DrawString(Str_TextOnImage, new Font("arial", 16, FontStyle.Regular), new SolidBrush(StringColor), new Point(230, 130), stringformat);

            bitmap.Save(Server.MapPath(SAVE_DIRECOTORY + IMAGE_NAME), ImageFormat.Jpeg);
            bitmap.Dispose();
        }
        #endregion

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

            checkAccount.SelectCommand.Parameters.Add("@USER_LOGIN", SqlDbType.NVarChar).Value          = login;
            checkAccount.SelectCommand.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value       = subdomain;
            checkAccount.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value                 = ISDELETE;

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
            return DateTime.Now.AddDays(1).AddHours(-12).ToString("dd/MM/yyyy HH:mm");
        }

        private void InsertLogo(string USER_SERIAL, string USER_ID)
        {
            string LOGO_NAME        = string.Empty;
            SqlCommand insertLogo   = new SqlCommand(@"INSERT INTO PC_SITELOGOS
                                                                                    (
	                                                                                 ISDELETE           ,
                                                                                     ISACTIVE           ,
                                                                                     LOGO_TITLE         ,
                                                                                     LOGO_IMG           ,
                                                                                     LOGO_SERIAL        ,
                                                                                     USER_ID
	                                                                                )
                                                                              VALUES
                                                                                    (
	                                                                            	 @ISDELETE          ,
                                                                                     @ISACTIVE          ,
                                                                                     @LOGO_TITLE        ,
                                                                                     @LOGO_IMG          ,
                                                                                     @LOGO_SERIAL       ,
                                                                                     @USER_ID
	                                                                            	)
                                                                                    ");

            if (logoUpload.HasFile)
            {
                string extension                                                        = Path.GetExtension(logoUpload.FileName).ToLower();
                if (CheckImageValidation(extension))
                {
                    LOGO_NAME = SetName(extension);

                    insertLogo.Parameters.Add("@LOGO_TITLE", SqlDbType.NVarChar).Value  = logoUpload.FileName;

                    MadeImage(logoUpload, LOGO_NAME, 460, 280);
                }
            }
            else
            {
                LOGO_NAME                                                               = SetName(".jpg");
                insertLogo.Parameters.Add("@LOGO_TITLE", SqlDbType.NVarChar).Value      = inputPCname.Text;
                SaveEmptyPCImage(LOGO_NAME, inputPCname.Text, "/images/logos/");
            }

            insertLogo.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value                 = false;
            insertLogo.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value                 = true;
            insertLogo.Parameters.Add("@LOGO_SERIAL", SqlDbType.NVarChar).Value         = USER_SERIAL;
            insertLogo.Parameters.Add("@USER_ID", SqlDbType.Int).Value                  = USER_ID;
            insertLogo.Parameters.Add("@LOGO_IMG", SqlDbType.NVarChar).Value            = LOGO_NAME;

            SQL.COMMAND(insertLogo);

        }

        private void InsertUser()
        {
            Session["USER_REGISTER_SERIAL"] = Helper.MakeSerial();

            #region(REGISTER INTO SQL BASE)

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

            insertUser.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value                                 = false;
            insertUser.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value                                 = false;
            insertUser.Parameters.Add("@ISONLINE", SqlDbType.Bit).Value                                 = false;
            insertUser.Parameters.Add("@USER_MEMBERSHIP", SqlDbType.NVarChar).Value                     = "pc";
            insertUser.Parameters.Add("@USER_MEMBERSHIP_TYPE", SqlDbType.NVarChar).Value                = "user";
            insertUser.Parameters.Add("@USER_LOGIN", SqlDbType.NVarChar).Value                          = inputLoginName.Text;
            insertUser.Parameters.Add("@USER_PASSWORD", SqlDbType.NVarChar).Value                       = Crypto.MD5crypt(inputPassword.Text);
            insertUser.Parameters.Add("@USER_SERIAL", SqlDbType.NVarChar).Value                         = Session["USER_REGISTER_SERIAL"] as string;
            insertUser.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value                       = inputPCdomain.Text;
            insertUser.Parameters.Add("@USER_NAME", SqlDbType.NVarChar).Value                           = inputName.Text;
            insertUser.Parameters.Add("@USER_SURNAME", SqlDbType.NVarChar).Value                        = inputSurname.Text;
            insertUser.Parameters.Add("@PC_NAME", SqlDbType.NVarChar).Value                             = inputPCname.Text;
            insertUser.Parameters.Add("@PC_TELEPHONE", SqlDbType.NVarChar).Value                        = inputTelephone.Text;
            insertUser.Parameters.Add("@USER_MOBILE", SqlDbType.NVarChar).Value                         = inputMobile.Text;
            insertUser.Parameters.Add("@PC_EMAIL", SqlDbType.NVarChar).Value                            = inputEmail.Text;
            insertUser.Parameters.Add("@PC_WEBADDRESS", SqlDbType.NVarChar).Value                       = inputWeb.Text;
            insertUser.Parameters.Add("@PC_COUNTRY", SqlDbType.NVarChar).Value                          = "Azərbaycan";
            insertUser.Parameters.Add("@PC_CITY", SqlDbType.NVarChar).Value                             = inputCity.SelectedItem.Text;
            DateTime createdDate = DateTime.ParseExact(GetDate()                                        ,"dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            insertUser.Parameters.Add("@CREATED_DATE", SqlDbType.Date).Value                            = createdDate.ToString(); ;
            insertUser.Parameters.Add("@PC_CATEGORY", SqlDbType.NVarChar).Value                         = categorySelect.SelectedValue;

            SQL.COMMAND(insertUser);
            #endregion

            SqlDataAdapter getRowCount = new SqlDataAdapter(new SqlCommand(@"SELECT USER_ID FROM PC_SITELOGOS WHERE LOGO_SERIAL = @USER_SERIAL"));

            getRowCount.SelectCommand.Parameters.Add("@USER_SERIAL", SqlDbType.NVarChar).Value          = Session["USER_REGISTER_SERIAL"] as string;

            DataTable DT = SQL.SELECT(getRowCount);

            InsertLogo(Session["USER_REGISTER_SERIAL"] as string, DT.Rows[0]["USER_ID"].ToString());
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //CheckAccount
            if (CheckAccount(inputLoginName.Text, inputPCdomain.Text, false))
            {
                errorLiteral.Text = @"<div class='text-danger'>Bu istifadəçi artıq bazada mövcuddur.</div>";
                return;
            }

            //Send email to admin
            try
            {
                SendEmail(
                    ConfigurationManager.AppSettings["SmarterEmail"].ToString()     ,
                    ConfigurationManager.AppSettings["SmarterPassword"].ToString()  ,
                    "behrambayramli999@gmail.com",
                    inputPCname.Text,
                    "adlı ictimai şura qeydiyyatdan keçmidir."
                    );
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main master >> register.aspx >> SendEmail method >> Admin, Log:{ex.Message}");
            }

            //Send email to Public Council
            try
            {
                SendEmail(
                        ConfigurationManager.AppSettings["SmarterEmail"].ToString(),
                        ConfigurationManager.AppSettings["SmarterPassword"].ToString(),
                        inputEmail.Text,
                        inputPCname.Text,
                        "qeydiyyatdan keçdiyiniz üçün təşəkkür edirik."
                        );
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main master >> register.aspx >> SendEmail method >> PC, Log:{ex.Message}");
            }

            //InsertUser
            try
            {
                InsertUser();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main master >> register.aspx >> InsertUser method, Log:{ex.Message}");
            }

            Session["USER_REGISTER_SERIAL"] = null;

            Response.Redirect("/login");
        }
    }
}
