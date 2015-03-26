var app = angular.module('ProjectTrackingModule', ['ngRoute', 'ui.bootstrap']);
app.config(function ($routeProvider) {
    $routeProvider
        .when("/Home", {
            templateUrl: "/Home.html",
            controller:"HomeController"
        })
        .when("/Projects", {
        templateUrl: "ProjectManagement/ProjectDetails.html",
        controller: "ProjectsController"
        })
        .when("/NewProject", {
            templateUrl: "ProjectManagement/ProjectInsert.html",
            controller: "ProjectsController"
        })
        .when("/ModifyProject/:projectID", {
            templateUrl: "ProjectManagement/ProjectModify.html",
            controller: "ProjectsController"
        })
        .when("/UserStories", {
            templateUrl: "UserStories/UserStoryDetails.html",
            controller: "UserStoriesController"
        })
        .when("/NewUserStory", {
            templateUrl: "UserStories/UserStoryInsert.html",
            controller: "UserStoriesController"
        })
        .when("/ModifyUserStory/:userStoryID", {
            templateUrl: "UserStories/UserStoryUpdate.html",
            controller: "UserStoriesController"
        })
        .when("/Employees", {
            templateUrl: "Employees/EmployeeDetails.html",
            controller: "EmployeesController"
        })
        .when("/NewEmployee", {
            templateUrl: "Employees/EmployeeInsert.html",
            controller: "EmployeesController"
        })
        .when("/ModifyEmployee/:employeeID", {
            templateUrl: "Employees/EmployeeModify.html",
            controller: "EmployeesController"
        })
        .when("/Tasks", {
            templateUrl: "Tasks/ProjectTaskDetails.html",
            controller: "ProjectTasksController"
        })
        .when("/NewTask", {
            templateUrl: "Tasks/ProjectTaskInsert.html",
            controller: "ProjectTasksController"
        })
        .when("/ModifyTask/:projectTaskID", {
            templateUrl: "Tasks/ProjectTaskModify.html",
            controller: "ProjectTasksController"
        })
    .otherwise({redirectTo:"/Home"})
});
