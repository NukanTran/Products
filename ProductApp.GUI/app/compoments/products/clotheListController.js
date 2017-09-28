(function (app) {
    app.controller("clotheListController", clotheListController);

    clotheListController.$inject = ["$scope", "apiService"];
    function clotheListController($scope, apiService) {
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.totalCount = 0;
        $scope.listProduct = [];
        $scope.getListClothe = getListClothe;
        $scope.search = search;

        function search() {
            getListClothe();
        }

        function getListClothe(page) {
            var pageSize = 10;
            apiService.get("http://localhost:5260/api/Product/clothe/GetListPaging/" + page + "/" + pageSize, null, function (result) {
                $scope.page = page;
                $scope.pagesCount = parseInt((result.data.total + 9)/ pageSize);
                $scope.totalCount = result.data.total;
                $scope.listProduct = result.data.elements;
            }, function (error) {
                $scope.error = error;
            });
        }
        
        $scope.getListClothe(0);
    }
})(angular.module("productapp.product"));