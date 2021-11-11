using System.Web;
using System.Web.Optimization;

namespace SearchCustomer
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-{version}.min.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/DataTables/jquery.dataTables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            //DataTable CSS
            bundles.Add(new StyleBundle("~/Content/DataTableCSS").Include(
                "~/Content/DataTables/css/dataTables.bootstrap4.css",
                "~/Content/DataTables/css/dataTables.jqueryui.min.css"));

            //AdminLTE CSS
            bundles.Add(new StyleBundle("~/AdminLTE/css").Include(
                "~/AdminLTE/font/SourceSansPro.css",
                "~/AdminLTE/plugins/fontawesome-free/css/all.min.css",
                "~/AdminLTE/dist/css/adminlte.min.css",
                "~/AdminLTE/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css",
                "~/AdminLTE/plugins/icheck-bootstrap/icheck-bootstrap.min.css",
                "~/AdminLTE/plugins/jquery-ui/jquery-ui.css",
                "~/AdminLTE/plugins/bootstrap4-duallistbox/bootstrap-duallistbox.min.css",
                "~/AdminLTE/plugins/sweetalert2-theme-bootstrap-4/bootstrap-4.min.css",
                "~/AdminLTE/plugins/select2/css/select2.min.css",
                "~/AdminLTE/plugins/select2-bootstrap4-theme/select2-bootstrap4.min.css"));

            //AdminLTE JS
            bundles.Add(new ScriptBundle("~/AdminLTE/jquery").Include(
                "~/AdminLTE/plugins/bootstrap/js/bootstrap.bundle.min.js",
                "~/AdminLTE/dist/js/adminlte.min.js",
                "~/AdminLTE/plugins/moment/moment.min.js",
                "~/AdminLTE/plugins/inputmask/jquery.inputmask.min.js",
                "~/AdminLTE/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js",
                "~/AdminLTE/plugins/jquery-ui/jquery-ui.js",
                "~/AdminLTE/plugins/bootstrap4-duallistbox/jquery.bootstrap-duallistbox.min.js",
                "~/AdminLTE/plugins/sweetalert2/sweetalert2.min.js",
                "~/AdminLTE/plugins/select2/js/select2.full.min.js"));
        }
    }
}
