(function () {
    var projectService = function ($http, $q, $log) {
        var cachedProjects;

        var projects = function () {
            if (cachedProjects)
                return $q.when(cachedProjects);

            return $http.get("http://localhost:2464/api/ptprojects")
                        .then(function (serviceResp) {
                            cachedProjects = serviceResp.data;
                            return serviceResp.data;
                        });
        };

        var singleProject = function (id) {
            return $http.get("http://localhost:2464/api/ptprojects/"+id)
                        .then(function (serviceResp) {
                            return serviceResp.data;
                        });
        };

        var insertProject = function (project) {
            return $http.post("http://localhost:2464/api/ptprojects", project)
            .then(function (result)
            {
                $log.info("Insert Successful");
                cachedProjects = result.data;
                return result;
            });
        };

        var modifyProject = function (project) {
            return $http.put("http://localhost:2464/api/ptprojects/" + project.projectID, project)
            .then(function (result) {
                $log.info("Update Successful");
                cachedProjects = result.data;
                return;
            });
        };

        var deleteProject = function (project) {
            return $http.delete("http://localhost:2464/api/ptprojects/"+project.projectID)
            .then(function (result) {
                $log.info("Delete Successful");
                cachedProjects = result.data;
                return result.data;
            });
        };

        return {
            projects: projects,
            singleProject: singleProject,
            insertProject: insertProject,
            modifyProject: modifyProject,
            deleteProject: deleteProject
        };
    };

    var module = angular.module("ProjectTrackingModule");

    module.factory("projectService", ["$http", "$q", "$log", projectService]);
}());