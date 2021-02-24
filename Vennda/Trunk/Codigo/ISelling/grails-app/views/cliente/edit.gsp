<%@ page import="mx.elephantworks.iselling.Cliente" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'cliente.label', default: 'Cliente')}" />
		<title><g:message code="default.edit.label" args="[entityName]" /></title>
	</head>
	<body>

<div style="margin-top: 3%">
	<g:link action="index">
		<image width="30px" class="imageInButton" src="${resource(dir: "images", file: "volver.png")}"></image>
		<label class="mensaje"><g:message code="volver.title.label" default="Volver"></g:message></label>
	</g:link>
</div>
<div id="create-cliente" class="row" style="margin-top: 3%" role="main">
	<div class="col-md-8 col-md-offset-2">
		<div class="panel panel-primary" style="border-color: #48BFE6">
			<div class="panel-heading encabezadoPanelFormulario" style="background-color: #48BFE6;border-color: #48BFE6;">
				<image width="25px" class="imageInButton" src="${resource(dir: "images", file: "cliente/clienteBlanco.png")}"></image>
				<g:message code="default.edit.label" args="[entityName]" />
			</div>
			<g:if test="${flash.message}">
				<div class="alert alert-info alert-dismissible" role="alert">
					<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
					<strong><g:message code="alerta.title.label" default="Aviso!"></g:message></strong> ${flash.message}
				</div>
			</g:if>
			<g:hasErrors bean="${clienteInstance}">
				<div class="alert alert-danger alert-dismissible" role="alert">
					<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
					<ul role="alert">
						<g:eachError bean="${clienteInstance}" var="error">
							<li <g:if test="${error in org.springframework.validation.FieldError}">data-field-id="${error.field}"</g:if>><g:message error="${error}"/></li>
						</g:eachError>
					</ul>
				</div>
			</g:hasErrors>

			<div class="contenedor" style="margin-top: 3%; margin-bottom: 3%">
				<g:form url="[resource:clienteInstance, action:'update']" method="PUT" >
					<g:hiddenField name="version" value="${clienteInstance?.version}" />
					<fieldset class="form">
						<g:render template="form" model="[editable: true]"/>
					</fieldset>
					<fieldset class="buttons" style="text-align: right">
						<g:actionSubmit class="btn btn-primary color-vennda" action="update" value="${message(code: 'default.button.update.label', default: 'Update')}" />
					</fieldset>
				</g:form>
			</div>
	</div>
</div>
</div>
	</body>
</html>
