﻿(function () {
    angular
        .module('eRouteApp')
        .controller('comparativoVentaMensualMooController', comparativoVentaMensualMooController)
    comparativoVentaMensualMooController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices"];

    function comparativoVentaMensualMooController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices) {

        var ctrl = this;
        var url = window.sessionStorage.getItem('URL');

        ctrl.url = undefined;
        ctrl.showList = false;
        ctrl.showSelect = undefined;
        ctrl.nShowLists = nShowLists;
        ctrl.selectedItem = ctrl.selectedItem;
        ctrl.OnSelectChange = OnSelectChange;
        ctrl.minDate = new Date();
        ctrl.GetList;


        GetList();
        function GetList() {
            menuServices.getReportList()
                .then(function successCallback(response) {
                    ctrl.GetList = response.data;
                },
                function errorCallback(response) {
                    if (response.status == 401) {
                        window.sessionStorage.clear();
                        window.location = url + '/Login';
                    }
                });
        }



        function OnSelectChange(state) {
            if (state == 'Entre') {
                ctrl.showSelect = 'true';
            }
            else {
                ctrl.showSelect = undefined;
            }
        }

        function nShowLists(state) {
            if (state == undefined) {
                ctrl.showList = undefined;
            }
            else {
                ctrl.showList = 'true';
            }
        }


        var self = this;
        self.simulateQuery = false;
        self.isDisabled = false;
        self.querySearch = querySearch;
        self.selectedItemChange = selectedItemChange;
        self.searchTextChange = searchTextChange;


        function querySearch(query) {

            var results = query ? self.states.filter(createFilterFor(query)) : self.states,
                deferred;

            if (self.simulateQuery) {
                deferred = $q.defer();
                $timeout(function () { deferred.resolve(results); }, Math.random() * 1000, false);
                return deferred.promise;
            } else {
                return results;
            }
        }

        function createFilterFor(query) {
            var lowercaseQuery = angular.lowercase(query);
            return function filterFn(state) {
                return (state.value.indexOf(lowercaseQuery) === 0);
            };
        }

        function searchTextChange(text) {
            //console.log('Text changed to ' + text);
        }

        function selectedItemChange(item) {
            $log.info('Item changed to ' + JSON.stringify(item));
        }

        function loadAll(s) {
            var allstates = s;
            return allstates.toString().split(',').map(function (state) {
                return {
                    value: state.toString().substr(0, state.indexOf(' ')),
                    display: state
                };
            });
        }

        //Cedis config
        var load = [GetCedis()]
        //var load = [GetActivityList()]

        $q.all(load).then(function () {
        })

        //dates state functions
        ctrl.State = undefined;
        ctrl.dateState = GetDates();

        function GetDates() {
            $http({
                url: url + '/api/GetDateStatus',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                ctrl.dateState = response.data;
            }, function errorCallBack(response) {

            });
        }

        function GetCedis() {
            $http({
                url: url + '/api/GetCedis',
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
                params: { USUId: window.sessionStorage.getItem('USUId') }
            }).then(function successCallBack(response) {
                //  self.states = loadAll(response.data);
                self.states = response.data;
            }, function errorCallBack(response) {

            });
        }

        ctrl.SubmitForm = SubmitForm;
        ctrl.date1 = undefined;
        ctrl.date2 = undefined;
        ctrl.pvEsFecha = false;
        ctrl.VAVClave = undefined;
        ctrl.ReportType = false;
        ctrl.UnidadMedida = "Cartones";

        ctrl.startbar = function () {
            cfpLoadingBar.start();
        };

        ctrl.completebar = function () {
            cfpLoadingBar.complete();
        };

        //envia el formulario completo
        function SubmitForm(Cedis, dateStatus, Routes, Clientes, pvEsFecha, campoFecha) {
            var countRoutes;
            angular.forEach(ctrl.routes, function (item) {

                if (item.Checked == true) {
                    countRoutes++;
                }
            });

            var countSellers;
            angular.forEach(ctrl.sellers, function (item) {

                if (item.Checked == true) {
                    countSellers++;
                }
            });

            if (ctrl.selectedItem == undefined || ctrl.selectedItem == null) {
                ctrl.selectedItem = {};
            }
            else if (ctrl.date1 == undefined || ctrl.date2 == undefined) {
                alert("Seleccion una Fecha Inicial y una Fecha Final");
                cfpLoadingBar.complete();
            }
            else if (ctrl.date1 > ctrl.date2) {
                alert("La Fecha Final debe ser mayor a la Fecha Inicial");
                cfpLoadingBar.complete();
            }
            else if (/*ctrl.date1.getFullYear() != ctrl.date2.getFullYear() || */ ctrl.date1.getMonth() != ctrl.date2.getMonth()) {
                alert("Las Fechas seleccionadas deben pertenecer al mismo Mes");
                cfpLoadingBar.complete();
            }
            else {
                ctrl.nombreReport = $filter("filter")(ctrl.GetList, { VAVClave: ctrl.VAVClave })[0].Descripcion;
                var data = {
                    nombreReport: ctrl.nombreReport,
                    Cedis: ctrl.selectedItem.value,
                    nombreCedis: ctrl.selectedItem.display,
                    dateStatus: ctrl.State,
                    Routes: Routes,
                    init: ctrl.date1,
                    end: ctrl.date2,
                    vavclave: ctrl.VAVClave,
                    reportType: ctrl.ReportType,
                    unidadMedida: ctrl.UnidadMedida
                }

                $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                .then(function successCallBack(response) {
                    //console.log(response);
                    //window.open(url + "/Reports/Ver?VAVClave=" + response.data.VAVClave + "&Cedis=" + response.data.Cedis + "&nombreReport=" + response.data.nombreReport + "&nombreCedis=" + response.data.nombreCedis + "&FechaInicial=" + response.data.FechaInicial + "&FechaFinal=" + response.data.FechaFinal + "&dateStatus=" + response.data.Rango + "&Rutas=" + response.data.Rutas + "&Clientes=" + response.data.Clientes + "&Vendedor=" + response.data.Vendedor + "&detallado=" + response.data.reportType + "&unidadMedida=" + response.data.unidadMedida, "_blank");
                    //$http({
                    //    url: url + '/Reports/Ver',
                    //    method: 'POST',
                    //    headers: {
                    //        Authorization: window.sessionStorage.getItem('Token'),
                    //        'Content-Type': 'application/json'
                    //    },
                    //    data: {
                    //        VAVClave: response.data.VAVClave,
                    //        Cedis: response.data.Cedis,
                    //        nombreReport: response.data.nombreReport,
                    //        nombreCedis: response.data.nombreCedis,
                    //        FechaInicial: response.data.FechaInicial,
                    //        FechaFinal: response.data.FechaFinal,
                    //        dateStatus: response.data.Rango,
                    //        Rutas: response.data.Rutas,
                    //        Clientes: response.data.Clientes,
                    //        Vendedor: response.data.Vendedor,
                    //        detallado: response.data.reportType,
                    //        unidadMedida: response.data.unidadMedida
                    //    }
                    //}).then(function successCallBack(response) {
                    //    console.log(response);
                    //}, function errorCallBack(response) {
                    //});
                    window.open(url + "/Reports/Ver?VAVClave=" + response.data.VAVClave + "&Cedis=" + response.data.Cedis.replace(/\+/g, "%2B") + "&nombreReport=" + response.data.nombreReport + "&nombreCedis=" + response.data.nombreCedis + "&FechaInicial=" + response.data.FechaInicial + "&FechaFinal=" + response.data.FechaFinal + "&dateStatus=" + response.data.Rango + "&Rutas=" + response.data.Rutas + "&Clientes=" + response.data.Clientes + "&Vendedor=" + response.data.Vendedor + "&detallado=" + response.data.reportType + "&unidadMedida=" + response.data.unidadMedida, "_blank");
                    cfpLoadingBar.complete();
                }, function errorCallBack(response) {

                });
            }
        }



        var last = { bottom: true, top: false, left: true, right: false };


        //toast
        $scope.toastPosition = angular.extend({}, last);

        $scope.getToastPosition = function () {
            sanitizePosition();
            return Object.keys($scope.toastPosition)
              .filter(function (pos) { return $scope.toastPosition[pos]; })
              .join(' ');
        };

        function sanitizePosition() {
            var current = $scope.toastPosition;
            if (current.bottom && last.top) current.top = false;
            if (current.top && last.bottom) current.bottom = false;
            if (current.right && last.left) current.left = false;
            if (current.left && last.right) current.right = false;
            last = angular.extend({}, current);
        }

        function showSimpleToast(Message) {
            var pinTo = $scope.getToastPosition();
            $mdToast.show(
              $mdToast.simple()
                .textContent(Message)
                .position(pinTo)
                .hideDelay(3000)
            );
        };

    }
})();