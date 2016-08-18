using System.Web;
using System.Web.Optimization;

namespace EBox.MvcApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css",
                      "~/Content/bootstrap-social/assets/css/bootstrap.css",
                      "~/Content/bootstrap-social/assets/css/docs.css",
                      "~/Content/bootstrap-social/assets/css/font-awesome.css",
                      "~/Content/bootstrap-social/bootstrap-social.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/EBoxAngularMVCApp")
                .IncludeDirectory("~/Scripts/Controllers", "*.js")
                .IncludeDirectory("~/Scripts/Factories", "*.js")
                .Include("~/Scripts/EBoxAngularMVCApp.js"));

            //BundleTable.EnableOptimizations = true;

        }
    }
}
