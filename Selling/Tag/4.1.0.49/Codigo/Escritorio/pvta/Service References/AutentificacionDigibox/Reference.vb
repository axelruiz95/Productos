﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace AutentificacionDigibox
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute([Namespace]:="http://digibox.com/", ConfigurationName:="AutentificacionDigibox.wsAutenticacionSoap")>  _
    Public Interface wsAutenticacionSoap
        
        'CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento usuario del espacio de nombres http://digibox.com/ no está marcado para aceptar valores nil.
        <System.ServiceModel.OperationContractAttribute(Action:="http://digibox.com/AutenticarBasico", ReplyAction:="*")>  _
        Function AutenticarBasico(ByVal request As AutentificacionDigibox.AutenticarBasicoRequest) As AutentificacionDigibox.AutenticarBasicoResponse
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://digibox.com/AutenticarBasico", ReplyAction:="*")>  _
        Function AutenticarBasicoAsync(ByVal request As AutentificacionDigibox.AutenticarBasicoRequest) As System.Threading.Tasks.Task(Of AutentificacionDigibox.AutenticarBasicoResponse)
        
        'CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento apiKey del espacio de nombres http://digibox.com/ no está marcado para aceptar valores nil.
        <System.ServiceModel.OperationContractAttribute(Action:="http://digibox.com/TokenCambioContraseña", ReplyAction:="*")>  _
        Function TokenCambioContraseña(ByVal request As AutentificacionDigibox.TokenCambioContraseñaRequest) As AutentificacionDigibox.TokenCambioContraseñaResponse
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://digibox.com/TokenCambioContraseña", ReplyAction:="*")>  _
        Function TokenCambioContraseñaAsync(ByVal request As AutentificacionDigibox.TokenCambioContraseñaRequest) As System.Threading.Tasks.Task(Of AutentificacionDigibox.TokenCambioContraseñaResponse)
        
        'CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento token del espacio de nombres http://digibox.com/ no está marcado para aceptar valores nil.
        <System.ServiceModel.OperationContractAttribute(Action:="http://digibox.com/CambioContraseña", ReplyAction:="*")>  _
        Function CambioContraseña(ByVal request As AutentificacionDigibox.CambioContraseñaRequest) As AutentificacionDigibox.CambioContraseñaResponse
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://digibox.com/CambioContraseña", ReplyAction:="*")>  _
        Function CambioContraseñaAsync(ByVal request As AutentificacionDigibox.CambioContraseñaRequest) As System.Threading.Tasks.Task(Of AutentificacionDigibox.CambioContraseñaResponse)
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class AutenticarBasicoRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="AutenticarBasico", [Namespace]:="http://digibox.com/", Order:=0)>  _
        Public Body As AutentificacionDigibox.AutenticarBasicoRequestBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As AutentificacionDigibox.AutenticarBasicoRequestBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://digibox.com/")>  _
    Partial Public Class AutenticarBasicoRequestBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public usuario As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=1)>  _
        Public password As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal usuario As String, ByVal password As String)
            MyBase.New
            Me.usuario = usuario
            Me.password = password
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class AutenticarBasicoResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="AutenticarBasicoResponse", [Namespace]:="http://digibox.com/", Order:=0)>  _
        Public Body As AutentificacionDigibox.AutenticarBasicoResponseBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As AutentificacionDigibox.AutenticarBasicoResponseBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://digibox.com/")>  _
    Partial Public Class AutenticarBasicoResponseBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public AutenticarBasicoResult As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal AutenticarBasicoResult As String)
            MyBase.New
            Me.AutenticarBasicoResult = AutenticarBasicoResult
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class TokenCambioContraseñaRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="TokenCambioContraseña", [Namespace]:="http://digibox.com/", Order:=0)>  _
        Public Body As AutentificacionDigibox.TokenCambioContraseñaRequestBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As AutentificacionDigibox.TokenCambioContraseñaRequestBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://digibox.com/")>  _
    Partial Public Class TokenCambioContraseñaRequestBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public apiKey As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=1)>  _
        Public email As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal apiKey As String, ByVal email As String)
            MyBase.New
            Me.apiKey = apiKey
            Me.email = email
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class TokenCambioContraseñaResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="TokenCambioContraseñaResponse", [Namespace]:="http://digibox.com/", Order:=0)>  _
        Public Body As AutentificacionDigibox.TokenCambioContraseñaResponseBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As AutentificacionDigibox.TokenCambioContraseñaResponseBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://digibox.com/")>  _
    Partial Public Class TokenCambioContraseñaResponseBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public TokenCambioContraseñaResult As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal TokenCambioContraseñaResult As String)
            MyBase.New
            Me.TokenCambioContraseñaResult = TokenCambioContraseñaResult
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class CambioContraseñaRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="CambioContraseña", [Namespace]:="http://digibox.com/", Order:=0)>  _
        Public Body As AutentificacionDigibox.CambioContraseñaRequestBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As AutentificacionDigibox.CambioContraseñaRequestBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute([Namespace]:="http://digibox.com/")>  _
    Partial Public Class CambioContraseñaRequestBody
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=0)>  _
        Public token As String
        
        <System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue:=false, Order:=1)>  _
        Public newPassword As String
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal token As String, ByVal newPassword As String)
            MyBase.New
            Me.token = token
            Me.newPassword = newPassword
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class CambioContraseñaResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="CambioContraseñaResponse", [Namespace]:="http://digibox.com/", Order:=0)>  _
        Public Body As AutentificacionDigibox.CambioContraseñaResponseBody
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal Body As AutentificacionDigibox.CambioContraseñaResponseBody)
            MyBase.New
            Me.Body = Body
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.Runtime.Serialization.DataContractAttribute()>  _
    Partial Public Class CambioContraseñaResponseBody
        
        Public Sub New()
            MyBase.New
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface wsAutenticacionSoapChannel
        Inherits AutentificacionDigibox.wsAutenticacionSoap, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class wsAutenticacionSoapClient
        Inherits System.ServiceModel.ClientBase(Of AutentificacionDigibox.wsAutenticacionSoap)
        Implements AutentificacionDigibox.wsAutenticacionSoap
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function AutentificacionDigibox_wsAutenticacionSoap_AutenticarBasico(ByVal request As AutentificacionDigibox.AutenticarBasicoRequest) As AutentificacionDigibox.AutenticarBasicoResponse Implements AutentificacionDigibox.wsAutenticacionSoap.AutenticarBasico
            Return MyBase.Channel.AutenticarBasico(request)
        End Function
        
        Public Function AutenticarBasico(ByVal usuario As String, ByVal password As String) As String
            Dim inValue As AutentificacionDigibox.AutenticarBasicoRequest = New AutentificacionDigibox.AutenticarBasicoRequest()
            inValue.Body = New AutentificacionDigibox.AutenticarBasicoRequestBody()
            inValue.Body.usuario = usuario
            inValue.Body.password = password
            Dim retVal As AutentificacionDigibox.AutenticarBasicoResponse = CType(Me,AutentificacionDigibox.wsAutenticacionSoap).AutenticarBasico(inValue)
            Return retVal.Body.AutenticarBasicoResult
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function AutentificacionDigibox_wsAutenticacionSoap_AutenticarBasicoAsync(ByVal request As AutentificacionDigibox.AutenticarBasicoRequest) As System.Threading.Tasks.Task(Of AutentificacionDigibox.AutenticarBasicoResponse) Implements AutentificacionDigibox.wsAutenticacionSoap.AutenticarBasicoAsync
            Return MyBase.Channel.AutenticarBasicoAsync(request)
        End Function
        
        Public Function AutenticarBasicoAsync(ByVal usuario As String, ByVal password As String) As System.Threading.Tasks.Task(Of AutentificacionDigibox.AutenticarBasicoResponse)
            Dim inValue As AutentificacionDigibox.AutenticarBasicoRequest = New AutentificacionDigibox.AutenticarBasicoRequest()
            inValue.Body = New AutentificacionDigibox.AutenticarBasicoRequestBody()
            inValue.Body.usuario = usuario
            inValue.Body.password = password
            Return CType(Me,AutentificacionDigibox.wsAutenticacionSoap).AutenticarBasicoAsync(inValue)
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function AutentificacionDigibox_wsAutenticacionSoap_TokenCambioContraseña(ByVal request As AutentificacionDigibox.TokenCambioContraseñaRequest) As AutentificacionDigibox.TokenCambioContraseñaResponse Implements AutentificacionDigibox.wsAutenticacionSoap.TokenCambioContraseña
            Return MyBase.Channel.TokenCambioContraseña(request)
        End Function
        
        Public Function TokenCambioContraseña(ByVal apiKey As String, ByVal email As String) As String
            Dim inValue As AutentificacionDigibox.TokenCambioContraseñaRequest = New AutentificacionDigibox.TokenCambioContraseñaRequest()
            inValue.Body = New AutentificacionDigibox.TokenCambioContraseñaRequestBody()
            inValue.Body.apiKey = apiKey
            inValue.Body.email = email
            Dim retVal As AutentificacionDigibox.TokenCambioContraseñaResponse = CType(Me,AutentificacionDigibox.wsAutenticacionSoap).TokenCambioContraseña(inValue)
            Return retVal.Body.TokenCambioContraseñaResult
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function AutentificacionDigibox_wsAutenticacionSoap_TokenCambioContraseñaAsync(ByVal request As AutentificacionDigibox.TokenCambioContraseñaRequest) As System.Threading.Tasks.Task(Of AutentificacionDigibox.TokenCambioContraseñaResponse) Implements AutentificacionDigibox.wsAutenticacionSoap.TokenCambioContraseñaAsync
            Return MyBase.Channel.TokenCambioContraseñaAsync(request)
        End Function
        
        Public Function TokenCambioContraseñaAsync(ByVal apiKey As String, ByVal email As String) As System.Threading.Tasks.Task(Of AutentificacionDigibox.TokenCambioContraseñaResponse)
            Dim inValue As AutentificacionDigibox.TokenCambioContraseñaRequest = New AutentificacionDigibox.TokenCambioContraseñaRequest()
            inValue.Body = New AutentificacionDigibox.TokenCambioContraseñaRequestBody()
            inValue.Body.apiKey = apiKey
            inValue.Body.email = email
            Return CType(Me,AutentificacionDigibox.wsAutenticacionSoap).TokenCambioContraseñaAsync(inValue)
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function AutentificacionDigibox_wsAutenticacionSoap_CambioContraseña(ByVal request As AutentificacionDigibox.CambioContraseñaRequest) As AutentificacionDigibox.CambioContraseñaResponse Implements AutentificacionDigibox.wsAutenticacionSoap.CambioContraseña
            Return MyBase.Channel.CambioContraseña(request)
        End Function
        
        Public Sub CambioContraseña(ByVal token As String, ByVal newPassword As String)
            Dim inValue As AutentificacionDigibox.CambioContraseñaRequest = New AutentificacionDigibox.CambioContraseñaRequest()
            inValue.Body = New AutentificacionDigibox.CambioContraseñaRequestBody()
            inValue.Body.token = token
            inValue.Body.newPassword = newPassword
            Dim retVal As AutentificacionDigibox.CambioContraseñaResponse = CType(Me,AutentificacionDigibox.wsAutenticacionSoap).CambioContraseña(inValue)
        End Sub
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function AutentificacionDigibox_wsAutenticacionSoap_CambioContraseñaAsync(ByVal request As AutentificacionDigibox.CambioContraseñaRequest) As System.Threading.Tasks.Task(Of AutentificacionDigibox.CambioContraseñaResponse) Implements AutentificacionDigibox.wsAutenticacionSoap.CambioContraseñaAsync
            Return MyBase.Channel.CambioContraseñaAsync(request)
        End Function
        
        Public Function CambioContraseñaAsync(ByVal token As String, ByVal newPassword As String) As System.Threading.Tasks.Task(Of AutentificacionDigibox.CambioContraseñaResponse)
            Dim inValue As AutentificacionDigibox.CambioContraseñaRequest = New AutentificacionDigibox.CambioContraseñaRequest()
            inValue.Body = New AutentificacionDigibox.CambioContraseñaRequestBody()
            inValue.Body.token = token
            inValue.Body.newPassword = newPassword
            Return CType(Me,AutentificacionDigibox.wsAutenticacionSoap).CambioContraseñaAsync(inValue)
        End Function
    End Class
End Namespace