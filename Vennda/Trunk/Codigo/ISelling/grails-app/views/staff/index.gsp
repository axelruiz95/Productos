
<%@ page import="mx.elephantworks.iselling.Staff" %>
<!DOCTYPE html>
<html>
<head>
	<meta name="layout" content="main">
	<g:set var="entityName" value="${message(code: 'staff.label', default: 'Staff')}" />
	<title><g:message code="default.list.label" args="[entityName]" /></title>
	<style>
	.imageInButton{
		width:30px;
	}
	.buttonImage{
		background-color: #48BFE6;
	}
	thead{
		background-color: #1c94c4;
		text-align: center;

	}
	thead tr th{
		font-family: "Arial";
		font-size: 14px;
		color:#FFF;
		text-align: center;
	}
	tbody tr{
		background-color: #D8DFE5;
		font-family: "Arial";
		font-size: 12px;
		color:#000;
		text-align: center;
	}
	tbody tr td{
		border-bottom: 1px solid #9B9B9B;
	}
	.semi-circulo-abajo
	{
		display: none;
	}
	.semi-circulo-arriba
	{
		display: none;
	}
	</style>
</head>
<body>
<div class="row">
	<div class="col-md-12" style="margin-top: 3%">
		<div class="col-md-3">
			<label class="mensaje">
				<image class="imageInButton" src="${resource(dir: "images", file: "Staff/staffGris.png")}"></image>
				<%--<g:message code="default.list.label" args="[entityName]" default="Staff" />--%>
				<g:message code="default.staff.label" args="[entityName]" default="Staff" />
			</label>
		</div>
		<div class="col-md-9" style="text-align: right">
			<g:link action="create" class="btn btn-primary color-vennda">
				<image class="imageInButton" src="${resource(dir: "images", file: "Staff/staffBlanco.png")}"></image>
				<g:message code="default.new.label" args="[entityName]"/>
			</g:link>
		</div>
	</div>
</div>
<br>
<g:if test="${flash.message}">
	<div class="alert alert-info alert-dismissible" role="alert">
		<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
		<strong>Aviso!</strong> ${flash.message}
	</div>
</g:if>

<div class="table-responsive" style="margin-top: 3%">
	<div class="table table-hover" id="list-staff" role="main">
		<table id="tablaStaff" class="table table-hover">
			<thead>
			<tr>

				<th>${message(code: 'staff.numEmpleado.label', default: 'Num Empleado')}</th>

				<th>${message(code: 'staff.nombre.label', default: 'Nombre')}</th>

				<th>${message(code: 'staff.apellidos.label', default: 'Apellidos')}</th>

				<th>${message(code: 'staff.email.label', default: 'Email')}</th>

				<th>${message(code: 'default.edit.label', default: 'Editar', args: [""])}</th>

				<th>${message(code: 'default.button.delete.label', default: 'Eliminar', args: [""])}</th>

			</tr>
			</thead>
			<tbody>
			<g:each in="${staffInstanceList}" status="i" var="staffInstance">
				<tr class="${(i % 2) == 0 ? 'even' : 'odd'}">

					<td>${fieldValue(bean: staffInstance, field: "numEmpleado")}</td>

					<td>${fieldValue(bean: staffInstance, field: "nombre")}</td>

					<td>${fieldValue(bean: staffInstance, field: "apellidos")}</td>

					<td>${fieldValue(bean: staffInstance, field: "email")}</td>

					<td>
						<g:link action="edit" id="${staffInstance.id}">
							<image class="imageInButton" src="${resource(dir: "images", file: "editar.png")}"></image>
						</g:link>
					</td>

					<td>
						<g:form url="[resource:staffInstance, action:'delete']" method="DELETE">
							<g:actionSubmitImage width="25px" value="${message(code: 'default.deleted.message', default: 'Eliminar', args: [""])}" src="${resource(dir: 'images', file: 'eliminar.png')}" action="delete" onclick="return confirm('${message(code: 'default.button.delete.confirm.message', default: 'Are you sure?')}');" />
						</g:form>
					</td>

				</tr>
			</g:each>
			</tbody>
		</table>
		<div class="pagination">
			<g:paginate total="${staffInstanceCount ?: 0}" />
		</div>
	</div>
</div>
<g:javascript>

		$(document).ready(function () {
			var tablaStaff = $("#tablaStaff").dataTable({
			   "sPaginationType": "full_numbers",
				"iDisplayLengthChange": 10,
				"bLengthChange": false,
				"bStateSave": true,
				"language": {
			       "url": "${resource(dir: 'javascripts', file:'spanish.json')}"
				}
			});
		});

</g:javascript>
</body>
</html>