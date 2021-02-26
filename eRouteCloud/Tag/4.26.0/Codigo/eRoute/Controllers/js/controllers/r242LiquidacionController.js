﻿app.controller('r242LiquidacionController', ['$scope', '$mdToast', '$q', '$timeout', 'valorReferencia', '$http', 'cfpLoadingBar', function ($scope, $mdToast, $q, $timeout, valorReferencia, $http, cfpLoadingBar) {
    var url = window.sessionStorage.getItem('URL');
    var self = this;
    self.showList = false;
    self.minDate = new Date();

    $scope.EstablecerReporte = function (VAVClave) {
        valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
            self.titulo = result[0].Descripcion;
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
        }, function errorCallBack(response) {
        });
    }

    self.QuerySearch = function (query) {
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

    self.ShowItems = function (selectedItem) {
        self.showErrorForm = false;
        if (selectedItem == undefined) {
            self.showList = false;
        } else {
            self.showList = true;
        }
    }

    //Fechas
    self.GetDates = function () {
        self.showErrorForm = false;
        self.State = undefined;
        self.date1 = undefined;
        self.dateState = null;
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
            self.date1 = self.minDate;
        }, function errorCallBack(response) {
        });
    }

    //Llenar Vendedores
    self.GetSellers = function (selectedItem) {
        if (selectedItem != undefined) {
            $scope.querySeller = '';
            self.sellers = undefined;
            $scope.selectAllSellers = false;
            $http({
                url: url + '/API/GetReportFilters/GetSellers?cedis=' + selectedItem.replace(/\+/g, "%2B"),
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                self.sellers = response.data;
            }, function errorCallBack(response) {
            });
        }
    }

    self.CountSellers = function () {
        $scope.querySeller = '';
        var count = 0;
        var sellers = [];
        angular.forEach(self.sellers, function (item) {
            if (item.Checked) {
                count++;
                sellers.push(item.Clave);
            }
        });
        if (count != 0) {
            if (count != self.sellers.length) {
                $scope.selectAllSellers = false;
            } else if (count == self.sellers.length) {
                $scope.selectAllSellers = true;
            }
        }
    }

    //Seleccionar todos los Vendedores
    self.SelectAllCheckboxesSellers = function (selectAllSellers) {
        $scope.querySeller = '';
        if (selectAllSellers == undefined || selectAllSellers == false) {
            angular.forEach(self.sellers, function (item) {
                item.Checked = true;
            });
        } else {
            angular.forEach(self.sellers, function (item) {
                item.Checked = false;
            });
        }
    }

    function GetArrayValues(Array, otro) {
        var newArray = [];
        angular.forEach(Array, function (item) {
            if (otro != undefined) {
                if (item.Clave == otro) {
                    newArray.push({ Clave: item.Clave, Nombre: item.Nombre, Checked: true, Disabled: false });
                }
            } else {
                if (item.Checked == true) {
                    newArray.push({ Clave: item.Clave, Nombre: item.Nombre, Checked: item.Checked, Disabled: item.Disabled });
                }
            }
        });
        return newArray;
    }

    self.startbar = function () {
        cfpLoadingBar.start();
    };

    function ErrorMessage(cadena) {
        self.ShowError = cadena;
        self.showErrorForm = true;
        cfpLoadingBar.complete();
    }

    //Envia formulario completo
    self.SubmitForm = function () {
        var vendedores = [];
        if (!$scope.selectAllSellers) {
            vendedores = GetArrayValues(self.sellers);
        }

        if (vendedores.length <= 0 && !$scope.selectAllSellers) {
            ErrorMessage("*Seleccione un Vendedor");
        } else if (self.date1 == undefined) {
            ErrorMessage("*Seleccione la fecha");
        } else {
            vendedores = ($scope.selectAllSellers ? null : vendedores);
            var data = {
                NameCEDIS: self.selectedItem.Nombre,
                ReportName: self.titulo,
                InitialDate: moment(self.date1).format('YYYY-MM-DD'),
                VAVClave: self.VAVClave,
                Sellers: vendedores
            }
            $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
                .then(function () {
                    window.open(url + '/Reports/Ver');
                    cfpLoadingBar.complete();
                });
        }
    }
}]);