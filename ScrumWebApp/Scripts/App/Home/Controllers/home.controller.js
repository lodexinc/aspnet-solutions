
(function (angular) {
    'use strict';

    angular.module('HomeModule').controller("HomeController", HomeController);

    

})(angular);
HomeController.$inject = ['$scope', '$http', 'moment', 'deviceDetector'];
    function HomeController($scope, $http, moment, deviceDetector) {
        var self = this;
        self.SignInCommand = {
            email: "trandangthanh@gmail.com",
            password: "123456",
            rememberMe: false,
            debug: false
        }

        $scope.topic =
           "Integrating ASP.NET MVC and AngularJS sdfsdfsd sdf sdf";

        $scope.time = moment().format('MMMM Do YYYY, h:mm:ss a') + ' - Time zone: ' + moment.tz.guess();
        $scope.os = deviceDetector.os + "/" + deviceDetector.os_version;
        $scope.browser = deviceDetector.browser + "/" + deviceDetector.browser_version;
        $scope.device = deviceDetector.device;

        $scope.isDesktop = deviceDetector.isDesktop();
        $scope.isMobile = deviceDetector.isMobile();
        $scope.isTablet = deviceDetector.isTablet();

        this.search = {
            keyword: "",
            searchButtonLabel: "Search",
            placeHolder: "Please enter your keyword..."
        };

        this.beginSearch = function () {
            this.search.keyword = "Your search has been started. Please wait...";
            $http.post('/Authentication/SignIn', self.SignInCommand)
                .then(function successCallback(response) {
                    // this callback will be called asynchronously
                    // when the response is available
                    // self.message = JSON.stringify(response);
                }, function errorCallback(errorResponse) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.
                    self.message = JSON.stringify(errorResponse);
                });
        };

        var initialize = function () {
            $scope.pageHeading = "Home Section";
        }

        initialize();
    }