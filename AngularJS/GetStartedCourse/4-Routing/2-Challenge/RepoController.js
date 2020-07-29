
(function () {

    var app = angular.module("githubViewer");
    //$scope -> model
    //$http -> service for http requests
    //i$interval => function service, 1- function to call, every 1 sec, how much times ->  $interval(decrementCountdown, 1000, $scope.countdown);
    //$log -> log, info, error, warn, debug
    var RepoController = function (
        $scope, github, $routeParams) {

        var onRepos = function (data) {
            $scope.repos = data;
        };

        //only invoked when get is OK 200, successful response, first parameter in then
        var onUserComplite = function(data) {
            $scope.user = data;
            github.getRepos($scope.user)
                .then(onRepos, onError);
        };

        //invoked on error, second parameter, optionally
        var onError = function (reason) {
            $scope.error = "Could not fetch the data!";
        };


        $scope.username = $routeParams.username; //default username
        $scope.countdown = 5;
        github.getUser($scope.username).then(onUserComplite, onError);
      

    };


    app.controller("RepoController", RepoController); //register controller, in array first parameters then controller, min.js

}());  //immediately invoked function expression -> IIFE