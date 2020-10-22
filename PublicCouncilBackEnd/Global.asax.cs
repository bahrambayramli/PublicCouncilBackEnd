using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Optimization;
using System.Web.Routing;

namespace PublicCouncilBackEnd
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
            BundleTable.EnableOptimizations = true;
            BundleConfig.RegisterBundle(BundleTable.Bundles);
        }


        void RegisterRoutes(RouteCollection routes)
        {
            #region(Site routes)
            
            routes.MapPageRoute("home", "home/{language}", "~/home.aspx");
            routes.MapPageRoute("legislation", "legislation/{language}", "~/legislation.aspx");
            routes.MapPageRoute("elections", "elections/{language}", "~/elections.aspx");
            routes.MapPageRoute("publications", "publications/{language}", "~/publications.aspx");
            routes.MapPageRoute("posts", "posts/{language}", "~/posts.aspx");
            routes.MapPageRoute("reports", "reports/{language}", "~/reports.aspx");
            routes.MapPageRoute("announcements", "announcements/{language}", "~/announcements.aspx");

            routes.MapPageRoute("multimedia", "multimedia/{language}", "~/multimedia.aspx");
            routes.MapPageRoute("multimediaRoute", "multimedia/{directory}/{language}", "~/multimedia.aspx");

            routes.MapPageRoute("councils", "councils/{language}", "~/councils.aspx");
            routes.MapPageRoute("councilsroute", "councils/{directory}/{language}", "~/councils.aspx");

            routes.MapPageRoute("details", "details/{language}/{postid}", "~/details.aspx");
            routes.MapPageRoute("login", "login/", "~/login.aspx");
            routes.MapPageRoute("register", "register/", "~/register.aspx");
            #endregion

            #region(Manage routes)
            //Admin Panel routes

            routes.MapPageRoute("managedashboard", "manage/dashboard/", "~/manage/dashboard.aspx");
            routes.MapPageRoute("manageposts", "manage/posts/", "~/manage/posts.aspx");
            routes.MapPageRoute("managepostdetail", "manage/postdetail/", "~/manage/postdetail.aspx");
            routes.MapPageRoute("managelogos", "manage/logos/", "~/manage/logos.aspx");
            routes.MapPageRoute("managelogodetail", "manage/logodetail/", "~/manage/logodetail.aspx");
            routes.MapPageRoute("managepartners", "manage/partners/", "~/manage/partners.aspx");
            routes.MapPageRoute("managepartnerdetail", "manage/partnerdetail/", "~/manage/partnerdetail.aspx");
            routes.MapPageRoute("managesponsors", "manage/sponsors/", "~/manage/sponsors.aspx");
            routes.MapPageRoute("managesponsordetail", "manage/sponsordetail/", "~/manage/sponsordetail.aspx");
            routes.MapPageRoute("managecouncils", "manage/councils/", "~/manage/councils.aspx");
            routes.MapPageRoute("managecouncildetail", "manage/councildetail/", "~/manage/councildetail.aspx");

            //routes.MapPageRoute("admindetails", "adminpanel/details/{newID}", "~/adminpanel/details.aspx");
            //routes.MapPageRoute("partnersedit", "adminpanel/partnersdetail/{id}", "~/adminpanel/partnersdetail.aspx");
            //routes.MapPageRoute("pages", "adminpanel/pages/", "~/adminpanel/pages.aspx");
            //routes.MapPageRoute("usersprofile", "adminpanel/usersprofile/", "~/adminpanel/usersprofile.aspx");

            #endregion

            #region(SubSite routes)
            routes.MapPageRoute("pchome", "site/home/{language}", "~/subsite/home.aspx");
            routes.MapPageRoute("pcposts", "site/posts/{language}", "~/subsite/posts.aspx");
            routes.MapPageRoute("pcannouncements", "site/announcements/{language}", "~/subsite/announcements.aspx");
            routes.MapPageRoute("pclegislations", "site/legislation/{language}", "~/subsite/legislation.aspx");
            routes.MapPageRoute("pcpublications", "site/publications/{language}", "~/subsite/publications.aspx");
            routes.MapPageRoute("pcreports", "site/reports/{language}", "~/subsite/reports.aspx");
            routes.MapPageRoute("pcmultimedia", "site/multimedia/{language}", "~/subsite/multimedia.aspx");
            routes.MapPageRoute("pcmultimediaRoute", "site/multimedia/{directory}/{language}", "~/subsite/multimedia.aspx");
            routes.MapPageRoute("pcaboutus", "site/aboutus/{language}", "~/subsite/aboutus.aspx");
            routes.MapPageRoute("pccontactus", "site/contactus/{language}", "~/subsite/contactus.aspx");
            #endregion

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
           
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}