(function () {
    var projectTasksService = function ($http) {
        var projectTasks = function () {
            return $http.get("http://localhost:2464/api/ptprojecttasks")
                        .then(function (serviceResp) {
                            return serviceResp.data;
                        });
        };

        var addProjectTask = function (task) {
            return $http.post("http://localhost:2464/api/ptprojecttasks", task)
                        .then(function (response) {
                            return response.data;
                        });
        };

        return {
            projectTasks: projectTasks,
            addProjectTask: addProjectTask
        };
    };
    var module = angular.module("ProjectTrackingModule");
    module.factory("projectTasksService", ["$http", projectTasksService]);
}());