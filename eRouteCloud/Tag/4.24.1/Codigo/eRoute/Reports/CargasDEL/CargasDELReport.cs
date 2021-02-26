﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for AnalisisSaldosMOODetallado
/// </summary>
public class CargasDELReport : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRPageInfo xrPageInfo2;
    private XRPageInfo xrPageInfo1;
    public GroupHeaderBand GroupHeader1;
    private XRLabel xrLabel7;
    public GroupHeaderBand GroupHeader2;
    public GroupHeaderBand GroupHeader3;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    public XRLabel Fecha;
    public XRLabel Vendedor;
    public XRLabel Fase;
    private GroupFooterBand GroupFooter1;
    private GroupFooterBand GroupFooter2;
    private GroupFooterBand GroupFooter3;
    public GroupHeaderBand GroupHeader4;
    private GroupFooterBand GroupFooter4;
    private XRLabel xrLabel3;
    private XRLabel xrLabel2;
    public GroupHeaderBand GroupHeader5;
    private GroupFooterBand GroupFooter5;
    public XRLabel Folio;
    public XRLabel cediClave;
    public XRLabel dLote;
    public XRLabel dCantidad;
    public XRLabel dUnidades;
    public XRLabel dProducto;
    public XRLabel dClave;
    public XRLabel fPiezas;
    private XRLabel xrLabel25;
    public XRSubreport xrSubreport1;
    public XRLabel dCaducidad;
    public GroupHeaderBand GroupHeader6;
    private XRLabel xrLabel12;
    public XRLabel gLote;
    public XRSubreport xrSubreport2;
    private ReportFooterBand ReportFooter;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel33;
    private XRLine xrLine2;
    private XRLine xrLine1;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel8;
    private XRLabel xrLabel11;
    public XRLabel headerlabelcedis;
    public XRLabel labelfechaheader;
    public XRLabel labelvendedorheader;
    private XRLabel xrLabel20;
    private XRLabel xrLabel23;
    private XRLabel xrLabel24;
    public XRPictureBox logo;
    public XRLabel reporte;
    public XRLabel empresa;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public CargasDELReport()
    {
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.dCaducidad = new DevExpress.XtraReports.UI.XRLabel();
            this.dLote = new DevExpress.XtraReports.UI.XRLabel();
            this.dCantidad = new DevExpress.XtraReports.UI.XRLabel();
            this.dUnidades = new DevExpress.XtraReports.UI.XRLabel();
            this.dProducto = new DevExpress.XtraReports.UI.XRLabel();
            this.dClave = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.headerlabelcedis = new DevExpress.XtraReports.UI.XRLabel();
            this.labelfechaheader = new DevExpress.XtraReports.UI.XRLabel();
            this.labelvendedorheader = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Folio = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Vendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Fase = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Fecha = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.fPiezas = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter4 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrSubreport1 = new DevExpress.XtraReports.UI.XRSubreport();
            this.GroupHeader5 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.cediClave = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter5 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupHeader6 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.gLote = new DevExpress.XtraReports.UI.XRLabel();
            this.xrSubreport2 = new DevExpress.XtraReports.UI.XRSubreport();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.dCaducidad,
            this.dLote,
            this.dCantidad,
            this.dUnidades,
            this.dProducto,
            this.dClave});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 19.79167F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // dCaducidad
            // 
            this.dCaducidad.Dpi = 100F;
            this.dCaducidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dCaducidad.LocationFloat = new DevExpress.Utils.PointFloat(626.9424F, 3.041713F);
            this.dCaducidad.Multiline = true;
            this.dCaducidad.Name = "dCaducidad";
            this.dCaducidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dCaducidad.SizeF = new System.Drawing.SizeF(81.68268F, 12.99996F);
            this.dCaducidad.StylePriority.UseFont = false;
            this.dCaducidad.StylePriority.UseTextAlignment = false;
            this.dCaducidad.Text = "Caducidad";
            this.dCaducidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // dLote
            // 
            this.dLote.Dpi = 100F;
            this.dLote.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dLote.LocationFloat = new DevExpress.Utils.PointFloat(573.7338F, 3.041713F);
            this.dLote.Multiline = true;
            this.dLote.Name = "dLote";
            this.dLote.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dLote.SizeF = new System.Drawing.SizeF(53.7085F, 12.99996F);
            this.dLote.StylePriority.UseFont = false;
            this.dLote.StylePriority.UseTextAlignment = false;
            this.dLote.Text = "Lote";
            this.dLote.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // dCantidad
            // 
            this.dCantidad.Dpi = 100F;
            this.dCantidad.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dCantidad.LocationFloat = new DevExpress.Utils.PointFloat(709.1251F, 3.041713F);
            this.dCantidad.Multiline = true;
            this.dCantidad.Name = "dCantidad";
            this.dCantidad.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dCantidad.SizeF = new System.Drawing.SizeF(75.5835F, 12.99996F);
            this.dCantidad.StylePriority.UseFont = false;
            this.dCantidad.StylePriority.UseTextAlignment = false;
            this.dCantidad.Text = "Cantidad";
            this.dCantidad.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // dUnidades
            // 
            this.dUnidades.Dpi = 100F;
            this.dUnidades.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dUnidades.LocationFloat = new DevExpress.Utils.PointFloat(508.6088F, 3.041713F);
            this.dUnidades.Multiline = true;
            this.dUnidades.Name = "dUnidades";
            this.dUnidades.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dUnidades.SizeF = new System.Drawing.SizeF(64.12512F, 12.99996F);
            this.dUnidades.StylePriority.UseFont = false;
            this.dUnidades.StylePriority.UseTextAlignment = false;
            this.dUnidades.Text = "Unidades";
            this.dUnidades.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // dProducto
            // 
            this.dProducto.Dpi = 100F;
            this.dProducto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dProducto.LocationFloat = new DevExpress.Utils.PointFloat(183.2083F, 3.041713F);
            this.dProducto.Multiline = true;
            this.dProducto.Name = "dProducto";
            this.dProducto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dProducto.SizeF = new System.Drawing.SizeF(324.9006F, 12.99996F);
            this.dProducto.StylePriority.UseFont = false;
            this.dProducto.StylePriority.UseTextAlignment = false;
            this.dProducto.Text = "Producto";
            this.dProducto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // dClave
            // 
            this.dClave.Dpi = 100F;
            this.dClave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dClave.LocationFloat = new DevExpress.Utils.PointFloat(86.41661F, 3.041713F);
            this.dClave.Multiline = true;
            this.dClave.Name = "dClave";
            this.dClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.dClave.SizeF = new System.Drawing.SizeF(65.62502F, 12.99996F);
            this.dClave.StylePriority.UseFont = false;
            this.dClave.StylePriority.UseTextAlignment = false;
            this.dClave.Text = "Clave";
            this.dClave.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo,
            this.reporte,
            this.empresa,
            this.headerlabelcedis,
            this.labelfechaheader,
            this.labelvendedorheader,
            this.xrLabel20,
            this.xrLabel23,
            this.xrLabel24});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 189.6875F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // headerlabelcedis
            // 
            this.headerlabelcedis.Dpi = 100F;
            this.headerlabelcedis.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerlabelcedis.LocationFloat = new DevExpress.Utils.PointFloat(146.5139F, 120.6875F);
            this.headerlabelcedis.Name = "headerlabelcedis";
            this.headerlabelcedis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerlabelcedis.SizeF = new System.Drawing.SizeF(676.4861F, 22.99999F);
            this.headerlabelcedis.StylePriority.UseFont = false;
            // 
            // labelfechaheader
            // 
            this.labelfechaheader.Dpi = 100F;
            this.labelfechaheader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelfechaheader.LocationFloat = new DevExpress.Utils.PointFloat(146.5139F, 143.6875F);
            this.labelfechaheader.Name = "labelfechaheader";
            this.labelfechaheader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelfechaheader.SizeF = new System.Drawing.SizeF(676.4861F, 23F);
            this.labelfechaheader.StylePriority.UseFont = false;
            // 
            // labelvendedorheader
            // 
            this.labelvendedorheader.Dpi = 100F;
            this.labelvendedorheader.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelvendedorheader.LocationFloat = new DevExpress.Utils.PointFloat(146.5139F, 166.6875F);
            this.labelvendedorheader.Name = "labelvendedorheader";
            this.labelvendedorheader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.labelvendedorheader.SizeF = new System.Drawing.SizeF(676.4861F, 23F);
            this.labelvendedorheader.StylePriority.UseFont = false;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(2.388875F, 120.6875F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(140.625F, 23F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.Text = "Centro de Distribución";
            // 
            // xrLabel23
            // 
            this.xrLabel23.Dpi = 100F;
            this.xrLabel23.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(2.388875F, 143.6875F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(140.625F, 23F);
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.Text = "Fecha";
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(2.388891F, 166.6875F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(140.625F, 23F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.Text = "Vendedor";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrPageInfo1});
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 116F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.Format = "Página {0} de {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(418F, 82.99999F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(92.99998F, 82.99999F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Folio,
            this.xrLabel3});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 25.00001F;
            this.GroupHeader1.Level = 1;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // Folio
            // 
            this.Folio.Dpi = 100F;
            this.Folio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Folio.LocationFloat = new DevExpress.Utils.PointFloat(182.7083F, 0F);
            this.Folio.Name = "Folio";
            this.Folio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Folio.SizeF = new System.Drawing.SizeF(261.2914F, 23F);
            this.Folio.StylePriority.UseFont = false;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(51.54163F, 0F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(99.99998F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "Folio";
            // 
            // Vendedor
            // 
            this.Vendedor.Dpi = 100F;
            this.Vendedor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Vendedor.LocationFloat = new DevExpress.Utils.PointFloat(182.7083F, 4.083347F);
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Vendedor.SizeF = new System.Drawing.SizeF(261.2914F, 23F);
            this.Vendedor.StylePriority.UseFont = false;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(23.41669F, 3.041649F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(99.99998F, 23F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "Fase";
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(2.500041F, 0F);
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(135.625F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.Text = "Centro de Distribución";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Vendedor,
            this.xrLabel2});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 27.08335F;
            this.GroupHeader2.Level = 2;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(38.1251F, 4.083347F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(99.99998F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Vendedor";
            // 
            // Fase
            // 
            this.Fase.Dpi = 100F;
            this.Fase.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fase.LocationFloat = new DevExpress.Utils.PointFloat(182.7083F, 3.041681F);
            this.Fase.Name = "Fase";
            this.Fase.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Fase.SizeF = new System.Drawing.SizeF(261.2914F, 23F);
            this.Fase.StylePriority.UseFont = false;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(11.99998F, 3.041681F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(99.99998F, 23F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.Text = "Fecha";
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Fase,
            this.xrLabel10});
            this.GroupHeader3.Dpi = 100F;
            this.GroupHeader3.HeightF = 29.08331F;
            this.GroupHeader3.Level = 3;
            this.GroupHeader3.Name = "GroupHeader3";
            // 
            // Fecha
            // 
            this.Fecha.Dpi = 100F;
            this.Fecha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fecha.LocationFloat = new DevExpress.Utils.PointFloat(182.7083F, 0F);
            this.Fecha.Name = "Fecha";
            this.Fecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Fecha.SizeF = new System.Drawing.SizeF(261.2914F, 23F);
            this.Fecha.StylePriority.UseFont = false;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 28.125F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // fPiezas
            // 
            this.fPiezas.Dpi = 100F;
            this.fPiezas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fPiezas.LocationFloat = new DevExpress.Utils.PointFloat(720.0836F, 0F);
            this.fPiezas.Multiline = true;
            this.fPiezas.Name = "fPiezas";
            this.fPiezas.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.fPiezas.SizeF = new System.Drawing.SizeF(64.62506F, 24.04198F);
            this.fPiezas.StylePriority.UseFont = false;
            this.fPiezas.StylePriority.UseTextAlignment = false;
            this.fPiezas.Text = "Piezas";
            this.fPiezas.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel25
            // 
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(599.2672F, 0F);
            this.xrLabel25.Multiline = true;
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(71.03119F, 24.04198F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.StylePriority.UseTextAlignment = false;
            this.xrLabel25.Text = "TOTAL";
            this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.fPiezas,
            this.xrLabel25});
            this.GroupFooter2.Dpi = 100F;
            this.GroupFooter2.HeightF = 29.16667F;
            this.GroupFooter2.Level = 1;
            this.GroupFooter2.Name = "GroupFooter2";
            // 
            // GroupFooter3
            // 
            this.GroupFooter3.Dpi = 100F;
            this.GroupFooter3.HeightF = 0F;
            this.GroupFooter3.Level = 2;
            this.GroupFooter3.Name = "GroupFooter3";
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Fecha,
            this.xrLabel9});
            this.GroupHeader4.Dpi = 100F;
            this.GroupHeader4.HeightF = 26.04168F;
            this.GroupHeader4.Level = 4;
            this.GroupHeader4.Name = "GroupHeader4";
            // 
            // GroupFooter4
            // 
            this.GroupFooter4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreport1});
            this.GroupFooter4.Dpi = 100F;
            this.GroupFooter4.HeightF = 47.91676F;
            this.GroupFooter4.Level = 3;
            this.GroupFooter4.Name = "GroupFooter4";
            // 
            // xrSubreport1
            // 
            this.xrSubreport1.CanShrink = true;
            this.xrSubreport1.Dpi = 100F;
            this.xrSubreport1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrSubreport1.Name = "xrSubreport1";
            this.xrSubreport1.SizeF = new System.Drawing.SizeF(155.2083F, 46.66679F);
            // 
            // GroupHeader5
            // 
            this.GroupHeader5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.cediClave,
            this.xrLabel7});
            this.GroupHeader5.Dpi = 100F;
            this.GroupHeader5.HeightF = 23.95835F;
            this.GroupHeader5.Level = 5;
            this.GroupHeader5.Name = "GroupHeader5";
            // 
            // cediClave
            // 
            this.cediClave.Dpi = 100F;
            this.cediClave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cediClave.LocationFloat = new DevExpress.Utils.PointFloat(182.7083F, 0.9583473F);
            this.cediClave.Name = "cediClave";
            this.cediClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cediClave.SizeF = new System.Drawing.SizeF(261.2914F, 23F);
            this.cediClave.StylePriority.UseFont = false;
            // 
            // GroupFooter5
            // 
            this.GroupFooter5.Dpi = 100F;
            this.GroupFooter5.Expanded = false;
            this.GroupFooter5.HeightF = 1.041667F;
            this.GroupFooter5.Level = 4;
            this.GroupFooter5.Name = "GroupFooter5";
            // 
            // GroupHeader6
            // 
            this.GroupHeader6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12,
            this.gLote});
            this.GroupHeader6.Dpi = 100F;
            this.GroupHeader6.HeightF = 23F;
            this.GroupHeader6.Name = "GroupHeader6";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(73.41666F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(99.99998F, 23F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.Text = "Lote";
            // 
            // gLote
            // 
            this.gLote.Dpi = 100F;
            this.gLote.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gLote.LocationFloat = new DevExpress.Utils.PointFloat(183.2083F, 0F);
            this.gLote.Name = "gLote";
            this.gLote.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.gLote.SizeF = new System.Drawing.SizeF(261.2914F, 23F);
            this.gLote.StylePriority.UseFont = false;
            // 
            // xrSubreport2
            // 
            this.xrSubreport2.CanShrink = true;
            this.xrSubreport2.Dpi = 100F;
            this.xrSubreport2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrSubreport2.Name = "xrSubreport2";
            this.xrSubreport2.SizeF = new System.Drawing.SizeF(155.2083F, 46.66679F);
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrSubreport2});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 47.91667F;
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel33,
            this.xrLine2,
            this.xrLine1,
            this.xrLabel4,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel8,
            this.xrLabel11});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 80.0421F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrLabel33
            // 
            this.xrLabel33.Dpi = 100F;
            this.xrLabel33.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(88.11098F, 33F);
            this.xrLabel33.Multiline = true;
            this.xrLabel33.Name = "xrLabel33";
            this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel33.SizeF = new System.Drawing.SizeF(64.62506F, 24.04198F);
            this.xrLabel33.StylePriority.UseFont = false;
            this.xrLabel33.StylePriority.UseTextAlignment = false;
            this.xrLabel33.Text = "Clave";
            this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(2.694223F, 57.0421F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(819.1113F, 23F);
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(2.694415F, 10F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(819.1111F, 23F);
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(183.9027F, 33.00012F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(325.4005F, 24.04198F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Producto";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(509.3032F, 33F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(64.62506F, 24.04198F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Unidades";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(709.8195F, 33.00012F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(76.08344F, 24.04198F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Cantidad";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(628.6368F, 33.00012F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(81.18268F, 24.04198F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Caducidad";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(574.4283F, 33F);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(54.20844F, 24.04198F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "Lote";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(54.79166F, 5.000003F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(150F, 100F);
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(231.2917F, 70F);
            this.reporte.Name = "reporte";
            this.reporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.reporte.SizeF = new System.Drawing.SizeF(540F, 40F);
            this.reporte.StylePriority.UseFont = false;
            this.reporte.StylePriority.UseTextAlignment = false;
            this.reporte.Text = "reporte";
            this.reporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // empresa
            // 
            this.empresa.Dpi = 100F;
            this.empresa.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(231.2917F, 10.00001F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(540F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // CargasDELReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupHeader2,
            this.GroupHeader3,
            this.GroupFooter1,
            this.GroupFooter2,
            this.GroupFooter3,
            this.GroupHeader4,
            this.GroupFooter4,
            this.GroupHeader5,
            this.GroupFooter5,
            this.GroupHeader6,
            this.ReportFooter,
            this.ReportHeader});
            this.Margins = new System.Drawing.Printing.Margins(12, 15, 190, 116);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}