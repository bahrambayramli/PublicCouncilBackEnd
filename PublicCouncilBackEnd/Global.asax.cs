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
            //BundleTable.EnableOptimizations = true;
            //BundleConfig.RegisterBundle(BundleTable.Bundles);
        }


        void RegisterRoutes(RouteCollection routes)
        {

            //Site routes
            routes.MapPageRoute("home", "home/{language}", "~/home.aspx");
            routes.MapPageRoute("legislation", "legislation/{language}", "~/legislation.aspx");
            routes.MapPageRoute("elections", "elections/{language}", "~/elections.aspx");
            routes.MapPageRoute("publications", "publications/{language}", "~/publications.aspx");
            routes.MapPageRoute("posts", "posts/{language}", "~/posts.aspx");
            routes.MapPageRoute("reports", "reports/{language}", "~/reports.aspx");
            routes.MapPageRoute("multimedia", "multimedia/{language}", "~/multimedia.aspx");
            routes.MapPageRoute("multimediaRoute", "multimedia/{directory}/{language}", "~/multimedia.aspx");
            routes.MapPageRoute("announcments", "announcments/{language}", "~/announcments.aspx");
            routes.MapPageRoute("details", "details/{language}/{id}", "~/details.aspx");











            //Admin Panel routes

            routes.MapPageRoute("managedashboard", "manage/dashboard/", "~/manage/dashboard.aspx");
            routes.MapPageRoute("manageposts", "manage/posts/", "~/manage/posts.aspx");
            routes.MapPageRoute("managepostdetail", "manage/postdetail/", "~/manage/postdetail.aspx");
            routes.MapPageRoute("managelogos", "manage/logos/", "~/manage/logos.aspx");
            routes.MapPageRoute("managelogodetail", "manage/logodetail/", "~/manage/logodetail.aspx");

            routes.MapPageRoute("managepartners", "manage/partners/", "~/manage/partners.aspx");
            routes.MapPageRoute("managepartnerdetail", "manage/partnerdetail/", "~/manage/partnerdetail.aspx");


            routes.MapPageRoute("managesponsors", "manage/sponsors/", "~/adminpanel/sponsors.aspx");
            routes.MapPageRoute("managesponsordetail", "manage/sponsordetail/", "~/manage/sponsordetail.aspx");


            //routes.MapPageRoute("admindetails", "adminpanel/details/{newID}", "~/adminpanel/details.aspx");

            //routes.MapPageRoute("partnersedit", "adminpanel/partnersdetail/{id}", "~/adminpanel/partnersdetail.aspx");
            //routes.MapPageRoute("pages", "adminpanel/pages/", "~/adminpanel/pages.aspx");
            //routes.MapPageRoute("usersprofile", "adminpanel/usersprofile/", "~/adminpanel/usersprofile.aspx");



            //Subdomain routes
            //routes.MapPageRoute("ngohome", "site/home/{language}", "~/ngo/home.aspx");
            //routes.MapPageRoute("ngonews", "site/news/{language}", "~/ngo/news.aspx");
            //routes.MapPageRoute("ngoprojects", "site/projects/{language}", "~/ngo/projects.aspx");
            //routes.MapPageRoute("ngomultimedia", "site/multimedia/{language}", "~/ngo/multimedia.aspx");
            //routes.MapPageRoute("ngoreports", "site/reports/{language}", "~/ngo/reports.aspx");
            //routes.MapPageRoute("ngoaboutus", "site/aboutus/{language}", "~/ngo/aboutus.aspx");
            //routes.MapPageRoute("ngocontactus", "site/contactus/{language}", "~/ngo/contactus.aspx");
            //routes.MapPageRoute("ngopublications", "site/publications/{language}", "~/ngo/publications.aspx");



            //routes.MapPageRoute("login", "login/", "~/login.aspx");
            //routes.MapPageRoute("register", "register/", "~/register.aspx");
            //routes.MapPageRoute("success", "success/", "~/success.aspx");
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