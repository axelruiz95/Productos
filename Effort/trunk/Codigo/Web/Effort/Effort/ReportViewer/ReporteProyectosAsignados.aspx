﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteProyectosAsignados.aspx.cs" Inherits="Effort.ReportViewer.ReporteProyectosAsignados" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
         <rsweb:ReportViewer ID="rptViewer" runat="server" height="503px" width="100%">
        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
