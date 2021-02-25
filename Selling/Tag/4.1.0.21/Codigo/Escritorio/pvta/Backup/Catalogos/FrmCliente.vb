Public Class FrmCliente
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
    Friend WithEvents UiTab1 As Janus.Windows.UI.Tab.UITab
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnGuardar As Janus.Windows.EditControls.UIButton
    Friend WithEvents UiTabCliente As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabDomicilio As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents UiTabSaldos As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpDomicilio As System.Windows.Forms.GroupBox
    Friend WithEvents ChkDomicilio As Selling.ChkStatus
    Friend WithEvents cmbPais As Selling.StoreCombo
    Friend WithEvents BtnAceptarDomi As Janus.Windows.EditControls.UIButton
    Friend WithEvents GrpDomicilios As System.Windows.Forms.GroupBox
    Friend WithEvents GridDomicilios As Janus.Windows.GridEX.GridEX
    Friend WithEvents GrpSaldos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDelDomi As Janus.Windows.EditControls.UIButton
    Friend WithEvents NumDisponible As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents NumSaldo As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents LblColonia As System.Windows.Forms.Label
    Friend WithEvents LblMnpio As System.Windows.Forms.Label
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents LblPais As System.Windows.Forms.Label
    Friend WithEvents LblSaldo As System.Windows.Forms.Label
    Friend WithEvents LblCredito As System.Windows.Forms.Label
    Friend WithEvents TxtCalle As System.Windows.Forms.TextBox
    Friend WithEvents LblCalle As System.Windows.Forms.Label
    Friend WithEvents GridSaldos As Janus.Windows.GridEX.GridEX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GrpCliente As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDiasCredito As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbListaPrecio As Selling.StoreCombo
    Friend WithEvents lblLimite As System.Windows.Forms.Label
    Friend WithEvents TxtLimite As Janus.Windows.GridEX.EditControls.NumericEditBox
    Friend WithEvents lblRFC As System.Windows.Forms.Label
    Friend WithEvents TxtRFC As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnKey As Janus.Windows.EditControls.UIButton
    Friend WithEvents ChkEstado As Selling.ChkStatus
    Friend WithEvents TxtFechaRegistro As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaReg As System.Windows.Forms.Label
    Friend WithEvents TxtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LblTPersona As System.Windows.Forms.Label
    Friend WithEvents TxtNombreCorto As System.Windows.Forms.TextBox
    Friend WithEvents LblNombre As System.Windows.Forms.Label
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents CmbTipoPersona As Selling.StoreCombo
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtDomicilioFac As System.Windows.Forms.TextBox
    Friend WithEvents CmbPaisFac As Selling.StoreCombo
    Friend WithEvents GrpContacto As System.Windows.Forms.GroupBox
    Friend WithEvents LblEmail As System.Windows.Forms.Label
    Friend WithEvents LblTel2 As System.Windows.Forms.Label
    Friend WithEvents LblTel1 As System.Windows.Forms.Label
    Friend WithEvents TxtTel2 As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents TxtContacto As System.Windows.Forms.TextBox
    Friend WithEvents LblContacto As System.Windows.Forms.Label
    Friend WithEvents TxtMail As System.Windows.Forms.TextBox
    Friend WithEvents ChkDesglosarIVA As System.Windows.Forms.CheckBox
    Friend WithEvents cmbResponsable As Selling.StoreCombo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CmbTipo As Selling.StoreCombo
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtLocalidadFac As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoPostalFac As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtNoInteriorFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtNoExteriorFac As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtReferenciaFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtReferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TxtNoInterior As System.Windows.Forms.TextBox
    Friend WithEvents TxtNoExterior As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtCURP As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TxtEstadoFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtColoniaFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtMunicipioFac As System.Windows.Forms.TextBox
    Friend WithEvents TxtGLN As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents UiTabMetodo As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpMetodos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAgregar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridMetodos As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnElimina As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnModifica As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtColonia As System.Windows.Forms.TextBox
    Friend WithEvents TxtMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents TxtEstado As System.Windows.Forms.TextBox
    Friend WithEvents UiTabClasificaciones As Janus.Windows.UI.Tab.UITabPage
    Friend WithEvents GrpClasificaciones As System.Windows.Forms.GroupBox
    Friend WithEvents BtnBuscaClasificacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtClasificacion As System.Windows.Forms.TextBox
    Friend WithEvents LblReferencia As System.Windows.Forms.Label
    Friend WithEvents btnDelClasificacion As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridClasificaciones As Janus.Windows.GridEX.GridEX
    Friend WithEvents TxtCtaContable As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtAlterno As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoCanal As Selling.StoreCombo
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmbRamo As Selling.StoreCombo
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cmbZonaReparto As Selling.StoreCombo
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cmbZonaVenta As Selling.StoreCombo
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cmbZonaRep As Selling.StoreCombo
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cmbZonaVtap As Selling.StoreCombo
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtTelDomicilio As Janus.Windows.GridEX.EditControls.MaskedEditBox
    Friend WithEvents TxtConsignatario As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents TxtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox15 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox17 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox25 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox24 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox23 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox22 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox21 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox20 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox19 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox18 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbPostVenta As Selling.StoreCombo
    Friend WithEvents PictureBox27 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbDirecto As Selling.StoreCombo
    Friend WithEvents PictureBox26 As System.Windows.Forms.PictureBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents btnPostventa As Janus.Windows.EditControls.UIButton
    Friend WithEvents btnDirecto As Janus.Windows.EditControls.UIButton
    Friend WithEvents TxtTel1 As Janus.Windows.GridEX.EditControls.MaskedEditBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCliente))
        Me.UiTab1 = New Janus.Windows.UI.Tab.UITab
        Me.UiTabCliente = New Janus.Windows.UI.Tab.UITabPage
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnPostventa = New Janus.Windows.EditControls.UIButton
        Me.btnDirecto = New Janus.Windows.EditControls.UIButton
        Me.cmbPostVenta = New Selling.StoreCombo
        Me.PictureBox27 = New System.Windows.Forms.PictureBox
        Me.cmbDirecto = New Selling.StoreCombo
        Me.PictureBox26 = New System.Windows.Forms.PictureBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.PictureBox17 = New System.Windows.Forms.PictureBox
        Me.PictureBox16 = New System.Windows.Forms.PictureBox
        Me.PictureBox15 = New System.Windows.Forms.PictureBox
        Me.PictureBox14 = New System.Windows.Forms.PictureBox
        Me.PictureBox13 = New System.Windows.Forms.PictureBox
        Me.PictureBox12 = New System.Windows.Forms.PictureBox
        Me.PictureBox11 = New System.Windows.Forms.PictureBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.cmbZonaReparto = New Selling.StoreCombo
        Me.Label27 = New System.Windows.Forms.Label
        Me.cmbZonaVenta = New Selling.StoreCombo
        Me.TxtColoniaFac = New System.Windows.Forms.TextBox
        Me.TxtMunicipioFac = New System.Windows.Forms.TextBox
        Me.TxtEstadoFac = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtReferenciaFac = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtNoInteriorFac = New System.Windows.Forms.TextBox
        Me.TxtNoExteriorFac = New System.Windows.Forms.TextBox
        Me.TxtCodigoPostalFac = New System.Windows.Forms.TextBox
        Me.TxtLocalidadFac = New System.Windows.Forms.TextBox
        Me.TxtDomicilioFac = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.CmbPaisFac = New Selling.StoreCombo
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.GrpCliente = New System.Windows.Forms.GroupBox
        Me.PictureBox10 = New System.Windows.Forms.PictureBox
        Me.PictureBox9 = New System.Windows.Forms.PictureBox
        Me.PictureBox8 = New System.Windows.Forms.PictureBox
        Me.PictureBox7 = New System.Windows.Forms.PictureBox
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.cmbRamo = New Selling.StoreCombo
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtAlterno = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.cmbTipoCanal = New Selling.StoreCombo
        Me.TxtCtaContable = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.TxtGLN = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.TxtCURP = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.CmbTipo = New Selling.StoreCombo
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbResponsable = New Selling.StoreCombo
        Me.ChkDesglosarIVA = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtDiasCredito = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbListaPrecio = New Selling.StoreCombo
        Me.lblLimite = New System.Windows.Forms.Label
        Me.TxtLimite = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.lblRFC = New System.Windows.Forms.Label
        Me.TxtRFC = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.BtnKey = New Janus.Windows.EditControls.UIButton
        Me.ChkEstado = New Selling.ChkStatus(Me.components)
        Me.TxtFechaRegistro = New System.Windows.Forms.TextBox
        Me.lblFechaReg = New System.Windows.Forms.Label
        Me.TxtRazonSocial = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.LblTPersona = New System.Windows.Forms.Label
        Me.TxtNombreCorto = New System.Windows.Forms.TextBox
        Me.LblNombre = New System.Windows.Forms.Label
        Me.LblClave = New System.Windows.Forms.Label
        Me.TxtClave = New System.Windows.Forms.TextBox
        Me.CmbTipoPersona = New Selling.StoreCombo
        Me.Label9 = New System.Windows.Forms.Label
        Me.GrpContacto = New System.Windows.Forms.GroupBox
        Me.LblEmail = New System.Windows.Forms.Label
        Me.LblTel2 = New System.Windows.Forms.Label
        Me.LblTel1 = New System.Windows.Forms.Label
        Me.TxtTel2 = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.TxtContacto = New System.Windows.Forms.TextBox
        Me.LblContacto = New System.Windows.Forms.Label
        Me.TxtMail = New System.Windows.Forms.TextBox
        Me.TxtTel1 = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.UiTabDomicilio = New Janus.Windows.UI.Tab.UITabPage
        Me.GrpDomicilio = New System.Windows.Forms.GroupBox
        Me.PictureBox25 = New System.Windows.Forms.PictureBox
        Me.PictureBox24 = New System.Windows.Forms.PictureBox
        Me.PictureBox23 = New System.Windows.Forms.PictureBox
        Me.PictureBox22 = New System.Windows.Forms.PictureBox
        Me.PictureBox21 = New System.Windows.Forms.PictureBox
        Me.PictureBox20 = New System.Windows.Forms.PictureBox
        Me.PictureBox19 = New System.Windows.Forms.PictureBox
        Me.PictureBox18 = New System.Windows.Forms.PictureBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtTelDomicilio = New Janus.Windows.GridEX.EditControls.MaskedEditBox
        Me.TxtConsignatario = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.TxtNombre = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtColonia = New System.Windows.Forms.TextBox
        Me.TxtMunicipio = New System.Windows.Forms.TextBox
        Me.TxtEstado = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxtReferencia = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.TxtNoInterior = New System.Windows.Forms.TextBox
        Me.TxtNoExterior = New System.Windows.Forms.TextBox
        Me.TxtCodigoPostal = New System.Windows.Forms.TextBox
        Me.TxtLocalidad = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtCalle = New System.Windows.Forms.TextBox
        Me.LblCalle = New System.Windows.Forms.Label
        Me.BtnDelDomi = New Janus.Windows.EditControls.UIButton
        Me.LblColonia = New System.Windows.Forms.Label
        Me.LblMnpio = New System.Windows.Forms.Label
        Me.LblEstado = New System.Windows.Forms.Label
        Me.LblPais = New System.Windows.Forms.Label
        Me.BtnAceptarDomi = New Janus.Windows.EditControls.UIButton
        Me.Label17 = New System.Windows.Forms.Label
        Me.cmbZonaRep = New Selling.StoreCombo
        Me.cmbZonaVtap = New Selling.StoreCombo
        Me.ChkDomicilio = New Selling.ChkStatus(Me.components)
        Me.cmbPais = New Selling.StoreCombo
        Me.GrpDomicilios = New System.Windows.Forms.GroupBox
        Me.GridDomicilios = New Janus.Windows.GridEX.GridEX
        Me.UiTabSaldos = New Janus.Windows.UI.Tab.UITabPage
        Me.GrpSaldos = New System.Windows.Forms.GroupBox
        Me.LblSaldo = New System.Windows.Forms.Label
        Me.NumSaldo = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.LblCredito = New System.Windows.Forms.Label
        Me.NumDisponible = New Janus.Windows.GridEX.EditControls.NumericEditBox
        Me.GridSaldos = New Janus.Windows.GridEX.GridEX
        Me.UiTabMetodo = New Janus.Windows.UI.Tab.UITabPage
        Me.GrpMetodos = New System.Windows.Forms.GroupBox
        Me.BtnAgregar = New Janus.Windows.EditControls.UIButton
        Me.GridMetodos = New Janus.Windows.GridEX.GridEX
        Me.BtnElimina = New Janus.Windows.EditControls.UIButton
        Me.BtnModifica = New Janus.Windows.EditControls.UIButton
        Me.UiTabClasificaciones = New Janus.Windows.UI.Tab.UITabPage
        Me.GrpClasificaciones = New System.Windows.Forms.GroupBox
        Me.BtnBuscaClasificacion = New Janus.Windows.EditControls.UIButton
        Me.TxtClasificacion = New System.Windows.Forms.TextBox
        Me.LblReferencia = New System.Windows.Forms.Label
        Me.btnDelClasificacion = New Janus.Windows.EditControls.UIButton
        Me.GridClasificaciones = New Janus.Windows.GridEX.GridEX
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton
        Me.BtnGuardar = New Janus.Windows.EditControls.UIButton
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTab1.SuspendLayout()
        Me.UiTabCliente.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox26, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCliente.SuspendLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpContacto.SuspendLayout()
        Me.UiTabDomicilio.SuspendLayout()
        Me.GrpDomicilio.SuspendLayout()
        CType(Me.PictureBox25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDomicilios.SuspendLayout()
        CType(Me.GridDomicilios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabSaldos.SuspendLayout()
        Me.GrpSaldos.SuspendLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabMetodo.SuspendLayout()
        Me.GrpMetodos.SuspendLayout()
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiTabClasificaciones.SuspendLayout()
        Me.GrpClasificaciones.SuspendLayout()
        CType(Me.GridClasificaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiTab1
        '
        Me.UiTab1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UiTab1.FlatBorderColor = System.Drawing.Color.LightSteelBlue
        Me.UiTab1.Location = New System.Drawing.Point(1, 12)
        Me.UiTab1.Name = "UiTab1"
        Me.UiTab1.Size = New System.Drawing.Size(773, 504)
        Me.UiTab1.TabIndex = 0
        Me.UiTab1.TabPages.AddRange(New Janus.Windows.UI.Tab.UITabPage() {Me.UiTabCliente, Me.UiTabDomicilio, Me.UiTabSaldos, Me.UiTabMetodo, Me.UiTabClasificaciones})
        Me.UiTab1.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2007
        '
        'UiTabCliente
        '
        Me.UiTabCliente.Controls.Add(Me.Panel1)
        Me.UiTabCliente.Location = New System.Drawing.Point(1, 21)
        Me.UiTabCliente.Name = "UiTabCliente"
        Me.UiTabCliente.Size = New System.Drawing.Size(771, 482)
        Me.UiTabCliente.TabStop = True
        Me.UiTabCliente.Text = "General"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GrpCliente)
        Me.Panel1.Controls.Add(Me.GrpContacto)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(772, 484)
        Me.Panel1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnPostventa)
        Me.GroupBox1.Controls.Add(Me.btnDirecto)
        Me.GroupBox1.Controls.Add(Me.cmbPostVenta)
        Me.GroupBox1.Controls.Add(Me.PictureBox27)
        Me.GroupBox1.Controls.Add(Me.cmbDirecto)
        Me.GroupBox1.Controls.Add(Me.PictureBox26)
        Me.GroupBox1.Controls.Add(Me.Label34)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 706)
        Me.GroupBox1.MinimumSize = New System.Drawing.Size(725, 122)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(725, 122)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Descuentos"
        '
        'btnPostventa
        '
        Me.btnPostventa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPostventa.Location = New System.Drawing.Point(394, 59)
        Me.btnPostventa.Name = "btnPostventa"
        Me.btnPostventa.Size = New System.Drawing.Size(119, 21)
        Me.btnPostventa.TabIndex = 98
        Me.btnPostventa.Text = "&Excepci�n ..."
        Me.btnPostventa.ToolTipText = "Agregar Excepci�n de descuento postventa por sector de material"
        Me.btnPostventa.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'btnDirecto
        '
        Me.btnDirecto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDirecto.Location = New System.Drawing.Point(394, 25)
        Me.btnDirecto.Name = "btnDirecto"
        Me.btnDirecto.Size = New System.Drawing.Size(119, 21)
        Me.btnDirecto.TabIndex = 97
        Me.btnDirecto.Text = "&Excepci�n ..."
        Me.btnDirecto.ToolTipText = "Agregar Excepci�n de descuento directo por sector de material"
        Me.btnDirecto.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'cmbPostVenta
        '
        Me.cmbPostVenta.Location = New System.Drawing.Point(141, 59)
        Me.cmbPostVenta.Name = "cmbPostVenta"
        Me.cmbPostVenta.Size = New System.Drawing.Size(241, 21)
        Me.cmbPostVenta.TabIndex = 95
        '
        'PictureBox27
        '
        Me.PictureBox27.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox27.Image = CType(resources.GetObject("PictureBox27.Image"), System.Drawing.Image)
        Me.PictureBox27.Location = New System.Drawing.Point(100, 61)
        Me.PictureBox27.Name = "PictureBox27"
        Me.PictureBox27.Size = New System.Drawing.Size(22, 18)
        Me.PictureBox27.TabIndex = 94
        Me.PictureBox27.TabStop = False
        Me.PictureBox27.Visible = False
        '
        'cmbDirecto
        '
        Me.cmbDirecto.Location = New System.Drawing.Point(141, 25)
        Me.cmbDirecto.Name = "cmbDirecto"
        Me.cmbDirecto.Size = New System.Drawing.Size(241, 21)
        Me.cmbDirecto.TabIndex = 93
        '
        'PictureBox26
        '
        Me.PictureBox26.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox26.Image = CType(resources.GetObject("PictureBox26.Image"), System.Drawing.Image)
        Me.PictureBox26.Location = New System.Drawing.Point(100, 28)
        Me.PictureBox26.Name = "PictureBox26"
        Me.PictureBox26.Size = New System.Drawing.Size(22, 18)
        Me.PictureBox26.TabIndex = 92
        Me.PictureBox26.TabStop = False
        Me.PictureBox26.Visible = False
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(11, 62)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(120, 15)
        Me.Label34.TabIndex = 63
        Me.Label34.Text = "Descuento PostVenta"
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(13, 28)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(100, 14)
        Me.Label36.TabIndex = 61
        Me.Label36.Text = "Descuento Directo"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.PictureBox17)
        Me.GroupBox2.Controls.Add(Me.PictureBox16)
        Me.GroupBox2.Controls.Add(Me.PictureBox15)
        Me.GroupBox2.Controls.Add(Me.PictureBox14)
        Me.GroupBox2.Controls.Add(Me.PictureBox13)
        Me.GroupBox2.Controls.Add(Me.PictureBox12)
        Me.GroupBox2.Controls.Add(Me.PictureBox11)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.cmbZonaReparto)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.cmbZonaVenta)
        Me.GroupBox2.Controls.Add(Me.TxtColoniaFac)
        Me.GroupBox2.Controls.Add(Me.TxtMunicipioFac)
        Me.GroupBox2.Controls.Add(Me.TxtEstadoFac)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.TxtReferenciaFac)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.TxtNoInteriorFac)
        Me.GroupBox2.Controls.Add(Me.TxtNoExteriorFac)
        Me.GroupBox2.Controls.Add(Me.TxtCodigoPostalFac)
        Me.GroupBox2.Controls.Add(Me.TxtLocalidadFac)
        Me.GroupBox2.Controls.Add(Me.TxtDomicilioFac)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.CmbPaisFac)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 349)
        Me.GroupBox2.MinimumSize = New System.Drawing.Size(725, 209)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(725, 209)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Domicilio Fiscal"
        '
        'PictureBox17
        '
        Me.PictureBox17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox17.Image = CType(resources.GetObject("PictureBox17.Image"), System.Drawing.Image)
        Me.PictureBox17.Location = New System.Drawing.Point(499, 101)
        Me.PictureBox17.Name = "PictureBox17"
        Me.PictureBox17.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox17.TabIndex = 99
        Me.PictureBox17.TabStop = False
        Me.PictureBox17.Visible = False
        '
        'PictureBox16
        '
        Me.PictureBox16.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox16.Image = CType(resources.GetObject("PictureBox16.Image"), System.Drawing.Image)
        Me.PictureBox16.Location = New System.Drawing.Point(499, 72)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox16.TabIndex = 98
        Me.PictureBox16.TabStop = False
        Me.PictureBox16.Visible = False
        '
        'PictureBox15
        '
        Me.PictureBox15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox15.Image = CType(resources.GetObject("PictureBox15.Image"), System.Drawing.Image)
        Me.PictureBox15.Location = New System.Drawing.Point(81, 98)
        Me.PictureBox15.Name = "PictureBox15"
        Me.PictureBox15.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox15.TabIndex = 97
        Me.PictureBox15.TabStop = False
        Me.PictureBox15.Visible = False
        '
        'PictureBox14
        '
        Me.PictureBox14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox14.Image = CType(resources.GetObject("PictureBox14.Image"), System.Drawing.Image)
        Me.PictureBox14.Location = New System.Drawing.Point(80, 75)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox14.TabIndex = 96
        Me.PictureBox14.TabStop = False
        Me.PictureBox14.Visible = False
        '
        'PictureBox13
        '
        Me.PictureBox13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox13.Image = CType(resources.GetObject("PictureBox13.Image"), System.Drawing.Image)
        Me.PictureBox13.Location = New System.Drawing.Point(80, 48)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox13.TabIndex = 95
        Me.PictureBox13.TabStop = False
        Me.PictureBox13.Visible = False
        '
        'PictureBox12
        '
        Me.PictureBox12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), System.Drawing.Image)
        Me.PictureBox12.Location = New System.Drawing.Point(499, 19)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox12.TabIndex = 94
        Me.PictureBox12.TabStop = False
        Me.PictureBox12.Visible = False
        '
        'PictureBox11
        '
        Me.PictureBox11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
        Me.PictureBox11.Location = New System.Drawing.Point(80, 22)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(22, 18)
        Me.PictureBox11.TabIndex = 90
        Me.PictureBox11.TabStop = False
        Me.PictureBox11.Visible = False
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(13, 180)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(93, 15)
        Me.Label28.TabIndex = 89
        Me.Label28.Text = "Zona de Reparto"
        '
        'cmbZonaReparto
        '
        Me.cmbZonaReparto.BackColor = System.Drawing.SystemColors.Window
        Me.cmbZonaReparto.ItemHeight = 13
        Me.cmbZonaReparto.Location = New System.Drawing.Point(121, 177)
        Me.cmbZonaReparto.Name = "cmbZonaReparto"
        Me.cmbZonaReparto.Size = New System.Drawing.Size(263, 21)
        Me.cmbZonaReparto.TabIndex = 88
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(13, 153)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(93, 15)
        Me.Label27.TabIndex = 87
        Me.Label27.Text = "Zona de Venta"
        '
        'cmbZonaVenta
        '
        Me.cmbZonaVenta.BackColor = System.Drawing.SystemColors.Window
        Me.cmbZonaVenta.ItemHeight = 13
        Me.cmbZonaVenta.Location = New System.Drawing.Point(121, 150)
        Me.cmbZonaVenta.Name = "cmbZonaVenta"
        Me.cmbZonaVenta.Size = New System.Drawing.Size(263, 21)
        Me.cmbZonaVenta.TabIndex = 86
        '
        'TxtColoniaFac
        '
        Me.TxtColoniaFac.Location = New System.Drawing.Point(121, 72)
        Me.TxtColoniaFac.Name = "TxtColoniaFac"
        Me.TxtColoniaFac.Size = New System.Drawing.Size(263, 20)
        Me.TxtColoniaFac.TabIndex = 5
        '
        'TxtMunicipioFac
        '
        Me.TxtMunicipioFac.Location = New System.Drawing.Point(121, 46)
        Me.TxtMunicipioFac.Name = "TxtMunicipioFac"
        Me.TxtMunicipioFac.Size = New System.Drawing.Size(167, 20)
        Me.TxtMunicipioFac.TabIndex = 3
        '
        'TxtEstadoFac
        '
        Me.TxtEstadoFac.Location = New System.Drawing.Point(532, 17)
        Me.TxtEstadoFac.Name = "TxtEstadoFac"
        Me.TxtEstadoFac.Size = New System.Drawing.Size(178, 20)
        Me.TxtEstadoFac.TabIndex = 2
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(13, 127)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 15)
        Me.Label15.TabIndex = 84
        Me.Label15.Text = "Referencia"
        '
        'TxtReferenciaFac
        '
        Me.TxtReferenciaFac.Location = New System.Drawing.Point(121, 124)
        Me.TxtReferenciaFac.Name = "TxtReferenciaFac"
        Me.TxtReferenciaFac.Size = New System.Drawing.Size(412, 20)
        Me.TxtReferenciaFac.TabIndex = 10
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(601, 100)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 16)
        Me.Label14.TabIndex = 82
        Me.Label14.Text = "No. Int."
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(401, 99)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 16)
        Me.Label13.TabIndex = 81
        Me.Label13.Text = "No. Ext."
        '
        'TxtNoInteriorFac
        '
        Me.TxtNoInteriorFac.Location = New System.Drawing.Point(662, 96)
        Me.TxtNoInteriorFac.Name = "TxtNoInteriorFac"
        Me.TxtNoInteriorFac.Size = New System.Drawing.Size(48, 20)
        Me.TxtNoInteriorFac.TabIndex = 9
        '
        'TxtNoExteriorFac
        '
        Me.TxtNoExteriorFac.Location = New System.Drawing.Point(532, 97)
        Me.TxtNoExteriorFac.Name = "TxtNoExteriorFac"
        Me.TxtNoExteriorFac.Size = New System.Drawing.Size(64, 20)
        Me.TxtNoExteriorFac.TabIndex = 8
        '
        'TxtCodigoPostalFac
        '
        Me.TxtCodigoPostalFac.Location = New System.Drawing.Point(532, 72)
        Me.TxtCodigoPostalFac.Name = "TxtCodigoPostalFac"
        Me.TxtCodigoPostalFac.Size = New System.Drawing.Size(178, 20)
        Me.TxtCodigoPostalFac.TabIndex = 6
        '
        'TxtLocalidadFac
        '
        Me.TxtLocalidadFac.Location = New System.Drawing.Point(532, 42)
        Me.TxtLocalidadFac.Name = "TxtLocalidadFac"
        Me.TxtLocalidadFac.Size = New System.Drawing.Size(178, 20)
        Me.TxtLocalidadFac.TabIndex = 4
        '
        'TxtDomicilioFac
        '
        Me.TxtDomicilioFac.Location = New System.Drawing.Point(121, 98)
        Me.TxtDomicilioFac.Name = "TxtDomicilioFac"
        Me.TxtDomicilioFac.Size = New System.Drawing.Size(263, 20)
        Me.TxtDomicilioFac.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 15)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Calle"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(13, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 18)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "Colonia"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(13, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 15)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Municipio"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(401, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 15)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Entidad/Estado"
        '
        'CmbPaisFac
        '
        Me.CmbPaisFac.Location = New System.Drawing.Point(121, 19)
        Me.CmbPaisFac.Name = "CmbPaisFac"
        Me.CmbPaisFac.Size = New System.Drawing.Size(167, 21)
        Me.CmbPaisFac.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(13, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 15)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Pa�s"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(400, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 14)
        Me.Label10.TabIndex = 75
        Me.Label10.Text = "Ciudad/Poblaci�n"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(401, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 15)
        Me.Label12.TabIndex = 77
        Me.Label12.Text = "C�digo Postal"
        '
        'GrpCliente
        '
        Me.GrpCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCliente.BackColor = System.Drawing.Color.Transparent
        Me.GrpCliente.Controls.Add(Me.PictureBox10)
        Me.GrpCliente.Controls.Add(Me.PictureBox9)
        Me.GrpCliente.Controls.Add(Me.PictureBox8)
        Me.GrpCliente.Controls.Add(Me.PictureBox7)
        Me.GrpCliente.Controls.Add(Me.PictureBox6)
        Me.GrpCliente.Controls.Add(Me.PictureBox5)
        Me.GrpCliente.Controls.Add(Me.PictureBox4)
        Me.GrpCliente.Controls.Add(Me.PictureBox3)
        Me.GrpCliente.Controls.Add(Me.PictureBox2)
        Me.GrpCliente.Controls.Add(Me.Label26)
        Me.GrpCliente.Controls.Add(Me.cmbRamo)
        Me.GrpCliente.Controls.Add(Me.Label25)
        Me.GrpCliente.Controls.Add(Me.txtAlterno)
        Me.GrpCliente.Controls.Add(Me.Label24)
        Me.GrpCliente.Controls.Add(Me.cmbTipoCanal)
        Me.GrpCliente.Controls.Add(Me.TxtCtaContable)
        Me.GrpCliente.Controls.Add(Me.Label23)
        Me.GrpCliente.Controls.Add(Me.TxtGLN)
        Me.GrpCliente.Controls.Add(Me.Label22)
        Me.GrpCliente.Controls.Add(Me.TxtCURP)
        Me.GrpCliente.Controls.Add(Me.Label21)
        Me.GrpCliente.Controls.Add(Me.CmbTipo)
        Me.GrpCliente.Controls.Add(Me.Label4)
        Me.GrpCliente.Controls.Add(Me.cmbResponsable)
        Me.GrpCliente.Controls.Add(Me.ChkDesglosarIVA)
        Me.GrpCliente.Controls.Add(Me.Label2)
        Me.GrpCliente.Controls.Add(Me.TxtDiasCredito)
        Me.GrpCliente.Controls.Add(Me.Label1)
        Me.GrpCliente.Controls.Add(Me.cmbListaPrecio)
        Me.GrpCliente.Controls.Add(Me.lblLimite)
        Me.GrpCliente.Controls.Add(Me.TxtLimite)
        Me.GrpCliente.Controls.Add(Me.lblRFC)
        Me.GrpCliente.Controls.Add(Me.TxtRFC)
        Me.GrpCliente.Controls.Add(Me.PictureBox1)
        Me.GrpCliente.Controls.Add(Me.BtnKey)
        Me.GrpCliente.Controls.Add(Me.ChkEstado)
        Me.GrpCliente.Controls.Add(Me.TxtFechaRegistro)
        Me.GrpCliente.Controls.Add(Me.lblFechaReg)
        Me.GrpCliente.Controls.Add(Me.TxtRazonSocial)
        Me.GrpCliente.Controls.Add(Me.Label11)
        Me.GrpCliente.Controls.Add(Me.LblTPersona)
        Me.GrpCliente.Controls.Add(Me.TxtNombreCorto)
        Me.GrpCliente.Controls.Add(Me.LblNombre)
        Me.GrpCliente.Controls.Add(Me.LblClave)
        Me.GrpCliente.Controls.Add(Me.TxtClave)
        Me.GrpCliente.Controls.Add(Me.CmbTipoPersona)
        Me.GrpCliente.Controls.Add(Me.Label9)
        Me.GrpCliente.Location = New System.Drawing.Point(10, 5)
        Me.GrpCliente.MinimumSize = New System.Drawing.Size(725, 332)
        Me.GrpCliente.Name = "GrpCliente"
        Me.GrpCliente.Size = New System.Drawing.Size(725, 332)
        Me.GrpCliente.TabIndex = 1
        Me.GrpCliente.TabStop = False
        Me.GrpCliente.Text = "Cliente"
        '
        'PictureBox10
        '
        Me.PictureBox10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
        Me.PictureBox10.Location = New System.Drawing.Point(530, 299)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox10.TabIndex = 93
        Me.PictureBox10.TabStop = False
        Me.PictureBox10.Visible = False
        '
        'PictureBox9
        '
        Me.PictureBox9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
        Me.PictureBox9.Location = New System.Drawing.Point(530, 269)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(18, 17)
        Me.PictureBox9.TabIndex = 64
        Me.PictureBox9.TabStop = False
        Me.PictureBox9.Visible = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
        Me.PictureBox8.Location = New System.Drawing.Point(530, 236)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox8.TabIndex = 92
        Me.PictureBox8.TabStop = False
        Me.PictureBox8.Visible = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(93, 17)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox7.TabIndex = 91
        Me.PictureBox7.TabStop = False
        Me.PictureBox7.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(93, 271)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox6.TabIndex = 90
        Me.PictureBox6.TabStop = False
        Me.PictureBox6.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(93, 239)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox5.TabIndex = 89
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(93, 177)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox4.TabIndex = 88
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(93, 109)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox3.TabIndex = 87
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(93, 76)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox2.TabIndex = 86
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(396, 176)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(93, 15)
        Me.Label26.TabIndex = 85
        Me.Label26.Text = "Ramo o Giro"
        '
        'cmbRamo
        '
        Me.cmbRamo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbRamo.ItemHeight = 13
        Me.cmbRamo.Location = New System.Drawing.Point(507, 173)
        Me.cmbRamo.Name = "cmbRamo"
        Me.cmbRamo.Size = New System.Drawing.Size(203, 21)
        Me.cmbRamo.TabIndex = 84
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(398, 80)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(68, 14)
        Me.Label25.TabIndex = 83
        Me.Label25.Text = "Alterno"
        '
        'txtAlterno
        '
        Me.txtAlterno.Location = New System.Drawing.Point(557, 77)
        Me.txtAlterno.Name = "txtAlterno"
        Me.txtAlterno.Size = New System.Drawing.Size(153, 20)
        Me.txtAlterno.TabIndex = 82
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(13, 239)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(93, 15)
        Me.Label24.TabIndex = 80
        Me.Label24.Text = "Canal de Venta"
        '
        'cmbTipoCanal
        '
        Me.cmbTipoCanal.BackColor = System.Drawing.SystemColors.Window
        Me.cmbTipoCanal.ItemHeight = 13
        Me.cmbTipoCanal.Location = New System.Drawing.Point(121, 233)
        Me.cmbTipoCanal.Name = "cmbTipoCanal"
        Me.cmbTipoCanal.Size = New System.Drawing.Size(242, 21)
        Me.cmbTipoCanal.TabIndex = 79
        '
        'TxtCtaContable
        '
        Me.TxtCtaContable.Location = New System.Drawing.Point(121, 297)
        Me.TxtCtaContable.Name = "TxtCtaContable"
        Me.TxtCtaContable.Size = New System.Drawing.Size(242, 20)
        Me.TxtCtaContable.TabIndex = 77
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(13, 300)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(93, 14)
        Me.Label23.TabIndex = 78
        Me.Label23.Text = "Cta. Contable"
        '
        'TxtGLN
        '
        Me.TxtGLN.Location = New System.Drawing.Point(507, 139)
        Me.TxtGLN.Name = "TxtGLN"
        Me.TxtGLN.Size = New System.Drawing.Size(203, 20)
        Me.TxtGLN.TabIndex = 75
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(398, 142)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(40, 14)
        Me.Label22.TabIndex = 76
        Me.Label22.Text = "GLN"
        '
        'TxtCURP
        '
        Me.TxtCURP.Location = New System.Drawing.Point(121, 201)
        Me.TxtCURP.Name = "TxtCURP"
        Me.TxtCURP.Size = New System.Drawing.Size(242, 20)
        Me.TxtCURP.TabIndex = 7
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(13, 204)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(63, 14)
        Me.Label21.TabIndex = 74
        Me.Label21.Text = "CURP"
        '
        'CmbTipo
        '
        Me.CmbTipo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipo.Location = New System.Drawing.Point(557, 233)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(153, 21)
        Me.CmbTipo.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(13, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 15)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "Responsable"
        '
        'cmbResponsable
        '
        Me.cmbResponsable.BackColor = System.Drawing.SystemColors.Window
        Me.cmbResponsable.ItemHeight = 13
        Me.cmbResponsable.Location = New System.Drawing.Point(121, 15)
        Me.cmbResponsable.Name = "cmbResponsable"
        Me.cmbResponsable.Size = New System.Drawing.Size(242, 21)
        Me.cmbResponsable.TabIndex = 11
        '
        'ChkDesglosarIVA
        '
        Me.ChkDesglosarIVA.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkDesglosarIVA.Location = New System.Drawing.Point(577, 203)
        Me.ChkDesglosarIVA.Name = "ChkDesglosarIVA"
        Me.ChkDesglosarIVA.Size = New System.Drawing.Size(133, 22)
        Me.ChkDesglosarIVA.TabIndex = 2
        Me.ChkDesglosarIVA.Text = "No Desglosar IEPS"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(398, 300)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 15)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "Dias de Cr�dito"
        '
        'TxtDiasCredito
        '
        Me.TxtDiasCredito.Location = New System.Drawing.Point(590, 297)
        Me.TxtDiasCredito.Name = "TxtDiasCredito"
        Me.TxtDiasCredito.Size = New System.Drawing.Size(120, 20)
        Me.TxtDiasCredito.TabIndex = 9
        Me.TxtDiasCredito.Text = "0"
        Me.TxtDiasCredito.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtDiasCredito.Value = 0
        Me.TxtDiasCredito.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 268)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 15)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "Lista de Precio"
        '
        'cmbListaPrecio
        '
        Me.cmbListaPrecio.BackColor = System.Drawing.SystemColors.Window
        Me.cmbListaPrecio.ItemHeight = 13
        Me.cmbListaPrecio.Location = New System.Drawing.Point(121, 265)
        Me.cmbListaPrecio.Name = "cmbListaPrecio"
        Me.cmbListaPrecio.Size = New System.Drawing.Size(242, 21)
        Me.cmbListaPrecio.TabIndex = 10
        '
        'lblLimite
        '
        Me.lblLimite.Location = New System.Drawing.Point(398, 268)
        Me.lblLimite.Name = "lblLimite"
        Me.lblLimite.Size = New System.Drawing.Size(90, 15)
        Me.lblLimite.TabIndex = 57
        Me.lblLimite.Text = "L�mite de Cr�dito"
        '
        'TxtLimite
        '
        Me.TxtLimite.FormatMask = Janus.Windows.GridEX.NumericEditFormatMask.Currency
        Me.TxtLimite.Location = New System.Drawing.Point(590, 265)
        Me.TxtLimite.Name = "TxtLimite"
        Me.TxtLimite.Size = New System.Drawing.Size(120, 20)
        Me.TxtLimite.TabIndex = 8
        Me.TxtLimite.Text = "$0.00"
        Me.TxtLimite.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
        Me.TxtLimite.Value = 0
        Me.TxtLimite.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'lblRFC
        '
        Me.lblRFC.Location = New System.Drawing.Point(13, 176)
        Me.lblRFC.Name = "lblRFC"
        Me.lblRFC.Size = New System.Drawing.Size(33, 15)
        Me.lblRFC.TabIndex = 55
        Me.lblRFC.Text = "RFC"
        '
        'TxtRFC
        '
        Me.TxtRFC.Location = New System.Drawing.Point(121, 173)
        Me.TxtRFC.Name = "TxtRFC"
        Me.TxtRFC.Size = New System.Drawing.Size(127, 20)
        Me.TxtRFC.TabIndex = 6
        Me.TxtRFC.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(93, 45)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(18, 19)
        Me.PictureBox1.TabIndex = 40
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BtnKey
        '
        Me.BtnKey.Image = CType(resources.GetObject("BtnKey.Image"), System.Drawing.Image)
        Me.BtnKey.Location = New System.Drawing.Point(280, 73)
        Me.BtnKey.Name = "BtnKey"
        Me.BtnKey.Size = New System.Drawing.Size(26, 21)
        Me.BtnKey.TabIndex = 1
        Me.BtnKey.ToolTipText = "Generar clave automatica"
        Me.BtnKey.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'ChkEstado
        '
        Me.ChkEstado.Checked = True
        Me.ChkEstado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEstado.Enabled = False
        Me.ChkEstado.Location = New System.Drawing.Point(653, 44)
        Me.ChkEstado.Name = "ChkEstado"
        Me.ChkEstado.Size = New System.Drawing.Size(57, 22)
        Me.ChkEstado.TabIndex = 1
        Me.ChkEstado.Text = "Activo"
        '
        'TxtFechaRegistro
        '
        Me.TxtFechaRegistro.Location = New System.Drawing.Point(588, 14)
        Me.TxtFechaRegistro.Name = "TxtFechaRegistro"
        Me.TxtFechaRegistro.ReadOnly = True
        Me.TxtFechaRegistro.Size = New System.Drawing.Size(122, 20)
        Me.TxtFechaRegistro.TabIndex = 51
        Me.TxtFechaRegistro.TabStop = False
        '
        'lblFechaReg
        '
        Me.lblFechaReg.Location = New System.Drawing.Point(401, 18)
        Me.lblFechaReg.Name = "lblFechaReg"
        Me.lblFechaReg.Size = New System.Drawing.Size(88, 15)
        Me.lblFechaReg.TabIndex = 47
        Me.lblFechaReg.Text = "Fecha Registro"
        '
        'TxtRazonSocial
        '
        Me.TxtRazonSocial.Location = New System.Drawing.Point(121, 108)
        Me.TxtRazonSocial.Name = "TxtRazonSocial"
        Me.TxtRazonSocial.Size = New System.Drawing.Size(589, 20)
        Me.TxtRazonSocial.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(13, 111)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 15)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Raz�n Social"
        '
        'LblTPersona
        '
        Me.LblTPersona.Location = New System.Drawing.Point(13, 49)
        Me.LblTPersona.Name = "LblTPersona"
        Me.LblTPersona.Size = New System.Drawing.Size(93, 15)
        Me.LblTPersona.TabIndex = 23
        Me.LblTPersona.Text = "Tipo de Persona"
        '
        'TxtNombreCorto
        '
        Me.TxtNombreCorto.Location = New System.Drawing.Point(121, 139)
        Me.TxtNombreCorto.Name = "TxtNombreCorto"
        Me.TxtNombreCorto.Size = New System.Drawing.Size(242, 20)
        Me.TxtNombreCorto.TabIndex = 3
        '
        'LblNombre
        '
        Me.LblNombre.Location = New System.Drawing.Point(13, 142)
        Me.LblNombre.Name = "LblNombre"
        Me.LblNombre.Size = New System.Drawing.Size(102, 15)
        Me.LblNombre.TabIndex = 3
        Me.LblNombre.Text = "Nombre Corto"
        '
        'LblClave
        '
        Me.LblClave.Location = New System.Drawing.Point(13, 80)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(68, 14)
        Me.LblClave.TabIndex = 1
        Me.LblClave.Text = "Clave"
        '
        'TxtClave
        '
        Me.TxtClave.Location = New System.Drawing.Point(121, 74)
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.Size = New System.Drawing.Size(153, 20)
        Me.TxtClave.TabIndex = 0
        '
        'CmbTipoPersona
        '
        Me.CmbTipoPersona.BackColor = System.Drawing.SystemColors.Window
        Me.CmbTipoPersona.Location = New System.Drawing.Point(121, 45)
        Me.CmbTipoPersona.Name = "CmbTipoPersona"
        Me.CmbTipoPersona.Size = New System.Drawing.Size(121, 21)
        Me.CmbTipoPersona.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(398, 236)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 12)
        Me.Label9.TabIndex = 72
        Me.Label9.Text = "Tipo Impuesto"
        '
        'GrpContacto
        '
        Me.GrpContacto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpContacto.BackColor = System.Drawing.Color.Transparent
        Me.GrpContacto.Controls.Add(Me.LblEmail)
        Me.GrpContacto.Controls.Add(Me.LblTel2)
        Me.GrpContacto.Controls.Add(Me.LblTel1)
        Me.GrpContacto.Controls.Add(Me.TxtTel2)
        Me.GrpContacto.Controls.Add(Me.TxtContacto)
        Me.GrpContacto.Controls.Add(Me.LblContacto)
        Me.GrpContacto.Controls.Add(Me.TxtMail)
        Me.GrpContacto.Controls.Add(Me.TxtTel1)
        Me.GrpContacto.Location = New System.Drawing.Point(10, 568)
        Me.GrpContacto.MinimumSize = New System.Drawing.Size(725, 122)
        Me.GrpContacto.Name = "GrpContacto"
        Me.GrpContacto.Size = New System.Drawing.Size(725, 122)
        Me.GrpContacto.TabIndex = 3
        Me.GrpContacto.TabStop = False
        Me.GrpContacto.Text = "Contacto"
        '
        'LblEmail
        '
        Me.LblEmail.Location = New System.Drawing.Point(13, 90)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(60, 15)
        Me.LblEmail.TabIndex = 63
        Me.LblEmail.Text = "Correo(s)"
        '
        'LblTel2
        '
        Me.LblTel2.Location = New System.Drawing.Point(370, 53)
        Me.LblTel2.Name = "LblTel2"
        Me.LblTel2.Size = New System.Drawing.Size(57, 15)
        Me.LblTel2.TabIndex = 62
        Me.LblTel2.Text = "Tel/Fax"
        '
        'LblTel1
        '
        Me.LblTel1.Location = New System.Drawing.Point(13, 53)
        Me.LblTel1.Name = "LblTel1"
        Me.LblTel1.Size = New System.Drawing.Size(53, 14)
        Me.LblTel1.TabIndex = 61
        Me.LblTel1.Text = "Tel/Fax"
        '
        'TxtTel2
        '
        Me.TxtTel2.Location = New System.Drawing.Point(442, 50)
        Me.TxtTel2.Mask = "!(##) 000 00 0 00 00"
        Me.TxtTel2.Name = "TxtTel2"
        Me.TxtTel2.Size = New System.Drawing.Size(200, 20)
        Me.TxtTel2.TabIndex = 3
        Me.TxtTel2.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'TxtContacto
        '
        Me.TxtContacto.Location = New System.Drawing.Point(121, 20)
        Me.TxtContacto.Name = "TxtContacto"
        Me.TxtContacto.Size = New System.Drawing.Size(427, 20)
        Me.TxtContacto.TabIndex = 1
        '
        'LblContacto
        '
        Me.LblContacto.Location = New System.Drawing.Point(13, 23)
        Me.LblContacto.Name = "LblContacto"
        Me.LblContacto.Size = New System.Drawing.Size(60, 15)
        Me.LblContacto.TabIndex = 34
        Me.LblContacto.Text = "Contacto"
        '
        'TxtMail
        '
        Me.TxtMail.Location = New System.Drawing.Point(121, 87)
        Me.TxtMail.Name = "TxtMail"
        Me.TxtMail.Size = New System.Drawing.Size(521, 20)
        Me.TxtMail.TabIndex = 4
        '
        'TxtTel1
        '
        Me.TxtTel1.Location = New System.Drawing.Point(121, 50)
        Me.TxtTel1.Mask = "!(##) 000 00 0 00 00"
        Me.TxtTel1.Name = "TxtTel1"
        Me.TxtTel1.Size = New System.Drawing.Size(189, 20)
        Me.TxtTel1.TabIndex = 2
        Me.TxtTel1.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'UiTabDomicilio
        '
        Me.UiTabDomicilio.Controls.Add(Me.GrpDomicilio)
        Me.UiTabDomicilio.Controls.Add(Me.GrpDomicilios)
        Me.UiTabDomicilio.Location = New System.Drawing.Point(1, 21)
        Me.UiTabDomicilio.Name = "UiTabDomicilio"
        Me.UiTabDomicilio.Size = New System.Drawing.Size(771, 482)
        Me.UiTabDomicilio.TabStop = True
        Me.UiTabDomicilio.Text = "Puntos de Entrega"
        Me.UiTabDomicilio.Visible = False
        '
        'GrpDomicilio
        '
        Me.GrpDomicilio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDomicilio.BackColor = System.Drawing.Color.Transparent
        Me.GrpDomicilio.Controls.Add(Me.PictureBox25)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox24)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox23)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox22)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox21)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox20)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox19)
        Me.GrpDomicilio.Controls.Add(Me.PictureBox18)
        Me.GrpDomicilio.Controls.Add(Me.Label33)
        Me.GrpDomicilio.Controls.Add(Me.txtTelDomicilio)
        Me.GrpDomicilio.Controls.Add(Me.TxtConsignatario)
        Me.GrpDomicilio.Controls.Add(Me.Label32)
        Me.GrpDomicilio.Controls.Add(Me.TxtNombre)
        Me.GrpDomicilio.Controls.Add(Me.Label31)
        Me.GrpDomicilio.Controls.Add(Me.Label29)
        Me.GrpDomicilio.Controls.Add(Me.Label30)
        Me.GrpDomicilio.Controls.Add(Me.TxtColonia)
        Me.GrpDomicilio.Controls.Add(Me.TxtMunicipio)
        Me.GrpDomicilio.Controls.Add(Me.TxtEstado)
        Me.GrpDomicilio.Controls.Add(Me.Label18)
        Me.GrpDomicilio.Controls.Add(Me.TxtReferencia)
        Me.GrpDomicilio.Controls.Add(Me.Label19)
        Me.GrpDomicilio.Controls.Add(Me.Label20)
        Me.GrpDomicilio.Controls.Add(Me.TxtNoInterior)
        Me.GrpDomicilio.Controls.Add(Me.TxtNoExterior)
        Me.GrpDomicilio.Controls.Add(Me.TxtCodigoPostal)
        Me.GrpDomicilio.Controls.Add(Me.TxtLocalidad)
        Me.GrpDomicilio.Controls.Add(Me.Label16)
        Me.GrpDomicilio.Controls.Add(Me.TxtCalle)
        Me.GrpDomicilio.Controls.Add(Me.LblCalle)
        Me.GrpDomicilio.Controls.Add(Me.BtnDelDomi)
        Me.GrpDomicilio.Controls.Add(Me.LblColonia)
        Me.GrpDomicilio.Controls.Add(Me.LblMnpio)
        Me.GrpDomicilio.Controls.Add(Me.LblEstado)
        Me.GrpDomicilio.Controls.Add(Me.LblPais)
        Me.GrpDomicilio.Controls.Add(Me.BtnAceptarDomi)
        Me.GrpDomicilio.Controls.Add(Me.Label17)
        Me.GrpDomicilio.Controls.Add(Me.cmbZonaRep)
        Me.GrpDomicilio.Controls.Add(Me.cmbZonaVtap)
        Me.GrpDomicilio.Controls.Add(Me.ChkDomicilio)
        Me.GrpDomicilio.Controls.Add(Me.cmbPais)
        Me.GrpDomicilio.Location = New System.Drawing.Point(7, 3)
        Me.GrpDomicilio.Name = "GrpDomicilio"
        Me.GrpDomicilio.Size = New System.Drawing.Size(754, 298)
        Me.GrpDomicilio.TabIndex = 0
        Me.GrpDomicilio.TabStop = False
        Me.GrpDomicilio.Text = "Domicilio de Punto de Entrega"
        '
        'PictureBox25
        '
        Me.PictureBox25.Image = CType(resources.GetObject("PictureBox25.Image"), System.Drawing.Image)
        Me.PictureBox25.Location = New System.Drawing.Point(415, 190)
        Me.PictureBox25.Name = "PictureBox25"
        Me.PictureBox25.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox25.TabIndex = 110
        Me.PictureBox25.TabStop = False
        Me.PictureBox25.Visible = False
        '
        'PictureBox24
        '
        Me.PictureBox24.Image = CType(resources.GetObject("PictureBox24.Image"), System.Drawing.Image)
        Me.PictureBox24.Location = New System.Drawing.Point(84, 188)
        Me.PictureBox24.Name = "PictureBox24"
        Me.PictureBox24.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox24.TabIndex = 109
        Me.PictureBox24.TabStop = False
        Me.PictureBox24.Visible = False
        '
        'PictureBox23
        '
        Me.PictureBox23.Image = CType(resources.GetObject("PictureBox23.Image"), System.Drawing.Image)
        Me.PictureBox23.Location = New System.Drawing.Point(450, 161)
        Me.PictureBox23.Name = "PictureBox23"
        Me.PictureBox23.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox23.TabIndex = 108
        Me.PictureBox23.TabStop = False
        Me.PictureBox23.Visible = False
        '
        'PictureBox22
        '
        Me.PictureBox22.Image = CType(resources.GetObject("PictureBox22.Image"), System.Drawing.Image)
        Me.PictureBox22.Location = New System.Drawing.Point(84, 163)
        Me.PictureBox22.Name = "PictureBox22"
        Me.PictureBox22.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox22.TabIndex = 107
        Me.PictureBox22.TabStop = False
        Me.PictureBox22.Visible = False
        '
        'PictureBox21
        '
        Me.PictureBox21.Image = CType(resources.GetObject("PictureBox21.Image"), System.Drawing.Image)
        Me.PictureBox21.Location = New System.Drawing.Point(82, 134)
        Me.PictureBox21.Name = "PictureBox21"
        Me.PictureBox21.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox21.TabIndex = 106
        Me.PictureBox21.TabStop = False
        Me.PictureBox21.Visible = False
        '
        'PictureBox20
        '
        Me.PictureBox20.Image = CType(resources.GetObject("PictureBox20.Image"), System.Drawing.Image)
        Me.PictureBox20.Location = New System.Drawing.Point(403, 106)
        Me.PictureBox20.Name = "PictureBox20"
        Me.PictureBox20.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox20.TabIndex = 105
        Me.PictureBox20.TabStop = False
        Me.PictureBox20.Visible = False
        '
        'PictureBox19
        '
        Me.PictureBox19.Image = CType(resources.GetObject("PictureBox19.Image"), System.Drawing.Image)
        Me.PictureBox19.Location = New System.Drawing.Point(82, 107)
        Me.PictureBox19.Name = "PictureBox19"
        Me.PictureBox19.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox19.TabIndex = 104
        Me.PictureBox19.TabStop = False
        Me.PictureBox19.Visible = False
        '
        'PictureBox18
        '
        Me.PictureBox18.Image = CType(resources.GetObject("PictureBox18.Image"), System.Drawing.Image)
        Me.PictureBox18.Location = New System.Drawing.Point(82, 54)
        Me.PictureBox18.Name = "PictureBox18"
        Me.PictureBox18.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox18.TabIndex = 100
        Me.PictureBox18.TabStop = False
        Me.PictureBox18.Visible = False
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(7, 83)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(53, 14)
        Me.Label33.TabIndex = 103
        Me.Label33.Text = "Tel/Fax"
        '
        'txtTelDomicilio
        '
        Me.txtTelDomicilio.Location = New System.Drawing.Point(110, 79)
        Me.txtTelDomicilio.Mask = "!(##) 000 00 0 00 00"
        Me.txtTelDomicilio.Name = "txtTelDomicilio"
        Me.txtTelDomicilio.Size = New System.Drawing.Size(189, 20)
        Me.txtTelDomicilio.TabIndex = 102
        Me.txtTelDomicilio.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        '
        'TxtConsignatario
        '
        Me.TxtConsignatario.Location = New System.Drawing.Point(110, 52)
        Me.TxtConsignatario.Name = "TxtConsignatario"
        Me.TxtConsignatario.Size = New System.Drawing.Size(491, 20)
        Me.TxtConsignatario.TabIndex = 100
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(7, 55)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(93, 15)
        Me.Label32.TabIndex = 101
        Me.Label32.Text = "Consignatario"
        '
        'TxtNombre
        '
        Me.TxtNombre.Location = New System.Drawing.Point(110, 25)
        Me.TxtNombre.Name = "TxtNombre"
        Me.TxtNombre.Size = New System.Drawing.Size(242, 20)
        Me.TxtNombre.TabIndex = 99
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(7, 25)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(74, 15)
        Me.Label31.TabIndex = 98
        Me.Label31.Text = "Nombre Corto"
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(211, 271)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(93, 15)
        Me.Label29.TabIndex = 97
        Me.Label29.Text = "Zona de Reparto"
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(211, 244)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(93, 15)
        Me.Label30.TabIndex = 95
        Me.Label30.Text = "Zona de Venta"
        '
        'TxtColonia
        '
        Me.TxtColonia.Location = New System.Drawing.Point(110, 161)
        Me.TxtColonia.Name = "TxtColonia"
        Me.TxtColonia.Size = New System.Drawing.Size(262, 20)
        Me.TxtColonia.TabIndex = 5
        '
        'TxtMunicipio
        '
        Me.TxtMunicipio.Location = New System.Drawing.Point(110, 134)
        Me.TxtMunicipio.Name = "TxtMunicipio"
        Me.TxtMunicipio.Size = New System.Drawing.Size(147, 20)
        Me.TxtMunicipio.TabIndex = 3
        '
        'TxtEstado
        '
        Me.TxtEstado.Location = New System.Drawing.Point(425, 104)
        Me.TxtEstado.Name = "TxtEstado"
        Me.TxtEstado.Size = New System.Drawing.Size(176, 20)
        Me.TxtEstado.TabIndex = 2
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(7, 222)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 14)
        Me.Label18.TabIndex = 90
        Me.Label18.Text = "Referencia"
        '
        'TxtReferencia
        '
        Me.TxtReferencia.Location = New System.Drawing.Point(110, 215)
        Me.TxtReferencia.Name = "TxtReferencia"
        Me.TxtReferencia.Size = New System.Drawing.Size(491, 20)
        Me.TxtReferencia.TabIndex = 10
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(495, 191)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 16)
        Me.Label19.TabIndex = 88
        Me.Label19.Text = "No. Int."
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(386, 192)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(51, 16)
        Me.Label20.TabIndex = 87
        Me.Label20.Text = "No. Ext."
        '
        'TxtNoInterior
        '
        Me.TxtNoInterior.Location = New System.Drawing.Point(546, 188)
        Me.TxtNoInterior.Name = "TxtNoInterior"
        Me.TxtNoInterior.Size = New System.Drawing.Size(55, 20)
        Me.TxtNoInterior.TabIndex = 9
        '
        'TxtNoExterior
        '
        Me.TxtNoExterior.Location = New System.Drawing.Point(437, 188)
        Me.TxtNoExterior.Name = "TxtNoExterior"
        Me.TxtNoExterior.Size = New System.Drawing.Size(55, 20)
        Me.TxtNoExterior.TabIndex = 8
        '
        'TxtCodigoPostal
        '
        Me.TxtCodigoPostal.Location = New System.Drawing.Point(478, 159)
        Me.TxtCodigoPostal.Name = "TxtCodigoPostal"
        Me.TxtCodigoPostal.Size = New System.Drawing.Size(123, 20)
        Me.TxtCodigoPostal.TabIndex = 6
        '
        'TxtLocalidad
        '
        Me.TxtLocalidad.Location = New System.Drawing.Point(426, 131)
        Me.TxtLocalidad.Name = "TxtLocalidad"
        Me.TxtLocalidad.Size = New System.Drawing.Size(175, 20)
        Me.TxtLocalidad.TabIndex = 4
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(326, 133)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 14)
        Me.Label16.TabIndex = 77
        Me.Label16.Text = "Ciudad/Poblaci�n"
        '
        'TxtCalle
        '
        Me.TxtCalle.Location = New System.Drawing.Point(110, 188)
        Me.TxtCalle.Name = "TxtCalle"
        Me.TxtCalle.Size = New System.Drawing.Size(275, 20)
        Me.TxtCalle.TabIndex = 7
        '
        'LblCalle
        '
        Me.LblCalle.Location = New System.Drawing.Point(7, 192)
        Me.LblCalle.Name = "LblCalle"
        Me.LblCalle.Size = New System.Drawing.Size(60, 15)
        Me.LblCalle.TabIndex = 67
        Me.LblCalle.Text = "Calle"
        '
        'BtnDelDomi
        '
        Me.BtnDelDomi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnDelDomi.Enabled = False
        Me.BtnDelDomi.Image = CType(resources.GetObject("BtnDelDomi.Image"), System.Drawing.Image)
        Me.BtnDelDomi.Location = New System.Drawing.Point(657, 62)
        Me.BtnDelDomi.Name = "BtnDelDomi"
        Me.BtnDelDomi.Size = New System.Drawing.Size(90, 30)
        Me.BtnDelDomi.TabIndex = 12
        Me.BtnDelDomi.Text = "&Eliminar"
        Me.BtnDelDomi.ToolTipText = "Eliminar domicilio seleccionado"
        Me.BtnDelDomi.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'LblColonia
        '
        Me.LblColonia.Location = New System.Drawing.Point(7, 162)
        Me.LblColonia.Name = "LblColonia"
        Me.LblColonia.Size = New System.Drawing.Size(80, 18)
        Me.LblColonia.TabIndex = 59
        Me.LblColonia.Text = "Colonia"
        '
        'LblMnpio
        '
        Me.LblMnpio.Location = New System.Drawing.Point(7, 135)
        Me.LblMnpio.Name = "LblMnpio"
        Me.LblMnpio.Size = New System.Drawing.Size(53, 15)
        Me.LblMnpio.TabIndex = 57
        Me.LblMnpio.Text = "Municipio"
        '
        'LblEstado
        '
        Me.LblEstado.Location = New System.Drawing.Point(323, 107)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(97, 17)
        Me.LblEstado.TabIndex = 55
        Me.LblEstado.Text = "Entidad/Estado"
        '
        'LblPais
        '
        Me.LblPais.Location = New System.Drawing.Point(7, 109)
        Me.LblPais.Name = "LblPais"
        Me.LblPais.Size = New System.Drawing.Size(36, 15)
        Me.LblPais.TabIndex = 51
        Me.LblPais.Text = "Pa�s"
        '
        'BtnAceptarDomi
        '
        Me.BtnAceptarDomi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAceptarDomi.Image = CType(resources.GetObject("BtnAceptarDomi.Image"), System.Drawing.Image)
        Me.BtnAceptarDomi.Location = New System.Drawing.Point(657, 18)
        Me.BtnAceptarDomi.Name = "BtnAceptarDomi"
        Me.BtnAceptarDomi.Size = New System.Drawing.Size(90, 30)
        Me.BtnAceptarDomi.TabIndex = 11
        Me.BtnAceptarDomi.Text = "&Aceptar"
        Me.BtnAceptarDomi.ToolTipText = "Guardar cambios"
        Me.BtnAceptarDomi.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(388, 163)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(78, 15)
        Me.Label17.TabIndex = 79
        Me.Label17.Text = "C�digo Postal"
        '
        'cmbZonaRep
        '
        Me.cmbZonaRep.BackColor = System.Drawing.SystemColors.Window
        Me.cmbZonaRep.ItemHeight = 13
        Me.cmbZonaRep.Location = New System.Drawing.Point(338, 268)
        Me.cmbZonaRep.Name = "cmbZonaRep"
        Me.cmbZonaRep.Size = New System.Drawing.Size(263, 21)
        Me.cmbZonaRep.TabIndex = 96
        '
        'cmbZonaVtap
        '
        Me.cmbZonaVtap.BackColor = System.Drawing.SystemColors.Window
        Me.cmbZonaVtap.ItemHeight = 13
        Me.cmbZonaVtap.Location = New System.Drawing.Point(338, 241)
        Me.cmbZonaVtap.Name = "cmbZonaVtap"
        Me.cmbZonaVtap.Size = New System.Drawing.Size(263, 21)
        Me.cmbZonaVtap.TabIndex = 94
        '
        'ChkDomicilio
        '
        Me.ChkDomicilio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkDomicilio.Checked = True
        Me.ChkDomicilio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkDomicilio.Enabled = False
        Me.ChkDomicilio.Location = New System.Drawing.Point(110, 244)
        Me.ChkDomicilio.Name = "ChkDomicilio"
        Me.ChkDomicilio.Size = New System.Drawing.Size(69, 22)
        Me.ChkDomicilio.TabIndex = 7
        Me.ChkDomicilio.Text = "Activo"
        '
        'cmbPais
        '
        Me.cmbPais.Location = New System.Drawing.Point(110, 106)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(147, 21)
        Me.cmbPais.TabIndex = 13
        '
        'GrpDomicilios
        '
        Me.GrpDomicilios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDomicilios.BackColor = System.Drawing.Color.Transparent
        Me.GrpDomicilios.Controls.Add(Me.GridDomicilios)
        Me.GrpDomicilios.Location = New System.Drawing.Point(8, 307)
        Me.GrpDomicilios.Name = "GrpDomicilios"
        Me.GrpDomicilios.Size = New System.Drawing.Size(755, 168)
        Me.GrpDomicilios.TabIndex = 1
        Me.GrpDomicilios.TabStop = False
        Me.GrpDomicilios.Text = "Domicilios de Punto de Entrega"
        '
        'GridDomicilios
        '
        Me.GridDomicilios.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridDomicilios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDomicilios.ColumnAutoResize = True
        Me.GridDomicilios.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridDomicilios.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridDomicilios.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridDomicilios.Location = New System.Drawing.Point(7, 15)
        Me.GridDomicilios.Name = "GridDomicilios"
        Me.GridDomicilios.RecordNavigator = True
        Me.GridDomicilios.Size = New System.Drawing.Size(741, 145)
        Me.GridDomicilios.TabIndex = 1
        Me.GridDomicilios.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabSaldos
        '
        Me.UiTabSaldos.Controls.Add(Me.GrpSaldos)
        Me.UiTabSaldos.Location = New System.Drawing.Point(1, 21)
        Me.UiTabSaldos.Name = "UiTabSaldos"
        Me.UiTabSaldos.Size = New System.Drawing.Size(771, 482)
        Me.UiTabSaldos.TabStop = True
        Me.UiTabSaldos.Text = "Saldos"
        '
        'GrpSaldos
        '
        Me.GrpSaldos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpSaldos.BackColor = System.Drawing.Color.Transparent
        Me.GrpSaldos.Controls.Add(Me.LblSaldo)
        Me.GrpSaldos.Controls.Add(Me.NumSaldo)
        Me.GrpSaldos.Controls.Add(Me.LblCredito)
        Me.GrpSaldos.Controls.Add(Me.NumDisponible)
        Me.GrpSaldos.Controls.Add(Me.GridSaldos)
        Me.GrpSaldos.Location = New System.Drawing.Point(7, 7)
        Me.GrpSaldos.Name = "GrpSaldos"
        Me.GrpSaldos.Size = New System.Drawing.Size(754, 468)
        Me.GrpSaldos.TabIndex = 10
        Me.GrpSaldos.TabStop = False
        Me.GrpSaldos.Text = "Saldos de Facturas"
        '
        'LblSaldo
        '
        Me.LblSaldo.Location = New System.Drawing.Point(327, 18)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(80, 15)
        Me.LblSaldo.TabIndex = 61
        Me.LblSaldo.Text = "Total Saldo"
        '
        'NumSaldo
        '
        Me.NumSaldo.Location = New System.Drawing.Point(413, 13)
        Me.NumSaldo.Name = "NumSaldo"
        Me.NumSaldo.ReadOnly = True
        Me.NumSaldo.Size = New System.Drawing.Size(134, 20)
        Me.NumSaldo.TabIndex = 60
        Me.NumSaldo.Text = "0.00"
        Me.NumSaldo.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.NumSaldo.Value = 0
        Me.NumSaldo.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'LblCredito
        '
        Me.LblCredito.Location = New System.Drawing.Point(13, 18)
        Me.LblCredito.Name = "LblCredito"
        Me.LblCredito.Size = New System.Drawing.Size(98, 15)
        Me.LblCredito.TabIndex = 59
        Me.LblCredito.Text = "Cr�dito Disponible"
        '
        'NumDisponible
        '
        Me.NumDisponible.Location = New System.Drawing.Point(119, 13)
        Me.NumDisponible.Name = "NumDisponible"
        Me.NumDisponible.ReadOnly = True
        Me.NumDisponible.Size = New System.Drawing.Size(133, 20)
        Me.NumDisponible.TabIndex = 58
        Me.NumDisponible.Text = "0.00"
        Me.NumDisponible.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
        Me.NumDisponible.Value = 0
        Me.NumDisponible.ValueType = Janus.Windows.GridEX.NumericEditValueType.[Double]
        '
        'GridSaldos
        '
        Me.GridSaldos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridSaldos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridSaldos.ColumnAutoResize = True
        Me.GridSaldos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridSaldos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridSaldos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridSaldos.Location = New System.Drawing.Point(13, 37)
        Me.GridSaldos.Name = "GridSaldos"
        Me.GridSaldos.RecordNavigator = True
        Me.GridSaldos.Size = New System.Drawing.Size(728, 415)
        Me.GridSaldos.TabIndex = 2
        Me.GridSaldos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'UiTabMetodo
        '
        Me.UiTabMetodo.Controls.Add(Me.GrpMetodos)
        Me.UiTabMetodo.Location = New System.Drawing.Point(1, 21)
        Me.UiTabMetodo.Name = "UiTabMetodo"
        Me.UiTabMetodo.Size = New System.Drawing.Size(771, 482)
        Me.UiTabMetodo.TabStop = True
        Me.UiTabMetodo.Text = "Metodo de Pago"
        '
        'GrpMetodos
        '
        Me.GrpMetodos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpMetodos.BackColor = System.Drawing.Color.Transparent
        Me.GrpMetodos.Controls.Add(Me.BtnAgregar)
        Me.GrpMetodos.Controls.Add(Me.GridMetodos)
        Me.GrpMetodos.Controls.Add(Me.BtnElimina)
        Me.GrpMetodos.Controls.Add(Me.BtnModifica)
        Me.GrpMetodos.Location = New System.Drawing.Point(2, 3)
        Me.GrpMetodos.Name = "GrpMetodos"
        Me.GrpMetodos.Size = New System.Drawing.Size(764, 476)
        Me.GrpMetodos.TabIndex = 5
        Me.GrpMetodos.TabStop = False
        Me.GrpMetodos.Text = "Metodos Preferidos de Pago"
        '
        'BtnAgregar
        '
        Me.BtnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAgregar.Image = CType(resources.GetObject("BtnAgregar.Image"), System.Drawing.Image)
        Me.BtnAgregar.Location = New System.Drawing.Point(672, 15)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(90, 30)
        Me.BtnAgregar.TabIndex = 2
        Me.BtnAgregar.Text = "&Agregar"
        Me.BtnAgregar.ToolTipText = "Agrega nuevo Metodo de Pago"
        Me.BtnAgregar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridMetodos
        '
        Me.GridMetodos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.GridMetodos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMetodos.ColumnAutoResize = True
        Me.GridMetodos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridMetodos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridMetodos.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
        Me.GridMetodos.Location = New System.Drawing.Point(7, 15)
        Me.GridMetodos.Name = "GridMetodos"
        Me.GridMetodos.RecordNavigator = True
        Me.GridMetodos.Size = New System.Drawing.Size(659, 454)
        Me.GridMetodos.TabIndex = 1
        Me.GridMetodos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnElimina
        '
        Me.BtnElimina.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnElimina.Image = CType(resources.GetObject("BtnElimina.Image"), System.Drawing.Image)
        Me.BtnElimina.Location = New System.Drawing.Point(672, 97)
        Me.BtnElimina.Name = "BtnElimina"
        Me.BtnElimina.Size = New System.Drawing.Size(90, 30)
        Me.BtnElimina.TabIndex = 4
        Me.BtnElimina.Text = "&Eliminar "
        Me.BtnElimina.ToolTipText = "Elimina el Metodo de Pago seleccionada"
        Me.BtnElimina.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnModifica
        '
        Me.BtnModifica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnModifica.Image = CType(resources.GetObject("BtnModifica.Image"), System.Drawing.Image)
        Me.BtnModifica.Location = New System.Drawing.Point(672, 59)
        Me.BtnModifica.Name = "BtnModifica"
        Me.BtnModifica.Size = New System.Drawing.Size(90, 30)
        Me.BtnModifica.TabIndex = 3
        Me.BtnModifica.Text = "&Modificar "
        Me.BtnModifica.ToolTipText = "Modifica el Metodo de Pago seleccionada"
        Me.BtnModifica.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'UiTabClasificaciones
        '
        Me.UiTabClasificaciones.Controls.Add(Me.GrpClasificaciones)
        Me.UiTabClasificaciones.Location = New System.Drawing.Point(1, 21)
        Me.UiTabClasificaciones.Name = "UiTabClasificaciones"
        Me.UiTabClasificaciones.Size = New System.Drawing.Size(771, 482)
        Me.UiTabClasificaciones.TabStop = True
        Me.UiTabClasificaciones.Text = "Clasificaciones"
        '
        'GrpClasificaciones
        '
        Me.GrpClasificaciones.BackColor = System.Drawing.Color.LightSteelBlue
        Me.GrpClasificaciones.Controls.Add(Me.BtnBuscaClasificacion)
        Me.GrpClasificaciones.Controls.Add(Me.TxtClasificacion)
        Me.GrpClasificaciones.Controls.Add(Me.LblReferencia)
        Me.GrpClasificaciones.Controls.Add(Me.btnDelClasificacion)
        Me.GrpClasificaciones.Controls.Add(Me.GridClasificaciones)
        Me.GrpClasificaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpClasificaciones.Location = New System.Drawing.Point(0, 0)
        Me.GrpClasificaciones.Name = "GrpClasificaciones"
        Me.GrpClasificaciones.Size = New System.Drawing.Size(771, 482)
        Me.GrpClasificaciones.TabIndex = 12
        Me.GrpClasificaciones.TabStop = False
        Me.GrpClasificaciones.Text = "Clasificaciones de Cliente"
        '
        'BtnBuscaClasificacion
        '
        Me.BtnBuscaClasificacion.Image = CType(resources.GetObject("BtnBuscaClasificacion.Image"), System.Drawing.Image)
        Me.BtnBuscaClasificacion.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscaClasificacion.Location = New System.Drawing.Point(248, 22)
        Me.BtnBuscaClasificacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnBuscaClasificacion.Name = "BtnBuscaClasificacion"
        Me.BtnBuscaClasificacion.Size = New System.Drawing.Size(31, 30)
        Me.BtnBuscaClasificacion.TabIndex = 133
        Me.BtnBuscaClasificacion.ToolTipText = "Busqueda de clasificaciones"
        Me.BtnBuscaClasificacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtClasificacion
        '
        Me.TxtClasificacion.Location = New System.Drawing.Point(88, 29)
        Me.TxtClasificacion.Name = "TxtClasificacion"
        Me.TxtClasificacion.Size = New System.Drawing.Size(154, 20)
        Me.TxtClasificacion.TabIndex = 102
        '
        'LblReferencia
        '
        Me.LblReferencia.Location = New System.Drawing.Point(13, 32)
        Me.LblReferencia.Name = "LblReferencia"
        Me.LblReferencia.Size = New System.Drawing.Size(66, 15)
        Me.LblReferencia.TabIndex = 103
        Me.LblReferencia.Text = "Referencia"
        '
        'btnDelClasificacion
        '
        Me.btnDelClasificacion.Icon = CType(resources.GetObject("btnDelClasificacion.Icon"), System.Drawing.Icon)
        Me.btnDelClasificacion.Location = New System.Drawing.Point(285, 22)
        Me.btnDelClasificacion.Name = "btnDelClasificacion"
        Me.btnDelClasificacion.Size = New System.Drawing.Size(31, 30)
        Me.btnDelClasificacion.TabIndex = 5
        Me.btnDelClasificacion.ToolTipText = "Eliminar clasificaci�n seleccionada"
        Me.btnDelClasificacion.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridClasificaciones
        '
        Me.GridClasificaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridClasificaciones.ColumnAutoResize = True
        Me.GridClasificaciones.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridClasificaciones.Location = New System.Drawing.Point(10, 57)
        Me.GridClasificaciones.Name = "GridClasificaciones"
        Me.GridClasificaciones.RecordNavigator = True
        Me.GridClasificaciones.Size = New System.Drawing.Size(749, 420)
        Me.GridClasificaciones.TabIndex = 4
        Me.GridClasificaciones.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(593, 520)
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
        Me.BtnGuardar.Location = New System.Drawing.Point(689, 520)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(90, 37)
        Me.BtnGuardar.TabIndex = 2
        Me.BtnGuardar.Text = "&Aceptar"
        Me.BtnGuardar.ToolTipText = "Guardar cambios"
        Me.BtnGuardar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'FrmCliente
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.UiTab1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 432)
        Me.Name = "FrmCliente"
        Me.Text = "Clientes"
        CType(Me.UiTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTab1.ResumeLayout(False)
        Me.UiTabCliente.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox26, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCliente.ResumeLayout(False)
        Me.GrpCliente.PerformLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpContacto.ResumeLayout(False)
        Me.GrpContacto.PerformLayout()
        Me.UiTabDomicilio.ResumeLayout(False)
        Me.GrpDomicilio.ResumeLayout(False)
        Me.GrpDomicilio.PerformLayout()
        CType(Me.PictureBox25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDomicilios.ResumeLayout(False)
        CType(Me.GridDomicilios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabSaldos.ResumeLayout(False)
        Me.GrpSaldos.ResumeLayout(False)
        Me.GrpSaldos.PerformLayout()
        CType(Me.GridSaldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabMetodo.ResumeLayout(False)
        Me.GrpMetodos.ResumeLayout(False)
        CType(Me.GridMetodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiTabClasificaciones.ResumeLayout(False)
        Me.GrpClasificaciones.ResumeLayout(False)
        Me.GrpClasificaciones.PerformLayout()
        CType(Me.GridClasificaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables Publicas"

    Public Padre As String

    Public CTEClave As String = ""
    Public DCTEClaveFiscal As String = ""
    Public Clave As String = ""
    Public FechaReg As Date = DateTime.Today
    Public NombreCorto As String = ""
    Public RazonSocial As String = ""
    Public TPersona As Integer
    Public RFC As String = ""
    Public CURP As String = ""
    Public LCredito As Double
    Public Saldo As Double
    Public Contacto As String = ""
    Public Tel1 As String = ""
    Public Tel2 As String = ""
    Public email As String = ""
    Public Estado As Integer = 1
    Public CreditoDisponible As Double
    Public TDomicilio As Integer
    Public Pais As String
    Public Entidad As String = ""
    Public Mnpio As String = ""
    Public Colonia As String = ""
    Public Localidad As String = ""
    Public codigoPostal As String = ""
    Public referencia As String = ""
    Public noInterior As String = ""
    Public noExterior As String = ""
    Public GLN As String = ""
    Public ZonaVenta As Integer
    Public ZonaReparto As Integer

    Public TipoImpuesto As Integer = 1

    Public Nombre As String = ""
    Public Consignatario As String = ""
    Public TelDomicilio As String = ""
    Public PaisF As String
    Public EntidadF As String = ""
    Public MnpioF As String = ""
    Public ColoniaF As String = ""
    Public CalleF As String = ""
    Public LocalidadF As String = ""
    Public codigoPostalF As String = ""
    Public referenciaF As String = ""
    Public noInteriorF As String = ""
    Public noExteriorF As String = ""
    Public ZonaVentaF As Integer
    Public ZonaRepartoF As Integer

    Public listaPrecio As String = ""
    Public DiasCredito As Integer
    Public DesglosaIVA As Boolean = False

    Public CtaContable As String = ""
    Public fromForm As String = ""
    Public ClienteInicial As String = ""

    Public Alterno As String = ""
    Public Responsable As Integer
    Public TipoCanal As Integer
    Public Ramo As Integer

    Public DescuentoDirecto As Integer
    Public DescuentoPostVenta As Integer


#End Region

#Region "Variables Privadas"

    Private aEstado() As String
    Private aMnpio() As String
    Private aColonia() As String

    Private DCTEClave As String = ""
    Private sDomicilio As String = ""
    Private DomicilioPadre As String = "Agregar"

    Private Cnx As String
    Private alerta(26) As PictureBox
    Private reloj As parpadea

    Private guardado As Boolean = False
    Private cargado As Boolean = False

    Private dLimite As Double
    Private iDias As Integer

    Private DomicilioEstado As Integer
    Private Calle As String = ""

    Private dtMetodosPago As DataTable
    Private sMetodoPago As String
    Private sTipoMetodo, sBanco, sReferencia As String

    Private MaxCredito As Double = 0
    Private CambiaLista As Integer

    Private dtDomicilios, dtClasificaciones, dtDirecto, dtPostVenta As DataTable

#End Region

#Region "Cliente"

    Private Sub recuperaCondiciones(ByVal sCTEClave As String)
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_cliente", "@CTEClave", sCTEClave)

        TPersona = dt.Rows(0)("TPersona")
        TipoImpuesto = dt.Rows(0)("TipoImpuesto")
        LCredito = dt.Rows(0)("LimiteCredito")
        DiasCredito = dt.Rows(0)("DiasCredito")

        listaPrecio = dt.Rows(0)("PREClave")
        DesglosaIVA = dt.Rows(0)("DesglosaIVA")
        PaisF = dt.Rows(0)("Pais")
        CtaContable = IIf(dt.Rows(0)("CtaContable").GetType.Name = "DBNull", "", dt.Rows(0)("CtaContable"))


        DescuentoDirecto = IIf(dt.Rows(0)("DescuentoDirecto").GetType.Name = "DBNull", -1, dt.Rows(0)("DescuentoDirecto"))
        DescuentoPostVenta = IIf(dt.Rows(0)("DescuentoPostVenta").GetType.Name = "DBNull", -1, dt.Rows(0)("DescuentoPostVenta"))

        dt.Dispose()

        CmbTipoPersona.SelectedValue = TPersona
        CmbTipo.SelectedValue = TipoImpuesto
        TxtLimite.Text = CStr(LCredito)
        TxtDiasCredito.Text = CInt(DiasCredito)

        cmbListaPrecio.SelectedValue = listaPrecio

        ChkDesglosarIVA.Checked = DesglosaIVA
        CmbPaisFac.Text = PaisF
        cmbResponsable.SelectedValue = Responsable

        cmbDirecto.SelectedValue = DescuentoDirecto
        cmbPostVenta.SelectedValue = DescuentoPostVenta

    End Sub


    Public Sub AddMetodoPago(ByVal sMTPClave As String, ByVal iMetodoPago As Integer, ByVal sTipo As String, ByVal sBancoClave As String, ByVal sBancoNombre As String, ByVal sRef As String, ByVal iPreferido As Integer, ByVal iTipoEstado As Integer)

        Dim foundRows() As Data.DataRow
        foundRows = dtMetodosPago.Select("MTPClave Like '" & sMTPClave & "' and Baja = 0")

        If foundRows.Length = 0 Then

            foundRows = dtMetodosPago.Select("MetodoPago = " & iMetodoPago & " and Referencia like '" & sRef & "' and BNKClave like '" & sBancoClave & "' and Baja = 0")
            If foundRows.Length = 0 Then

                Dim row1 As DataRow
                row1 = dtMetodosPago.NewRow()
                'declara el nombre de la fila

                row1.Item("MTPClave") = sMTPClave
                row1.Item("MetodoPago") = iMetodoPago
                row1.Item("Tipo") = sTipo
                row1.Item("BNKClave") = sBancoClave
                row1.Item("Banco") = sBancoNombre
                row1.Item("Referencia") = sRef
                row1.Item("TipoEstado") = iTipoEstado
                row1.Item("Estado") = IIf(iTipoEstado = 1, "Activo", "Inactivo")
                row1.Item("Preferido") = iPreferido
                row1.Item("update") = 1
                row1.Item("Baja") = 0

                dtMetodosPago.Rows.Add(row1)
                'agrega la fila completo a la tabla

            Else
                Beep()
                MessageBox.Show("�La referencia de Metodo de Pago que intenta agregar ya existe para el cliente actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If

        Else
            foundRows(0)("Referencia") = sRef
            foundRows(0)("Estado") = IIf(iTipoEstado = 1, "Activo", "Inactivo")
            foundRows(0)("TipoEstado") = iTipoEstado
            foundRows(0)("Preferido") = iPreferido
            foundRows(0)("update") = 1
        End If
    End Sub

    Private Sub cargaMetodosPago()
        If Padre = "Agregar" Then

            dtMetodosPago = ModPOS.CrearTabla("ClientePago", _
            "MTPClave", "System.String", _
            "MetodoPago", "System.Int32", _
            "Tipo", "System.String", _
            "BNKClave", "System.String", _
            "Banco", "System.String", _
            "Referencia", "System.String", _
            "TipoEstado", "System.Int32", _
            "Estado", "System.String", _
            "Preferido", "System.Boolean", _
            "update", "System.Int32", _
            "Baja", "System.Int32")
        Else
            dtMetodosPago = ModPOS.Recupera_Tabla("sp_recupera_clientepago", "@CTEClave", CTEClave)
        End If


        With Me.GridMetodos
            .DataSource = dtMetodosPago
            .RetrieveStructure(True)
            .GroupByBoxVisible = False
            .RootTable.Columns("MTPClave").Visible = False
            .RootTable.Columns("MetodoPago").Visible = False
            .RootTable.Columns("BNKClave").Visible = False
            .RootTable.Columns("TipoEstado").Visible = False
            .RootTable.Columns("Update").Visible = False
            .RootTable.Columns("Baja").Visible = False

            .CurrentTable.Columns("Preferido").Selectable = False
            .CurrentTable.Columns("Tipo").Selectable = False
            .CurrentTable.Columns("Banco").Selectable = False
            .CurrentTable.Columns("Referencia").Selectable = False
            .CurrentTable.Columns("Estado").Selectable = False

            Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
            fc = New Janus.Windows.GridEX.GridEXFormatCondition(.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

            fc.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
            fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
            .RootTable.FormatConditions.Add(fc)


            Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
            fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(.RootTable.Columns("TipoEstado"), Janus.Windows.GridEX.ConditionOperator.Equal, 0)

            fc1.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
            .RootTable.FormatConditions.Add(fc1)

        End With


    End Sub

    Private Sub FrmCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Me.BringToFront()

        alerta(0) = Me.PictureBox1
        alerta(1) = Me.PictureBox2
        alerta(2) = Me.PictureBox3
        alerta(3) = Me.PictureBox4
        alerta(4) = Me.PictureBox5
        alerta(5) = Me.PictureBox6

        alerta(6) = Me.PictureBox7
        alerta(7) = Me.PictureBox8
        alerta(8) = Me.PictureBox9
        alerta(9) = Me.PictureBox10

        alerta(25) = Me.PictureBox26
        alerta(26) = Me.PictureBox27

        'Domicilio Fiscal
        alerta(10) = Me.PictureBox11
        alerta(11) = Me.PictureBox12
        alerta(12) = Me.PictureBox13
        alerta(13) = Me.PictureBox14
        alerta(14) = Me.PictureBox15
        alerta(15) = Me.PictureBox16
        alerta(16) = Me.PictureBox17


        'Domicilio Entrega
        alerta(17) = Me.PictureBox18
        alerta(18) = Me.PictureBox19
        alerta(19) = Me.PictureBox20
        alerta(20) = Me.PictureBox21
        alerta(21) = Me.PictureBox22
        alerta(22) = Me.PictureBox23
        alerta(23) = Me.PictureBox24
        alerta(24) = Me.PictureBox25

        Cnx = ModPOS.BDConexion

        With Me.CmbTipoPersona
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With

        With Me.CmbTipo
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Impuesto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Tipo"
            .llenar()
        End With


        With cmbTipoCanal
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "TipoCanal"
            .llenar()
        End With


        With cmbResponsable
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "Responsable"
            .llenar()
        End With

        With cmbRamo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "Ramo"
            .llenar()
        End With

        With Me.cmbListaPrecio
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_listas_canal"
            .NombreParametro1 = "TipoCanal"
            .Parametro1 = cmbTipoCanal.SelectedValue
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With


        With Me.cmbPais
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Geografia"
            .NombreParametro2 = "campo"
            .Parametro2 = "Pais"
            .llenar()
        End With


        With Me.CmbPaisFac
            .Conexion = Cnx
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Geografia"
            .NombreParametro2 = "campo"
            .Parametro2 = "Pais"
            .llenar()
        End With

        With cmbZonaVenta
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "ZonaVenta"
            .llenar()
        End With

        With cmbZonaReparto
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "ZonaReparto"
            .llenar()
        End With


        With cmbZonaVtap
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "ZonaVenta"
            .llenar()
        End With

        With cmbZonaRep
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "ZonaReparto"
            .llenar()
        End With

        With cmbDirecto
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "DescuentoDirecto"
            .llenar()
        End With

        With cmbPostVenta
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Cliente"
            .NombreParametro2 = "campo"
            .Parametro2 = "DescuentoPostVenta"
            .llenar()
        End With

        Dim dtEstado As DataTable

        dtEstado = ModPOS.Recupera_Tabla("sp_filtra_estado", "@Pais", CmbPaisFac.SelectedValue)
        If dtEstado.Rows.Count > 0 Then
            ReDim aEstado(dtEstado.Rows.Count - 1)

            For i As Integer = 0 To dtEstado.Rows.Count - 1
                aEstado(i) = dtEstado.Rows(i)("d_estado")
            Next

            Me.TxtEstadoFac.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Me.TxtEstadoFac.AutoCompleteSource = AutoCompleteSource.CustomSource
            Me.TxtEstadoFac.AutoCompleteCustomSource.AddRange(aEstado)


            Me.TxtEstado.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Me.TxtEstado.AutoCompleteSource = AutoCompleteSource.CustomSource
            Me.TxtEstado.AutoCompleteCustomSource.AddRange(aEstado)

            dtEstado.Dispose()
        End If


        cargado = True

        CmbTipoPersona.SelectedValue = TPersona
        TxtClave.Text = Clave
        TxtNombreCorto.Text = NombreCorto
        TxtRazonSocial.Text = RazonSocial
        TxtRFC.Text = RFC
        TxtCURP.Text = CURP
        cmbTipoCanal.SelectedValue = TipoCanal
        cmbListaPrecio.SelectedValue = listaPrecio
        cmbResponsable.SelectedValue = Responsable
        TxtCtaContable.Text = CtaContable

        TxtFechaRegistro.Text = FechaReg.ToString("MMMM dd,yyyy")
        ChkEstado.Estado = Estado
        txtAlterno.Text = Alterno
        TxtGLN.Text = GLN
        cmbRamo.SelectedValue = Ramo
        ChkDesglosarIVA.Checked = DesglosaIVA
        CmbTipo.SelectedValue = TipoImpuesto
        TxtLimite.Text = CStr(LCredito)
        TxtDiasCredito.Text = CInt(DiasCredito)


        CmbPaisFac.Text = PaisF
        TxtEstadoFac.Text = EntidadF
        TxtMunicipioFac.Text = MnpioF
        TxtColoniaFac.Text = ColoniaF
        TxtLocalidadFac.Text = LocalidadF
        TxtDomicilioFac.Text = CalleF
        TxtCodigoPostalFac.Text = codigoPostalF
        TxtNoInteriorFac.Text = noInteriorF
        TxtNoExteriorFac.Text = noExteriorF
        TxtReferenciaFac.Text = referenciaF
        cmbZonaVenta.SelectedValue = ZonaVentaF
        cmbZonaReparto.SelectedValue = ZonaRepartoF

        cmbDirecto.SelectedValue = DescuentoDirecto
        cmbPostVenta.SelectedValue = DescuentoPostVenta

        TxtContacto.Text = Contacto
        TxtTel1.Text = Tel1
        TxtTel2.Text = Tel2
        TxtMail.Text = email

        NumSaldo.Text = CStr(Saldo)
        NumDisponible.Text = CStr(CreditoDisponible)


        If Padre = "Modificar" Then
            BtnKey.Enabled = False

        End If

        cargaPuntosdeEntrega()

        cargaMetodosPago()

        cargaClasificaciones()

        cargaDirecto()

        cargaPostVenta()


        Dim dtUsuario As DataTable

        dtUsuario = Recupera_Tabla("sp_recupera_usuarioActual", "@Usuario", ModPOS.UsuarioActual)
        MaxCredito = IIf(dtUsuario.Rows(0)("MaxCredito").GetType.FullName = "System.DBNull", 0, dtUsuario.Rows(0)("MaxCredito"))
        CambiaLista = IIf(dtUsuario.Rows(0)("CambiaLista").GetType.FullName = "System.DBNull", 0, dtUsuario.Rows(0)("CambiaLista"))
        dtUsuario.Dispose()


        If MaxCredito = 0 OrElse Me.LCredito > MaxCredito Then
            TxtLimite.Enabled = False
            TxtDiasCredito.Enabled = False
        End If

        If CambiaLista = 0 Then
            cmbListaPrecio.Enabled = False
        End If

        If Padre = "Agregar" AndAlso ClienteInicial <> "" Then
            recuperaCondiciones(ClienteInicial)
        End If
    End Sub

    Private Sub FrmCliente_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not ModPOS.MtoCliente Is Nothing Then
            ModPOS.MtoCliente.actGrid("0")
            If Padre = "Agregar" Then
                ModPOS.MtoCliente.actualizaTree(IIf(ModPOS.MtoCliente.cmbGrupo.SelectedValue Is Nothing, 0, ModPOS.MtoCliente.cmbGrupo.SelectedValue))
            End If
        End If
        ModPOS.Cliente.Dispose()
        ModPOS.Cliente = Nothing
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub



    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        If Padre = "Agregar" AndAlso TxtRFC.Text = "" Then
            TxtRFC.Text = "XAXX010101000"
            CmbTipoPersona.SelectedValue = 1
        End If

        If validaForm() Then

            Dim foundRows() As System.Data.DataRow

            If Me.GridMetodos.RecordCount > 0 Then
                foundRows = dtMetodosPago.Select(" Preferido = 1 and Baja = 0 ")

                If foundRows.Length <> 1 Then
                    Beep()
                    MessageBox.Show("Debe detener un Metodo de Pago marcado como Preferido. Verifique no tener m�s de uno seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            End If



            Select Case Me.Padre
                Case "Agregar"


                    If MaxCredito < dLimite Then
                        Beep()
                        MessageBox.Show("El limite de cr�dito que intenta otorgar excede el rango permitido para el usuario actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If

                    CTEClave = ModPOS.obtenerLlave

                    TPersona = CmbTipoPersona.SelectedValue
                    Clave = TxtClave.Text.ToUpper.Trim
                    NombreCorto = TxtNombreCorto.Text.ToUpper.Trim
                    RazonSocial = TxtRazonSocial.Text.ToUpper.Trim
                    RFC = TxtRFC.Text.ToUpper.Trim
                    CURP = TxtCURP.Text.ToUpper.Trim
                    TipoCanal = cmbTipoCanal.SelectedValue
                    listaPrecio = cmbListaPrecio.SelectedValue
                    Responsable = cmbResponsable.SelectedValue
                    CtaContable = TxtCtaContable.Text.Trim.ToUpper

                    Alterno = txtAlterno.Text
                    GLN = TxtGLN.Text.ToUpper.Trim

                    If Not cmbRamo.SelectedValue Is Nothing Then
                        Ramo = cmbRamo.SelectedValue
                    Else
                        Ramo = 0
                    End If

                    DesglosaIVA = ChkDesglosarIVA.Checked
                    TipoImpuesto = CmbTipo.SelectedValue
                    LCredito = dLimite
                    DiasCredito = iDias

                    If LCredito = 0 Then
                        DiasCredito = 0
                    End If

                    Contacto = TxtContacto.Text.ToUpper.Trim
                    Tel1 = TxtTel1.Text.ToUpper.Trim
                    Tel2 = TxtTel2.Text.ToUpper.Trim
                    email = TxtMail.Text.Trim

                    DescuentoDirecto = cmbDirecto.SelectedValue
                    DescuentoPostVenta = cmbPostVenta.SelectedValue


                    ModPOS.Ejecuta("sp_inserta_cliente", _
                                        "@CTEClave", CTEClave, _
                                        "@TPersona", TPersona, _
                                        "@Clave", Clave, _
                                        "@NombreCorto", NombreCorto, _
                                        "@RazonSocial", RazonSocial, _
                                        "@RFC", RFC, _
                                        "@CURP", CURP, _
                                        "@TipoCanal", TipoCanal, _
                                        "@ListaPrecio", listaPrecio, _
                                        "@Responsable", Responsable, _
                                        "@CtaContable", CtaContable, _
                                        "@Alterno", Alterno, _
                                        "@GLN", GLN, _
                                        "@Ramo", Ramo, _
                                        "@Desglosar", DesglosaIVA, _
                                        "@TipoImpuesto", TipoImpuesto, _
                                        "@LCredito", LCredito, _
                                        "@DCredito", DiasCredito, _
                                        "@Contacto", Contacto, _
                                        "@Tel1", Tel1, _
                                        "@Tel2", Tel2, _
                                        "@Email", email, _
                                        "@DescuentoDirecto", DescuentoDirecto, _
                                        "@DescuentoPostVenta", DescuentoPostVenta, _
                                        "@COMClave", ModPOS.CompanyActual, _
                                        "@Usuario", ModPOS.UsuarioActual)


                    PaisF = CmbPaisFac.Text.ToUpper.Trim
                    EntidadF = TxtEstadoFac.Text.ToUpper.Trim
                    MnpioF = TxtMunicipioFac.Text.ToUpper.Trim
                    CalleF = TxtDomicilioFac.Text.ToUpper.Trim
                    ColoniaF = TxtColoniaFac.Text.ToUpper.Trim
                    LocalidadF = TxtLocalidadFac.Text.ToUpper.Trim
                    codigoPostalF = TxtCodigoPostalFac.Text.ToUpper.Trim
                    referenciaF = TxtReferenciaFac.Text.ToUpper.Trim
                    noExteriorF = TxtNoExteriorFac.Text.ToUpper.Trim
                    noInteriorF = TxtNoInteriorFac.Text.ToUpper.Trim

                    If Not cmbZonaVenta.SelectedValue Is Nothing Then
                        ZonaVentaF = cmbZonaVenta.SelectedValue
                    Else
                        ZonaVentaF = 0
                    End If

                    If Not cmbZonaReparto.SelectedValue Is Nothing Then
                        ZonaRepartoF = cmbZonaReparto.SelectedValue
                    Else
                        ZonaRepartoF = 0
                    End If


                    DCTEClaveFiscal = ModPOS.obtenerLlave

                    ModPOS.Ejecuta("sp_inserta_domiciliocliente", _
                                        "@DCTEClave", DCTEClaveFiscal, _
                                        "@CTEClave", CTEClave, _
                                        "@TDomicilio", 1, _
                                        "@Pais", PaisF, _
                                        "@Entidad", EntidadF, _
                                        "@Municipio", MnpioF, _
                                        "@Colonia", ColoniaF, _
                                        "@Calle", CalleF, _
                                        "@codigoPostal", codigoPostalF, _
                                        "@Localidad", LocalidadF, _
                                        "@referencia", referenciaF, _
                                        "@noExterior", noExteriorF, _
                                        "@noInterior", noInteriorF, _
                                        "@ZonaVenta", ZonaVentaF, _
                                        "@ZonaReparto", ZonaRepartoF, _
                                        "@NombreCorto", NombreCorto, _
                                        "@Consignatario", RazonSocial, _
                                        "@Telefono", Tel1, _
                                        "@Usuario", ModPOS.UsuarioActual)

                    foundRows = dtDomicilios.Select(" Modificado = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        Dim j As Integer
                        For j = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_inserta_domiciliocliente", _
                                          "@DCTEClave", foundRows(j)("ID"), _
                                          "@CTEClave", CTEClave, _
                                          "@TDomicilio", 2, _
                                          "@Pais", foundRows(j)("Pa�s"), _
                                          "@Entidad", foundRows(j)("Entidad"), _
                                          "@Municipio", foundRows(j)("Municipio"), _
                                          "@Colonia", foundRows(j)("Colonia"), _
                                          "@codigoPostal", foundRows(j)("CP"), _
                                          "@Localidad", foundRows(j)("Localidad"), _
                                          "@referencia", foundRows(j)("Ref"), _
                                          "@noExterior", foundRows(j)("noExt"), _
                                          "@noInterior", foundRows(j)("noInt"), _
                                          "@Calle", foundRows(j)("Calle"), _
                                          "@ZonaVenta", foundRows(j)("ZonaVenta"), _
                                        "@ZonaReparto", foundRows(j)("ZonaReparto"), _
                                        "@NombreCorto", foundRows(j)("NombreCorto"), _
                                        "@Consignatario", foundRows(j)("Consignatario"), _
                                        "@Telefono", foundRows(j)("Telefono"), _
                                          "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    Dim z As Integer

                    'Clasificaciones

                    foundRows = dtClasificaciones.Select(" Update = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta clasprod
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_clasprod", "@Tipo", 1, "@Class", foundRows(z)("CLAClave"), "@Producto", CTEClave, "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If





                    foundRows = dtMetodosPago.Select(" update = 1 and Baja = 0 ")

                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago


                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_clientepago", _
                            "@MTPClave", foundRows(z)("MTPClave"), _
                            "@CTEClave", CTEClave, _
                            "@MetodoPago", foundRows(z)("MetodoPago"), _
                            "@BNKClave", foundRows(z)("BNKClave"), _
                            "@Referencia", CStr(foundRows(z)("Referencia")).Trim.ToUpper, _
                            "@Preferido", foundRows(z)("Preferido"), _
                            "@Estado", foundRows(z)("TipoEstado"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If


                    foundRows = dtDirecto.Select(" Update = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_excepcion_descuento", _
                            "@CTEClave", CTEClave, _
                            "@TipoSector", foundRows(z)("TipoSector"), _
                            "@Descuento", foundRows(z)("TipoDescuento"), _
                            "@Tipo", 1, _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If


                    foundRows = dtPostVenta.Select(" Update = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_excepcion_descuento", _
                            "@CTEClave", CTEClave, _
                            "@TipoSector", foundRows(z)("TipoSector"), _
                            "@Descuento", foundRows(z)("TipoDescuento"), _
                            "@Tipo", 2, _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    If fromForm = "Factura" Then
                        If Not ModPOS.Factura Is Nothing Then
                            ModPOS.Factura.CargaDatosCliente(CTEClave)
                        End If

                        Me.Close()
                    ElseIf fromForm = "NotaCargo" Then
                        If Not ModPOS.NotaCargo Is Nothing Then
                            ModPOS.NotaCargo.CargaDatosCliente(CTEClave)
                        End If
                        Me.Close()
                    ElseIf fromForm = "Viaje" Then
                        If Not ModPOS.AddCaja Is Nothing Then
                            ModPOS.Viaje.CargaDatosCliente(CTEClave)
                        End If
                        Me.Close()
                    ElseIf fromForm = "Venta" Then
                        If Not ModPOS.Venta Is Nothing Then
                            ModPOS.Venta.cambiaCliente(CTEClave)
                        End If
                        Me.Close()
                    End If

                    reinicializa()

                Case "Modificar"

                    Dim Limite, Dias As Double

                    Limite = dLimite
                    Dias = iDias

                    If Limite = 0 Then
                        Dias = 0
                    End If


                    If LCredito <> dLimite Then
                        If MaxCredito < dLimite Then
                            Beep()
                            MessageBox.Show("El limite de cr�dito que intenta otorgar excede el rango permitido para el usuario actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                    End If

                    Dim iRamo, iZV, iZR, iTipoSector As Integer
                    If Not cmbZonaVenta.SelectedValue Is Nothing Then
                        iZV = cmbZonaVenta.SelectedValue
                    Else
                        iZV = 0
                    End If


                    If Not cmbZonaReparto.SelectedValue Is Nothing Then
                        iZR = cmbZonaReparto.SelectedValue
                    Else
                        iZR = 0
                    End If

                    If Not cmbRamo.SelectedValue Is Nothing Then
                        iRamo = cmbRamo.SelectedValue
                    Else
                        iRamo = 0
                    End If


                    If Not ( _
                    TPersona = CmbTipoPersona.SelectedValue AndAlso _
                    NombreCorto = TxtNombreCorto.Text.ToUpper.Trim AndAlso _
                    RazonSocial = TxtRazonSocial.Text.ToUpper.Trim AndAlso _
                    RFC = TxtRFC.Text.ToUpper.Trim AndAlso _
                    CURP = TxtCURP.Text.ToUpper.Trim AndAlso _
                    TipoCanal = cmbTipoCanal.SelectedValue AndAlso _
                    listaPrecio = cmbListaPrecio.SelectedValue AndAlso _
                    Responsable = cmbResponsable.SelectedValue AndAlso _
                    CtaContable = TxtCtaContable.Text.Trim.ToUpper AndAlso _
                    Alterno = txtAlterno.Text AndAlso _
                    GLN = TxtGLN.Text.ToUpper.Trim AndAlso _
                    Ramo = iRamo AndAlso _
                    DesglosaIVA = ChkDesglosarIVA.Checked AndAlso _
                    TipoImpuesto = CmbTipo.SelectedValue AndAlso _
                    LCredito = Limite AndAlso _
                    DiasCredito = Dias AndAlso _
                    Contacto = TxtContacto.Text.ToUpper.Trim AndAlso _
                    Tel1 = TxtTel1.Text.ToUpper.Trim AndAlso _
                    Tel2 = TxtTel2.Text.ToUpper.Trim AndAlso _
                    email = TxtMail.Text.ToUpper.Trim AndAlso _
                    PaisF = CmbPaisFac.Text.ToUpper.Trim AndAlso _
                    EntidadF = TxtEstadoFac.Text.ToUpper.Trim AndAlso _
                    MnpioF = TxtMunicipioFac.Text.ToUpper.Trim AndAlso _
                    ColoniaF = TxtColoniaFac.Text.ToUpper.Trim AndAlso _
                    CalleF = TxtDomicilioFac.Text.ToUpper.Trim AndAlso _
                    LocalidadF = TxtLocalidadFac.Text.ToUpper.Trim AndAlso _
                    codigoPostalF = TxtCodigoPostalFac.Text.ToUpper.Trim AndAlso _
                    referenciaF = TxtReferenciaFac.Text.ToUpper.Trim AndAlso _
                    noExteriorF = TxtNoExteriorFac.Text.ToUpper.Trim AndAlso _
                    noInteriorF = TxtNoInteriorFac.Text.ToUpper.Trim AndAlso _
                    ZonaVentaF = iZV AndAlso _
                    ZonaRepartoF = iZR AndAlso _
                    DescuentoDirecto = cmbDirecto.SelectedValue AndAlso _
                    DescuentoPostVenta = cmbPostVenta.SelectedValue AndAlso _
                    Estado = Me.ChkEstado.GetEstado) Then



                        TPersona = CmbTipoPersona.SelectedValue
                        NombreCorto = TxtNombreCorto.Text.ToUpper.Trim
                        RazonSocial = TxtRazonSocial.Text.ToUpper.Trim
                        RFC = TxtRFC.Text.ToUpper.Trim
                        CURP = TxtCURP.Text.ToUpper.Trim
                        TipoCanal = cmbTipoCanal.SelectedValue
                        listaPrecio = cmbListaPrecio.SelectedValue
                        Responsable = cmbResponsable.SelectedValue
                        CtaContable = TxtCtaContable.Text.Trim.ToUpper
                        Alterno = txtAlterno.Text
                        GLN = TxtGLN.Text.ToUpper.Trim
                        Ramo = iRamo
                        DesglosaIVA = ChkDesglosarIVA.Checked
                        TipoImpuesto = CmbTipo.SelectedValue
                        LCredito = Limite
                        DiasCredito = Dias
                        Contacto = TxtContacto.Text.ToUpper.Trim
                        Tel1 = TxtTel1.Text.ToUpper.Trim
                        Tel2 = TxtTel2.Text.ToUpper.Trim
                        email = TxtMail.Text.Trim
                        Estado = Me.ChkEstado.GetEstado


                        DescuentoDirecto = cmbDirecto.SelectedValue
                        DescuentoPostVenta = cmbPostVenta.SelectedValue

                        ModPOS.Ejecuta("sp_modifica_cliente", _
                                        "@CTEClave", CTEClave, _
                                        "@TPersona", TPersona, _
                                        "@NombreCorto", NombreCorto, _
                                        "@RazonSocial", RazonSocial, _
                                        "@RFC", RFC, _
                                        "@CURP", CURP, _
                                        "@TipoCanal", TipoCanal, _
                                        "@ListaPrecio", listaPrecio, _
                                        "@Responsable", Responsable, _
                                        "@CtaContable", CtaContable, _
                                        "@Alterno", Alterno, _
                                        "@GLN", GLN, _
                                        "@Ramo", Ramo, _
                                        "@Desglosar", DesglosaIVA, _
                                        "@TipoImpuesto", TipoImpuesto, _
                                        "@LCredito", LCredito, _
                                        "@DCredito", DiasCredito, _
                                        "@Contacto", Contacto, _
                                        "@Tel1", Tel1, _
                                        "@Tel2", Tel2, _
                                        "@Email", email, _
                                        "@DescuentoDirecto", DescuentoDirecto, _
                                        "@DescuentoPostVenta", DescuentoPostVenta, _
                                        "@Estado", Estado, _
                                        "@Usuario", ModPOS.UsuarioActual)

                        PaisF = CmbPaisFac.Text.ToUpper.Trim
                        EntidadF = TxtEstadoFac.Text.ToUpper.Trim
                        MnpioF = TxtMunicipioFac.Text.ToUpper.Trim
                        ColoniaF = TxtColoniaFac.Text.ToUpper.Trim
                        CalleF = TxtDomicilioFac.Text.ToUpper.Trim
                        LocalidadF = TxtLocalidadFac.Text.ToUpper.Trim
                        codigoPostalF = TxtCodigoPostalFac.Text.ToUpper.Trim
                        referenciaF = TxtReferenciaFac.Text.ToUpper.Trim
                        noExteriorF = TxtNoExteriorFac.Text.ToUpper.Trim
                        noInteriorF = TxtNoInteriorFac.Text.ToUpper.Trim
                        ZonaVentaF = iZV
                        ZonaRepartoF = iZR

                        ModPOS.Ejecuta("sp_modifica_domiciliocliente", _
                                       "@DCTEClave", DCTEClaveFiscal, _
                                       "@CTEClave", CTEClave, _
                                       "@TDomicilio", 1, _
                                       "@Pais", PaisF, _
                                       "@Entidad", EntidadF, _
                                       "@Municipio", MnpioF, _
                                       "@Colonia", ColoniaF, _
                                       "@Calle", CalleF, _
                                       "@codigoPostal", codigoPostalF, _
                                       "@Localidad", LocalidadF, _
                                       "@referencia", referenciaF, _
                                       "@noExterior", noExteriorF, _
                                       "@noInterior", noInteriorF, _
                                       "@ZonaVenta", ZonaVentaF, _
                                        "@ZonaReparto", ZonaRepartoF, _
                                        "@NombreCorto", NombreCorto, _
                                        "@Consignatario", RazonSocial, _
                                        "@Telefono", Tel1, _
                                       "@Estado", 1, _
                                       "@Usuario", ModPOS.UsuarioActual)






                    End If


                    Dim j As Integer

                    foundRows = dtDomicilios.Select(" Modificado = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        Dim iEstado As Integer
                        For j = 0 To foundRows.GetUpperBound(0)


                            If foundRows(j)("Estado") = "Activo" Then
                                iEstado = 1
                            Else
                                iEstado = 0
                            End If

                            ModPOS.Ejecuta("sp_modifica_domiciliocliente", _
                                          "@DCTEClave", foundRows(j)("ID"), _
                                          "@CTEClave", CTEClave, _
                                          "@TDomicilio", 2, _
                                          "@Pais", foundRows(j)("Pa�s"), _
                                          "@Entidad", foundRows(j)("Entidad"), _
                                          "@Municipio", foundRows(j)("Municipio"), _
                                          "@Colonia", foundRows(j)("Colonia"), _
                                          "@codigoPostal", foundRows(j)("CP"), _
                                          "@Localidad", foundRows(j)("Localidad"), _
                                          "@referencia", foundRows(j)("Ref"), _
                                          "@noExterior", foundRows(j)("noExt"), _
                                          "@noInterior", foundRows(j)("noInt"), _
                                          "@Calle", foundRows(j)("Calle"), _
                                           "@ZonaVenta", foundRows(j)("ZonaVenta"), _
                                        "@ZonaReparto", foundRows(j)("ZonaReparto"), _
                                        "@NombreCorto", foundRows(j)("NombreCorto"), _
                                        "@Consignatario", foundRows(j)("Consignatario"), _
                                        "@Telefono", foundRows(j)("Telefono"), _
                                          "@Estado", iEstado, _
                                          "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    'Clasificaciones

                    foundRows = dtClasificaciones.Select(" Update = 1 and  Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta clasprod
                        For j = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_clasprod", "@Tipo", 1, "@Class", foundRows(j)("CLAClave"), "@Producto", CTEClave, "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If



                    foundRows = dtClasificaciones.Select(" Baja = 1 ")
                    If foundRows.Length <> 0 Then
                        'inserta clasprod
                        For j = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_clasprod", "@Tipo", 1, "@Class", foundRows(j)("CLAClave"), "@Producto", CTEClave)

                        Next
                    End If




                    foundRows = dtDomicilios.Select(" Baja = 1 ")
                    If foundRows.Length <> 0 Then

                        For j = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_domiciliocliente", "@DCTEClave", foundRows(j)("ID"), "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If


                    Dim z As Integer

                    foundRows = dtMetodosPago.Select(" update = 1 and Baja = 0")

                    If foundRows.Length <> 0 Then
                        'actualiza denominaciones

                        For z = 0 To foundRows.GetUpperBound(0)

                            ModPOS.Ejecuta("sp_actualiza_clientepago", _
                            "@MTPClave", foundRows(z)("MTPClave"), _
                            "@CTEClave", CTEClave, _
                            "@MetodoPago", foundRows(z)("MetodoPago"), _
                            "@BNKClave", foundRows(z)("BNKClave"), _
                            "@Referencia", CStr(foundRows(z)("Referencia")).Trim.ToUpper, _
                            "@Preferido", foundRows(z)("Preferido"), _
                            "@Estado", foundRows(z)("TipoEstado"), _
                            "@Baja", foundRows(z)("Baja"), _
                            "@Usuario", ModPOS.UsuarioActual)


                        Next
                    End If

                    foundRows = dtMetodosPago.Select(" Baja = 1 ")

                    If foundRows.Length <> 0 Then
                        'inserta denominaciones

                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_clientepago", _
                            "@MTPClave", foundRows(z)("MTPClave"), _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next

                    End If


                    foundRows = dtDirecto.Select(" Baja = 1 ")
                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_excepcion_descuento", _
                            "@CTEClave", CTEClave, _
                            "@TipoSector", foundRows(z)("TipoSector"), _
                            "@Descuento", foundRows(z)("TipoDescuento"), _
                            "@Tipo", 1)
                        Next
                    End If



                    foundRows = dtDirecto.Select(" Update = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_excepcion_descuento", _
                            "@CTEClave", CTEClave, _
                            "@TipoSector", foundRows(z)("TipoSector"), _
                            "@Descuento", foundRows(z)("TipoDescuento"), _
                            "@Tipo", 1, _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If


                    foundRows = dtPostVenta.Select(" Baja = 1 ")
                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_elimina_excepcion_descuento", _
                            "@CTEClave", CTEClave, _
                            "@TipoSector", foundRows(z)("TipoSector"), _
                            "@Descuento", foundRows(z)("TipoDescuento"), _
                            "@Tipo", 2)
                        Next
                    End If

                    foundRows = dtPostVenta.Select(" Update = 1 and Baja = 0 ")
                    If foundRows.Length <> 0 Then
                        'inserta metodos de pago
                        For z = 0 To foundRows.GetUpperBound(0)
                            ModPOS.Ejecuta("sp_inserta_excepcion_descuento", _
                            "@CTEClave", CTEClave, _
                            "@TipoSector", foundRows(z)("TipoSector"), _
                            "@Descuento", foundRows(z)("TipoDescuento"), _
                            "@Tipo", 2, _
                            "@Usuario", ModPOS.UsuarioActual)
                        Next
                    End If

                    If fromForm = "Factura" Then
                        If Not ModPOS.Factura Is Nothing Then
                            ModPOS.Factura.CargaDatosCliente(CTEClave)
                        End If
                        Me.Close()
                    ElseIf fromForm = "NotaCargo" Then
                        If Not ModPOS.NotaCargo Is Nothing Then
                            ModPOS.NotaCargo.CargaDatosCliente(CTEClave)
                        End If
                        Me.Close()
                    ElseIf fromForm = "Viaje" Then
                        If Not ModPOS.AddCaja Is Nothing Then
                            ModPOS.Viaje.CargaDatosCliente(CTEClave)
                        End If
                        Me.Close()
                    ElseIf fromForm = "Venta" Then
                        If Not ModPOS.Venta Is Nothing Then
                            ModPOS.Venta.cambiaCliente(CTEClave)
                        End If
                        Me.Close()
                    ElseIf fromForm <> "" Then
                        Me.Close()

                    Else
                        Close()
                    End If

            End Select

        Else
            Beep()
            MessageBox.Show("�Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Function validaForm() As Boolean
        Dim i As Integer = 0

        If Me.CmbTipoPersona.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(0))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtClave.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(1))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 20 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 20)
        End If

        If Me.TxtRazonSocial.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(2))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtRazonSocial.Text.Length > 200 Then
            Me.TxtRazonSocial.Text = Me.TxtRazonSocial.Text.Substring(0, 200)
        End If

        If Me.TxtRFC.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(3))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtRFC.Text.Length > 32 Then
            Me.TxtRFC.Text = Me.TxtRFC.Text.Substring(0, 32)
        End If

        If Me.cmbTipoCanal.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(4))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbListaPrecio.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(5))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbResponsable.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(6))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.CmbTipo.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(7))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.cmbDirecto.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(25))
            reloj.Enabled = True
            reloj.Start()
        End If
        If Me.cmbPostVenta.SelectedValue Is Nothing Then
            i += 1
            reloj = New parpadea(Me.alerta(26))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtLimite.Text = "" Then
            dLimite = 0
        Else
            dLimite = CDbl(TxtLimite.Text)
        End If

        If dLimite < 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(8))
            reloj.Enabled = True
            reloj.Start()
        End If

        If TxtDiasCredito.Text = "" Then
            iDias = 0
        Else
            iDias = CInt(TxtDiasCredito.Text)
        End If

        If dLimite > 0 AndAlso iDias <= 0 Then
            i += 1
            reloj = New parpadea(Me.alerta(9))
            reloj.Enabled = True
            reloj.Start()
        End If



        If Me.CmbPaisFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(10))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtEstadoFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(11))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtMunicipioFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(12))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtColoniaFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(13))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtDomicilioFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(14))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 128 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 128)
        End If

        If Me.TxtCodigoPostalFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(15))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtNoExteriorFac.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(16))
            reloj.Enabled = True
            reloj.Start()
        End If



        If i > 0 Then
            Return False
        ElseIf Me.Padre = "Agregar" Then
            Dim Con As String = ModPOS.BDConexion

            If ModPOS.SiExite(Con, "sp_valida_PK", "@tabla", "Cliente", "@clave", Me.TxtClave.Text.ToUpper.Trim, "@COMClave", ModPOS.CompanyActual) > 0 Then
                Beep()
                MessageBox.Show("La Referencia que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                reloj = New parpadea(Me.alerta(0))
                reloj.Enabled = True
                reloj.Start()
                Return False
            Else
                While i < Me.alerta.Length
                    Me.alerta(i).Visible = False
                    i += 1
                End While
                Return True
            End If
        Else
            While i < Me.alerta.Length
                Me.alerta(i).Visible = False
                i += 1
            End While
            Return True
        End If

    End Function

#End Region

#Region "Domicilio"

    'DomicilioCliente, Tipo= 2 = Punto de Entrega

    Public Sub cargaPostVenta()
        If Padre = "Modificar" Then

            dtPostVenta = ModPOS.Recupera_Tabla("sp_muestra_descuentopostventa", "@CTEClave", CTEClave)

        Else
            dtPostVenta = ModPOS.CrearTabla("Descuento", _
               "Sector", "System.String", _
               "Descuento", "System.String", _
               "TipoSector", "System.Int32", _
               "TipoDescuento", "System.Int32", _
               "Update", "System.Int32", _
               "Baja", "System.Int32")
        End If

    End Sub

    Public Sub cargaDirecto()
        If Padre = "Modificar" Then

            dtDirecto = ModPOS.Recupera_Tabla("sp_muestra_descuentodirecto", "@CTEClave", CTEClave)

        Else
            dtDirecto = ModPOS.CrearTabla("Descuento", _
               "Sector", "System.String", _
               "Descuento", "System.String", _
               "TipoSector", "System.Int32", _
               "TipoDescuento", "System.Int32", _
               "Update", "System.Int32", _
               "Baja", "System.Int32")
        End If

    End Sub


    Public Sub cargaClasificaciones()
        If Padre = "Modificar" Then

            dtClasificaciones = ModPOS.Recupera_Tabla("sp_muestra_clascte", "@CTEClave", CTEClave)

        Else

            dtClasificaciones = ModPOS.CrearTabla("ClasCte", _
               "CLAClave", "System.Int32", _
               "Grupo", "System.String", _
               "Referencia", "System.String", _
               "Nombre", "System.String", _
               "TGrupo", "System.Int32", _
               "Update", "System.Int32", _
               "Baja", "System.Int32")

        End If

        GridClasificaciones.DataSource = dtClasificaciones
        GridClasificaciones.RetrieveStructure(True)
        GridClasificaciones.GroupByBoxVisible = False
        GridClasificaciones.RootTable.Columns("CLAClave").Visible = False
        GridClasificaciones.RootTable.Columns("TGrupo").Visible = False
        GridClasificaciones.RootTable.Columns("Update").Visible = False
        GridClasificaciones.RootTable.Columns("Baja").Visible = False

        Dim fc0 As Janus.Windows.GridEX.GridEXFormatCondition
        fc0 = New Janus.Windows.GridEX.GridEXFormatCondition(GridClasificaciones.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc0.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc0.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridClasificaciones.RootTable.FormatConditions.Add(fc0)
    End Sub


    Public Sub cargaPuntosdeEntrega()
        If Padre = "Modificar" Then
            dtDomicilios = ModPOS.Recupera_Tabla("sp_muestra_domicilios", "@CTEClave", CTEClave)

        Else

            dtDomicilios = ModPOS.CrearTabla("DomicilioCliente", _
                     "ID", "System.String", _
                     "Domicilio", "System.String", _
                     "Calle", "System.String", _
                     "noExt", "System.String", _
                     "noInt", "System.String", _
                     "Ref", "System.String", _
                     "Colonia", "System.String", _
                     "CP", "System.String", _
                     "Municipio", "System.String", _
                     "Localidad", "System.String", _
                     "Entidad", "System.String", _
                     "Pais", "System.String", _
                     "ZonaVenta", "System.Int32", _
                     "ZonaReparto", "System.Int32", _
                    "NombreCorto", "System.String", _
                    "Consignatario", "System.String", _
                    "Telefono", "System.String", _
                     "Estado", "System.String", _
                     "Baja", "System.Int32", _
                     "Modificado", "System.Int32")

        End If

        GridDomicilios.DataSource = dtDomicilios
        GridDomicilios.RetrieveStructure(True)
        GridDomicilios.GroupByBoxVisible = False
        GridDomicilios.RootTable.Columns("ID").Visible = False
        GridDomicilios.RootTable.Columns("Calle").Visible = False
        GridDomicilios.RootTable.Columns("noExt").Visible = False
        GridDomicilios.RootTable.Columns("noInt").Visible = False
        GridDomicilios.RootTable.Columns("Ref").Visible = False
        GridDomicilios.RootTable.Columns("Colonia").Visible = False
        GridDomicilios.RootTable.Columns("CP").Visible = False
        GridDomicilios.RootTable.Columns("Municipio").Visible = False
        GridDomicilios.RootTable.Columns("Localidad").Visible = False
        GridDomicilios.RootTable.Columns("Entidad").Visible = False
        GridDomicilios.RootTable.Columns("Pais").Visible = False
        GridDomicilios.RootTable.Columns("Baja").Visible = False
        GridDomicilios.RootTable.Columns("ZonaVenta").Visible = False
        GridDomicilios.RootTable.Columns("ZonaReparto").Visible = False
        GridDomicilios.RootTable.Columns("Modificado").Visible = False

        Dim fc As Janus.Windows.GridEX.GridEXFormatCondition
        fc = New Janus.Windows.GridEX.GridEXFormatCondition(GridDomicilios.RootTable.Columns("Estado"), Janus.Windows.GridEX.ConditionOperator.NotEqual, "Activo")

        fc.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridDomicilios.RootTable.FormatConditions.Add(fc)

        Dim fc1 As Janus.Windows.GridEX.GridEXFormatCondition
        fc1 = New Janus.Windows.GridEX.GridEXFormatCondition(GridDomicilios.RootTable.Columns("Baja"), Janus.Windows.GridEX.ConditionOperator.Equal, 1)

        fc1.FormatStyle.FontStrikeout = Janus.Windows.GridEX.TriState.True
        fc1.FormatStyle.ForeColor = System.Drawing.SystemColors.GrayText
        GridDomicilios.RootTable.FormatConditions.Add(fc1)



    End Sub

    Public Sub reiniciaPuntodeEntrega(ByVal dPadre As String)
        Pais = ""
        Nombre = ""
        Consignatario = ""
        TelDomicilio = ""
        TDomicilio = 0
        Colonia = ""
        Entidad = ""
        Mnpio = ""
        Calle = ""
        Localidad = ""
        codigoPostal = ""
        referencia = ""
        noInterior = ""
        noExterior = ""
        Estado = 1

        TxtNombre.Text = Nombre
        TxtConsignatario.Text = Consignatario
        txtTelDomicilio.Text = TelDomicilio
        TxtCalle.Text = Calle
        TxtEstado.Text = Entidad
        TxtMunicipio.Text = Mnpio
        TxtColonia.Text = Colonia
        TxtLocalidad.Text = Localidad
        TxtCodigoPostal.Text = codigoPostal
        TxtReferencia.Text = referencia
        TxtNoInterior.Text = noInterior
        TxtNoExterior.Text = noExterior
        ChkEstado.Estado = Estado

        If dPadre <> "Agregar" Then
            DomicilioPadre = "Agregar"

            BtnDelDomi.Enabled = False
            ChkDomicilio.Enabled = False
            ChkDomicilio.Enabled = 1
        End If

    End Sub


    Public Sub AddDomicilio(ByVal ID As String, ByVal sNombre As String, ByVal sConsignatario As String, ByVal sTelDomicllio As String, ByVal sColonia As String, ByVal sCalle As String, ByVal snoExt As String, ByVal snoInt As String, ByVal sRef As String, ByVal sCP As String, ByVal sMunicipio As String, ByVal sLocalidad As String, ByVal sEntidad As String, ByVal sPais As String, ByVal iZonaVta As Integer, ByVal iZonaRep As Integer, ByVal sEstado As String)

        Dim foundRows() As Data.DataRow
        foundRows = dtDomicilios.Select("ID Like '" & ID & "'")

        If foundRows.Length = 0 Then
            Dim row1 As DataRow
            row1 = dtDomicilios.NewRow()
            'declara el nombre de la fila

            row1.Item("ID") = ID
            row1.Item("NombreCorto") = sNombre
            row1.Item("Consignatario") = sConsignatario
            row1.Item("Telefono") = sTelDomicllio

            row1.Item("Domicilio") = sCalle & " " & snoExt & " " & snoInt & ", " & sColonia & ", CP:" & sCP & ", " & sMunicipio & ", " & sEntidad

            row1.Item("Calle") = sCalle
            row1.Item("noExt") = snoExt
            row1.Item("noInt") = snoInt
            row1.Item("Ref") = sRef
            row1.Item("Colonia") = sColonia
            row1.Item("CP") = sCP
            row1.Item("Municipio") = sMunicipio
            row1.Item("Localidad") = sLocalidad
            row1.Item("Entidad") = sEntidad
            row1.Item("Pa�s") = sPais
            row1.Item("Estado") = sEstado
            row1.Item("ZonaVenta") = iZonaVta
            row1.Item("ZonaReparto") = iZonaRep


            row1.Item("Baja") = 0
            row1.Item("Modificado") = 1

            dtDomicilios.Rows.Add(row1)
            'agrega la fila completo a la tabla


        Else
            Beep()
            MessageBox.Show("�El domicilio que intenta agregar ya existe para el cliente actual!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub


    Public Sub UpdDomicilio(ByVal ID As String, ByVal sNombre As String, ByVal sConsignatario As String, ByVal sTelDomicllio As String, ByVal sColonia As String, ByVal sCalle As String, ByVal snoExt As String, ByVal snoInt As String, ByVal sRef As String, ByVal sCP As String, ByVal sMunicipio As String, ByVal sLocalidad As String, ByVal sEntidad As String, ByVal sPais As String, ByVal iZonaVta As Integer, ByVal iZonaRep As Integer, ByVal sEstado As String)
        Dim foundRows() As Data.DataRow
        foundRows = dtDomicilios.Select("ID Like '" & ID & "'")

        If foundRows.Length = 1 Then
            foundRows(0)("Domiclio") = sCalle & " " & snoExt & " " & snoInt & ", " & sColonia & ", CP:" & sCP & ", " & sMunicipio & ", " & sEntidad
            foundRows(0)("NombreCorto") = sNombre
            foundRows(0)("Consignatario") = sConsignatario
            foundRows(0)("Telefono") = sTelDomicllio
            foundRows(0)("Calle") = sCalle
            foundRows(0)("noExt") = snoExt
            foundRows(0)("noInt") = snoInt
            foundRows(0)("Ref") = sRef
            foundRows(0)("Colonia") = sColonia
            foundRows(0)("CP") = sCP
            foundRows(0)("Municipio") = sMunicipio
            foundRows(0)("Localidad") = sLocalidad
            foundRows(0)("Entidad") = sEntidad
            foundRows(0)("Pa�s") = sPais
            foundRows(0)("ZonaVenta") = iZonaVta
            foundRows(0)("ZonaReparto") = iZonaRep
            foundRows(0)("Estado") = sEstado
            foundRows(0)("Modificado") = 1
        End If
    End Sub


    Private Function validaDomicilio() As Boolean
        Dim i As Integer = 0

        If Me.TxtConsignatario.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(17))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtConsignatario.Text.Length > 200 Then
            Me.TxtConsignatario.Text = Me.TxtConsignatario.Text.Substring(0, 200)
        End If


        If Me.cmbPais.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(18))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtEstado.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(19))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtMunicipio.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(20))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtColonia.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(21))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtCodigoPostal.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(22))
            reloj.Enabled = True
            reloj.Start()
        End If

        If Me.TxtCalle.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(23))
            reloj.Enabled = True
            reloj.Start()
        ElseIf Me.TxtClave.Text.Length > 128 Then
            Me.TxtClave.Text = Me.TxtClave.Text.Substring(0, 128)
        End If

        If Me.TxtNoExterior.Text = "" Then
            i += 1
            reloj = New parpadea(Me.alerta(24))
            reloj.Enabled = True
            reloj.Start()
        End If


        If i > 0 Then
            Return False
        Else

            Dim Result As Integer
            Dim dt As DataTable

            dt = ModPOS.Recupera_Tabla("sp_valida_domiciliocliente", _
            "@CTEClave", CTEClave, _
            "@DCTEClave", DCTEClave, _
            "@TDomicilio", 2, _
            "@Pais", cmbPais.Text.ToUpper.Trim, _
            "@Entidad", TxtEstado.Text.ToUpper.Trim, _
            "@Municipio", TxtMunicipio.Text.ToUpper.Trim, _
            "@Colonia", TxtColonia.Text.ToUpper.Trim, _
            "@Calle", TxtCalle.Text.ToUpper.Trim, _
            "@Localidad", TxtLocalidad.Text.ToUpper.Trim, _
            "@Referencia", TxtReferencia.Text.ToUpper.Trim, _
            "@codigoPostal", TxtCodigoPostal.Text.ToUpper.Trim, _
            "@noExterior", TxtNoExterior.Text.ToUpper.Trim, _
            "@noInterior", TxtNoInterior.Text.Trim, _
            "@Estado", ChkDomicilio.GetEstado)

            Result = dt.Rows(0)("Resultado")
            dt.Dispose()

            Select Case Result
                Case 0
                    While i < Me.alerta.Length
                        Me.alerta(i).Visible = False
                        i += 1
                    End While
                    Return True

                Case 1, 3, 5
                    MessageBox.Show("Solo puede existir un domicilio Fiscal activo en el sistema, el domicilio existente tiene que eliminarlo o cambiar su estado a inactivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Case 2, 4
                    MessageBox.Show("El domicilio que intenta agregar ya existe en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
            End Select

        End If

    End Function

    Private Sub GridDomicilios_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridDomicilios.DoubleClick

        If Not GridDomicilios.GetValue(0) Is Nothing Then

            Me.DCTEClave = GridDomicilios.GetValue("ID")
            Me.sDomicilio = GridDomicilios.GetValue("Calle") & " " & GridDomicilios.GetValue("noExt")
        Else
            Me.DCTEClave = ""
            Me.sDomicilio = ""

        End If

        If DCTEClave <> "" Then

            TDomicilio = 2
            Nombre = GridDomicilios.GetValue("NombreCorto")
            Consignatario = GridDomicilios.GetValue("Consignatario")
            TelDomicilio = GridDomicilios.GetValue("Telefono")
            Pais = GridDomicilios.GetValue("Pa�s")
            Entidad = GridDomicilios.GetValue("Entidad")
            Mnpio = GridDomicilios.GetValue("Municipio")
            Colonia = GridDomicilios.GetValue("Colonia")
            Localidad = GridDomicilios.GetValue("Localidad")
            referencia = GridDomicilios.GetValue("Ref")
            noExterior = GridDomicilios.GetValue("noExt")
            noInterior = GridDomicilios.GetValue("noInt")
            codigoPostal = GridDomicilios.GetValue("CP")
            Calle = GridDomicilios.GetValue("Calle")
            ZonaVenta = GridDomicilios.GetValue("ZonaVenta")
            ZonaReparto = GridDomicilios.GetValue("ZonaReparto")

            If GridDomicilios.GetValue("Estado") = "Activo" Then
                DomicilioEstado = 1
            Else
                DomicilioEstado = 0
            End If


            TxtNombre.Text = Nombre
            TxtConsignatario.Text = Consignatario
            txtTelDomicilio.Text = TelDomicilio
            cmbPais.Text = Pais
            TxtEstado.Text = Entidad
            TxtMunicipio.Text = Mnpio
            TxtColonia.Text = Colonia
            TxtLocalidad.Text = Localidad
            TxtCodigoPostal.Text = codigoPostal
            TxtReferencia.Text = referencia
            TxtNoInterior.Text = noInterior
            TxtNoExterior.Text = noExterior
            TxtCalle.Text = Calle
            ChkDomicilio.Estado = DomicilioEstado
            cmbZonaVtap.SelectedValue = ZonaVenta
            cmbZonaRep.SelectedValue = ZonaReparto

            DomicilioPadre = "Modificar"
            BtnDelDomi.Enabled = True
            ChkDomicilio.Enabled = True
        End If

    End Sub

    Private Sub cmbPais_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPais.SelectedIndexChanged
        If cargado = True AndAlso Not cmbPais.SelectedValue Is Nothing Then
            Dim dtEstado As DataTable

            dtEstado = ModPOS.Recupera_Tabla("sp_filtra_estado", "@Pais", cmbPais.SelectedValue)
            If dtEstado.Rows.Count > 0 Then
                ReDim aEstado(dtEstado.Rows.Count - 1)

                For i As Integer = 0 To dtEstado.Rows.Count - 1
                    aEstado(i) = dtEstado.Rows(i)("d_estado")
                Next

                Me.TxtEstado.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Me.TxtEstado.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.TxtEstado.AutoCompleteCustomSource.AddRange(aEstado)

                dtEstado.Dispose()
            End If

        End If

    End Sub

    Private Sub UiTab1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Janus.Windows.UI.Tab.TabEventArgs) Handles UiTab1.SelectedTabChanged
        Select Case e.Page.Name

            Case "UiTabSaldos"
                ModPOS.ActualizaGrid(False, Me.GridSaldos, "sp_muestra_saldos", "@CTEClave", CTEClave)

        End Select

    End Sub

    Private Sub BtnAceptarDomi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptarDomi.Click
        If validaDomicilio() Then
            Select Case Me.DomicilioPadre
                Case "Agregar"

                    DCTEClave = ModPOS.obtenerLlave
                    TDomicilio = 2
                    Nombre = TxtNombre.Text
                    Consignatario = TxtConsignatario.Text
                    TelDomicilio = txtTelDomicilio.Text
                    Pais = cmbPais.Text
                    Entidad = TxtEstado.Text
                    Mnpio = TxtMunicipio.Text
                    Colonia = TxtColonia.Text
                    Calle = TxtCalle.Text.ToUpper.Trim
                    Localidad = TxtLocalidad.Text.ToUpper.Trim
                    codigoPostal = TxtCodigoPostal.Text.ToUpper.Trim
                    referencia = TxtReferencia.Text.ToUpper.Trim
                    noExterior = TxtNoExterior.Text.ToUpper.Trim
                    noInterior = TxtNoInterior.Text.ToUpper.Trim

                    If Not cmbZonaVtap.SelectedValue Is Nothing Then
                        ZonaVenta = cmbZonaVtap.SelectedValue
                    Else
                        ZonaVenta = 0
                    End If


                    If Not cmbZonaRep.SelectedValue Is Nothing Then
                        ZonaReparto = cmbZonaRep.SelectedValue
                    Else
                        ZonaReparto = 0
                    End If


                    Dim sEstado As String
                    If Me.ChkDomicilio.GetEstado = 1 Then
                        sEstado = "Activo"
                    Else
                        sEstado = "Inactivo"
                    End If



                    AddDomicilio(DCTEClave, Nombre, Consignatario, TelDomicilio, Colonia, Calle, noExterior, noInterior, referencia, codigoPostal, Mnpio, Localidad, Entidad, Pais, ZonaVenta, ZonaReparto, sEstado)

                    reiniciaPuntodeEntrega(DomicilioPadre)

                Case "Modificar"

                    Dim iZV, iZR As Integer
                    If Not cmbZonaVtap.SelectedValue Is Nothing Then
                        iZV = cmbZonaVtap.SelectedValue
                    Else
                        iZV = 0
                    End If


                    If Not cmbZonaRep.SelectedValue Is Nothing Then
                        iZR = cmbZonaRep.SelectedValue
                    Else
                        iZR = 0
                    End If


                    If Not ( _
                    Nombre = TxtNombre.Text AndAlso _
                    Consignatario = TxtConsignatario.Text AndAlso _
                    TelDomicilio = txtTelDomicilio.Text AndAlso _
                    Pais = cmbPais.Text AndAlso _
                    Entidad = TxtEstado.Text AndAlso _
                    Mnpio = TxtMunicipio.Text AndAlso _
                    Colonia = TxtColonia.Text AndAlso _
                    Calle = TxtCalle.Text.ToUpper.Trim AndAlso _
                    Localidad = TxtLocalidad.Text.ToUpper.Trim AndAlso _
                    codigoPostal = TxtCodigoPostal.Text.ToUpper.Trim AndAlso _
                    referencia = TxtReferencia.Text.ToUpper.Trim AndAlso _
                    noExterior = TxtNoExterior.Text.ToUpper.Trim AndAlso _
                    noInterior = TxtNoInterior.Text.ToUpper.Trim AndAlso _
                    ZonaVenta = iZV AndAlso _
                    ZonaReparto = iZR AndAlso _
                    DomicilioEstado = Me.ChkDomicilio.GetEstado) Then


                        TDomicilio = 2
                        Nombre = TxtNombre.Text
                        Consignatario = TxtConsignatario.Text
                        TelDomicilio = txtTelDomicilio.Text
                        Pais = cmbPais.Text
                        Entidad = TxtEstado.Text
                        Mnpio = TxtMunicipio.Text
                        Colonia = TxtColonia.Text
                        Calle = TxtCalle.Text.ToUpper.Trim
                        Localidad = TxtLocalidad.Text.ToUpper.Trim
                        codigoPostal = TxtCodigoPostal.Text.ToUpper.Trim
                        referencia = TxtReferencia.Text.ToUpper.Trim
                        noExterior = TxtNoExterior.Text.ToUpper.Trim
                        noInterior = TxtNoInterior.Text.ToUpper.Trim
                        ZonaVenta = iZV
                        ZonaReparto = iZR

                        Dim sEstado As String
                        If Me.ChkDomicilio.GetEstado = 1 Then
                            sEstado = "Activo"
                        Else
                            sEstado = "Inactivo"
                        End If

                        UpdDomicilio(DCTEClave, Nombre, Consignatario, TelDomicilio, Colonia, Calle, noExterior, noInterior, referencia, codigoPostal, Mnpio, Localidad, Entidad, Pais, ZonaVenta, ZonaReparto, sEstado)



                    End If

                    reiniciaPuntodeEntrega(DomicilioPadre)


            End Select

        Else
            Beep()
            MessageBox.Show("�Alguno de los datos introducidos no es valido o es requerido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub BtnDelDomi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelDomi.Click
        If DCTEClave <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el domicilio seleccionado  :" & sDomicilio, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtDomicilios.Select("ID Like '" & DCTEClave & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If

                    reiniciaPuntodeEntrega(DomicilioPadre)



            End Select
        End If

    End Sub

#End Region

    Private Sub CmbPaisFac_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbPaisFac.SelectedIndexChanged
        If cargado = True AndAlso Not CmbPaisFac.SelectedValue Is Nothing Then
            Dim dtEstado As DataTable

            dtEstado = ModPOS.Recupera_Tabla("sp_filtra_estado", "@Pais", CmbPaisFac.SelectedValue)
            If dtEstado.Rows.Count > 0 Then
                ReDim aEstado(dtEstado.Rows.Count - 1)

                For i As Integer = 0 To dtEstado.Rows.Count - 1
                    aEstado(i) = dtEstado.Rows(i)("d_estado")
                Next

                Me.TxtEstadoFac.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Me.TxtEstadoFac.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.TxtEstadoFac.AutoCompleteCustomSource.AddRange(aEstado)

                dtEstado.Dispose()
            End If

        End If

    End Sub

    'Private Sub CmbEstadoFac_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If cargado = True AndAlso Not CmbEstadoFac.SelectedValue Is Nothing Then
    '        With Me.CmbMunicipioFac
    '            .Conexion = Cnx
    '            .ProcedimientoAlmacenado = "sp_filtra_mnpio"
    '            .NombreParametro1 = "Estado"
    '            .Parametro1 = CmbEstadoFac.SelectedValue
    '            .llenar()
    '        End With
    '    End If

    'End Sub

    'Private Sub CmbMunicipioFac_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If cargado = True AndAlso Not CmbMunicipioFac.SelectedValue Is Nothing AndAlso Not CmbEstadoFac.SelectedValue Is Nothing Then
    '        With Me.CmbColoniaFac
    '            .Conexion = Cnx
    '            .ProcedimientoAlmacenado = "sp_filtra_colonia"
    '            .NombreParametro1 = "Estado"
    '            .Parametro1 = CmbEstadoFac.SelectedValue
    '            .NombreParametro2 = "Municipio"
    '            .Parametro2 = CmbMunicipioFac.SelectedValue
    '            .llenar()
    '        End With
    '    End If

    'End Sub

    Private Sub Ctrl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClave.KeyDown, TxtNombreCorto.KeyDown, CmbTipoPersona.KeyDown, TxtRazonSocial.KeyDown, TxtRFC.KeyDown, TxtLimite.KeyDown, cmbListaPrecio.KeyDown, TxtDiasCredito.KeyDown, CmbPaisFac.KeyDown, TxtDomicilioFac.KeyDown, TxtContacto.KeyDown, TxtTel1.KeyDown, TxtTel2.KeyDown, TxtMail.KeyDown, TxtEstadoFac.KeyDown, TxtMunicipioFac.KeyDown, TxtColoniaFac.KeyDown, TxtLocalidadFac.KeyDown, TxtCodigoPostalFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub BtnKey_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKey.Click
        If Not cmbResponsable.SelectedValue Is Nothing Then
            Dim dt As DataTable
            dt = ModPOS.Recupera_Tabla("sp_recupera_comparam", "@PARClave", "Digitos", "@COMClave", ModPOS.CompanyActual)
            Dim len As Integer = CInt(dt.Rows(0)("Valor"))
            dt.Dispose()

            dt = ModPOS.Recupera_Tabla("sp_calcula_cteclave", "@Responsable", cmbResponsable.SelectedValue, "@len", len, "@COMClave", ModPOS.CompanyActual)

            TxtClave.Text = dt.Rows(0)("Clave")
            dt.Dispose()

            SendKeys.Send("{TAB}")
        Else
            MessageBox.Show("Debe asignar un responsable de la cuenta de cliente", "Importante", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub reinicializa()

        CTEClave = ""
        DCTEClaveFiscal = ""
        Clave = ""
        FechaReg = DateTime.Today
        NombreCorto = ""
        RazonSocial = ""
        TPersona = 1
        RFC = ""
        LCredito = 0
        Saldo = 0
        Contacto = ""
        Tel1 = ""
        Tel2 = ""
        email = ""
        Estado = 1
        CreditoDisponible = 0
        TDomicilio = 1
        Responsable = 0
        TipoImpuesto = 1

        MnpioF = ""
        ColoniaF = ""
        CalleF = ""
        LocalidadF = ""
        codigoPostalF = ""
        referenciaF = ""
        noInteriorF = ""
        noExteriorF = ""

        DiasCredito = 0
        DesglosaIVA = False

        TxtClave.Text = Clave
        TxtFechaRegistro.Text = FechaReg.ToString("MMMM dd,yyyy")
        TxtNombreCorto.Text = NombreCorto
        TxtRazonSocial.Text = RazonSocial
        CmbTipoPersona.SelectedValue = TPersona
        TxtRFC.Text = RFC
        TxtLimite.Text = CStr(LCredito)
        NumSaldo.Text = CStr(Saldo)
        NumDisponible.Text = CStr(CreditoDisponible)
        TxtContacto.Text = Contacto
        TxtTel1.Text = Tel1
        TxtTel2.Text = Tel2
        TxtMail.Text = email
        ChkEstado.Estado = Estado
        TxtDiasCredito.Text = CInt(DiasCredito)
        ChkDesglosarIVA.Checked = DesglosaIVA
        cmbResponsable.SelectedValue = Responsable
        CmbTipo.SelectedValue = TipoImpuesto

        TxtMunicipioFac.Text = MnpioF
        TxtColoniaFac.Text = ColoniaF
        TxtDomicilioFac.Text = CalleF
        TxtLocalidadFac.Text = LocalidadF
        TxtCodigoPostalFac.Text = codigoPostalF
        TxtReferenciaFac.Text = referenciaF
        TxtNoInteriorFac.Text = noInteriorF
        TxtNoExteriorFac.Text = noExteriorF

        cmbResponsable.SelectedValue = Responsable

        TxtClave.Focus()
        Me.Panel1.VerticalScroll.Value = 0


        If MaxCredito = 0 OrElse Me.LCredito > MaxCredito Then
            TxtLimite.Enabled = False
            TxtDiasCredito.Enabled = False
        Else
            TxtLimite.Enabled = True
            TxtDiasCredito.Enabled = True
        End If

        Me.cargaMetodosPago()
        Me.cargaPuntosdeEntrega()
        Me.cargaClasificaciones()
        Me.reiniciaPuntodeEntrega("Modificar")
    End Sub




    'Private Sub CmbColoniaFac_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If cargado = True AndAlso Not CmbColoniaFac.SelectedValue Is Nothing Then
    '        TxtCodigoPostalFac.Text = CmbColoniaFac.SelectedValue
    '    End If
    'End Sub





    Private Sub TxtEstadoFac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEstadoFac.LostFocus
        If TxtEstadoFac.Text <> "" AndAlso TxtEstadoFac.Text <> EntidadF Then
            Dim dtMnpio As DataTable
            dtMnpio = ModPOS.Recupera_Tabla("sp_recupera_mnpio", "@Estado", TxtEstadoFac.Text.Trim.ToUpper)
            If dtMnpio.Rows.Count > 0 Then
                ReDim aMnpio(dtMnpio.Rows.Count - 1)
                For i As Integer = 0 To dtMnpio.Rows.Count - 1
                    aMnpio(i) = dtMnpio.Rows(i)("d_mnpio")
                Next
                Me.TxtMunicipioFac.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Me.TxtMunicipioFac.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.TxtMunicipioFac.AutoCompleteCustomSource.AddRange(aMnpio)
                dtMnpio.Dispose()
            End If
        End If
    End Sub

    Private Sub TxtMunicipioFac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMunicipioFac.LostFocus
        If TxtEstadoFac.Text <> "" AndAlso TxtMunicipioFac.Text <> "" AndAlso TxtMunicipioFac.Text <> MnpioF Then
            Dim dtColonia As DataTable
            dtColonia = ModPOS.Recupera_Tabla("sp_recupera_colonia", "@Estado", TxtEstadoFac.Text.ToUpper.Trim, "@Municipio", TxtMunicipioFac.Text.Trim.ToUpper)
            If dtColonia.Rows.Count > 0 Then
                ReDim aColonia(dtColonia.Rows.Count - 1)
                For i As Integer = 0 To dtColonia.Rows.Count - 1
                    aColonia(i) = dtColonia.Rows(i)("Nombre")
                Next
                Me.TxtColoniaFac.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Me.TxtColoniaFac.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.TxtColoniaFac.AutoCompleteCustomSource.AddRange(aColonia)
                dtColonia.Dispose()
            End If
            If TxtLocalidadFac.Text = "" Then
                Me.TxtLocalidadFac.Text = TxtMunicipioFac.Text
            End If
        End If
    End Sub

    Private Sub TxtColoniaFac_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtColoniaFac.LostFocus
        If TxtColoniaFac.Text <> "" AndAlso TxtColoniaFac.Text <> ColoniaF AndAlso TxtEstadoFac.Text <> "" AndAlso TxtMunicipioFac.Text <> "" AndAlso TxtMunicipioFac.Text <> MnpioF Then
            Dim dtCP As DataTable
            dtCP = ModPOS.Recupera_Tabla("sp_recupera_cp", "@Estado", TxtEstadoFac.Text.ToUpper.Trim, "@Municipio", TxtMunicipioFac.Text.Trim.ToUpper, "@Colonia", TxtColoniaFac.Text.Trim.ToUpper)
            If dtCP.Rows.Count > 0 Then
                Me.TxtCodigoPostalFac.Text = dtCP.Rows(0)("codigo_postal")
                dtCP.Dispose()
            End If
        End If
    End Sub

    Private Sub CmbTipoPersona_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbTipoPersona.SelectedIndexChanged
        If cargado = True AndAlso CmbTipoPersona.SelectedIndex = 1 Then
            TxtRFC.Mask = "&&&000000aaa" 'Persona Moral
        Else
            TxtRFC.Mask = "&&&&000000aaa" 'Persona Fisica
        End If
    End Sub


    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        Dim a As New FrmAddMetodoPago
        a.Padre = "Agregar"
        a.ShowDialog()
    End Sub

    Private Sub BtnModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModifica.Click
        If sMetodoPago <> "" Then
            Dim a As New FrmAddMetodoPago
            a.Padre = "Modificar"
            a.MTPClave = sMetodoPago
            a.MetodoPago = Me.GridMetodos.GetValue("MetodoPago")
            a.BNKClave = GridMetodos.GetValue("BNKClave")
            a.Referencia = GridMetodos.GetValue("Referencia")
            a.Estado = GridMetodos.GetValue("TipoEstado")
            a.Preferido = GridMetodos.GetValue("Preferido")
            a.ShowDialog()
        End If
    End Sub

    Private Sub BtnElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnElimina.Click
        If Me.sMetodoPago <> "" Then
            Beep()
            Select Case MessageBox.Show("Se eliminara el metodo :" & sTipoMetodo & " " & sBanco & " " & sReferencia, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes

                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtMetodosPago.Select("MTPClave Like '" & sMetodoPago & "'")

                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If

                Case DialogResult.No

            End Select
        End If
    End Sub

    Private Sub GridMetodos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridMetodos.DoubleClick
        If Me.sMetodoPago <> "" Then
            Dim a As New FrmAddMetodoPago
            a.Padre = "Modificar"
            a.MTPClave = sMetodoPago
            a.MetodoPago = GridMetodos.GetValue("MetodoPago")
            a.Referencia = IIf(GridMetodos.GetValue("Referencia").GetType.Name = "DBNull", "", GridMetodos.GetValue("Referencia"))
            a.BNKClave = IIf(GridMetodos.GetValue("BNKClave").GetType.Name = "DBNull", "", GridMetodos.GetValue("BNKClave"))
            a.Estado = GridMetodos.GetValue("TipoEstado")
            a.Preferido = IIf(GridMetodos.GetValue("Preferido") = True, 1, 0)
            a.ShowDialog()
        End If
    End Sub

    Private Sub GridMetodos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridMetodos.SelectionChanged
        If Not Me.GridMetodos.GetValue("MTPClave") Is Nothing Then
            Me.BtnElimina.Enabled = True
            Me.sMetodoPago = GridMetodos.GetValue("MTPClave")
            sReferencia = IIf(GridMetodos.GetValue("Referencia").GetType.Name = "DBNull", "", GridMetodos.GetValue("Referencia"))
            sBanco = IIf(GridMetodos.GetValue("Banco").GetType.Name = "DBNull", "", GridMetodos.GetValue("Banco"))
            Me.sTipoMetodo = GridMetodos.GetValue("Tipo")
            Me.BtnModifica.Enabled = True
        Else
            Me.sMetodoPago = ""
            Me.sReferencia = ""
            Me.sBanco = ""
            Me.sTipoMetodo = ""
            Me.BtnElimina.Enabled = False
            Me.BtnModifica.Enabled = False
        End If
    End Sub


    Private Sub TxtEstado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEstado.LostFocus
        If TxtEstado.Text <> "" AndAlso TxtEstado.Text <> Entidad Then
            Dim dtMnpio As DataTable
            dtMnpio = ModPOS.Recupera_Tabla("sp_recupera_mnpio", "@Estado", TxtEstado.Text.Trim.ToUpper)
            If dtMnpio.Rows.Count > 0 Then
                ReDim aMnpio(dtMnpio.Rows.Count - 1)
                For i As Integer = 0 To dtMnpio.Rows.Count - 1
                    aMnpio(i) = dtMnpio.Rows(i)("d_mnpio")
                Next
                Me.TxtMunicipio.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Me.TxtMunicipio.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.TxtMunicipio.AutoCompleteCustomSource.AddRange(aMnpio)
                dtMnpio.Dispose()
            End If
        End If
    End Sub

    Private Sub TxtMunicipio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMunicipio.LostFocus
        If TxtEstado.Text <> "" AndAlso TxtMunicipio.Text <> "" AndAlso TxtMunicipio.Text <> Mnpio Then
            Dim dtColonia As DataTable
            dtColonia = ModPOS.Recupera_Tabla("sp_recupera_colonia", "@Estado", TxtEstado.Text.ToUpper.Trim, "@Municipio", TxtMunicipio.Text.Trim.ToUpper)
            If dtColonia.Rows.Count > 0 Then
                ReDim aColonia(dtColonia.Rows.Count - 1)
                For i As Integer = 0 To dtColonia.Rows.Count - 1
                    aColonia(i) = dtColonia.Rows(i)("Nombre")
                Next
                Me.TxtColonia.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Me.TxtColonia.AutoCompleteSource = AutoCompleteSource.CustomSource
                Me.TxtColonia.AutoCompleteCustomSource.AddRange(aColonia)
                dtColonia.Dispose()
            End If
            If TxtLocalidad.Text = "" Then
                Me.TxtLocalidad.Text = TxtMunicipio.Text
            End If
        End If

    End Sub

    Private Sub TxtColonia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtColonia.LostFocus
        If TxtColonia.Text <> "" AndAlso TxtColonia.Text <> Colonia AndAlso TxtEstado.Text <> "" AndAlso TxtMunicipio.Text <> "" AndAlso TxtMunicipio.Text <> Mnpio Then
            Dim dtCP As DataTable
            dtCP = ModPOS.Recupera_Tabla("sp_recupera_cp", "@Estado", TxtEstado.Text.ToUpper.Trim, "@Municipio", TxtMunicipio.Text.Trim.ToUpper, "@Colonia", TxtColonia.Text.Trim.ToUpper)
            If dtCP.Rows.Count > 0 Then
                Me.TxtCodigoPostal.Text = dtCP.Rows(0)("codigo_postal")
                dtCP.Dispose()
            End If
        End If
    End Sub

    Private Sub AddClasificaciones(ByVal iCLAClave As Integer, ByVal sGrupo As String, ByVal sReferencia As String, ByVal sNombre As String, ByVal iGrupo As Integer)

        Dim foundRows() As Data.DataRow
        foundRows = dtClasificaciones.Select("TGrupo = " & iGrupo & " and Baja = 0 ")

        If foundRows.Length = 0 Then

            Dim row1 As DataRow
            row1 = dtClasificaciones.NewRow()
            'declara el nombre de la fila
            row1.Item("CLAClave") = iCLAClave
            row1.Item("Grupo") = sGrupo
            row1.Item("Referencia") = sReferencia
            row1.Item("Nombre") = sNombre
            row1.Item("TGrupo") = iGrupo
            row1.Item("Update") = 1
            row1.Item("Baja") = 0

            dtClasificaciones.Rows.Add(row1)
            'agrega la fila completo a la tabla
        Else
            MessageBox.Show("El producto actual ya cuenta con una clasificaci�n de Grupo igual al que desea agregar, elimine la anterior para poder agregar otra", "Informaci�n", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub


    Private Sub recuperaClasificacion(ByVal Clase As Integer)
        Dim dt As DataTable
        dt = ModPOS.Recupera_Tabla("sp_recupera_clase", "@Clase", Clase)

        Dim iGrupo As Integer
        Dim sGrupo As String

        iGrupo = IIf(dt.Rows(0)("TGrupo").GetType.Name = "DBNull", 0, dt.Rows(0)("TGrupo"))

        Dim dtGrupo As DataTable
        dtGrupo = ModPOS.Recupera_Tabla("sp_recupera_valor", "@Tabla", "Clasificacion", "@Campo", "Grupo", "@Valor", iGrupo)

        If dtGrupo.Rows.Count > 0 Then
            sGrupo = dtGrupo.Rows(0)("Descripcion")
        Else
            sGrupo = ""
        End If

        dtGrupo.Dispose()

        Me.AddClasificaciones(CInt(dt.Rows(0)("CLAClave")), sGrupo, dt.Rows(0)("Referencia"), dt.Rows(0)("Nombre"), iGrupo)

        dt.Dispose()




    End Sub


    Private Sub BtnBuscaClasificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscaClasificacion.Click
        Dim a As New MeSearchSimple
        ModPOS.ActualizaGrid(False, a.GridSearch, "sp_filtra_clasificacion", "@TClasificacion", 1, "@TGrupo", 0, "@COMClave", ModPOS.CompanyActual)
        a.GridSearch.RootTable.Columns("CLAClave").Visible = False
        a.numColValor = 0
        a.numColDescripcion = 1
        a.ShowDialog()
        If a.DialogResult = DialogResult.OK Then
            Me.recuperaClasificacion(a.valor)
        End If
        a.Dispose()
    End Sub

    Private Sub btnDelClasificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelClasificacion.Click
        If GridClasificaciones.Row >= 0 Then
            Beep()
            Select Case MessageBox.Show("Se eliminara del cliente actual la clasificaci�n: " & GridClasificaciones.GetValue("Referencia"), "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case DialogResult.Yes
                    Dim foundRows() As System.Data.DataRow
                    foundRows = dtClasificaciones.Select("CLAClave = '" & GridClasificaciones.GetValue("CLAClave") & "'")



                    If foundRows.Length <> 0 Then
                        foundRows(0)("Baja") = 1
                    End If



            End Select
        End If
    End Sub

    Private Sub TxtClasificacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtClasificacion.KeyDown
        If e.KeyCode = Keys.Enter Then

            If TxtClasificacion.Text <> "" Then



                Dim dt As DataTable
                dt = ModPOS.Recupera_Tabla("sp_busca_clasificacion", "@Tipo", 1, "@Grupo", 0, "@Referencia", TxtClasificacion.Text, "@COMClave", ModPOS.CompanyActual)

                If dt.Rows.Count > 0 Then
                    Dim iGrupo As Integer
                    Dim sGrupo As String

                    iGrupo = IIf(dt.Rows(0)("TGrupo").GetType.Name = "DBNull", 0, dt.Rows(0)("TGrupo"))

                    Dim dtGrupo As DataTable
                    dtGrupo = ModPOS.Recupera_Tabla("sp_recupera_valor", "@Tabla", "Clasificacion", "@Campo", "Grupo", "@Valor", iGrupo)

                    If dtGrupo.Rows.Count > 0 Then
                        sGrupo = dtGrupo.Rows(0)("Descripcion")
                    Else
                        sGrupo = ""
                    End If

                    dtGrupo.Dispose()

                    Me.AddClasificaciones(CInt(dt.Rows(0)("CLAClave")), sGrupo, dt.Rows(0)("Referencia"), dt.Rows(0)("Nombre"), iGrupo)

                Else
                    MessageBox.Show("No se encontro clasificaci�n de cliente que coincida con la referencia", "Informaci�n", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                End If
                dt.Dispose()

            End If
        End If
    End Sub


    Private Sub cmbTipoCanal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoCanal.SelectedIndexChanged
        If Not cmbTipoCanal.SelectedValue Is Nothing AndAlso cargado Then
            With Me.cmbListaPrecio
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_listas_canal"
                .NombreParametro1 = "TipoCanal"
                .Parametro1 = cmbTipoCanal.SelectedValue
                .NombreParametro2 = "COMClave"
                .Parametro2 = ModPOS.CompanyActual
                .llenar()
            End With
        End If
    End Sub


    Private Sub btnDirecto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDirecto.Click
        Dim b As New FrmAddExcepcion
        b.Text &= " [Directo]"
        b.dtDescuento = dtDirecto
        b.TipoDescuento = 1
        b.ShowDialog()
        dtDirecto = b.dtDescuento
        b.Dispose()

    End Sub

    Private Sub btnPostventa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPostventa.Click
        Dim b As New FrmAddExcepcion
        b.Text &= " [PostVenta]"
        b.dtDescuento = dtPostVenta
        b.TipoDescuento = 2
        b.ShowDialog()
        dtPostVenta = b.dtDescuento
        b.Dispose()
    End Sub
End Class