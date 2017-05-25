
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
        $scope.flatFolders = [];

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
                $scope.parentCategories = commonService.getTree(result.data, "ID", "ParentID");
                $scope.parentCategories.forEach(function (item) {
                    recur(item, 0, $scope.flatFolders);
                });
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

        function times(n, str) {
            var result = '';
            for (var i = 0; i < n; i++) {
                result += str;
            }
            return result;
        };
        function recur(item, level, arr) {
            arr.push({
                Name: times(level, '–') + ' ' + item.Name,
                ID: item.ID,
                Level: level,
                Indent: times(level, '–')
            });
            if (item.children) {
                item.children.forEach(function (item) {
                    recur(item, level + 1, arr);
                });
            }
        };

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