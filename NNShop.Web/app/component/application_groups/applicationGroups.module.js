(function () {
    angular.module('nnshop.application_groups', ['nnshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('application_groups', {
            url: "/application_groups",
            templateUrl: "/app/component/application_groups/applicationGroupsListView.html",
            parent: 'base',
            controller: "applicationGroupsListController"
        }).state('add_application_group', {
            url: "/add_application_group",
            parent: 'base',
            templateUrl: "/app/component/application_groups/applicationGroupsAddView.html",
            controller: "applicationGroupsAddController"
        }).state('edit_application_group', {
            url: "/edit_application_group/:id",
            parent: 'base',
            templateUrl: "/app/component/application_groups/applicationGroupsEditView.html",
            controller: "applicationGroupsEditController"
        });
    }
})();