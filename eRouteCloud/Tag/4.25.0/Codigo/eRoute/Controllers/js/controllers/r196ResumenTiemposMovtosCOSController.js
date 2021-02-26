﻿app.controller('r196ResumenTiemposMovtosCOSController', ['$scope', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, valorReferencia, $http, cfpLoadingBar) {
    var url = window.sessionStorage.getItem('URL');
    var self = this;
    self.showCEDI = false;
    self.showList = false;
    self.showSelect = undefined;
    self.nShowLists = nShowLists;
    self.selectedItem = undefined;
    self.OnSelectChange = OnSelectChange;
    self.minDate = undefined;
    self.maxDate = new Date();
    self.SubmitForm = SubmitForm;
    self.State = undefined;
    self.date1 = undefined;
    self.date2 = undefined;
    self.VAVClave = undefined;

    $scope.EstablecerReporte = function (VAVClave) {
        valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            self.titulo = result[0].Descripcion;
            self.showCEDI = (self.titulo == undefined ? false : true);
            self.VAVClave = VAVClave;
        });
        GetCEDIS();
        GetDates();
    }

    //  LLENAR CEDIS
    function GetCEDIS() {
        $http({
            url: url + '/API/GetReportFilters/GetCEDIS',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
            params: { USUId: window.sessionStorage.getItem('USUId') }
        }).then(function successCallBack(response) {
            self.cedis = response.data;
        }, function errorCallBack(response) {
        });
    }

    self.querySearch = function querySearch(query) {
        var results = query ? self.cedis.filter(createFilterFor(query)) : self.cedis,
            deferred;
        return results;
    }

    function createFilterFor(query) {
        var lowercaseQuery = query.toLowerCase();
        return function filterFn(cedis) {
            var dis = cedis.Nombre;
            var lowercaseDispley = dis.toLowerCase();
            return (lowercaseDispley.indexOf(lowercaseQuery) === 0);
        };
    }

    //  HABILITA LOS FILTROS
    function nShowLists(cedi) {
        self.showList = (cedi == undefined ? false : true);
    }

    //  FECHAS
    function GetDates() {
        $http({
            url: url + '/API/GetReportFilters/GetDateStatus',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).then(function successCallBack(response) {
            self.dateState = response.data;
            self.State = self.dateState[0].Nombre;
            self.date1 = self.maxDate;
        }, function errorCallBack(response) {
        });
    }

    //  ESTADO DEL RANGO DE FECHA
    function OnSelectChange(state) {
        if (state == 'Entre') {
            self.showSelect = 'true';
        }
        else if (state == 'Igual') {
            self.showSelect = undefined;
            self.date2 = undefined;
        }
    }

    $scope.$watch("ctrl.date1", function () {
        if (self.date1 != undefined) {
            self.minDate = new Date(self.date1.getFullYear(), (self.date1.getMonth()), (self.date1.getDate() + 1));
        }
        if (self.State == "Entre" && self.date2 != undefined) {
            if (self.date1 >= self.date2) {
                self.date2 = undefined;
            }
        }
        if (self.showErrorForm) {
            self.showErrorForm = false;
        }
    });

    self.ResetItems = function () {
        self.showErrorForm = false;
    }

    self.startbar = function () {
        cfpLoadingBar.start();
    };

    //  ENVIA FORMULARIO COMPLETO
    function SubmitForm() {
        if (self.State == undefined) {
            muestraError("Seleccione rango de fechas");
        }
        else if (self.State == 'Entre' && (self.date1 == undefined || self.date2 == undefined)) {
            muestraError("Seleccione las fechas");
        }
        else if (self.State == 'Entre' && (self.date1 > self.date2)) {
            muestraError("Rango de fechas erróneo");
        }
        else if (self.date1 == undefined || self.date1 == "") {
            muestraError("Seleccione una fecha");
        }
        else {
            var data = {
                ReportName: self.titulo,
                VAVClave: self.VAVClave,
                CEDIS: self.selectedItem.Clave,
                NameCEDIS: self.selectedItem.Nombre,
                StatusDate: self.State,
                //InitialDate: moment(self.date1).format('YYYY-MM-DD'),
                InitialDate: self.date1.toLocaleDateString(),
            }
            $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
            .then(function () {
                window.open(url + "/Reports/Ver");
                cfpLoadingBar.complete();
            });
        }
    }

    //MUESTRA UN MENSAJE DE ERROR
    function muestraError(cadena) {
        self.ErrorEnviar = cadena;
        self.showErrorForm = true;
        cfpLoadingBar.complete();
    }
}]);