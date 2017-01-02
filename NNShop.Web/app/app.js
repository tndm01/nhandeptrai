/// <reference path="/Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('nnshop',
        ['nnshop.products'
            , 'nnshop.common'
            , 'nnshop.product_categories']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/app/shared/views/baseView.html',
                abstract: true
            })
            .state('login', {
                url: "/login",
                templateUrl: "/app/component/login/loginView.html",
                controller: "loginController"
            })
            .state('home', {
                url: "/admin",
                parent: 'base',
                templateUrl: "/app/component/home/homeView.html",
                controller: "homeController"
            });
        $urlRouterProvider.otherwise('/login')
    }
})();