﻿(function () {
    angular
        .module('eRouteApp')
        .controller('r263ImproductividadImgController', r263ImproductividadImgController)
    r263ImproductividadImgController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices", "valorReferencia"];

    function r263ImproductividadImgController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices, valorReferencia) {
        var url = window.sessionStorage.getItem('URL');
        var self = this;
        var countRoute = false;
        self.showCEDI = false;
        self.showList = false;
        self.showSelect = undefined;
        self.OnSelectChange = OnSelectChange;
        self.nShowLists = nShowLists;
        self.selectedItem = undefined;
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
            GetRoutes();
        }

        function GetCEDIS() {
            $http({
                url: url + '/API/GetModel/GetCEDIS',
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

        function nShowLists(cedi) {
            self.showList = (cedi == undefined ? false : true);
        }

        function GetDates() {
            $http({
                url: url + '/API/GetModel/GetDateStatus',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                self.dateState = response.data;
                self.State = self.dateState[0].Nombre;
            }, function errorCallBack(response) {
            });
        }

        function OnSelectChange(state) {
            if (state == 'Entre') {
                self.showSelect = 'true';
            }
            else {
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

        $scope.$watch("ctrl.date2", function () {
            if (self.State == "Entre" && self.date1 != undefined) {
                self.showErrorForm = false;
            }
        });

        $scope.$watch("RUTClave", function () {
            if (self.showErrorForm && $scope.RUTClave != undefined) {
                self.showErrorForm = false;
            }
        });

        function GetRoutes() {
            $http({
                url: url + '/API/GetModel/GetRoutes',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                self.routes = response.data;
            }, function errorCallBack(response) { });
        }

        self.startbar = function () {
            cfpLoadingBar.start();
        };

        function SubmitForm() {
            var rutas = [];

            if ($scope.RUTClave != undefined) {
                rutas = GetArrayValues(self.routes, $scope.RUTClave);
            }

            if (rutas.length <= 0) {
                muestraError("Seleccione una Ruta");
            }
            else if (self.State == undefined) {
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
                    InitialDate: self.date1,
                    FinalDate: self.date2,
                    Routes: rutas,
                }
                $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
                    .success(function (data, status, headers, config) {
                        window.open(url + "/Reports/Ver", "_blank");
                        cfpLoadingBar.complete();
                    })
                    .error(function (error, status, headers, config) {
                        cfpLoadingBar.complete();
                        muestraError("Status: " + status);
                    });
            }
        }

        function muestraError(cadena) {
            self.ErrorEnviar = cadena;
            self.showErrorForm = true;
            cfpLoadingBar.complete();
        }

        function GetArrayValues(Array, Clave) {
            var newArray = [];
            angular.forEach(Array, function (item) {
                if (item.Clave == Clave) {
                    newArray.push({ Clave: item.Clave, Nombre: item.Nombre, Checked: true, Disabled: false });
                }
            });
            return newArray;
        }
    }
})();