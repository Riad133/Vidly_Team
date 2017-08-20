(function () {
    "use strict";
    angular.module("vidly")
        .controller("CustomerDetailCtrl",
        ["customerResource",
            "membershiptypeResouce",
            "customer",
            "$stateParams",
            CustomerDetailCtrl]
    );

    function CustomerDetailCtrl(customerResource, membershiptypeResouce, customer) {

        var vm = this;
        vm.message = "";
        vm.Orginalcustomer = {};
        console.log(customer);
        vm.customer = {};
        vm.customer = customer;
        //vm.customer.membershipTypeId

      membershiptypeResouce.query(function (data) {
          vm.membershiptypes = data;
         
      });

      //vm.customer.membershipType = _.findWhere(vm.membershiptypes, { id: vm.customer.membershipTypeId});
      vm.customer.birthDate = new Date(vm.customer.birthDate);

      vm.membershipType = function(id) {
          var memberShipType = _.findWhere(vm.membershiptypes, { id: id });
          console.log(memberShipType.name);
          return memberShipType.name;
      }

    }


}());