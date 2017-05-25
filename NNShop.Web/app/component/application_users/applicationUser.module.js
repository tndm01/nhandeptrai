(function () {
    angular.module('nnshop.application_users', ['nnshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('application_users', {
            url: "/application_users",
            templateUrl: "/app/component/application_users/applicationUserListView.html",
            parent: 'base',
            controller: "applicationUserListController"
        }).state('add_application_user', {
            url: "/add_application_user",
            parent: 'base',
            templateUrl: "/app/component/application_users/applicationUserAddView.html",
            controller: "applicationUserAddController"
        }).state('edit_application_users', {
            url: "/edit_application_users/:id",
            parent: 'base',
            templateUrl: "/app/component/application_users/applicationUserEditView.html",
            controller: "applicationUserEditController"
        });
    }
})();