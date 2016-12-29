/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('nnshop.product_categories', ['nnshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('product_categories', {
            url: "/product_categories",
            templateUrl: "/app/component/product_categories/productCategoryListView.html",
            controller: "productCategoryListController"
        }).state('product_category_add', {
            url: "/product_category_add",
            templateUrl: "/app/component/product_categories/productCategoryAddView.html",
            controller: "productCategoryAddController"
        }).state('product_category_edit', {
            url: "/product_category_edit/:id",
            templateUrl: "/app/component/product_categories/productCategoryEditView.html",
            controller: "productCategoryEditController"
        });
    }
})();