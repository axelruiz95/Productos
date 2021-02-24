<%@ page import="mx.elephantworks.iselling.Plan" %>
<!DOCTYPE html>
<html>
	<head>
		<meta name="layout" content="main">
		<g:set var="entityName" value="${message(code: 'plan.label', default: 'Plan')}" />
		<title><g:message code="default.edit.label" args="[entityName]" /></title>
	</head>
	<body>
	<g:if test="${flash.message}">
		<div class="alert alert-info alert-dismissible" role="alert">
			<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
			<strong>Aviso!</strong> ${flash.message}
		</div>
	</g:if>
	<g:hasErrors bean="${planInstance}">
		<div class="alert alert-info alert-dismissible" role="alert">
			<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
			<ul role="alert">
				<g:eachError bean="${planInstance}" var="error">
					<li <g:if test="${error in org.springframework.validation.FieldError}">data-field-id="${error.field}"</g:if>><g:message error="${error}"/></li>
				</g:eachError>
			</ul>
		</div>
	</g:hasErrors>
	<div style="margin-top: 3%">
		<g:link action="index">
			<image width="30px" class="imageInButton" src="${resource(dir: "images", file: "volver.png")}"></image>
			<label class="mensaje">volver</label>
		</g:link>
	</div>
	<div id="create-plan" class="row" style="margin-top: 3%" role="main">
		<div class="col-md-8 col-md-offset-2">
			<div class="panel panel-primary" style="border-color: #48BFE6">
				<div class="panel-heading encabezadoPanelFormulario" style="background-color: #48BFE6;border-color: #48BFE6;">
					<image width="25px" class="imageInButton" src="${resource(dir: "images", file: "plan/planBlanco.png")}"></image>
					<g:message code="default.edit.label" args="[entityName]" />
				</div>
				<div class="contenedor" style="margin-top: 3%; margin-bottom: 3%;width: 86%;">
			<g:form url="[resource:planInstance, action:'update']" method="PUT" >
				<g:hiddenField name="version" value="${planInstance?.version}" />
				<fieldset class="form">
					<g:render template="form" model="[editable:true]"/>
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