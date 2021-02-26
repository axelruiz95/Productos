﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for ReporteClientesRuta
/// </summary>
public class SubReporteDesglose : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private GroupHeaderBand GroupHeader1;
    public GroupHeaderBand GroupHeader2;
    private GroupFooterBand GroupFooter1;
    public GroupFooterBand GroupFooter2;
    private XRLabel xrLabel3;
    private XRLabel xrLabel20;
    private XRLabel xrLabel1;
    private XRLabel xrLabel5;
    public XRLabel DTipo;
    private XRLabel xrLabel4;
    private XRLabel xrLabel2;
    public XRLabel DBanco;
    public XRLabel DReferencia;
    public XRLabel DFecha;
    public XRLabel DImporte;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public SubReporteDesglose()
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
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.GroupFooter2 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.DTipo = new DevExpress.XtraReports.UI.XRLabel();
            this.DImporte = new DevExpress.XtraReports.UI.XRLabel();
            this.DFecha = new DevExpress.XtraReports.UI.XRLabel();
            this.DReferencia = new DevExpress.XtraReports.UI.XRLabel();
            this.DBanco = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.DTipo,
            this.DBanco,
            this.DReferencia,
            this.DFecha,
            this.DImporte});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 20F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel2,
            this.xrLabel1,
            this.xrLabel3,
            this.xrLabel20});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 16F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(110F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(130F, 16F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Banco";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(240F, 0F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(141.4583F, 16F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Referencia";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // xrLabel20
            // 
            this.xrLabel20.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel20.Dpi = 100F;
            this.xrLabel20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel20.Name = "xrLabel20";
            this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel20.SizeF = new System.Drawing.SizeF(110F, 16F);
            this.xrLabel20.StylePriority.UseBorders = false;
            this.xrLabel20.StylePriority.UseFont = false;
            this.xrLabel20.StylePriority.UseTextAlignment = false;
            this.xrLabel20.Text = "Tipo";
            this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupHeader2
            // 
            this.GroupHeader2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5});
            this.GroupHeader2.Dpi = 100F;
            this.GroupHeader2.HeightF = 16.66667F;
            this.GroupHeader2.Level = 1;
            this.GroupHeader2.Name = "GroupHeader2";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(700.9167F, 16F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Documentos";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 0F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // GroupFooter2
            // 
            this.GroupFooter2.Dpi = 100F;
            this.GroupFooter2.HeightF = 0F;
            this.GroupFooter2.Level = 1;
            this.GroupFooter2.Name = "GroupFooter2";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(381.4583F, 0F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(210F, 16F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Fecha";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(591.4584F, 0F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(109F, 16F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Importe";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // DTipo
            // 
            this.DTipo.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.DTipo.Dpi = 100F;
            this.DTipo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTipo.LocationFloat = new DevExpress.Utils.PointFloat(0.270813F, 0F);
            this.DTipo.Name = "DTipo";
            this.DTipo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DTipo.SizeF = new System.Drawing.SizeF(110F, 16F);
            this.DTipo.StylePriority.UseBorders = false;
            this.DTipo.StylePriority.UseFont = false;
            this.DTipo.StylePriority.UseTextAlignment = false;
            this.DTipo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // DImporte
            // 
            this.DImporte.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.DImporte.Dpi = 100F;
            this.DImporte.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DImporte.LocationFloat = new DevExpress.Utils.PointFloat(591.7292F, 0F);
            this.DImporte.Multiline = true;
            this.DImporte.Name = "DImporte";
            this.DImporte.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DImporte.SizeF = new System.Drawing.SizeF(109F, 16F);
            this.DImporte.StylePriority.UseBorders = false;
            this.DImporte.StylePriority.UseFont = false;
            this.DImporte.StylePriority.UseTextAlignment = false;
            this.DImporte.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // DFecha
            // 
            this.DFecha.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.DFecha.Dpi = 100F;
            this.DFecha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DFecha.LocationFloat = new DevExpress.Utils.PointFloat(381.7292F, 0F);
            this.DFecha.Multiline = true;
            this.DFecha.Name = "DFecha";
            this.DFecha.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DFecha.SizeF = new System.Drawing.SizeF(210F, 16F);
            this.DFecha.StylePriority.UseBorders = false;
            this.DFecha.StylePriority.UseFont = false;
            this.DFecha.StylePriority.UseTextAlignment = false;
            this.DFecha.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // DReferencia
            // 
            this.DReferencia.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.DReferencia.Dpi = 100F;
            this.DReferencia.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DReferencia.LocationFloat = new DevExpress.Utils.PointFloat(240.2708F, 0F);
            this.DReferencia.Multiline = true;
            this.DReferencia.Name = "DReferencia";
            this.DReferencia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DReferencia.SizeF = new System.Drawing.SizeF(141.4583F, 16F);
            this.DReferencia.StylePriority.UseBorders = false;
            this.DReferencia.StylePriority.UseFont = false;
            this.DReferencia.StylePriority.UseTextAlignment = false;
            this.DReferencia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // DBanco
            // 
            this.DBanco.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.DBanco.Dpi = 100F;
            this.DBanco.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DBanco.LocationFloat = new DevExpress.Utils.PointFloat(110.2708F, 0F);
            this.DBanco.Name = "DBanco";
            this.DBanco.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DBanco.SizeF = new System.Drawing.SizeF(130F, 16F);
            this.DBanco.StylePriority.UseBorders = false;
            this.DBanco.StylePriority.UseFont = false;
            this.DBanco.StylePriority.UseTextAlignment = false;
            this.DBanco.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // SubReporteDesglose
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupHeader2,
            this.GroupFooter1,
            this.GroupFooter2});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(14, 385, 0, 0);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}