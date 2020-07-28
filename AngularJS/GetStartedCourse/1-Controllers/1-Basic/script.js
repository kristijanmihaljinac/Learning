var MainController = function($scope){

    var person = {
        fistName: "Scott",
        lastName: "Allen",
        imageSrc: "https://i.pinimg.com/236x/2d/60/65/2d6065a29bca4e021e4d216df72abbbb--wallpapers-for-mobile-phones-phone-wallpapers.jpg"
    }

    $scope.message = "Hello"; //model
    $scope.person = person;
};