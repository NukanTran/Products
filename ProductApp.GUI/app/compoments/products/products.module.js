
(function () {

    angular.module("productapp.product", ["productapp.common"]).config(config);

    config.$inject = ["$stateProvider", "$urlRouterProvider"]

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state("products", {
            url: "/products",
            templateUrl: "/app/compoments/products/productListView.html",
            controller: "productListController"
        }).state("product_add", {
            url: "/product_add",
            templateUrl: "/app/compoments/products/productAddView.html",
            controller: "productAddController"
        }).state("product_edit", {
            url: "/product_edit",
            templateUrl: "/app/compoments/products/productEditView.html",
            controller: "productEditController"
            });
        $urlRouterProvider.otherwise("/products");
    };

})();