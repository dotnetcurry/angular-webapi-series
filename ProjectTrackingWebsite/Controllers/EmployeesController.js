(function () {
    var EmployeesController = function ($scope,employeeService,$log) {
        var employees = function (data) {
            $scope.Employees = data;
        };
        $scope.searchEmployees = function (employeeName) {
            employeeService.searchEmployees(employeeName)
            .then(employees, errorDetails);
            $log.info("Found Employee which contains - " + employeeName);
        };
        var errorDetails = function (serviceResp) {
            $scope.Error="Something went wrong ??";
        };
        employeeService.employees().then(employees,errorDetails);
        $scope.Title = "Employee Details Page";
        $scope.employeeName = null;
    };
    app.controller("EmployeesController", ["$scope", "employeeService", "$log", EmployeesController]);
}());