using System.Web.Optimization;

namespace Arvato.PortalCandidato.UI
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/newJquery/jquery-3.2.1.min.js",
            "~/Scripts/jquery.nanoscroller.js",
            "~/Scripts/newJquery/plugins/ui/jquery-ui.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/newJquery/plugins/validate/jquery.validate*"));


            bundles.Add(new ScriptBundle("~/bundles/datatbles").Include(
                      "~/Scripts/datatablesNew/*dataTables.js",
                      "~/Scripts/datatablesNew/dataTables*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/respond").Include(
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/App").Include(
                "~/Scripts/scripts.js"
                        , "~/Scripts/toastr.min.js"
                       , "~/Scripts/i18next-1.8.0.min.js"
                       , "~/Scripts/App/*.js"
                       , "~/Scripts/Views/Utiles/utiles.js"
                       , "~/Scripts/datepicker/bootstrap-datepicker.js"
                      , "~/Scripts/locales/bootstrap-datepicker.es.js"
                      , "~/Scripts/select2.js"
                      , "~/Scripts/select2.multicheckbox.js"
                      , "~/Scripts/bootbox.min.js"
                      , "~/Scripts/moment.min.js"
                      , "~/Scripts/moment-timezone.min.js"
                      , "~/Scripts/jquery.stickyfooter.js"
                      , "~/Scripts/underscore-min.js"
                      , "~/Scripts/handlebars-v4.0.10.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/utiles").Include(
                      "~/Scripts/Views/Service/Estructura/SubproyectoService.js",
                      "~/Scripts/Views/Service/Estructura/PlataformaService.js",
                      "~/Scripts/Views/Service/Estructura/ServiceService.js",
                      "~/Scripts/Views/Service/Estructura/AgentService.js",
                      "~/Scripts/Views/Service/CatalogoValoresService.js",
                      "~/Scripts/Views/Utiles/utiles2.js"));



            bundles.Add(new ScriptBundle("~/bundles/flot").Include(
                "~/Scripts/flot/jquery.flot.min.js",
                "~/Scripts/flot/jquery.colorhelpers.min.js",
                "~/Scripts/flot/jquery.flot.canvas.min.js",
                "~/Scripts/flot/jquery.flot.categories.min.js",
                "~/Scripts/flot/jquery.flot.crosshair.min.js",
                "~/Scripts/flot/jquery.flot.errorbars.min.js",
                "~/Scripts/flot/jquery.flot.fillbetween.min.js",
                "~/Scripts/flot/jquery.flot.image.min.js",
                "~/Scripts/flot/jquery.flot.navigate.min.js",
                "~/Scripts/flot/jquery.flot.pie.min.js",
                "~/Scripts/flot/jquery.flot.resize.min.js",
                "~/Scripts/flot/jquery.flot.selection.min.js",
                "~/Scripts/flot/jquery.flot.stack.min.js",
                "~/Scripts/flot/jquery.flot.symbol.min.js",
                "~/Scripts/flot/jquery.flot.threshold.min.js",
                "~/Scripts/flot/jquery.flot.orderBars.js",
                "~/Scripts/flot/jquery.flot.barnumbers.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/Candidate").Include(
                   "~/Scripts/Views/Candidate/candidate.js", 
                   "~/Scripts/newJquery/plugins/validate/jquery.validate*"
                   ));
            #endregion

            #region Style

            bundles.Add(new StyleBundle("~/Styles/css").Include(
                      "~/Content/bootstrap/bootstrap.css"
                      , "~/Content/fonts/font-awesome.min.css"
                      , "~/Content/libs/toastr.min.css"
                      , "~/Content/css/select2.css"
                      , "~/Content/datepicker/datepicker.css"
                      , "~/Content/compiled/theme.css"
                      , "~/Content/moment.min.js"
                      , "~/Content/libs/jquery-ui.min.css"
                      , "~/Content/libs/jquery-ui.structure.min.css"
                      , "~/Content/libs/jquery-ui.theme.min.css"
                      ,"~/Content/Site.css"
                      ));

            bundles.Add(new StyleBundle("~/Styles/datatables").Include(
              "~/Content/datatables/dataTables.bootstrap.min.css",
                "~/Content/datatables/jquery.dataTables.min.css",
                "~/Content/arvato/datatables.arvato.css"));

            #endregion
        }
    }
}
