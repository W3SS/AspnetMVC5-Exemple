using System.Web;
using System.Web.Optimization;

namespace ModuloCongresso.UI.Site
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Principais
            // jQuery 3
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.1.0.min.js"));

            // jQuery 2
            bundles.Add(new ScriptBundle("~/bundles/jquery2").Include(
                        "~/Scripts/jquery-2.1.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));
            #endregion

            #region CSS
            // Footable styles
            bundles.Add(new StyleBundle("~/Content/fooTableStyles").Include(
                      "~/Content/Template 3/Tables/footable.core.css"));

            // dataPicker styles
            bundles.Add(new StyleBundle("~/Content/dataPickerStyles").Include(
                      "~/Content/Template 3/Elements/datepicker3.css"));

            // icheck styles
            bundles.Add(new StyleBundle("~/Content/iCheckAllStyles").Include(
                      "~/Content/Template 3/Elements/green.css",
                      "~/Content/Template 3/Elements/red.css",
                      "~/Content/Template 3/Elements/square.css",
                      "~/Content/Template 3/Elements/blue.css"));

            // chosen css styles
            bundles.Add(new StyleBundle("~/Content/chosenStyles").Include(
                      "~/Content/Template 3/Elements/chosen.css"));

            // Select2 css Styles
            bundles.Add(new StyleBundle("~/Content/select2Styles").Include(
                      "~/Content/Template 3/Elements/select2.min.css"));

            // iCheck css styles
            bundles.Add(new StyleBundle("~/Content/iCheckStyles").Include(
                      "~/Content/Template 3/Wizard/custom.css"));

            // wizardSteps styles
            bundles.Add(new StyleBundle("~/Content/wizardStepsStyles").Include(
                      "~/Content/Template 3/Wizard/jquery.steps.css"));

            // Font Awesome icons
            bundles.Add(new StyleBundle("~/font-awesome/css").Include(
                      "~/Content/Plugins/fonts/font-awesome.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Template 3/bootstrap.min.css",
                      "~/Content/Template 3/animate.css",
                      "~/Content/Template 3/style.css"));

            // Touch Styles
            bundles.Add(new StyleBundle("~/Content/touchSpinStyles").Include(
                      "~/Content/Template 3/Elements/jquery.bootstrap-touchspin.min.css"));
            #endregion

            #region JavaScript
            // fooTable 
            bundles.Add(new ScriptBundle("~/plugins/fooTable").Include(
                      "~/Scripts/Template 3/Tables/footable.all.min.js"));

            // dataPicker 
            bundles.Add(new ScriptBundle("~/plugins/dataPicker").Include(
                      "~/Scripts/Template 3/Elements/bootstrap-datepicker.js"));

            // icheck 
            bundles.Add(new ScriptBundle("~/plugins/iCheck").Include(
                      "~/Scripts/Template 3/Elements/icheck.min.js"));

            // Flot chart
            bundles.Add(new ScriptBundle("~/plugins/flot").Include(
                      "~/Scripts/Template 3/DashBoard/jquery.flot.js",
                      "~/Scripts/Template 3/DashBoard/jquery.flot.tooltip.min.js",
                      "~/Scripts/Template 3/DashBoard/jquery.flot.resize.js",
                      "~/Scripts/Template 3/DashBoard/jquery.flot.pie.js",
                      "~/Scripts/Template 3/DashBoard/jquery.flot.time.js",
                      "~/Scripts/Template 3/DashBoard/jquery.flot.spline.js"));

            // Sparkline
            bundles.Add(new ScriptBundle("~/plugins/sparkline").Include(
                      "~/Scripts/Template 3/DashBoard/jquery.sparkline.min.js"));

            // ChartJS chart
            bundles.Add(new ScriptBundle("~/plugins/chartJs").Include(
                      "~/Scripts/Template 3/DashBoard/Chart.min.js"));

            // Peity
            bundles.Add(new ScriptBundle("~/plugins/peity").Include(
                      "~/Scripts/Template 3/DashBoard/jquery.peity.min.js"));


            // wizardSteps 
            bundles.Add(new ScriptBundle("~/plugins/wizardSteps").Include(
                      "~/Scripts/Template 3/Wizard/jquery.steps.min.js"));

            // iCheck
            bundles.Add(new ScriptBundle("~/plugins/iCheck").Include(
                      "~/Scripts/Template 3/Wizard/icheck.min.js"));

            // wizardScript
            bundles.Add(new ScriptBundle("~/plugins/wizardScript").Include(
                      "~/Scripts/Template 3/Wizard/wizardScript.js"));

            // Select2
            bundles.Add(new ScriptBundle("~/plugins/select2").Include(
                      "~/Scripts/Template 3/Elements/select2.full.min.js"));

            // chosen 
            bundles.Add(new ScriptBundle("~/plugins/chosen").Include(
                      "~/Scripts/Template 3/Elements/chosen.jquery.js"));

            // SlimScroll
            bundles.Add(new ScriptBundle("~/plugins/slimScroll").Include(
                      "~/Scripts/Template 3/jquery.slimscroll.min.js"));

            // TouchSpin
            bundles.Add(new ScriptBundle("~/plugins/touchSpin").Include(
                      "~/Scripts/Template 3/Elements/jquery.bootstrap-touchspin.min.js"));

            // Inspinia script
            bundles.Add(new ScriptBundle("~/bundles/inspinia").Include(
                      "~/Scripts/Template 3/jquery.slimscroll.min.js",
                      "~/Scripts/Template 3/pace.min.js",
                      "~/Scripts/Template 3/inspinia.js"));

            // Inspinia skin config script
            bundles.Add(new ScriptBundle("~/bundles/skinConfig").Include(
                      "~/Scripts/Template 3/skin.config.min.js"));
            #endregion
        }
    }
}
