using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PublicCouncilBackEnd
{
    public partial class Main : System.Web.UI.MasterPage
    {
        #region(HELPER FUNCTIONS)

        private void ChangeLanguage(string LANG)
        {
            switch (LANG)
            {
                case "az":
                    {
                        signIN.Text = "Daxil ol";
                        pageName.Text = "İctimai şura";
                        pageName.NavigateUrl = "http://ictimaishura.az";
                        siteRights.Text = $"© Bütün hüquqlar qorunur {DateTime.Now.Year.ToString()}-{(DateTime.Now.Year + 1).ToString()}";
                        break;
                    }
                case "en":
                    {
                        signIN.Text = "Sign in";
                        pageName.Text = "Public council";
                        pageName.NavigateUrl = "http://ictimaishura.az";
                        siteRights.Text = $"© All rights reserved {DateTime.Now.Year.ToString()}-{(DateTime.Now.Year + 1).ToString()}";
                        break;
                    }
                default:
                    {
                        signIN.Text = "Daxil ol";
                        pageName.Text = "İctimai şura";
                        pageName.NavigateUrl = "http://ictimaishura.az";
                        siteRights.Text = $"© Bütün hüquqlar qorunur {DateTime.Now.Year.ToString()}-{(DateTime.Now.Year + 1).ToString()}";
                        break;
                    }
            }
        }

        private void HeaderNav(string LANG)
        {

            Label aboutus = new Label();
            Literal aboutusicon = new Literal();
            Label contactus = new Label();
            Literal contactusicon = new Literal();
            Label search = new Label();
            Literal searchIcon = new Literal();
            switch (LANG)
            {
                case "az":
                    {
                        try
                        {


                            aboutus.Text = "HAQQIMIZDA";
                            aboutus.CssClass = "subnav-link-text";
                            aboutusicon.Text = " <i class='fas fa-address-card text-danger mr-2 d-none d-md-inline'></i>";
                            _aboutus.Controls.Add(aboutusicon);
                            _aboutus.Controls.Add(aboutus);
                            _aboutus.NavigateUrl = "/aboutus/az";


                            contactus.Text = "ƏLAQƏ";
                            contactus.CssClass = "subnav-link-text";
                            contactusicon.Text = " <i class='fas fa-globe text-danger mr-2 d-none d-md-inline'></i>";
                            _contactus.Controls.Add(contactusicon);
                            _contactus.Controls.Add(contactus);
                            _contactus.NavigateUrl = "/contactus/az";

                            search.Text = "Axtar";
                            search.CssClass = "subnav-link-text";
                            searchIcon.Text = " <i class='fas fa-search text-danger mr-2 d-none d-md-inline'></i>";
                            _search.Controls.Add(searchIcon);
                            _search.Controls.Add(search);
                            _search.NavigateUrl = "#";
                            searchBtn.Text = "Axtar";
                            searchModalTitle.Text = "Saytda axtar";
                        }
                        catch
                        {


                        }
                        break;
                    }
                case "en":
                    {

                        aboutus.Text = "ABOUT US";
                        aboutus.CssClass = "subnav-link-text";
                        aboutusicon.Text = " <i class='fas fa-address-card text-danger mr-2 d-none d-md-inline'></i>";
                        _aboutus.Controls.Add(aboutusicon);
                        _aboutus.Controls.Add(aboutus);
                        _aboutus.NavigateUrl = "/aboutus/en";


                        contactus.Text = "CONTACT US";
                        contactus.CssClass = "subnav-link-text";
                        contactusicon.Text = " <i class='fas fa-globe text-danger mr-2 d-none d-md-inline'></i>";
                        _contactus.Controls.Add(contactusicon);
                        _contactus.Controls.Add(contactus);
                        _contactus.NavigateUrl = "/contactus/en";

                        search.Text = "Search";
                        search.CssClass = "subnav-link-text";
                        searchIcon.Text = " <i class='fas fa-search text-danger mr-2 d-none d-md-inline'></i>";
                        _search.Controls.Add(searchIcon);
                        _search.Controls.Add(search);
                        _search.NavigateUrl = "#";
                        searchBtn.Text = "Search";
                        searchModalTitle.Text = "Search in the site";

                        break;
                    }
                default:
                    {
                        try
                        {


                            aboutus.Text = "HAQQIMIZDA";
                            aboutus.CssClass = "subnav-link-text";
                            aboutusicon.Text = " <i class='fas fa-address-card text-danger mr-2 d-none d-md-inline'></i>";
                            _aboutus.Controls.Add(aboutusicon);
                            _aboutus.Controls.Add(aboutus);
                            _aboutus.NavigateUrl = "/aboutus/az";


                            contactus.Text = "ƏLAQƏ";
                            contactus.CssClass = "subnav-link-text";
                            contactusicon.Text = " <i class='fas fa-globe text-danger mr-2 d-none d-md-inline'></i>";
                            _contactus.Controls.Add(contactusicon);
                            _contactus.Controls.Add(contactus);
                            _contactus.NavigateUrl = "/contactus/az";

                            search.Text = "Axtar";
                            search.CssClass = "subnav-link-text";
                            searchIcon.Text = " <i class='fas fa-search text-danger mr-2 d-none d-md-inline'></i>";
                            _search.Controls.Add(searchIcon);
                            _search.Controls.Add(search);
                            _search.NavigateUrl = "#";
                            searchBtn.Text = "Axtar";
                            searchModalTitle.Text = "Saytda axtar";
                        }
                        catch
                        {


                        }
                        break;
                    }
            }

        }

        protected DateTime GetCurrentTime()
        {
            DateTime serverTime = DateTime.Now;
            DateTime _localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverTime, TimeZoneInfo.Local.Id, "Azerbaijan Standard Time");
            return _localTime;
        }

        #endregion

        #region(SQL FUNCTIONS)
        private void GetSocialLinks()
        {
            SqlDataAdapter getSocialLinks = new SqlDataAdapter(new SqlCommand(@"

                                                                            SELECT 
                                                                                   
                                                                                    SOCIAL_LINK_NAME		,
                                                                                    SOCIAL_LINK_URL         ,
                                                                                    SOCIAL_LINK_ICON

                                                                            FROM PC_SOCIAL_LINKS

                                                                            WHERE 
                                                                                    SOCIAL_LINK_ISDELETE = @SOCIAL_LINK_ISDELETE AND
                                                                                    SOCIAL_LINK_ISACTIVE = @SOCIAL_LINK_ISACTIVE
                                                                                                                                "));

            getSocialLinks.SelectCommand.Parameters.Add("@SOCIAL_LINK_ISDELETE", SqlDbType.Bit).Value = false;
            getSocialLinks.SelectCommand.Parameters.Add("@SOCIAL_LINK_ISACTIVE", SqlDbType.Bit).Value = true;

            DataTable DT = SQL.SELECT(getSocialLinks);


            SITE_SOCIAL_FOOTER.DataSource = DT;
            SITE_SOCIAL_FOOTER.DataBind();

        }
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

            dtLogo = null;
        }

        private void GetNavigations(string lang)
        {
            DataTable nav;
            switch (lang)
            {
                case "az":
                    {
                        nav = SQLFUNC.GetNavigations(lang, false, true);
                        NAV_AZ.DataSource = nav;
                        NAV_AZ.DataBind();
                        FOOTER_NAVS_AZ.DataSource = nav;
                        FOOTER_NAVS_AZ.DataBind();
                        break;
                    }
                case "en":
                    {
                        nav = SQLFUNC.GetNavigations(lang, false, true);
                        NAV_EN.DataSource = nav;
                        NAV_EN.DataBind();
                        FOOTER_NAVS_EN.DataSource = nav;
                        FOOTER_NAVS_EN.DataBind();
                        break;
                    }
                default:
                    {
                        nav = SQLFUNC.GetNavigations(lang, false, true);
                        NAV_AZ.DataSource = nav;
                        NAV_AZ.DataBind();
                        FOOTER_NAVS_AZ.DataSource = nav;
                        FOOTER_NAVS_AZ.DataBind();
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
                                                                                                        POST_DATE,
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
                                                                                                        POST_DATE,
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
                                                                                                        POST_DATE,
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
            SqlDataAdapter getPost;
            switch (LANGUAGE)
            {
                case "az":
                    {
                        LSV_EN.DataSource = null;
                        LSV_EN.DataBind();


                       
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
                                                                                                        POST_DATE,
                                                                                                        POST_TYPE,
                                                                                                        POST_SEOEN,
                                                                                                        POST_AUTHOR
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE          AND
                                                                                                        ISACTIVE            = @ISACTIVE          AND
                                                                                                        POST_CATEGORY       = @POST_CATEGORY     AND
                                                                                                        POST_SUBCATEGORY    = @POST_SUBCATEGORY  AND
                                                                                                     
                                                                                                        POST_EN_VIEW        = @POST_EN_VIEW      
                                                                                                    
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

            getPost = null;
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
                                                                                                        POST_CATEGORY       = 'election '      OR
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
                                                                                                        POST_CATEGORY       = 'election '      OR
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
                                                                                                        POST_CATEGORY       = 'election '      OR
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

        #region(CHANGE LANGUAGE BUTTON EVENTS)

        protected void langAZ_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Page.RouteData.Values["postid"] as string))
            {
                Response.Redirect($"https://{Request.Url.Host}/details/az/{Page.RouteData.Values["postid"] as string}");
            }
            else if (HttpContext.Current.Request.Url.ToString().Contains("/az") || HttpContext.Current.Request.Url.ToString().Contains("/en"))
            {
                Response.Redirect($"https://{HttpContext.Current.Request.Url.ToString().Substring(0, HttpContext.Current.Request.Url.ToString().Length - 2).Replace("http://", "")}az");
            }
            else
            {
                Response.Redirect("/home/az");
            }
        }

        protected void langEN_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Page.RouteData.Values["postid"] as string))
            {
                Response.Redirect($"https://{Request.Url.Host}/details/en/{Page.RouteData.Values["postid"] as string}");
            }
            else if (HttpContext.Current.Request.Url.ToString().Contains("/az") || HttpContext.Current.Request.Url.ToString().Contains("/en"))
            {
               
                Response.Redirect($"https://{HttpContext.Current.Request.Url.ToString().Substring(0, HttpContext.Current.Request.Url.ToString().Length - 2).Replace("http://", "")}en");   
            }
            else
            {
                Response.Redirect("/home/en");
            }
        }

        #endregion

        #region(SIGN IN AND SEARCH BUTTON EVENTS)

        protected void signIN_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/login");
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            Session["searchtext"] = searchInput.Text;
            string lang = Convert.ToString(Page.RouteData.Values["language"]).ToLower();
            switch (lang)
            {
                case "az":
                    {
                        Response.Redirect("/search/az");
                        break;
                    }
                case "en":
                    {
                        Response.Redirect("/search/en");

                        break;
                    }
                default:
                    {
                        Response.Redirect("/search/az");
                        break;
                    }
            }


        }

        #endregion

        protected private void RunMainMaster(string LANG)
        {
            //ChangeLanguage
            try
            {
                ChangeLanguage(LANG);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: main master >>  ChangeLanguage method, Log:{ex.Message}");
            }

            //GetLogo
            try
            {
                GetLogo();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: main master >>  GetLogo method, Log:{ex.Message}");
            }

            //GetNavigations
            try
            {
                GetNavigations(LANG);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: main master >>  GetNavigations method, Log:{ex.Message}");
            }

            //GetPosts
            try
            {
                GetPosts(LANG, "4", "announcements", false, true, true, ANNOUNCMENTS_AZ, ANNOUNCMENTS_EN);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: main master >>  GetPosts method, Log:{ex.Message}");
            }

            //GetLatest
            try
            {
                GetLatest(LANG, "10", false, true, true, LATEST_AZ, LATEST_EN);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: main master >>  GetLatest method, Log:{ex.Message}");
            }

            //
            try
            {
                HeaderNav(LANG);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: main master >>  HeaderNav method, Log:{ex.Message}");
            }

            if (!IsPostBack)
            {
                //GetPosts
                try
                {
                    GetPosts(LANG, "4", "election", false, true, true, COUNCILELECTION_AZ, COUNCILELECTION_EN);
                }
                catch (Exception ex)
                {
                    Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: main master >>  GetPosts method, Log:{ex.Message}");
                }

                //GetPosts
                try
                {
                    GetPosts(LANG, "10", "multimedia", "video", false, true, true, VIDEOS_AZ, VIDEOS_EN, false);
                }
                catch (Exception ex)
                {
                    Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: main master >>  GetPosts method, Log:{ex.Message}");
                }

                //GetPartners
                try
                {
                    GetPartners(LANG, "12", false, true, PARTNERS_AZ, PARTNERS_EN);
                }
                catch (Exception ex)
                {
                    Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: main master >>  GetPartners method, Log:{ex.Message}");
                }

                //GetSponsors
                try
                {
                    GetSponsors();
                }
                catch (Exception ex)
                {
                    Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: main master >>  GetSponsors method, Log:{ex.Message}");
                }

            }

            //GetSocialLinks
            try
            {
                GetSocialLinks();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main master >>  GetSocialLinks method, Log:{ex.Message}");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //RunMainMaster
            try
            {
                RunMainMaster(Convert.ToString(Page.RouteData.Values["language"]).ToLower());
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: Main master >>  RunMainMaster method, Log:{ex.Message}");
            }
        }
    }
}