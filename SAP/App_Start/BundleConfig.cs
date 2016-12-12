using System.Web;
using System.Web.Optimization;

namespace SAP
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/nglr")
                .Include("~/Scripts/angular.min.js")
                .Include("~/Scripts/angular-animate.min.js")
                .Include("~/Scripts/angular-route.min.js")
                .Include("~/Scripts/app/MainApp.js")
                .IncludeDirectory("~/Scripts/app", "*.js")
                .Include("~/Scripts/bootstrap.min.js")
                .Include("~/Scripts/jquery-3.1.1.min.js"));


            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/font-awesome.min.css")
                .Include("~/Content/bootsrap.min.css")
                .Include("~/Content/site.css"));
        }
    }
}
