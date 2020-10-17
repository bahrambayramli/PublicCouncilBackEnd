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
        
        private string GetSerial(string USER_PCDOMAIN)
        {
            SqlDataAdapter getSerial = new SqlDataAdapter(new SqlCommand(@"SELECT USER_SERIAL FROM PC_USERS 
                                                                                                 WHERE 
                                                                                                 ISDELETE      = @ISDELETE AND 
                                                                                                 ISACTIVE      = @ISACTIVE AND
                                                                                                 USER_PCDOMAIN = @USER_PCDOMAIN"));
            getSerial.SelectCommand.Parameters.Add("@ISDELETE", SqlDbType.Bit).Value = false;
            getSerial.SelectCommand.Parameters.Add("@ISACTIVE", SqlDbType.Bit).Value = true;
            getSerial.SelectCommand.Parameters.Add("@USER_PCDOMAIN", SqlDbType.NVarChar).Value = USER_PCDOMAIN;
            return SQL.SELECT(getSerial).Rows[0]["USER_SERIAL"].ToString(); ;
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
          
            logoPcMobile.DataSource = GetLogo(GetSerial(Session["pcsubsite"] as string)); ;
            logoPcMobile.DataBind();
           
          


        }

        private void Navigation()
        {
            try
            {
                Label home = new Label();
                Literal homeicon = new Literal();
                home.Text = "ANA SƏHİFƏ";
                home.CssClass = "subnav-link-text";
                homeicon.Text = " <i class='fas fa-home text-danger mr-2'></i>";
                _home.Controls.Add(homeicon);
                _home.Controls.Add(home);
                _home.NavigateUrl = "/site/home/az";

                Label news = new Label();
                Literal newsicon = new Literal();
                news.Text = "XƏBƏRLƏR";
                news.CssClass = "subnav-link-text";
                newsicon.Text = " <i class='fas fa-newspaper text-danger mr-2'></i>";
                _news.Controls.Add(newsicon);
                _news.Controls.Add(news);
                _news.NavigateUrl = "/site/news/az";

                Label projects = new Label();
                Literal projectsicon = new Literal();
                projects.Text = "ELANLAR";
                projects.CssClass = "subnav-link-text";
                projectsicon.Text = "<i class='fas fa-project-diagram text-danger mr-2'></i>";
                _projects.Controls.Add(projectsicon);
                _projects.Controls.Add(projects);
                _projects.NavigateUrl = "/site/projects/az";

                Label legislation = new Label();
                Literal legislationicon = new Literal();
                legislation.Text = "QANUNVERİCİLİK";
                legislation.CssClass = "subnav-link-text";
                legislationicon.Text = " <i class='fas fa-gavel text-danger mr-2'></i>";
                _legilations.Controls.Add(legislationicon);
                _legilations.Controls.Add(legislation);
                _legilations.NavigateUrl = "/site/legislations/az";



                Label publications = new Label();
                Literal publicationsicon = new Literal();
                publications.Text = "NƏŞRLƏR";
                publications.CssClass = "subnav-link-text";
                publicationsicon.Text = " <i class='fas fa-book-open text-danger mr-2'></i>";
                _publications.Controls.Add(publicationsicon);
                _publications.Controls.Add(publications);
                _publications.NavigateUrl = "/site/publications/az";

                Label reports = new Label();
                Literal reportsicon = new Literal();
                reports.Text = "HESABATLAR";
                reports.CssClass = "subnav-link-text";
                reportsicon.Text = " <i class='fas fa-flag text-danger mr-2'></i>";
                _reports.Controls.Add(reportsicon);
                _reports.Controls.Add(reports);
                _reports.NavigateUrl = "/site/reports/az";

                Label multimedia = new Label();
                Literal multimediaicon = new Literal();
                multimedia.Text = "MULTİMEDİA";
                multimedia.CssClass = "subnav-link-text";
                multimediaicon.Text = " <i class='fas fa-photo-video text-danger mr-2'></i>";
                _multimedia.Controls.Add(multimediaicon);
                _multimedia.Controls.Add(multimedia);
                _multimedia.NavigateUrl = "/site/multimedia/az";

                //Label aboutus = new Label();
                //Literal aboutusicon = new Literal();
                //aboutus.Text = "HAQQIMIZDA";
                //aboutus.CssClass = "subnav-link-text";
                //aboutusicon.Text = " <i class='fas fa-address-card text-danger mr-2'></i>";
                //_aboutus.Controls.Add(aboutusicon);
                //_aboutus.Controls.Add(aboutus);
                //_aboutus.NavigateUrl = "/site/aboutus/az";

                //Label contactus = new Label();
                //Literal contactusicon = new Literal();
                //contactus.Text = "ƏLAQƏ";
                //contactus.CssClass = "subnav-link-text";
                //contactusicon.Text = " <i class='fas fa-globe text-danger mr-2'></i>";
                //_contactus.Controls.Add(contactusicon);
                //_contactus.Controls.Add(contactus);
                //_contactus.NavigateUrl = "/site/contactus/az";

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                throw;
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
            switch (Session["language"] as string)
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

        protected void Page_Load(object sender, EventArgs e)
        {
            GetLogos();
            Navigation();
            SiteLanguage();
            GetSponsors();

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