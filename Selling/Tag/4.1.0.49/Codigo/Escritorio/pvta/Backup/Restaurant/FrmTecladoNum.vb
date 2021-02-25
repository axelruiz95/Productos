Public Class FrmTecladoNum

    Public Cantidad As String = ""
    Private bError As Boolean = False

    Private Sub FrmTecladoNum_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If bError Then
            e.Cancel = True
        End If
    End Sub


    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn1.Click
        TxtCantidad.Text &= "1"
    End Sub

    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn2.Click
        TxtCantidad.Text &= "2"
    End Sub

    Private Sub Btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn3.Click
        TxtCantidad.Text &= "3"
    End Sub

    Private Sub Btn4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn4.Click
        TxtCantidad.Text &= "4"
    End Sub

    Private Sub Btn5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn5.Click
        TxtCantidad.Text &= "5"
    End Sub

    Private Sub Btn6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn6.Click
        TxtCantidad.Text &= "6"
    End Sub

    Private Sub Btn7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn7.Click
        TxtCantidad.Text &= "7"
    End Sub

    Private Sub Btn8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn8.Click
        TxtCantidad.Text &= "8"
    End Sub

    Private Sub Btn9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn9.Click
        TxtCantidad.Text &= "9"
    End Sub

    Private Sub BtnPunto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPunto.Click
        TxtCantidad.Text &= "."
    End Sub

    Private Sub BtnCero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCero.Click
        TxtCantidad.Text &= "0"
    End Sub

    Private Sub BtnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBorrar.Click
        TxtCantidad.Text = ""
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        bError = False
        Me.Close()
    End Sub

 
    Private Sub BtnDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeshacer.Click
        If TxtCantidad.Text <> "" Then
            TxtCantidad.Text = TxtCantidad.Text.Remove(TxtCantidad.TextLength - 1, 1)
        End If
    End Sub

    Private Sub BtnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnter.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Cantidad = TxtCantidad.Text
        bError = False
    End Sub

    Private Sub FrmTecladoNum_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Show()
        Me.BringToFront()
    End Sub

    Private Sub BtnGuion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuion.Click
        TxtCantidad.Text &= "-"
    End Sub
End Class