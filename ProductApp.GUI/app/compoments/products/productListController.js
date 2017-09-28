(function (app) {
    app.controller("productListController", productListController);

    productListController.$inject = ["$scope", "$http", "apiService"];
    function productListController($scope, $http, apiService) {
        $scope.listProduct = [];
        $scope.getListProduct = getListProduct;

        function getListProduct() {
            $http.get("http://localhost:5260/api/Product/GetListPaging/0/2").then(function (result) {
                $scope.listProduct = result.data.elements;
            }, function (error) {
                $scope.error = error;
            });
        }

        //function getListProduct() {
        //    apiService.get("http://localhost:5260/api/Product/GetAll", null, function (result) {
        //        $scope.listProduct = result.data.elements;
        //    }, function (error) {
        //        $scope.error = error;
        //    });
        //}


        $scope.getListProduct();
    }
})(angular.module("productapp.product"));