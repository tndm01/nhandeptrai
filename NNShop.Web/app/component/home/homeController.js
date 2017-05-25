(function (app) {
    app.controller('homeController', homeController);

    homeController.$inject = ['authData', '$state', 'authenticationService'];

    function homeController(authData, $state, authenticationService) {
        var userName = authData.authenticationData.userName;
        if (userName == "") {
            $state.go('login');
        }
    }
})(angular.module('nnshop'));