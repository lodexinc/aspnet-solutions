var HomePageController = function ($scope, LoginFactory) {
    $scope.models = {
        helloAngular: 'I work!'
    };


    $scope.navbarProperties = {
        isCollapsed: true
    };

    $scope.logout = function () {
        var result = LoginFactory.logout();
        result.then(function (data) {
            if (data.success) {
                $location.path('/');
            }
        });
    }

}

HomePageController.$inject = ['$scope', 'LoginFactory'];
