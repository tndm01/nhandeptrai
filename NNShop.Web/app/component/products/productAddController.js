
(function (app) {
    app.controller('productAddController', productAddController);

    productAddController.inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService']

    function productAddController(apiService, $scope, notificationService, $state, commonService) {
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
        $scope.AddProduct = AddProduct;

        function AddProduct() {
            $scope.products.MoreImages = JSON.stringify($scope.moreImages);
            apiService.post('/api/product/create', $scope.products,
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
                $scope.$apply(function () {
                    $scope.products.Image = fileUrl;
                })
            }
            finder.popup();
        }

        $scope.moreImages = [];
        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })
            }
            finder.popup();
        }

        loadParentCategory();
    }

})(angular.module('nnshop.products'));