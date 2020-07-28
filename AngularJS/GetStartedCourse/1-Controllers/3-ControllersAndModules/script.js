
(function () {

    var app = angular.module("githubViewer", []);
    //$scope -> model
    //$http -> service for http requests
    var MainController = function ($scope, $http) {

        //only invoked when get is OK 200, successful response, first parameter in then
        var onUserComplite = function (response) {
            $scope.user = response.data;
        };

        //invoked on error, second parameter, optionally
        var onError = function (reason) {
            $scope.error = "Could not fetch the user";
        };

        $http.get("https://api.github.com/users/kristijanmihaljinac")
            .then(onUserComplite, onError);

        $scope.message = "Hello"; //model

    };


    app.controller("MainController", ["$scope", "$http",MainController]); //register controller, in array first parameters then controller, min.js

}());  //immediately invoked function expression -> IIFE