angular.module("contosoApp").controller("StudentController", function ($scope, $http, $stateParams,toastr) {
    $scope.whatisjavascript = "Javascript is like Wife!";
    $scope.whatisangularjs = "AngularJS is like girlfriend!";

    //Insert data
    $scope.saveStudent = function (data) {
        $http.post("http://localhost:52617/contoso/student", data).then(function (response) {
            if (response.status === 201 && response.statusText === "Created") {
                toastr.success("Student information has been added successfully!");
            }
        }, function (error) {
                if (error.status === 404) {
                    toastr.error("API not found!");
                }
        });
    }

    //Get data and display in Table
    $scope.getStudents = function () {
        $http.get("http://localhost:52617/contoso/student").then(function (response) {
            $scope.students = response.data;
        });
    }

    //Get individual data 
    $scope.getStudentById = function () {
        $http.get("http://localhost:52617/contoso/student/" + $stateParams.studentId).then(function (response) {
            $scope.student = response.data;
        });
    }

    //Update the Existing data
    $scope.updateStudent = function (student) {
        $http.put("http://localhost:52617/contoso/student", student);
    }

    //Delete data
    $scope.deleteStudent = function (studentId) {
        $http.delete("http://localhost:52617/contoso/student/" + studentId);
    }

});