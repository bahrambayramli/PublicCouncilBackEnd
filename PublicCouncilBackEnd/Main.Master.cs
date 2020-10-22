using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PublicCouncilBackEnd
{
    public partial class Main : System.Web.UI.MasterPage
    {
        #region(SQL FUNCTIONS)
        private void GetLogo()
        {
            DataTable dtLogo = new DataTable();
            dtLogo = SQLFUNC.GetLogo("1", false, true);

            LogoMobile.DataSource = dtLogo;
            LogoMobile.DataBind();

            LogoMobile2.DataSource = dtLogo;
            LogoMobile2.DataBind();

            LogoDesktop.DataSource = dtLogo;
            LogoDesktop.DataBind();
        }
        private void GetNavigations(string lang)
        {
            switch (lang)
            {
                case "az":
                    {
                        NAV_AZ.DataSource = SQLFUNC.GetNavigations(lang, false, true);
                        NAV_AZ.DataBind();
                        break;
                    }
                case "en":
                    {
                        NAV_EN.DataSource = SQLFUNC.GetNavigations(lang, false, true);
                        NAV_EN.DataBind();
                        break;
                    }
                case "ru":
                    {
                        NAV_RU.DataSource = SQLFUNC.GetNavigations(lang, false, true);
                        NAV_RU.DataBind();
                        break;
                    }
                default:
                    {
                        NAV_AZ.DataSource = SQLFUNC.GetNavigations(lang, false, true);
                        NAV_AZ.DataBind();
                        break;
                    }
            }
        }

        private void GetPosts(string LANGUAGE, string POST_COUNT, string POST_CATEGORY, bool POST_ISDELETE, bool POST_ISACTIVE, bool POSTMAIN_VIEW, ListView LSV_AZ, ListView LSV_EN)
        {
            switch (LANGUAGE)
            {
                case "az":
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();


                        SqlDataAdapter getPost =  new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + POST_COUNT + @"  
                                                                                                        DATA_ID,
                                                                                                        POST_AZ_TITLE,
                                                                                                        POST_CATEGORY,
                                                                                            	        POST_SUBCATEGORY,
                                                                                            	        POST_SITECATEGORYAZ,
                                                                                                        POST_SITESUBCATEGORYAZ,
                                                                                                        POST_IMG,
                                                                                                        POST_DATE,
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE      AND
                                                                                                        ISACTIVE            = @ISACTIVE      AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY AND                                                                                                   
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW  AND
                                                                                                        POSTMAIN_VIEW       = @POSTMAIN_VIEW

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));
                      
                        

                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = POSTMAIN_VIEW;
                       

                        LSV_AZ.DataSource = SQL.SELECT(getPost);
                        LSV_AZ.DataBind();

                        break;
                    }
                case "en":
                    {
                        LSV_AZ.DataSource = null;
                        LSV_AZ.DataBind();


                        SqlDataAdapter getPost = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + POST_COUNT + @"  
                                                                                                        DATA_ID,
                                                                                                        POST_EN_TITLE,
                                                                                                        POST_CATEGORY,
                                                                                            	        POST_SUBCATEGORY,
                                                                                            	        POST_SITECATEGORYEN,
                                                                                                        POST_SITESUBCATEGORYEN,
                                                                                                        POST_IMG,
                                                                                                        CONVERT(VARCHAR(10), CONVERT(DATETIME, POST_DATE),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, POST_DATE),108) AS 'POST_DATE',
                                                                                                        POST_SEOEN,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE      AND
                                                                                                        ISACTIVE            = @ISACTIVE      AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY AND                                                                                                   
                                                                                                        POST_EN_VIEW        = @POST_EN_VIEW  AND
                                                                                                        POSTMAIN_VIEW         = @POSTMAIN_VIEW

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));



                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_EN_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = POSTMAIN_VIEW;


                        LSV_EN.DataSource = SQL.SELECT(getPost);
                        LSV_EN.DataBind();
                        break;
                    }
                default:
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();


                        SqlDataAdapter getPost = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + POST_COUNT + @"  
                                                                                                        DATA_ID,
                                                                                                        POST_AZ_TITLE,
                                                                                                        POST_CATEGORY,
                                                                                            	        POST_SUBCATEGORY,
                                                                                            	        POST_SITECATEGORYAZ,
                                                                                                        POST_SITESUBCATEGORYAZ,
                                                                                                        POST_IMG,
                                                                                                        CONVERT(VARCHAR(10), CONVERT(DATETIME, POST_DATE),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, POST_DATE),108) AS 'POST_DATE',
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE      AND
                                                                                                        ISACTIVE            = @ISACTIVE      AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY AND                                                                                                   
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW  AND
                                                                                                        POSTMAIN_VIEW         = @POSTMAIN_VIEW

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));



                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = POSTMAIN_VIEW;


                        LSV_AZ.DataSource = SQL.SELECT(getPost);
                        LSV_AZ.DataBind();

                        break;
                    }

            }
        }
        private void GetPosts(string LANGUAGE, string POST_COUNT, string POST_CATEGORY,string POST_TYPE, bool POST_ISDELETE, bool POST_ISACTIVE, string POSTMAIN_VIEW, ListView LSV_AZ, ListView LSV_EN)
        {
            switch (LANGUAGE)
            {
                case "az":
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();


                        SqlDataAdapter getPost = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + POST_COUNT + @"  
                                                                                                        DATA_ID,
                                                                                                        POST_AZ_TITLE,
                                                                                                        POST_CATEGORY,
                                                                                            	        POST_SUBCATEGORY,
                                                                                            	        POST_SITECATEGORYAZ,
                                                                                                        POST_SITESUBCATEGORYAZ,
                                                                                                        POST_IMG,
                                                                                                        CONVERT(VARCHAR(10), CONVERT(DATETIME, POST_DATE),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, POST_DATE),108) AS 'POST_DATE',
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE      AND
                                                                                                        ISACTIVE            = @ISACTIVE      AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY AND 
                                                                                                        POST_TYPE           = @POST_TYPE     AND 
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW  AND
                                                                                                        POSTMAIN_VIEW       = @POSTMAIN_VIEW

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));



                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_TYPE", SqlDbType.NVarChar).Value = POST_TYPE;
                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = POSTMAIN_VIEW;


                        LSV_AZ.DataSource = SQL.SELECT(getPost);
                        LSV_AZ.DataBind();

                        break;
                    }
                case "en":
                    {
                        LSV_AZ.DataSource = null;
                        LSV_AZ.DataBind();


                        SqlDataAdapter getPost = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + POST_COUNT + @"  
                                                                                                        DATA_ID,
                                                                                                        POST_EN_TITLE,
                                                                                                        POST_CATEGORY,
                                                                                            	        POST_SUBCATEGORY,
                                                                                            	        POST_SITECATEGORYEN,
                                                                                                        POST_SITESUBCATEGORYEN,
                                                                                                        POST_IMG,
                                                                                                        CONVERT(VARCHAR(10), CONVERT(DATETIME, POST_DATE),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, POST_DATE),108) AS 'POST_DATE',
                                                                                                        POST_SEOEN,
                                                                                                        POSTMAIN_VIEW
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE      AND
                                                                                                        ISACTIVE            = @ISACTIVE      AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY AND  
                                                                                                        POST_TYPE           = @POST_TYPE     AND 
                                                                                                        POST_EN_VIEW        = @POST_EN_VIEW  AND
                                                                                                        POSTMAIN_VIEW         = @POSTMAIN_VIEW

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));



                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_TYPE", SqlDbType.NVarChar).Value = POST_TYPE;
                        getPost.SelectCommand.Parameters.Add("@POST_EN_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = POSTMAIN_VIEW;


                        LSV_EN.DataSource = SQL.SELECT(getPost);
                        LSV_EN.DataBind();
                        break;
                    }
                default:
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();


                        SqlDataAdapter getPost = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + POST_COUNT + @"  
                                                                                                        DATA_ID,
                                                                                                        POST_AZ_TITLE,
                                                                                                        POST_CATEGORY,
                                                                                            	        POST_SUBCATEGORY,
                                                                                            	        POST_SITECATEGORYAZ,
                                                                                                        POST_SITESUBCATEGORYAZ,
                                                                                                        POST_IMG,
                                                                                                        CONVERT(VARCHAR(10), CONVERT(DATETIME, POST_DATE),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, POST_DATE),108) AS 'POST_DATE',
                                                                                                        POST_SEOAZ,
                                                                                                        POSTMAIN_VIEW
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE      AND
                                                                                                        ISACTIVE            = @ISACTIVE      AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY AND 
                                                                                                        POST_TYPE           = @POST_TYPE     AND 
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW  AND
                                                                                                        POSTMAIN_VIEW         = @POSTMAIN_VIEW

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));



                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_TYPE", SqlDbType.NVarChar).Value = POST_TYPE;
                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = POSTMAIN_VIEW;


                        LSV_AZ.DataSource = SQL.SELECT(getPost);
                        LSV_AZ.DataBind();

                        break;
                    }

            }
        }
        private void GetPosts(string LANGUAGE, string POST_COUNT, string POST_CATEGORY, string POST_SUBCATEGORY, bool POST_ISDELETE, bool POST_ISACTIVE, bool POSTMAIN_VIEW, ListView LSV_AZ, ListView LSV_EN,bool notuse)
        {
            switch (LANGUAGE)
            {
                case "az":
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();


                        SqlDataAdapter getPost = new SqlDataAdapter();
                        if (string.IsNullOrEmpty(POST_SUBCATEGORY))
                        {
                            getPost = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + POST_COUNT + @"  
                                                                                                        DATA_ID,
                                                                                                        POST_AZ_TITLE,
                                                                                                        POST_AZ_TOPIC,
                                                                                                        POST_CATEGORY,
                                                                                            	        POST_SUBCATEGORY,
                                                                                            	        POST_SITECATEGORYAZ,
                                                                                                        POST_SITESUBCATEGORYAZ,
                                                                                                        POST_SUBCATEGORY,
                                                                                                        POST_IMG,
                                                                                                        CONVERT(VARCHAR(10), CONVERT(DATETIME, POST_DATE),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, POST_DATE),108) AS 'POST_DATE',
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE      AND
                                                                                                        ISACTIVE            = @ISACTIVE      AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY AND
                                                                                                      
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW  AND
                                                                                                        POSTMAIN_VIEW       = @POSTMAIN_VIEW

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));
                        }
                        else
                        {
                            getPost = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + POST_COUNT + @"  
                                                                                                        DATA_ID,
                                                                                                        POST_AZ_TITLE,
                                                                                                        POST_AZ_TOPIC,
                                                                                                        POST_CATEGORY,
                                                                                            	        POST_SUBCATEGORY,
                                                                                            	        POST_SITECATEGORYAZ,
                                                                                                        POST_SITESUBCATEGORYAZ,
                                                                                                        POST_SUBCATEGORY,
                                                                                                        POST_IMG,
                                                                                                        CONVERT(VARCHAR(10), CONVERT(DATETIME, POST_DATE),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, POST_DATE),108) AS 'POST_DATE',
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE          AND
                                                                                                        ISACTIVE            = @ISACTIVE          AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY     AND
                                                                                                        POST_SUBCATEGORY    = @POST_SUBCATEGORY  AND
                                                                                                      
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW      AND
                                                                                                        POSTMAIN_VIEW       = @POSTMAIN_VIEW
                                                                                                        ORDER BY POST_DATE DESC"));
                            getPost.SelectCommand.Parameters.Add("@POST_SUBCATEGORY", SqlDbType.NVarChar).Value = POST_SUBCATEGORY;
                        }

                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = POSTMAIN_VIEW;

                        LSV_AZ.DataSource = SQL.SELECT(getPost);
                        LSV_AZ.DataBind();

                        break;
                    }
                case "en":
                    {
                        LSV_AZ.DataSource = null;
                        LSV_AZ.DataBind();


                        SqlDataAdapter getPost = new SqlDataAdapter();
                        if (string.IsNullOrEmpty(POST_SUBCATEGORY))
                        {
                            getPost = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + POST_COUNT + @"  
                                                                                                        DATA_ID,
                                                                                                        POST_EN_TITLE,
                                                                                                        POST_EN_TOPIC,
                                                                                                        POST_CATEGORY,
                                                                                            	        POST_SUBCATEGORY,
                                                                                            	        POST_SITECATEGORYEN,
                                                                                                        POST_SITESUBCATEGORYEN,
                                                                                                        POST_SUBCATEGORY,
                                                                                                        POST_IMG,
                                                                                                        CONVERT(VARCHAR(10), CONVERT(DATETIME, POST_DATE),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, POST_DATE),108) AS 'POST_DATE',
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOEN,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE      AND
                                                                                                        ISACTIVE            = @ISACTIVE      AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY AND
                                                                                                       
                                                                                                        POST_EN_VIEW        = @POST_EN_VIEW  AND
                                                                                                        POSTMAIN_VIEW       = @POSTMAIN_VIEW
                                                                                                        
                                                                                                        ORDER BY POST_DATE DESC"));
                        }
                        else
                        {
                            getPost = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + POST_COUNT + @"  
                                                                                                        DATA_ID,
                                                                                                        POST_EN_TITLE,
                                                                                                        POST_EN_TOPIC,
                                                                                                        POST_CATEGORY,
                                                                                            	        POST_SUBCATEGORY,
                                                                                            	        POST_SITECATEGORYEN,
                                                                                                        POST_SITESUBCATEGORYEN,
                                                                                                        POST_SUBCATEGORY,
                                                                                                        POST_IMG,
                                                                                                        CONVERT(VARCHAR(10), CONVERT(DATETIME, POST_DATE),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, POST_DATE),108) AS 'POST_DATE',
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOEN,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE          AND
                                                                                                        ISACTIVE            = @ISACTIVE          AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY     AND
                                                                                                        POST_SUBCATEGORY    = @POST_SUBCATEGORY  AND
                                                                                                     
                                                                                                        POST_EN_VIEW        = @POST_EN_VIEW      AND
                                                                                                        POST_AUTHOR         = @POST_AUTHOR
                                                                                                        ORDER BY POST_DATE DESC"));
                            getPost.SelectCommand.Parameters.Add("@POST_SUBCATEGORY", SqlDbType.NVarChar).Value = POST_SUBCATEGORY;
                        }

                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_EN_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = POSTMAIN_VIEW;

                        LSV_EN.DataSource = SQL.SELECT(getPost);
                        LSV_EN.DataBind();

                        break;
                    }
                default:
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();


                        SqlDataAdapter getPost = new SqlDataAdapter();
                        if (string.IsNullOrEmpty(POST_SUBCATEGORY))
                        {
                            getPost = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + POST_COUNT + @"  
                                                                                                        DATA_ID,
                                                                                                        POST_AZ_TITLE,
                                                                                                        POST_AZ_TOPIC,
                                                                                                        POST_CATEGORY,
                                                                                            	        POST_SUBCATEGORY,
                                                                                            	        POST_SITECATEGORYAZ,
                                                                                                        POST_SITESUBCATEGORYAZ,
                                                                                                        POST_SUBCATEGORY,
                                                                                                        POST_IMG,
                                                                                                        CONVERT(VARCHAR(10), CONVERT(DATETIME, POST_DATE),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, POST_DATE),108) AS 'POST_DATE',
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE      AND
                                                                                                        ISACTIVE            = @ISACTIVE      AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY AND
                                                                                                      
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW  AND
                                                                                                        POSTMAIN_VIEW       = @POSTMAIN_VIEW

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));
                        }
                        else
                        {
                            getPost = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + POST_COUNT + @"  
                                                                                                        DATA_ID,
                                                                                                        POST_AZ_TITLE,
                                                                                                        POST_AZ_TOPIC,
                                                                                                        POST_CATEGORY,
                                                                                            	        POST_SUBCATEGORY,
                                                                                            	        POST_SITECATEGORYAZ,
                                                                                                        POST_SITESUBCATEGORYAZ,
                                                                                                        POST_SUBCATEGORY,
                                                                                                        POST_IMG,
                                                                                                        CONVERT(VARCHAR(10), CONVERT(DATETIME, POST_DATE),103) + ' ' + CONVERT(VARCHAR(8), CONVERT(DATETIME, POST_DATE),108) AS 'POST_DATE',
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE          AND
                                                                                                        ISACTIVE            = @ISACTIVE          AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY     AND
                                                                                                        POST_SUBCATEGORY    = @POST_SUBCATEGORY  AND
                                                                                                      
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW      AND
                                                                                                        POSTMAIN_VIEW       = @POSTMAIN_VIEW
                                                                                                        ORDER BY POST_DATE DESC"));
                            getPost.SelectCommand.Parameters.Add("@POST_SUBCATEGORY", SqlDbType.NVarChar).Value = POST_SUBCATEGORY;
                        }

                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = POSTMAIN_VIEW;

                        LSV_AZ.DataSource = SQL.SELECT(getPost);
                        LSV_AZ.DataBind();

                        break;
                    }

            }
        }

        private void GetLatest(string LANGUAGE, string POST_COUNT, bool POST_ISDELETE, bool POST_ISACTIVE, bool POSTMAIN_VIEW, ListView LSV_AZ, ListView LSV_EN)
        {

            SqlDataAdapter getPost = new SqlDataAdapter();
            switch (LANGUAGE)
            {
                case "az":
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();


                        getPost = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + POST_COUNT + @"  

                                                                                                        DATA_ID,
                                                                                                        POST_AZ_TITLE,
                                                                                            	        POST_SITECATEGORYAZ,
                                                                                                        POST_IMG,
                                                                                                        POST_DATE,
                                                                                                        POST_SEOAZ
                                                                                                      
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE        AND
                                                                                                        ISACTIVE            = @ISACTIVE        AND
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW    AND
                                                                                                        POSTMAIN_VIEW       = @POSTMAIN_VIEW   AND
                                                                                                        (
                                                                                                        POST_CATEGORY       = 'news '          OR 
                                                                                                        POST_CATEGORY       = 'announcements'  OR
                                                                                                        POST_CATEGORY       = 'reports'        OR
                                                                                                        POST_CATEGORY       = 'publications'   )

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));



                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = POSTMAIN_VIEW;


                        LSV_AZ.DataSource = SQL.SELECT(getPost);
                        LSV_AZ.DataBind();

                        getPost = null;

                        break;
                    }
                case "en":
                    {
                        LSV_AZ.DataSource = null;
                        LSV_AZ.DataBind();


                        getPost = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + POST_COUNT + @"  

                                                                                                        DATA_ID,
                                                                                                        POST_EN_TITLE,
                                                                                            	        POST_SITECATEGORYEN,
                                                                                                        POST_IMG,
                                                                                                        POST_DATE,
                                                                                                        POST_SEOEN
                                                                                                      
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE        AND
                                                                                                        ISACTIVE            = @ISACTIVE        AND
                                                                                                        POST_EN_VIEW        = @POST_EN_VIEW    AND
                                                                                                        POSTMAIN_VIEW       = @POSTMAIN_VIEW   AND
                                                                                                        (
                                                                                                        POST_CATEGORY       = 'news '          OR 
                                                                                                        POST_CATEGORY       = 'announcements'  OR
                                                                                                        POST_CATEGORY       = 'reports'        AND
                                                                                                        POST_CATEGORY       = 'publications'   
                                                                                                        )

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));



                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_EN_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = POSTMAIN_VIEW;


                        LSV_EN.DataSource = SQL.SELECT(getPost);
                        LSV_EN.DataBind();

                        getPost = null;

                        break;
                    }
                default:
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();


                        getPost = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + POST_COUNT + @"  

                                                                                                        DATA_ID,
                                                                                                        POST_AZ_TITLE,
                                                                                            	        POST_SITECATEGORYAZ,
                                                                                                        POST_IMG,
                                                                                                        POST_DATE,
                                                                                                        POST_SEOAZ
                                                                                                      
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE        AND
                                                                                                        ISACTIVE            = @ISACTIVE        AND
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW    AND
                                                                                                        POSTMAIN_VIEW       = @POSTMAIN_VIEW   AND
                                                                                                        (
                                                                                                        POST_CATEGORY       = 'news '          OR 
                                                                                                        POST_CATEGORY       = 'announcements'  OR
                                                                                                        POST_CATEGORY       = 'reports'        OR
                                                                                                        POST_CATEGORY       = 'publications'   )

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));



                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = POSTMAIN_VIEW;


                        LSV_AZ.DataSource = SQL.SELECT(getPost);
                        LSV_AZ.DataBind();

                        getPost = null;

                        break;
                    }

            }
        }

        private void GetPartners(string LANGUAGE,string PARTNERS_COUNT, bool PARTNERS_ISDELETE, bool PARTNERS_ISACTIVE, ListView LSV_AZ,ListView LSV_EN)
        {
            SqlDataAdapter getPartners = new SqlDataAdapter();
            switch (LANGUAGE)
            {
                 
                case "az":
                    {

                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind(); 
                        getPartners = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + PARTNERS_COUNT + @"  
	                                                                                           
                                                                                                 PARTNERS_TITLE,
                                                                                                 PARTNERS_LINK,
                                                                                                 PARTNERS_IMG
                                                                                                
                                                                                            FROM PC_PARTNERS

                                                                                            WHERE ISDELETE = @ISDELETE AND
                                                                                                  ISACTIVE = @ISACTIVE"));

                        getPartners.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = PARTNERS_ISDELETE;
                        getPartners.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = PARTNERS_ISACTIVE;

                        LSV_AZ.DataSource = SQL.SELECT(getPartners);
                        LSV_AZ.DataBind();

                        break;
                    }
                case "en":
                    {
                        LSV_AZ.DataSource = null;
                        LSV_AZ.DataBind();
                        getPartners = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + PARTNERS_COUNT + @"  
	                                                                                             
                                                                                                 PARTNERS_TITLE,
                                                                                                 PARTNERS_LINK,
                                                                                                 PARTNERS_IMG
                                                                                                
                                                                                            FROM PC_PARTNERS

                                                                                            WHERE ISDELETE = @ISDELETE AND
                                                                                                  ISACTIVE = @ISACTIVE"));

                        getPartners.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = PARTNERS_ISDELETE;
                        getPartners.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = PARTNERS_ISACTIVE;

                        LSV_EN.DataSource = SQL.SELECT(getPartners);
                        LSV_EN.DataBind();

                        break;
                       
                    }
                default:
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();
                        getPartners = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + PARTNERS_COUNT + @"  
	                                                                                           
                                                                                                 PARTNERS_TITLE,
                                                                                                 PARTNERS_LINK,
                                                                                                 PARTNERS_IMG
                                                                                                
                                                                                            FROM PC_PARTNERS

                                                                                            WHERE ISDELETE = @ISDELETE AND
                                                                                                  ISACTIVE = @ISACTIVE"));

                        getPartners.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = PARTNERS_ISDELETE;
                        getPartners.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = PARTNERS_ISACTIVE;

                        LSV_AZ.DataSource = SQL.SELECT(getPartners);
                        LSV_AZ.DataBind();

                        break;
                     
                    }
            }

           
        }
        private void GetSponsors()
        {
            SqlDataAdapter getSponsors = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                                    DATA_ID,
                                                                                    SPONSOR_TITLE,
                                                                                    SPONSOR_LINK,
                                                                                    SPONSOR_IMG,
                                                                                    ISDELETE,
                                                                                    ISACTIVE
                                                                             
                                                                             FROM PC_SPONSORS
                                                                             
                                                                             WHERE  ISDELETE=@ISDELETE AND
                                                                             	    ISACTIVE=@ISACTIVE"));

            getSponsors.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            getSponsors.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;

            SPONSORS.DataSource = SQL.SELECT(getSponsors);
            SPONSORS.DataBind();

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["language"] = Convert.ToString(Page.RouteData.Values["language"]).ToLower();
            GetLogo();
            GetSponsors();
            GetNavigations(Page.RouteData.Values["language"] as string);
            GetPosts(Session["language"] as string, "4", "election", false, true, true, COUNCILELECTION_AZ, COUNCILELECTION_EN);
            GetPosts(Session["language"] as string, "4", "announcements", false, true, true, ANNOUNCMENTS_AZ, ANNOUNCMENTS_EN);
            GetLatest(Session["language"] as string, "12", false, true, true, LATEST_AZ, LATEST_EN);
            GetPosts(Session["language"] as string, "5", "multimedia", "video", false, true,true, VIDEOS_AZ, VIDEOS_EN,false);
            GetPartners(Session["language"] as string,"12", false, true, PARTNERS_AZ,PARTNERS_EN);
            switch (Session["language"]as string)
            {
                case "az":
                    {
                        signIN.Text = "Daxil ol";
                        break;
                    }
                case "en":
                    {
                        signIN.Text = "Sign in";
                        break;
                    }
               default:
                    {
                        signIN.Text = "Daxil ol";
                        break;
                    }
            }
        }

        protected void langAZ_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl.Replace("/en", "/az"));
        }

        protected void langEN_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl.Replace("/az", "/en"));
        }

        protected void signIN_Click(object sender, EventArgs e)
        {
            Response.Redirect("/login");
        }
    }
}