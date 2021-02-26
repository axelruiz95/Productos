﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReporteClientesRuta
/// </summary>
public class ReporteDocumentosConSaldoPDR : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRLabel xrLabel27;
    public XRPictureBox xrPictureBox1;
    private XRLabel xrLabel20;
    private XRLabel xrLabel24;
    private XRLabel xrLabel25;
    public XRLabel headerlabelCedis;
    public XRLabel headerlabelVendedor;
    public XRLabel headerlabelRuta;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLine xrLine1;
    private XRLine xrLine2;
    public GroupHeaderBand GroupHeader1;
    public GroupHeaderBand GroupHeader2;
    public GroupHeaderBand GroupHeader3;
    public GroupHeaderBand GroupHeader4;
    public XRLabel detalleSaldo;
    public XRLabel detalleTotal;
    public XRLabel detalleFechaCobranza;
    public XRLabel detalleFechaCaptura;
    public XRLabel detalleFolio;
    private GroupFooterBand GroupFooter1;
    private XRPageInfo xrPageInfo1;
    private XRPageInfo xrPageInfo2;
    private XRLabel xrLabel19;
    public XRLabel vendedorLabel;
    private XRLabel xrLabel18;
    public XRLabel cediLabel;
    private XRLabel xrLabel4;
    public XRLabel rutaLabel;
    public XRLabel headerlabelCliente;
    private XRLabel xrLabel2;
    private GroupFooterBand GroupFooter4;
    private GroupFooterBand GroupFooter2;
    private GroupFooterBand GroupFooter3;
    public XRLabel xrLabel10;
    public XRLabel xrLabel1;
    public XRLabel xrLabel9;
    public XRLabel xrLabel3;
    public XRLabel totalPorCEDI;
    public XRLabel totalPorCliente;
    public XRLabel totalPorVendedor;
    public XRLabel totalPorRuta;
    private ReportFooterBand ReportFooter;
    public XRLabel granTotal;
    public XRLabel xrLabel11;
    public XRLabel detalleCLINombre;
    public XRLabel detalleCLIClave;
    public XRLabel detalleCLINCorto;
    private XRLabel xrLabel12;
    private FormattingRule formattingRule1;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReporteDocumentosConSaldoPDR()
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
            this.detalleCLINCorto = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleSaldo = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleFechaCobranza = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleFechaCaptura = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleFolio = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleCLINombre = new DevExpress.XtraReports.UI.XRLabel();
            this.detalleCLIClave = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.headerlabelCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
            this.headerlabelCedis = new DevExpress.XtraReports.UI.XRLabel();
            this.headerlabelVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.headerlabelRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.cediLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
            this.vendedorLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.rutaLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader4 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.totalPorCEDI = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter4 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.totalPorCliente = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.totalPorVendedor = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter3 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.totalPorRuta = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.granTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.formattingRule1 = new DevExpress.XtraReports.UI.FormattingRule();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.detalleCLINCorto,
            this.detalleSaldo,
            this.detalleTotal,
            this.detalleFechaCobranza,
            this.detalleFechaCaptura,
            this.detalleFolio,
            this.detalleCLINombre,
            this.detalleCLIClave});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 16F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // detalleCLINCorto
            // 
            this.detalleCLINCorto.Dpi = 100F;
            this.detalleCLINCorto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleCLINCorto.LocationFloat = new DevExpress.Utils.PointFloat(255F, 0F);
            this.detalleCLINCorto.Name = "detalleCLINCorto";
            this.detalleCLINCorto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleCLINCorto.SizeF = new System.Drawing.SizeF(175F, 16F);
            this.detalleCLINCorto.StylePriority.UseFont = false;
            this.detalleCLINCorto.StylePriority.UseTextAlignment = false;
            this.detalleCLINCorto.Text = "CLINombre";
            this.detalleCLINCorto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.detalleCLINCorto.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.detalleNormal_BeforePrint);
            // 
            // detalleSaldo
            // 
            this.detalleSaldo.Dpi = 100F;
            this.detalleSaldo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleSaldo.LocationFloat = new DevExpress.Utils.PointFloat(745F, 0F);
            this.detalleSaldo.Multiline = true;
            this.detalleSaldo.Name = "detalleSaldo";
            this.detalleSaldo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleSaldo.SizeF = new System.Drawing.SizeF(77F, 16F);
            this.detalleSaldo.StylePriority.UseFont = false;
            this.detalleSaldo.StylePriority.UseTextAlignment = false;
            this.detalleSaldo.Text = "Saldo";
            this.detalleSaldo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.detalleSaldo.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.detalleNormal_BeforePrint);
            // 
            // detalleTotal
            // 
            this.detalleTotal.Dpi = 100F;
            this.detalleTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleTotal.LocationFloat = new DevExpress.Utils.PointFloat(665F, 0F);
            this.detalleTotal.Multiline = true;
            this.detalleTotal.Name = "detalleTotal";
            this.detalleTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleTotal.SizeF = new System.Drawing.SizeF(80F, 16F);
            this.detalleTotal.StylePriority.UseFont = false;
            this.detalleTotal.StylePriority.UseTextAlignment = false;
            this.detalleTotal.Text = "Total";
            this.detalleTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.detalleTotal.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.detalleNormal_BeforePrint);
            // 
            // detalleFechaCobranza
            // 
            this.detalleFechaCobranza.Dpi = 100F;
            this.detalleFechaCobranza.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleFechaCobranza.LocationFloat = new DevExpress.Utils.PointFloat(600F, 0F);
            this.detalleFechaCobranza.Multiline = true;
            this.detalleFechaCobranza.Name = "detalleFechaCobranza";
            this.detalleFechaCobranza.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleFechaCobranza.SizeF = new System.Drawing.SizeF(65F, 16F);
            this.detalleFechaCobranza.StylePriority.UseFont = false;
            this.detalleFechaCobranza.StylePriority.UseTextAlignment = false;
            this.detalleFechaCobranza.Text = "FechaCobranza";
            this.detalleFechaCobranza.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.detalleFechaCobranza.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.detalleFechaCobranza_BeforePrint);
            // 
            // detalleFechaCaptura
            // 
            this.detalleFechaCaptura.Dpi = 100F;
            this.detalleFechaCaptura.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleFechaCaptura.LocationFloat = new DevExpress.Utils.PointFloat(525F, 0F);
            this.detalleFechaCaptura.Multiline = true;
            this.detalleFechaCaptura.Name = "detalleFechaCaptura";
            this.detalleFechaCaptura.NullValueText = " ";
            this.detalleFechaCaptura.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleFechaCaptura.SizeF = new System.Drawing.SizeF(75F, 16F);
            this.detalleFechaCaptura.StylePriority.UseFont = false;
            this.detalleFechaCaptura.Text = "Fecha Captura";
            // 
            // detalleFolio
            // 
            this.detalleFolio.Dpi = 100F;
            this.detalleFolio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleFolio.LocationFloat = new DevExpress.Utils.PointFloat(430F, 0F);
            this.detalleFolio.Multiline = true;
            this.detalleFolio.Name = "detalleFolio";
            this.detalleFolio.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleFolio.SizeF = new System.Drawing.SizeF(95F, 16F);
            this.detalleFolio.StylePriority.UseFont = false;
            this.detalleFolio.Text = "Folio";
            this.detalleFolio.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.detalleNormal_BeforePrint);
            // 
            // detalleCLINombre
            // 
            this.detalleCLINombre.Dpi = 100F;
            this.detalleCLINombre.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleCLINombre.LocationFloat = new DevExpress.Utils.PointFloat(100F, 0F);
            this.detalleCLINombre.Name = "detalleCLINombre";
            this.detalleCLINombre.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleCLINombre.SizeF = new System.Drawing.SizeF(155F, 16F);
            this.detalleCLINombre.StylePriority.UseFont = false;
            this.detalleCLINombre.StylePriority.UseTextAlignment = false;
            this.detalleCLINombre.Text = "CLINombre";
            this.detalleCLINombre.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.detalleCLINombre.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.detalleNormal_BeforePrint);
            // 
            // detalleCLIClave
            // 
            this.detalleCLIClave.Dpi = 100F;
            this.detalleCLIClave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detalleCLIClave.LocationFloat = new DevExpress.Utils.PointFloat(5F, 0F);
            this.detalleCLIClave.Name = "detalleCLIClave";
            this.detalleCLIClave.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.detalleCLIClave.SizeF = new System.Drawing.SizeF(95F, 16F);
            this.detalleCLIClave.StylePriority.UseFont = false;
            this.detalleCLIClave.Text = "CLIClave";
            this.detalleCLIClave.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.detalleNormal_BeforePrint);
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12,
            this.headerlabelCliente,
            this.xrLabel2,
            this.xrLabel20,
            this.xrLabel24,
            this.xrLabel25,
            this.headerlabelCedis,
            this.headerlabelVendedor,
            this.headerlabelRuta,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel13,
            this.xrLabel14,
            this.xrLine1,
            this.xrLine2,
            this.xrLabel27,
            this.xrPictureBox1});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 294.125F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(255F, 230F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(175F, 35F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Nombre Comercial";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // headerlabelCliente
            // 
            this.headerlabelCliente.Dpi = 100F;
            this.headerlabelCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerlabelCliente.LocationFloat = new DevExpress.Utils.PointFloat(157F, 175F);
            this.headerlabelCliente.Name = "headerlabelCliente";
            this.headerlabelCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerlabelCliente.SizeF = new System.Drawing.SizeF(665F, 20F);
            this.headerlabelCliente.StylePriority.UseFont = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(5F, 175F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(152F, 20F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Cliente";
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(5F, 115F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(152F, 20F);
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.Text = "CEDI";
            // 
            // xrLabel24
            // 
            this.xrLabel24.Dpi = 100F;
            this.xrLabel24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(5F, 135F);
            this.xrLabel24.Name = "xrLabel24";
            this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel24.SizeF = new System.Drawing.SizeF(152F, 20F);
            this.xrLabel24.StylePriority.UseFont = false;
            this.xrLabel24.Text = "Vendedor";
            // 
            // xrLabel25
            // 
            this.xrLabel25.Dpi = 100F;
            this.xrLabel25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(5F, 155F);
            this.xrLabel25.Name = "xrLabel25";
            this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel25.SizeF = new System.Drawing.SizeF(152F, 20F);
            this.xrLabel25.StylePriority.UseFont = false;
            this.xrLabel25.Text = "Ruta";
            // 
            // headerlabelCedis
            // 
            this.headerlabelCedis.Dpi = 100F;
            this.headerlabelCedis.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerlabelCedis.LocationFloat = new DevExpress.Utils.PointFloat(157F, 115F);
            this.headerlabelCedis.Name = "headerlabelCedis";
            this.headerlabelCedis.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerlabelCedis.SizeF = new System.Drawing.SizeF(665F, 20F);
            this.headerlabelCedis.StylePriority.UseFont = false;
            // 
            // headerlabelVendedor
            // 
            this.headerlabelVendedor.Dpi = 100F;
            this.headerlabelVendedor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerlabelVendedor.LocationFloat = new DevExpress.Utils.PointFloat(157F, 135F);
            this.headerlabelVendedor.Name = "headerlabelVendedor";
            this.headerlabelVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerlabelVendedor.SizeF = new System.Drawing.SizeF(665F, 20F);
            this.headerlabelVendedor.StylePriority.UseFont = false;
            // 
            // headerlabelRuta
            // 
            this.headerlabelRuta.Dpi = 100F;
            this.headerlabelRuta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerlabelRuta.LocationFloat = new DevExpress.Utils.PointFloat(157F, 155F);
            this.headerlabelRuta.Name = "headerlabelRuta";
            this.headerlabelRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.headerlabelRuta.SizeF = new System.Drawing.SizeF(665F, 20F);
            this.headerlabelRuta.StylePriority.UseFont = false;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(430F, 230F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(95F, 35F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Folio";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(525F, 230F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(75F, 35F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Fecha Captura";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(600F, 230F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(65F, 35F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Fecha Cobranza";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(745F, 230F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(77F, 35F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Saldo";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(665F, 230F);
            this.xrLabel13.Multiline = true;
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(80F, 35F);
            this.xrLabel13.StylePriority.UseFont = false;
            this.xrLabel13.StylePriority.UseTextAlignment = false;
            this.xrLabel13.Text = "Total";
            this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(5F, 230F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(250F, 35F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "Cliente";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.Dpi = 100F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(5F, 205F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.SizeF = new System.Drawing.SizeF(817F, 23F);
            // 
            // xrLine2
            // 
            this.xrLine2.Dpi = 100F;
            this.xrLine2.LocationFloat = new DevExpress.Utils.PointFloat(5F, 270F);
            this.xrLine2.Name = "xrLine2";
            this.xrLine2.SizeF = new System.Drawing.SizeF(817F, 23F);
            // 
            // xrLabel27
            // 
            this.xrLabel27.Dpi = 100F;
            this.xrLabel27.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(254.5417F, 26.25F);
            this.xrLabel27.Name = "xrLabel27";
            this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel27.SizeF = new System.Drawing.SizeF(345.4583F, 23F);
            this.xrLabel27.StylePriority.UseFont = false;
            this.xrLabel27.StylePriority.UseTextAlignment = false;
            this.xrLabel27.Text = "DOCUMENTOS CON SALDO (PDR)";
            this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 100F;
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(5F, 5F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(152F, 95F);
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 100F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(100F, 38.5F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.Dpi = 100F;
            this.xrPageInfo2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPageInfo2.Format = "Página {0} de {1}";
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(430F, 38.5F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(313F, 23F);
            this.xrPageInfo2.StylePriority.UseFont = false;
            this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.cediLabel,
            this.xrLabel18});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 16.66667F;
            this.GroupHeader1.Level = 3;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // cediLabel
            // 
            this.cediLabel.Dpi = 100F;
            this.cediLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cediLabel.LocationFloat = new DevExpress.Utils.PointFloat(157F, 0F);
            this.cediLabel.Name = "cediLabel";
            this.cediLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.cediLabel.SizeF = new System.Drawing.SizeF(635F, 16F);
            this.cediLabel.StylePriority.UseFont = false;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(5F, 0F);
            this.xrLabel18.Multiline = true;
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(95F, 16F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.Text = "CEDI";
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel19,
            this.vendedorLabel});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 16.66667F;
            this.GroupHeader2.Level = 2;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // xrLabel19
            // 
            this.xrLabel19.Dpi = 100F;
            this.xrLabel19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(5F, 0F);
            this.xrLabel19.Multiline = true;
            this.xrLabel19.Name = "xrLabel19";
            this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel19.SizeF = new System.Drawing.SizeF(95F, 16F);
            this.xrLabel19.StylePriority.UseFont = false;
            this.xrLabel19.Text = "Vendedor";
            // 
            // vendedorLabel
            // 
            this.vendedorLabel.Dpi = 100F;
            this.vendedorLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendedorLabel.LocationFloat = new DevExpress.Utils.PointFloat(157F, 0F);
            this.vendedorLabel.Multiline = true;
            this.vendedorLabel.Name = "vendedorLabel";
            this.vendedorLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.vendedorLabel.SizeF = new System.Drawing.SizeF(635F, 16F);
            this.vendedorLabel.StylePriority.UseFont = false;
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.rutaLabel,
            this.xrLabel4});
            this.GroupHeader3.Dpi = 100F;
            this.GroupHeader3.HeightF = 16F;
            this.GroupHeader3.Level = 1;
            this.GroupHeader3.Name = "GroupHeader3";
            // 
            // rutaLabel
            // 
            this.rutaLabel.Dpi = 100F;
            this.rutaLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rutaLabel.LocationFloat = new DevExpress.Utils.PointFloat(157F, 0F);
            this.rutaLabel.Multiline = true;
            this.rutaLabel.Name = "rutaLabel";
            this.rutaLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.rutaLabel.SizeF = new System.Drawing.SizeF(635F, 16F);
            this.rutaLabel.StylePriority.UseFont = false;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(5F, 0F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(95F, 16F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "Ruta";
            // 
            // GroupHeader4
            // 
            this.GroupHeader4.Dpi = 100F;
            this.GroupHeader4.HeightF = 0F;
            this.GroupHeader4.Name = "GroupHeader4";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.totalPorCEDI,
            this.xrLabel10});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 16F;
            this.GroupFooter1.Level = 3;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // totalPorCEDI
            // 
            this.totalPorCEDI.Dpi = 100F;
            this.totalPorCEDI.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPorCEDI.LocationFloat = new DevExpress.Utils.PointFloat(665F, 0F);
            this.totalPorCEDI.Multiline = true;
            this.totalPorCEDI.Name = "totalPorCEDI";
            this.totalPorCEDI.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalPorCEDI.SizeF = new System.Drawing.SizeF(157F, 16F);
            this.totalPorCEDI.StylePriority.UseFont = false;
            this.totalPorCEDI.StylePriority.UseForeColor = false;
            this.totalPorCEDI.StylePriority.UseTextAlignment = false;
            this.totalPorCEDI.Text = "totalPorCEDI";
            this.totalPorCEDI.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(430F, 0F);
            this.xrLabel10.Multiline = true;
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(235F, 16F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.Text = "Total Por CEDI";
            // 
            // GroupFooter4
            // 
            this.GroupFooter4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.totalPorCliente,
            this.xrLabel1});
            this.GroupFooter4.Dpi = 100F;
            this.GroupFooter4.HeightF = 20F;
            this.GroupFooter4.Name = "GroupFooter4";
            // 
            // totalPorCliente
            // 
            this.totalPorCliente.Dpi = 100F;
            this.totalPorCliente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPorCliente.LocationFloat = new DevExpress.Utils.PointFloat(665F, 0F);
            this.totalPorCliente.Multiline = true;
            this.totalPorCliente.Name = "totalPorCliente";
            this.totalPorCliente.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalPorCliente.SizeF = new System.Drawing.SizeF(157F, 16F);
            this.totalPorCliente.StylePriority.UseFont = false;
            this.totalPorCliente.StylePriority.UseForeColor = false;
            this.totalPorCliente.StylePriority.UseTextAlignment = false;
            this.totalPorCliente.Text = "totalPorCliente";
            this.totalPorCliente.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(525F, 0F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(140F, 16F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Total Por Cliente";
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.totalPorVendedor,
            this.xrLabel9});
            this.GroupFooter2.Dpi = 100F;
            this.GroupFooter2.HeightF = 16.66667F;
            this.GroupFooter2.Level = 2;
            this.GroupFooter2.Name = "GroupFooter2";
            // 
            // totalPorVendedor
            // 
            this.totalPorVendedor.Dpi = 100F;
            this.totalPorVendedor.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPorVendedor.LocationFloat = new DevExpress.Utils.PointFloat(665F, 0F);
            this.totalPorVendedor.Multiline = true;
            this.totalPorVendedor.Name = "totalPorVendedor";
            this.totalPorVendedor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalPorVendedor.SizeF = new System.Drawing.SizeF(157F, 16.04F);
            this.totalPorVendedor.StylePriority.UseFont = false;
            this.totalPorVendedor.StylePriority.UseForeColor = false;
            this.totalPorVendedor.StylePriority.UseTextAlignment = false;
            this.totalPorVendedor.Text = "totalPorVendedor";
            this.totalPorVendedor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(430F, 0F);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(235F, 16.04F);
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.Text = "Total Por Vendedor";
            // 
            // GroupFooter3
            // 
            this.GroupFooter3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.totalPorRuta,
            this.xrLabel3});
            this.GroupFooter3.Dpi = 100F;
            this.GroupFooter3.HeightF = 25F;
            this.GroupFooter3.Level = 1;
            this.GroupFooter3.Name = "GroupFooter3";
            // 
            // totalPorRuta
            // 
            this.totalPorRuta.Dpi = 100F;
            this.totalPorRuta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPorRuta.LocationFloat = new DevExpress.Utils.PointFloat(665F, 9F);
            this.totalPorRuta.Multiline = true;
            this.totalPorRuta.Name = "totalPorRuta";
            this.totalPorRuta.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.totalPorRuta.SizeF = new System.Drawing.SizeF(157F, 16F);
            this.totalPorRuta.StylePriority.UseFont = false;
            this.totalPorRuta.StylePriority.UseForeColor = false;
            this.totalPorRuta.StylePriority.UseTextAlignment = false;
            this.totalPorRuta.Text = "totalPorRuta";
            this.totalPorRuta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(430F, 9F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(235F, 16F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "Total Por Ruta";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.granTotal,
            this.xrLabel11});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 25F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // granTotal
            // 
            this.granTotal.Dpi = 100F;
            this.granTotal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.granTotal.LocationFloat = new DevExpress.Utils.PointFloat(665F, 9F);
            this.granTotal.Multiline = true;
            this.granTotal.Name = "granTotal";
            this.granTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.granTotal.SizeF = new System.Drawing.SizeF(157F, 16F);
            this.granTotal.StylePriority.UseFont = false;
            this.granTotal.StylePriority.UseForeColor = false;
            this.granTotal.StylePriority.UseTextAlignment = false;
            this.granTotal.Text = "totalPorCEDI";
            this.granTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(430F, 9F);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(235F, 16F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.Text = "GRAN TOTAL";
            // 
            // formattingRule1
            // 
            this.formattingRule1.Name = "formattingRule1";
            // 
            // ReporteDocumentosConSaldoPDR
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupHeader2,
            this.GroupHeader3,
            this.GroupHeader4,
            this.GroupFooter1,
            this.GroupFooter4,
            this.GroupFooter2,
            this.GroupFooter3,
            this.ReportFooter});
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.formattingRule1});
            this.Margins = new System.Drawing.Printing.Margins(14, 14, 294, 100);
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private void detalleFechaCobranza_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        // Create a new rule and add it to a report.
        FormattingRule rule1 = new FormattingRule();
        this.FormattingRuleSheet.Add(rule1);

        // Specify the rule's properties.
        rule1.DataSource = this.DataSource;
        rule1.DataMember = this.DataMember;
        rule1.Condition = "[FechaCobranza] < LocalDateTimeToday()";
        rule1.Formatting.ForeColor = Color.Red;
        rule1.Formatting.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        // Apply this rule to the detail band.
        this.Detail.FormattingRules.Add(rule1);

        // Create a new rule and add it to a report.
        FormattingRule rule2 = new FormattingRule();
        this.FormattingRuleSheet.Add(rule2);

        // Specify the rule's properties.
        rule2.DataSource = this.DataSource;
        rule2.DataMember = this.DataMember;
        rule2.Condition = "[FechaCobranza] >= LocalDateTimeToday()";
        rule2.Formatting.ForeColor = Color.Black;
        rule2.Formatting.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


        // Apply this rule to the detail band.
        this.Detail.FormattingRules.Add(rule2);
    }

    private void detalleNormal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        // Create a new rule and add it to a report.
        FormattingRule rule3 = new FormattingRule();
        this.FormattingRuleSheet.Add(rule3);

        // Specify the rule's properties.
        rule3.DataSource = this.DataSource;
        rule3.DataMember = this.DataMember;
        rule3.Condition = "1 == 1";
        rule3.Formatting.ForeColor = Color.Black;
        rule3.Formatting.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        // Apply this rule to the detail band.
        this.Detail.FormattingRules.Add(rule3);
    }
}