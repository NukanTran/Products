(function (app) {
    app.controller("productAddController", productAddController);

    productAddController.$inject = ["$scope", '$state', "apiService", "notifyService"];
    function productAddController($scope, $state, apiService, notifyService) {
        $scope.category = "Phone";
        $scope.listSupplier = [];
        $scope.product = {
        };

        $scope.addProduct = addProduct;

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

        function addProduct() {
            var url = "http://localhost:5260/api/Product/insert";
            if ($scope.category) {
                url = $scope.category == 'Phone' ? "http://localhost:5260/api/Product/Phone/insert" : "http://localhost:5260/api/Product/Clothe/insert";
            }
            apiService.post(url, $scope.product,
                function (result) {
                    if (result.data.success) {
                        notifyService.displaySuccess($scope.product.ProductName + ' đã được thêm mới.');
                        $state.go('products');
                    } else {
                        notifyService.displayError('Thêm mới không thành công.');
                    }
                }, function (error) {
                    notifyService.displayError('Thêm mới không thành công.');
                });
        }

        loadSupplier();
    }
})(angular.module("productapp.product"));