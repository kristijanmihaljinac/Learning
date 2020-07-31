
(function () {

    var app = angular.module("githubViewer");
    //$scope -> model
    //$http -> service for http requests
    //DI
    var RepoController = function (
        $scope, github, $routeParams) {


        //only invoked when get is OK 200, successful response, first parameter in then
        var onRepoComplite = function (data) {
            $scope.repo = data;
        };

        //invoked on error, second parameter, optionally
        var onError = function (reason) {
            $scope.error = reason;
        };


        $scope.username = $routeParams.username;
        $scope.reponame = $routeParams.reponame;
        github.getRepoDetails($scope.username, $scope.reponame).then(onRepoComplite, onError);


    };


    app.controller("RepoController", RepoController); //register controller, in array first parameters then controller, min.js

}());  //immediately invoked function expression -> IIFE