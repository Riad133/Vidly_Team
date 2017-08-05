(function () {
    "use strict";
    angular
        .module("common.services")
        .factory("membershiptypeResouce",
        [
            "$resource",
            "appSettings",
            membershiptypeResouce
        ]);

    function membershiptypeResouce($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/MemberShipTypes/:id");
    }
}());