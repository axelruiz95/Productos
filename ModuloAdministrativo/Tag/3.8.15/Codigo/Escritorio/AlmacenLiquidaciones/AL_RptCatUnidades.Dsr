VERSION 5.00
Begin {82282820-C017-11D0-A87C-00A0C90F29FC} AL_RptCatUnidades 
   Caption         =   "Cat�logos"
   ClientHeight    =   11430
   ClientLeft      =   120
   ClientTop       =   180
   ClientWidth     =   18960
   Icon            =   "AL_RptCatUnidades.dsx":0000
   Palette         =   "AL_RptCatUnidades.dsx":08CA
   WindowState     =   2  'Maximized
   _ExtentX        =   33443
   _ExtentY        =   20161
   SectionData     =   "AL_RptCatUnidades.dsx":1E08
End
Attribute VB_Name = "AL_RptCatUnidades"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim Pagina

Private Sub ActiveReport_ReportStart()
    LblFechaImpresion.Caption = Format(Date, ctFechaLarga) & " - " & Format(Time, ctHoraLarga)
End Sub

Private Sub PageFooter_Format()
    Pagina = Pagina + 1
    LblPagN.Caption = Pagina
End Sub
