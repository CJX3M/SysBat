using System.Web;
using System.Web.Optimization;

namespace Sysbat
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js", 
                "~/bower_components/metisMenu/dist/metisMenu.js",
                "~/dist/js/sb-admin-2.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapTablesJS").Include(
                "~/bower_components/datatables/media/js/jquery.dataTables.js",
                "~/bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.min.js"));
            
                // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include("~/Scripts/angular.js", "~/Scripts/angular-route.js",
                        "~/Scripts/js/module.js", "~/Scripts/js/service.js", "~/Scripts/js/controller.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css",
                "~/Content/bootstrap.css",
                "~/dist/css/sb-admin-2.css",
                "~/bower_components/font-awesome/css/font-awesome.css",
                "~/bower_components/metisMenu/dist/metisMenu.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/bundles/bootstrapTablesCSS").Include("~/bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.css",
                "~/bower_components/datatables-responsive/css/dataTables.responsive.css"));
        }
    }
}