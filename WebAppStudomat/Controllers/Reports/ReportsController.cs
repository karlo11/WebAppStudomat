using Microsoft.Reporting.WebForms;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace WebAppStudomat.Controllers.Reports
{
    public class ReportsController : Controller
    {
        private static readonly string configSSRSUrl = "SSRSReportUrl";
        private static readonly string configSSRSInitialReport = "SSRSInitialReport";

        // GET: Reports
        public ActionResult Index()
        {
            LoadInitialReport();

            return View();
        }

        private void LoadInitialReport()
        {
            var ssrsUrl = ReadSetting(configSSRSUrl);
            var ssrsInitialReport = ReadSetting(configSSRSInitialReport);

            var reportViewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Remote,
                SizeToReportContent = true,
                AsyncRendering = true
            };

            try
            {
                reportViewer.ServerReport.ReportServerUrl = new Uri(ssrsUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: ", ex.ToString());
            }

            reportViewer.ServerReport.ReportPath = ssrsInitialReport;
            ViewBag.ReportViewer = reportViewer;
        }

        private string ReadSetting(string key)
        {
            string settingUrl = null;
            try
            {
                settingUrl = ConfigurationManager.AppSettings[key].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not found: ", ex.ToString());
            }

            return settingUrl;
        }
    }
}