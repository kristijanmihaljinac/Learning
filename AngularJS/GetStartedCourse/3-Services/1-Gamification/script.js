
(function () {

    var app = angular.module("githubViewer", []);
    //$scope -> model
    //$http -> service for http requests
    var MainController = function ($scope, $http, $interval) {
        
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

        var startCountDown = function() {
            //i$interval => function service, 1- function to call, every 1 sec, how much times
            $interval(decrementCountdown, 1000, $scope.countdown);
        };

        $scope.search = function (username) {
            $http.get("https://api.github.com/users/" + username)
                .then(onUserComplite, onError);
        };


        $scope.username = "angular"; //default username
        $scope.message = "GitHub Viewer"; //model
        $scope.repoSortOrder = "-stargazers_count";
        $scope.countdown = 5;
        startCountDown();

    };


    app.controller("MainController", ["$scope", "$http", "$interval", MainController]); //register controller, in array first parameters then controller, min.js

}());  //immediately invoked function expression -> IIFE