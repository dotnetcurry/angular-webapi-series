(function () {
    var ProjectsController = function ($scope, projectService,$log,$routeParams,$location) {
        var projects = function (data) {
            $scope.Projects = data;
            $log.info(data);
        };

        function convertDateToBindable(date) {
            var dateObj = new Date(date);

            return dateObj.getFullYear() + "-" + getTwoDigitString(dateObj.getMonth() + 1) + "-" + getTwoDigitString(dateObj.getDate());
        }

        function getTwoDigitString(number) {
            if (number.toString().length === 1)
                return "0" + number;
            return number;
        }

        var singleProject = function (data) {
            $scope.existingProject = data;

            $scope.existingProject.startDate = convertDateToBindable($scope.existingProject.startDate);
            $scope.existingProject.endDate = convertDateToBindable($scope.existingProject.endDate);

            $log.info(data);
        };

        $scope.init = function () {
            projectService.singleProject($routeParams.projectID)
                .then(singleProject, errorDetails);
        };

        var project = {
            projectID: null,
            projectName: null,
            startDate: null,
            endDate: null,
            clientName: null
        };

        $scope.project = project;
        
        var errorDetails = function (serviceResp) {
            $scope.Error = "Something went wrong ??";
        };

        $scope.insertProject=function (project) {
            projectService.insertProject(project)
                .then(function (data) {
                    console.log(data);
                    $location.path("/Projects");
                });
        };

        $scope.modifyProject = function (existingProject) {
            $log.info(existingProject);
            projectService.modifyProject(existingProject)
                .then(function () {
                    $location.path("/Projects");
                }, errorDetails);
        };

        $scope.deleteProject = function (project) {
            $log.info(project);
            projectService.deleteProject(project)
                .then(projects, errorDetails);
        };

        var refresh = function () {
            projectService.projects()
                .then(projects, errorDetails);
        };

        refresh();
        $scope.Title = "Project Details Page";
    };
    app.controller("ProjectsController", ["$scope", "projectService", "$log", "$routeParams", "$location", ProjectsController]);
}());