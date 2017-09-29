(function (app) {
    app.controller("productEditController", productEditController);
    function productEditController() {

    }
})(angular.module("productapp.product"));

(function (app) {
    app.controller("productEditController", productEditController);

    productEditController.$inject = ["$scope", '$state', "apiService", "notifyService"];
    function productEditController($scope, $state, apiService, notifyService) {
        $scope.category = "Phone";
        $scope.listSupplier = [];
        $scope.product = {
        };

        $scope.updateProduct = updateProduct;

        function loadSupplier() {
            apiService.get("http://localhost:5260/api/Supplier/GetAll", null, function (result) {
                $scope.listSupplier = result.data.elements;
                if ($scope.totalCount == 0) {
                    notifyService.displayWarning('Không tìm thấy dữ liệu!');
                }
            }, function (error) {
                $scope.error = error;
                notifyService.displayError(error.xhrStatus);
            });
        }

        function updateProduct() {
            var url = "http://localhost:5260/api/Product/update";
            if ($scope.category) {
                url = $scope.category == 'Phone' ? "http://localhost:5260/api/Product/Phone/update" : "http://localhost:5260/api/Product/Clothe/update";
            }
            apiService.post(url, $scope.product,
                function (result) {
                    if (result.data.success) {
                        notifyService.displaySuccess($scope.product.ProductName + ' đã được cập nhật.');
                        $state.go('products');
                    } else {
                        notifyService.displayError('Cập nhật không thành công.');
                    }
                }, function (error) {
                    notifyService.displayError('Cập nhật không thành công.');
                });
        }

        loadSupplier();
    }
})(angular.module("productapp.product"));