using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace PublicCouncilBackEnd
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        #region(Helper functions)
        public void MadeImage(FileUpload fl, string imgName, int width, int height)
        {

            //gave the sizes
            int W = width;      //Widht
            int H = height;    //Height


            //check the image extrension type  ---------------------------------------------------
            string extension = Path.GetExtension(fl.FileName).ToLower();
            if ((extension != ".jpg") &&
                (extension != ".jpeg") &&
                (extension != ".bmp") &&
                (extension != ".png") &&
                (extension != ".gif") &&
                (extension != ".tif") &&
                (extension != ".tiff")) return;



            //  ------------------------------------------
            System.Drawing.Image orginal = System.Drawing.Image.FromStream(fl.PostedFile.InputStream);
            //int newH = (orginal.Height * W) / orginal.Width;
            //if (newH > H) { W = (W * H) / newH; newH = H; }
            //H = newH;

            //chnaged the converted image size ----------------------------------
            Bitmap finalImage = new Bitmap(orginal, W, H);
            finalImage.Save(Server.MapPath("/images/logos/" + imgName), System.Drawing.Imaging.ImageFormat.Jpeg);//Jpeg formatina kecirdirem
            finalImage.Dispose();
        }

        public void SaveEmptyPCImage(string imageName, string imageText, string SaveDirectory)
        {

            System.Drawing.Image bitmap = (System.Drawing.Image)Bitmap.FromFile(Server.MapPath("/images/Untitled.png"));
            // set image     
            //draw the image object using a Graphics object    
            Graphics graphicsImage = Graphics.FromImage(bitmap);

            //Set the alignment based on the coordinates       
            StringFormat stringformat = new StringFormat();
            stringformat.Alignment = StringAlignment.Center;
            stringformat.LineAlignment = StringAlignment.Center;

            //Set the font color/format/size etc..      

            Color StringColor = System.Drawing.ColorTranslator.FromHtml("#933eea");//direct color adding    
            string Str_TextOnImage = imageText;//Your Text On Image    


            graphicsImage.DrawString(Str_TextOnImage, new Font("arial", 16, FontStyle.Regular), new SolidBrush(StringColor), new Point(230, 130), stringformat);


            bitmap.Save(Server.MapPath(SaveDirectory + imageName), ImageFormat.Jpeg);
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
            Session["USER_REGISTER_SERIAL"] = Helper.MakeSerial();

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
            DateTime createdDate = DateTime.ParseExact(GetDate(), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            insertUser.Parameters.Add("@CREATED_DATE", SqlDbType.Date).Value                            = createdDate.ToString(); ;
            insertUser.Parameters.Add("@PC_CATEGORY", SqlDbType.NVarChar).Value                         = categorySelect.SelectedValue;

            SQL.COMMAND(insertUser);
            #endregion

            SqlDataAdapter getRowCount = new SqlDataAdapter(new SqlCommand(@"SELECT USER_ID FROM PC_SITELOGOS WHERE LOGO_SERIAL = @USER_SERIAL"));

            getRowCount.SelectCommand.Parameters.Add("@USER_SERIAL", SqlDbType.NVarChar).Value          = Session["USER_REGISTER_SERIAL"] as string;

            DataTable DT = SQL.SELECT(getRowCount);

            InsertLogo(Session["USER_REGISTER_SERIAL"] as string, DT.Rows[0]["USER_ID"].ToString());
        }

        private void InsertLogo(string USER_SERIAL, string USER_ID)
        {
            string logoName = string.Empty;
            SqlCommand insertLogo = new SqlCommand(@"INSERT INTO PC_SITELOGOS
                                                                                    (
	                                                                                 ISDELETE,
                                                                                     ISACTIVE,
                                                                                     LOGO_TITLE,
                                                                                     LOGO_IMG,
                                                                                     LOGO_SERIAL,
                                                                                     USER_ID
	                                                                                )
                                                                              VALUES
                                                                                    (
	                                                                            	 @ISDELETE,
                                                                                     @ISACTIVE,
                                                                                     @LOGO_TITLE,
                                                                                     @LOGO_IMG,
                                                                                     @LOGO_SERIAL,
                                                                                     @USER_ID

	                                                                            	)
                                                                                    ");

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


                logoName = Helper.SetName(extension);

                insertLogo.Parameters.Add("@LOGO_TITLE", SqlDbType.NVarChar).Value = logoUpload.FileName;

                MadeImage(logoUpload, logoName, 460, 280);

            }
            else
            {
                logoName = Helper.SetName(".jpg");
                insertLogo.Parameters.Add("@LOGO_TITLE", SqlDbType.NVarChar).Value = inputPCname.Text;
                SaveEmptyPCImage(logoName, inputPCname.Text, "/images/logos/");
            }

            insertLogo.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value             = false;
            insertLogo.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value             = true;
            insertLogo.Parameters.Add("@LOGO_SERIAL", SqlDbType.NVarChar).Value     = USER_SERIAL;
            insertLogo.Parameters.Add("@USER_ID", SqlDbType.Int).Value              = USER_ID;
            insertLogo.Parameters.Add("@LOGO_IMG", SqlDbType.NVarChar).Value        = logoName;

            SQL.COMMAND(insertLogo);

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

            Session["USER_REGISTER_SERIAL"] = null;

            Response.Redirect("/login");
        }
    }
}