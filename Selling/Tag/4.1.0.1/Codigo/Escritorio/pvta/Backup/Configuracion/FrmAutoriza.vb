Public Class FrmAutoriza
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpAutorizacion As System.Windows.Forms.GroupBox
    Friend WithEvents cmbUsuario As Selling.StoreCombo
    Friend WithEvents GrpRango As System.Windows.Forms.GroupBox
    Friend WithEvents TxtInicial As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents TxtFinal As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtConfirmar As System.Windows.Forms.TextBox
    Friend WithEvents TxtFirma As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtDias As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAutoriza))
        Me.GrpAutorizacion = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtDias = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtConfirmar = New System.Windows.Forms.TextBox
        Me.TxtFirma = New System.Windows.Forms.TextBox
        Me.cmbUsuario = New Selling.StoreCombo
        Me.LblNombre = New System.Windows.Forms.Label
        Me.LblClave = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        Me.GrpRango = New System.Windows.Forms.GroupBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtFinal = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.TxtInicial = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpAutorizacion.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpRango.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpAutorizacion
        '
        Me.GrpAutorizacion.Controls.Add(Me.Label7)
        Me.GrpAutorizacion.Controls.Add(Me.Label6)
        Me.GrpAutorizacion.Controls.Add(Me.TxtDias)
        Me.GrpAutorizacion.Controls.Add(Me.Label5)
        Me.GrpAutorizacion.Controls.Add(Me.PictureBox2)
        Me.GrpAutorizacion.Controls.Add(Me.Label3)
        Me.GrpAutorizacion.Controls.Add(Me.TxtConfirmar)
        Me.GrpAutorizacion.Controls.Add(Me.TxtFirma)
        Me.GrpAutorizacion.Controls.Add(Me.cmbUsuario)
        Me.GrpAutorizacion.Controls.Add(Me.LblNombre)
        Me.GrpAutorizacion.Controls.Add(Me.LblClave)
        Me.GrpAutorizacion.Controls.Add(Me.Label4)
        Me.GrpAutorizacion.Controls.Add(Me.PictureBox1)
        Me.GrpAutorizacion.Location = New System.Drawing.Point(7, 7)
        Me.GrpAutorizacion.Name = "GrpAutorizacion"
        Me.GrpAutorizacion.Size = New System.Drawing.Size(340, 144)
        Me.GrpAutorizacion.TabIndex = 1
        Me.GrpAutorizacion.TabStop = False
        Me.GrpAutorizacion.Text = "Autorización"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(167, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(166, 15)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = " 0 (Cero) para no requerir renovación"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(133, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "dias"
        '
        'TxtDias
        '
        Me.TxtDias.Location = New System.Drawing.Point(93, 112)
        Me.TxtDias.Name = "TxtDias"
        Me.TxtDias.Size = New System.Drawing.Size(37, 20)
        Me.TxtDias.TabIndex = 40
        Me.TxtDias.Text = "0"
        Me.TxtDias.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtDias.Value = 0
        Me.TxtDias.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(13, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 15)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Renovar cada"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(240, 56)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox2.TabIndex = 38
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Confirmar"
        '
        'TxtConfirmar
        '
        Me.TxtConfirmar.Location = New System.Drawing.Point(93, 85)
        Me.TxtConfirmar.Name = "TxtConfirmar"
        Me.TxtConfirmar.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtConfirmar.Size = New System.Drawing.Size(140, 20)
        Me.TxtConfirmar.TabIndex = 34
        '
        'TxtFirma
        '
        Me.TxtFirma.Location = New System.Drawing.Point(93, 56)
        Me.TxtFirma.Name = "TxtFirma"
        Me.TxtFirma.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtFirma.Size = New System.Drawing.Size(140, 20)
        Me.TxtFirma.TabIndex = 33
        '
        'cmbUsuario
        '
        Me.cmbUsuario.Location = New System.Drawing.Point(93, 26)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(227, 21)
        Me.cmbUsuario.TabIndex = 32
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(13, 26)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(80, 15)
        Me.LblNombre.TabIndex = 26
        Me.LblNombre.Text = "Autoriza"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(13, 56)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(34, 15)
        Me.LblClave.TabIndex = 24
        Me.LblClave.Text = "Firma"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(240, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Max. 60 Caracteres"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(320, 26)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox1.TabIndex = 36
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(161, 216)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 3
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Image = CType(resources.GetObject("BtnGuardar.Image"), System.Drawing.Image)
        Me.BtnGuardar.Location = New System.Drawing.Point(257, 216)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GrpRango
        '
        Me.GrpRango.Controls.Add(Me.PictureBox4)
        Me.GrpRango.Controls.Add(Me.PictureBox3)
        Me.GrpRango.Controls.Add(Me.Label2)
        Me.GrpRango.Controls.Add(Me.TxtFinal)
        Me.GrpRango.Controls.Add(Me.TxtInicial)
        Me.GrpRango.Controls.Add(Me.Label1)
        Me.GrpRango.Location = New System.Drawing.Point(7, 157)
        Me.GrpRango.Name = "GrpRango"
        Me.GrpRango.Size = New System.Drawing.Size(340, 52)
        Me.GrpRango.TabIndex = 30
        Me.GrpRango.TabStop = False
        Me.GrpRango.Text = "Rango de Autorización"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(320, 22)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(13, 15)
        Me.PictureBox4.TabIndex = 36
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(153, 22)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(14, 15)
        Me.PictureBox3.TabIndex = 35
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(187, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 15)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Final"
        '
        'TxtFinal
        '
        Me.TxtFinal.Location = New System.Drawing.Point(227, 22)
        Me.TxtFinal.Name = "TxtFinal"
        Me.TxtFinal.Size = New System.Drawing.Size(93, 20)
        Me.TxtFinal.TabIndex = 1
        Me.TxtFinal.Text = "0.00"
        Me.TxtFinal.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtFinal.Value = 0
        Me.TxtFinal.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'TxtInicial
        '
        Me.TxtInicial.Location = New System.Drawing.Point(53, 22)
        Me.TxtInicial.Name = "TxtInicial"
        Me.TxtInicial.Size = New System.Drawing.Size(94, 20)
        Me.TxtInicial.TabIndex = 0
        Me.TxtInicial.Text = "0.00"
        Me.TxtInicial.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.TxtInicial.Value = 0
        Me.TxtInicial.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 15)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Inicial"
        '
        'FrmAutoriza
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(356, 258)
        Me.Controls.Add(Me.GrpRango)
        Me.Controls.Add(Me.GrpAutorizacion)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAutoriza"
        Me.Text = "Agregar Autorización"
        Me.GrpAutorizacion.ResumeLayout(False)
        Me.GrpAutorizacion.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpRango.ResumeLayout(False)
        Me.GrpRango.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private AUTClave As String
    Private Nombre As String = ""
    Private USRClave As String = ""
    Private Firma As String
    Private Inicial As Double
    Private Final As Double
    Private Dias As Integer
    Private FechaIni As Date

    Private alerta(3) As PictureBox
    Private reloj As parpadea



    Private Function validaForm() As Boolean
        Dim i As Integer = 0


        If Me.cmbUsuario.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtFirma.Text <> Me.TxtConfirmar.Text OrElse Me.TxtFirma.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtFirma.Text.Length > 60 Then
            Me.TxtFirma.Text = Me.TxtFirma.Text.Substring(0, 60)
        End If


        If TxtInicial.Text = "" OrElse CDbl(TxtInicial.Text) < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtFinal.Text = "" OrElse CDbl(TxtFinal.Text) <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        ElseIf TxtInicial.Text <> "" Then
            If CDbl(TxtFinal.Text) < CDbl(TxtInicial.Text) Then
                i += 1
                reloj = New parpadea(Me.alerta(3))
                reloj.Enabled = True
                reloj.Start()
            End If
        End If
        If i > 0 Then
            Return False
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

    Private Sub FrmAutoriza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4

        With Me.cmbUsuario
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_usuario"
            .llenar()
        End With

        TxtFirma.Text = Firma
        TxtInicial.Text = CStr(Inicial)
        TxtFinal.Text = CStr(Final)
        cmbUsuario.SelectedValue = USRClave



    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        If validaForm() Then

            USRClave = cmbUsuario.SelectedValue
            Nombre = cmbUsuario.Text
            Firma = ModPOS.EncryptText(TxtFirma.Text.Trim, "AlpeGroup")
            Inicial = CDbl(TxtInicial.Text)
            Final = CDbl(TxtFinal.Text)
            Dias = Math.Abs(CInt(TxtDias.Text))
            FechaIni = Date.Today

            If ModPOS.Sucursal Is Nothing Then
                Beep()
                MessageBox.Show("El mantenimiento de sucursales ha sido cerrado. No se actualizara la información actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Close()
            Else
                If ModPOS.Sucursal.insertaAutorizacion(USRClave, Nombre, Firma, Inicial, Final, Dias, FechaIni) Then
                    TxtFirma.Text = ""
                    TxtConfirmar.Text = ""
                    TxtInicial.Text = ""
                    TxtFinal.Text = ""
                    TxtDias.Text = ""
                Else
                    Beep()
                    MessageBox.Show("El usuario que intenta agregar ya existe en la sucursal actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If
        Else
            Beep()
            MessageBox.Show("ˇAlguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub FrmAutoriza_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.Autoriza.Dispose()
        ModPOS.Autoriza = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

 
End Class
