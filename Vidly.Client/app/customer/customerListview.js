(function() {
    "use strict";
    angular
        .module("vidly")
        .controller("CustomerListCtrl",
        ["customerResource",
            "membershiptypeResouce",
            CustomerListCtrl]);

    function CustomerListCtrl(customerResource, membershiptypeResouce) {
        var vm = this;
        customerResource.query(function(data) {
            vm.customers = data;
        });
        membershiptypeResouce.query(function(data) {
            vm.memberShipTypes = data; 
        });

        vm.findMemberShip= function (id) {
            var member = _.findWhere(vm.memberShipTypes, { id: id });
            return member.name;
            //console.log(member.name);

        }
      
    }

}());