(function () {
    var UserStoriesController = function ($scope, $location, userStoriesService, projectService) {
        var userStories = function (data) {
            $scope.Stories = data;
        };
        var errorDetails = function (serviceResp) {
            $scope.Error = "Something went wrong ??";
        };

        $scope.addUserStory = function () {
            userStoriesService.addUserStory({ projectID: $scope.userStory.projectSelected.projectID, story: $scope.userStory.story })
                        .then(function (userStories) {
                            $location.path("/UserStories");
                        });
        };

        userStoriesService.userStories().then(userStories, errorDetails);

        projectService.projects().then(function (projects) {
            $scope.projects = projects;
        });

        $scope.Title = "User Stories Page";
    };
    app.controller("UserStoriesController", ["$scope", "$location", "userStoriesService", "projectService", UserStoriesController]);
}());