(function (app) {
    app.controller('orderEditController', orderEditController);

    orderEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService', '$stateParams'];

    function orderEditController(apiService, $scope, notificationService, $state, commonService, $stateParams) {
        $scope.order = {};
        $scope.names = [];
        $scope.nameProduct = [];
        $scope.UpdateOrder = UpdateOrder;

        function UpdateOrder() {
            apiService.put('api/order/update', $scope.order,
                function (result) {
                    notificationService.displaySuccess(result.data.CustomerName + ' đã được cập nhật thành công!');
                    $state.go('orders');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công!');
                });
        }

        function loadDetailOrder() {
            apiService.get('api/order/getbyid/' + $stateParams.id, null, function (result) {
                $scope.order = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function loadNameProduct() {
            apiService.get('api/order/getbyname/' + $stateParams.id, null, function (response) {
                $scope.nameProduct = response.data;
                var name = [];
                $.each(response.data, function (i, item) {
                    name.push(item.Name);
                });
                $scope.nameProduct = name;
            }, function (response) {
                notificationService.displayError('Không thể tải dữ liệu');
            });
        }
        loadDetailOrder();
        loadNameProduct(); 
    }
})(angular.module('nnshop.orders'));