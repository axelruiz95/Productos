﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReportePuntosRecorrido
/// </summary>
public class ReporteCFDInota : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    public XRLabel z9;
    public XRLabel z10;
    public XRLabel z8;
    public XRLabel z7;
    public XRLabel z6;
    public XRLabel z5;
    public XRLabel z4;
    public XRLabel z3;
    public XRLabel z2;
    public XRLabel z1;
    private GroupHeaderBand GroupHeader2;
    private XRLabel xrLabel9;
    private XRLabel xrLabel21;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel18;
    private XRLabel xrLabel20;
    private XRLabel xrLabel10;
    private XRLabel xrLabel15;
    private ReportHeaderBand ReportHeader;    
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRLabel xrLabel5;
    public XRLabel tipo;
    public XRLabel periodo;
    public XRLabel estatus;
    public XRPictureBox logo;
    public XRLabel reporte;
    public XRLabel empresa;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public ReporteCFDInota()
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
            this.z9 = new DevExpress.XtraReports.UI.XRLabel();
            this.z10 = new DevExpress.XtraReports.UI.XRLabel();
            this.z8 = new DevExpress.XtraReports.UI.XRLabel();
            this.z7 = new DevExpress.XtraReports.UI.XRLabel();
            this.z6 = new DevExpress.XtraReports.UI.XRLabel();
            this.z5 = new DevExpress.XtraReports.UI.XRLabel();
            this.z4 = new DevExpress.XtraReports.UI.XRLabel();
            this.z3 = new DevExpress.XtraReports.UI.XRLabel();
            this.z2 = new DevExpress.XtraReports.UI.XRLabel();
            this.z1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.reporte = new DevExpress.XtraReports.UI.XRLabel();
            this.empresa = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.tipo = new DevExpress.XtraReports.UI.XRLabel();
            this.periodo = new DevExpress.XtraReports.UI.XRLabel();
            this.estatus = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.z9,
            this.z10,
            this.z8,
            this.z7,
            this.z6,
            this.z5,
            this.z4,
            this.z3,
            this.z2,
            this.z1});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 26.04167F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // z9
            // 
            this.z9.Dpi = 100F;
            this.z9.LocationFloat = new DevExpress.Utils.PointFloat(712.5F, 0F);
            this.z9.Name = "z9";
            this.z9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.z9.SizeF = new System.Drawing.SizeF(62.5F, 23F);
            this.z9.Text = "Total";
            // 
            // z10
            // 
            this.z10.Dpi = 100F;
            this.z10.LocationFloat = new DevExpress.Utils.PointFloat(775F, 0F);
            this.z10.Name = "z10";
            this.z10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.z10.SizeF = new System.Drawing.SizeF(62F, 23F);
            this.z10.Text = "Estatus";
            // 
            // z8
            // 
            this.z8.Dpi = 100F;
            this.z8.LocationFloat = new DevExpress.Utils.PointFloat(650F, 0F);
            this.z8.Name = "z8";
            this.z8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.z8.SizeF = new System.Drawing.SizeF(62.5F, 23F);
            this.z8.Text = "IVA";
            // 
            // z7
            // 
            this.z7.Dpi = 100F;
            this.z7.LocationFloat = new DevExpress.Utils.PointFloat(575F, 0F);
            this.z7.Name = "z7";
            this.z7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.z7.SizeF = new System.Drawing.SizeF(75F, 23F);
            this.z7.Text = "Sub";
            // 
            // z6
            // 
            this.z6.Dpi = 100F;
            this.z6.LocationFloat = new DevExpress.Utils.PointFloat(500F, 0F);
            this.z6.Name = "z6";
            this.z6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.z6.SizeF = new System.Drawing.SizeF(75F, 23F);
            this.z6.Text = "Fecha";
            // 
            // z5
            // 
            this.z5.Dpi = 100F;
            this.z5.LocationFloat = new DevExpress.Utils.PointFloat(438.3489F, 0F);
            this.z5.Name = "z5";
            this.z5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.z5.SizeF = new System.Drawing.SizeF(61.56244F, 23F);
            this.z5.Text = "Folio";
            // 
            // z4
            // 
            this.z4.Dpi = 100F;
            this.z4.LocationFloat = new DevExpress.Utils.PointFloat(387.5F, 0F);
            this.z4.Name = "z4";
            this.z4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.z4.SizeF = new System.Drawing.SizeF(50F, 23F);
            this.z4.Text = "Serie";
            // 
            // z3
            // 
            this.z3.Dpi = 100F;
            this.z3.LocationFloat = new DevExpress.Utils.PointFloat(337.5F, 0F);
            this.z3.Name = "z3";
            this.z3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.z3.SizeF = new System.Drawing.SizeF(50F, 23F);
            this.z3.Text = "TipoDocumento";
            // 
            // z2
            // 
            this.z2.Dpi = 100F;
            this.z2.LocationFloat = new DevExpress.Utils.PointFloat(62.5F, 0F);
            this.z2.Name = "z2";
            this.z2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.z2.SizeF = new System.Drawing.SizeF(275F, 23F);
            this.z2.Text = "Nombre";
            // 
            // z1
            // 
            this.z1.Dpi = 100F;
            this.z1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.z1.Name = "z1";
            this.z1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.z1.SizeF = new System.Drawing.SizeF(62.5F, 23F);
            this.z1.Text = "Cliente";
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 13F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.TopMargin.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.TopMargin_BeforePrint);
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 1F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel9,
            this.xrLabel21,
            this.xrLabel11,
            this.xrLabel12,
            this.xrLabel13,
            this.xrLabel14,
            this.xrLabel18,
            this.xrLabel20,
            this.xrLabel10,
            this.xrLabel15});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 23F;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // xrLabel9
            // 
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(62.5F, 23F);
            this.xrLabel9.Text = "Cliente";
            // 
            // xrLabel21
            // 
            this.xrLabel21.Dpi = 100F;
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(62.5F, 0F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(275F, 23F);
            this.xrLabel21.Text = "Nombre";
            // 
            // xrLabel11
            // 
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(337.5F, 0F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(50F, 23F);
            this.xrLabel11.Text = "Tipo";
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(387.5F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(50F, 23F);
            this.xrLabel12.Text = "Serie";
            // 
            // xrLabel13
            // 
            this.xrLabel13.Dpi = 100F;
            this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(438.3489F, 0F);
            this.xrLabel13.Name = "xrLabel13";
            this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel13.SizeF = new System.Drawing.SizeF(61.56244F, 23F);
            this.xrLabel13.Text = "Folio";
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 100F;
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(500F, 0F);
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(75F, 23F);
            this.xrLabel14.Text = "Fecha";
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 100F;
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(575F, 0F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(75F, 23F);
            this.xrLabel18.Text = "Sub";
            // 
            // xrLabel20
            // 
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(650F, 0F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(62.5F, 23F);
            this.xrLabel20.Text = "IVA";
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(712.5F, 0F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(62.5F, 23F);
            this.xrLabel10.Text = "Total";
            // 
            // xrLabel15
            // 
            this.xrLabel15.Dpi = 100F;
            this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(775F, 0F);
            this.xrLabel15.Name = "xrLabel15";
            this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel15.SizeF = new System.Drawing.SizeF(62F, 23F);
            this.xrLabel15.Text = "Estatus";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo,
            this.empresa,
            this.xrLabel3,
            this.xrLabel4,
            this.xrLabel5,
            this.tipo,
            this.periodo,
            this.estatus,
            this.reporte});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 225.6667F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // logo
            // 
            this.logo.Dpi = 100F;
            this.logo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 12.5F);
            this.logo.Name = "logo";
            this.logo.SizeF = new System.Drawing.SizeF(150F, 102.5F);
            // 
            // reporte
            // 
            this.reporte.Dpi = 100F;
            this.reporte.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.reporte.LocationFloat = new DevExpress.Utils.PointFloat(150F, 75F);
            this.reporte.Name = "reporte";
            this.reporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.reporte.SizeF = new System.Drawing.SizeF(687F, 40F);
            this.reporte.StylePriority.UseFont = false;
            this.reporte.StylePriority.UseTextAlignment = false;
            this.reporte.Text = "reporte";
            this.reporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // empresa
            // 
            this.empresa.Dpi = 100F;
            this.empresa.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
            this.empresa.LocationFloat = new DevExpress.Utils.PointFloat(150F, 12.5F);
            this.empresa.Name = "empresa";
            this.empresa.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.empresa.SizeF = new System.Drawing.SizeF(687F, 40F);
            this.empresa.StylePriority.UseFont = false;
            this.empresa.StylePriority.UseTextAlignment = false;
            this.empresa.Text = "empresa";
            this.empresa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 137.5F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(336.4803F, 23F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "Tipo de Documento:";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 162.5F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(336.4803F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "Periodo";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 187.5F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(336.4803F, 23F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "Estatus:";
            // 
            // tipo
            // 
            this.tipo.Dpi = 100F;
            this.tipo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipo.LocationFloat = new DevExpress.Utils.PointFloat(336.9902F, 137.5F);
            this.tipo.Name = "tipo";
            this.tipo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tipo.SizeF = new System.Drawing.SizeF(238.0098F, 23F);
            this.tipo.StylePriority.UseFont = false;
            this.tipo.Text = "tipo";
            // 
            // periodo
            // 
            this.periodo.Dpi = 100F;
            this.periodo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodo.LocationFloat = new DevExpress.Utils.PointFloat(336.9902F, 162.5F);
            this.periodo.Name = "periodo";
            this.periodo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.periodo.SizeF = new System.Drawing.SizeF(238.0098F, 23F);
            this.periodo.StylePriority.UseFont = false;
            this.periodo.Text = "periodo";
            // 
            // estatus
            // 
            this.estatus.Dpi = 100F;
            this.estatus.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estatus.LocationFloat = new DevExpress.Utils.PointFloat(336.9902F, 187.5F);
            this.estatus.Name = "estatus";
            this.estatus.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.estatus.SizeF = new System.Drawing.SizeF(238.0098F, 23F);
            this.estatus.StylePriority.UseFont = false;
            this.estatus.Text = "estatus";
            // 
            // ReporteCFDInota
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader2,
            this.ReportHeader});
            this.Margins = new System.Drawing.Printing.Margins(12, 1, 13, 1);
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

    }
}