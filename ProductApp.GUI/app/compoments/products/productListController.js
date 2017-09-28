(function (app) {
    app.controller("productListController", productListController);

    productListController.$inject = ["$scope", "apiService"];
    function productListController($scope, apiService) {
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.totalCount = 0;
        $scope.listProduct = [];
        $scope.getListProduct = getListProduct;
        $scope.search = search;

        function search() {
            getListProduct();
        }

        function getListProduct(page) {
            var pageSize = 10;
            apiService.get("http://localhost:5260/api/Product/GetListPaging/" + page + "/" + pageSize, null, function (result) {
                $scope.page = page;
                $scope.pagesCount = parseInt((result.data.total + 9)/ pageSize);
                $scope.totalCount = result.data.total;
                $scope.listProduct = result.data.elements;
            }, function (error) {
                $scope.error = error;
            });
        }
        
        $scope.getListProduct(0);
    }
})(angular.module("productapp.product"));