﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DevExpress.XtraReports.UI;
using System.Text;
using System.IO;
using System.Drawing;

namespace eRoute.Models.ReportesModels
{
    public class Cargas
    {
        private IDbConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["eRouteConnection"].ConnectionString);
        private string QueryString = "";
        private DateTime fInicio;
        private DateTime fFin;
        CargasReport report = new CargasReport();
        //public XtraReport GetReport(string NombreReporte, string NombreEmpresa, string pvCondicion, string FechaInicial, string FechaFinal, string Cedis, string pvCondicionCEDI)}
        public XtraReport GetReport(string NombreReporte, string NombreEmpresa, MemoryStream LogoEmpresa, string NombreVendedor, string NombreCEDIS, string CEDIS, string Vendedores, string FechaInicial, string FechaFinal)
        {
            #region reporte
            this.fInicio = DateTime.Parse(FechaInicial);
            this.fFin = DateTime.Parse(FechaFinal);
            FechaInicial = this.fInicio.Date.ToString("yyyy-MM-dd");
            FechaFinal = this.fFin.Date.ToString("yyyy-MM-dd");
            StringBuilder sConsulta = new StringBuilder();
            sConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
            sConsulta.AppendLine("SET NOCOUNT ON IF (SELECT object_id('tempdb..#TmpCargas')) IS NOT NULL DROP TABLE #TmpCargas ");
            sConsulta.AppendLine("SELECT CEDI = CASE WHEN TipoFase = 1 THEN (SELECT TOP 1 ClaveCEDI FROM AgendaVendedor AGV (NOLOCK) WHERE AGV.DiaClave = TRP.DiaClave AND VEN.USUId = TRP.MUsuarioID) ELSE TRP.Notas END, TRP.Folio, TipoFase, VAD.Descripcion AS DescripcionFase, ");
            sConsulta.AppendLine("CONVERT(DATETIME, CONVERT(VARCHAR(20), D.FechaCaptura, 112)) AS FechaHoraAlta, TPD.ProductoClave, TPD.TipoUnidad, VAD2.Descripcion AS TipoUnidadDes, TPD.Cantidad, USU.Clave + ' ' + VEN.Nombre AS Vendedor INTO #TmpCargas ");
            sConsulta.AppendLine("FROM (SELECT DiaClave, TransProdID, TipoFase, Folio, Tipo, Notas, MUsuarioID, FechaHoraAlta FROM TransProd (NOLOCK) WHERE Tipo = 2) TRP ");
            sConsulta.AppendLine("INNER JOIN (SELECT TransProdID, ProductoClave, TipoUnidad, Cantidad FROM TransProdDetalle (NOLOCK)) TPD ON TPD.TransProdID = TRP.TransProdID ");
            sConsulta.AppendLine("INNER JOIN (SELECT VAVClave, Descripcion FROM VAVDescripcion (NOLOCK) WHERE VARCodigo = 'TRPFASE' AND VADTipoLenguaje = 'EM' ) VAD ON VAD.VAVClave = TRP.TipoFase ");
            sConsulta.AppendLine("INNER JOIN VAVDescripcion VAD2 (NOLOCK) ON VAD2.VARCodigo = 'UNIDADV' AND VAD2.VAVClave = TPD.TipoUnidad AND VAD2.VADTipoLenguaje = 'EM' ");
            sConsulta.AppendLine("INNER JOIN (SELECT VendedorID, Nombre, UsuId FROM Vendedor (NOLOCK)) VEN ON VEN.UsuID = TRP.MUsuarioID ");
            sConsulta.AppendLine("INNER JOIN Usuario USU (NOLOCK) ON USU.UsuID = TRP.MUsuarioID ");
            sConsulta.AppendLine("INNER JOIN Dia D (NOLOCK) ON TRP.DiaClave = D.DiaClave ");
            sConsulta.AppendLine(string.Format("AND CONVERT(date, D.FechaCaptura, 112) BETWEEN '{0}' AND '{1}' ", FechaInicial, FechaFinal));
            sConsulta.AppendLine(string.Format("AND VEN.VendedorID = '{0}' ", Vendedores));
            sConsulta.AppendLine("SELECT ALN.Clave + ' ' + ALN.Nombre AS CEDI, TPD.FechaHoraAlta AS Fecha, TPD.ProductoClave AS Clave, PRO.Nombre AS Producto, ");
            sConsulta.AppendLine("TPD.TipoUnidadDes AS Unidad, TPD.Cantidad, PRD.Factor AS Piezas, TPD.Vendedor, TPD.Folio, TPD.TipoFase, TPD.DescripcionFase ");
            sConsulta.AppendLine("FROM #TmpCargas TPD ");
            sConsulta.AppendLine("INNER JOIN (SELECT ProductoClave, Nombre FROM Producto (NOLOCK)) PRO ON TPD.ProductoClave = PRO.ProductoClave ");
            sConsulta.AppendLine("INNER JOIN (SELECT ProductoClave, PRUTipoUnidad, ProductoDetClave, Factor FROM ProductoDetalle (NOLOCK)) PRD ON PRD.ProductoClave = PRO.ProductoClave ");
            sConsulta.AppendLine("AND PRD.PRUTipoUnidad = TPD.TipoUnidad AND PRD.ProductoDetClave = PRO.ProductoClave ");
            sConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON ALN.Clave = CEDI ");
            sConsulta.AppendLine(string.Format("AND ALN.AlmacenID = '{0}' ", CEDIS));
            sConsulta.AppendLine("ORDER BY CEDI, Fecha, Vendedor, Folio, TPD.ProductoClave, TipoUnidad ");
            sConsulta.AppendLine("IF (SELECT object_id('tempdb..#TmpCargas')) IS NOT NULL DROP TABLE #TmpCargas SET NOCOUNT OFF ");

            QueryString = "";

            QueryString = sConsulta.ToString();

            Connection.Open();
            List<CargasModel> User = Connection.Query<CargasModel>(QueryString, null, null, true, 9000).ToList();
            Connection.Close();
            if (User.Count() <= 0)
            {
                return null;
            }

            #region subreporte
            StringBuilder fechaConsulta = new StringBuilder();
            fechaConsulta.AppendLine("SET ANSI_WARNINGS OFF ");
            fechaConsulta.AppendLine("SET NOCOUNT ON IF (SELECT object_id('tempdb..#TmpCargas')) IS NOT NULL DROP TABLE #TmpCargas ");
            fechaConsulta.AppendLine("SELECT CEDI = CASE WHEN TipoFase = 1 THEN (SELECT TOP 1 ClaveCEDI FROM AgendaVendedor AGV (NOLOCK) WHERE AGV.DiaClave = TRP.DiaClave AND VEN.USUId = TRP.MUsuarioID) ELSE TRP.Notas END, CONVERT(DATETIME, CONVERT(VARCHAR(20), D.FechaCaptura, 112)) AS FechaHoraAlta, TRP.Folio, VAD.Descripcion AS TipoFase, ");
            fechaConsulta.AppendLine("TPD.ProductoClave, TPD.TipoUnidad, VAD2.Descripcion AS TipoUnidadDes, TPD.Cantidad INTO #TmpCargas ");
            fechaConsulta.AppendLine("FROM (SELECT DiaClave, TransProdID, TipoFase, Folio, Tipo, Notas, MUsuarioID, FechaHoraAlta FROM TransProd (NOLOCK) WHERE Tipo = 2) TRP ");
            fechaConsulta.AppendLine("INNER JOIN (SELECT TransProdID, ProductoClave, TipoUnidad, Cantidad FROM TransProdDetalle (NOLOCK)) TPD ON TPD.TransProdID = TRP.TransProdID ");
            fechaConsulta.AppendLine("INNER JOIN (SELECT VAVClave, Descripcion FROM VAVDescripcion (NOLOCK) WHERE VARCodigo = 'TRPFASE' AND VADTipoLenguaje = 'EM') VAD ON VAD.VAVClave = TRP.TipoFase ");
            fechaConsulta.AppendLine("INNER JOIN VAVDescripcion VAD2 (NOLOCK) ON VAD2.VARCodigo = 'UNIDADV' AND VAD2.VAVClave = TPD.TipoUnidad AND VAD2.VADTipoLenguaje = 'EM' ");
            fechaConsulta.AppendLine("INNER JOIN (SELECT VendedorID, Nombre, UsuId FROM Vendedor (NOLOCK)) VEN ON VEN.UsuID = TRP.MUsuarioID ");
            fechaConsulta.AppendLine("INNER JOIN Dia d (NOLOCK) ON TRP.DiaClave = D.DiaClave ");
            fechaConsulta.AppendLine(string.Format("AND CONVERT(date, D.FechaCaptura, 112) BETWEEN '{0}' AND '{1}' ", FechaInicial, FechaFinal));
            fechaConsulta.AppendLine(string.Format("AND VEN.VendedorID = '{0}' ", Vendedores));
            fechaConsulta.AppendLine("AND TipoFase <> 0 ");

            fechaConsulta.AppendLine("SELECT ALN.Clave + ' ' + ALN.Nombre AS CEDI, TPD.FechaHoraAlta AS Fecha, TPD.ProductoClave AS Clave, PRO.Nombre AS Producto, TPD.TipoUnidadDes AS Unidad, SUM(TPD.Cantidad) AS Cantidad, PRD.Factor AS Piezas ");
            fechaConsulta.AppendLine("FROM #TmpCargas TPD ");
            fechaConsulta.AppendLine("INNER JOIN (SELECT ProductoClave, Nombre FROM Producto (NOLOCK)) PRO ON TPD.ProductoClave = PRO.ProductoClave ");
            fechaConsulta.AppendLine("INNER JOIN (SELECT ProductoClave, PRUTipoUnidad, ProductoDetClave, Factor FROM ProductoDetalle (NOLOCK)) PRD ON PRD.ProductoClave = PRO.ProductoClave ");
            fechaConsulta.AppendLine("AND PRD.PRUTipoUnidad = TPD.TipoUnidad AND PRD.ProductoDetClave = PRO.ProductoClave ");
            fechaConsulta.AppendLine("INNER JOIN Almacen ALN (NOLOCK) ON ALN.Clave = CEDI ");
            fechaConsulta.AppendLine(string.Format("AND ALN.AlmacenID = '{0}' ", CEDIS));
            fechaConsulta.AppendLine("GROUP BY ALN.Clave + ' ' + ALN.Nombre, TPD.FechaHoraAlta, TPD.ProductoClave, PRO.Nombre, TPD.TipoUnidadDes, PRD.Factor ");
            fechaConsulta.AppendLine("ORDER BY CEDI, Fecha, TPD.ProductoClave, Unidad ");
            fechaConsulta.AppendLine("IF (SELECT object_id('tempdb..#TmpCargas')) IS NOT NULL DROP TABLE #TmpCargas SET NOCOUNT OFF ");

            QueryString = "";

            QueryString = fechaConsulta.ToString();

            Connection.Open();
            List<SubCargasModel> subConsulta = Connection.Query<SubCargasModel>(QueryString, null, null, true, 9000).ToList();
            Connection.Close();

            var subLista = (from c in subConsulta
                            select c).ToList();

            var sub = (from gr in subLista group gr by new { gr.CEDI, gr.Fecha } into grupo select grupo);
            List<SubCargasModel> subformatlist = new List<SubCargasModel>();
            foreach (var grupo in sub)
            {
                foreach (var objetoAgrupado in grupo)
                {
                    subformatlist.Add(new SubCargasModel
                    {
                        CEDI = objetoAgrupado.CEDI,
                        Fecha = objetoAgrupado.Fecha,
                        Clave = objetoAgrupado.Clave,
                        Producto = objetoAgrupado.Producto,
                        Unidad = objetoAgrupado.Unidad,
                        Cantidad = objetoAgrupado.Cantidad,
                        Piezas = objetoAgrupado.Piezas * objetoAgrupado.Cantidad
                    });
                }
                subformatlist.Last().PiezasFecha = grupo.Sum(c => c.Piezas * c.Cantidad);
            }

            TotalFecha subreport = new TotalFecha();

            subreport.DataSource = subformatlist;

            //grouheader2
            GroupField groupCedis = new GroupField("Cedi");
            subreport.GroupHeader2.GroupFields.Add(groupCedis);
            //groupheader1
            GroupField groupFechas = new GroupField("Fecha");
            subreport.GroupHeader1.GroupFields.Add(groupFechas);

            //Datos del detail
            subreport.dClave.DataBindings.Add("Text", null, "Clave");
            subreport.dProducto.DataBindings.Add("Text", null, "Producto");
            subreport.dUnidades.DataBindings.Add("Text", null, "Unidad");
            subreport.dCantidad.DataBindings.Add("Text", null, "Cantidad");
            subreport.dPiezas.DataBindings.Add("Text", null, "Piezas");

            //Datos del groupfooter1
            subreport.fPiezas.DataBindings.Add("Text", null, "PiezasFecha");

            #endregion

            var lista = (from c in User
                         select c).ToList();

            var s = (from gr in lista group gr by new { gr.CEDI, gr.Fecha, gr.DescripcionFase, gr.Vendedor, gr.Folio } into grupo select grupo);
            List<CargasModel> formatlist = new List<CargasModel>();
            foreach (var grupo in s)
            {
                foreach (var objetoAgrupado in grupo)
                {
                    formatlist.Add(new CargasModel
                    {
                        CEDI = objetoAgrupado.CEDI,
                        Fecha = objetoAgrupado.Fecha,
                        Clave = objetoAgrupado.Clave,
                        Producto = objetoAgrupado.Producto,
                        Unidad = objetoAgrupado.Unidad,
                        Cantidad = objetoAgrupado.Cantidad,
                        Piezas = objetoAgrupado.Piezas * objetoAgrupado.Cantidad,
                        Vendedor = objetoAgrupado.Vendedor,
                        Folio = objetoAgrupado.Folio,
                        TipoFase = objetoAgrupado.Folio,
                        DescripcionFase = objetoAgrupado.DescripcionFase
                    });
                }
                formatlist.Last().PiezasFolio = grupo.Sum(c => c.Piezas * c.Cantidad);
            }

            FechaInicial = fInicio.Date.ToShortDateString();
            FechaFinal = fFin.Date.ToShortDateString();

            Connection.Open();
            report.logo.Image = Image.FromStream(LogoEmpresa);
            report.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;

            report.DataSource = formatlist;

            //ReportHeader
            report.empresa.Text = NombreEmpresa;
            report.reporte.Text = NombreReporte;
            report.headerlabelcedis.Text = NombreCEDIS;
            report.labelfechaheader.Text = FechaInicial + (FechaFinal == FechaInicial ? "" : " - " + FechaFinal);
            report.labelvendedorheader.DataBindings.Add("Text", report.DataSource, "Vendedor");

            //grouheader5
            GroupField groupCedi = new GroupField("CEDI");
            report.GroupHeader5.GroupFields.Add(groupCedi);
            report.cediClave.DataBindings.Add("Text", report.DataSource, "CEDI");
            //grouheader4
            GroupField groupFecha = new GroupField("Fecha");
            report.GroupHeader4.GroupFields.Add(groupFecha);
            report.Fecha.DataBindings.Add("Text", report.DataSource, "Fecha", "{0:dd/MM/yyyy}");
            //grouheader3
            GroupField groupFase = new GroupField("DescripcionFase");
            report.GroupHeader3.GroupFields.Add(groupFase);
            report.Fase.DataBindings.Add("Text", report.DataSource, "DescripcionFase");
            //grouheader2
            GroupField groupVendedor = new GroupField("Vendedor");
            report.GroupHeader2.GroupFields.Add(groupVendedor);
            report.Vendedor.DataBindings.Add("Text", report.DataSource, "Vendedor");
            //groupheader1
            GroupField groupFolio = new GroupField("Folio");
            report.GroupHeader1.GroupFields.Add(groupFolio);
            report.Folio.DataBindings.Add("Text", report.DataSource, "Folio");

            //Datos del detail
            report.dClave.DataBindings.Add("Text", null, "Clave");
            report.dProducto.DataBindings.Add("Text", null, "Producto");
            report.dUnidades.DataBindings.Add("Text", null, "Unidad");
            report.dCantidad.DataBindings.Add("Text", null, "Cantidad");
            report.dPiezas.DataBindings.Add("Text", null, "Piezas");

            //Datos del groupfooter1
            report.fPiezas.DataBindings.Add("Text", null, "PiezasFolio");

            if (subLista.Count() > 0)
            {
                report.xrSubreport1.ReportSource = subreport;
            }
            else
            {
                report.xrSubreport1.Visible = false;
            }

            #endregion
            return report;
        }
    }

    class CargasModel
    {
        public String CEDI { get; set; }
        public DateTime Fecha { get; set; }
        public String Clave { get; set; }
        public String Producto { get; set; }
        public String Unidad { get; set; }
        public long Cantidad { get; set; }
        public long Piezas { get; set; }
        public String Vendedor { get; set; }
        public String Folio { get; set; }
        public String TipoFase { get; set; }
        public String DescripcionFase { get; set; }
        public long PiezasFolio { get; set; }
    }

    class SubCargasModel
    {
        public String CEDI { get; set; }
        public DateTime Fecha { get; set; }
        public String Clave { get; set; }
        public String Producto { get; set; }
        public String Unidad { get; set; }
        public long Cantidad { get; set; }
        public long Piezas { get; set; }
        public long PiezasFecha { get; set; }
    }
}