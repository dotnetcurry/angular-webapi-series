(function () {
    var userStoriesService = function ($http) {
        var userStories = function () {
            return $http.get("http://localhost:2464/api/ptuserstories")
                        .then(function (serviceResp) {
                            return serviceResp.data;
                        });
        };

        var addUserStory = function (userStory) {
            return $http.post("http://localhost:2464/api/ptuserstories",userStory)
                        .then(function (result) {
                            return result.data;
                        });
        };

        return {
            userStories: userStories,
            addUserStory: addUserStory
        };
    };
    var module = angular.module("ProjectTrackingModule");
    module.factory("userStoriesService", ["$http", userStoriesService]);
}());