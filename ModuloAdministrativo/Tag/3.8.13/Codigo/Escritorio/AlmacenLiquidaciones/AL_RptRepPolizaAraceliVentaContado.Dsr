VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptRepPolizaAraceliVentaContado 
   Caption         =   "P�liza"
   ClientHeight    =   11430
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   18960
   Icon            =   "AL_RptRepPolizaAraceliVentaContado.dsx":0000
   StartUpPosition =   2  'CenterScreen
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20161
   SectionData     =   "AL_RptRepPolizaAraceliVentaContado.dsx":08CA
End
Attribute VB_Name = "AL_RptRepPolizaAraceliVentaContado"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub Detail_Format()
On Error Resume Next
    Select Case DataSrc.Recordset!IdCliente.Value
        Case 1, 2, 4:
            Detail.Visible = True
            Line21.Visible = True
        Case Else:
            Detail.Visible = False
            Line21.Visible = False
    End Select
End Sub

