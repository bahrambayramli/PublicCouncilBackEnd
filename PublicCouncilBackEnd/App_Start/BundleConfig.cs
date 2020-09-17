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
            //bundle.Add(new ScriptBundle("~/bundles/MyAppStartupJs")
            //.Include(
            //"~/scripts/core/jquery.min.js",
            //"~/scripts/owl.carousel.min.js",
            //"~/scripts/jquery.marquee.min.js",
            //"~/scripts/core/popper.min.min.js",
            //"~/scripts/core/bootstrap-material-design.min.min.js",
            //"~/scripts/plugins/moment.min.js",
            //"~/scripts/plugins/nouislider.min.js",
            // "~/scripts/plugins/bootstrap-selectpicker.js",
            //"~/scripts/plugins/perfect-scrollbar.jquery.min.js",
            //"~/scripts/sticky-header.min.js",
            //"~/scripts/tab.min.js"
            //));
            // ,
            // "~/scripts/scripts/nav.min.js",


            //wrapup all css in a bundle  
            //bundle.Add(new StyleBundle("~/bundles/MyAppStartupCss")
            //.Include(
            //"~/Content/css/owl.carousel.min.css",
            //"~/Content/css/owl.theme.default.min.css",
            //"~/Content/css/material-kit.min.css",
            //"~/Content/SCSS/style.min.css").
            //Include("~/Content/CSS/fonts/fontawesome-5.13.0/css/all.min.css", new CssRewriteUrlTransform()));

            //BundleTable.EnableOptimizations = true;
            
        }
    }
}