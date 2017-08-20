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
                    url: "/customers/Edit/:id",
                    templateUrl: "app/customer/customerEditView.html",
                    controller: "CustomerEditCtrl as vm",
                    resolve: {
                        customerResource: "customerResource",
                        customer: function (customerResource, $stateParams) {
                            var customerId = $stateParams.id;

                            return customerResource.get({ id: customerId });

                        }
                    }

                })
                .state("customerDetail",
                {
                    url: "/customers/detail/:id",
                    templateUrl: "app/customer/customerDetailView.html",
                    controller: "CustomerDetailCtrl as vm",
                    resolve: {
                        customerResource: "customerResource",
                        customer: function (customerResource, $stateParams) {
                            var customerId = $stateParams.id;
                            console.log("Customers : "+customerResource.get({ id: customerId }).$promise);

                            return customerResource.get({ id: customerId });

                        }
                    }

                });
                
            
            
            // console.log("Config apperar");
        }]);


}());