
(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService', '$stateParams']

    function productEditController(apiService, $scope, notificationService, $state, commonService, $stateParams) {
        $scope.products = {
            CreatedDate: new Date(),
            Status: true
        }
        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px'
        }

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.products.Alias = commonService.getSeoTitle($scope.products.Name);
        }

        function loadProductDetail() {
            apiService.get('/api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.products = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        $scope.UpdateProduct = UpdateProduct;

        function UpdateProduct() {
            apiService.put('/api/product/update', $scope.products,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('products');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }

        function loadParentCategory() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.products.Image = fileUrl;
            }
            finder.popup();
        }
        loadParentCategory();
        loadProductDetail();
    }

})(angular.module('nnshop.products'));