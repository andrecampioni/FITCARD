using System.Web;
using System.Web.Optimization;


namespace FITCARD.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
             
            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                      "~/scripts/jquery.min.js",
                      "~/scripts/bootstrap.min.js",
                      "~/scripts/jquery.dataTables.min.js",
                      "~/scripts/dataTables.bootstrap.min.js",
                      "~/scripts/toastr.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/font-awesome.min.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/Site.css",
                      "~/Content/toastr.min.css"));

        }
    }
}

