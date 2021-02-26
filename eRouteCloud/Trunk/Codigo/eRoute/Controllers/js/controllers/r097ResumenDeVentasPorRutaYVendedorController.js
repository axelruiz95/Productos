﻿app.controller('r097ResumenDeVentasPorRutaYVendedorController', ['valorReferencia', '$http', 'cfpLoadingBar', function (valorReferencia, $http, cfpLoadingBar) {
    var url = window.sessionStorage.getItem('URL');
    var self = this;
    self.todayDate = new Date();

    self.StartReport = function (VAVClave) {
        valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            self.title = result[0].Descripcion;
            self.VAVClave = VAVClave;
            GetCEDIS();
        });
    }

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
        });
    }

    self.QuerySearch = function (query) {
        var results = query ? self.cedis.filter(createFilterFor(query)) : self.cedis;
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

    //Fechas
    self.GetDates = function () {
        self.showErrorForm = false;
        self.State = undefined;
        self.startDate = undefined;
        self.endDate = undefined;
        self.showSelect = false;
        self.dateState = undefined;
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
            self.OnSelectChange(self.State, 0);
        });
    }

    //Estado del rango de fecha
    self.OnSelectChange = function (state, date) {
        self.showErrorForm = false;
        if (date === 0) {
            self.startDate = self.todayDate;
        }
        if (state === 'Entre') {
            self.showSelect = true;
        } else {
            self.showSelect = false;
        }
        self.endDate = self.startDate;
    }

    function ErrorMessage(message) {
        self.ShowError = message;
        self.showErrorForm = true;
        cfpLoadingBar.complete();
    }

    function GetArrayValues(Array, otro) {
        var newArray = [];
        angular.forEach(Array, function (item) {
            if (otro !== undefined) {
                if (item.Clave === otro) {
                    newArray.push({ Clave: item.Clave, Nombre: item.Nombre, Checked: true, Disabled: false });
                }
            } else {
                if (item.Checked === true) {
                    newArray.push({ Clave: item.Clave, Nombre: item.Nombre, Checked: item.Checked, Disabled: item.Disabled });
                }
            }
        });
        return newArray;
    }

    self.GetEsquemasPro = GetEsquemasPro();
    function GetEsquemasPro(selectedItem) {
        (selectedItem == undefined ? null : selectedItem.replace(/\+/g, "%2B"));

        $http({
            url: url + '/API/GetReportFilters/GetSchemes',
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
            params: { cedis: selectedItem, state: 1, types: 2, levels: 2, schemesID: null }
        }).then(function successCallBack(response) {
            self.schemesPro = response.data;
        }, function errorCallBack(response) { });

    }

    ////Seleccionar todos los Esquemas de Productos
    self.SelectAllChekboxesSchemesPro = SelectAllChekboxesSchemesPro;
    function SelectAllChekboxesSchemesPro(selectAll) {
        checkedAllCombo(self.schemesPro, selectAll);
    }

    self.CountSchemesProducts = function () {
        var coun = countComboBoxElements($scope.selectAllSchemesPro, $scope.querySchemesPro, self.schemesPro);
        $scope.selectAllSchemesPro = coun[0];
        $scope.querySchemesPro = coun[1];
    }

    //Envia formulario completo
    self.Submit = function () {
        cfpLoadingBar.start();
        if (self.State === undefined) {
            ErrorMessage("*Seleccione rango de fechas");
        } else if (self.State === 'Entre' && (self.startDate === undefined || self.endDate === undefined)) {
            ErrorMessage("*Seleccione las fechas");
        } else if (self.State === 'Entre' && (self.endDate <= self.startDate)) {
            ErrorMessage("*Rango de fechas erróneo");
        } else if (self.startDate === undefined) {
            ErrorMessage("*Seleccione la fecha");
        } else {
            var EsquemaPro = GetArrayValues(self.schemesPro);
            var data = {
                CEDIS: self.selectedItem.Clave,
                NameCEDIS: self.selectedItem.Nombre,
                ReportName: self.title,
                InitialDate: moment(self.startDate).format('YYYY-MM-DD'),
                FinalDate: moment(self.endDate).format('YYYY-MM-DD'),
                VAVClave: self.VAVClave,
                ProductSchemes: EsquemaPro
            }
            $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
            .then(function () {
                window.open(url + "/Reports/Ver");
                cfpLoadingBar.complete();
            });
        }
    }

    //Seleccionar todos los elementos del Combo (TRUE OR FALSE)
    function checkedAllCombo(Array, selectAll) {
        if (selectAll == undefined) {
            selectAll = false;
        }
        angular.forEach(Array, function (item) {
            item.Checked = selectAll;
        });
    }

    function countComboBoxElements(modelAll, queryFilter, Array) {
        queryFilter = "";
        var count = 0;
        angular.forEach(Array, function (item) {
            if (item.Checked) {
                count++;
            }
        });
        if (count != Array.length) {
            modelAll = false;
        } else if (count == Array.length) {
            modelAll = true;
        }
        return [modelAll, queryFilter];
    }
}]);