/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('nnshop.products', ['nnshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products', {
            url: "/products",
            parent: 'base',
            templateUrl: "/app/component/products/productListView.html",
            controller: "productListController"

        }).state('product_add', {
            url: "/product_add",
            parent: 'base',
            templateUrl: "/app/component/products/productAddView.html",
            controller: "productAddController"

        }).state('product_edit', {
            url: "/product_edit/:id",
            parent: 'base', 
            templateUrl: "/app/component/products/productEditView.html",
            controller: "productEditController"
        });
    }
})();
