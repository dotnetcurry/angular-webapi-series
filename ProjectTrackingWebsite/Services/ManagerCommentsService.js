(function () {
    var managerCommentsService = function ($http) {
        var managerComments = function () {
            return $http.get("http://localhost:2464/api/ptmanagercomments")
                        .then(function (serviceResp) {
                            return serviceResp.data;
                        });
        };
        return {
            managerComments: managerComments
        };
    };
    var module = angular.module("ProjectTrackingModule");
    module.factory("managerCommentsService", ["$http", managerCommentsService]);
}());