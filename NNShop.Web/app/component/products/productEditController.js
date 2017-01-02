(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService', '$stateParams'];

    function productEditController(apiService, $scope, notificationService, $state, commonService, $stateParams) {
        $scope.products = {};
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }
        $scope.UpdateProduct = UpdateProduct;
        $scope.moreImages = [];
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.products.Alias = commonService.getSeoTitle($scope.products.Name);
        }

        function loadProductDetail() {
            apiService.get('api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.products = result.data;
                $scope.moreImages = JSON.parse($scope.products.MoreImages);
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        function UpdateProduct() {
            $scope.products.MoreImages = JSON.stringify($scope.moreImages)
            apiService.put('api/product/update', $scope.products,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('products');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }
        function loadProductCategory() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        }
        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })

            }
            finder.popup();
        }
        loadProductCategory();
        loadProductDetail();
    }

})(angular.module('nnshop.products'));