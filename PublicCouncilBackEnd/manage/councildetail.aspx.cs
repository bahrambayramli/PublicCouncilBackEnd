using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace PublicCouncilBackEnd.manage
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
            finalImage.Save(Server.MapPath("/Images/logos/" + imgName), System.Drawing.Imaging.ImageFormat.Jpeg);//Jpeg formatina kecirdirem
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
                                                                               ISACTIVE                ,
                                                                               USER_MEMBERSHIP         ,
                                                                               USER_MEMBERSHIP_TYPE    ,
                                                                               USER_LOGIN              ,
                                                                               USER_PASSWORD           ,
                                                                               USER_SERIAL             ,
                                                                               USER_PCDOMAIN           ,
                                                                               USER_NAME               ,
                                                                               USER_SURNAME            ,
                                                                               USER_MOBILE             ,
                                                                               PC_NAME                 ,
                                                                               PC_TELEPHONE            ,
                                                                               PC_EMAIL                ,
                                                                               PC_WEBADDRESS           ,
                                                                               PC_COUNTRY              ,
                                                                               PC_CITY                 ,
                                                                               CREATED_DATE            ,
                                                                               PC_CATEGORY             ,
                                                                               PC_ABOUT_AZ             ,
                                                                               PC_ABOUT_EN             ,
                                                                               PC_ORDER_NUMBER         ,
                                                                               PC_NAME_EN              ,
                                                                               USER_NAME_EN            ,
                                                                               USER_SURNAME_EN         ,
                                                                               PC_ACTIVITY_PERIOD

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

                if (item.Text.ToString().ToLower() == pc.Rows[0]["USER_MEMBERSHIP_TYPE"].ToString().ToLower())
                {
                    try { inputMembershipType.Items.FindByValue(item.Value.ToString()).Selected = true; } catch { }
                    break;
                }
            }

            foreach (ListItem item in inputCity.Items)
            {
                if (item.Text.ToString().ToLower() == pc.Rows[0]["PC_CITY"].ToString().ToLower())
                {
                    try{ inputCity.Items.FindByValue(item.Value.ToString()).Selected = true; } catch{ }
                    break;
                }
            }

            foreach (ListItem item in categorySelect.Items)
            {

                if (item.Value.ToString().ToLower() == pc.Rows[0]["PC_CATEGORY"].ToString().ToLower())
                {
                    try { categorySelect.Items.FindByValue(item.Value.ToString()).Selected = true; } catch { }
                    break;
                }
            }

            inputOrderNumber.Text       = pc.Rows[0]["PC_ORDER_NUMBER"].ToString();
            
            inputLoginName.Text         = pc.Rows[0]["USER_LOGIN"].ToString().ToLower();

            inputPCdomain.Text          = pc.Rows[0]["USER_PCDOMAIN"].ToString().ToLower();

            inputName.Text              = pc.Rows[0]["USER_NAME"].ToString().ToLower();

            inputSurname.Text           = pc.Rows[0]["USER_SURNAME"].ToString().ToLower();

            inputLoginName.Text         = pc.Rows[0]["USER_LOGIN"].ToString().ToLower();

            inputEmail.Text             = pc.Rows[0]["PC_EMAIL"].ToString().ToLower();

            inputMobile.Text            = pc.Rows[0]["USER_MOBILE"].ToString().ToLower();

            inputTelephone.Text         = pc.Rows[0]["PC_TELEPHONE"].ToString().ToLower();

            inputWeb.Text               = pc.Rows[0]["PC_WEBADDRESS"].ToString().ToLower();

            inputPCname.Text            = pc.Rows[0]["PC_NAME"].ToString();

            inputAboutUs_Az.Text        = pc.Rows[0]["PC_ABOUT_AZ"].ToString();

            inputAboutUs_En.Text        = pc.Rows[0]["PC_ABOUT_EN"].ToString();

            inputPCname_En.Text         = pc.Rows[0]["PC_NAME_EN"].ToString();

            inputName_En.Text           = pc.Rows[0]["USER_NAME_EN"].ToString();

            inputSurname_En.Text        = pc.Rows[0]["USER_SURNAME_EN"].ToString();

            inputActivityPeriod.Text    = pc.Rows[0]["PC_ACTIVITY_PERIOD"].ToString();

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
                                                         PC_ABOUT_AZ,
                                                         PC_ABOUT_EN,
                                                         CREATED_DATE,
                                                         PC_CATEGORY,
                                                         PC_ORDER_NUMBER,
                                                         PC_NAME_EN,
                                                         USER_NAME_EN,
                                                         USER_SURNAME_EN,
                                                         PC_ACTIVITY_PERIOD

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
                                                         @PC_ABOUT_AZ,
                                                         @PC_ABOUT_EN,
                                                         @CREATED_DATE,
                                                         @PC_CATEGORY,
                                                         @PC_ORDER_NUMBER,
                                                         @PC_NAME_EN,
                                                         @USER_NAME_EN,
                                                         @USER_SURNAME_EN,
                                                         @PC_ACTIVITY_PERIOD
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

            if (Session["USER_MEMBERSHIP_TYPE"] as string == "admin")
            {
                if (string.IsNullOrEmpty(inputOrderNumber.Text))
                {
                    SqlDataAdapter getLastRowOrderNum = new SqlDataAdapter(new SqlCommand("SELECT TOP (1) PC_ORDER_NUMBER FROM PC_USERS WHERE ISACTIVE='TRUE' AND ISDELETE='FALSE' ORDER BY USER_ID DESC"));
                    DataTable lastRow = SQL.SELECT(getLastRowOrderNum);
                    insertUser.Parameters.Add("@PC_ORDER_NUMBER", SqlDbType.Int).Value = int.Parse(lastRow.Rows[0]["PC_ORDER_NUMBER"].ToString()) + 1;
                    lastRow = null;
                }
                else
                {
                    insertUser.Parameters.Add("@PC_ORDER_NUMBER", SqlDbType.Int).Value = inputOrderNumber.Text;
                }

            }
            else
            {
                SqlDataAdapter getLastRowOrderNum = new SqlDataAdapter(new SqlCommand("SELECT TOP (1) PC_ORDER_NUMBER FROM PC_USERS WHERE ISACTIVE='TRUE' AND ISDELETE='FALSE' ORDER BY USER_ID DESC"));
                DataTable lastRow = SQL.SELECT(getLastRowOrderNum);
                insertUser.Parameters.Add("@PC_ORDER_NUMBER", SqlDbType.Int).Value = int.Parse(lastRow.Rows[0]["PC_ORDER_NUMBER"].ToString()) + 1;
                lastRow = null;
            }

            insertUser.Parameters.Add("@USER_MEMBERSHIP_TYPE", SqlDbType.NVarChar).Value                = inputMembershipType.SelectedValue;
            insertUser.Parameters.Add("@USER_LOGIN", SqlDbType.NVarChar).Value                          = inputLoginName.Text;
            insertUser.Parameters.Add("@USER_PASSWORD", SqlDbType.NVarChar).Value                       = Crypto.MD5crypt(inputPassword.Text);
            insertUser.Parameters.Add("@USER_SERIAL", SqlDbType.NVarChar).Value                         = Session["NEW_USER_SERIAL"] as string;
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
            insertUser.Parameters.Add("@PC_ABOUT_AZ", SqlDbType.NVarChar).Value                         = inputAboutUs_Az.Text;
            insertUser.Parameters.Add("@PC_ABOUT_EN", SqlDbType.NVarChar).Value                         = inputAboutUs_En.Text;

            DateTime createdDate = DateTime.ParseExact(GetDate(), "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            insertUser.Parameters.Add("@CREATED_DATE", SqlDbType.Date).Value                            = createdDate.ToString(); ;
            insertUser.Parameters.Add("@PC_CATEGORY", SqlDbType.NVarChar).Value                         = categorySelect.SelectedValue;

            insertUser.Parameters.Add("@PC_NAME_EN", SqlDbType.NVarChar).Value                          = inputPCname_En.Text;
            insertUser.Parameters.Add("@USER_NAME_EN", SqlDbType.NVarChar).Value                        = inputName_En.Text;
            insertUser.Parameters.Add("@USER_SURNAME_EN", SqlDbType.NVarChar).Value                     = inputSurname_En.Text;
            insertUser.Parameters.Add("@PC_ACTIVITY_PERIOD", SqlDbType.NVarChar).Value                  = inputActivityPeriod.Text;

            SQL.COMMAND(insertUser);
            #endregion


            #region(Insert logo)
            SqlDataAdapter getLastPcId = new SqlDataAdapter(new SqlCommand("SELECT TOP (1) USER_ID FROM PC_USERS WHERE ISACTIVE='TRUE' AND ISDELETE='FALSE' ORDER BY USER_ID DESC"));
          
            InsertLogo(Session["NEW_USER_SERIAL"] as string, SQL.SELECT(getLastPcId).Rows[0]["USER_ID"].ToString());
            #endregion

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
                                                         PC_CATEGORY           = @PC_CATEGORY           ,
	                                                     PC_ABOUT_AZ              = @PC_ABOUT_AZ              ,
                                                         PC_ORDER_NUMBER       = @PC_ORDER_NUMBER       ,
                                                         PC_NAME_EN            = @PC_NAME_EN            ,
                                                         USER_NAME_EN          = @USER_NAME_EN          ,
                                                         USER_SURNAME_EN       = @USER_SURNAME_EN


                                                         WHERE USER_ID         = @USER_ID
                                                        
	                                                	   ");
                string pass = Crypto.MD5crypt(inputPassword.Text);
                updateUser.Parameters.Add("@USER_PASSWORD", SqlDbType.NVarChar).Value = pass ;
            }
            else
            {
                updateUser = new SqlCommand(@"UPDATE PC_USERS SET 
                                                        
		                                                
                                                         ISACTIVE              = @ISACTIVE              , 
                                                         USER_MEMBERSHIP       = @USER_MEMBERSHIP       ,
                                                         USER_MEMBERSHIP_TYPE  = @USER_MEMBERSHIP_TYPE  ,
                                                         USER_LOGIN            = @USER_LOGIN            ,
                                                         USER_PCDOMAIN         = @USER_PCDOMAIN         ,
                                                         USER_NAME             = @USER_NAME             ,
                                                         USER_SURNAME          = @USER_SURNAME          ,
                                                         USER_MOBILE           = @USER_MOBILE           ,
                                                         PC_NAME               = @PC_NAME               ,
                                                         PC_TELEPHONE          = @PC_TELEPHONE          ,
                                                         PC_EMAIL              = @PC_EMAIL              ,
                                                         PC_WEBADDRESS         = @PC_WEBADDRESS         ,                                                      
                                                         PC_CITY               = @PC_CITY               ,                                                       
                                                         PC_CATEGORY           = @PC_CATEGORY           ,
	                                                     PC_ABOUT_AZ           = @PC_ABOUT_AZ           ,
	                                                     PC_ABOUT_EN           = @PC_ABOUT_EN           ,
                                                         PC_ORDER_NUMBER       = @PC_ORDER_NUMBER       ,
                                                         PC_NAME_EN            = @PC_NAME_EN            ,
                                                         USER_NAME_EN          = @USER_NAME_EN          ,
                                                         USER_SURNAME_EN       = @USER_SURNAME_EN       ,
                                                         PC_ACTIVITY_PERIOD    = @PC_ACTIVITY_PERIOD       

                                                         WHERE USER_ID = @USER_ID
                                                        
	                                                	   ");
            }


            updateUser.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID ;

            if (inputISACTIVE.SelectedItem.Text=="Bəli")
            {
                updateUser.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true ;
            }
            else
            {
                updateUser.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = false;
            }

            updateUser.Parameters.Add("@USER_MEMBERSHIP", SqlDbType.NVarChar).Value         = "pc";
            updateUser.Parameters.Add("@PC_ORDER_NUMBER", SqlDbType.Int).Value              = inputOrderNumber.Text;
            updateUser.Parameters.Add("@USER_MEMBERSHIP_TYPE", SqlDbType.NVarChar).Value    = inputMembershipType.SelectedValue;
            updateUser.Parameters.Add("@USER_LOGIN", SqlDbType.NVarChar).Value              = inputLoginName.Text;
            updateUser.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value           = inputPCdomain.Text;
            updateUser.Parameters.Add("@USER_NAME", SqlDbType.NVarChar).Value               = inputName.Text;
            updateUser.Parameters.Add("@USER_SURNAME", SqlDbType.NVarChar).Value            = inputSurname.Text;
            updateUser.Parameters.Add("@PC_NAME", SqlDbType.NVarChar).Value                 = inputPCname.Text;
            updateUser.Parameters.Add("@PC_TELEPHONE", SqlDbType.NVarChar).Value            = inputTelephone.Text;
            updateUser.Parameters.Add("@USER_MOBILE", SqlDbType.NVarChar).Value             = inputMobile.Text;
            updateUser.Parameters.Add("@PC_EMAIL", SqlDbType.NVarChar).Value                = inputEmail.Text;
            updateUser.Parameters.Add("@PC_WEBADDRESS", SqlDbType.NVarChar).Value           = inputWeb.Text;
            updateUser.Parameters.Add("@PC_CITY", SqlDbType.NVarChar).Value                 = inputCity.SelectedItem.Text;
            updateUser.Parameters.Add("@PC_CATEGORY", SqlDbType.NVarChar).Value             = categorySelect.SelectedValue;
            updateUser.Parameters.Add("@PC_ABOUT_AZ", SqlDbType.NVarChar).Value             = inputAboutUs_Az.Text;
            updateUser.Parameters.Add("@PC_ABOUT_EN", SqlDbType.NVarChar).Value             = inputAboutUs_En.Text;

            updateUser.Parameters.Add("@PC_NAME_EN", SqlDbType.NVarChar).Value              = inputPCname_En.Text;
            updateUser.Parameters.Add("@USER_NAME_EN", SqlDbType.NVarChar).Value            = inputName_En.Text;
            updateUser.Parameters.Add("@USER_SURNAME_EN", SqlDbType.NVarChar).Value         = inputSurname_En.Text;
            updateUser.Parameters.Add("@PC_ACTIVITY_PERIOD", SqlDbType.NVarChar).Value      = inputActivityPeriod.Text;

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

            
                    logoName = Helper.SetName(extension);

                    insertLogo.Parameters.Add("@LOGO_TITLE", SqlDbType.NVarChar).Value      = logoFile.FileName;

                    MadeImage(logoFile, logoName, 460, 280);
                
            }
            else
            {
                logoName = Helper.SetName(".jpg");
                insertLogo.Parameters.Add("@LOGO_TITLE", SqlDbType.NVarChar).Value      = inputPCname.Text;
                SaveEmptyPCImage(logoName, inputPCname.Text,"/images/logos/");
            }

            insertLogo.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value             = false;
            insertLogo.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value             = true;
            insertLogo.Parameters.Add("@LOGO_SERIAL", SqlDbType.NVarChar).Value     = USER_SERIAL;
            insertLogo.Parameters.Add("@USER_ID", SqlDbType.Int).Value              = USER_ID;
            insertLogo.Parameters.Add("@LOGO_IMG", SqlDbType.NVarChar).Value        = logoName;

            SQL.COMMAND(insertLogo);
           

        }

        private void UpdateLogo(string USER_SERIAL, string USER_ID)
        {
            //Update
            //1.Logo text
            //2.Logo image
            //if the logo file input has files need to add the new image to /Uploads/logos folder and update in sql 
            //if the logo file input has not file need to update only logo text
           
           
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

                SqlCommand updateLogo = new SqlCommand(@"UPDATE PC_SITELOGOS 
                                                            SET  
						                                    LOGO_TITLE = @LOGO_TITLE,
						                                    LOGO_IMG   = @LOGO_IMG
                                                           
					                                        WHERE 
                                                                  USER_ID               = @USER_ID         AND
                                                                  LOGO_SERIAL           = @USER_SERIAL
                                                                  ");

              
                updateLogo.Parameters.Add("@LOGO_IMG", SqlDbType.NVarChar).Value = logoName;
                updateLogo.Parameters.Add("@LOGO_TITLE", SqlDbType.NVarChar).Value = logoFile.FileName;
                
                
                updateLogo.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;
                updateLogo.Parameters.Add("@USER_SERIAL", SqlDbType.NVarChar).Value = USER_SERIAL;


                SQL.COMMAND(updateLogo);

                MadeImage(logoFile, logoName, 460, 280);
            }
            
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if(Session["PC"] as string == "SELECTED")
                {
                    if (Session["USER_MEMBERSHIP_TYPE"] as string != "admin")
                    {
                        PC_ORDER_BLOCK.Visible                = false;
                        PC_ISACTIVE_MEMBERSHIP_BLOCK.Visible  = false;
                        PC_LOGIN_BLOCK.Visible                = false;
                        PC_PASSWORD_BLOCK.CssClass            = "col-12";

                    }

                    try
                    {
                        GetPCOUNCIL(Session["PC_ID"] as string);
                    }
                    catch (Exception ex)
                    {
                        Log.LogCreator(HttpContext.Current.Server.MapPath("/Logs/logs.txt"), ex.Message);
                        string exmm = ex.Message;
                        Console.WriteLine(exmm);
                    }

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
                    errorLiteral.Text = @"<div class='text-danger text-center h2'>Bu istifadəçi artıq bazada mövcuddur.</div>";
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

        protected void back_Click(object sender, EventArgs e)
        {
            Session["PC"] = null;
            Session["PC_ID"] = null;
            Session["PC_SERIAL"] = null;
            Session["NEW_USER_SERIAL"] = null;

            Response.Redirect("/manage/councils");
        }
    }
}