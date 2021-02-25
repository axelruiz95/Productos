''' -----------------------------------------------------------------------------
''' Project	 : LbGeneral
''' Class	 : cKeyGen
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' Clase que genera una llave �nica, en base a una semilla num�rica, utilizada com�nmente como 
''' Campo Llave o ID �nico
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[jvazquez]	03/05/2007	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class cKeyGen
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Fecha y hora para generar la llave. Su valor por default es la Fecha y Hora actual
    ''' al momento de hacer la llamada a la funci�n
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared vcFechaHora As String
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Semilla num�rica que ser� la base de la generaci�n de la llave. Su valor por default es cero.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Shared vcSemilla As Integer = 0
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Constructor de la clase. 
    ''' Define el valor de su variable miembro vcFechaHora con la fecha y hora actuales en formato yyyyMMddHHmmssff 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New()
        If (IsNothing(vcFechaHora) = True) Then
            vcFechaHora = Now.ToString("yyyyMMddHHmmssff")
        End If
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Funci�n que contiene el algoritmo que genera la llave �nica en base a una semilla num�rica
    ''' </summary>
    ''' <param name="pvSemilla"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[jvazquez]	03/05/2007	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function KEYGEN(ByVal pvSemilla As Integer) As String
        Dim vlDateTime As String
        Dim vlNumeric As Decimal
        Dim vlString As String
        Dim vlString1 As String
        Dim vlTimeNow As String = ""
        Dim vlKey As String
        Dim vlBase As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ+"
        Dim vlModulo As Integer

        If (IsNothing(vcFechaHora) = True) Then
            vcFechaHora = Now.ToString("yyyyMMddHHmmssff")
        End If

        vlDateTime = vcFechaHora
        vlNumeric = Int(vlDateTime)
        vlNumeric = vlNumeric - 1899000000000000
        vlDateTime = CStr(vlNumeric)
        vlDateTime = vlDateTime.Substring(1, 13)

        vlNumeric = Now.Hour
        vlNumeric = vlNumeric + 100
        vlString = CStr(vlNumeric)
        vlTimeNow = vlTimeNow + vlString.Substring(1)

        vlNumeric = Now.Minute
        vlNumeric = vlNumeric + 100
        vlString = CStr(vlNumeric)
        vlTimeNow = vlTimeNow + vlString.Substring(1)

        vlNumeric = Now.Second
        vlNumeric = vlNumeric + 100
        vlString = CStr(vlNumeric)
        vlTimeNow = vlTimeNow + vlString.Substring(1)

        vlNumeric = Now.Millisecond
        vlNumeric = vlNumeric + 1000
        vlString = CStr(vlNumeric)
        vlTimeNow = vlTimeNow + vlString.Substring(1, 2)

        vlNumeric = vcSemilla
        vlNumeric = vlNumeric + 100
        vlString = CStr(vlNumeric)
        vlKey = vlDateTime + vlTimeNow + vlString.Substring(1)
        If vcSemilla = 99 Then
            vcSemilla = 0
        Else
            vcSemilla = vcSemilla + 1
        End If

        vlNumeric = vlKey
        vlString = ""

        While vlNumeric > 0
            vlModulo = (vlNumeric Mod 36) + 1
            vlNumeric = vlNumeric / 36
            vlNumeric = Int(vlNumeric)
            vlString1 = vlBase.Substring(vlModulo, 1)
            vlString = vlString1 + vlString
        End While

        Return vlString
    End Function
End Class
