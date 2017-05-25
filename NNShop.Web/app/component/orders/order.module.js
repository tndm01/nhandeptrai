/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('nnshop.orders', ['nnshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('orders', {
            url: "/orders",
            parent: 'base',
            templateUrl: "/app/component/orders/orderListView.html",
            controller: "orderListController"

        }).state('orders_edit', {
            url: "/orders_edit/:id",
            parent: 'base',
            templateUrl: "/app/component/orders/orderEditView.html",
            controller: "orderEditController"
        });
    }
})();
