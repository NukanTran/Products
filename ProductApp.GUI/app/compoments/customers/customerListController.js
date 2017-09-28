(function (app) {
    app.controller("customerListController", customerListController);

    customerListController.$inject = ["$scope", "apiService"];
    function customerListController($scope, apiService) {
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.totalCount = 0;
        $scope.listCustomer = [];
        $scope.getListCustomer = getListCustomer;
        $scope.search = search;

        function search() {
            getListCustomer();
        }

        function getListCustomer(page) {
            var pageSize = 10;
            apiService.get("http://localhost:5260/api/Customer/GetListPaging/" + page + "/" + pageSize, null, function (result) {
                $scope.page = page;
                $scope.pagesCount = parseInt((result.data.total + 9) / pageSize);
                $scope.totalCount = result.data.total;
                $scope.listCustomer = result.data.elements;
            }, function (error) {
                $scope.error = error;
            });
        }


        $scope.getListCustomer(0);
    }
})(angular.module("productapp.product"));