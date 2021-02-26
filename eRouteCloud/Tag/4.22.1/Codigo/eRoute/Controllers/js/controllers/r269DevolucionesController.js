﻿app.controller('r269DevolucionesController', ['valorReferencia', '$http', 'cfpLoadingBar', function (valorReferencia, $http, cfpLoadingBar) {
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
            url: url + '/API/GetModel/GetCEDIS',
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
            url: url + '/API/GetModel/GetDateStatus',
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

    //Llenar Rutas
    self.GetRoutes = function (selectedItem) {
        self.queryRoute = '';
        self.routes = undefined;
        self.selectAllRoutes = false;
        $http({
            url: url + '/API/GetModel/GetRoutes?cedis=' + selectedItem.replace(/\+/g, '%2B'),
            method: 'GET',
            headers: {
                Authorization: window.sessionStorage.getItem('Token'),
                'Content-Type': 'application/json'
            },
        }).then(function successCallBack(response) {
            self.routes = response.data;
        });
    }

    self.CountRoutes = function () {
        self.queryRoute = '';
        var count = 0;
        var routes = [];
        angular.forEach(self.routes, function (item) {
            if (item.Checked) {
                count++;
                routes.push(item.Clave);
            }
        });
        if (count !== 0) {
            if (count !== self.routes.length) {
                self.selectAllRoutes = false;
            } else if (count === self.routes.length) {
                self.selectAllRoutes = true;
            }
        }
    }

    //Seleccionar todas las Rutas
    self.SelectAllCheckboxesRoutes = function (selectAll) {
        self.queryRoute = '';
        if (selectAll === undefined || selectAll === false) {
            angular.forEach(self.routes, function (item) {
                item.Checked = true;
            });
        } else {
            angular.forEach(self.routes, function (item) {
                item.Checked = false;
            });
        }
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

    //Envia formulario completo
    self.Submit = function () {
        cfpLoadingBar.start();
        var routes = [];
        var date1 = self.startDate;
        if (!self.selectAllRoutes) {
            routes = GetArrayValues(self.routes);
        }

        if (routes.length <= 0 && !self.selectAllRoutes) {
            ErrorMessage('*Seleccione una Ruta');
        } else if (self.State === undefined) {
            ErrorMessage('*Seleccione rango de fechas');
        } else if (self.State === 'Entre' && (self.startDate === undefined || self.endDate === undefined)) {
            ErrorMessage('*Seleccione las fechas');
        } else if (self.State === 'Entre' && (self.endDate <= self.startDate)) {
            ErrorMessage('*Rango de fechas erróneo');
        } else if (self.startDate === undefined) {
            ErrorMessage('*Seleccione la fecha');
        } else {
            routes = (self.selectAllRoutes ? null : routes);
            var data = {
                CEDIS: self.selectedItem.Clave,
                NameCEDIS: self.selectedItem.Nombre,
                ReportName: self.title,
                InitialDate: moment(self.startDate).format('YYYY-MM-DD'),
                FinalDate: moment(self.endDate).format('YYYY-MM-DD'),
                VAVClave: self.VAVClave,
                Routes: routes
            }
            $http.post(url + '/Reports/SetCondition', data, { ignoreLoadingBar: true })
            .then(function () {
                window.open(url + '/Reports/Ver');
                cfpLoadingBar.complete();
            });
        }
    }
}]);