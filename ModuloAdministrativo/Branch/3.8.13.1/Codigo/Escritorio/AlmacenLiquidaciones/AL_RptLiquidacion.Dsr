VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptLiquidacion 
   Caption         =   "Liquidaci�n de Rutas"
   ClientHeight    =   11010
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   15240
   Icon            =   "AL_RptLiquidacion.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   26882
   _ExtentY        =   19420
   SectionData     =   "AL_RptLiquidacion.dsx":08CA
End
Attribute VB_Name = "AL_RptLiquidacion"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina

Private Sub ActiveReport_Activate()
    Set SubRptDetail.object = New AL_RptLiquidacionDet
    Set SubRptEfectivo.object = New AL_RptLiquidacionEfectivo
    Set SubRptComisiones.object = New AL_RptComisionesLiquidacion
    Set SubRptSaldos.object = New AL_RptLiquidacionSaldos
End Sub

Private Sub ActiveReport_ReportStart()
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
End Sub

Private Sub GroupFooter1_Format()
    Dim Total, TotalCobranza, TotalLiquidar

    Total = 0

    StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & _
            FormatDate(Fecha) & "', " & _
            IdSurtido & ", 0, 12"

    If RsC.State Then RsC.Close
    RsC.Open StrCmd, Cnn
    LblContado.Caption = FormatCurrency(0, 2, vbTrue): LblCredito.Caption = FormatCurrency(0, 2, vbTrue)
    LblTotal.Caption = FormatCurrency(0, 2, vbTrue): LblCobranza.Caption = FormatCurrency(0, 2, vbTrue)

    While Not RsC.EOF
        Select Case RsC.Fields(0)
            Case 2:
                LblContado.Caption = FormatCurrency(RsC.Fields(3), 2, vbTrue)
                LblContadoC.Caption = FormatCurrency(RsC.Fields(3), 2, vbTrue)
                Total = Total + CDbl(RsC.Fields(3))
                TotalLiquidar = TotalLiquidar + CDbl(RsC.Fields(3))
            Case 1:
                LblCredito.Caption = FormatCurrency(RsC.Fields(3), 2, vbTrue)
                Total = Total + CDbl(RsC.Fields(3))
            Case 99:
                LblCobranza.Caption = FormatCurrency(RsC.Fields(3), 2, vbTrue)
                TotalCobranza = RsC.Fields(3)
                TotalLiquidar = TotalLiquidar + CDbl(RsC.Fields(3))
                
        End Select
        RsC.MoveNext
    Wend
    LblTotal.Caption = FormatCurrency(Total, 2, vbTrue)
    LblTotalL.Caption = FormatCurrency(TotalLiquidar, 2, vbTrue)
    LblTotalLC.Caption = FormatCurrency(TotalLiquidar, 2, vbTrue)

    If LstConfiguraLiquidacion(1) = "S" Then
        StrCmd = "execute sel_Denominacion " & IdCedis & ", " & IdSurtido & ", 0, '', 0, 3"
        If Rs2.State Then Rs2.Close
        Rs2.Open StrCmd, Cnn
        LblEfectivo.Caption = FormatCurrency(0, 2, vbTrue)
        LblSaldo.Caption = FormatCurrency(0, 2, vbTrue)
        If Not Rs2.EOF Then
            LblEfectivo.Caption = FormatCurrency(Rs2.Fields(1) + Rs2.Fields(3), 2, vbTrue)
            LblSaldo.Caption = FormatCurrency(Rs2.Fields(2), 2, vbTrue)
            Select Case Rs2.Fields(2)
                Case 0: LblSaldoE.Caption = "Saldo"
                Case Else: LblSaldoE.Caption = IIf(Rs2.Fields(2) < 0, "Faltante", "Sobrante")
            End Select
            LblTotalE.Visible = True: LblEfectivo.Visible = True
            LblSaldoE.Visible = True: LblSaldo.Visible = True
       End If

        StrCmd = "execute sel_Denominacion " & IdCedis & ", " & IdSurtido & ", 0, '', 0, 2"
        If Rs3.State Then Rs3.Close
        Rs3.Open StrCmd, Cnn
        If Not Rs2.EOF Then
            SubRptEfectivo.object.DataSrcE.DataSourceName = Cnn
            SubRptEfectivo.object.DataSrcE.Recordset = Rs3
        End If
    Else
        LblTotalE.Visible = False: LblEfectivo.Visible = False
        LblSaldoE.Visible = False: LblSaldo.Visible = False
        SubRptEfectivo.Visible = False
    End If
    
    If LstConfiguraLiquidacion(2) = "S" Or LstConfiguraLiquidacion(3) = "S" Or LstConfiguraLiquidacion(4) = "S" Then
        StrCmd = "execute sel_VendedoresSaldos " & IdCedis & ", " & IdSurtido & ", 1"
        If RsC2.State Then RsC2.Close
        RsC2.Open StrCmd, Cnn
        If Not RsC2.EOF Then
            SubRptSaldos.Visible = True
            SubRptSaldos.object.DataSrcS.DataSourceName = Cnn
            SubRptSaldos.object.DataSrcS.Recordset = RsC2
        Else
            SubRptSaldos.Visible = False
        End If
    Else
        SubRptSaldos.Visible = False
    End If
    
    StrCmd = "execute sel_SurtidosVendedores " & IdCedis & ", " & IdSurtido
    Set RsDetail = New ADODB.Recordset
    If RsDetail.State Then RsDetail.Close
    RsDetail.Open StrCmd, Cnn
    
    If Not RsDetail.EOF Then
        SubRptDetail.object.DataSrc.DataSourceName = Cnn
        SubRptDetail.object.DataSrc.Recordset = RsDetail
    End If

'Dim Total
'
'    Total = 0
'    StrCmd = "execute sel_SurtidosDetalle " & IdCedis & ", '" & FormatDate(Fecha) & "', " & IdSurtido & ", 0, 5"
'    If RsC.State Then RsC.Close
'    RsC.Open StrCmd, Cnn
'
'    LblContado.Caption = FormatCurrency(0, 2, vbTrue): LblCredito.Caption = FormatCurrency(0, 2, vbTrue): LblTotal.Caption = FormatCurrency(0, 2, vbTrue)
'
'    While Not RsC.EOF
'        If RsC.Fields(0) = 2 Then
'            LblContado.Caption = FormatCurrency(RsC.Fields(3), 2, vbTrue)
'        Else
'            LblCredito.Caption = FormatCurrency(RsC.Fields(3), 2, vbTrue)
'        End If
'        Total = Total + CDbl(RsC.Fields(3))
'        RsC.MoveNext
'    Wend
'    LblTotal.Caption = FormatCurrency(Total, 2, vbTrue)
'
'    If LstConfiguraLiquidacion(1) = "S" Then
'        StrCmd = "execute sel_Denominacion " & IdCedis & ", " & IdSurtido & ", 0, '', 'MXP', 2"
'        If Rs2.State Then Rs2.Close
'        Rs2.Open StrCmd, Cnn
'        If Not Rs2.EOF Then
'            SubRptEfectivo.Visible = True
'            SubRptEfectivo.object.DataSrcE.DataSourceName = Cnn
'            SubRptEfectivo.object.DataSrcE.Recordset = Rs2
'            LblTotalE.Visible = True: LblEfectivo.Visible = True
'            LblSaldoE.Visible = True: LblSaldo.Visible = True
'        Else
'            LblTotalE.Visible = False: LblEfectivo.Visible = False
'            LblSaldoE.Visible = False: LblSaldo.Visible = False
'            SubRptEfectivo.Visible = False
'        End If
'    Else
'        LblTotalE.Visible = False: LblEfectivo.Visible = False
'        LblSaldoE.Visible = False: LblSaldo.Visible = False
'        SubRptEfectivo.Visible = False
'    End If
'
'    If LstConfiguraLiquidacion(2) = "S" Or LstConfiguraLiquidacion(3) = "S" Or LstConfiguraLiquidacion(4) = "S" Then
'        StrCmd = "execute sel_VendedoresSaldos " & IdCedis & ", " & IdSurtido & ", 1"
'        If RsC2.State Then RsC2.Close
'        RsC2.Open StrCmd, Cnn
'        If Not RsC2.EOF Then
'            SubRptSaldos.Visible = True
'            SubRptSaldos.object.DataSrcS.DataSourceName = Cnn
'            SubRptSaldos.object.DataSrcS.Recordset = RsC2
'        Else
'            SubRptSaldos.Visible = False
'        End If
'    Else
'        SubRptSaldos.Visible = False
'    End If
'
'    StrCmd = "execute sel_SurtidosVendedores " & IdCedis & ", " & IdSurtido
'    If Rs.State Then Rs.Close
'    Rs.Open StrCmd, Cnn
'
'    If Not Rs.EOF Then
'        SubRptDetail.Visible = True
'        SubRptDetail.object.DataSrc.DataSourceName = Cnn
'        SubRptDetail.object.DataSrc.Recordset = Rs
'    Else
'        SubRptDetail.Visible = False
'    End If
End Sub

Private Sub PageFooter_Format()
    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
End Sub

Private Sub ReportFooter_Format()

    Dim RsCom As New ADODB.Recordset
    
    If LstConfiguraLiquidacion(0) <> "N" Then
        StrCmd = "execute sel_ComisionesLiquidacion " & IdCedis & ", " & IdSurtido & ", '" & FormatDate(Fecha) & "', '" & FormatDate(Fecha) & "'"
        If RsCom.State Then RsCom.Close
        RsCom.Open StrCmd, Cnn
    
        SubRptComisiones.object.GroupHeader2.Visible = IIf(LstConfiguraLiquidacion(0) = "F" Or LstConfiguraLiquidacion(0) = "A", True, False)
        SubRptComisiones.object.GroupFooter2.Visible = IIf(LstConfiguraLiquidacion(0) = "F" Or LstConfiguraLiquidacion(0) = "A", True, False)
        SubRptComisiones.object.Detail.Visible = IIf(LstConfiguraLiquidacion(0) = "P" Or LstConfiguraLiquidacion(0) = "A", True, False)
        SubRptComisiones.object.LineFamilia.Visible = IIf(LstConfiguraLiquidacion(0) = "A", True, False)
        SubRptComisiones.object.LblRango.Visible = IIf(LstConfiguraLiquidacion(0) = "P" Or LstConfiguraLiquidacion(0) = "A", True, False)
        SubRptComisiones.object.LblProducto.Caption = IIf(LstConfiguraLiquidacion(0) = "F", "Familia", "Producto")
    
        With AL_RptComisionesLiquidacion
            SubRptComisiones.object.DataSrc.DataSourceName = Cnn: SubRptComisiones.object.DataSrc.Recordset = RsCom
        End With
    Else
        SubRptComisiones.Visible = False
    End If
End Sub