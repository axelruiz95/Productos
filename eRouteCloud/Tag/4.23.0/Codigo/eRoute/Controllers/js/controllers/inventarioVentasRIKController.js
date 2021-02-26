﻿(function () {
    angular
        .module('eRouteApp')
        .controller('inventarioVentasRIKController', inventarioVentasRIKController)
    inventarioVentasRIKController.$inject = ['$scope', '$http', '$mdToast', '$q', '$timeout', 'NgMap', 'cfpLoadingBar', '$filter', "menuServices", "reportServices", "valorReferencia"];

    function inventarioVentasRIKController($scope, $http, $mdToast, $q, $timeout, NgMap, cfpLoadingBar, $filter, menuServices, reportServices, valorReferencia) {

        var ctrl = this;
        var url = window.sessionStorage.getItem('URL');

        ctrl.showList = false;
        ctrl.showSelect = undefined;
        ctrl.nShowLists = nShowLists;
        ctrl.selectedItem = ctrl.selectedItem;
        ctrl.OnSelectChange = OnSelectChange;
        ctrl.minDate = new Date();

        //muestra el segundo datepicker cuando el estado de la fecha es 'Entre'
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

        $scope.EstablecerReporte = function (VAVClave) {
            valorReferencia.obtenerValorClave('REPORTEW', VAVClave, function (result) {
                ctrl.titulo = result[0].Descripcion;
            });

            GetRoutes();
        }

        ////Cedis config
        //var load = [GetRoutes()]
        ////var load = [GetActivityList()]

        //$q.all(load).then(function () {
        //})

        var self = this;
        self.simulateQuery = false;
        self.isDisabled = false;
        self.querySearch = querySearch;
        self.selectedItemChange = selectedItemChange;
        self.searchTextChange = searchTextChange;

        //load maps on sidebar menu

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

        //function GetCedis() {
        //    $http({
        //        url: url + '/api/GetCedis?USUId=' + window.sessionStorage.getItem('USUId'),
        //        method: 'GET',
        //        headers: {
        //            Authorization: window.sessionStorage.getItem('Token'),
        //            'Content-Type': 'application/json'
        //        },
        //    }).then(function successCallBack(response) {
        //        self.states = loadAll(response.data);
        //    }, function errorCallBack(response) {

        //    });
        //}

        ////routes functions
        //ctrl.routes = GetRoutes();
        //ctrl.GetRoutes = GetRoutes;

        function GetRoutes() {
            $http({
                url: url + '/api/GetRoutes?Cedis=' + "",
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                ctrl.routes = response.data;                
            }, function errorCallBack(response) {


            });
        }


        //seller functions
        ctrl.group = 'Client';
        ctrl.GetClients = GetClients;

        function GetClients(Route) {
            Route = "'" + Route + "'";
            $http({
                url: url + '/api/GetClients?Id=Todos&Routes=' + Route + '&Cedis=' + "",
                method: 'GET',
                headers: {
                    Authorization: window.sessionStorage.getItem('Token'),
                    'Content-Type': 'application/json'
                },
            }).then(function successCallBack(response) {
                ctrl.clients = response.data;
            }, function errorCallBack(response) {

            });
        }

        //dates state functions
        ctrl.State = undefined;
        ctrl.dateState = GetDates();
        

        function GetDates() {
            valorReferencia.obtenerValorClave('BFNUMERI', '1', function (result) {
                ctrl.State = 1;
                ctrl.dateState = result;
                
            });            
        }

        
        ctrl.SubmitForm = SubmitForm;
        ctrl.Fecha = undefined;
        ctrl.RUTClave = "";
        ctrl.VAVClave = undefined;
        ctrl.ReportType = false;

        ctrl.startbar = function () {
            cfpLoadingBar.start();
        };

        ctrl.completebar = function () {
            cfpLoadingBar.complete();
        };

        //envia el formulario completo
        function SubmitForm(Route, Clientes) {
            //console.log(ctrl.State);
            var countClients;
            countClients = 0;
            angular.forEach(ctrl.clients, function (item) {

                if (item.Checked == true) {
                    countClients++;
                }
            });

            var countRoutes;
            countRoutes = 0;
            angular.forEach(ctrl.routes, function (item) {
                if (item.RUTClave == Route) {
                    item.Checked = true;
                    countRoutes++;
                }
                else {
                    item.Checked = false;
                }
            });

           

            if (countRoutes <= 0) {
                alert("Seleccione una Ruta");
                cfpLoadingBar.complete();
            }
            else if (ctrl.date1 == undefined) {
                alert("Seleccione fecha");
                cfpLoadingBar.complete();
            }
            else {
                var data = {
                    nombreReport: ctrl.titulo,
                    //Cedis: ctrl.selectedItem.value,
                    //nombreCedis: ctrl.selectedItem.display,
                    dateStatus: ctrl.State,
                    Routes: ctrl.routes,
                    Clientes: Clientes,
                    //Seller: ctrl.sellers,
                    init: ctrl.date1,
                    //end: ctrl.date2,
                    vavclave: ctrl.VAVClave,
                    reportType: ctrl.ReportType
                }
                if (data.Cedis == undefined)
                    data.Cedis = "";

                $http.post(url + '/Reports/GetCondition', data, { ignoreLoadingBar: true })
                .success(function (data, status, headers, config) {
                    window.open(url + "/Reports/Ver", "_blank");
                    cfpLoadingBar.complete();
                })
                .error(function (error, status, headers, config) {
                });
            }
        }
        ctrl.SelectAllCheckboxesClients = SelectAllCheckboxesClients;
        function SelectAllCheckboxesClients(selectAll) {
            if (selectAll == undefined || selectAll == false) {
                angular.forEach(ctrl.clients, function (item) {
                    item.Checked = true;
                });
            }

            else {
                angular.forEach(ctrl.clients, function (item) {
                    item.Checked = false;
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