(function() {
    "use strict";
    var app = angular.module("vidly",
        ["common.services",
            "ui.router",
            "ui.bootstrap",
            'ngResource'
            
           
            ]);
    
        app.config(["$urlRouterProvider", "$stateProvider", function ($urlRouterProvider, $stateProvider) {

            // default route
            $urlRouterProvider.otherwise("/");

            $stateProvider
                .state("customerList",
                {
                    url: "/customers",
                    templateUrl: "app/customer/customerListView.html",
                    controller: "CustomerListCtrl as vm"
                })
                .state("home",
                {
                    url: "/",
                    templateUrl: "app/welcome.html"

                })
                .state("customerEdit",
                {
                    url: "/customers/:id",
                    templateUrl: "app/customer/customerEditView.html",
                    controller: "CustomerEditCtrl as vm"
                });
            

            // console.log("Config apperar");
        }]);


}());