﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PublicCouncilBackEnd.subsite
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        #region(HELPER FUNCTIONS)

        private void ChangeLanguage(string LANG)
        {
            switch (LANG)
            {
                case "az":
                    {
                        pageName.Text = "Xəbərlər";

                        break;
                    }
                case "en":
                    {
                        pageName.Text = "News";
                        break;
                    }
                default:
                    {
                        pageName.Text = "Xəbərlər";
                        break;
                    }

            }
        }

        #endregion

        #region(POST LIST LISTVIEW EVENTS)
        protected void POSTLIST_AZ_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_AZ.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            try
            {
                GetPosts(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), "news", false, true, Convert.ToString(Page.RouteData.Values["publiccouncil"]).ToLower(), POSTLIST_AZ, POSTLIST_EN);

            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: subsite >> posts.aspx page >> GetPosts method, Log:{ex.Message}");
            }
        }

        protected void POSTLIST_EN_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_EN.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            try
            {
                GetPosts(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), "news", false, true, Convert.ToString(Page.RouteData.Values["publiccouncil"]).ToLower(), POSTLIST_AZ, POSTLIST_EN);

            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: subsite >> posts.aspx page >> GetPosts method, Log:{ex.Message}");
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

                                                                                            WHERE       ISDELETE            = @ISDELETE      AND
                                                                                                        ISACTIVE            = @ISACTIVE      AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY AND                                                                                                   
                                                                                                        POST_EN_VIEW        = @POST_EN_VIEW  AND
                                                                                                        POST_AUTHOR         = @POST_AUTHOR

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));



                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
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
        #endregion

        protected private void RunPosts(string LANG, string PC_NAME)
        {
            //ChangeLanguage
            try
            {
                ChangeLanguage(LANG);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: subsite >> posts.aspx page >> ChangeLanguage method, Log:{ex.Message}");
            }

            //GetPosts
            try
            {
                GetPosts(LANG, "news", false, true, PC_NAME, POSTLIST_AZ, POSTLIST_EN);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: subsite >> posts.aspx page >> GetPosts method, Log:{ex.Message}");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //RunPosts
            try
            {
                RunPosts(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), Convert.ToString(Page.RouteData.Values["publiccouncil"]).ToLower());
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: subsite >> posts.aspx page >> RunPost method, Log:{ex.Message}");
            }
        }
    }
}