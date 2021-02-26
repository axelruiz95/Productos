﻿(function () {
    angular
        .module('eRouteApp')
        .controller('promocionesNvoMORController', promocionesNvoMORController)
    promocionesNvoMORController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices", "valorReferencia"];

    function promocionesNvoMORController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices, valorReferencia) {

        //Inicialización de variables
        var ctrl = this;
        var url = window.sessionStorage.getItem('URL');
        ctrl.url = undefined;
        ctrl.showList = false;
        ctrl.showSelect = undefined;
        ctrl.nShowLists = nShowLists;
        ctrl.selectedItem = ctrl.selectedItem;
        ctrl.OnSelectChange = OnSelectChange;
        ctrl.minDate = new Date();

        ctrl.SubmitForm = SubmitForm;
        ctrl.date1 = undefined;
        ctrl.pvEsFecha = false;
        ctrl.VAVClave = undefined;
        ctrl.ReportType = false;
        ctrl.ObjetivoVentaMensualCajas = undefined;
        ctrl.ObjetivoVisitasEfectivas = undefined;

        var self = this;
        self.simulateQuery = false;
        self.isDisabled = false;
        self.querySearch = querySearch;
        self.selectedItemChange = selectedItemChange;
        self.searchTextChange = searchTextChange;

        //Carga la lista de CEDIS
        var load = [GetCedis()]
        $q.all(load).then(function () {
        })

        //muestra el segundo datepicker cuando el estado actual de la fecha sea 'entre'
        function OnSelectChange(state) {
            if (state == 'Entre') {
                ctrl.showSelect = 'true';
            }
            else {
                ctrl.showSelect = undefined;
            }
        }

        function nShowLists(state) {
            if (state === undefined) {
                ctrl.showList = undefined;
            }
            else {
                ctrl.showList = 'true';
            }
        }

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
                self.dateState = response.data;
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
                self.states = response.data;
            }, function errorCallBack(response) {

            });
        }

        ctrl.startbar = function () {
            cfpLoadingBar.start();
        };

        ctrl.completebar = function () {
            cfpLoadingBar.complete();
        };

        ctrl.sellers = GetSellers();
        ctrl.GetSellers = GetSellers;

        function GetSellers(selectedItem) {
            if (selectedItem == undefined)
                selectedItem = "";
            $http({
                url: url + '/api/GetSeller?Cedis=' + selectedItem.replace(/\+/g, "%2B"),
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                ctrl.sellers = response.data;
            }, function errorCallBack(response) {

            });
        }

        function SubmitForm() {
        
            angular.forEach(ctrl.sellers, function (item) {
                if (item.VendedorId == ctrl.VendedorId) {
                    item.Checked = true;
                }
                else {
                    item.Checked = false;
                }
            });

            if (ctrl.State === undefined) {
                alert("Seleccione rango de fechas");
                cfpLoadingBar.complete();
            }
            else if (ctrl.State == 'Entre' && (ctrl.date1 == undefined || ctrl.date2 == undefined)) {
                alert("Seleccione un rango de fechas");
                cfpLoadingBar.complete();
            }
            else if (ctrl.date1 == undefined) {
                alert("Seleccione una fecha");
                cfpLoadingBar.complete();
            }
            else {
                var data = {
                    Cedis: ctrl.selectedItem.value,
                    nombreCedis: ctrl.selectedItem.display,
                    dateStatus: ctrl.State, 
                    Seller: ctrl.sellers,
                    init: ctrl.date1,
                    end: ctrl.date2,
                    vavclave: ctrl.VAVClave,
                    reportType: ctrl.ReportType
                }

                $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                    .success(function (data, status, headers, config) {
                        window.open(url + "/Reports/Ver?VAVClave=" + data.VAVClave + "&Cedis=" + data.Cedis.replace(/\+/g, "%2B") + "&nombreReport=" + data.nombreReport + "&nombreCedis=" + data.nombreCedis + "&FechaInicial=" + data.FechaInicial + "&FechaFinal=" + data.FechaFinal + "&dateStatus=" + data.Rango + "&Vendedor=" + data.Vendedor + "&detallado=false", "_blank")
                        cfpLoadingBar.complete();
                    })
                    .error(function (error, status, headers, config) {
                        console.log(error);
                    });
            }
        }
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
    }
})();