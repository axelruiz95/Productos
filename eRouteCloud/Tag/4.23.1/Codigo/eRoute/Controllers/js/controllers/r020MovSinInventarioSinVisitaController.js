﻿(function () {
    angular
        .module('eRouteApp')
        .controller('r020MovSinInventarioSinVisitaController', r020MovSinInventarioSinVisitaController)
    r020MovSinInventarioSinVisitaController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices", "valorReferencia"];

    function r020MovSinInventarioSinVisitaController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices, valorReferencia) {
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
        self.ReportType = false;
        $scope.TipoReporte = "General";

        $scope.EstablecerReporte = function (VAVClave) {
            valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
                self.titulo = result[0].Descripcion;
                self.showCEDI = (self.titulo == undefined ? false : true);
            });
            GetCEDIS();
            GetDates();
        }

        //  LLENAR CEDIS
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

        //  HABILITA LOS FILTROS
        function nShowLists(cedi) {
            self.showList = (cedi == undefined ? false : true);
        }

        //  FECHAS
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

        $scope.$watch("ctrl.date2", function () {
            if (self.State == "Entre" && self.date1 != undefined) {
                self.showErrorForm = false;
            }
        });

        ////    LLENAR VENDEDORES
        self.GETSeller = GETSeller;
        function GETSeller(selectedItem) {
            if (selectedItem != undefined) {
                $http({
                    url: url + '/API/GetModel/GetSellers',
                    method: 'GET',
                    headers: {
                        Authorization: window.sessionStorage.getItem('Token'),
                        'Content-Type': 'application/json'
                    },
                    params: { cedis: selectedItem }
                }).then(function successCallBack(response) {
                    self.seller = response.data;
                }, function errorCallBack(response) {

                });
            }
        }

        self.SelectAllChekboxesSellers = SelectAllChekboxesSellers;
        function SelectAllChekboxesSellers(selectAll) {
            checkedAllCombo(self.seller, selectAll);
        }

        self.CountSellers = function () {
            self.showErrorForm = false;
            var coun = countComboBoxElements($scope.selectAllSellers, $scope.querySeller, self.seller);
            $scope.selectAllSellers = coun[0];
            $scope.querySeller = coun[1];
        }

        self.startbar = function () {
            cfpLoadingBar.start();
        };

        //  ENVIA FORMULARIO COMPLETO
        function SubmitForm(Cedis, Vavclave) {
            var Seller = [];

            if (!$scope.selectAllSellers) {
                Seller = GetArrayValues(self.seller);
            }

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
                if ($scope.TipoReporte == "Detallado") {
                    self.ReportType = true;
                }
                else {
                    self.ReportType = false;
                }
                var data = {
                    ReportName: self.titulo,
                    VAVClave: self.VAVClave,
                    CEDIS: self.selectedItem.Clave,
                    NameCEDIS: self.selectedItem.Nombre,
                    StatusDate: self.State,
                    InitialDate: self.date1.toLocaleDateString(),
                    FinalDate: self.date2 ? self.date2.toLocaleDateString() : self.date2,
                    ReportType: self.ReportType,
                    Sellers: Seller,
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

        function GetArrayValues(Array) {
            var newArray = [];
            angular.forEach(Array, function (item) {
                if (item.Checked == true) {
                    newArray.push({ Clave: item.Clave, Nombre: item.Nombre, Checked: item.Checked, Disabled: item.Disabled });
                }
            });
            return newArray;
        }

        //MUESTRA UN MENSAJE DE ERROR
        function muestraError(cadena) {
            self.ErrorEnviar = cadena;
            self.showErrorForm = true;
            cfpLoadingBar.complete();
        }
    }
})();