''' -----------------------------------------------------------------------------
''' <summary>
''' Tipo de la aplicaci�n destino desde la que se solicita o env�a el parametro
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[jvazquez]	03/05/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Enum TipoAplicacion
    Escritorio
    Web
End Enum
''' -----------------------------------------------------------------------------
''' Project	 : LbGeneral
''' Class	 : cParametros
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que define el comportamiento, propiedades y caracter�sticas de un par�metro
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[jvazquez]	03/05/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cParametros
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Lenguaje del servidor de datos
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared vcLenguaje As String
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Cadena de coneci�n a la base de datos
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared vcConexion As String
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Tiempo de espera para la conexi�n activa
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared vcTimeOut As Integer
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' ID del usuario
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared vcUsuarioID As String
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Tipo de aplicaci�n destino para el par�metro
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared vcTipoAplicacion As TipoAplicacion
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Propiedad de la clase que regresa 
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared ReadOnly Property Conexion() As String
        Get
            Return vcConexion
        End Get
    End Property
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Regresa el tiempo de espera de conexi�n de la instancia del par�metro
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared ReadOnly Property TimeOut() As Integer
        Get
            If vcTimeOut <= 0 Then
                vcTimeOut = -1
            End If
            Return vcTimeOut
        End Get
    End Property
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Regresa el ID del usuario propietario de la instancia del par�metro
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property UsuarioID() As String
        Get
            Return vcUsuarioID
        End Get
        Set(ByVal Value As String)
            If vcUsuarioID = "" Then
                vcUsuarioID = Value
            End If
        End Set
    End Property
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Lenguaje del servidor de datos, que servir� para invocar el val�r del par�metro correspondiente al 
    ''' lenguaje adecuado
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property Lenguaje() As String
        Get
            If vcLenguaje = "" Then
                vcLenguaje = "EM"
            End If
            Return vcLenguaje
        End Get
        Set(ByVal Value As String)
            vcLenguaje = Value
        End Set
    End Property
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Regresa o asigna el tipo de aplicaci�n para la cual se obtiene el valor del par�metro
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Property TipoAplicacion() As TipoAplicacion
        Get
            Return vcTipoAplicacion
        End Get
        Set(ByVal Value As TipoAplicacion)
            vcTipoAplicacion = Value
        End Set
    End Property
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Obtiene y asigna los valores  de cadena de conexi�n, tiempo de espera y lenguaje 
    ''' obtenidos del archivo de configuraci�n de la aplicaci�n
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub CargarParametros()
        vcConexion = ReadIni("Conexion")
        vcTimeOut = Int(ReadIni("TimeOut"))
        vcLenguaje = ReadIni("Lenguaje")
    End Sub
End Class
