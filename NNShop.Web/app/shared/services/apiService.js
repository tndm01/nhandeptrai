/// <reference path="Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.factory('apiService', apiService);

    apiService.$inject = ['$http', 'notificationService', 'authenticationService'];

    function apiService($http, notificationService, authenticationService) {
        return {
            get: get,
            post: post,
            put: put,
            del: del
        }

        // Hàm post Create
        function post(url, data, success, failure) {
            authenticationService.setHeader();
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                    notificationService.displayError('Bạn không có quyền.');
                }
                else if (failure != null) {
                    failure(error);
                }

            });
        }

        //Hàm put Update
        function put(url, data, success, failure) {
            authenticationService.setHeader();
            $http.put(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                    notificationService.displayError('Bạn không có quyền!');
                }
                else if (failure != null) {
                    failure(error);
                }
            });
        }

        // Hàm delete 
        function del(url, data, success, failure) {
            authenticationService.setHeader();
            $http.delete(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                    notificationService.displayError('Bạn không có quyền!');
                }
                else if (failure != null) {
                    failure(error);
                }
            });
        }

        //Hàm get
        function get(url, params, success, failure) {
            authenticationService.setHeader();
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                    notificationService.displayError('Bạn không có quyền!');
                }
                else if (failure != null) {
                    failure(error);
                }
            });
        }
    }

})(angular.module('nnshop.common'));