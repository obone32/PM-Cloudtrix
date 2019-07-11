using System.Web;
using System.Web.Optimization;

namespace CloudtrixApp.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/thirdpartcss").Include(
                            "~/Content/adminFront/assets/css/bootstrap.min.css",
                            "~/Content/adminFront/assets/css/bootstrap-reset.css",
                            "~/Content/adminFront/assets/css/animate.css",
                            "~/Content/adminFront/assets/plugins/morris/morris.css"));

            bundles.Add(new StyleBundle("~/bundles/thirdpartcss2").Include(
                           "~/Content/adminFront/assets/plugins/datatables/jquery.dataTables.min.css",
                           "~/Content/toastr.css",
                           "~/Content/adminFront/assets/plugins/toggles/toggles.css",
                           "~/Content/adminFront/assets/css/style.css",
                           "~/Content/adminFront/assets/css/helper.css",
                           "~/Content/adminFront/assets/css/style-responsive.css",
                           "~/Content/adminFront/assets/plugins/select2/select2.css"));



            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/adminFront/assets/js/jquery.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/thirdpartjs").Include(
                        "~/Content/adminFront/assets/plugins/chat/moment-2.2.1.js",
                        "~/Content/adminFront/assets/js/bootstrap.min.js",
                        "~/Content/adminFront/assets/js/modernizr.min.js",
                        "~/Content/adminFront/assets/js/wow.min.js",
                        "~/Content/adminFront/assets/js/jquery.scrollTo.min.js",
                        "~/Content/adminFront/assets/js/jquery.nicescroll.js"));


            bundles.Add(new ScriptBundle("~/bundles/thirdpartjs2").Include(
                     "~/Content/adminFront/assets/plugins/toggles/toggles.min.js",
                     "~/Scripts/toastr.js",
                     "~/Content/adminFront/assets/plugins/datatables/jquery.dataTables.min.js",
                     "~/Content/adminFront/assets/plugins/datatables/dataTables.bootstrap.js",
                     "~/Content/adminFront/assets/plugins/timepicker/bootstrap-datepicker.js",
                     "~/Scripts/App/jquery.timepicker.min.js",
                     "~/Content/adminFront/assets/js/app.js",
                     "~/Content/adminFront/assets/plugins/select2/select2.min.js",
                     "~/Content/adminFront/assets/js/demo_color.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            //App

            bundles.Add(new ScriptBundle("~/bundles/App").Include(
                     "~/Scripts/App/App.js"));
            
            // App3
            bundles.Add(new ScriptBundle("~/bundles/App3").Include(
                //"~/Scripts/App/Invoice.js",
                "~/Scripts/App/NewJS.js",
                 "~/Scripts/App/Select2.js",
                 "~/Scripts/App/bootstrap-multiselect.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-multiselect.css"));

           
        }
    }
}
