VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} CC_RptFactura 
   Caption         =   "Factura"
   ClientHeight    =   11010
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   15240
   Icon            =   "CC_RptFactura.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   26882
   _ExtentY        =   19420
   SectionData     =   "CC_RptFactura.dsx":08CA
End
Attribute VB_Name = "CC_RptFactura"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina, STotal, CReg

Private Sub ActiveReport_ReportStart()
    STotal = 0
End Sub

Private Sub Detail_Format()
    STotal = STotal + DataSrc.Recordset.Fields(6).Value
End Sub

Private Sub PageFooter_Format()
Dim StrCantidad As Long, Str As Long

    Pagina = Pagina + 1
    
    For i = 1 To Len(STotal)
        If Mid(STotal, i, 1) = "." Then Exit For
        Str = Str & Mid(STotal, i, 1)
    Next
    StrCantidad = CLng(Str)
    LblCantidadConLetra.Caption = "( " & UCase(Numeros_x_Letras(StrCantidad) & " pesos " & CStr(Format((CDbl(STotal) - StrCantidad) * 100, "00")) & "/100 M.N. )")
End Sub

Private Sub ReportFooter_Format()
    LblCantidadConLetra.Visible = True
End Sub
