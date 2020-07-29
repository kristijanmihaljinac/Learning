(function(){
    
    //design pattern -> retunrs object with API -> revealing module design pattern
    var github = function($http){
        
        var getUser = function(username){
            //returns promise -> async
            return $http.get("https://api.github.com/users/" + username)
                        .then(function(response){
                            return response.data;
                        });
        };


        var getRepos = function(user){
            //returns promise -> async
            return  $http.get(user.repos_url)
                        .then(function(response){
                            return response.data;
                        });
        };


        var getRepoDetails = function(username, reponame){

            return $http.get("https://api.github.com/repos/" + username + "/" + reponame)
                        .then(function (response){
                            return response.data;
                        });
        }


        var getContibutors = function(repo){
            return $http.get(repo.contributors_url)
                        .then(function (response){
                            return response.data;
                        });
        }



        
        return {
            getUser: getUser,
            getRepos: getRepos,
            getRepoDetails: getRepoDetails,
            getContibutors: getContibutors
        };
    };
    
    var module = angular.module("githubViewer");
    module.factory("github", github);

}());