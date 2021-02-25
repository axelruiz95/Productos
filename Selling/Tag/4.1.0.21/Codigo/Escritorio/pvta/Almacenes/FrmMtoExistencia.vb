Public Class FrmMtoExistencia
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
    Friend WithEvents GrpClas As System.Windows.Forms.GroupBox
    Friend WithEvents GrpProductos As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancelar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GridProductos As Janus.Windows.GridEX.GridEX
    Friend WithEvents TreeViewClass As System.Windows.Forms.TreeView
    Friend WithEvents TxtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbAlmacen As Selling.StoreCombo
    Friend WithEvents BtnAceptar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnAjustar As Janus.Windows.EditControls.UIButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtUbicacion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GridUbicacion As Janus.Windows.GridEX.GridEX
    Friend WithEvents BtnBuscar As Janus.Windows.EditControls.UIButton
    Friend WithEvents BtnImp As Janus.Windows.EditControls.UIButton
    Friend WithEvents cmbGrupo As Selling.StoreCombo
    Friend WithEvents cmbSucursalO As Selling.StoreCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnStock As Janus.Windows.EditControls.UIButton
    Friend WithEvents CmbCampo As Selling.StoreCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMtoExistencia))
        Me.GrpClas = New System.Windows.Forms.GroupBox()
        Me.cmbGrupo = New Selling.StoreCombo()
        Me.TreeViewClass = New System.Windows.Forms.TreeView()
        Me.GrpProductos = New System.Windows.Forms.GroupBox()
        Me.cmbSucursalO = New Selling.StoreCombo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnBuscar = New Janus.Windows.EditControls.UIButton()
        Me.TxtUbicacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbAlmacen = New Selling.StoreCombo()
        Me.CmbCampo = New Selling.StoreCombo()
        Me.TxtBuscar = New System.Windows.Forms.TextBox()
        Me.GridProductos = New Janus.Windows.GridEX.GridEX()
        Me.BtnCancelar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAceptar = New Janus.Windows.EditControls.UIButton()
        Me.BtnAjustar = New Janus.Windows.EditControls.UIButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BtnStock = New Janus.Windows.EditControls.UIButton()
        Me.BtnImp = New Janus.Windows.EditControls.UIButton()
        Me.GridUbicacion = New Janus.Windows.GridEX.GridEX()
        Me.GrpClas.SuspendLayout()
        Me.GrpProductos.SuspendLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridUbicacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpClas
        '
        Me.GrpClas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpClas.Controls.Add(Me.cmbGrupo)
        Me.GrpClas.Controls.Add(Me.TreeViewClass)
        Me.GrpClas.Location = New System.Drawing.Point(7, 0)
        Me.GrpClas.Name = "GrpClas"
        Me.GrpClas.Size = New System.Drawing.Size(216, 545)
        Me.GrpClas.TabIndex = 1
        Me.GrpClas.TabStop = False
        Me.GrpClas.Text = "Clasificaciones"
        '
        'cmbGrupo
        '
        Me.cmbGrupo.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGrupo.Location = New System.Drawing.Point(8, 15)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(202, 21)
        Me.cmbGrupo.TabIndex = 9
        '
        'TreeViewClass
        '
        Me.TreeViewClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeViewClass.Location = New System.Drawing.Point(7, 39)
        Me.TreeViewClass.Name = "TreeViewClass"
        Me.TreeViewClass.Size = New System.Drawing.Size(203, 499)
        Me.TreeViewClass.TabIndex = 0
        '
        'GrpProductos
        '
        Me.GrpProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpProductos.Controls.Add(Me.cmbSucursalO)
        Me.GrpProductos.Controls.Add(Me.Label3)
        Me.GrpProductos.Controls.Add(Me.BtnBuscar)
        Me.GrpProductos.Controls.Add(Me.TxtUbicacion)
        Me.GrpProductos.Controls.Add(Me.Label2)
        Me.GrpProductos.Controls.Add(Me.Label1)
        Me.GrpProductos.Controls.Add(Me.CmbAlmacen)
        Me.GrpProductos.Controls.Add(Me.CmbCampo)
        Me.GrpProductos.Controls.Add(Me.TxtBuscar)
        Me.GrpProductos.Controls.Add(Me.GridProductos)
        Me.GrpProductos.Location = New System.Drawing.Point(229, 0)
        Me.GrpProductos.Name = "GrpProductos"
        Me.GrpProductos.Size = New System.Drawing.Size(552, 342)
        Me.GrpProductos.TabIndex = 0
        Me.GrpProductos.TabStop = False
        Me.GrpProductos.Text = "Productos"
        '
        'cmbSucursalO
        '
        Me.cmbSucursalO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSucursalO.BackColor = System.Drawing.SystemColors.Window
        Me.cmbSucursalO.Location = New System.Drawing.Point(84, 17)
        Me.cmbSucursalO.Name = "cmbSucursalO"
        Me.cmbSucursalO.Size = New System.Drawing.Size(235, 21)
        Me.cmbSucursalO.TabIndex = 141
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 16)
        Me.Label3.TabIndex = 140
        Me.Label3.Text = "Sucursal"
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageSize = New System.Drawing.Size(32, 32)
        Me.BtnBuscar.Location = New System.Drawing.Point(291, 66)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(27, 22)
        Me.BtnBuscar.TabIndex = 139
        Me.BtnBuscar.ToolTipText = "Busqueda de ubicaci�n"
        Me.BtnBuscar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'TxtUbicacion
        '
        Me.TxtUbicacion.Location = New System.Drawing.Point(84, 67)
        Me.TxtUbicacion.Name = "TxtUbicacion"
        Me.TxtUbicacion.Size = New System.Drawing.Size(201, 20)
        Me.TxtUbicacion.TabIndex = 42
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Ubicaci�n"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(7, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 16)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Almac�n"
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.BackColor = System.Drawing.SystemColors.Window
        Me.CmbAlmacen.Location = New System.Drawing.Point(84, 42)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(235, 21)
        Me.CmbAlmacen.TabIndex = 39
        '
        'CmbCampo
        '
        Me.CmbCampo.BackColor = System.Drawing.SystemColors.Window
        Me.CmbCampo.Location = New System.Drawing.Point(7, 91)
        Me.CmbCampo.Name = "CmbCampo"
        Me.CmbCampo.Size = New System.Drawing.Size(163, 21)
        Me.CmbCampo.TabIndex = 7
        '
        'TxtBuscar
        '
        Me.TxtBuscar.Location = New System.Drawing.Point(173, 91)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(269, 20)
        Me.TxtBuscar.TabIndex = 1
        '
        'GridProductos
        '
        Me.GridProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridProductos.ColumnAutoResize = True
        Me.GridProductos.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridProductos.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridProductos.GroupByBoxVisible = False
        Me.GridProductos.Location = New System.Drawing.Point(7, 118)
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.RecordNavigator = True
        Me.GridProductos.Size = New System.Drawing.Size(537, 218)
        Me.GridProductos.TabIndex = 2
        Me.GridProductos.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridProductos.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.GridProductos.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed
        Me.GridProductos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.Location = New System.Drawing.Point(594, 519)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(90, 37)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "&Salir"
        Me.BtnCancelar.ToolTipText = "Cancelar y cerrar ventana"
        Me.BtnCancelar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAceptar.Icon = CType(resources.GetObject("BtnAceptar.Icon"), System.Drawing.Icon)
        Me.BtnAceptar.Location = New System.Drawing.Point(690, 519)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(90, 37)
        Me.BtnAceptar.TabIndex = 6
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.ToolTipText = "Guarda los cambios realizados al apartado, minimo, maximo y reorden"
        Me.BtnAceptar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnAjustar
        '
        Me.BtnAjustar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAjustar.Image = CType(resources.GetObject("BtnAjustar.Image"), System.Drawing.Image)
        Me.BtnAjustar.Location = New System.Drawing.Point(262, 12)
        Me.BtnAjustar.Name = "BtnAjustar"
        Me.BtnAjustar.Size = New System.Drawing.Size(90, 30)
        Me.BtnAjustar.TabIndex = 7
        Me.BtnAjustar.Text = "&Ajustar"
        Me.BtnAjustar.ToolTipText = "Ajusta la existencia de la ubicaci�n y producto seleccionados"
        Me.BtnAjustar.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnStock)
        Me.GroupBox1.Controls.Add(Me.BtnImp)
        Me.GroupBox1.Controls.Add(Me.GridUbicacion)
        Me.GroupBox1.Controls.Add(Me.BtnAjustar)
        Me.GroupBox1.Location = New System.Drawing.Point(229, 348)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(551, 165)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ubicaciones"
        '
        'BtnStock
        '
        Me.BtnStock.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnStock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnStock.Icon = CType(resources.GetObject("BtnStock.Icon"), System.Drawing.Icon)
        Me.BtnStock.ImageSize = New System.Drawing.Size(28, 28)
        Me.BtnStock.Location = New System.Drawing.Point(358, 12)
        Me.BtnStock.Name = "BtnStock"
        Me.BtnStock.Size = New System.Drawing.Size(90, 30)
        Me.BtnStock.TabIndex = 21
        Me.BtnStock.Text = "Otros"
        Me.BtnStock.ToolTipText = "Muestra la Existencia en otras Sucursales"
        Me.BtnStock.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'BtnImp
        '
        Me.BtnImp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImp.Icon = CType(resources.GetObject("BtnImp.Icon"), System.Drawing.Icon)
        Me.BtnImp.Location = New System.Drawing.Point(454, 12)
        Me.BtnImp.Name = "BtnImp"
        Me.BtnImp.Size = New System.Drawing.Size(90, 30)
        Me.BtnImp.TabIndex = 20
        Me.BtnImp.Text = "Imprimir"
        Me.BtnImp.ToolTipText = "Imprime la existencia de la ubicaci�n seleccionada"
        Me.BtnImp.VisualStyle = Janus.Windows.UI.VisualStyle.Office2007
        '
        'GridUbicacion
        '
        Me.GridUbicacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridUbicacion.ColumnAutoResize = True
        Me.GridUbicacion.ColumnAutoSizeMode = Janus.Windows.GridEX.ColumnAutoSizeMode.DiaplayedCells
        Me.GridUbicacion.ColumnSetNavigation = Janus.Windows.GridEX.ColumnSetNavigation.ColumnSet
        Me.GridUbicacion.GroupByBoxVisible = False
        Me.GridUbicacion.Location = New System.Drawing.Point(7, 45)
        Me.GridUbicacion.Name = "GridUbicacion"
        Me.GridUbicacion.RecordNavigator = True
        Me.GridUbicacion.Size = New System.Drawing.Size(537, 114)
        Me.GridUbicacion.TabIndex = 3
        Me.GridUbicacion.TotalRow = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.GridUbicacion.TotalRowFormatStyle.FontBold = Janus.Windows.GridEX.TriState.[True]
        Me.GridUbicacion.TotalRowPosition = Janus.Windows.GridEX.TotalRowPosition.BottomFixed
        Me.GridUbicacion.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'FrmMtoExistencia
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.GrpProductos)
        Me.Controls.Add(Me.GrpClas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(667, 464)
        Me.Name = "FrmMtoExistencia"
        Me.Text = "Mantenimiento de Existencias"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpClas.ResumeLayout(False)
        Me.GrpProductos.ResumeLayout(False)
        Me.GrpProductos.PerformLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridUbicacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private iAjustaExistencia As Integer = 0

    Private sProdSelected As String
    Private dExistSelected As Double
    Private dApartados, dBloqueados As Double
    Private sClave As String
    Private sNombre As String
    Private dataSetArbol As Data.DataSet
    Private dtExistencia, dtUbicaciones As DataTable
    Private bLoad As Boolean = False
    Private bLoadProductos As Boolean = False
    Private sUBCClave As String = ""
    Private sUbicacion As String = ""
    Private SUCClave As String
    Private TipoConsulta As Integer
    Private sTag As String = ""



    Private Sub actualizaTree(ByVal Tipo As Integer)
        TreeViewClass.Nodes.Clear()
        dataSetArbol = ModPOS.recuperaTabla_DTS("sp_recupera_clasificacion", "Clasificacion", "@Tipo", 3, "Grupo", Tipo, "@COMClave", ModPOS.CompanyActual)
        CrearNodosDelPadre(0, Nothing)
        Dim nuevoNodoSinClas As New TreeNode
        nuevoNodoSinClas.Text = "SIN CLASIFICACI�N"
        nuevoNodoSinClas.Tag = "0"
        TreeViewClass.Nodes.Add(nuevoNodoSinClas)
        dataSetArbol.Dispose()

    End Sub

    Private Sub CrearNodosDelPadre(ByVal indicePadre As Integer, ByVal nodePadre As TreeNode)

        Dim dataViewHijos As DataView

        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como par�metro.
        dataViewHijos = New DataView(dataSetArbol.Tables("Clasificacion"))

        dataViewHijos.RowFilter = dataSetArbol.Tables("Clasificacion").Columns("IdentificadorPadre").ColumnName + " = " + indicePadre.ToString()

        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each dataRowCurrent As DataRowView In dataViewHijos

            Dim nuevoNodo As New TreeNode
            nuevoNodo.Text = dataRowCurrent("NombreNodo").ToString().Trim()
            nuevoNodo.Tag = dataRowCurrent("IdentificadorNodo").ToString().Trim()
            ' si el par�metro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                TreeViewClass.Nodes.Add(nuevoNodo)
            Else
                ' se a�ade el nuevo nodo al nodo padre.
                nodePadre.Nodes.Add(nuevoNodo)
            End If

            ' Llamada recurrente al mismo m�todo para agregar los Hijos del Nodo reci�n agregado.
            CrearNodosDelPadre(Int32.Parse(dataRowCurrent("IdentificadorNodo").ToString()), nuevoNodo)
        Next dataRowCurrent



    End Sub

    Private Sub recuperaAlmacenOrigen()
        If Not cmbSucursalO.SelectedValue Is Nothing Then
            SUCClave = cmbSucursalO.SelectedValue
            With CmbAlmacen
                .Conexion = ModPOS.BDConexion
                .ProcedimientoAlmacenado = "sp_filtra_almsuc"
                .NombreParametro1 = "SUCClave"
                .Parametro1 = SUCClave
                .llenar()
            End With
        Else
            SUCClave = ""
        End If
    End Sub

    Private Sub FrmMtoExistencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ModPOS.CambiarEstiloXP.CambiarEstilo(Me)
        Cursor.Current = Cursors.WaitCursor

        Dim dt As DataTable = ModPOS.Recupera_Tabla("st_recupera_perfil", "@PERClave", ModPOS.MyProfile)
        iAjustaExistencia = IIf(dt.Rows(0)("AjustaExistencia").GetType.Name = "DBNull", 0, dt.Rows(0)("AjustaExistencia"))
        dt.Dispose()


        With cmbSucursalO
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_sucursal"
            .NombreParametro1 = "USRClave"
            .Parametro1 = ModPOS.UsuarioActual
            .NombreParametro2 = "COMClave"
            .Parametro2 = ModPOS.CompanyActual
            .llenar()
        End With


        If ModPOS.SucursalPredeterminada <> "" Then
            cmbSucursalO.SelectedValue = ModPOS.SucursalPredeterminada
        End If

        recuperaAlmacenOrigen()

        If ModPOS.AlmacenPredeterminado <> "" Then
            CmbAlmacen.SelectedValue = ModPOS.AlmacenPredeterminado
        End If

        With Me.cmbGrupo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_grupo"
            .NombreParametro1 = "Tipo"
            .Parametro1 = "3"
            .llenar()
        End With

        actualizaTree(IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue))

        If Not CmbAlmacen.SelectedValue Is Nothing Then
            recuperaExistencia(2, "")
            Cursor.Current = Cursors.Default
        End If

        bLoad = True

        With Me.CmbCampo
            .Conexion = ModPOS.BDConexion
            .ProcedimientoAlmacenado = "sp_filtra_valorref"
            .NombreParametro1 = "tabla"
            .Parametro1 = "Producto"
            .NombreParametro2 = "campo"
            .Parametro2 = "Filtro"
            .llenar()
        End With

        If iAjustaExistencia = 0 Then
            BtnAjustar.Visible = False
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmMtoExistencia_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ModPOS.MtoExistencia.Dispose()
        ModPOS.MtoExistencia = Nothing
    End Sub



    Private Sub GridProductos_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridProductos.SelectionChanged
        If bLoadProductos = True AndAlso Not GridProductos.GetValue(0) Is Nothing Then
            Me.sProdSelected = GridProductos.GetValue(0)
            Me.sNombre = GridProductos.GetValue("Nombre")
            sClave = GridProductos.GetValue("Clave")
            dApartados = GridProductos.GetValue("Apart")
            dBloqueados = IIf(IsDBNull(GridProductos.GetValue("Bloq")), 0, GridProductos.GetValue("Bloq"))
            recuperaUbicaciones(CmbAlmacen.SelectedValue, sProdSelected)
        Else
            Me.sProdSelected = ""
            Me.sNombre = ""
            sClave = ""
            dApartados = 0
            dBloqueados = 0
        End If
    End Sub

    Public Sub AjustarExistencia()
        If sProdSelected <> "" Then

            If ModPOS.AjustarExist Is Nothing Then

                ModPOS.AjustarExist = New FrmAjustarExist
                With ModPOS.AjustarExist
                    .Text = "Ajuste de Existencia"
                    .PROClave = sProdSelected
                    .ALMClave = CmbAlmacen.SelectedValue
                    .UBCClave = sUBCClave
                    .Nombre = sNombre
                    .Clave = sClave
                    .Ubicacion = sUbicacion
                    .StartPosition = FormStartPosition.CenterScreen
                End With
            End If

            ModPOS.AjustarExist.StartPosition = FormStartPosition.CenterScreen
            ModPOS.AjustarExist.Show()
            ModPOS.AjustarExist.BringToFront()
        End If
    End Sub

    Private Sub TxtBuscar_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyUp
        If Not CmbAlmacen.SelectedValue Is Nothing AndAlso Not CmbCampo.SelectedValue Is Nothing Then
            If TxtBuscar.Text <> "" Then
                recuperaExistencia(1, "")
            End If
        Else
            Beep()
            MessageBox.Show("�No esta el filtro seleccionado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Public Sub recuperaUbicaciones(ByVal sAlmacen As String, ByVal sProducto As String)

        If Not dtUbicaciones Is Nothing Then
            dtUbicaciones.Dispose()
        End If

        dtUbicaciones = ModPOS.Recupera_Tabla("sp_prd_exist_uba", "@ALMClave", sAlmacen, "@PROClave", sProducto)

        GridUbicacion.DataSource = dtUbicaciones
        GridUbicacion.RetrieveStructure()
        GridUbicacion.AutoSizeColumns()
        GridUbicacion.RootTable.Columns("ID").Visible = False
        GridUbicacion.CurrentTable.Columns("EST").Selectable = False
        GridUbicacion.CurrentTable.Columns("Columna").Selectable = False
        GridUbicacion.CurrentTable.Columns("Nivel").Selectable = False
        GridUbicacion.CurrentTable.Columns("Ubicaci�n").Selectable = False
        GridUbicacion.CurrentTable.Columns("Exist").Selectable = False
        GridUbicacion.CurrentTable.Columns("Apart").Selectable = False
        GridUbicacion.CurrentTable.Columns("Bloq").Selectable = False
        GridUbicacion.CurrentTable.Columns("Estado").Selectable = False

        GridUbicacion.CurrentTable.Columns("UBCClave").Visible = False
       

        GridUbicacion.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True
        GridUbicacion.RootTable.Columns("Exist").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        GridUbicacion.RootTable.Columns("Apart").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        GridUbicacion.RootTable.Columns("Bloq").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum



        If Not GridUbicacion.GetValue(0) Is Nothing Then
            sUBCClave = GridUbicacion.GetValue("UBCClave")
            sUbicacion = GridUbicacion.GetValue("Ubicaci�n")
            Me.dExistSelected = GridUbicacion.GetValue("Exist")

            If iAjustaExistencia = 0 Then
                BtnAjustar.Visible = False
            Else
                Me.BtnAjustar.Visible = True
            End If

            BtnImp.Enabled = True
        Else
            Me.sUBCClave = ""
            sUbicacion = ""
            Me.dExistSelected = 0
            BtnImp.Enabled = False

        End If
    End Sub

    Public Sub recuperaExistencia(ByVal iTipo As Integer, ByVal sT As String)

        If Not dtExistencia Is Nothing Then
            dtExistencia.Dispose()
        End If

        bLoadProductos = False

        Select Case iTipo
            Case Is = 1
                dtExistencia = ModPOS.Recupera_Tabla("sp_muestra_existencias", "@Tipo", iTipo, "@ALMClave", CmbAlmacen.SelectedValue, "@Campo", CmbCampo.SelectedValue, "@Busca", TxtBuscar.Text.ToUpper.Trim, "@Char", cReplace)
            Case Is = 2
                If TreeViewClass.SelectedNode Is Nothing Then
                    dtExistencia = ModPOS.Recupera_Tabla("sp_muestra_existencias", "@Tipo", iTipo, "@ALMClave", CmbAlmacen.SelectedValue, "@Class", TreeViewClass.TopNode.Tag, "@Char", cReplace)
                    sTag = TreeViewClass.TopNode.Tag
                Else
                    dtExistencia = ModPOS.Recupera_Tabla("sp_muestra_existencias", "@Tipo", iTipo, "@ALMClave", CmbAlmacen.SelectedValue, "@Class", TreeViewClass.SelectedNode.Tag, "@Char", cReplace)
                    sTag = TreeViewClass.SelectedNode.Tag
                End If
            Case Is = 3
                dtExistencia = ModPOS.Recupera_Tabla("sp_muestra_existencias", "@Tipo", iTipo, "@ALMClave", CmbAlmacen.SelectedValue, "@Class", sT, "@Char", cReplace)
                sTag = sT
            Case Is = 4
                dtExistencia = ModPOS.Recupera_Tabla("sp_muestra_existencias", "@Tipo", iTipo, "@ALMClave", CmbAlmacen.SelectedValue, "@UBCClave", TxtUbicacion.Text.ToUpper.Trim, "@Char", cReplace)
        End Select

        GridProductos.DataSource = dtExistencia
        GridProductos.RetrieveStructure()
        GridProductos.AutoSizeColumns()
        GridProductos.RootTable.Columns("ID").Visible = False
        GridProductos.RootTable.Columns("Marca").Visible = False
        GridProductos.CurrentTable.Columns("C.BARRAS").Selectable = False
        GridProductos.CurrentTable.Columns("Clave").Selectable = False
        GridProductos.CurrentTable.Columns("Nombre").Selectable = False
        GridProductos.CurrentTable.Columns("Exist").Selectable = False
        GridProductos.CurrentTable.Columns("Apart").Selectable = False
        GridProductos.CurrentTable.Columns("Bloq").Selectable = False

        GridProductos.TotalRow = Janus.Windows.GridEX.InheritableBoolean.True
        GridProductos.RootTable.Columns("Exist").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        GridProductos.RootTable.Columns("Apart").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum
        GridProductos.RootTable.Columns("Bloq").AggregateFunction = Janus.Windows.GridEX.AggregateFunction.Sum

    
        TipoConsulta = iTipo

        If dtExistencia.Rows.Count > 0 Then
            recuperaUbicaciones(CmbAlmacen.SelectedValue, dtExistencia.Rows(0)("ID"))
        Else
            recuperaUbicaciones(CmbAlmacen.SelectedValue, "")
        End If

        If Not GridProductos.GetValue(0) Is Nothing Then
            Me.sProdSelected = GridProductos.GetValue(0)
            Me.sNombre = GridProductos.GetValue("Nombre")
            sClave = GridProductos.GetValue("Clave")
            dApartados = GridProductos.GetValue("Apart")
            dBloqueados = IIf(IsDBNull(GridProductos.GetValue("Bloq")), 0, GridProductos.GetValue("Bloq"))
        Else
            Me.sProdSelected = ""
            Me.sNombre = ""
            sClave = ""
            dApartados = 0
            dBloqueados = 0
        End If


        bLoadProductos = True

    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Me.Close()
    End Sub

    Private Sub BtnAjustar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAjustar.Click

        AjustarExistencia()

    End Sub

    Private Sub TreeViewClass_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TreeViewClass.KeyUp
        If e.KeyCode = Keys.Enter AndAlso Not TreeViewClass.SelectedNode.Tag Is Nothing Then
            recuperaExistencia(3, TreeViewClass.SelectedNode.Tag)
        End If
    End Sub

    Private Sub TreeViewClass_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeViewClass.NodeMouseClick
        If Not CmbAlmacen.SelectedValue Is Nothing AndAlso Not e.Node.Tag Is Nothing Then
            recuperaExistencia(3, e.Node.Tag)
        End If
    End Sub

    Private Sub TxtUbicacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUbicacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not CmbAlmacen.SelectedValue Is Nothing Then
                If TxtUbicacion.Text <> "" Then
                    recuperaExistencia(4, "")
                End If
            End If
        End If
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        If Not CmbAlmacen.SelectedValue Is Nothing Then
            Dim a As New MeSearch
            a.ProcedimientoAlmacenado = "sp_search_ubicacion"
            a.TablaCmb = "Reubicacion"
            a.CampoCmb = "Filtro"
            a.AlmRequerido = True
            a.ALMClave = Me.CmbAlmacen.SelectedValue
            a.NumColDes = 1
            a.OcultaCol = True
            a.OcultaColNum = 0
            a.ShowDialog()
            If a.DialogResult = DialogResult.OK Then
                TxtUbicacion.Text = a.Descripcion
                recuperaExistencia(4, "")
            End If
            a.Dispose()
        End If
    End Sub

    Private Sub GridUbicacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridUbicacion.DoubleClick
        If iAjustaExistencia = 1 Then
            AjustarExistencia()
        End If
    End Sub

    Private Sub GridUbicacion_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridUbicacion.SelectionChanged
        If sProdSelected <> "" AndAlso Not GridUbicacion.GetValue(0) Is Nothing Then
            sUBCClave = GridUbicacion.GetValue("UBCClave")
            sUbicacion = GridUbicacion.GetValue("Ubicaci�n")

            Me.dExistSelected = GridUbicacion.GetValue("Exist")
            Me.BtnImp.Enabled = True

            If iAjustaExistencia = 0 Then
                BtnAjustar.Visible = False
            Else
                Me.BtnAjustar.Visible = True
            End If

        Else
            Me.sUBCClave = ""
            sUbicacion = ""
            Me.dExistSelected = 0
            Me.BtnImp.Enabled = False

        End If
    End Sub

    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        If sUBCClave <> "" AndAlso Not CmbAlmacen.SelectedValue Is Nothing Then
            Dim OpenReport As New Report
            Dim pvtaDataSet As New DataSet
            pvtaDataSet.DataSetName = "pvtaDataSet"

            Select Case TipoConsulta
                Case Is = 1
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_muestra_existencias", "@Tipo", TipoConsulta, "@ALMClave", CmbAlmacen.SelectedValue, "@Campo", CmbCampo.SelectedValue, "@Busca", TxtBuscar.Text.ToUpper.Trim, "@Char", cReplace))
                Case Is = 2
                    If TreeViewClass.SelectedNode Is Nothing Then
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_muestra_existencias", "@Tipo", TipoConsulta, "@ALMClave", CmbAlmacen.SelectedValue, "@Class", sTag, "@Char", cReplace))
                    Else
                        pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_muestra_existencias", "@Tipo", TipoConsulta, "@ALMClave", CmbAlmacen.SelectedValue, "@Class", sTag, "@Char", cReplace))
                    End If
                Case Is = 3
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_muestra_existencias", "@Tipo", TipoConsulta, "@ALMClave", CmbAlmacen.SelectedValue, "@Class", sTag, "@Char", cReplace))
                Case Is = 4
                    pvtaDataSet.Tables.Add(ModPOS.Recupera_Tabla("sp_muestra_existencias", "@Tipo", TipoConsulta, "@ALMClave", CmbAlmacen.SelectedValue, "@UBCClave", TxtUbicacion.Text.ToUpper.Trim, "@Char", cReplace))
            End Select

            OpenReport.PrintPreview("Existencia por Ubicaci�n", "CRExistUba.rpt", pvtaDataSet, "")
        End If
    End Sub

    Private Sub cmbGrupo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGrupo.SelectedValueChanged
        If Not cmbGrupo.SelectedValue Is Nothing AndAlso bLoad = True Then

            actualizaTree(IIf(cmbGrupo.SelectedValue Is Nothing, 0, cmbGrupo.SelectedValue))

        End If
    End Sub

    Private Sub cmbSucursalO_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSucursalO.SelectedValueChanged
        If bLoad = True Then
            recuperaAlmacenOrigen()
        End If
    End Sub

    Private Sub CmbAlmacen_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbAlmacen.SelectedValueChanged
        If bLoad = True AndAlso Not CmbAlmacen.SelectedValue Is Nothing Then
            Cursor.Current = Cursors.WaitCursor
            recuperaExistencia(2, "")
            Cursor.Current = Cursors.Default
        End If
    End Sub


    Private Sub BtnStock_Click(sender As Object, e As EventArgs) Handles BtnStock.Click
        If sProdSelected <> "" AndAlso Not CmbAlmacen.SelectedValue Is Nothing Then
            Dim a As New FrmConsultaGen
            a.Text = "Existencia en Otros Almacenes"
            ModPOS.ActualizaGrid(False, a.GridConsultaGen, "sp_muestra_exist_alm", "@PROClave", sProdSelected, "@ALMClave", CmbAlmacen.SelectedValue)
            a.ShowDialog()
            a.Dispose()
        End If
    End Sub
End Class