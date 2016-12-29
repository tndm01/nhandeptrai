﻿
(function (app) {
    app.factory('apiService', apiService);

    apiService.$inject = ['$http', 'notificationService'];

    function apiService($http, notificationService)
    {
        return {
            get: get,
            post: post,
            put: put
        }

        function post(url, data, success, failure) {
            $http.post(url, data).then(function (resule) {
                success(result);
            }, function (error) {
                if (error.Status === '401') {
                    notificationService.displayError('Bạn không có quyền truy cập!');
                } else if (failure != null) {
                    failure(error);
                }
            });
        }


        function put(url, data, success, failure) {
            $http.put(url, data).then(function (resule) {
                success(result);
            }, function (error) {
                if (error.Status === '401') {
                    notificationService.displayError('Bạn không có quyền truy cập!');
                } else if (failure != null) {
                    failure(error);
                }
            });
        }

        function get(url, params, success, failure) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failure(result);
            });
        }
    }

})(angular.module('nnshop.common'));