(function () {
    angular.module('nnshop.statistic', ['nnshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('statistic_revenue', {
            url: "/statistic",
            parent: 'base',
            templateUrl: "/app/component/statistic/revenueStatisticView.html",
            controller: "revenueStatisticController"
        });
    }
})();