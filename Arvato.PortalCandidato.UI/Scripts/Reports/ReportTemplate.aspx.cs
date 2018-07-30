using Microsoft.AspNet.Identity;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Arvato.PortalCandidato.UI.Reports
{
    public partial class ReportTemplate : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    reportViewer.ProcessingMode = ProcessingMode.Remote;
                    reportViewer.ServerReport.ReportServerUrl = new Uri("http://10.20.56.85/reportserver_MSSQL2008");
                    reportViewer.AsyncRendering = false;
                    reportViewer.ShowBackButton = true;
                    reportViewer.DocumentMapCollapsed = false;
                    reportViewer.Height = Unit.Pixel(Convert.ToInt32(Request["Height"]));
                    reportViewer.ServerReport.ReportPath = "/Excelenzia Web/";
                    reportViewer.ServerReport.ReportPath += Request["categoria"].ToString() + "/" + Request["informe"].ToString();
                    reportViewer.KeepSessionAlive = true;
                    reportViewer.AsyncRendering = true;
                    var dominio = User.Identity.GetDominio();
                    var usuario = User.Identity.GetUsuarioNT();
                    reportViewer.ServerReport.SetParameters(new ReportParameter("usuario", usuario));
                    reportViewer.ServerReport.SetParameters(new ReportParameter("dominio", dominio.Replace("@", "")));
                    reportViewer.ServerReport.Refresh();
                }
                catch (Exception ex)
                {
                    //return ex.Message;//Manejar exepxiones
                }
            }
        }
    }
}