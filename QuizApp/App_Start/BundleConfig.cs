using System.Web.Optimization;

namespace QuizApp
{
    public class BundleConfig
    {
        // Paketleme hakkında daha fazla bilgi için lütfen https://go.microsoft.com/fwlink/?LinkId=301862 adresini ziyaret edin
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Geliştirme yapmak ve öğrenmek için Modernizr'ın geliştirme sürümünü kullanın. Daha sonra,
            // üretim için hazır. https://modernizr.com adresinde derleme aracını kullanarak yalnızca ihtiyacınız olan testleri seçin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));
            //bundles.Add(new StyleBundle("~/bundles/layoutcss").Include(
            //       "~/assets/plugins/custom/fullcalendar/fullcalendar.bundle.css?v=7.0.5",
            //       "~/assets/plugins/custom/prismjs/prismjs.bundle.css?v=7.0.5",
            //       "~/assets/css/style.bundle.css?v=7.0.5",
            //       "~/assets/css/themes/layout/header/base/light.css?v=7.0.5",
            //       "~/assets/css/themes/layout/header/menu/light.css?v=7.0.5",
            //       "~/assets/css/themes/layout/brand/dark.css?v=7.0.5",
            //       "~/assets/css/themes/layout/aside/dark.css?v=7.0.5",
            //       "~/assets/plugins/global/plugins.bundle.css?v=7.0.5"));

            //bundles.Add(new ScriptBundle("~/bundles/layoutjs").Include(
            //        "~/assets/plugins/global/plugins.bundle.js?v=7.0.5",
            //        "~/assets/plugins/custom/prismjs/prismjs.bundle.js?v=7.0.5",
            //        "~/assets/js/scripts.bundle.js?v=7.0.5",
            //        "assets/plugins/custom/fullcalendar/fullcalendar.bundle.js?v=7.0.5",
            //        "assets/js/pages/widgets.js?v=7.0.5"));
            bundles.Add(new ScriptBundle("~/bundles/Datatable").Include(
                "~/Scripts/jquery.dataTables.min.js",
                "~/Scripts/Datatable/dataTables.buttons.min.js",
                "~/Scripts/Datatable/buttons.flash.min.js",
                "~/Scripts/Datatable/pdfmake.min.js",
                "~/Scripts/Datatable/buttons.html5.min.js",
                "~/Scripts/Datatable/dataTables.buttons.min.js",
                "~/Scripts/Datatable/jszip.min.js",
                "~/Scripts/Datatable/vfs_fonts.js"
            ));
        }
    }
}