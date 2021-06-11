using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace PublicCouncilBackEnd.subsite
{
    public partial class Subdomain : System.Web.UI.MasterPage
    {
        #region(HELPER FUNCTIONS)
        private void ChangeLanguage(string LANG)
        {

            switch (LANG)
            {
                case "az":
                    {
                        signIN.Text             = "Daxil ol";
                        pageName.Text           = "İctimai şura";
                        pageName.NavigateUrl    = "http://ictimaishura.az";
                        siteRights.Text         = $"©Bütün hüquqlar qorunur {DateTime.Now.Year.ToString()}-{(DateTime.Now.Year + 1).ToString()}";
                        break;
                    }
                case "en":
                    {
                        signIN.Text             = "Sign in";
                        pageName.Text           = "Public council";
                        pageName.NavigateUrl    = "http://ictimaishura.az";
                        siteRights.Text         = $"© All rights reserved {DateTime.Now.Year.ToString()}-{(DateTime.Now.Year + 1).ToString()}";
                        break;
                    }
                default:
                    {
                        signIN.Text             = "Daxil ol";
                        pageName.Text           = "İctimai şura";
                        pageName.NavigateUrl    = "http://ictimaishura.az";
                        siteRights.Text         = $"©Bütün hüquqlar qorunur {DateTime.Now.Year.ToString()}-{(DateTime.Now.Year + 1).ToString()}";
                        break;
                    }
            }

        }
        #endregion

        #region(SQL FUNCTIONS)
        private string GetPcSerial(string PC_DOMAIN_NAME)
        {
            SqlDataAdapter getSerial = new SqlDataAdapter(new SqlCommand(@"SELECT USER_SERIAL FROM PC_USERS WHERE ISDELETE = @ISDELETE AND ISACTIVE = @ISACTIVE AND USER_PCDOMAIN = @USER_PCDOMAIN"));

            getSerial.SelectCommand.Parameters.Add(@"ISDELETE", SqlDbType.Bit).Value                = false;
            getSerial.SelectCommand.Parameters.Add(@"ISACTIVE", SqlDbType.Bit).Value                = true;
            getSerial.SelectCommand.Parameters.Add(@"USER_PCDOMAIN", SqlDbType.NVarChar).Value      = PC_DOMAIN_NAME;

            return SQL.SELECT(getSerial).Rows[0]["USER_SERIAL"].ToString();
        }
        private void GetUserInfo(string LANG, string USER_PCDOMAIN)
        {
            SqlDataAdapter getSerial;
            DataTable dt = null;

            switch (LANG)
            {
                case "az":
                    {

                        getSerial = new SqlDataAdapter(new SqlCommand(@"SELECT USER_SERIAL ,PC_NAME, PC_ACTIVITY_PERIOD, USER_ID , USER_PCDOMAIN FROM PC_USERS 
                                                                                                 WHERE 
                                                                                                 ISDELETE      = @ISDELETE AND 
                                                                                                 ISACTIVE      = @ISACTIVE AND
                                                                                                 USER_PCDOMAIN = @USER_PCDOMAIN"));
                        getSerial.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getSerial.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getSerial.SelectCommand.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value = USER_PCDOMAIN;

                        dt = SQL.SELECT(getSerial);

                        Page.Title                                              = dt.Rows[0]["PC_NAME"].ToString();
                        pcName.Text                                             = dt.Rows[0]["PC_NAME"].ToString();
                        Session["PC_USER_ID"]                                   = dt.Rows[0]["USER_ID"].ToString();
                        Session["SUBSITE_SERIAL"]                               = dt.Rows[0]["USER_SERIAL"].ToString();
                        Session["PC_ACTIVITY_PERIOD"]                           = dt.Rows[0]["PC_ACTIVITY_PERIOD"].ToString();
                        break;
                    }
                case "en":
                    {
                        getSerial = new SqlDataAdapter(new SqlCommand(@"SELECT USER_SERIAL ,PC_NAME_EN, PC_ACTIVITY_PERIOD, USER_ID , USER_PCDOMAIN FROM PC_USERS 
                                                                                                 WHERE 
                                                                                                 ISDELETE      = @ISDELETE AND 
                                                                                                 ISACTIVE      = @ISACTIVE AND
                                                                                                 USER_PCDOMAIN = @USER_PCDOMAIN"));
                        getSerial.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getSerial.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getSerial.SelectCommand.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value = USER_PCDOMAIN;
                        
                        dt = SQL.SELECT(getSerial);

                        Page.Title = dt.Rows[0]["PC_NAME_EN"].ToString();
                        pcName.Text = dt.Rows[0]["PC_NAME_EN"].ToString();
                        Session["PC_USER_ID"] = dt.Rows[0]["USER_ID"].ToString();
                        Session["SUBSITE_SERIAL"] = dt.Rows[0]["USER_SERIAL"].ToString();
                        Session["PC_ACTIVITY_PERIOD"] = dt.Rows[0]["PC_ACTIVITY_PERIOD"].ToString();
                        break;
                    }
                default:
                    {

                        getSerial = new SqlDataAdapter(new SqlCommand(@"SELECT USER_SERIAL ,PC_NAME, PC_ACTIVITY_PERIOD, USER_ID , USER_PCDOMAIN FROM PC_USERS 
                                                                                                 WHERE 
                                                                                                 ISDELETE      = @ISDELETE AND 
                                                                                                 ISACTIVE      = @ISACTIVE AND
                                                                                                 USER_PCDOMAIN = @USER_PCDOMAIN"));
                        getSerial.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
                        getSerial.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
                        getSerial.SelectCommand.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value = USER_PCDOMAIN;

                        dt = SQL.SELECT(getSerial);

                        Page.Title = dt.Rows[0]["PC_NAME"].ToString();
                        pcName.Text = dt.Rows[0]["PC_NAME"].ToString();
                        Session["PC_USER_ID"] = dt.Rows[0]["USER_ID"].ToString();
                        Session["SUBSITE_SERIAL"] = dt.Rows[0]["USER_SERIAL"].ToString();
                        Session["PC_ACTIVITY_PERIOD"] = dt.Rows[0]["PC_ACTIVITY_PERIOD"].ToString();
                        break;
                    }

            }

            getSerial = null;
            dt = null;

        }

        private DataTable GetLogo(string USER_SERIAL)
        {
            SqlDataAdapter getLogo = new SqlDataAdapter(new SqlCommand(@"SELECT TOP 1 LOGO_TITLE , LOGO_IMG FROM PC_SITELOGOS
                                                                                WHERE 
                                                                                            ISDELETE    = @ISDELETE AND
                                                                                            ISACTIVE    = @ISACTIVE AND
                                                                                            LOGO_SERIAL = @LOGO_SERIAL ORDER BY DATA_ID DESC"));

            getLogo.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            getLogo.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            getLogo.SelectCommand.Parameters.Add("@LOGO_SERIAL", SqlDbType.NVarChar).Value = USER_SERIAL;

            return SQL.SELECT(getLogo);

        }

        private void GetLogos(string PC_SERIAL)
        {
            /*
            //we have a pc domain name
            //1. getting USER SERIAL code using pc domain name
            //2.getting logo using USER SERIAL
           */

            //Get Main Logo
            LogoDesktop.DataSource = SQLFUNC.GetLogo("1", false, true);
            LogoDesktop.DataBind();

            //Get Sub PC logo

            logoPc.DataSource = GetLogo(PC_SERIAL);
            logoPc.DataBind();
        }

        private void Navigation()
        {
            Label home = new Label();
            Literal homeicon = new Literal();
            Label news = new Label();
            Literal newsicon = new Literal();
            Label projects = new Label();
            Literal projectsicon = new Literal();
            Label legislation = new Label();
            Literal legislationicon = new Literal();
            Label publications = new Label();
            Literal publicationsicon = new Literal();
            Label reports = new Label();
            Literal reportsicon = new Literal();
            Label multimedia = new Label();
            Literal multimediaicon = new Literal();
            Label aboutus = new Label();
            Literal aboutusicon = new Literal();
            Label contactus = new Label();
            Literal contactusicon = new Literal();
            Label member = new Label();
            Literal membericon = new Literal();
            switch (Convert.ToString(Page.RouteData.Values["language"]).ToLower())
            {
                case "az":
                    {
                        try
                        {

                            home.Text = "ANA SƏHİFƏ";
                            home.CssClass = "subnav-link-text";
                            homeicon.Text = " <i class='fas fa-home text-danger mr-2'></i>";
                            _home.Controls.Add(homeicon);
                            _home.Controls.Add(home);
                            _home.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/home/az";

                            aboutus.Text = "HAQQIMIZDA";
                            aboutus.CssClass = "subnav-link-text";
                            aboutusicon.Text = " <i class='fas fa-address-card text-danger mr-2'></i>";
                            _aboutus.Controls.Add(aboutusicon);
                            _aboutus.Controls.Add(aboutus);
                            _aboutus.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/aboutus/az";

                            member.Text = "ŞURA ÜZVLƏRİ";
                            member.CssClass = "subnav-link-text";
                            membericon.Text = " <i class='fas fa-users text-danger mr-2'></i>";
                            _members.Controls.Add(membericon);
                            _members.Controls.Add(member);
                            _members.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/members/az";

                            news.Text = "XƏBƏRLƏR";
                            news.CssClass = "subnav-link-text";
                            newsicon.Text = " <i class='fas fa-newspaper text-danger mr-2'></i>";
                            _news.Controls.Add(newsicon);
                            _news.Controls.Add(news);
                            _news.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/posts/az";

                            projects.Text = "ELANLAR";
                            projects.CssClass = "subnav-link-text";
                            projectsicon.Text = "<i class='fas fa-project-diagram text-danger mr-2'></i>";
                            _projects.Controls.Add(projectsicon);
                            _projects.Controls.Add(projects);
                            _projects.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/announcements/az";


                            legislation.Text = "QANUNVERİCİLİK";
                            legislation.CssClass = "subnav-link-text";
                            legislationicon.Text = " <i class='fas fa-gavel text-danger mr-2'></i>";
                            _legilations.Controls.Add(legislationicon);
                            _legilations.Controls.Add(legislation);
                            _legilations.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/legislation/az";






                            reports.Text = "HESABATLAR";
                            reports.CssClass = "subnav-link-text";
                            reportsicon.Text = " <i class='fas fa-flag text-danger mr-2'></i>";
                            _reports.Controls.Add(reportsicon);
                            _reports.Controls.Add(reports);
                            _reports.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/reports/az";


                            publications.Text = "NƏŞRLƏR";
                            publications.CssClass = "subnav-link-text";
                            publicationsicon.Text = " <i class='fas fa-book-open text-danger mr-2'></i>";
                            _publications.Controls.Add(publicationsicon);
                            _publications.Controls.Add(publications);
                            _publications.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/publications/az";


                            multimedia.Text = "MULTİMEDİA";
                            multimedia.CssClass = "subnav-link-text";
                            multimediaicon.Text = " <i class='fas fa-photo-video text-danger mr-2'></i>";
                            _multimedia.Controls.Add(multimediaicon);
                            _multimedia.Controls.Add(multimedia);
                            _multimedia.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/multimedia/az";


                            contactus.Text = "ƏLAQƏ";
                            contactus.CssClass = "subnav-link-text";
                            contactusicon.Text = " <i class='fas fa-globe text-danger mr-2'></i>";
                            _contactus.Controls.Add(contactusicon);
                            _contactus.Controls.Add(contactus);
                            _contactus.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/contactus/az";

                        }
                        catch
                        {


                        }
                        break;
                    }
                case "en":
                    {

                        home.Text = "HOME";
                        home.CssClass = "subnav-link-text";
                        homeicon.Text = " <i class='fas fa-home text-danger mr-2'></i>";
                        _home.Controls.Add(homeicon);
                        _home.Controls.Add(home);
                        _home.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/home/en";

                        aboutus.Text = "ABOUT US";
                        aboutus.CssClass = "subnav-link-text";
                        aboutusicon.Text = " <i class='fas fa-address-card text-danger mr-2'></i>";
                        _aboutus.Controls.Add(aboutusicon);
                        _aboutus.Controls.Add(aboutus);
                        _aboutus.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/aboutus/en";


                        member.Text = "Members";
                        member.CssClass = "subnav-link-text";
                        membericon.Text = " <i class='fas fa-users text-danger mr-2'></i>";
                        _members.Controls.Add(membericon);
                        _members.Controls.Add(member);
                        _members.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/members/en";

                        news.Text = "NEWS";
                        news.CssClass = "subnav-link-text";
                        newsicon.Text = " <i class='fas fa-newspaper text-danger mr-2'></i>";
                        _news.Controls.Add(newsicon);
                        _news.Controls.Add(news);
                        _news.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/posts/en";

                        projects.Text = "ANNOUNCEMENTS";
                        projects.CssClass = "subnav-link-text";
                        projectsicon.Text = "<i class='fas fa-project-diagram text-danger mr-2'></i>";
                        _projects.Controls.Add(projectsicon);
                        _projects.Controls.Add(projects);
                        _projects.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/announcements/en";


                        legislation.Text = "LEGISLATION";
                        legislation.CssClass = "subnav-link-text";
                        legislationicon.Text = " <i class='fas fa-gavel text-danger mr-2'></i>";
                        _legilations.Controls.Add(legislationicon);
                        _legilations.Controls.Add(legislation);
                        _legilations.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/legislation/en";

                        reports.Text = "REPORTS";
                        reports.CssClass = "subnav-link-text";
                        reportsicon.Text = " <i class='fas fa-flag text-danger mr-2'></i>";
                        _reports.Controls.Add(reportsicon);
                        _reports.Controls.Add(reports);
                        _reports.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/reports/en";


                        publications.Text = "PUBLICATIONS";
                        publications.CssClass = "subnav-link-text";
                        publicationsicon.Text = " <i class='fas fa-book-open text-danger mr-2'></i>";
                        _publications.Controls.Add(publicationsicon);
                        _publications.Controls.Add(publications);
                        _publications.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/publications/en";


                        multimedia.Text = "MULTIMEDIA";
                        multimedia.CssClass = "subnav-link-text";
                        multimediaicon.Text = " <i class='fas fa-photo-video text-danger mr-2'></i>";
                        _multimedia.Controls.Add(multimediaicon);
                        _multimedia.Controls.Add(multimedia);
                        _multimedia.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/multimedia/en";



                        contactus.Text = "CONTACT US";
                        contactus.CssClass = "subnav-link-text";
                        contactusicon.Text = " <i class='fas fa-globe text-danger mr-2'></i>";
                        _contactus.Controls.Add(contactusicon);
                        _contactus.Controls.Add(contactus);
                        _contactus.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/contactus/en";


                        break;
                    }
                default:
                    {
                        try
                        {

                            home.Text = "ANA SƏHİFƏ";
                            home.CssClass = "subnav-link-text";
                            homeicon.Text = " <i class='fas fa-home text-danger mr-2'></i>";
                            _home.Controls.Add(homeicon);
                            _home.Controls.Add(home);
                            _home.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/home/az";

                            aboutus.Text = "HAQQIMIZDA";
                            aboutus.CssClass = "subnav-link-text";
                            aboutusicon.Text = " <i class='fas fa-address-card text-danger mr-2'></i>";
                            _aboutus.Controls.Add(aboutusicon);
                            _aboutus.Controls.Add(aboutus);
                            _aboutus.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/aboutus/az";

                            member.Text = "ŞURA ÜZVLƏRİ";
                            member.CssClass = "subnav-link-text";
                            membericon.Text = " <i class='fas fa-users text-danger mr-2'></i>";
                            _members.Controls.Add(membericon);
                            _members.Controls.Add(member);
                            _members.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/members/az";

                            news.Text = "XƏBƏRLƏR";
                            news.CssClass = "subnav-link-text";
                            newsicon.Text = " <i class='fas fa-newspaper text-danger mr-2'></i>";
                            _news.Controls.Add(newsicon);
                            _news.Controls.Add(news);
                            _news.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/posts/az";

                            projects.Text = "ELANLAR";
                            projects.CssClass = "subnav-link-text";
                            projectsicon.Text = "<i class='fas fa-project-diagram text-danger mr-2'></i>";
                            _projects.Controls.Add(projectsicon);
                            _projects.Controls.Add(projects);
                            _projects.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/announcements/az";


                            legislation.Text = "QANUNVERİCİLİK";
                            legislation.CssClass = "subnav-link-text";
                            legislationicon.Text = " <i class='fas fa-gavel text-danger mr-2'></i>";
                            _legilations.Controls.Add(legislationicon);
                            _legilations.Controls.Add(legislation);
                            _legilations.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/legislation/az";






                            reports.Text = "HESABATLAR";
                            reports.CssClass = "subnav-link-text";
                            reportsicon.Text = " <i class='fas fa-flag text-danger mr-2'></i>";
                            _reports.Controls.Add(reportsicon);
                            _reports.Controls.Add(reports);
                            _reports.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/reports/az";


                            publications.Text = "NƏŞRLƏR";
                            publications.CssClass = "subnav-link-text";
                            publicationsicon.Text = " <i class='fas fa-book-open text-danger mr-2'></i>";
                            _publications.Controls.Add(publicationsicon);
                            _publications.Controls.Add(publications);
                            _publications.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/publications/az";


                            multimedia.Text = "MULTİMEDİA";
                            multimedia.CssClass = "subnav-link-text";
                            multimediaicon.Text = " <i class='fas fa-photo-video text-danger mr-2'></i>";
                            _multimedia.Controls.Add(multimediaicon);
                            _multimedia.Controls.Add(multimedia);
                            _multimedia.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/multimedia/az";


                            contactus.Text = "ƏLAQƏ";
                            contactus.CssClass = "subnav-link-text";
                            contactusicon.Text = " <i class='fas fa-globe text-danger mr-2'></i>";
                            _contactus.Controls.Add(contactusicon);
                            _contactus.Controls.Add(contactus);
                            _contactus.NavigateUrl = $"/{Page.RouteData.Values["publiccouncil"] as string}/contactus/az";

                        }
                        catch
                        {


                        }
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

        private void GetNavigations(string lang)
        {
            DataTable nav;
            switch (lang)
            {
                case "az":
                    {
                        nav = SQLFUNC.GetNavigations(lang, false, true);
                      
                        FOOTER_NAVS_AZ.DataSource = nav;
                        FOOTER_NAVS_AZ.DataBind();
                        break;
                    }
                case "en":
                    {
                        nav = SQLFUNC.GetNavigations(lang, false, true);
                       
                        FOOTER_NAVS_EN.DataSource = nav;
                        FOOTER_NAVS_EN.DataBind();
                        break;
                    }
                default:
                    {
                        nav = SQLFUNC.GetNavigations(lang, false, true);
                      
                        FOOTER_NAVS_AZ.DataSource = nav;
                        FOOTER_NAVS_AZ.DataBind();
                        break;
                    }
            }
            nav = null;
        }

        private void GetLatest(string LANGUAGE, string POST_COUNT, string POST_CATEGORY, bool POST_ISDELETE, bool POST_ISACTIVE, string POST_AUTHOR, ListView LSV_AZ, ListView LSV_EN)
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
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                                       
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE      AND
                                                                                                        ISACTIVE            = @ISACTIVE      AND
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW  AND
                                                                                                        POST_AUTHOR         = @POST_AUTHOR   AND

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
                        getPost.SelectCommand.Parameters.Add("@POST_AUTHOR", SqlDbType.NVarChar).Value = POST_AUTHOR;


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
                                                                                                        POST_AZ_TITLE,
                                                                                            	        POST_SITECATEGORYEN,
                                                                                                        POST_IMG,
                                                                                                        POST_DATE,
                                                                                                        POST_SEOEN,
                                                                                                        POST_AUTHOR
                                                                                                    
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE      AND
                                                                                                        ISACTIVE            = @ISACTIVE      AND
                                                                                                        POST_EN_VIEW        = @POST_EN_VIEW  AND
                                                                                                        POST_AUTHOR         = @POST_AUTHOR   AND

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
                        getPost.SelectCommand.Parameters.Add("@POST_EN_VIEW", SqlDbType.Bit).Value = true;
                        getPost.SelectCommand.Parameters.Add("@POST_AUTHOR", SqlDbType.NVarChar).Value = POST_AUTHOR;


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
                                                                                                        POST_SEOAZ,
                                                                                                        POST_AUTHOR
                                                                                                       
                                                                                            FROM        PC_POSTS

                                                                                            WHERE       ISDELETE            = @ISDELETE      AND
                                                                                                        ISACTIVE            = @ISACTIVE      AND
                                                                                                        POST_AZ_VIEW        = @POST_AZ_VIEW  AND
                                                                                                        POST_AUTHOR         = @POST_AUTHOR   AND

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
                        getPost.SelectCommand.Parameters.Add("@POST_AUTHOR", SqlDbType.NVarChar).Value = POST_AUTHOR;


                        LSV_AZ.DataSource = SQL.SELECT(getPost);
                        LSV_AZ.DataBind();
                        getPost = null;
                        break;
                    }

            }
        }
        #endregion

        #region(CHANGE LANGUAGE BUTTON'S EVENTS)
        protected void langAZ_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(Page.RouteData.Values["postid"] as string))
            {
                Response.Redirect($"/{Page.RouteData.Values["publiccouncil"] as string}/details/az/{Page.RouteData.Values["postid"] as string}");
            }
            else if (!string.IsNullOrEmpty(Page.RouteData.Values["memberid"] as string))
            {
                Response.Redirect($"/{Page.RouteData.Values["publiccouncil"] as string}/memberdetail/az/{Page.RouteData.Values["memberid"] as string}");
            }
            else if(HttpContext.Current.Request.Url.ToString().Contains("/az") || HttpContext.Current.Request.Url.ToString().Contains("/en"))
            {
                Response.Redirect(HttpContext.Current.Request.Url.ToString().Substring(0, HttpContext.Current.Request.Url.ToString().Length - 2) + "az");
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
                Response.Redirect($"/{Page.RouteData.Values["publiccouncil"] as string}/details/en/{Page.RouteData.Values["postid"] as string}");
            }
            else if (!string.IsNullOrEmpty(Page.RouteData.Values["memberid"] as string))
            {
                Response.Redirect($"/{Page.RouteData.Values["publiccouncil"] as string}/memberdetail/en/{Page.RouteData.Values["memberid"] as string}");
            }
            else if (HttpContext.Current.Request.Url.ToString().Contains("/en") || HttpContext.Current.Request.Url.ToString().Contains("/az"))
            {
                Response.Redirect(HttpContext.Current.Request.Url.ToString().Substring(0, HttpContext.Current.Request.Url.ToString().Length - 2) + "en");
            }
            else
            {
                Response.Redirect("/home/en");
            }
        }
        #endregion

        protected private void RunSubMaster(string LANG,string PC_NAME)
        {
            //GetUserInfo
            try
            {
                GetUserInfo(LANG, PC_NAME);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: subsite master >> GetUserInfo method, Log:{ex.Message}");
            }

            //Navigation
            try
            {
                Navigation();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: subsite master >> Navigation method, Log:{ex.Message}");
            }

            //GetLogos
            try
            {
                GetLogos(GetPcSerial(PC_NAME));
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: subsite master >> GetLogos method, Log:{ex.Message}");
            }

            //ChangeLanguage
            try
            {
                ChangeLanguage(LANG);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: subsite master >> GetLogos method, Log:{ex.Message}");
            }

            //GetNavigations
            try
            {
                GetNavigations(LANG);
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: subsite master >> GetLogos method, Log:{ex.Message}");
            }

            //GetSponsors
            try
            {
                GetSponsors();
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: subsite master >> GetSponsors method, Log:{ex.Message}");
            }

            //GetLatest
            try
            {
                GetLatest(LANG, "4", "news", false, true, PC_NAME, LATEST_AZ, LATEST_EN);

            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: subsite master >> GetLatest method, Log:{ex.Message}");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                RunSubMaster(Convert.ToString(Page.RouteData.Values["language"]).ToLower(), Convert.ToString(Page.RouteData.Values["publiccouncil"]).ToLower());
            }
            catch (Exception ex)
            {
                Log.LogCreator(Server.MapPath(Path.Combine("~/Logs", "logs.txt")), $"Log created:{DateTime.Now}, Log page is: subsite master >> GetLatest method, Log:{ex.Message}");
            }
        }

        protected void signIN_Click(object sender, EventArgs e)
        {
            Response.Redirect("/login");
        }
    }
}