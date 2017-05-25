(function (app) {
    app.controller('orderListController', orderListController);

    orderListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function orderListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.order = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.getOrder = getOrder;

        $scope.deleteMultiple = deleteMultiple;
        $scope.selectAll = selectAll;
        $scope.deleteOrder = deleteOrder;
        $scope.search = search;

        function search() {
            getOrder();
        }

        function deleteOrder(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa không?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/order/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công!');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                });
            });
        }

        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.order, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.order, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        function deleteMultiple() {
            var listId = [];
            $each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            var config = {
                params: {
                    strId: JSON.stringify(listId)
                }
            }
            apiService.del('api/order/deletemulti', config, null, function (result) {
                notificationService.displaySuccess('Xóa thành công' + result.data + ' bản ghi');
                search();
            }, function (error) {
                notificationService.displayError('Xóa không thành công!');
            });
        }

        function getOrder(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('api/order/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                $scope.order = result.data.Items;
                $scope.page = result.data.Pages;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load Order Failed')
            });
        }

        $scope.getOrder();
    }
})(angular.module('nnshop.orders'));