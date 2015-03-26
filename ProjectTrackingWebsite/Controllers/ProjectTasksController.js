(function () {
    var ProjectTasksController = function ($scope, $location, projectTasksService, userStoriesService) {
        var userStories = function (data) {
            $scope.Stories = data;
        };
        var errorDetails = function (serviceResp) {
            $scope.Error = "Something went wrong!!";
        };

        userStoriesService.userStories().then(userStories, errorDetails);

        var projectTasks = function (data) {
            $scope.Tasks = data;
        };
        var errorDetails = function (serviceResp) {
            $scope.Error = "Something went wrong ??";
        };

        $scope.assignTask = function () {
            $scope.task.userStoryID = $scope.userStorySelected.userStoryID;

            projectTasksService.addProjectTask($scope.task).then(function () {
                $location.path("/Tasks");
            });
        };

        projectTasksService.projectTasks().then(projectTasks, errorDetails);
        $scope.Title = "Project Tasks Page";
    };
    app.controller("ProjectTasksController", ["$scope", "$location", "projectTasksService", "userStoriesService", ProjectTasksController]);
}());