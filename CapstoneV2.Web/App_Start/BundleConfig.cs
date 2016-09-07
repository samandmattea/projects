﻿using System.Web;
using System.Web.Optimization;

namespace CapstoneV2.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-1.10.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/tinymce").Include(
                "~/Scripts/tinymce/tinymce.min.js",
                "~/Scripts/app/tinymce-app.js"));

            bundles.Add(new ScriptBundle("~/bundles/fullpage").Include(
                "~/Scripts/jquery.fullPage.min.js",
                "~/Scripts/app/fullpage-app.js"));

            bundles.Add(new ScriptBundle("~/bundles/fittext").Include(
                "~/Scripts/jquery.fittext.js"));

            bundles.Add(new ScriptBundle("~/bundles/agecheck").Include(
                "~/Scripts/jquery.agecheck.min.js",
                "~/Scripts/app/agecheck-app.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                "~/Content/fontawesome/font-awesome.css"));
        }
    }
}
