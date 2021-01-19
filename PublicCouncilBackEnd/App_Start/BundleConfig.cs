using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace PublicCouncilBackEnd
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundle)
        {
            //bundle all common js files, required in every page  
            bundle.Add(new ScriptBundle("~/bundles/MyAppStartupJs")
            .Include(
          
            "~/scripts/core/jquery.js",
            "~/scripts/owl.carousel.js",
            "~/scripts/core/popper.min.js",
            "~/scripts/core/bootstrap.min.js",
            "~/scripts/jquery-nice-scroll.js"
           
            ));
             
            


            //wrapup all css in a bundle
            bundle.Add(new StyleBundle("~/bundles/MyAppStartupCss")
            .Include(
           
            "~/content/css/argon-design-system.min.css",
            "~/content/css/owl.carousel.min.css",
            "~/content/css/owl.theme.default.min.css",
            "~/content/scss/style.css")
          );
            //  Include("~/Content/CSS/fonts/fontawesome-5.13.0/css/all.min.css", new CssRewriteUrlTransform())
            BundleTable.EnableOptimizations = true;

        }
    }
}