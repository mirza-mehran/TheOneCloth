﻿using Forloop.HtmlHelpers;
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
                      "~/Content/site.css"
                     ));

            bundles.Add(new StyleBundle("~/Content/Admincss").Include(
                       "~/Content/plugins/fontawesome-free/css/all.min.css",
                         "~/Content/plugins/overlayScrollbars/css/OverlayScrollbars.min.css",
                             "~/Content/AdminStyle/css/adminlte.css",
                              "~/Content/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css",
                                "~/Content/plugins/datatables-responsive/css/responsive.bootstrap4.min.css",
                                 "~/Content/plugins/datatables-buttons/css/buttons.bootstrap4.min.css",
                                  "~/Content/plugins/summernote/summernote-bs4.min.css",
                                   "~/Content/plugins/codemirror/codemirror.css",
                                    "~/Content/plugins/codemirror/theme/monokai.css",
                                     "~/Content/plugins/simplemde/simplemde.min.css"
  ));

            bundles.Add(new ScriptBundle("~/Content/Adminplugins").Include(
                             "~/Content/plugins/jquery/jquery.min.js",
                             "~/Content/plugins/bootstrap/js/bootstrap.min.js",
                              "~/Content/plugins/bootstrap/js/bootstrap.bundle.min.js",
                               "~/Content/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js",
                                "~/Content/AdminStyle/js/adminlte.js",
                                 "~/Content/plugins/jquery-mousewheel/jquery.mousewheel.js",
                                  "~/Content/plugins/raphael/raphael.min.js",
                                   "~/Content/plugins/jquery-mapael/jquery.mapael.min.js",
                                    "~/Content/plugins/jquery-mapael/maps/usa_states.min.js",
                                     "~/Content/plugins/datatables/jquery.dataTables.min.js",
                                      "~/Content/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js",
                                       "~/Content/plugins/datatables-responsive/js/dataTables.responsive.min.js",
                                        "~/Content/plugins/datatables-responsive/js/responsive.bootstrap4.min.js",
                                         "~/Content/plugins/datatables-buttons/js/dataTables.buttons.min.js",
                                          "~/Content/plugins/datatables-buttons/js/buttons.bootstrap4.min.js",
                                            "~/Content/plugins/jszip/jszip.min.js",
                                             "~/Content/plugins/pdfmake/pdfmake.min.js",
                                              "~/Content/plugins/pdfmake/vfs_fonts.js",
                                                "~/Content/plugins/datatables-buttons/js/buttons.html5.min.js",
                                                 "~/Content/plugins/datatables-buttons/js/buttons.print.min.js",
                                                  "~/Content/plugins/datatables-buttons/js/buttons.colVis.min.js",
                                                   "~/Content/plugins/summernote/summernote-bs4.min.js",
                                                    "~/Content/plugins/codemirror/codemirror.js",
                                                     "~/Content/plugins/codemirror/mode/css/css.js",
                                                      "~/Content/plugins/codemirror/mode/xml/xml.js",
                                                       "~/Content/plugins/codemirror/mode/htmlmixed/htmlmixed.js"

                                    ));

            ScriptContext.ScriptPathResolver = System.Web.Optimization.Scripts.Render;
        }
        

    }
}
