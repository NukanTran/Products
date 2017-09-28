
(function () {
    angular.module("productapp", ["productapp.product", "productapp.supplier", "productapp.customer", "productapp.order", "productapp.common"]).config(config);

    config.$inject = ["$stateProvider", "$urlRouterProvider"]

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state("home",{
            url: "/home",
            templateUrl: "/app/compoments/homeView.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise("/home");
    };

})();