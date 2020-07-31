(function () {

    //design pattern -> retunrs object with API -> revealing module design pattern
    var github = function ($http) {

        var getUser = function (username) {
            //returns promise -> async
            return $http.get("https://api.github.com/users/" + username)
                .then(function (response) {
                    return response.data;
                });
        };


        var getRepos = function (user) {
            //returns promise -> async
            return $http.get(user.repos_url)
                .then(function (response) {
                    return response.data;
                });
        };


        var getRepoDetails = function (username, reponame) {
            var repo;
            return $http.get("https://api.github.com/repos/" + username + "/" + reponame)
                .then(function (response) {
                    repo = response.data;

                    return $http.get(repo.contributors_url);

                })
                .then(function (response) {
                    repo.contributors = response.data;
                    return repo;
                });
        }



        return {
            getUser: getUser,
            getRepos: getRepos,
            getRepoDetails: getRepoDetails

        };
    };

    var module = angular.module("githubViewer");
    module.factory("github", github);

}());