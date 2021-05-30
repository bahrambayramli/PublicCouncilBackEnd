using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PublicCouncilBackEnd.subsite
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        #region(HELPER FUNCTIONS)
        private void ChangeLanguage(string LANG)
        {
            switch (LANG)
            {
                case "az":
                    {
                        postsName.Text          = "Multimedia";
                        postPhoto.Text          = "Foto";
                        postPhoto.NavigateUrl   = $"/{Page.RouteData.Values["publiccouncil"] as string}/multimedia/photo/az";
                        postVideo.Text          = "Video";
                        postVideo.NavigateUrl   = $"/{Page.RouteData.Values["publiccouncil"] as string}/multimedia/video/az";
                        break;
                    }
                case "en":
                    {
                        postsName.Text          = "multimedias";
                        postPhoto.Text          = "Photo";
                        postPhoto.NavigateUrl   = $"/{Page.RouteData.Values["publiccouncil"] as string}/multimedia/photo/en";
                        postVideo.Text          = "Video";
                        postVideo.NavigateUrl   = $"/{Page.RouteData.Values["publiccouncil"] as string}/multimedia/video/en";
                        break;
                    }
                default:
                    {
                        postsName.Text          = "Multimedia";
                        postPhoto.Text          = "Foto";
                        postPhoto.NavigateUrl   = $"/{Page.RouteData.Values["publiccouncil"] as string}/multimedia/photo/az";
                        postVideo.Text          = "Video";
                        postVideo.NavigateUrl   = $"/{Page.RouteData.Values["publiccouncil"] as string}/multimedia/video/az";
                        break;
                    }
            }
        }
        #endregion

        #region(SQL FUNCTIONS)
        private void GetPosts(string LANGUAGE, string POST_CATEGORY, bool POST_ISDELETE, bool POST_ISACTIVE, string POST_AUTHOR, ListView LSV_AZ, ListView LSV_EN)
        {
            switch (LANGUAGE)
            {
                case "az":
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();


                        SqlDataAdapter getPost = new SqlDataAdapter(new SqlCommand(@"SELECT  
                                                                                                        DATA_ID                                 ,
                                                                                                        POST_AZ_TITLE                           ,
                                                                                                        POST_CATEGORY                           ,
                                                                                            	        POST_SUBCATEGORY                        ,
                                                                                            	        POST_SITECATEGORYAZ                     ,
                                                                                                        POST_SITESUBCATEGORYAZ                  ,
                                                                                                        POST_IMG                                ,
                                                                                                        POST_DATE                               ,
                                                                                                        POST_SEOAZ                              ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE         AND
                                                                                                        ISACTIVE            = @ISACTIVE         AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY    AND      
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW     AND
                                                                                                        POST_AUTHOR         = @POST_AUTHOR

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));


                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value                  = true;
                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value                      = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value                      = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value            = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_AUTHOR", SqlDbType.NVarChar).Value              = POST_AUTHOR;


                        LSV_AZ.DataSource = SQL.SELECT(getPost);
                        LSV_AZ.DataBind();

                        break;
                    }
                case "en":
                    {
                        LSV_AZ.DataSource = null;
                        LSV_AZ.DataBind();


                        SqlDataAdapter getPost = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                                                        DATA_ID                                 ,
                                                                                                        POST_EN_TITLE                           ,
                                                                                                        POST_CATEGORY                           ,
                                                                                            	        POST_SUBCATEGORY                        ,
                                                                                            	        POST_SITECATEGORYEN                     ,
                                                                                                        POST_SITESUBCATEGORYEN                  ,
                                                                                                        POST_IMG                                ,
                                                                                                        POST_DATE                               ,
                                                                                                        POST_SEOEN                              ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE         AND
                                                                                                        ISACTIVE            = @ISACTIVE         AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY    AND      
                                                                                                        POST_EN_VIEW        = @POST_EN_VIEW     AND
                                                                                                        POST_AUTHOR         = @POST_AUTHOR

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));



                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value              = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value              = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value    = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_EN_VIEW", SqlDbType.Bit).Value          = true;
                        getPost.SelectCommand.Parameters.Add("@POST_AUTHOR", SqlDbType.NVarChar).Value      = POST_AUTHOR;


                        LSV_EN.DataSource = SQL.SELECT(getPost);
                        LSV_EN.DataBind();
                        break;
                    }
                default:
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();


                        SqlDataAdapter getPost = new SqlDataAdapter(new SqlCommand(@"SELECT 
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

                                                                                            WHERE       ISDELETE            = @ISDELETE         AND
                                                                                                        ISACTIVE            = @ISACTIVE         AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY    AND      
                                                                                                       
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW     AND
                                                                                                        POST_AUTHOR         = @POST_AUTHOR

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));



                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POST_AUTHOR", SqlDbType.NVarChar).Value = POST_AUTHOR;


                        LSV_AZ.DataSource = SQL.SELECT(getPost);
                        LSV_AZ.DataBind();

                        break;
                    }

            }
        }
        private void GetPosts(string LANGUAGE, string POST_CATEGORY, string POST_SUBCATEGORY, bool POST_ISDELETE, bool POST_ISACTIVE, string POST_AUTHOR, ListView LSV_AZ, ListView LSV_EN)
        {
            switch (LANGUAGE)
            {
                case "az":
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();


                        SqlDataAdapter getPost = new SqlDataAdapter(new SqlCommand(@"SELECT  
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

                                                                                            WHERE       ISDELETE            = @ISDELETE         AND
                                                                                                        ISACTIVE            = @ISACTIVE         AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY    AND      
                                                                                                        POST_SUBCATEGORY    = @POST_SUBCATEGORY AND 
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW     AND
                                                                                                        POST_AUTHOR         = @POST_AUTHOR

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));



                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_SUBCATEGORY", SqlDbType.NVarChar).Value = POST_SUBCATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POST_AUTHOR", SqlDbType.NVarChar).Value = POST_AUTHOR;


                        LSV_AZ.DataSource = SQL.SELECT(getPost);
                        LSV_AZ.DataBind();

                        break;
                    }
                case "en":
                    {
                        LSV_AZ.DataSource = null;
                        LSV_AZ.DataBind();


                        SqlDataAdapter getPost = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                                                        DATA_ID,
                                                                                                        POST_EN_TITLE,
                                                                                                        POST_CATEGORY,
                                                                                            	        POST_SUBCATEGORY,
                                                                                            	        POST_SITECATEGORYEN,
                                                                                                        POST_SITESUBCATEGORYEN,
                                                                                                        POST_IMG,
                                                                                                        POST_DATE,
                                                                                                        POST_SEOEN,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE         AND
                                                                                                        ISACTIVE            = @ISACTIVE         AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY    AND      
                                                                                                        POST_SUBCATEGORY    = @POST_SUBCATEGORY AND 
                                                                                                        POST_EN_VIEW        = @POST_EN_VIEW     AND
                                                                                                        POST_AUTHOR         = @POST_AUTHOR

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));



                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_SUBCATEGORY", SqlDbType.NVarChar).Value = POST_SUBCATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_EN_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POST_AUTHOR", SqlDbType.NVarChar).Value = POST_AUTHOR;


                        LSV_EN.DataSource = SQL.SELECT(getPost);
                        LSV_EN.DataBind();
                        break;
                    }
                default:
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();


                        SqlDataAdapter getPost = new SqlDataAdapter(new SqlCommand(@"SELECT 
                                                                                                        DATA_ID                                 ,
                                                                                                        POST_AZ_TITLE                           ,
                                                                                                        POST_CATEGORY                           ,
                                                                                            	        POST_SUBCATEGORY                        ,
                                                                                            	        POST_SITECATEGORYAZ                     ,
                                                                                                        POST_SITESUBCATEGORYAZ                  ,
                                                                                                        POST_IMG,
                                                                                                        POST_DATE,
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE         AND
                                                                                                        ISACTIVE            = @ISACTIVE         AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY    AND      
                                                                                                        POST_SUBCATEGORY    = @POST_SUBCATEGORY AND 
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW     AND
                                                                                                        POST_AUTHOR         = @POST_AUTHOR

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));


                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value                      = true;
                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value                          = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value                          = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value                = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_SUBCATEGORY", SqlDbType.NVarChar).Value             = POST_SUBCATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_AUTHOR", SqlDbType.NVarChar).Value                  = POST_AUTHOR;


                        LSV_AZ.DataSource = SQL.SELECT(getPost);
                        LSV_AZ.DataBind();

                        break;
                    }

            }


        }
        private void ContentSwitcher(string LANG,string PAGE_DIRECTORY,string PUBLIC_COUNCIL)
        {
            if (string.IsNullOrEmpty(PAGE_DIRECTORY))
            {
                GetPosts(LANG, "multimedia", false, true, PAGE_DIRECTORY, POSTLIST_AZ, POSTLIST_EN);
            }
            else
            {
                GetPosts(LANG, "multimedia", PAGE_DIRECTORY, false, true, PUBLIC_COUNCIL, POSTLIST_AZ, POSTLIST_EN);
            }
        }
        #endregion

        #region(PAGER'S EVENTS)

        protected void POSTLIST_AZ_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_AZ.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            try
            {
                ContentSwitcher(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), Convert.ToString(Page.RouteData.Values["directory"]).ToLower(), Convert.ToString(Page.RouteData.Values["publiccouncil"]).ToLower());
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("Logs", "log.txt")), $"Log created:{DateTime.Now}, Log page is: subsite>> multimedia.aspx page >> ChangeLanguage, Log:{ex.Message}");
            }

        }

        protected void POSTLIST_EN_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_EN.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            try
            {
                ContentSwitcher(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), Convert.ToString(Page.RouteData.Values["directory"]).ToLower(), Convert.ToString(Page.RouteData.Values["publiccouncil"]).ToLower());
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("Logs", "log.txt")), $"Log created:{DateTime.Now}, Log page is: subsite>> multimedia.aspx page >> ChangeLanguage, Log:{ex.Message}");
            }

        }

        #endregion

        private void RunMultmedia(string LANG)
        {
            //CHANGE LANGUAGE
            try
            {
                ChangeLanguage(LANG);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("Logs", "log.txt")), $"Log created:{DateTime.Now}, Log page is: subsite>> multimedia.aspx page >> ChangeLanguage, Log:{ex.Message}");
            }

            //CONTENT SWITCHER
            try
            {
                ContentSwitcher(LANG, Convert.ToString(Page.RouteData.Values["directory"]).ToLower(), Convert.ToString(Page.RouteData.Values["publiccouncil"]).ToLower());
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("Logs", "log.txt")), $"Log created:{DateTime.Now}, Log page is: subsite>> multimedia.aspx page >> ChangeLanguage, Log:{ex.Message}");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //RUN MULTIMEDIA
            try
            {
                RunMultmedia(Convert.ToString(Page.RouteData.Values["language"]).ToLower());
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("Logs", "log.txt")), $"Log created:{DateTime.Now}, Log page is: subsite>> multimedia.aspx page >> RunMultmedia, Log:{ex.Message}");
            }
        }

    }
}