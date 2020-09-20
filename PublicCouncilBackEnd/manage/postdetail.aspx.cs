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
using System.Diagnostics;

namespace PublicCouncilBackEnd.manage
{
    public partial class WebForm3 : System.Web.UI.Page
    {

        /*   
           
        1.SEO TITLE USED FOR ANCHOR LINK AND ITS USED TO SHOW NEWS TITLE IN ADMIN NEWS LIST ASPX FILE

       */


        #region(Image Maker)

        public void MadeImageForBanner(FileUpload fl, string imgName)
        {

            //SET THE SIZES
            int W = 900;      //Widht
            int H = 600;    //Height


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
            Bitmap NeticeImage = new Bitmap(orginal, W, H);
            NeticeImage.Save(Server.MapPath("/Images/" + imgName), System.Drawing.Imaging.ImageFormat.Jpeg);//Jpeg formatina kecirdirem
            NeticeImage.Dispose();
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
            NeticeImage.Save(Server.MapPath("~/Images/subimages/" + name), System.Drawing.Imaging.ImageFormat.Jpeg);//Jpeg formatina kecirdirem
            NeticeImage.Dispose();
        }

        #endregion

        #region(Methods)
        private void GetNews(string NEWS_ID)
        {

            SqlDataAdapter getnews = new SqlDataAdapter(new SqlCommand(@"SELECT
	                                                                            DATA_ID,
                                                                                USER_ID,

                                                                                NEWS_posttitle_az,
                                                                                NEWS_posttitle_en,
                                                                                NEWS_posttitle_ru,
                                                                                NEWS_TR_TITLE,
                                                                                NEWS_FR_TITLE,

                                                                                NEWS_SEOAZ,
                                                                                NEWS_SEOEN,
                                                                                NEWS_SEORU,
                                                                                NEWS_SEOTR,
                                                                                NEWS_SEOFR,

                                                                                NEWS_AZ_TOPIC,
                                                                                NEWS_EN_TOPIC,
                                                                                NEWS_RU_TOPIC,
                                                                                NEWS_TR_TOPIC,
                                                                                NEWS_FR_TOPIC,

                                                                                NEWS_AZ_VIEW,
                                                                                NEWS_EN_VIEW,
                                                                                NEWS_RU_VIEW,
                                                                                NEWS_TR_VIEW,
                                                                                NEWS_FR_VIEW,

                                                                                NEWS_CATEGORY,
                                                                                NEWS_SUBCATEGORY,

                                                                                NEWS_IMG,
                                                                                NEWS_VIDEO,
                                                                                CONVERT(VARCHAR(10), CONVERT(DATETIME, NEWS_DATE),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, NEWS_DATE),108) AS 'NEWS_DATE',
                                                                                NEWS_TYPE,
                                                                                NEWS_SERIAL,
                                                                                ISACTIVE,
                                                                                ISDELETE

                                                                                FROM DATA_NEWS
                                                                                                        WHERE DATA_ID  =    @DATA_ID      AND
                                                                                                              ISACTIVE =    @ISACTIVE     AND
                                                                                                              ISDELETE =    @ISDELETE
                                                                          "));

            getnews.SelectCommand.Parameters.AddWithValue("@DATA_ID", SqlDbType.Int).Value = NEWS_ID;
            getnews.SelectCommand.Parameters.AddWithValue("@ISACTIVE", SqlDbType.Bit).Value = true;
            getnews.SelectCommand.Parameters.AddWithValue("@ISDELETE", SqlDbType.Bit).Value = false;

            DataTable dataTable = new DataTable();
            dataTable = SQL.SELECT(getnews);



            GetCategory();

            foreach (ListItem item in category_list.Items)
            {



                if (item.Value.ToString() == dataTable.Rows[0]["NEWS_CATEGORY"].ToString())
                {
                    try
                    {
                        category_list.Items.FindByValue(item.Value.ToString()).Selected = true;
                    }
                    catch (Exception ex)
                    {

                        Debug.WriteLine(ex.Message);
                    }
                }
            }

            GetSubCategory(category_list.SelectedValue);

            foreach (ListItem item in subcategory_list.Items)
            {
                if (item.Value.ToString() == dataTable.Rows[0]["NEWS_SUBCATEGORY"].ToString())
                {
                    try
                    {
                        subcategory_list.Items.FindByValue(item.Value.ToString()).Selected = true;
                    }
                    catch (Exception ex)
                    {

                        Debug.WriteLine(ex.Message);
                    }
                }
            }

            type_list.SelectedItem.Text = dataTable.Rows[0]["NEWS_TYPE"].ToString();

            posttitle_az.Text = dataTable.Rows[0]["NEWS_posttitle_az"].ToString();
            posttitle_en.Text = dataTable.Rows[0]["POST_posttitle_en"].ToString();
           // posttitle_ru.Text = dataTable.Rows[0]["POST_posttitle_ru"].ToString();
           

            postseo_az.Text = dataTable.Rows[0]["NEWS_SEOAZ"].ToString();
            postseo_en.Text = dataTable.Rows[0]["POST_SEOEN"].ToString();
           // seoposttitle_ru.Text = dataTable.Rows[0]["POST_SEORU"].ToString();
          

            post_az.Text = dataTable.Rows[0]["POST_AZ_TOPIC"].ToString();
            post_en.Text = dataTable.Rows[0]["POST_EN_TOPIC"].ToString();
           // CKEditorRU.Text = dataTable.Rows[0]["POST_RU_TOPIC"].ToString();
           


            if (dataTable.Rows[0]["NEWS_AZ_VIEW"].Equals(true))
            {
                az_view.Items.FindByText("Bəli").Selected = true;
            }
            else
            {
                az_view.Items.FindByText("Xeyr").Selected = true;
            }

            if (dataTable.Rows[0]["NEWS_EN_VIEW"].Equals(true))
            {
                en_view.Items.FindByText("Bəli").Selected = true;
            }
            else
            {
                en_view.Items.FindByText("Xeyr").Selected = true;
            }



            labelTime.Text = dataTable.Rows[0]["NEWS_DATE"].ToString().Substring(0, dataTable.Rows[0]["NEWS_DATE"].ToString().Length - 3);

            mainimage.ImageUrl = $"~/images/{dataTable.Rows[0]["NEWS_IMG"].ToString()}";

            Session["NEWSSERIAL"] = dataTable.Rows[0]["NEWS_SERIAL"].ToString();

            GetSubImages(Session["NEWSSERIAL"] as string);

            mainvideo_frame.Text = dataTable.Rows[0]["NEWS_VIDEO"].ToString();

            GetVideos(Session["NEWSSERIAL"] as string, dataTable.Rows[0]["USER_ID"].ToString());

            GetDocs(Session["NEWSSERIAL"] as string);

        }

        private void InsertData(string userid)
        {
            string picName = SetName(".jpg");
            string serial = MakeSerial();

            SqlCommand insertdata = new SqlCommand(@"INSERT INTO DATA_NEWS
                                                                            (
                                                                                USER_ID,
                                                                                NEWS_posttitle_az,
		                                                                        NEWS_posttitle_en,
		                                                                        NEWS_posttitle_ru,
		                                                                        NEWS_TR_TITLE,
		                                                                        NEWS_FR_TITLE,
                                                                                NEWS_SEOAZ,
                                                                                NEWS_SEOEN,
                                                                                NEWS_SEORU,
                                                                                NEWS_SEOTR,
                                                                                NEWS_SEOFR,
		                                                                        NEWS_AZ_SUBTITLE,
		                                                                        NEWS_EN_SUBTITLE,
		                                                                        NEWS_RU_SUBTITLE,
		                                                                        NEWS_TR_SUBTITLE,
		                                                                        NEWS_FR_SUBTITLE,
		                                                                        NEWS_AZ_TOPIC,
		                                                                        NEWS_EN_TOPIC,
		                                                                        NEWS_RU_TOPIC,
		                                                                        NEWS_TR_TOPIC,
		                                                                        NEWS_FR_TOPIC,
		                                                                        NEWS_AZ_VIEW,
		                                                                        NEWS_EN_VIEW,
		                                                                        NEWS_RU_VIEW,
		                                                                        NEWS_TR_VIEW,
		                                                                        NEWS_FR_VIEW,
		                                                                        NEWS_CATEGORY,
		                                                                        NEWS_SUBCATEGORY,
		                                                                        NEWS_SITECATEGORYAZ,
                                                                                NEWS_SITECATEGORYEN,
                                                                                NEWS_SITECATEGORYRU,
                                                                                NEWS_SITECATEGORYTR,
                                                                                NEWS_SITECATEGORYFR,
		                                                                        NEWS_SITESUBCATEGORYAZ,
                                                                                NEWS_SITESUBCATEGORYEN,
                                                                                NEWS_SITESUBCATEGORYRU,
                                                                                NEWS_SITESUBCATEGORYTR,
                                                                                NEWS_SITESUBCATEGORYFR,
		                                                                        NEWS_IMG,
		                                                                        NEWS_VIDEO,
		                                                                        NEWS_DATE,
		                                                                        NEWS_TYPE,
		                                                                        NEWS_SERIAL,
                                                                                NEWS_VIEWCOUNT,
		                                                                        ISACTIVE,
		                                                                        ISDELETE
                                                                            )
                                                                           VALUES
                                                                            (
                                                                                @USER_ID,
                                                                                @NEWS_posttitle_az,
		                                                                        @NEWS_posttitle_en,
		                                                                        @NEWS_posttitle_ru,
		                                                                        @NEWS_TR_TITLE,
		                                                                        @NEWS_FR_TITLE,
                                                                                @NEWS_SE0AZ,
                                                                                @NEWS_SE0EN,
                                                                                @NEWS_SE0RU,
                                                                                @NEWS_SE0TR,
                                                                                @NEWS_SE0FR,
		                                                                        @NEWS_AZ_SUBTITLE,
		                                                                        @NEWS_EN_SUBTITLE,
		                                                                        @NEWS_RU_SUBTITLE,
		                                                                        @NEWS_TR_SUBTITLE,
		                                                                        @NEWS_FR_SUBTITLE,
		                                                                        @NEWS_AZ_TOPIC,
		                                                                        @NEWS_EN_TOPIC,
		                                                                        @NEWS_RU_TOPIC,
		                                                                        @NEWS_TR_TOPIC,
		                                                                        @NEWS_FR_TOPIC,
		                                                                        @NEWS_AZ_VIEW,
		                                                                        @NEWS_EN_VIEW,
		                                                                        @NEWS_RU_VIEW,
		                                                                        @NEWS_TR_VIEW,
		                                                                        @NEWS_FR_VIEW,
		                                                                        @NEWS_CATEGORY,
		                                                                        @NEWS_SUBCATEGORY,
		                                                                        @NEWS_SITECATEGORYAZ,
                                                                                @NEWS_SITECATEGORYEN,
                                                                                @NEWS_SITECATEGORYRU,
                                                                                @NEWS_SITECATEGORYTR,
                                                                                @NEWS_SITECATEGORYFR,
		                                                                        @NEWS_SITESUBCATEGORYAZ,
                                                                                @NEWS_SITESUBCATEGORYEN,
                                                                                @NEWS_SITESUBCATEGORYRU,
                                                                                @NEWS_SITESUBCATEGORYTR,
                                                                                @NEWS_SITESUBCATEGORYFR,
		                                                                        @NEWS_IMG,
		                                                                        @NEWS_VIDEO,
		                                                                        @NEWS_DATE,
		                                                                        @NEWS_TYPE,
		                                                                        @NEWS_SERIAL,
                                                                                @NEWS_VIEWCOUNT,
		                                                                        @ISACTIVE,
		                                                                        @ISDELETE
                                                                            )");

            insertdata.Parameters.Add("@USER_ID", SqlDbType.Int).Value = userid;

            insertdata.Parameters.Add("@NEWS_posttitle_az", SqlDbType.NVarChar).Value = posttitle_az.Text;
            insertdata.Parameters.Add("@NEWS_posttitle_en", SqlDbType.NVarChar).Value = posttitle_en.Text;
           

            insertdata.Parameters.Add("@NEWS_SE0AZ", SqlDbType.NVarChar).Value = postseo_az.Text;
            insertdata.Parameters.Add("@NEWS_SE0EN", SqlDbType.NVarChar).Value = postseo_en.Text;
           

            insertdata.Parameters.Add("@NEWS_AZ_SUBTITLE", SqlDbType.NVarChar).Value = "";
            insertdata.Parameters.Add("@NEWS_EN_SUBTITLE", SqlDbType.NVarChar).Value = "";
           

            insertdata.Parameters.Add("@NEWS_AZ_TOPIC", SqlDbType.NVarChar).Value = post_az.Text;
            insertdata.Parameters.Add("@NEWS_EN_TOPIC", SqlDbType.NVarChar).Value = post_en.Text;
           

            insertdata.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category_list.SelectedItem.Value;


            Session["subcategory"] = string.Empty;
            try
            {
                Session["subcategory"] = subcategory_list.SelectedValue;
            }
            catch
            {
                Session["subcategory"] = string.Empty;

            }
            insertdata.Parameters.Add("@NEWS_SUBCATEGORY", SqlDbType.NVarChar).Value = Session["subcategory"] as string;

            //select nav querry
            //get cetgory language text
            //and insert category for diferent languages

            SqlDataAdapter getNav = new SqlDataAdapter(new SqlCommand(@"SELECT  DATA_ID,
                                                                           		NAV_AZ,
                                                                           		NAV_EN,
                                                                           		NAV_RU,
                                                                           		NAV_TR,
                                                                           		NAV_FR,
                                                                           		NAV_VALUE
                                                                                FROM  DATA_NAV WHERE NAV_VALUE = @NAV_VALUE	AND 
                                                                           					   ISDELETE  = 'False'          AND
                                                                           					   ISACTIVE  = 'True'"));

            getNav.SelectCommand.Parameters.Add("@NAV_VALUE", SqlDbType.NVarChar).Value = category_list.SelectedValue;

            DataTable NAVDB = SQL.SELECT(getNav);


            insertdata.Parameters.Add("@NEWS_SITECATEGORYAZ", SqlDbType.NVarChar).Value = NAVDB.Rows[0]["NAV_AZ"].ToString();
            insertdata.Parameters.Add("@NEWS_SITECATEGORYEN", SqlDbType.NVarChar).Value = NAVDB.Rows[0]["NAV_EN"].ToString();
            insertdata.Parameters.Add("@NEWS_SITECATEGORYRU", SqlDbType.NVarChar).Value = NAVDB.Rows[0]["NAV_RU"].ToString();
            insertdata.Parameters.Add("@NEWS_SITECATEGORYTR", SqlDbType.NVarChar).Value = NAVDB.Rows[0]["NAV_TR"].ToString();
            insertdata.Parameters.Add("@NEWS_SITECATEGORYFR", SqlDbType.NVarChar).Value = NAVDB.Rows[0]["NAV_FR"].ToString();


            SqlDataAdapter getsubNav = new SqlDataAdapter(new SqlCommand(@" SELECT               
                                                                                    DATA_ID,
                                                                                    SUBNAV_AZ,
                                                                                    SUBNAV_EN,
                                                                                    SUBNAV_RU,
                                                                                    SUBNAV_TR,
                                                                                    SUBNAV_FR
                                                                                    FROM  DATA_NAVSUB
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
                insertdata.Parameters.Add("@NEWS_SITESUBCATEGORYAZ", SqlDbType.NVarChar).Value = SUBNAVDB.Rows[0]["SUBNAV_AZ"].ToString();
                insertdata.Parameters.Add("@NEWS_SITESUBCATEGORYEN", SqlDbType.NVarChar).Value = SUBNAVDB.Rows[0]["SUBNAV_EN"].ToString();
                insertdata.Parameters.Add("@NEWS_SITESUBCATEGORYRU", SqlDbType.NVarChar).Value = SUBNAVDB.Rows[0]["SUBNAV_RU"].ToString();
                insertdata.Parameters.Add("@NEWS_SITESUBCATEGORYTR", SqlDbType.NVarChar).Value = SUBNAVDB.Rows[0]["SUBNAV_TR"].ToString();
                insertdata.Parameters.Add("@NEWS_SITESUBCATEGORYFR", SqlDbType.NVarChar).Value = SUBNAVDB.Rows[0]["SUBNAV_FR"].ToString();
            }
            else
            {
                insertdata.Parameters.Add("@NEWS_SITESUBCATEGORYAZ", SqlDbType.NVarChar).Value = "";
                insertdata.Parameters.Add("@NEWS_SITESUBCATEGORYEN", SqlDbType.NVarChar).Value = "";
                insertdata.Parameters.Add("@NEWS_SITESUBCATEGORYRU", SqlDbType.NVarChar).Value = "";
                insertdata.Parameters.Add("@NEWS_SITESUBCATEGORYTR", SqlDbType.NVarChar).Value = "";
                insertdata.Parameters.Add("@NEWS_SITESUBCATEGORYFR", SqlDbType.NVarChar).Value = "";
            }


            //---------------------------------------------------------------------------------------------------------------------------------//



            insertdata.Parameters.Add("@NEWS_IMG", SqlDbType.NVarChar).Value = picName;
            insertdata.Parameters.Add("@NEWS_VIDEO", SqlDbType.NVarChar).Value = mainvideo_frame.Text;

            if (az_view.SelectedItem.Text.ToLower() == "bəli")
            {
                insertdata.Parameters.Add("@NEWS_AZ_VIEW", SqlDbType.Bit).Value = true;
            }
            else
            {
                insertdata.Parameters.Add("@NEWS_AZ_VIEW", SqlDbType.Bit).Value = false;
            }

            if (en_view.SelectedItem.Text.ToLower() == "bəli")
            {
                insertdata.Parameters.Add("@NEWS_EN_VIEW", SqlDbType.Bit).Value = true;
            }
            else
            {
                insertdata.Parameters.Add("@NEWS_EN_VIEW", SqlDbType.Bit).Value = false;
            }

        

            DateTime DT = DateTime.ParseExact(post_date.Text, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

            insertdata.Parameters.Add("@NEWS_DATE", SqlDbType.DateTime).Value = DT.ToString();
            insertdata.Parameters.Add("@NEWS_TYPE", SqlDbType.NVarChar).Value = type_list.SelectedItem.Text;
            insertdata.Parameters.Add("@NEWS_SERIAL", SqlDbType.NVarChar).Value = serial;
            insertdata.Parameters.Add("@NEWS_VIEWCOUNT", SqlDbType.Int).Value = 0;
            insertdata.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            insertdata.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;

            SQL.COMMAND(insertdata);
            Session["NEWS_SUBCATEGORY"] = null;
            MadeImageForBanner(inpFile, picName);


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



                    SqlCommand insertsubimgs = new SqlCommand(@"INSERT INTO DATA_IMGGALERY
                                                                    (   
                                                                    USER_ID,
                                                                    NEWS_SERIAL,
                                                                    NEWS_IMG_NAME,
                                                                    ISDELETE,
                                                                    ISACTIVE
                                                                    )
                                                                    VALUES
                                                                    (
                                                                    @USER_ID,
                                                                    @NEWS_SERIAL,
                                                                    @NEWS_IMG_NAME,
                                                                    @ISDELETE,
                                                                    @ISACTIVE
                                                                    )");

                    insertsubimgs.Parameters.Add("@USER_ID", SqlDbType.Bit).Value = userid;

                    insertsubimgs.Parameters.Add("@NEWS_SERIAL", SqlDbType.NVarChar).Value = serial;
                    insertsubimgs.Parameters.Add("@NEWS_IMG_NAME", SqlDbType.NVarChar).Value = subPicName;

                    insertsubimgs.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                    insertsubimgs.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;

                    SQL.COMMAND(insertsubimgs);

                    MadeSubImages(postedFile, subPicName);

                }

            }

            if (Session["NEWSSERIAL"] as string != "TRUE" || Session["NEWSSERIAL"] as string == "FALSE")
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
                    postedFile.SaveAs(Server.MapPath("/Uploads/" + docname));

                    SqlCommand insertdocs = new SqlCommand(@"INSERT INTO DATA_NEWSDOCS
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


        }

        private void UpdateData(string NEWSID, string userid)
        {
            string serial = Session["NEWSSERIAL"] as string;


            SqlCommand updatedata = new SqlCommand(@"UPDATE DATA_NEWS SET
                                                                            
                                                                                NEWS_posttitle_az     =   @NEWS_posttitle_az,
		                                                                        NEWS_posttitle_en     =   @NEWS_posttitle_en,
		                                                                        NEWS_posttitle_ru     =   @NEWS_posttitle_ru,
		                                                                        NEWS_TR_TITLE     =   @NEWS_TR_TITLE,
		                                                                        NEWS_FR_TITLE     =   @NEWS_FR_TITLE,

                                                                                NEWS_SEOAZ        =   @NEWS_SEOAZ,
		                                                                        NEWS_SEOEN        =   @NEWS_SEOEN,
		                                                                        NEWS_SEORU        =   @NEWS_SEORU,
		                                                                        NEWS_SEOTR        =   @NEWS_SEOTR,
		                                                                        NEWS_SEOFR        =   @NEWS_SEOFR,

		                                                                        NEWS_AZ_SUBTITLE  =   @NEWS_AZ_SUBTITLE,
		                                                                        NEWS_EN_SUBTITLE  =   @NEWS_EN_SUBTITLE,
		                                                                        NEWS_RU_SUBTITLE  =   @NEWS_RU_SUBTITLE,
		                                                                        NEWS_TR_SUBTITLE  =   @NEWS_TR_SUBTITLE,
		                                                                        NEWS_FR_SUBTITLE  =   @NEWS_FR_SUBTITLE,
		                                                                        NEWS_AZ_TOPIC     =   @NEWS_AZ_TOPIC,
		                                                                        NEWS_EN_TOPIC     =   @NEWS_EN_TOPIC,
		                                                                        NEWS_RU_TOPIC     =   @NEWS_RU_TOPIC,
		                                                                        NEWS_TR_TOPIC     =   @NEWS_TR_TOPIC,
		                                                                        NEWS_FR_TOPIC     =   @NEWS_FR_TOPIC,
		                                                                        NEWS_AZ_VIEW      =   @NEWS_AZ_VIEW,
		                                                                        NEWS_EN_VIEW      =   @NEWS_EN_VIEW,
		                                                                        NEWS_RU_VIEW      =   @NEWS_RU_VIEW,
		                                                                        NEWS_TR_VIEW      =   @NEWS_TR_VIEW,
		                                                                        NEWS_FR_VIEW      =   @NEWS_FR_VIEW,
		                                                                        NEWS_CATEGORY     =   @NEWS_CATEGORY,
		                                                                        NEWS_SUBCATEGORY  =   @NEWS_SUBCATEGORY,

                                                                                NEWS_SITECATEGORYAZ  =   @NEWS_SITECATEGORYAZ,
                                                                                NEWS_SITECATEGORYEN  =   @NEWS_SITECATEGORYEN,
                                                                                NEWS_SITECATEGORYRU  =   @NEWS_SITECATEGORYRU,
                                                                                NEWS_SITECATEGORYTR  =   @NEWS_SITECATEGORYTR,
                                                                                NEWS_SITECATEGORYFR  =   @NEWS_SITECATEGORYFR,

                                                                                NEWS_SITESUBCATEGORYAZ  =   @NEWS_SITESUBCATEGORYAZ,
                                                                                NEWS_SITESUBCATEGORYEN  =   @NEWS_SITESUBCATEGORYEN,
                                                                                NEWS_SITESUBCATEGORYRU  =   @NEWS_SITESUBCATEGORYRU,
                                                                                NEWS_SITESUBCATEGORYTR  =   @NEWS_SITESUBCATEGORYTR,
                                                                                NEWS_SITESUBCATEGORYFR  =   @NEWS_SITESUBCATEGORYFR,

		                                                                        NEWS_IMG          =   @NEWS_IMG,
		                                                                        NEWS_DATE         =   @NEWS_DATE,
		                                                                        NEWS_TYPE         =   @NEWS_TYPE
		                                                                                                                  WHERE DATA_ID = @DATA_ID");

            updatedata.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = NEWSID;

            updatedata.Parameters.Add("@NEWS_posttitle_az", SqlDbType.NVarChar).Value = posttitle_az.Text;
            updatedata.Parameters.Add("@NEWS_posttitle_en", SqlDbType.NVarChar).Value = posttitle_en.Text;



            updatedata.Parameters.Add("@NEWS_SEOAZ", SqlDbType.NVarChar).Value = postseo_az.Text;
            updatedata.Parameters.Add("@NEWS_SEOEN", SqlDbType.NVarChar).Value = postseo_en.Text;


            updatedata.Parameters.Add("@NEWS_AZ_SUBTITLE", SqlDbType.NVarChar).Value = "";
            updatedata.Parameters.Add("@NEWS_EN_SUBTITLE", SqlDbType.NVarChar).Value = "";
            updatedata.Parameters.Add("@NEWS_RU_SUBTITLE", SqlDbType.NVarChar).Value = "";
            updatedata.Parameters.Add("@NEWS_TR_SUBTITLE", SqlDbType.NVarChar).Value = "";
            updatedata.Parameters.Add("@NEWS_FR_SUBTITLE", SqlDbType.NVarChar).Value = "";

            updatedata.Parameters.Add("@NEWS_AZ_TOPIC", SqlDbType.NVarChar).Value = post_az.Text;
            updatedata.Parameters.Add("@NEWS_EN_TOPIC", SqlDbType.NVarChar).Value = post_en.Text;
           

            updatedata.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category_list.SelectedItem.Value;
            Session["subcategory"] = string.Empty;
            try
            {
                Session["subcategory"] = subcategory_list.SelectedValue;
            }
            catch
            {
                Session["subcategory"] = string.Empty;

            }
            updatedata.Parameters.Add("@NEWS_SUBCATEGORY", SqlDbType.NVarChar).Value = Session["subcategory"] as string;


            if (inpFile.HasFile)
            {
                string picName = SetName(".jpg");
                updatedata.Parameters.Add("@NEWS_IMG", SqlDbType.NVarChar).Value = picName;
                MadeImageForBanner(inpFile, picName);
            }
            else
            {
                string mainImageName = mainimage.ImageUrl.ToString().Replace("/", "").Replace("images", "").Replace("~", "");

                updatedata.Parameters.Add("@NEWS_IMG", SqlDbType.NVarChar).Value = mainImageName;
            }

            if (az_view.SelectedItem.Text.ToLower() == "bəli")
            {
                updatedata.Parameters.Add("@NEWS_AZ_VIEW", SqlDbType.Bit).Value = true;
            }
            else
            {
                updatedata.Parameters.Add("@NEWS_AZ_VIEW", SqlDbType.Bit).Value = false;
            }

            if (en_view.SelectedItem.Text.ToLower() == "bəli")
            {
                updatedata.Parameters.Add("@NEWS_EN_VIEW", SqlDbType.Bit).Value = true;
            }
            else
            {
                updatedata.Parameters.Add("@NEWS_EN_VIEW", SqlDbType.Bit).Value = false;
            }

         

            DateTime DT = DateTime.ParseExact(post_date.Text, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

            updatedata.Parameters.Add("@NEWS_DATE", SqlDbType.DateTime).Value = DT.ToString();

            updatedata.Parameters.Add("@NEWS_TYPE", SqlDbType.NVarChar).Value = type_list.SelectedItem.Text;

            //select nav querry
            //get cetegory language text
            //and insert category for diferent languages

            SqlDataAdapter getNav = new SqlDataAdapter(new SqlCommand(@"SELECT  DATA_ID,
                                                                           		NAV_AZ,
                                                                           		NAV_EN,
                                                                           		NAV_RU,
                                                                           		NAV_TR,
                                                                           		NAV_FR,
                                                                           		NAV_VALUE
                                                                                FROM  DATA_NAV WHERE NAV_VALUE = @NAV_VALUE	AND 
                                                                           					   ISDELETE  = 'False'          AND
                                                                           					   ISACTIVE  = 'True'"));

            getNav.SelectCommand.Parameters.Add("@NAV_VALUE", SqlDbType.NVarChar).Value = category_list.SelectedValue;

            DataTable NAVDB = SQL.SELECT(getNav);


            updatedata.Parameters.Add("@NEWS_SITECATEGORYAZ", SqlDbType.NVarChar).Value = NAVDB.Rows[0]["NAV_AZ"].ToString();
            updatedata.Parameters.Add("@NEWS_SITECATEGORYEN", SqlDbType.NVarChar).Value = NAVDB.Rows[0]["NAV_EN"].ToString();
            updatedata.Parameters.Add("@NEWS_SITECATEGORYRU", SqlDbType.NVarChar).Value = NAVDB.Rows[0]["NAV_RU"].ToString();
            updatedata.Parameters.Add("@NEWS_SITECATEGORYTR", SqlDbType.NVarChar).Value = NAVDB.Rows[0]["NAV_TR"].ToString();
            updatedata.Parameters.Add("@NEWS_SITECATEGORYFR", SqlDbType.NVarChar).Value = NAVDB.Rows[0]["NAV_FR"].ToString();


            SqlDataAdapter getsubNav = new SqlDataAdapter(new SqlCommand(@" SELECT               
                                                                                    DATA_ID,
                                                                                    SUBNAV_AZ,
                                                                                    SUBNAV_EN,
                                                                                    SUBNAV_RU,
                                                                                    SUBNAV_TR,
                                                                                    SUBNAV_FR
                                                                                    FROM  DATA_NAVSUB
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
                updatedata.Parameters.Add("@NEWS_SITESUBCATEGORYAZ", SqlDbType.NVarChar).Value = SUBNAVDB.Rows[0]["SUBNAV_AZ"].ToString();
                updatedata.Parameters.Add("@NEWS_SITESUBCATEGORYEN", SqlDbType.NVarChar).Value = SUBNAVDB.Rows[0]["SUBNAV_EN"].ToString();
                updatedata.Parameters.Add("@NEWS_SITESUBCATEGORYRU", SqlDbType.NVarChar).Value = SUBNAVDB.Rows[0]["SUBNAV_RU"].ToString();
                updatedata.Parameters.Add("@NEWS_SITESUBCATEGORYTR", SqlDbType.NVarChar).Value = SUBNAVDB.Rows[0]["SUBNAV_TR"].ToString();
                updatedata.Parameters.Add("@NEWS_SITESUBCATEGORYFR", SqlDbType.NVarChar).Value = SUBNAVDB.Rows[0]["SUBNAV_FR"].ToString();
            }
            else
            {
                updatedata.Parameters.Add("@NEWS_SITESUBCATEGORYAZ", SqlDbType.NVarChar).Value = "";
                updatedata.Parameters.Add("@NEWS_SITESUBCATEGORYEN", SqlDbType.NVarChar).Value = "";
                updatedata.Parameters.Add("@NEWS_SITESUBCATEGORYRU", SqlDbType.NVarChar).Value = "";
                updatedata.Parameters.Add("@NEWS_SITESUBCATEGORYTR", SqlDbType.NVarChar).Value = "";
                updatedata.Parameters.Add("@NEWS_SITESUBCATEGORYFR", SqlDbType.NVarChar).Value = "";
            }




            //---------------------------------------------------------------------------------------------------------------------------------//



            SQL.COMMAND(updatedata);


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



                    SqlCommand insertsubimgs = new SqlCommand(@"INSERT INTO DATA_IMGGALERY
                                                                    (   
                                                                    USER_ID,
                                                                    NEWS_SERIAL,
                                                                    NEWS_IMG_NAME,
                                                                    ISDELETE,
                                                                    ISACTIVE
                                                                    )
                                                                    VALUES
                                                                    (
                                                                    @USER_ID,
                                                                    @NEWS_SERIAL,
                                                                    @NEWS_IMG_NAME,
                                                                    @ISDELETE,
                                                                    @ISACTIVE
                                                                    )
                                                                    ");

                    insertsubimgs.Parameters.Add("@USER_ID", SqlDbType.Bit).Value = userid;

                    insertsubimgs.Parameters.Add("@NEWS_SERIAL", SqlDbType.NVarChar).Value = serial;
                    insertsubimgs.Parameters.Add("@NEWS_IMG_NAME", SqlDbType.NVarChar).Value = subPicName;

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
                    SqlCommand updateVideo = new SqlCommand(@"UPDATE DATA_VIDEOGALERY SET 
                                                                                NEWS_VIDEO_FRAME=@NEWS_VIDEO_FRAME ,
                                                                                NEWS_VIDEO_NAME=@NEWS_VIDEO_NAME 
                                                                                                WHERE USER_ID=@USER_ID AND 
                                                                                                      NEWS_SERIAL=@NEWS_SERIAL AND
                                                                                                      DATA_ID=@DATA_ID");

                    updateVideo.Parameters.Add("@NEWS_VIDEO_FRAME", SqlDbType.NVarChar).Value = videogalery_list.Items[i].Text.Replace(" ", string.Empty).Replace(".", string.Empty);
                    updateVideo.Parameters.Add("@NEWS_VIDEO_NAME", SqlDbType.NVarChar).Value = string.Empty;
                    updateVideo.Parameters.Add("@USER_ID", SqlDbType.Int).Value = 1;
                    updateVideo.Parameters.Add("@NEWS_SERIAL", SqlDbType.NVarChar).Value = Session["NEWSSERIAL"] as string;
                    updateVideo.Parameters.Add("@DATA_ID", SqlDbType.Int).Value = videogalery_list.Items[i].Value;

                    SQL.COMMAND(updateVideo);
                }
            }


            #region(insert documents to  doc table)
            if (_docsupload.HasFiles)
            {
                foreach (HttpPostedFile postedFile in _docsupload.PostedFiles)
                {
                    string uploadFile = Path.GetExtension(postedFile.FileName).ToLower();
                    if ((uploadFile != ".doc") &&
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
                    postedFile.SaveAs(Server.MapPath("/Uploads/" + docname));

                    SqlCommand insertdocs = new SqlCommand(@"INSERT INTO DATA_NEWSDOCS
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

        }

        public string GetDate()
        {
            SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand("SELECT FORMAT (SYSDATETIME() ,'dd/MM/yyyy HH:mm' ) as DataTime"));
            return SQL.SELECT(adapter).Rows[0]["DataTime"].ToString();
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
            string fileName = Guid.NewGuid().ToString().Replace("-", "") +
                                                DateTime.Now.Day.ToString() +
                                                DateTime.Now.Month.ToString() +
                                                DateTime.Now.Year.ToString() +
                                                DateTime.Now.Minute.ToString() +
                                                DateTime.Now.Second.ToString() +
                                                DateTime.Now.Millisecond + fileExtension;
            return fileName;
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

        private void GetSubImages(string NEWSSERIAL)
        {

            SqlDataAdapter subimages = new SqlDataAdapter(new SqlCommand(@"SELECT  ROW_NUMBER() OVER(ORDER BY DATA_ID DESC) AS '#' , 
                                                                                     DATA_IMGGALERY.DATA_ID,
                                                                                     DATA_IMGGALERY.USER_ID,
                                                                                     DATA_IMGGALERY.NEWS_SERIAL,
                                                                                     DATA_IMGGALERY.NEWS_IMG_NAME

                                                                                     FROM DATA_IMGGALERY WHERE  ISACTIVE    = @ISACTIVE AND 
                                                                                                                ISDELETE    = @ISDELETE AND 
                                                                                                                NEWS_SERIAL = @NEWS_SERIAL"));

            subimages.SelectCommand.Parameters.AddWithValue("@ISACTIVE", SqlDbType.Bit).Value = true;
            subimages.SelectCommand.Parameters.AddWithValue("@ISDELETE", SqlDbType.Bit).Value = false;
            subimages.SelectCommand.Parameters.AddWithValue("@NEWS_SERIAL", SqlDbType.NVarChar).Value = NEWSSERIAL;


            subImageList.DataSource = SQL.SELECT(subimages);
            subImageList.DataBind();
        }

        private void InsertVideoGalery(string USERID, string SERIAL, string VIDEOFRAME, string VIDEONAME)
        {
            SqlCommand insertVideos = new SqlCommand(@"INSERT INTO DATA_VIDEOGALERY
                                                                    (   
		                                                         
		                                                             USER_ID,
		                                                             ISDELETE,
		                                                             ISACTIVE,
		                                                             NEWS_SERIAL,
		                                                             NEWS_VIDEO_NAME,
		                                                             NEWS_VIDEO_FRAME
                                                                    )
                                                                    VALUES
                                                                    (
		                                                             @USER_ID,
		                                                             @ISDELETE,
		                                                             @ISACTIVE,
		                                                             @NEWS_SERIAL,
		                                                             @NEWS_VIDEO_NAME,
		                                                             @NEWS_VIDEO_FRAME
                                                                    )");

            insertVideos.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USERID;

            insertVideos.Parameters.Add("@NEWS_SERIAL", SqlDbType.NVarChar).Value = SERIAL;
            insertVideos.Parameters.Add("@NEWS_VIDEO_NAME", SqlDbType.NVarChar).Value = VIDEONAME.Replace(" ", string.Empty).Replace(".", string.Empty); ;
            insertVideos.Parameters.Add("@NEWS_VIDEO_FRAME", SqlDbType.NVarChar).Value = VIDEOFRAME.Replace(" ", string.Empty).Replace(".", string.Empty); ;

            insertVideos.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            insertVideos.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;

            SQL.COMMAND(insertVideos);
        }

        private void GetVideos(string SERIAL, string USERID)
        {
            SqlDataAdapter getVideos = new SqlDataAdapter(new SqlCommand(@"SELECT DATA_ID, NEWS_VIDEO_FRAME  FROM DATA_VIDEOGALERY

                                                                                            WHERE 
                                                                                                  ISACTIVE=@ISACTIVE        AND 
                                                                                                  ISDELETE=@ISDELETE        AND
                                                                                                  NEWS_SERIAL=@NEWS_SERIAL  AND 
                                                                                                  USER_ID=@USER_ID"));

            getVideos.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            getVideos.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            getVideos.SelectCommand.Parameters.Add("@NEWS_SERIAL", SqlDbType.NVarChar).Value = SERIAL;
            getVideos.SelectCommand.Parameters.Add("@USER_ID", SqlDbType.Int).Value = Convert.ToInt32(USERID);

            videogalery_list.DataSource = SQL.SELECT(getVideos);
            videogalery_list.DataTextField = "NEWS_VIDEO_FRAME";
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
                                                                      FROM  DATA_NEWSDOCS
                                                                      WHERE 
                                                                            ISDELETE=@ISDELETE       AND
                                                                            ISACTIVE=@ISACTIVE       AND
                                                                            POST_SERIAL=@POST_SERIAL AND 
                                                                    		USER_ID=@USER_ID"));

            getdocs.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            getdocs.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            getdocs.SelectCommand.Parameters.Add("@POST_SERIAL", SqlDbType.NVarChar).Value = POST_SERIAL;
            getdocs.SelectCommand.Parameters.Add("@USER_ID", SqlDbType.Int).Value = 1;

            post_docs_list.DataSource = SQL.SELECT(getdocs);
            post_docs_list.DataBind();


        }

        public void DeleteDocs(int DOCID)
        {
            SqlCommand deletenews = new SqlCommand(@"UPDATE DATA_NEWSDOCS SET ISDELETE=@ISDELETE,ISACTIVE=@ISACTIVE WHERE DOC_ID = @DOC_ID");
            deletenews.Parameters.Add("@DOC_ID", SqlDbType.Int).Value = DOCID;
            deletenews.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = false;
            deletenews.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = true;
            SQL.COMMAND(deletenews);
            GetDocs(Session["NEWSSERIAL"] as string);

        }
        #endregion


        #region(Post Sub images)
        protected void deletePostSubImage_Click(object sender, EventArgs e)
        {

        }

        protected void subImageList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void subImageList_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }
        #endregion

        #region(Post videos)
        protected void videogalery_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void videogaleryitemdelete_Click(object sender, EventArgs e)
        {

        }

        protected void videogalery_add_Click(object sender, EventArgs e)
        {

        }

        protected void videogalery_edit_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region(Post Docs)

        protected void post_docs_list_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void post_docs_list_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void deletePostDocs_Click(object sender, EventArgs e)
        {

        }
        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    GetCategory();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

                try
                {
                    GetSubCategory(category_list.SelectedValue);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }


                if (Session["POST"] as string == "SELECTED")
                {
                    try
                    {
                        GetNews(Page.RouteData.Values["newID"] as string);
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }

                    try
                    {
                        postConfirm.Text = "Dəyiş";
                        postConfirm.CssClass = "btn btn-warning";
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }



                }
                else
                {
                    try
                    {
                        labelTime.Text = GetDate();
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }



                }
            }
        }

        protected void postConfirm_Click(object sender, EventArgs e)
        {

        }

        protected void subImageList_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {

        }

        protected void category_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSubCategory(category_list.SelectedValue);
        }
    }
}