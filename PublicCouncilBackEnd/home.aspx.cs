using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace PublicCouncilBackEnd
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private void GetPosts(string LANGUAGE, string POST_COUNT, string POST_CATEGORY,string POST_SUBCATEGORY, string POST_TYPE, bool POST_ISDELETE, bool POST_ISACTIVE, bool POSTMAIN_VIEW, ListView LSV_AZ, ListView LSV_EN)
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
                                                                                                        POST_DATE,
                                                                                                        POST_TYPE,
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
                                                                                                        POST_DATE,
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE          AND
                                                                                                        ISACTIVE            = @ISACTIVE          AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY     AND
                                                                                                        POST_SUBCATEGORY    = @POST_SUBCATEGORY  AND
                                                                                                        POST_TYPE           = @POST_TYPE         AND
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
                        getPost.SelectCommand.Parameters.Add("@POST_TYPE", SqlDbType.NVarChar).Value = POST_TYPE;

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
                                                                                                        POST_DATE,
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOEN,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE      AND
                                                                                                        ISACTIVE            = @ISACTIVE      AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY AND
                                                                                                        POST_TYPE           = @POST_TYPE     AND
                                                                                                        POST_EN_VIEW        = @POST_EN_VIEW  AND
                                                                                                        POSTMAIN_VIEW         = @POSTMAIN_VIEW
                                                                                                        
                                                                                                        ORDER BY POST_DATE DESC"));
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
                                                                                                       POST_DATE,
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE          AND
                                                                                                        ISACTIVE            = @ISACTIVE          AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY     AND
                                                                                                        POST_SUBCATEGORY    = @POST_SUBCATEGORY  AND
                                                                                                        POST_TYPE           = @POST_TYPE         AND
                                                                                                        POST_EN_VIEW        = @POST_EN_VIEW      AND
                                                                                                        POSTMAIN_VIEW         = @POSTMAIN_VIEW
                                                                                                        ORDER BY POST_DATE DESC"));
                            getPost.SelectCommand.Parameters.Add("@POST_SUBCATEGORY", SqlDbType.NVarChar).Value = POST_SUBCATEGORY;
                        }

                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_EN_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = POSTMAIN_VIEW;
                        getPost.SelectCommand.Parameters.Add("@POST_TYPE", SqlDbType.NVarChar).Value = POST_TYPE;

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
                                                                                                        POST_DATE,
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE      AND
                                                                                                        ISACTIVE            = @ISACTIVE      AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY AND
                                                                                                        POST_TYPE           = @POST_TYPE     AND
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW  AND
                                                                                                        POSTMAIN_VIEW         = @POSTMAIN_VIEW

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
                                                                                                        POST_DATE,
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE          AND
                                                                                                        ISACTIVE            = @ISACTIVE          AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY     AND
                                                                                                        POST_SUBCATEGORY    = @POST_SUBCATEGORY  AND
                                                                                                        POST_TYPE           = @POST_TYPE         AND
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW      AND
                                                                                                        POSTMAIN_VIEW         = @POSTMAIN_VIEW
                                                                                                        ORDER BY POST_DATE DESC"));
                            getPost.SelectCommand.Parameters.Add("@POST_SUBCATEGORY", SqlDbType.NVarChar).Value = POST_SUBCATEGORY;
                        }

                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POSTMAIN_VIEW", SqlDbType.Bit).Value = POSTMAIN_VIEW;
                        getPost.SelectCommand.Parameters.Add("@POST_TYPE", SqlDbType.NVarChar).Value = POST_TYPE;

                        LSV_AZ.DataSource = SQL.SELECT(getPost);
                        LSV_AZ.DataBind();

                        break;
                    }

            }
        }

        private void GetPosts(string LANGUAGE, string POST_COUNT, string POST_CATEGORY, string POST_SUBCATEGORY, string POST_TYPE, bool POST_ISDELETE, bool POST_ISACTIVE,ListView LSV_AZ, ListView LSV_EN)
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
                                                                                                        POST_DATE,
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE      AND
                                                                                                        ISACTIVE            = @ISACTIVE      AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY AND
                                                                                                        POST_TYPE           = @POST_TYPE     AND
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW 
                                                                                                        

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
                                                                                                       POST_DATE,
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE          AND
                                                                                                        ISACTIVE            = @ISACTIVE          AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY     AND
                                                                                                        POST_SUBCATEGORY    = @POST_SUBCATEGORY  AND
                                                                                                        POST_TYPE           = @POST_TYPE         AND
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW     
                                                                                                      
                                                                                                        ORDER BY POST_DATE DESC"));
                            getPost.SelectCommand.Parameters.Add("@POST_SUBCATEGORY", SqlDbType.NVarChar).Value = POST_SUBCATEGORY;
                        }

                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POST_TYPE", SqlDbType.NVarChar).Value = POST_TYPE;

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
                                                                                                       POST_DATE,
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOEN,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE      AND
                                                                                                        ISACTIVE            = @ISACTIVE      AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY AND
                                                                                                        POST_TYPE           = @POST_TYPE     AND
                                                                                                        POST_EN_VIEW        = @POST_EN_VIEW  
                                                                                                        
                                                                                                        ORDER BY POST_DATE DESC"));
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
                                                                                                       POST_DATE,
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE          AND
                                                                                                        ISACTIVE            = @ISACTIVE          AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY     AND
                                                                                                        POST_SUBCATEGORY    = @POST_SUBCATEGORY  AND
                                                                                                        POST_TYPE           = @POST_TYPE         AND
                                                                                                        POST_EN_VIEW        = @POST_EN_VIEW     
                                                                                                        ORDER BY POST_DATE DESC"));
                            getPost.SelectCommand.Parameters.Add("@POST_SUBCATEGORY", SqlDbType.NVarChar).Value = POST_SUBCATEGORY;
                        }

                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_EN_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POST_TYPE", SqlDbType.NVarChar).Value = POST_TYPE;

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
                                                                                                        POST_DATE,
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE      AND
                                                                                                        ISACTIVE            = @ISACTIVE      AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY AND
                                                                                                        POST_TYPE           = @POST_TYPE     AND
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW  
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
                                                                                                        POST_DATE,
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE          AND
                                                                                                        ISACTIVE            = @ISACTIVE          AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY     AND
                                                                                                        POST_SUBCATEGORY    = @POST_SUBCATEGORY  AND
                                                                                                        POST_TYPE           = @POST_TYPE         AND
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW      
                                                                                                        ORDER BY POST_DATE DESC"));
                            getPost.SelectCommand.Parameters.Add("@POST_SUBCATEGORY", SqlDbType.NVarChar).Value = POST_SUBCATEGORY;
                        }

                        getPost.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = POST_ISDELETE;
                        getPost.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = POST_ISACTIVE;
                        getPost.SelectCommand.Parameters.Add("@POST_CATEGORY", SqlDbType.NVarChar).Value = POST_CATEGORY;
                        getPost.SelectCommand.Parameters.Add("@POST_AZ_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POST_TYPE", SqlDbType.NVarChar).Value = POST_TYPE;

                        LSV_AZ.DataSource = SQL.SELECT(getPost);
                        LSV_AZ.DataBind();

                        break;
                    }

            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (HttpContext.Current.Request.Url.ToString().Contains(".ictimaishura.az") &&
               !HttpContext.Current.Request.Url.ToString().Contains("www.ictimaishura.az"))
            {
                Session["pcsubsite"] =
                     HttpContext.Current.Request.Url.ToString()
                    .Substring(0, HttpContext.Current.Request.Url.ToString().IndexOf("."))
                    .Replace("http://", string.Empty);

                    Response.Redirect("/site/home/az");
            }

            GetPosts(Page.RouteData.Values["language"] as string, "4", "news", "","Əsas", false, true,true,MAINSLIDER_AZ,MAINSLIDER_EN);
            GetPosts(Page.RouteData.Values["language"] as string, "4", "news", "","Sağ yuxarı", false, true,  true, RIGHTTOP_AZ, RIGHTTOP_EN);
            GetPosts(Page.RouteData.Values["language"] as string, "4", "news", "","Sağ aşağı",false, true, true, RIGHTBOTTOM_AZ, RIGHTBOTTOM_EN);
            GetPosts(Page.RouteData.Values["language"] as string, "4", "news", "", "Sağ aşağı", false, true, true, RIGHTBOTTOM_AZ, RIGHTBOTTOM_EN);
            GetPosts(Page.RouteData.Values["language"] as string, "6", "news", "", "Sadə", false, true, true, SIMPLEPOSTS_AZ, SIMPLEPOSTS_EN);
            switch (Page.RouteData.Values["language"] as string)
            {
                case "az":
                    {
                        allPosts.PostBackUrl = "/posts/az";
                        allPosts.Text = "bütün xəbərlər";
                        break;
                    }
                case "en":
                    {
                        allPosts.PostBackUrl = "/posts/en";
                        allPosts.Text = "all news";
                        break;
                    }
                default:
                    {
                        allPosts.PostBackUrl = "/posts/az";
                        allPosts.Text = "bütün xəbərlər";
                        break;
                    }
                   
            }
            GetPosts(Page.RouteData.Values["language"] as string, "6", "publications", "", "Sadə", false, true, true, PUBLICATIONS_AZ, PUBLICATIONS_EN);
            GetPosts(Page.RouteData.Values["language"] as string, "6", "reports", "", "Sadə", false, true, true, REPORTS_AZ, REPORTS_EN);
        }
    }
}