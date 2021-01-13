using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace PublicCouncilBackEnd
{
    public class SQLFUNC
    {
        public static DataTable GetLogo(string USER_ID,bool ISDELETE,bool ISACTIVE)
        {
          
            SqlDataAdapter getLogo = new SqlDataAdapter(new SqlCommand(@"SELECT TOP 1
                                                                                  LOGO_TITLE,
                                                                                  LOGO_IMG
                                                                             FROM PC_SITELOGOS
                                                                             WHERE USER_ID  = @USER_ID  AND
                                                                                   ISDELETE = @ISDELETE AND
                                                                                   ISACTIVE = @ISACTIVE
          "));


            getLogo.SelectCommand.Parameters.Add("@USER_ID", SqlDbType.Int).Value = USER_ID;
            getLogo.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = ISDELETE;
            getLogo.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = ISACTIVE;

            return SQL.SELECT(getLogo);

        }


        public static DataTable GetNavigations(string language,bool isdelete,bool isactive)
        {
            SqlDataAdapter getNavigations = new SqlDataAdapter(); 

            switch (language)
            {
                case "az":
                    {
                    getNavigations = new SqlDataAdapter(new SqlCommand(@"SELECT
                                                                                       NAV_AZ ,              
                                                                                       NAV_LINK_AZ
                                                                                        
                                                                                  FROM PC_NAV
                                                                                  WHERE ISDELETE  =@ISDELETE AND
                                                                                        ISACTIVE  =@ISACTIVE AND
                                                                                        NAV_VALUE !='contactus' AND
                                                                                        NAV_VALUE !='aboutus'
                                                                                 ORDER BY NAV_ORDER ASC"));
                        break;
                    }
                case "en":
                    {

                        getNavigations = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                                     
                                                                                       NAV_EN,
                                                                                       NAV_LINK_EN
                                                                                  FROM PC_NAV
                                                                                   WHERE ISDELETE  =@ISDELETE AND
                                                                                        ISACTIVE  =@ISACTIVE AND
                                                                                        NAV_VALUE !='contactus' AND
                                                                                        NAV_VALUE !='aboutus'
                                                                                 ORDER BY NAV_ORDER ASC"));
                        break;
                    }
                case "ru":
                    {
                        getNavigations = new SqlDataAdapter(new SqlCommand(@"SELECT                   
                                                                                       NAV_RU ,                                                                                  
                                                                                       NAV_LINK_RU

                                                                                  FROM PC_NAV
                                                                                  WHERE ISDELETE  =@ISDELETE AND
                                                                                        ISACTIVE  =@ISACTIVE AND
                                                                                        NAV_VALUE !='contactus' AND
                                                                                        NAV_VALUE !='aboutus'
                                                                                  ORDER BY NAV_ORDER ASC"));
                        break;
                    }
                default:
                    {
                        getNavigations = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                                       NAV_AZ,                                                                                     
                                                                                       NAV_LINK_AZ,
                                                                                       NAV_VALUE,
                                                                                       NAV_ORDER,
                                                                                       ISDELETE,
                                                                                       ISACTIVE
                                                                                  FROM PC_NAV
                                                                                  WHERE ISDELETE  =@ISDELETE AND
                                                                                        ISACTIVE  =@ISACTIVE AND
                                                                                        NAV_VALUE !='contactus' AND
                                                                                        NAV_VALUE !='aboutus'
                                                                                 ORDER BY NAV_ORDER ASC"));
                        break;
                    }
            }

            getNavigations.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = isdelete;
            getNavigations.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = isactive;
            return SQL.SELECT(getNavigations);

        }

        public static void GetSectionsData(string lang, string category, string operation, ListView LS_AZ, ListView LS_EN)
        {
            SqlDataAdapter getdata = new SqlDataAdapter();
            switch (lang)
            {
                case "az":
                    {
                        LS_EN.DataSourceID = null;
                        LS_EN.DataBind();

                        getdata = new SqlDataAdapter(new SqlCommand(@"SELECT  DATA_ID, NEWS_SEOAZ, NEWS_SITECATEGORYAZ , NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE ," + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY          
                                                                                                                     

                                                                                                                ORDER BY NEWS_DATE DESC  "));

                        getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getdata.SelectCommand.Parameters.Add("@NEWS_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category;


                        LS_AZ.DataSource = SQL.SELECT(getdata);
                        LS_AZ.DataBind();

                        getdata = null;
                        break;
                    }
                case "en":
                    {
                        LS_EN.DataSourceID = null;
                        LS_EN.DataBind();

                        getdata = new SqlDataAdapter(new SqlCommand(@"SELECT DATA_ID,  NEWS_SEOEN, NEWS_SITECATEGORYEN, NEWS_EN_TITLE, NEWS_IMG, NEWS_DATE , " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_EN_VIEW        = @NEWS_EN_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY           

                                                                                                                ORDER BY NEWS_DATE DESC  "));

                        getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getdata.SelectCommand.Parameters.Add("@NEWS_EN_VIEW", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category;

                        LS_AZ.DataSource = SQL.SELECT(getdata);
                        LS_AZ.DataBind();

                        getdata = null;
                        break;
                    }

                default:
                    {
                        LS_EN.DataSourceID = null;
                        LS_EN.DataBind();

                        getdata = new SqlDataAdapter(new SqlCommand(@"SELECT DATA_ID,  NEWS_SEOAZ, NEWS_SITECATEGORYAZ, NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE , " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY           

                                                                                                                ORDER BY NEWS_DATE DESC  "));

                        getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getdata.SelectCommand.Parameters.Add("@NEWS_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category;

                        LS_AZ.DataSource = SQL.SELECT(getdata);
                        LS_AZ.DataBind();

                        getdata = null;
                        break;
                    }
            }
        }

        public static void GetSectionsData(string lang, string category, string subcategory, string operation, ListView LS_AZ, ListView LS_EN) 
        {
            SqlDataAdapter getdata = new SqlDataAdapter();
            switch (lang)
            {
                case "az":
                    {
                        LS_EN.DataSourceID = null;
                        LS_EN.DataBind();
                        if (string.IsNullOrEmpty(subcategory))
                        {
                            getdata = new SqlDataAdapter(new SqlCommand(@"SELECT  DATA_ID,  NEWS_SEOAZ, NEWS_SITECATEGORYAZ, NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY          
                                                                                                                    

                                                                                                                     ORDER BY NEWS_DATE DESC  "));
                        }
                        else
                        {
                            getdata = new SqlDataAdapter(new SqlCommand(@"SELECT  DATA_ID, NEWS_SEOAZ, NEWS_SITECATEGORYAZ, NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY           AND
                                                                                                                      NEWS_SUBCATEGORY    = @NEWS_SUBCATEGORY

                                                                                                                ORDER BY NEWS_DATE DESC  "));
                            getdata.SelectCommand.Parameters.Add("@NEWS_SUBCATEGORY", SqlDbType.NVarChar).Value = subcategory;
                        }


                        getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getdata.SelectCommand.Parameters.Add("@NEWS_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category;
                      

                        LS_AZ.DataSource = SQL.SELECT(getdata);
                        LS_AZ.DataBind();

                        getdata = null;
                        break;
                    }
                case "en":
                    {
                        LS_EN.DataSourceID = null;
                        LS_EN.DataBind();

                        if (string.IsNullOrEmpty(subcategory))
                        {
                            getdata = new SqlDataAdapter(new SqlCommand(@"SELECT  DATA_ID,  NEWS_SEOEN, NEWS_SITECATEGORYEN, NEWS_E_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_EN_VIEW        = @NEWS_EN_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY          
                                                                                                                    

                                                                                                                     ORDER BY NEWS_DATE DESC  "));
                        }
                        else
                        {
                            getdata = new SqlDataAdapter(new SqlCommand(@"SELECT  DATA_ID, NEWS_SEOEN, NEWS_SITECATEGORYEN, NEWS_EN_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_EN_VIEW        = @NEWS_EN_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY           AND
                                                                                                                      NEWS_SUBCATEGORY    = @NEWS_SUBCATEGORY

                                                                                                                ORDER BY NEWS_DATE DESC  "));
                            getdata.SelectCommand.Parameters.Add("@NEWS_SUBCATEGORY", SqlDbType.NVarChar).Value = subcategory;
                        }

                        getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getdata.SelectCommand.Parameters.Add("@NEWS_EN_VIEW", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category;
                        getdata.SelectCommand.Parameters.Add("@NEWS_SUBCATEGORY", SqlDbType.NVarChar).Value = subcategory;

                        LS_AZ.DataSource = SQL.SELECT(getdata);
                        LS_AZ.DataBind();

                        getdata = null;
                        break;
                    }

                default:
                    {
                        {
                            LS_EN.DataSourceID = null;
                            LS_EN.DataBind();
                            if (string.IsNullOrEmpty(subcategory))
                            {
                                getdata = new SqlDataAdapter(new SqlCommand(@"SELECT  DATA_ID, NEWS_SEOAZ, NEWS_SITECATEGORYAZ , NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY          
                                                                                                                    

                                                                                                                     ORDER BY NEWS_DATE DESC  "));
                            }
                            else
                            {
                                getdata = new SqlDataAdapter(new SqlCommand(@"SELECT  DATA_ID, NEWS_SEOAZ, NEWS_SITECATEGORYAZ , NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY           AND
                                                                                                                      NEWS_SUBCATEGORY    = @NEWS_SUBCATEGORY

                                                                                                                ORDER BY NEWS_DATE DESC  "));
                                getdata.SelectCommand.Parameters.Add("@NEWS_SUBCATEGORY", SqlDbType.NVarChar).Value = subcategory;
                            }


                            getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                            getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                            getdata.SelectCommand.Parameters.Add("@NEWS_AZ_VIEW", SqlDbType.Bit).Value = true;
                            getdata.SelectCommand.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category;


                            LS_AZ.DataSource = SQL.SELECT(getdata);
                            LS_AZ.DataBind();

                            getdata = null;
                            break;
                        }
                    }
            }
        }

        public static void GetSectionsData(string lang, string category, string subcategory, string operation, string count, ListView LS_AZ, ListView LS_EN)
        {
            SqlDataAdapter getdata = new SqlDataAdapter();
            switch (lang)
            {
                case "az":
                    {
                        LS_EN.DataSourceID = null;
                        LS_EN.DataBind();
                        if (string.IsNullOrEmpty(subcategory))
                        {
                            getdata = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + count+ @"  DATA_ID,  NEWS_SEOAZ, NEWS_SITECATEGORYAZ, NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY          
                                                                                                                    

                                                                                                                     ORDER BY NEWS_DATE DESC  "));
                        }
                        else
                        {
                            getdata = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + count + @" DATA_ID, NEWS_SEOAZ, NEWS_SITECATEGORYAZ, NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY           AND
                                                                                                                      NEWS_SUBCATEGORY    = @NEWS_SUBCATEGORY

                                                                                                                ORDER BY NEWS_DATE DESC  "));
                            getdata.SelectCommand.Parameters.Add("@NEWS_SUBCATEGORY", SqlDbType.NVarChar).Value = subcategory;
                        }


                        getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getdata.SelectCommand.Parameters.Add("@NEWS_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category;


                        LS_AZ.DataSource = SQL.SELECT(getdata);
                        LS_AZ.DataBind();

                        getdata = null;
                        break;
                    }
                case "en":
                    {
                        LS_EN.DataSourceID = null;
                        LS_EN.DataBind();

                        if (string.IsNullOrEmpty(subcategory))
                        {
                            getdata = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + count + @" DATA_ID,  NEWS_SEOEN, NEWS_SITECATEGORYEN, NEWS_E_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_EN_VIEW        = @NEWS_EN_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY          
                                                                                                                    

                                                                                                                     ORDER BY NEWS_DATE DESC  "));
                        }
                        else
                        {
                            getdata = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + count + @" DATA_ID, NEWS_SEOEN, NEWS_SITECATEGORYEN, NEWS_EN_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_EN_VIEW        = @NEWS_EN_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY           AND
                                                                                                                      NEWS_SUBCATEGORY    = @NEWS_SUBCATEGORY

                                                                                                                ORDER BY NEWS_DATE DESC  "));
                            getdata.SelectCommand.Parameters.Add("@NEWS_SUBCATEGORY", SqlDbType.NVarChar).Value = subcategory;
                        }

                        getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getdata.SelectCommand.Parameters.Add("@NEWS_EN_VIEW", SqlDbType.Bit).Value = true;
                        getdata.SelectCommand.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category;
                        getdata.SelectCommand.Parameters.Add("@NEWS_SUBCATEGORY", SqlDbType.NVarChar).Value = subcategory;

                        LS_AZ.DataSource = SQL.SELECT(getdata);
                        LS_AZ.DataBind();

                        getdata = null;
                        break;
                    }

                default:
                    {
                        {
                            LS_EN.DataSourceID = null;
                            LS_EN.DataBind();
                            if (string.IsNullOrEmpty(subcategory))
                            {
                                getdata = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + count + @" DATA_ID, NEWS_SEOAZ, NEWS_SITECATEGORYAZ , NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY          
                                                                                                                    

                                                                                                                     ORDER BY NEWS_DATE DESC  "));
                            }
                            else
                            {
                                getdata = new SqlDataAdapter(new SqlCommand(@"SELECT TOP " + count + @" DATA_ID, NEWS_SEOAZ, NEWS_SITECATEGORYAZ , NEWS_AZ_TITLE, NEWS_IMG, NEWS_DATE, " + operation + @" FROM DATA_NEWS 

                                                                                                                WHERE
                                                                                                                      ISACTIVE            = @ISACTIVE                AND 
                                                                                                                      ISDELETE            = @ISDELETE                AND 
                                                                                                                      NEWS_AZ_VIEW        = @NEWS_AZ_VIEW            AND
                                                                                                                      NEWS_CATEGORY       = @NEWS_CATEGORY           AND
                                                                                                                      NEWS_SUBCATEGORY    = @NEWS_SUBCATEGORY

                                                                                                                ORDER BY NEWS_DATE DESC  "));
                                getdata.SelectCommand.Parameters.Add("@NEWS_SUBCATEGORY", SqlDbType.NVarChar).Value = subcategory;
                            }


                            getdata.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                            getdata.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                            getdata.SelectCommand.Parameters.Add("@NEWS_AZ_VIEW", SqlDbType.Bit).Value = true;
                            getdata.SelectCommand.Parameters.Add("@NEWS_CATEGORY", SqlDbType.NVarChar).Value = category;


                            LS_AZ.DataSource = SQL.SELECT(getdata);
                            LS_AZ.DataBind();

                            getdata = null;
                            break;
                        }
                    }
            }
        }



        //NEW QUERY METHODS
        public static void GetSectionPosts(string LANGUAGE,string COUNT,string CATEGORY,bool ISDELETE,bool ISACTIVE,string POSTAUTHOR ,ListView LSV_AZ,ListView LSV_EN)
        {
            switch (LANGUAGE)
            {
                case "az":
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();
                        SqlDataAdapter getPost = new SqlDataAdapter(new SqlCommand(@"SELECT TOP @COUNT  
                                                                                                        DATA_ID,
                                                                                                        POST_AZ_TITLE,
                                                                                                        POST_AZ_TOPIC,
                                                                                                        POST_CATEGORY,
                                                                                            	        POST_SUBCATEGORY,
                                                                                            	        POST_SITECATEGORYAZ,
                                                                                                        POST_SITESUBCATEGORYAZ,
                                                                                                        POST_SUBCATEGORY,
                                                                                                        POST_IMG,
                                                                                                        POST_DATE,
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE AND
                                                                                                        ISACTIVE            = @ISACTIVE AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY AND
                                                                                                        POST_AZ_VIEW        = @POST_EN_VIEW  AND
                                                                                                        POST_AUTHOR         = @ POST_AUTHOR"));

                        getPost.SelectCommand.Parameters.Add("@COUNT", SqlDbType.NVarChar).Value = COUNT;
                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POST_AUTHOR", SqlDbType.NVarChar).Value = POSTAUTHOR;

                        LSV_AZ.DataSource = SQL.SELECT(getPost);
                        LSV_AZ.DataBind();

                        break;
                    }
                case "en":
                    {
                        LSV_AZ.DataSource = null;
                        LSV_AZ.DataBind();
                        SqlDataAdapter getPost = new SqlDataAdapter(new SqlCommand(@"SELECT TOP @COUNT  
                                                                                                        DATA_ID,
                                                                                                        POST_EN_TITLE,
                                                                                                        POST_EN_TOPIC,
                                                                                                        POST_CATEGORY,
                                                                                            	        POST_SUBCATEGORY,
                                                                                            	        POST_SITECATEGORYEN,
                                                                                                        POST_SITESUBCATEGORYEN,
                                                                                                        POST_SUBCATEGORY,
                                                                                                        POST_IMG,
                                                                                                        POST_DATE,
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOEN,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE AND
                                                                                                        ISACTIVE            = @ISACTIVE AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY AND
                                                                                                        POST_EN_VIEW        = @POST_EN_VIEW  AND
                                                                                                        POST_AUTHOR         = @ POST_AUTHOR"));

                        getPost.SelectCommand.Parameters.Add("@COUNT",         SqlDbType.NVarChar).Value         = COUNT;
                        getPost.SelectCommand.Parameters.Add("@ISDELETE",      SqlDbType.Bit).Value              = ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE",      SqlDbType.Bit).Value              = ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value         = CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_EN_VIEW",  SqlDbType.Bit).Value              = true;
                        getPost.SelectCommand.Parameters.Add("@POST_AUTHOR",   SqlDbType.NVarChar).Value         = POSTAUTHOR;

                        LSV_EN.DataSource = SQL.SELECT(getPost);
                        LSV_EN.DataBind();

                        break;
                    }
                default:
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();
                        SqlDataAdapter getPost = new SqlDataAdapter(new SqlCommand(@"SELECT TOP @COUNT  
                                                                                                        DATA_ID,
                                                                                                        POST_AZ_TITLE,
                                                                                                        POST_AZ_TOPIC,
                                                                                                        POST_CATEGORY,
                                                                                            	        POST_SUBCATEGORY,
                                                                                            	        POST_SITECATEGORYAZ,
                                                                                                        POST_SITESUBCATEGORYAZ,
                                                                                                        POST_SUBCATEGORY,
                                                                                                        POST_IMG,
                                                                                                        POST_DATE,
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE AND
                                                                                                        ISACTIVE            = @ISACTIVE AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY AND
                                                                                                        POST_AZ_VIEW        = @POST_EN_VIEW  AND
                                                                                                        POST_AUTHOR         = @ POST_AUTHOR"));

                        getPost.SelectCommand.Parameters.Add("@COUNT", SqlDbType.NVarChar).Value = COUNT;
                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POST_AUTHOR", SqlDbType.NVarChar).Value = POSTAUTHOR;

                        LSV_AZ.DataSource = SQL.SELECT(getPost);
                        LSV_AZ.DataBind();

                        break;
                    }
                  
            }
        }
    }
}