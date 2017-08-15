﻿(function() {
    "use strict";
    angular.module("vidly")
        .controller("CustomerEditCtrl",
        ["customerResource",
            "membershiptypeResouce",
            
            "$stateParams",
            CustomerEditCtrl]
    );

    function CustomerEditCtrl(customerResource, membershiptypeResouce, $stateParams) {

        var vm = this;
        vm.message = "";
        vm.Orginalcustomer = {};
        vm.customer = {};
       // console.log("customer " + $stateParams.id);
        
        customerResource.get({ id: $stateParams.id},
            function (data) {
                vm.customer = data;
                vm.customer.birthDate = new Date(vm.customer.birthDate);
                vm.Orginalcustomer = angular.copy(vm.customer);
                console.log("$stateProvider ->" + $stateParams.id);
        },
            function (response) {
           
            vm.message = response.statusText + "--\r\n";
            console.log(response.data.exceptionMessage);
            if (response.data.exceptionMessage) {
                console.log(response.data.exceptionMessage);
                vm.message += response.data.exceptionMessage;
            }
        });

        vm.memberShipTypes = {};
        membershiptypeResouce.query(function(data) {
            vm.memberShipTypes = data;
            
          //  console.log("Customer editCtrl -> >"+vm.customer);

        });
        
       
        vm.submit = function () {
           if (vm.customer.id) {
               vm.customer.$update({ id: vm.customer.id },
                   function(data) {
                       vm.message = "...Save Successfully"; 
                   },
                   function (response) {
                       vm.message = response.statusText + "--\r\n";
                       console.log(response.data.exceptionMessage);
                       if (response.data.exceptionMessage) {
                           console.log(response.data.exceptionMessage);
                           vm.message += response.data.exceptionMessage;
                       }
                   }
               );
           }
            //vm.message = "Success";
            console.log(vm.customer);
        }
        vm.cancel =function(editForm) {
            editForm.$setPristine();
            vm.customer = angular.copy(vm.Orginalcustomer);
            vm.message = "";
        }

   
        vm.open = function($event) {
            $event.preventDefault();
            $event.stopPropagation();
            vm.opened = !vm.opened;
        };

    }


}());