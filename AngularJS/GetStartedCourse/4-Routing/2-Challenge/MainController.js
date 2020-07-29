
(function () {

    var app = angular.module("githubViewer");
    //$scope -> model
    //$http -> service for http requests
    //i$interval => function service, 1- function to call, every 1 sec, how much times ->  $interval(decrementCountdown, 1000, $scope.countdown);
    //$log -> log, info, error, warn, debug
    var MainController = function (
        $scope, $interval, $location) {

      
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
            if (countdownInit) {
                $interval.cancel(countdownInit);
                $scope.countdown = null;
            }
            
            $location.path("/user/"+ username);
        };


        $scope.username = "angular"; //default username
        $scope.countdown = 5;
        startCountDown();

    };


    app.controller("MainController", MainController); //register controller, in array first parameters then controller, min.js

}());  //immediately invoked function expression -> IIFE