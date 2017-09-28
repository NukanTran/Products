
(function () {
    angular.module("productapp.customer", ["productapp.common"]).config(config);

    config.$inject = ["$stateProvider", "$urlRouterProvider"]

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state("customers", {
            url: "/customers",
            templateUrl: "/app/compoments/customers/customerListView.html",
            controller: "customerListController"
        }).state("customer_add", {
            url: "/customer_add",
            templateUrl: "/app/compoments/customers/customerAddView.html",
            controller: "customerAddController"
        }).state("customer_edit", {
            url: "/customer_edit",
            templateUrl: "/app/compoments/customers/customerEditView.html",
            controller: "customerEditController"
            });
        $urlRouterProvider.otherwise("/customers");
    };

})();