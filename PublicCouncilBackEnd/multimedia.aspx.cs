﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PublicCouncilBackEnd
{
    public partial class WebForm8 : System.Web.UI.Page
    {

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
                                                                                                        
                                                                                                        POST_EN_VIEW        = @POST_EN_VIEW     AND
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

                                                                                            WHERE       ISDELETE            = @ISDELETE         AND
                                                                                                        ISACTIVE            = @ISACTIVE         AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY    AND      
                                                                                                       
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW     AND
                                                                                                        POST_AUTHOR         = @POST_AUTHOR

                                                                                                        ORDER BY POST_DATE DESCC
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
        private void GetPosts(string LANGUAGE, string POST_CATEGORY, string POST_SUBCATEGORY, bool POST_ISDELETE, bool POST_ISACTIVE, ListView LSV_AZ, ListView LSV_EN)
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
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW     
                                                                                                      

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));



                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_SUBCATEGORY", SqlDbType.NVarChar).Value = POST_SUBCATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;


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
                                                                                                        POST_EN_VIEW        = @POST_EN_VIEW     
                                                                                                       

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));



                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_SUBCATEGORY", SqlDbType.NVarChar).Value = POST_SUBCATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_EN_VIEW", SqlDbType.Bit).Value = true;


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
                                                                                                        POST_SUBCATEGORY    = @POST_SUBCATEGORY AND 
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW     
                                                                                                    

                                                                                                        ORDER BY POST_DATE DESCC
                                                                                                    "));



                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_SUBCATEGORY", SqlDbType.NVarChar).Value = POST_SUBCATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;


                        LSV_AZ.DataSource = SQL.SELECT(getPost);
                        LSV_AZ.DataBind();

                        break;
                    }

            }

          
        }
        private void GetPosts(string LANGUAGE, string POST_CATEGORY, bool POST_ISDELETE, bool POST_ISACTIVE, ListView LSV_AZ, ListView LSV_EN)
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
                                                                                                        POST_SEOAZ
                                                                                                       
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE      AND
                                                                                                        ISACTIVE            = @ISACTIVE      AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY AND                                                                                                   
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW  
                                                                                                    

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));



                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;



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
                                                                                                        POST_EN_VIEW        = @POST_EN_VIEW  
                                                                                                        

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));



                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_EN_VIEW", SqlDbType.Bit).Value = true;



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
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW                                                                                                         

                                                                                                        ORDER BY POST_DATE DESC
                                                                                                    "));



                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;



                        LSV_AZ.DataSource = SQL.SELECT(getPost);
                        LSV_AZ.DataBind();

                        break;
                    }

            }
        }

        private void changeLinksActiveStyle()
        {
            if (HttpContext.Current.Request.Url.ToString().Contains("/multimedia/photo/az") || HttpContext.Current.Request.Url.ToString().Contains("/multimedia/photo/en"))
            {
                postPhoto.CssClass = "btn btn-success w-100 d-flex align-items-center justify-content-center mb-1 mb-md-0";
                postVideo.CssClass = "btn btn-default w-100 d-flex align-items-center justify-content-center mb-1 mb-md-0";
            }
            else if (HttpContext.Current.Request.Url.ToString().Contains("/multimedia/video/az") || HttpContext.Current.Request.Url.ToString().Contains("/multimedia/video/en"))
            {
                postPhoto.CssClass = "btn btn-default w-100 d-flex align-items-center justify-content-center mb-1 mb-md-0";
                postVideo.CssClass = "btn btn-success w-100 d-flex align-items-center justify-content-center mb-1 mb-md-0";

            }
            else
            {
                postPhoto.CssClass = "btn btn-default w-100 d-flex align-items-center justify-content-center mb-1 mb-md-0";
                postVideo.CssClass = "btn btn-default w-100 d-flex align-items-center justify-content-center mb-1 mb-md-0";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            changeLinksActiveStyle();
            switch (Convert.ToString(Page.RouteData.Values["language"]).ToLower())
            {
                case "az":
                    {
                        postsName.Text = "Multimedia";
                        postPhoto.Text = "Foto";
                        postPhoto.NavigateUrl = "/multimedia/photo/az";
                        postVideo.Text = "Video";
                        postVideo.NavigateUrl = "/multimedia/video/az";
                        break;
                    }
                case "en":
                    {
                        postsName.Text = "multimedias";
                        postPhoto.Text = "Photo";
                        postPhoto.NavigateUrl = "/multimedia/photo/en";
                        postVideo.Text = "Video";
                        postVideo.NavigateUrl = "/multimedia/video/en";
                        break;
                    }
                default:
                    {
                        postsName.Text = "multimedia";
                        postPhoto.Text = "Foto";
                        postPhoto.NavigateUrl = "/multimedia/photo/az";
                        postVideo.Text = "Video";
                        postVideo.NavigateUrl = "/multimedia/video/az";
                        break;
                    }
            }
            if (string.IsNullOrEmpty(Page.RouteData.Values["directory"] as string))
            {
                GetPosts(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), "multimedia", false, true,  POSTLIST_AZ, POSTLIST_EN);

            }
            else
            {
                GetPosts(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), "multimedia", Page.RouteData.Values["directory"] as string, false, true, POSTLIST_AZ, POSTLIST_EN);

            }
        }

        protected void POSTLIST_AZ_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            if (Convert.ToString(Page.RouteData.Values["language"]).ToLower() == "az")
            {
                POSTLIST_AZ.Visible = true;
                POSTLIST_EN.Visible = false;
                DataPager_AZ.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            }
            else if (Convert.ToString(Page.RouteData.Values["language"]).ToLower() == "en")
            {
                POSTLIST_EN.Visible = true;
                POSTLIST_AZ.Visible = false;
                DataPager_EN.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            }
            if(string.IsNullOrEmpty(Page.RouteData.Values["directory"] as string))
            {
                GetPosts(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), "multimedia",  false, true,  POSTLIST_AZ, POSTLIST_EN);

            }
            else
            {
                GetPosts(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), "multimedia", Page.RouteData.Values["directory"] as string, false, true,  POSTLIST_AZ, POSTLIST_EN);

            }
        }

        protected void POSTLIST_EN_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            if (Convert.ToString(Page.RouteData.Values["language"]).ToLower() == "az")
            {
                POSTLIST_AZ.Visible = true;
                POSTLIST_EN.Visible = false;
                DataPager_AZ.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            }
            else if (Convert.ToString(Page.RouteData.Values["language"]).ToLower() == "en")
            {
                POSTLIST_AZ.Visible = false;
                POSTLIST_EN.Visible = true;
                DataPager_EN.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            }

            if (string.IsNullOrEmpty(Page.RouteData.Values["directory"] as string))
            {
                GetPosts(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), "multimedia", false, true,  POSTLIST_AZ, POSTLIST_EN);

            }
            else
            {
                GetPosts(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), "multimedia", Page.RouteData.Values["directory"] as string, false, true,  POSTLIST_AZ, POSTLIST_EN);

            }


        }
    }
}