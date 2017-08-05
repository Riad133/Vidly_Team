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
        //vm.customers = [
        //    {
        //        "id": 1,
        //        "name": "John Smith",
        //        "birthDate": "1981-09-10T00:00:00",
        //        "isSubscribeToNewsletter": false,
        //        "membershipTypeId": 1
        //    },
        //    {
        //        "id": 2,
        //        "name": "Mary William Joe",
        //        "birthDate": null,
        //        "isSubscribeToNewsletter": true,
        //        "membershipTypeId": 2
        //    },
        //    {
        //        "id": 3,
        //        "name": "Riad",
        //        "birthDate": "1990-01-12T00:00:00",
        //        "isSubscribeToNewsletter": true,
        //        "membershipTypeId": 1
        //    },
        //    {
        //        "id": 4,
        //        "name": "Riad",
        //        "birthDate": "1990-01-12T00:00:00",
        //        "isSubscribeToNewsletter": true,
        //        "membershipTypeId": 2
        //    },
        //    {
        //        "id": 5,
        //        "name": "Riad 1",
        //        "birthDate": "1990-01-12T00:00:00",
        //        "isSubscribeToNewsletter": true,
        //        "membershipTypeId": 2
        //    },
        //    {
        //        "id": 6,
        //        "name": "Riad 2",
        //        "birthDate": "1990-01-12T00:00:00",
        //        "isSubscribeToNewsletter": true,
        //        "membershipTypeId": 2
        //    },
        //    {
        //        "id": 7,
        //        "name": "Riad 3",
        //        "birthDate": "1990-01-12T00:00:00",
        //        "isSubscribeToNewsletter": true,
        //        "membershipTypeId": 2
        //    },
        //    {
        //        "id": 8,
        //        "name": "Nazrul Islam Riad 3",
        //        "birthDate": "1991-01-12T00:00:00",
        //        "isSubscribeToNewsletter": true,
        //        "membershipTypeId": 2
        //    },
        //    {
        //        "id": 9,
        //        "name": "John Smith 2",
        //        "birthDate": "1981-09-10T00:00:00",
        //        "isSubscribeToNewsletter": false,
        //        "membershipTypeId": 1
        //    },
        //    {
        //        "id": 10,
        //        "name": "John Smith 3",
        //        "birthDate": "1981-09-10T00:00:00",
        //        "isSubscribeToNewsletter": false,
        //        "membershipTypeId": 1
        //    },
        //    {
        //        "id": 11,
        //        "name": "Movie",
        //        "birthDate": "1990-10-04T00:00:00",
        //        "isSubscribeToNewsletter": false,
        //        "membershipTypeId": 2
        //    },
        //    {
        //        "id": 12,
        //        "name": "Movie 3",
        //        "birthDate": "1990-10-04T00:00:00",
        //        "isSubscribeToNewsletter": false,
        //        "membershipTypeId": 2
        //    },
        //    {
        //        "id": 13,
        //        "name": "Movie",
        //        "birthDate": "1990-01-12T00:00:00",
        //        "isSubscribeToNewsletter": false,
        //        "membershipTypeId": 1
        //    },
        //    {
        //        "id": 15,
        //        "name": "Riad 25",
        //        "birthDate": "1990-01-12T00:00:00",
        //        "isSubscribeToNewsletter": true,
        //        "membershipTypeId": 2
        //    },
        //    {
        //        "id": 17,
        //        "name": "Mehedi Hassan",
        //        "birthDate": null,
        //        "isSubscribeToNewsletter": true,
        //        "membershipTypeId": 3
        //    }
        //];
    }

}());