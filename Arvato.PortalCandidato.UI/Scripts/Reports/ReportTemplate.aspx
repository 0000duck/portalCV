<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportTemplate.aspx.cs" Inherits="Arvato.PortalCandidato.UI.Reports.ReportTemplate" %>

<%@ Register TagPrefix="rsweb" Namespace="Microsoft.Reporting.WebForms" Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" %>



<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scriptManager" runat="server" ScriptMode="Release" EnablePartialRendering="false">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="reportViewer"  style="height:50rem;width:100%" ShowPrintButton="true" KeepSessionAlive="true" runat="server" ProcessingMode="Remote">
            <ServerReport />
        </rsweb:ReportViewer>
    </form>  
</body>
</html>
