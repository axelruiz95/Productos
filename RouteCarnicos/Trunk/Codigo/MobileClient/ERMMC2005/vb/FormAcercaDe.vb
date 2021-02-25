Public Class FormAcercaDe
    Public refaVista As Vista

    Private Sub FormAcercaDe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        [Global].ObtenerFactores(Me)
        [Global].EscalarFuente(Me)
        [Global].EscalarForma(Me)

        Dim AcercaDe As New System.Text.StringBuilder
        AcercaDe.Append("AMESOL Guadalajara, Jos� Ma. Vigil #2706-2 Lomas de Guevara, Guadalajara Jalisco, 44657 M�xico, Tel�fono: +52(33) 3648-60-70, infogdl@amesol.com " & vbCrLf)
        AcercaDe.Append("Advertencia: Este programa est� protegido por leyes de copyright y tratados internacionales. La reproducci�n o distribuci�n no autorizada de este programa o de parte del mismo dar� lugar a graves penalizaciones tanto civiles como penales y ser� objeto de cuantas acciones judiciales correspondan en derecho." & vbCrLf)
        AcercaDe.Append("Copyright � 2006 Amesol Group" & vbCrLf)

        LabelVersion.Text = "AMESOL Route Mobile Versi�n " & PubsVersion
        LabelInfo.Text = AcercaDe.ToString

        If Not Vista.Buscar("FormAcercaDe", refaVista) Then
            Exit Sub
        End If

        ' Recuperar los r�tulos y elementos de la pantalla desde la base de datos
        refaVista.ColocarEtiquetasForma(Me)

    End Sub


    Private Sub ButtonContinuar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonContinuar.Click
        Me.Close()
    End Sub
End Class