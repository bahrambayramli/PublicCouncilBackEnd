using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace PublicCouncilBackEnd.manage
{
    public partial class WebForm3 : System.Web.UI.Page
    {

        /*   
           
        1.SEO TITLE USED FOR ANCHOR LINK AND ITS USED TO SHOW NEWS TITLE IN ADMIN NEWS LIST ASPX FILE

       */
      
        #region(Image Maker)

        public void MadeImageForBanner(FileUpload fl, string imgName, string imgDirectory, int width, int height)
        {

            //SET THE SIZES
            int W = width;      //Widht
            int H = height;    //Height


            //CHECK THE EXTENSION TYPES ---------------------------------------------------
            string extension = Path.GetExtension(fl.FileName).ToLower();
            if ((extension != ".jpg") &&
                (extension != ".jpeg") &&
                (extension != ".bmp") &&
                (extension != ".png") &&
                (extension != ".gif") &&
                (extension != ".tif") &&
                (extension != ".tiff")) return;



            //SET THE IMAGE SIZE ------------------------------------------
            System.Drawing.Image orginal = System.Drawing.Image.FromStream(fl.PostedFile.InputStream);
            //int newH = (orginal.Height * W) / orginal.Width;
            //if (newH > H) { W = (W * H) / newH; newH = H; }
            //H = newH;

            //CHNAGE THE FINAL IMAGE SIZE ----------------------------------
            Bitmap finalImage = new Bitmap(orginal, W, H);
            finalImage.Save(Server.MapPath(imgDirectory + imgName), System.Drawing.Imaging.ImageFormat.Jpeg);//Jpeg formatina kecirdirem
            finalImage.Dispose();
        }

        public void MadeSubImages(HttpPostedFile postedFile, string name)
        {

            int W = 1024;      //Widht
            int H = 768;    //Height


            //change the original img size ----------------------------------
            System.Drawing.Image orginal = System.Drawing.Image.FromStream(postedFile.InputStream);
            //int newH = (orginal.Height * W) / orginal.Width;
            //if (newH > H) { W = (W * H) / newH; newH = H; }
            //H = newH;



            Bitmap NeticeImage = new Bitmap(orginal, W, H);
            NeticeImage.Save(Server.MapPath("~/images/subimages/" + name), System.Drawing.Imaging.ImageFormat.Jpeg);//Jpeg formatina kecirdirem
            NeticeImage.Dispose();
        }

        #endregion

        #region(Methods)

        #region(CRUD)
        private void GetNews(string USER_ID, string POST_ID) 
        {

            SqlDataAdapter getPost = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                          DATA_ID,
                                                                          USER_ID,
                                                                          POST_AUTHOR,
                                                                          ISACTIVE,
                                                                          ISDELETE,
                                                                          POST_AZ_TITLE,
                                                                          POST_EN_TITLE,
                                                                         
                                                                          POST_AZ_SUBTITLE,
                                                                          POST_EN_SUBTITLE,
                                                                         
                                                                          POST_AZ_TOPIC,
                                                                          POST_EN_TOPIC,
                                                                                                                                                    
                                                                          POSTMAIN_VIEW,

                                                                          POST_AZ_VIEW,
                                                                          POST_EN_VIEW,
                                                                       
                                                                          POST_CATEGORY,
                                                                          POST_SUBCATEGORY,
                                                                          POST_IMG,
                                                                          CONVERT(VARCHAR(10), CONVERT(DATETIME, POST_DATE),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, POST_DATE),108) AS 'POST_DATE',
                                                                          POST_TYPE,
                                                                          POST_SERIAL,
                                                                          POST_VIDEO,
                                                                         
                                                                          POST_SEOAZ,
                                                                          POST_SEOEN,
                                                                       
                                                                          POST_VIEWCOUNT,
                                                                          POST_SITECATEGORYAZ,
                                                                          POST_SITECATEGORYEN,
                                                                         
                                                                          POST_SITESUBCATEGORYAZ,
                                                                          POST_SITESUBCATEGORYEN
                                                                        
                                                                     FROM  PC_POSTS
                                                                                                        WHERE DATA_ID  =    @DATA_ID      AND
                                                                                                              USER_ID  =    @USER_ID      AND
                                                                                                              ISACTIVE =    @ISACTIVE     AND
                                                                                                              ISDELETE =    @ISDELETE
                                                                          "));

            getPost.SelectCommand.Parameters.AddWithValue("@USER_ID", SqlDbType.Int).Value = USER_ID;
            getPost.SelectCommand.Parameters.AddWithValue("@DATA_ID", SqlDbType.Int).Value = POST_ID;
            getPost.SelectCommand.Parameters.AddWithValue("@ISACTIVE", SqlDbType.Bit).Value = true;
            getPost.SelectCommand.Parameters.AddWithValue("@ISDELETE", SqlDbType.Bit).Value = false;

            DataTable dataTable = new DataTable();
            dataTable = SQL.SELECT(getPost);

            GetCategory();
            foreach (ListItem item in category_list.Items)
            {
                if (item.Value.ToString() == dataTable.Rows[0]["POST_CATEGORY"].ToString())
                {
                    try
                    {
                        category_list.Items.FindByValue(item.Value.ToString()).Selected = true;
                        break;
                    }
                    catch (Exception ex)
                    {
                        Log.LogCreator(Server.MapPath("/Logs/logs.txt"), ex.Message);
                    }
                }
            }

            GetSubCategory(category_list.SelectedValue);
            foreach (ListItem item in subcategory_list.Items)
            {
                if (item.Value.ToString() == dataTable.Rows[0]["POST_SUBCATEGORY"].ToString())
                {
                    try
                    {
                        subcategory_list.Items.FindByValue(item.Value.ToString()).Selected = true;
                        break;
                    }
                    catch (Exception ex)
                    {
                        Log.LogCreator(Server.MapPath("/Logs/logs.txt"), ex.Message);
                    }
                }
            }

            GetPcLists();
            foreach (ListItem item in pcSelectList.Items)
            {
                if (item.Value.ToString() == dataTable.Rows[0]["USER_ID"].ToString())
                {
                    try
                    {
                        pcSelectList.Items.FindByValue(item.Value.ToString()).Selected = true;
                        break;
                    }
                    catch (Exception ex)
                    {
                        Log.LogCreator(Server.MapPath("/Logs/logs.txt"), ex.Message);
                    }
                }
            }

            foreach (ListItem item in type_list.Items)
            {
                if (item.Text == dataTable.Rows[0]["POST_TYPE"].ToString())
                {
                    type_list.Items.FindByText(item.Text).Selected = true;
                    break;
                }
            }

            posttitle_az.Text = dataTable.Rows[0]["POST_AZ_TITLE"].ToString();
            posttitle_en.Text = dataTable.Rows[0]["POST_EN_TITLE"].ToString();

            postseo_az.Text = dataTable.Rows[0]["POST_SEOAZ"].ToString();
            postseo_en.Text = dataTable.Rows[0]["POST_SEOEN"].ToString();
         
            post_az.Text = dataTable.Rows[0]["POST_AZ_TOPIC"].ToString();
            post_en.Text = dataTable.Rows[0]["POST_EN_TOPIC"].ToString();

            if (dataTable.Rows[0]["POSTMAIN_VIEW"].Equals(true))
            {
                postMAINVIEW.Items.FindByValue("1").Selected = true;
            }
            else
            {
                postMAINVIEW.Items.FindByValue("0").Selected = true;
            }

            if (dataTable.Rows[0]["POST_AZ_VIEW"].Equals(true))
            {
                az_view.Items.FindByText("Bəli").Selected = true;
            }
            else
            {
                az_view.Items.FindByText("Xeyr").Selected = true;
            }

            if (dataTable.Rows[0]["POST_EN_VIEW"].Equals(true))
            {
                en_view.Items.FindByText("Bəli").Selected = true;
            }
            else
            {
                en_view.Items.FindByText("Xeyr").Selected = true;
            }

            

            labelTime.Text = dataTable.Rows[0]["POST_DATE"].ToString().Substring(0, dataTable.Rows[0]["POST_DATE"].ToString().Length - 3);

            mainimage.ImageUrl = $"~/images/{dataTable.Rows[0]["POST_IMG"].ToString()}";

            Session["POSTSERIAL"] = dataTable.Rows[0]["POST_SERIAL"].ToString();

            GetSubImages(Session["POSTSERIAL"] as string);

            mainvideo_frame.Text = dataTable.Rows[0]["POST_VIDEO"].ToString();

            GetVideos(Session["POSTSERIAL"] as string, dataTable.Rows[0]["USER_ID"].ToString());

            GetDocs(Session["POSTSERIAL"] as string);

        }

        private void InsertData(string userid)
        {
            string picName = SetName(".jpg");
            string serial = MakeSerial();

            SqlCommand insertdata = new SqlCommand(@"INSERT INTO PC_POSTS
                                                                            (
                                                                                USER_ID,
                                                                                POST_AZ_TITLE,
		                                                                        POST_EN_TITLE,
		                                                                      
		                                                                       
                                                                                POST_SEOAZ,
                                                                                POST_SEOEN,
                                                                               
		                                                                        POST_AZ_SUBTITLE,
		                                                                        POST_EN_SUBTITLE,
		                                                                       
		                                                                        POST_AZ_TOPIC,
		                                                                        POST_EN_TOPIC,
		                                                                       
                                                                                POSTMAIN_VIEW,

		                                                                        POST_AZ_VIEW,
		                                                                        POST_EN_VIEW,
		                                                                       
		                                                                        POST_CATEGORY,
		                                                                        POST_SUBCATEGORY,
		                                                                        POST_SITECATEGORYAZ,
                                                                                POST_SITECATEGORYEN,
                                                                              
		                                                                        POST_SITESUBCATEGORYAZ,
                                                                                POST_SITESUBCATEGORYEN,
                                                                               
		                                                                        POST_IMG,
		                                                                        POST_VIDEO,
		                                                                        POST_DATE,
		                                                                        POST_TYPE,
		                                                                        POST_SERIAL,
                                                                                POST_AUTHOR,
                                                                                POST_VIEWCOUNT,
		                                                                        ISACTIVE,
		                                                                        ISDELETE
                                                                            )
                                                                           VALUES
                                                                            (
                                                                                @USER_ID,
                                                                                @POST_AZ_TITLE,
		                                                                        @POST_EN_TITLE,
		                                                                       
                                                                                @POST_SE0AZ,
                                                                                @POST_SE0EN,
                                                                               
		                                                                        @POST_AZ_SUBTITLE,
		                                                                        @POST_EN_SUBTITLE,
		                                                                       
		                                                                        @POST_AZ_TOPIC,
		                                                                        @POST_EN_TOPIC,
		                                                                        
                                                                                @POSTMAIN_VIEW,

		                                                                        @POST_AZ_VIEW,
		                                                                        @POST_EN_VIEW,
		                                                                       
		                                                                        @POST_CATEGORY,
		                                                                        @POST_SUBCATEGORY,
		                                                                        @POST_SITECATEGORYAZ,
                                                                                @POST_SITECATEGORYEN,
                                                                                
		                                                                        @POST_SITESUBCATEGORYAZ,
                                                                                @POST_SITESUBCATEGORYEN,
                                                                               
		                                                                        @POST_IMG,
		                                                                        @POST_VIDEO,
		                                                                        @POST_DATE,
		                                                                        @POST_TYPE,
		                                                                        @POST_SERIAL,
                                                                                @POST_AUTHOR,
                                                                                @POST_VIEWCOUNT,
		                                                                        @ISACTIVE,
		                                                                        @ISDELETE
                                                                            )");

            insertdata.Parameters.Add("@USER_ID", SqlDbType.Int).Value = userid;
            insertdata.Parameters.Add("@POST_AZ_TITLE", SqlDbType.NVarChar).Value = posttitle_az.Text;
            insertdata.Parameters.Add("@POST_EN_TITLE", SqlDbType.NVarChar).Value = posttitle_en.Text;
            insertdata.Parameters.Add("@POST_SE0AZ", SqlDbType.NVarChar).Value = postseo_az.Text;
            insertdata.Parameters.Add("@POST_SE0EN", SqlDbType.NVarChar).Value = postseo_en.Text;
            insertdata.Parameters.Add("@POST_AZ_SUBTITLE", SqlDbType.NVarChar).Value = "";
            insertdata.Parameters.Add("@POST_EN_SUBTITLE", SqlDbType.NVarChar).Value = "";
            insertdata.Parameters.Add("@POST_AZ_TOPIC", SqlDbType.NVarChar).Value = post_az.Text;
            insertdata.Parameters.Add("@POST_EN_TOPIC", SqlDbType.NVarChar).Value = post_en.Text;
            insertdata.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = category_list.SelectedItem.Value;

            Session["subcategory"] = string.Empty;
            try
            {
                Session["subcategory"] = subcategory_list.SelectedValue;
            }
            catch
            {
                Session["subcategory"] = string.Empty;

            }
            insertdata.Parameters.Add("@POST_SUBCATEGORY", SqlDbType.NVarChar).Value = Session["subcategory"] as string;

            //select nav querry
            //get cetgory language text
            //and insert category for diferent languages

            SqlDataAdapter getNav = new SqlDataAdapter(new SqlCommand(@"SELECT  DATA_ID,
                                                                           		NAV_AZ,
                                                                           		NAV_EN,
                                                                           	
                                                                           		NAV_VALUE
                                                                                FROM  PC_NAV WHERE NAV_VALUE = @NAV_VALUE	AND 
                                                                           					   ISDELETE  = 'False'          AND
                                                                           					   ISACTIVE  = 'True'"));
            getNav.SelectCommand.Parameters.Add("@NAV_VALUE", SqlDbType.NVarChar).Value = category_list.SelectedValue;
            DataTable NAVDB = SQL.SELECT(getNav);


            insertdata.Parameters.Add("@POST_SITECATEGORYAZ", SqlDbType.NVarChar).Value = NAVDB.Rows[0]["NAV_AZ"].ToString();
            insertdata.Parameters.Add("@POST_SITECATEGORYEN", SqlDbType.NVarChar).Value = NAVDB.Rows[0]["NAV_EN"].ToString();
           


            SqlDataAdapter getsubNav = new SqlDataAdapter(new SqlCommand(@" SELECT               
                                                                                    DATA_ID,
                                                                                    SUBNAV_AZ,
                                                                                    SUBNAV_EN
                                                                                    FROM  PC_NAVSUB
                                                                                    WHERE 
                                                                                    NAV_VALUE = @NAV_VALUE                    AND 
                                                                                    SUBNAV_VALUE = @SUBNAV_VALUE              AND 
                                                                           			ISDELETE  = 'FALSE'                       AND
                                                                           			ISACTIVE  = 'TRUE'"));
            getsubNav.SelectCommand.Parameters.Add("@NAV_VALUE", SqlDbType.NVarChar).Value = category_list.SelectedValue;
            getsubNav.SelectCommand.Parameters.Add("@SUBNAV_VALUE", SqlDbType.NVarChar).Value = subcategory_list.SelectedValue;
            DataTable SUBNAVDB = SQL.SELECT(getsubNav);


            if (SUBNAVDB.Rows.Count > 0)
            {
                insertdata.Parameters.Add("@POST_SITESUBCATEGORYAZ", SqlDbType.NVarChar).Value = SUBNAVDB.Rows[0]["SUBNAV_AZ"].ToString();
                insertdata.Parameters.Add("@POST_SITESUBCATEGORYEN", SqlDbType.NVarChar).Value = SUBNAVDB.Rows[0]["SUBNAV_EN"].ToString();
            }
            else
            {
                insertdata.Parameters.Add("@POST_SITESUBCATEGORYAZ", SqlDbType.NVarChar).Value = "";
                insertdata.Parameters.Add("@POST_SITESUBCATEGORYEN", SqlDbType.NVarChar).Value = "";
               
            }


            insertdata.Parameters.Add("@POST_IMG", SqlDbType.NVarChar).Value = picName;
            insertdata.Parameters.Add("@POST_VIDEO", SqlDbType.NVarChar).Value = mainvideo_frame.Text;

            if(Session["USER_MEMBERSHIP_TYPE"] as string == "user")
            {

                insertdata.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = false;
            }
            else
            {
                if (postMAINVIEW.SelectedValue == "1")
                {
                    insertdata.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = true;
                }
                else
                {
                    insertdata.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = false;
                }
            }

            if (az_view.SelectedItem.Text.ToLower() == "bəli")
            {
                insertdata.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;
            }
            else
            {
                insertdata.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = false;
            }

            if (en_view.SelectedItem.Text.ToLower() == "bəli")
            {
                insertdata.Parameters.Add("@POST_EN_VIEW", SqlDbType.Bit).Value = true;
            }
            else
            {
                insertdata.Parameters.Add("@POST_EN_VIEW", SqlDbType.Bit).Value = false;
            }

            DateTime DT = DateTime.ParseExact(post_date.Text, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

            insertdata.Parameters.Add("@POST_DATE", SqlDbType.DateTime).Value = DT.ToString();
            insertdata.Parameters.Add("@POST_TYPE", SqlDbType.NVarChar).Value = type_list.SelectedItem.Text;
            insertdata.Parameters.Add("@POST_SERIAL", SqlDbType.NVarChar).Value = serial;
            insertdata.Parameters.Add("@POST_AUTHOR", SqlDbType.NVarChar).Value = GetAuthor(pcSelectList.SelectedValue);
            insertdata.Parameters.Add("@POST_VIEWCOUNT", SqlDbType.Int).Value = 0;
            insertdata.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            insertdata.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;

            SQL.COMMAND(insertdata);
            Session["POST_SUBCATEGORY"] = null;
            MadeImageForBanner(inpFile, picName,"/images/original/",900,600);
            MadeImageForBanner(inpFile, picName, "/images/", 800, 500);


            if (subImgUpload.HasFiles)
            {
                foreach (HttpPostedFile postedFile in subImgUpload.PostedFiles)
                {
                    string extension = Path.GetExtension(postedFile.FileName).ToLower();
                    if ((extension != ".jpg") &&
                        (extension != ".jpeg") &&
                        (extension != ".bmp") &&
                        (extension != ".png") &&
                        (extension != ".gif") &&
                        (extension != ".tif") &&
                        (extension != ".tiff")) return;


                    string subPicName = SetName(extension);



                    SqlCommand insertsubimgs = new SqlCommand(@"INSERT INTO PC_IMGGALERY
                                                                    (   
                                                                    USER_ID,
                                                                    POST_SERIAL,
                                                                    POST_IMG_NAME,
                                                                    ISDELETE,
                                                                    ISACTIVE
                                                                    )
                                                                    VALUES
                                                                    (
                                                                    @USER_ID,
                                                                    @POST_SERIAL,
                                                                    @POST_IMG_NAME,
                                                                    @ISDELETE,
                                                                    @ISACTIVE
                                                                    )");

                    insertsubimgs.Parameters.Add("@USER_ID", SqlDbType.Int).Value = userid;

                    insertsubimgs.Parameters.Add("@POST_SERIAL", SqlDbType.NVarChar).Value = serial;
                    insertsubimgs.Parameters.Add("@POST_IMG_NAME", SqlDbType.NVarChar).Value = subPicName;

                    insertsubimgs.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                    insertsubimgs.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;

                    SQL.COMMAND(insertsubimgs);

                    MadeSubImages(postedFile, subPicName);

                }
            }

            if (Session["POSTSERIAL"] as string != "TRUE" || Session["POSTSERIAL"] as string == "FALSE")
            {
                if (videogalery_list.Items.Count > 0)
                {
                    for (int i = 0; i < videogalery_list.Items.Count; i++)
                    {
                        InsertVideoGalery(Session["USER_ID"] as string, serial, videogalery_list.Items[i].Text, string.Empty);
                    }
                }
            }

            #region(insert documents to appeal doc table)
            if (_docsupload.HasFiles)
            {
                foreach (HttpPostedFile postedFile in _docsupload.PostedFiles)
                {
                    string uploadFile = Path.GetExtension(postedFile.FileName).ToLower();
                    if ((uploadFile != ".doc ") &&
                        (uploadFile != ".docx") &&
                        (uploadFile != ".rtf") &&
                        (uploadFile != ".xlr") &&
                        (uploadFile != ".xlsx") &&
                        (uploadFile != ".xls") &&
                        (uploadFile != ".xlsx") &&
                        (uploadFile != ".pdf"))

                    {
                        return;
                    }


                    string docname = SetName(uploadFile);
                    postedFile.SaveAs(Server.MapPath("/uploads/" + docname));

                    SqlCommand insertdocs = new SqlCommand(@"INSERT INTO PC_POSTDOCS
                                                                ( 
                                                                 ISDELETE,
                                                                 ISACTIVE,
                                                                 ISREAD,
                                                                 DOC_NAME,
                                                                 DOC_DEFAULTNAME,
                                                                 USER_ID,
                                                                 POST_SERIAL
                                                                )
                                                                 VALUES
                                                                (
                                                                 @ISDELETE,
                                                                 @ISACTIVE,
                                                                 @ISREAD,
                                                                 @DOC_NAME,
                                                                 @DOC_DEFAULTNAME,
                                                                 @USER_ID,
                                                                 @POST_SERIAL
                                                                 )");
                    insertdocs.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                    insertdocs.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                    insertdocs.Parameters.Add("@ISREAD", SqlDbType.Bit).Value = false;
                    insertdocs.Parameters.Add("@DOC_NAME", SqlDbType.NVarChar).Value = docname;
                    insertdocs.Parameters.Add("@DOC_DEFAULTNAME", SqlDbType.NVarChar).Value = postedFile.FileName;

                    insertdocs.Parameters.Add("@USER_ID", SqlDbType.Int).Value = userid;
                    insertdocs.Parameters.Add("@POST_SERIAL", SqlDbType.NVarChar).Value = serial;
                    SQL.COMMAND(insertdocs);


                }
            }
            #endregion

            serial = null;
            picName = null;
        } 

        private void UpdateData(string POST_ID, string USER_ID)
        {
            string serial = Session["POSTSERIAL"] as string;


            SqlCommand updatedata = new SqlCommand(@"UPDATE PC_POSTS SET
                                                                            
                                                                                USER_ID           =   @USER_ID,
                                                                                POST_AUTHOR       =   @POST_AUTHOR,
                                                                                POST_AZ_TITLE     =   @POST_AZ_TITLE,
		                                                                        POST_EN_TITLE     =   @POST_EN_TITLE,
		                                                                        

                                                                                POST_SEOAZ        =   @POST_SEOAZ,
		                                                                        POST_SEOEN        =   @POST_SEOEN,
		                                                                      

		                                                                        POST_AZ_SUBTITLE  =   @POST_AZ_SUBTITLE,
		                                                                        POST_EN_SUBTITLE  =   @POST_EN_SUBTITLE,
		                                                                      
		                                                                        POST_AZ_TOPIC     =   @POST_AZ_TOPIC,
		                                                                        POST_EN_TOPIC     =   @POST_EN_TOPIC,
		                                                                      
                                                                                POSTMAIN_VIEW     =   @POSTMAIN_VIEW,

		                                                                        POST_AZ_VIEW      =   @POST_AZ_VIEW,
		                                                                        POST_EN_VIEW      =   @POST_EN_VIEW,
		                                                                     
		                                                                        POST_CATEGORY     =   @POST_CATEGORY,
		                                                                        POST_SUBCATEGORY  =   @POST_SUBCATEGORY,

                                                                                POST_SITECATEGORYAZ  =   @POST_SITECATEGORYAZ,
                                                                                POST_SITECATEGORYEN  =   @POST_SITECATEGORYEN,
                                                                               

                                                                                POST_SITESUBCATEGORYAZ  =   @POST_SITESUBCATEGORYAZ,
                                                                                POST_SITESUBCATEGORYEN  =   @POST_SITESUBCATEGORYEN,
                                                                               

		                                                                        POST_IMG          =   @POST_IMG,
		                                                                        POST_DATE         =   @POST_DATE,
		                                                                        POST_TYPE         =   @POST_TYPE
		                                                                                                                  WHERE DATA_ID = @DATA_ID");

            updatedata.Parameters.Add("@DATA_ID", SqlDbType.Int).Value                  = POST_ID;
            updatedata.Parameters.Add("@USER_ID", SqlDbType.Int).Value                  = USER_ID;
            updatedata.Parameters.Add("@POST_AUTHOR", SqlDbType.NVarChar).Value         = GetAuthor(USER_ID);
            updatedata.Parameters.Add("@POST_AZ_TITLE", SqlDbType.NVarChar).Value       = posttitle_az.Text;
            updatedata.Parameters.Add("@POST_EN_TITLE", SqlDbType.NVarChar).Value       = posttitle_en.Text;
            updatedata.Parameters.Add("@POST_SEOAZ", SqlDbType.NVarChar).Value          = postseo_az.Text;
            updatedata.Parameters.Add("@POST_SEOEN", SqlDbType.NVarChar).Value          = postseo_en.Text;
            updatedata.Parameters.Add("@POST_AZ_SUBTITLE", SqlDbType.NVarChar).Value    = "";
            updatedata.Parameters.Add("@POST_EN_SUBTITLE", SqlDbType.NVarChar).Value    = "";
            updatedata.Parameters.Add("@POST_AZ_TOPIC", SqlDbType.NVarChar).Value       = post_az.Text;
            updatedata.Parameters.Add("@POST_EN_TOPIC", SqlDbType.NVarChar).Value       = post_en.Text;
            updatedata.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value       = category_list.SelectedItem.Value;

            Session["subcategory"]                                                      = string.Empty;

            try
            {
                Session["subcategory"] = subcategory_list.SelectedValue;
            }
            catch
            {
                Session["subcategory"] = string.Empty;

            }

            updatedata.Parameters.Add("@POST_SUBCATEGORY", SqlDbType.NVarChar).Value = Session["subcategory"] as string;
           

            if (inpFile.HasFile)
            {
                string picName = SetName(".jpg");
                updatedata.Parameters.Add("@POST_IMG", SqlDbType.NVarChar).Value = picName;
                MadeImageForBanner(inpFile, picName, "/images/original/", 900, 600);
                MadeImageForBanner(inpFile, picName, "/images/", 800, 500);
            }
            else
            {
                string mainImageName = mainimage.ImageUrl.ToString().Replace("/", "").Replace("images", "").Replace("~", "");

                updatedata.Parameters.Add("@POST_IMG", SqlDbType.NVarChar).Value = mainImageName;
            }

            if (Session["USER_MEMBERSHIP_TYPE"] as string == "user")
            {
                updatedata.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = false;
            }
            else
            {
                if (postMAINVIEW.SelectedValue == "1")
                {
                    updatedata.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = true;
                }
                else
                {
                    updatedata.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = false;
                }
            }

            if (az_view.SelectedItem.Text.ToLower() == "bəli")
            {
                updatedata.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;
            }
            else
            {
                updatedata.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = false;
            }
            if (en_view.SelectedItem.Text.ToLower() == "bəli")
            {
                updatedata.Parameters.Add("@POST_EN_VIEW", SqlDbType.Bit).Value = true;
            }
            else
            {
                updatedata.Parameters.Add("@POST_EN_VIEW", SqlDbType.Bit).Value = false;
            }

            DateTime DT = DateTime.ParseExact(post_date.Text, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            updatedata.Parameters.Add("@POST_DATE", SqlDbType.DateTime).Value = DT.ToString();
            updatedata.Parameters.Add("@POST_TYPE", SqlDbType.NVarChar).Value = type_list.SelectedItem.Text;

            //select nav querry
            //get cetegory language text
            //and insert category for diferent languages
            #region(GET NAVIGATION AND SUB NAVIGATION)
            SqlDataAdapter getNav = new SqlDataAdapter(new SqlCommand(@"SELECT  DATA_ID,
                                                                           		NAV_AZ,
                                                                           		NAV_EN,                                                                         	
                                                                           		NAV_VALUE
                                                                                FROM  PC_NAV WHERE NAV_VALUE = @NAV_VALUE	AND 
                                                                           					   ISDELETE  = 'False'          AND
                                                                           					   ISACTIVE  = 'True'"));
            getNav.SelectCommand.Parameters.Add("@NAV_VALUE", SqlDbType.NVarChar).Value = category_list.SelectedValue;
            DataTable NAVDB = SQL.SELECT(getNav);
            updatedata.Parameters.Add("@POST_SITECATEGORYAZ", SqlDbType.NVarChar).Value = NAVDB.Rows[0]["NAV_AZ"].ToString();
            updatedata.Parameters.Add("@POST_SITECATEGORYEN", SqlDbType.NVarChar).Value = NAVDB.Rows[0]["NAV_EN"].ToString();
            


            SqlDataAdapter getsubNav = new SqlDataAdapter(new SqlCommand(@" SELECT               
                                                                                    DATA_ID,
                                                                                    SUBNAV_AZ,
                                                                                    SUBNAV_EN
                                                                                    
                                                                                    FROM  PC_NAVSUB
                                                                                    WHERE 
                                                                                    NAV_VALUE = @NAV_VALUE                    AND 
                                                                                    SUBNAV_VALUE = @SUBNAV_VALUE              AND 
                                                                           			ISDELETE  = 'FALSE'                       AND
                                                                           			ISACTIVE  = 'TRUE'"));
            getsubNav.SelectCommand.Parameters.Add("@NAV_VALUE", SqlDbType.NVarChar).Value = category_list.SelectedValue;
            getsubNav.SelectCommand.Parameters.Add("@SUBNAV_VALUE", SqlDbType.NVarChar).Value = subcategory_list.SelectedValue;

            DataTable SUBNAVDB = SQL.SELECT(getsubNav);
            if (SUBNAVDB.Rows.Count > 0)
            {
                updatedata.Parameters.Add("@POST_SITESUBCATEGORYAZ", SqlDbType.NVarChar).Value = SUBNAVDB.Rows[0]["SUBNAV_AZ"].ToString();
                updatedata.Parameters.Add("@POST_SITESUBCATEGORYEN", SqlDbType.NVarChar).Value = SUBNAVDB.Rows[0]["SUBNAV_EN"].ToString();
               
            }
            else
            {
                updatedata.Parameters.Add("@POST_SITESUBCATEGORYAZ", SqlDbType.NVarChar).Value = "";
                updatedata.Parameters.Add("@POST_SITESUBCATEGORYEN", SqlDbType.NVarChar).Value = "";
               
            }

            #endregion

            SQL.COMMAND(updatedata);

           //---------------------------------------------------------------------------------------------------------------------------------//
            if (subImgUpload.HasFiles)
            {

                foreach (HttpPostedFile postedFile in subImgUpload.PostedFiles)
                {
                    string extension = Path.GetExtension(postedFile.FileName).ToLower();
                    if ((extension != ".jpg") &&
                        (extension != ".jpeg") &&
                        (extension != ".bmp") &&
                        (extension != ".png") &&
                        (extension != ".gif") &&
                        (extension != ".tif") &&
                        (extension != ".tiff")) return;


                    string subPicName = SetName(extension);



                    SqlCommand insertsubimgs = new SqlCommand(@"INSERT INTO PC_IMGGALERY
                                                                    (   
                                                                    USER_ID,
                                                                    POST_SERIAL,
                                                                    POST_IMG_NAME,
                                                                    ISDELETE,
                                                                    ISACTIVE
                                                                    )
                                                                    VALUES
                                                                    (
                                                                    @USER_ID,
                                                                    @POST_SERIAL,
                                                                    @POST_IMG_NAME,
                                                                    @ISDELETE,
                                                                    @ISACTIVE
                                                                    )
                                                                    ");

                    insertsubimgs.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;

                    insertsubimgs.Parameters.Add("@POST_SERIAL", SqlDbType.NVarChar).Value = serial;
                    insertsubimgs.Parameters.Add("@POST_IMG_NAME", SqlDbType.NVarChar).Value = subPicName;

                    insertsubimgs.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                    insertsubimgs.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;

                    SQL.COMMAND(insertsubimgs);

                    MadeSubImages(postedFile, subPicName);

                }

            }

            if (videogalery_list.Items.Count > 0)
            {
                for (int i = 0; i < videogalery_list.Items.Count; i++)
                {
                    SqlCommand updateVideo = new SqlCommand(@"UPDATE PC_VIDEOGALERY SET 
                                                                                POST_VIDEO_FRAME=@POST_VIDEO_FRAME ,
                                                                                POST_VIDEO_NAME=@POST_VIDEO_NAME 
                                                                                                WHERE USER_ID=@USER_ID AND 
                                                                                                      POST_SERIAL=@POST_SERIAL AND
                                                                                                      DATA_ID=@DATA_ID");

                    updateVideo.Parameters.Add("@POST_VIDEO_FRAME", SqlDbType.NVarChar).Value = videogalery_list.Items[i].Text.Replace(" ", string.Empty).Replace(".", string.Empty);
                    updateVideo.Parameters.Add("@POST_VIDEO_NAME", SqlDbType.NVarChar).Value = string.Empty;
                    updateVideo.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;
                    updateVideo.Parameters.Add("@POST_SERIAL", SqlDbType.NVarChar).Value = Session["POSTSERIAL"] as string;
                    updateVideo.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = videogalery_list.Items[i].Value;

                    SQL.COMMAND(updateVideo);
                }
            }


            #region(insert documents doc table)
            if (_docsupload.HasFiles)
            {
                foreach (HttpPostedFile postedFile in _docsupload.PostedFiles)
                {
                    string uploadFile = Path.GetExtension(postedFile.FileName).ToLower();
                    if ((uploadFile != ".doc ") &&
                        (uploadFile != ".docx") &&
                        (uploadFile != ".rtf") &&
                        (uploadFile != ".xlr") &&
                        (uploadFile != ".xlsx") &&
                        (uploadFile != ".xls") &&
                        (uploadFile != ".xlsx") &&
                        (uploadFile != ".pdf"))

                    {
                        return;
                    }


                    string docname = SetName(uploadFile);
                    postedFile.SaveAs(Server.MapPath("/uploads/" + docname));

                    SqlCommand insertdocs = new SqlCommand(@"INSERT INTO PC_POSTDOCS
                                                                ( 
                                                                 ISDELETE,
                                                                 ISACTIVE,
                                                                 ISREAD,
                                                                 DOC_NAME,
                                                                 DOC_DEFAULTNAME,
                                                                 USER_ID,
                                                                 POST_SERIAL
                                                                )
                                                                 VALUES
                                                                (
                                                                 @ISDELETE,
                                                                 @ISACTIVE,
                                                                 @ISREAD,
                                                                 @DOC_NAME,
                                                                 @DOC_DEFAULTNAME,
                                                                 @USER_ID,
                                                                 @POST_SERIAL
                                                                 )");
                    insertdocs.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                    insertdocs.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                    insertdocs.Parameters.Add("@ISREAD", SqlDbType.Bit).Value = false;
                    insertdocs.Parameters.Add("@DOC_NAME", SqlDbType.NVarChar).Value = docname;
                    insertdocs.Parameters.Add("@DOC_DEFAULTNAME", SqlDbType.NVarChar).Value = postedFile.FileName;

                    insertdocs.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;
                    insertdocs.Parameters.Add("@POST_SERIAL", SqlDbType.NVarChar).Value = serial;
                    SQL.COMMAND(insertdocs);


                }
            }
            #endregion

        }
        #endregion

        public string GetDate()
        {
            //SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand("SELECT FORMAT (SYSDATETIME() ,'dd/MM/yyyy HH:mm' ) as DataTime"));
            //return SQL.SELECT(adapter).Rows[0]["DataTime"].ToString();

            DateTime today = DateTime.Now;
            DateTime answer = today.AddDays(1).AddHours(-12);
            return answer.ToString("dd/MM/yyyy HH:mm");
        }

        public string MakeSerial()
        {
            string srl = DateTime.Now.Day.ToString() +
                                                 DateTime.Now.Month.ToString() +
                                                 DateTime.Now.Year.ToString() +
                                                 DateTime.Now.Minute.ToString() +
                                                 DateTime.Now.Second.ToString() +
                                                 DateTime.Now.Millisecond;
            return srl;
        }

        public string SetName(string fileExtension)
        {
            
            return Guid.NewGuid().ToString().Replace("-", "")                   +
                                                DateTime.Now.Day.ToString()     +
                                                DateTime.Now.Month.ToString()   +
                                                DateTime.Now.Year.ToString()    +
                                                DateTime.Now.Minute.ToString()  +
                                                DateTime.Now.Second.ToString()  +
                                                DateTime.Now.Millisecond        + fileExtension; ;
        }

        private void GetCategory()
        {
            category_list.Items.Clear();
            subcategory_list.Items.Clear();

            SqlDataAdapter getCategroy = new SqlDataAdapter(new SqlCommand(@"SELECT NAV_VALUE, NAV_AZ FROM PC_NAV WHERE ISACTIVE='TRUE' AND ISDELETE='FALSE'"));

            category_list.DataSource = SQL.SELECT(getCategroy);

            category_list.DataValueField = "NAV_VALUE";
            category_list.DataTextField = "NAV_AZ";

            category_list.DataBind();


        }

        private void GetSubCategory(string NAV_VALUE)
        {
            subcategory_list.Items.Clear();

            SqlDataAdapter getsubcategory = new SqlDataAdapter(new SqlCommand(@"SELECT SUBNAV_AZ, SUBNAV_VALUE FROM PC_NAVSUB WHERE ISACTIVE='TRUE' AND ISDELETE='FALSE' AND NAV_VALUE=@NAV_VALUE"));
            getsubcategory.SelectCommand.Parameters.Add("@NAV_VALUE", SqlDbType.NVarChar).Value = NAV_VALUE;
            subcategory_list.DataSource = SQL.SELECT(getsubcategory);

            subcategory_list.DataValueField = "SUBNAV_VALUE";
            subcategory_list.DataTextField = "SUBNAV_AZ";
            subcategory_list.DataBind();

        }

        private void GetPcLists()
        {
            SqlDataAdapter getPC = new SqlDataAdapter(new SqlCommand("SELECT USER_ID, PC_NAME FROM PC_USERS WHERE ISACTIVE = @ISACTIVE AND ISDELETE = @ISDELETE"));

            getPC.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            getPC.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;

            pcSelectList.DataSource =  SQL.SELECT(getPC);

            pcSelectList.DataValueField = "USER_ID";
            pcSelectList.DataTextField = "PC_NAME";

            pcSelectList.DataBind();
        }

        private void GetSubImages(string POST_SERIAL)
        {

            SqlDataAdapter subimages = new SqlDataAdapter(new SqlCommand(@"SELECT  ROW_NUMBER() OVER(ORDER BY DATA_ID DESC) AS '#' , 
                                                                                     DATA_ID,
                                                                                     USER_ID,
                                                                                     POST_SERIAL,
                                                                                     POST_IMG_NAME

                                                                                     FROM PC_IMGGALERY
                                                                                                   WHERE  ISACTIVE    = @ISACTIVE AND 
                                                                                                          ISDELETE    = @ISDELETE AND 
                                                                                                          POST_SERIAL = @POST_SERIAL"));

            subimages.SelectCommand.Parameters.AddWithValue("@ISACTIVE", SqlDbType.Bit).Value = true;
            subimages.SelectCommand.Parameters.AddWithValue("@ISDELETE", SqlDbType.Bit).Value = false;
            subimages.SelectCommand.Parameters.AddWithValue("@POST_SERIAL", SqlDbType.NVarChar).Value = POST_SERIAL;


            subImageList.DataSource = SQL.SELECT(subimages);
            subImageList.DataBind();
        }

        private void InsertVideoGalery(string USERID, string SERIAL, string VIDEOFRAME, string VIDEONAME)
        {
            SqlCommand insertVideos = new SqlCommand(@"INSERT INTO PC_VIDEOGALERY
                                                                    (   
		                                                         
		                                                             USER_ID,
		                                                             ISDELETE,
		                                                             ISACTIVE,
		                                                             POST_SERIAL,
		                                                             POST_VIDEO_NAME,
		                                                             POST_VIDEO_FRAME
                                                                    )
                                                                    VALUES
                                                                    (
		                                                             @USER_ID,
		                                                             @ISDELETE,
		                                                             @ISACTIVE,
		                                                             @POST_SERIAL,
		                                                             @POST_VIDEO_NAME,
		                                                             @POST_VIDEO_FRAME
                                                                    )");

            insertVideos.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USERID;

            insertVideos.Parameters.Add("@POST_SERIAL", SqlDbType.NVarChar).Value = SERIAL;
            insertVideos.Parameters.Add("@POST_VIDEO_NAME", SqlDbType.NVarChar).Value = VIDEONAME.Replace(" ", string.Empty).Replace(".", string.Empty);
            insertVideos.Parameters.Add("@POST_VIDEO_FRAME", SqlDbType.NVarChar).Value = VIDEOFRAME.Replace(" ", string.Empty);

            insertVideos.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            insertVideos.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;

            SQL.COMMAND(insertVideos);
        }

        private void GetVideos(string SERIAL, string USERID)
        {
            SqlDataAdapter getVideos = new SqlDataAdapter(new SqlCommand(@"SELECT DATA_ID, POST_VIDEO_FRAME  FROM PC_VIDEOGALERY

                                                                                            WHERE 
                                                                                                  ISACTIVE=@ISACTIVE        AND 
                                                                                                  ISDELETE=@ISDELETE        AND
                                                                                                  POST_SERIAL=@POST_SERIAL  AND 
                                                                                                  USER_ID=@USER_ID"));

            getVideos.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            getVideos.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            getVideos.SelectCommand.Parameters.Add("@POST_SERIAL", SqlDbType.NVarChar).Value = SERIAL;
            getVideos.SelectCommand.Parameters.Add("@USER_ID", SqlDbType.Int).Value = Convert.ToInt32(USERID);

            videogalery_list.DataSource = SQL.SELECT(getVideos);
            videogalery_list.DataTextField = "POST_VIDEO_FRAME";
            videogalery_list.DataValueField = "DATA_ID";
            videogalery_list.DataBind();
        }

        private void GetDocs(string POST_SERIAL)
        {
            SqlDataAdapter getdocs = new SqlDataAdapter(new SqlCommand(@"SELECT
                                                                            ROW_NUMBER() OVER(ORDER BY DOC_ID DESC) AS '#' ,
                                                                    	    DOC_ID,
                                                                            DOC_DEFAULTNAME,
                                                                            USER_ID,
                                                                            POST_SERIAL
                                                                      FROM  PC_POSTDOCS
                                                                      WHERE 
                                                                            ISDELETE=@ISDELETE       AND
                                                                            ISACTIVE=@ISACTIVE       AND
                                                                            POST_SERIAL=@POST_SERIAL"));

            getdocs.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            getdocs.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            getdocs.SelectCommand.Parameters.Add("@POST_SERIAL", SqlDbType.NVarChar).Value = POST_SERIAL;
         

            post_docs_list.DataSource = SQL.SELECT(getdocs);
            post_docs_list.DataBind();


        }

        public void DeleteDocs(int DOCID)
        {
            SqlCommand deletenews = new SqlCommand(@"UPDATE PC_POSTDOCS SET ISDELETE=@ISDELETE,ISACTIVE=@ISACTIVE WHERE DOC_ID = @DOC_ID");
            deletenews.Parameters.Add("@DOC_ID", SqlDbType.Int).Value = DOCID;
            deletenews.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = false;
            deletenews.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = true;
            SQL.COMMAND(deletenews);
            GetDocs(Session["POSTSERIAL"] as string);

        }

        private string GetAuthor(string USER_ID)
        {
            SqlDataAdapter getUserPCdomainName = new SqlDataAdapter(new SqlCommand("SELECT USER_PCDOMAIN FROM PC_USERS WHERE USER_ID=@USER_ID"));

            getUserPCdomainName.SelectCommand.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;


            return SQL.SELECT(getUserPCdomainName).Rows[0]["USER_PCDOMAIN"].ToString() ;
        }

        #endregion

        #region(Post Sub images)
        //COMPLETED
        protected void deletePostSubImage_Click(object sender, EventArgs e)
        {

            SqlCommand deleteImg = new SqlCommand(@"Update PC_IMGGALERY SET ISDELETE=@ISDELETE,ISACTIVE=@ISACTIVE WHERE DATA_ID = @DATA_ID");
            deleteImg.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = subImageList.Rows[((GridViewRow)((Control)sender).NamingContainer).RowIndex].Cells[1].Text;
            deleteImg.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = false;
            deleteImg.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = true;
            SQL.COMMAND(deleteImg);
            GetSubImages(Session["POSTSERIAL"] as string);
        }
        //COMPLETED
        protected void subImageList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            subImageList.PageIndex = e.NewPageIndex;
            GetSubImages(Session["POSTSERIAL"] as string);
        }
        //COMPLETED
        protected void subImageList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager) { return; }
            try { e.Row.Cells[1].Visible = false; } catch { }
            try { e.Row.Cells[2].Visible = false; } catch { }
            try { e.Row.Cells[3].Visible = false; } catch { }
            try { e.Row.Cells[4].Visible = false; } catch { }
        }
        #endregion

        #region(Post videos)
        //COMPLETE
        protected void videogalery_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            videogalery_text.Text = videogalery_list.SelectedItem.Text;
        }
        //COMPLETE
        protected void videogaleryitemdelete_Click(object sender, EventArgs e)
        {
            videogalery_list.Items.Remove(videogalery_list.SelectedItem);
        }
        //COMPLETE
        protected void videogalery_add_Click(object sender, EventArgs e)
        {
            if (Session["POST"] as string == "SELECTED")
            {
                videogalery_list.Items.Add(videogalery_text.Text);
                InsertVideoGalery(Session["USER_ID"] as string, Session["POSTSERIAL"] as string, videogalery_text.Text, string.Empty);
            }
            else
            {
                videogalery_list.Items.Add(videogalery_text.Text);
            }
        }
        //COMPLETE
        protected void videogalery_edit_Click(object sender, EventArgs e)
        {
            videogalery_list.SelectedItem.Text = videogalery_text.Text;
        }
        #endregion

        #region(Post Docs)

        protected void post_docs_list_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager) { return; }
            try { e.Row.Cells[1].Visible = false; } catch { }
            try { e.Row.Cells[2].Visible = true; } catch { }
            try { e.Row.Cells[3].Visible = false; } catch { }
            try { e.Row.Cells[4].Visible = false; } catch { }
        }

        protected void post_docs_list_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            post_docs_list.PageIndex = e.NewPageIndex;
            GetDocs(Session["POSTSERIAL"] as string);
        }

        protected void deletePostDocs_Click(object sender, EventArgs e)
        {
            SqlCommand deleteImg = new SqlCommand(@"Update PC_POSTDOCS SET ISDELETE=@ISDELETE,ISACTIVE=@ISACTIVE WHERE DOC_ID = @DOC_ID");
            deleteImg.Parameters.Add("@DOC_ID", SqlDbType.Int).Value = post_docs_list.Rows[((GridViewRow)((Control)sender).NamingContainer).RowIndex].Cells[1].Text;
            deleteImg.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = false;
            deleteImg.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = true;
            SQL.COMMAND(deleteImg);
            GetDocs(Session["POSTSERIAL"] as string);
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                try { GetCategory(); } catch  { }

                try{ GetSubCategory(category_list.SelectedValue); }  catch  { }

                try { GetPcLists(); } catch { }

                if (Session["POST"] as string == "SELECTED")
                {
                    try { GetNews(Session["POST_USER_ID"] as string,Session["POSTID"] as string); } catch { }

                    try
                    {
                        postConfirm.Text = "Dəyiş";
                        postConfirm.CssClass = "btn btn-warning";
                    }
                    catch (Exception ex)
                    {
                        Log.LogCreator(Server.MapPath("/Logs/logs.txt"), ex.Message);
                    }

                } else{ try{ labelTime.Text = GetDate();} catch { } }

                if(Session["USER_MEMBERSHIP_TYPE"]as string == "user")
                {
                    PCLIST_MAINVIEW_BLOCK.Visible   = false;
                    PCLIST_PANEL.Visible            = false;
                    MAINVIEW_PANEL.Visible          = false;
                    GetPcLists();
                    foreach (ListItem item in pcSelectList.Items)
                    {
                        if (item.Value.ToString() == Session["USER_ID"] as string)
                        {
                            try
                            {
                                pcSelectList.Items.FindByValue(item.Value.ToString()).Selected = true;
                            }
                            catch (Exception ex)
                            {
                                Log.LogCreator(Server.MapPath("/Logs/logs.txt"), ex.Message);
                            }
                        }
                    }
                }
            }
        }

        protected void category_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSubCategory(category_list.SelectedValue);
        }

        protected void postConfirm_Click(object sender, EventArgs e)
        {
            if (Session["POST"] as string == "SELECTED")
            {
                try
                {
                    UpdateData(Session["POSTID"] as string, pcSelectList.SelectedValue);

                }
                catch (Exception ex)
                {
                    Log.LogCreator(Server.MapPath("/Logs/logs.txt"), ex.Message);
                }
            }
            else
            {
                try
                {
                    InsertData(pcSelectList.SelectedValue);
                }
                catch (Exception ex)
                {
                    Log.LogCreator(Server.MapPath("/Logs/logs.txt"), ex.Message);
                }
            }

            Session["POST"] = null;
            Session["POSTID"] = null;
            Session["POST_USER_ID"] = null;
            Response.Redirect("/manage/posts");
        }

        protected void back_Click(object sender, EventArgs e)
        {

            Session["POST"] = null; ;
            Session["POSTID"] = null;
            Session["POST_USER_ID"] = null;
            Response.Redirect("/manage/posts");
        }
    }
}