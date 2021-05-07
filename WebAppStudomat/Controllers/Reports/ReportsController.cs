using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

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
            string ssrsUrl = null;
            string ssrsInitialReport = null;
            try
            {
                ssrsUrl = ConfigurationManager.AppSettings[configSSRSUrl].ToString();
                ssrsInitialReport = ConfigurationManager.AppSettings[configSSRSInitialReport].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: ", ex.ToString());
            }

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
    }
}