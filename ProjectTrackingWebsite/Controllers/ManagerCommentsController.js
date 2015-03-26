(function () {
    var ManagerCommentsController = function ($scope, managerCommentsService) {
        var managerComments = function (data) {
            $scope.Comments = data;
        };
        var errorDetails = function (serviceResp) {
            $scope.Error = "Something went wrong ??";
        };
        managerCommentsService.managerComments().then(managerComments, errorDetails);
        $scope.Title = "Manager comments Page";
    };
    app.controller("ManagerCommentsController", ["$scope", "managerCommentsService", ManagerCommentsController]);
}());