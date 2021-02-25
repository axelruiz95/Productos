Imports BASMENLOG
Imports ERMCEFLOG

Public Class NGeneral
    Inherits FormasBase.Browse01

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
    Friend WithEvents btCrear As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btModificar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btEliminar As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btActualizar As DevComponents.DotNetBar.ButtonItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim GridEx1_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NGeneral))
        Me.btCrear = New DevComponents.DotNetBar.ButtonItem
        Me.btModificar = New DevComponents.DotNetBar.ButtonItem
        Me.btEliminar = New DevComponents.DotNetBar.ButtonItem
        Me.btActualizar = New DevComponents.DotNetBar.ButtonItem
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar1
        '
        Me.Bar1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btCrear, Me.btModificar, Me.btEliminar, Me.btActualizar})
        '
        'GridEx1
        '
        Me.GridEx1.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[False]
        GridEx1_DesignTimeLayout.LayoutString = resources.GetString("GridEx1_DesignTimeLayout.LayoutString")
        Me.GridEx1.DesignTimeLayout = GridEx1_DesignTimeLayout
        '
        'btCrear
        '
        Me.btCrear.DisabledImage = CType(resources.GetObject("btCrear.DisabledImage"), System.Drawing.Image)
        Me.btCrear.Icon = CType(resources.GetObject("btCrear.Icon"), System.Drawing.Icon)
        Me.btCrear.Name = "btCrear"
        Me.btCrear.Text = "btCrear"
        '
        'btModificar
        '
        Me.btModificar.DisabledImage = CType(resources.GetObject("btModificar.DisabledImage"), System.Drawing.Image)
        Me.btModificar.Icon = CType(resources.GetObject("btModificar.Icon"), System.Drawing.Icon)
        Me.btModificar.Name = "btModificar"
        Me.btModificar.Text = "btModificar"
        '
        'btEliminar
        '
        Me.btEliminar.DisabledImage = CType(resources.GetObject("btEliminar.DisabledImage"), System.Drawing.Image)
        Me.btEliminar.Icon = CType(resources.GetObject("btEliminar.Icon"), System.Drawing.Icon)
        Me.btEliminar.Name = "btEliminar"
        Me.btEliminar.Text = "btEliminar"
        '
        'btActualizar
        '
        Me.btActualizar.DisabledImage = CType(resources.GetObject("btActualizar.DisabledImage"), System.Drawing.Image)
        Me.btActualizar.Icon = CType(resources.GetObject("btActualizar.Icon"), System.Drawing.Icon)
        Me.btActualizar.Name = "btActualizar"
        Me.btActualizar.Text = "btActualizar"
        '
        'NGeneral
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(844, 666)
        Me.DoubleBuffered = True
        Me.Name = "NGeneral"
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridEx1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Variables "
    Private Shared oInstance As NGeneral = Nothing
    Private oMensaje As New CMensaje
    Private oConexion As LbConexion.cConexion = LbConexion.cConexion.Instancia
    Private oCertificadoFolio As cCertificadoFolio
    Private sComponente As String = "ERMCEFESC"
    Private vcAcceso As LbAcceso.cAcceso
#End Region

#Region "Eventos"
    Private Sub NGeneral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
#If DEBUG Then
        oConexion.Conectar("Provider=SQLOLEDB;Data Source=192.168.0.76\sql2008;user id=sa;password='dbsa';initial catalog=PANQUE")
        oMensaje = New CMensaje
        oMensaje.LlenarDataSet()
        lbGeneral.cParametros.UsuarioID = "Admin"
        vcAcceso = New LbAcceso.cAcceso
        vcAcceso.Crear = True
        vcAcceso.Eliminar = True
        vcAcceso.Modificar = True
        vcAcceso.Leer = True
#End If
        oCertificadoFolio = New cCertificadoFolio
        Me.Text = oMensaje.RecuperarDescripcion(sComponente & "_" & Me.Name)

        Try
            Actualizar()
            ConfigurarGrid()
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Sub

    Private Sub NGeneral_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            lbGeneral.GrabarConfiguracionGrid(sComponente, Me.Name, GridEx1, oCertificadoFolio.NombreTabla)
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try
    End Sub

    Private Sub btCrear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btCrear.Click
        Dim lMGeneral As New MGeneral
        Try
            oCertificadoFolio.Limpiar()
            If lMGeneral.CREAR(oCertificadoFolio) Then
                oCertificadoFolio.InsertarEn(GridEx1.DataSource)
            End If
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Sub

    Private Sub btModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btModificar.Click
        If vcAcceso.Modificar Then
            Call Modificar()
        Else
            If vcAcceso.Leer Then
                Call Consultar()
            End If
        End If
    End Sub

    Private Sub btEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btEliminar.Click
        Dim lMGeneral As New MGeneral

        If GridEx1.RowCount > 0 Then
            If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
                Try
                    oCertificadoFolio.Recuperar(GridEx1.GetRow.Cells("NumCertificado").Value)
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    Exit Sub
                End Try

                Try
                    oCertificadoFolio.Bloquear()
                Catch ex As LbControlError.cError
                    oConexion.DeshacerTran()
                    ex.Mostrar()
                    Exit Sub
                End Try

                'If oCertificadoFolio.Existe = True Then
                '    MsgBox(oMensaje.RecuperarDescripcion("E0641"), MsgBoxStyle.Critical, oMensaje.RecuperarDescripcion("XMensajeE"))
                '    lMGeneral.LEER(oCertificadoFolio)
                'Else
                If lMGeneral.ELIMINAR(oCertificadoFolio) Then 'Aceptar
                    GridEx1.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True
                    GridEx1.Delete()
                    GridEx1.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.False
                End If
                'End If
            End If
        End If
    End Sub

    Private Sub GridEX1_RowDoubleClick(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowActionEventArgs) Handles GridEx1.RowDoubleClick
        If vcAcceso.Modificar Then
            Call Modificar()
        Else
            If vcAcceso.Leer Then
                Call Consultar()
            End If
        End If
    End Sub

    Private Sub btActualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btActualizar.Click
        Call Actualizar()
    End Sub
#End Region

#Region " Metodos "
    Public Shared Function Instance() As NGeneral
        If oInstance Is Nothing OrElse oInstance.IsDisposed = True Then
            oInstance = New NGeneral
        End If
        Return oInstance
    End Function

    Sub Inicio(ByVal pvAcceso As LbAcceso.cAcceso)
        vcAcceso = pvAcceso
        Me.Show()
    End Sub

    Private Sub ConfigurarGrid()

        Dim lcColumna As Janus.Windows.GridEX.GridEXColumn
        For Each lcColumna In GridEx1.RootTable.Columns
            lcColumna.Caption = oMensaje.RecuperarDescripcion(oCertificadoFolio.Mnemonico & lcColumna.Key)
            lcColumna.HeaderToolTip = oMensaje.RecuperarDescripcion(oCertificadoFolio.Mnemonico & lcColumna.Key & "T")
        Next

        BTCrear.Tooltip = oMensaje.RecuperarDescripcion("btCrear")
        btModificar.Tooltip = oMensaje.RecuperarDescripcion("btModificar")
        btEliminar.Tooltip = oMensaje.RecuperarDescripcion("btEliminar")
        btActualizar.Tooltip = oMensaje.RecuperarDescripcion("btActualizar")

        If Not vcAcceso.Crear Then
            BTCrear.Enabled = False
        End If
        If Not vcAcceso.Eliminar Then
            btEliminar.Enabled = False
        End If
        If Not vcAcceso.Modificar And Not vcAcceso.Leer Then
            btModificar.Enabled = False
        End If

        If vcAcceso.Leer And Not vcAcceso.Modificar Then
            btModificar.Tooltip = oMensaje.RecuperarDescripcion("xconsultar")
            btModificar.Icon = New System.Drawing.Icon("Imagenes\Consulta.ico")
        End If
        Try
            lbGeneral.LlenarConfiguracionGrid(sComponente, Me.Name, GridEx1, oCertificadoFolio.NombreTabla)
        Catch ex As LbControlError.cError
            ex.Mostrar()
            Exit Sub
        End Try
    End Sub

    Private Sub Actualizar()
        Try
            Dim loDt As DataTable
            loDt = oCertificadoFolio.TablaNodo.Recuperar("", "NumCertificado, FechaInicial, FechaFinal")
            GridEx1.DataSource = loDt
            GridEx1.DataMember = oCertificadoFolio.NombreTabla
        Catch ex As LbControlError.cError
            ex.Mostrar()
        End Try
    End Sub

    Private Sub Modificar()
        Dim lMGeneral As New MGeneral

        If GridEx1.RowCount > 0 Then
            If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
                Try
                    oCertificadoFolio.Recuperar(GridEx1.GetRow.Cells("NumCertificado").Value)
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    Exit Sub
                End Try

                Try
                    oCertificadoFolio.Bloquear()
                Catch ex As LbControlError.cError
                    oConexion.DeshacerTran()
                    ex.Mostrar()
                    Exit Sub
                End Try

                If oCertificadoFolio.FechaFinal <= oConexion.ObtenerFecha Then
                    MsgBox(oMensaje.RecuperarDescripcion("I0168", New String() {Me.Text}), MsgBoxStyle.Information, oMensaje.RecuperarDescripcion("XMensajeI"))
                    lMGeneral.LEER(oCertificadoFolio)
                Else
                    If lMGeneral.MODIFICAR(oCertificadoFolio) Then 'Aceptar
                        oCertificadoFolio.ModificarEn(GridEx1.DataSource)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Consultar()
        Dim lMGeneral As New MGeneral

        If GridEx1.RowCount > 0 Then
            If (GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.NewRecord Or GridEx1.GetRow.RowType = Janus.Windows.GridEX.RowType.Record) Then
                Try
                    oCertificadoFolio.Recuperar(GridEx1.GetRow.Cells("NumCertificado").Value)
                Catch ex As LbControlError.cError
                    ex.Mostrar()
                    Exit Sub
                End Try

                lMGeneral.LEER(oCertificadoFolio)
            End If
        End If
    End Sub
#End Region

End Class