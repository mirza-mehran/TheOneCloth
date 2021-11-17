using System.Web;
using System.Web.Optimization;

namespace TheOneCloth.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Admincss").Include(
                       "~/Content/plugins/fontawesome-free/css/all.min.css",
                         "~/Content/plugins/overlayScrollbars/css/OverlayScrollbars.min.css",
                          "~/Content/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css",
                            "~/Content/plugins/icheck-bootstrap/icheck-bootstrap.min.css",
                            "~/Content/AdminStyle/css/adminlte.css"));
            
            bundles.Add(new ScriptBundle("~/Content/Adminplugins").Include(
                             "~/Content/plugins/jquery/jquery.min.js",
                              "~/Content/plugins/bootstrap/js/bootstrap.bundle.min.js",
                               "~/Content/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js",
                                "~/Content/AdminStyle/js/adminlte.js",
                                 "~/Content/plugins/jquery-mousewheel/jquery.mousewheel.js",
                                  "~/Content/plugins/raphael/raphael.min.js",
                                   "~/Content/plugins/jquery-mapael/jquery.mapael.min.js",
                                    "~/Content/plugins/jquery-mapael/maps/usa_states.min.js"));

        }
    }
}
