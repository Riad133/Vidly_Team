(function() {
    "use strict";
    angular.module("vidly")
        .controller("CustomerEditCtrl",
        ["customerResource",
            "membershiptypeResouce",
            "$scope",
            CustomerEditCtrl]
    );

    function CustomerEditCtrl(customerResource, membershiptypeResouce,$scope) {

        var vm = this;
        vm.message = "";
        vm.Orginalcustomer = {};
        vm.customer = {};
        customerResource.get({ id: 5 }, function (data) {
            vm.customer = data;
            vm.Orginalcustomer = angular.copy(vm.customer);
        });

        vm.memberShipTypes = {};
        membershiptypeResouce.query(function(data) {
            vm.memberShipTypes = data;
        });
        
       
        vm.submit = function () {
           if (vm.customer.id) {
               vm.customer.$update({ id: vm.customer.id },
                   function(data) {
                       vm.message = "...Save Successfully";
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
        

    }


}());