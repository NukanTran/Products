(function (app) {
    app.controller("phoneListController", phoneListController);

    phoneListController.$inject = ["$scope", "apiService"];
    function phoneListController($scope, apiService) {
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.totalCount = 0;
        $scope.listPhone = [];
        $scope.getListPhone = getListPhone;
        $scope.search = search;

        function search() {
            getListPhone();
        }

        function getListPhone(page) {
            var pageSize = 10;
            apiService.get("http://localhost:5260/api/Product/phone/GetListPaging/" + page + "/" + pageSize, null, function (result) {
                $scope.page = page;
                $scope.pagesCount = parseInt((result.data.total + 9)/ pageSize);
                $scope.totalCount = result.data.total;
                $scope.listPhone = result.data.elements;
            }, function (error) {
                $scope.error = error;
            });
        }
        
        $scope.getListPhone(0);
    }
})(angular.module("productapp.product"));