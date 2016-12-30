/// <reference path="/Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('nnshop',
        ['nnshop.products'
            , 'nnshop.common'
            , 'nnshop.product_categories']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/component/home/homeView.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise('/admin')
    }
})();