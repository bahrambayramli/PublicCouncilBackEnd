using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PublicCouncilBackEnd.subsite
{
    public partial class Subdomain : System.Web.UI.MasterPage
    {
        
        private string GetUserInfo(string USER_PCDOMAIN)
        {
            SqlDataAdapter getSerial = new SqlDataAdapter(new SqlCommand(@"SELECT USER_SERIAL ,PC_NAME FROM PC_USERS 
                                                                                                 WHERE 
                                                                                                 ISDELETE      = @ISDELETE AND 
                                                                                                 ISACTIVE      = @ISACTIVE AND
                                                                                                 USER_PCDOMAIN = @USER_PCDOMAIN"));
            getSerial.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            getSerial.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            getSerial.SelectCommand.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value = USER_PCDOMAIN;

            DataTable dt = SQL.SELECT(getSerial);

            Page.Title = dt.Rows[0]["PC_NAME"].ToString();
            return dt.Rows[0]["USER_SERIAL"].ToString(); ;
        }

        private DataTable GetLogo(string USER_SERIAL)
        {
            SqlDataAdapter getLogo = new SqlDataAdapter(new SqlCommand(@"SELECT LOGO_TITLE , LOGO_IMG FROM PC_SITELOGOS
                                                                                WHERE 
                                                                                            ISDELETE = @ISDELETE AND
                                                                                            ISACTIVE = @ISACTIVE AND
                                                                                            LOGO_SERIAL = @LOGO_SERIAL"));

            getLogo.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            getLogo.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            getLogo.SelectCommand.Parameters.Add("@LOGO_SERIAL", SqlDbType.NVarChar).Value = USER_SERIAL;

            return SQL.SELECT(getLogo);
           
        }

        private void GetLogos()
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
          
            logoPcMobile.DataSource = GetLogo(GetUserInfo(Session["pcsubsite"] as string)); ;
            logoPcMobile.DataBind();
           
          


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
                            _home.NavigateUrl = "/site/home/az";

                          
                            news.Text = "XƏBƏRLƏR";
                            news.CssClass = "subnav-link-text";
                            newsicon.Text = " <i class='fas fa-newspaper text-danger mr-2'></i>";
                            _news.Controls.Add(newsicon);
                            _news.Controls.Add(news);
                            _news.NavigateUrl = "/site/posts/az";

                           
                            projects.Text = "ELANLAR";
                            projects.CssClass = "subnav-link-text";
                            projectsicon.Text = "<i class='fas fa-project-diagram text-danger mr-2'></i>";
                            _projects.Controls.Add(projectsicon);
                            _projects.Controls.Add(projects);
                            _projects.NavigateUrl = "/site/announcements/az";

                           
                            legislation.Text = "QANUNVERİCİLİK";
                            legislation.CssClass = "subnav-link-text";
                            legislationicon.Text = " <i class='fas fa-gavel text-danger mr-2'></i>";
                            _legilations.Controls.Add(legislationicon);
                            _legilations.Controls.Add(legislation);
                            _legilations.NavigateUrl = "/site/legislation/az";



                          
                            publications.Text = "NƏŞRLƏR";
                            publications.CssClass = "subnav-link-text";
                            publicationsicon.Text = " <i class='fas fa-book-open text-danger mr-2'></i>";
                            _publications.Controls.Add(publicationsicon);
                            _publications.Controls.Add(publications);
                            _publications.NavigateUrl = "/site/publications/az";

                          
                            reports.Text = "HESABATLAR";
                            reports.CssClass = "subnav-link-text";
                            reportsicon.Text = " <i class='fas fa-flag text-danger mr-2'></i>";
                            _reports.Controls.Add(reportsicon);
                            _reports.Controls.Add(reports);
                            _reports.NavigateUrl = "/site/reports/az";

                          
                            multimedia.Text = "MULTİMEDİA";
                            multimedia.CssClass = "subnav-link-text";
                            multimediaicon.Text = " <i class='fas fa-photo-video text-danger mr-2'></i>";
                            _multimedia.Controls.Add(multimediaicon);
                            _multimedia.Controls.Add(multimedia);
                            _multimedia.NavigateUrl = "/site/multimedia/az";


                            aboutus.Text = "HAQQIMIZDA";
                            aboutus.CssClass = "subnav-link-text";
                            aboutusicon.Text = " <i class='fas fa-address-card text-danger mr-2'></i>";
                            _aboutus.Controls.Add(aboutusicon);
                            _aboutus.Controls.Add(aboutus);
                            _aboutus.NavigateUrl = "/site/aboutus/az";


                            contactus.Text = "ƏLAQƏ";
                            contactus.CssClass = "subnav-link-text";
                            contactusicon.Text = " <i class='fas fa-globe text-danger mr-2'></i>";
                            _contactus.Controls.Add(contactusicon);
                            _contactus.Controls.Add(contactus);
                            _contactus.NavigateUrl = "/site/contactus/az";

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
                            _home.NavigateUrl = "/site/home/en";

                           
                            news.Text = "NEWS";
                            news.CssClass = "subnav-link-text";
                            newsicon.Text = " <i class='fas fa-newspaper text-danger mr-2'></i>";
                            _news.Controls.Add(newsicon);
                            _news.Controls.Add(news);
                            _news.NavigateUrl = "/site/posts/en";

                           
                            projects.Text = "ANNOUNCEMENTS";
                            projects.CssClass = "subnav-link-text";
                            projectsicon.Text = "<i class='fas fa-project-diagram text-danger mr-2'></i>";
                            _projects.Controls.Add(projectsicon);
                            _projects.Controls.Add(projects);
                            _projects.NavigateUrl = "/site/announcements/en";

                            
                            legislation.Text = "LEGISLATION";
                            legislation.CssClass = "subnav-link-text";
                            legislationicon.Text = " <i class='fas fa-gavel text-danger mr-2'></i>";
                            _legilations.Controls.Add(legislationicon);
                            _legilations.Controls.Add(legislation);
                            _legilations.NavigateUrl = "/site/legislation/en";



                            
                            publications.Text = "PUBLICATIONS";
                            publications.CssClass = "subnav-link-text";
                            publicationsicon.Text = " <i class='fas fa-book-open text-danger mr-2'></i>";
                            _publications.Controls.Add(publicationsicon);
                            _publications.Controls.Add(publications);
                            _publications.NavigateUrl = "/site/publications/en";

                         
                            reports.Text = "REPORTS";
                            reports.CssClass = "subnav-link-text";
                            reportsicon.Text = " <i class='fas fa-flag text-danger mr-2'></i>";
                            _reports.Controls.Add(reportsicon);
                            _reports.Controls.Add(reports);
                            _reports.NavigateUrl = "/site/reports/en";

                         
                            multimedia.Text = "MULTIMEDIA";
                            multimedia.CssClass = "subnav-link-text";
                            multimediaicon.Text = " <i class='fas fa-photo-video text-danger mr-2'></i>";
                            _multimedia.Controls.Add(multimediaicon);
                            _multimedia.Controls.Add(multimedia);
                            _multimedia.NavigateUrl = "/site/multimedia/en";


                        aboutus.Text = "ABOUT US";
                        aboutus.CssClass = "subnav-link-text";
                        aboutusicon.Text = " <i class='fas fa-address-card text-danger mr-2'></i>";
                        _aboutus.Controls.Add(aboutusicon);
                        _aboutus.Controls.Add(aboutus);
                        _aboutus.NavigateUrl = "/site/aboutus/en";


                        contactus.Text = "CONTACT US";
                        contactus.CssClass = "subnav-link-text";
                        contactusicon.Text = " <i class='fas fa-globe text-danger mr-2'></i>";
                        _contactus.Controls.Add(contactusicon);
                        _contactus.Controls.Add(contactus);
                        _contactus.NavigateUrl = "/site/contactus/en";


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
                            _home.NavigateUrl = "/site/home/az";


                            news.Text = "XƏBƏRLƏR";
                            news.CssClass = "subnav-link-text";
                            newsicon.Text = " <i class='fas fa-newspaper text-danger mr-2'></i>";
                            _news.Controls.Add(newsicon);
                            _news.Controls.Add(news);
                            _news.NavigateUrl = "/site/posts/az";


                            projects.Text = "ELANLAR";
                            projects.CssClass = "subnav-link-text";
                            projectsicon.Text = "<i class='fas fa-project-diagram text-danger mr-2'></i>";
                            _projects.Controls.Add(projectsicon);
                            _projects.Controls.Add(projects);
                            _projects.NavigateUrl = "/site/announcements/az";


                            legislation.Text = "QANUNVERİCİLİK";
                            legislation.CssClass = "subnav-link-text";
                            legislationicon.Text = " <i class='fas fa-gavel text-danger mr-2'></i>";
                            _legilations.Controls.Add(legislationicon);
                            _legilations.Controls.Add(legislation);
                            _legilations.NavigateUrl = "/site/legislation/az";




                            publications.Text = "NƏŞRLƏR";
                            publications.CssClass = "subnav-link-text";
                            publicationsicon.Text = " <i class='fas fa-book-open text-danger mr-2'></i>";
                            _publications.Controls.Add(publicationsicon);
                            _publications.Controls.Add(publications);
                            _publications.NavigateUrl = "/site/publications/az";


                            reports.Text = "HESABATLAR";
                            reports.CssClass = "subnav-link-text";
                            reportsicon.Text = " <i class='fas fa-flag text-danger mr-2'></i>";
                            _reports.Controls.Add(reportsicon);
                            _reports.Controls.Add(reports);
                            _reports.NavigateUrl = "/site/reports/az";


                            multimedia.Text = "MULTİMEDİA";
                            multimedia.CssClass = "subnav-link-text";
                            multimediaicon.Text = " <i class='fas fa-photo-video text-danger mr-2'></i>";
                            _multimedia.Controls.Add(multimediaicon);
                            _multimedia.Controls.Add(multimedia);
                            _multimedia.NavigateUrl = "/site/multimedia/az";


                            aboutus.Text = "HAQQIMIZDA";
                            aboutus.CssClass = "subnav-link-text";
                            aboutusicon.Text = " <i class='fas fa-address-card text-danger mr-2'></i>";
                            _aboutus.Controls.Add(aboutusicon);
                            _aboutus.Controls.Add(aboutus);
                            _aboutus.NavigateUrl = "/site/aboutus/az";


                            contactus.Text = "ƏLAQƏ";
                            contactus.CssClass = "subnav-link-text";
                            contactusicon.Text = " <i class='fas fa-globe text-danger mr-2'></i>";
                            _contactus.Controls.Add(contactusicon);
                            _contactus.Controls.Add(contactus);
                            _contactus.NavigateUrl = "/site/contactus/az";

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

        private void SiteLanguage()
        {

           // string aaa = Session["language"] as string;
            switch (Convert.ToString(Page.RouteData.Values["language"]).ToLower())
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


        private void GetLatest(string LANGUAGE, string POST_COUNT, string POST_CATEGORY, bool POST_ISDELETE, bool POST_ISACTIVE, string POST_AUTHOR , ListView LSV_AZ, ListView LSV_EN)
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
                                                                                                        POST_SEOEN
                                                                                                    
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
                                                                                                        POST_SEOAZ
                                                                                                       
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

       



        protected void Page_Load(object sender, EventArgs e)
        {
            
            GetLogos();
            Navigation();
            SiteLanguage();
            GetSponsors();
            GetLatest(Session["language"] as string, "4", "news", false, true,Session["pcsubsite"] as string, LATEST_AZ, LATEST_EN);

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