
(function () {

    var app = angular.module("githubViewer", []);
    //$scope -> model
    //$http -> service for http requests
    //i$interval => function service, 1- function to call, every 1 sec, how much times ->  $interval(decrementCountdown, 1000, $scope.countdown);
    //$log -> log, info, error, warn, debug
    var MainController = function (
        $scope, github, $interval, $log, 
        $anchorScroll, $location) {

        var onRepos = function (data) {
            $scope.repos = data;
            $location.hash("userDetails");
            $anchorScroll();
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

        var decrementCountdown = function () {
            $scope.countdown -= 1;
            if ($scope.countdown < 1) {
                $scope.search($scope.username)
            }
        };

        var countdownInit = null;
        var startCountDown = function () {
            //i$interval => function service, 1- function to call, every 1 sec, how much times
            countdownInit = $interval(decrementCountdown, 1000, $scope.countdown);
        };

        //on submit form and on interval
        $scope.search = function (username) {
            $log.info("Searching for: " + username)
            github.getUser(username)
                .then(onUserComplite, onError);

            if (countdownInit) {
                $interval.cancel(countdownInit);
                $scope.countdown = null;
            }
        };


        $scope.username = "angular"; //default username
        $scope.message = "GitHub Viewer"; //model
        $scope.repoSortOrder = "-stargazers_count";
        $scope.countdown = 5;
        startCountDown();

    };


    app.controller("MainController", ["$scope", "github", "$interval", "$log","$anchorScroll", "$location", MainController]); //register controller, in array first parameters then controller, min.js

}());  //immediately invoked function expression -> IIFE