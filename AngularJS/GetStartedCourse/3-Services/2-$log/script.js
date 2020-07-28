
(function () {

    var app = angular.module("githubViewer", []);
    //$scope -> model
    //$http -> service for http requests
    //i$interval => function service, 1- function to call, every 1 sec, how much times ->  $interval(decrementCountdown, 1000, $scope.countdown);
    //$log -> log, info, error, warn, debug
    var MainController = function ($scope, $http, $interval, $log) {
        
        var onRepos = function(response){
            $scope.repos = response.data;
        };

        //only invoked when get is OK 200, successful response, first parameter in then
        var onUserComplite = function (response) {
            $scope.user = response.data;
            $http.get($scope.user.repos_url)
                 .then(onRepos, onError)
        };

      

        //invoked on error, second parameter, optionally
        var onError = function (reason) {
            $scope.error = "Could not fetch the data!";
        };

        var decrementCountdown = function(){
            $scope.countdown -= 1;
            if($scope.countdown < 1){
                $scope.search($scope.username)
            }
        };

        var countdownInit = null;
        var startCountDown = function() {
            //i$interval => function service, 1- function to call, every 1 sec, how much times
           countdownInit =  $interval(decrementCountdown, 1000, $scope.countdown);
        };

        //on submit form and on interval
        $scope.search = function (username) {
            $log.info("Searching for: " + username)
            $http.get("https://api.github.com/users/" + username)
                .then(onUserComplite, onError);

            if(countdownInit){
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


    app.controller("MainController", ["$scope", "$http", "$interval", "$log", MainController]); //register controller, in array first parameters then controller, min.js

}());  //immediately invoked function expression -> IIFE