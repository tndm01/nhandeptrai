﻿(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);

    productCategoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService']

    function productCategoryEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true
        }
        $scope.flatFolders = [];
        $scope.UpdateProductCategory = UpdateProductCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        function loadProductCategoryDetail() {
            apiService.get('/api/productcategory/getbyid/' + $stateParams.id, null, function (result) {
                $scope.productCategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdateProductCategory() {
            apiService.put('/api/productCategory/update', $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('product_categories');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        function loadParentCategory() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
                $scope.parentCategories = commonService.getTree(result.data, "ID", "ParentID");
                $scope.parentCategories.forEach(function (item) {
                    recur(item, 0, $scope.flatFolders);
                });
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        
        loadProductCategoryDetail();
        loadParentCategory();
    }

})(angular.module('nnshop.product_categories'));