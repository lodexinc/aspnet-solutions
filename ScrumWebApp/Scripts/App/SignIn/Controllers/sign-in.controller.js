
(function () {
    'use strict';

    angular.module('SignInModule').controller("SignInController", SignInController);

    SignInController.$inject = ['$scope', '$http', 'toastr', 'Urls', 'Flash', 'NotificationMessages', '$window'];
    function SignInController($scope, $http, toastr, Urls, Flash, NotificationMessages, $window) {
        var regex = new RegExp(Urls.LOG_IN, 'i');
        $scope.blockPattern = regex.toString();

        var self = this;
        self.SignInCommand = {
            email: "",
            password: "",
            rememberMe: false,
            debug: false
        }

        self.message = "";

        self.signIn = function () {
            $http.post(Urls.LOG_IN, self.SignInCommand)
                .then(function successCallback(response) {
                    // this callback will be called asynchronously
                    // when the response is available
                    // self.message = JSON.stringify(response);
                    // toastr.success("You signed in successfully.");
                    if (parseInt(response.status) === 200) {
                        $window.location.href = '/home/index';
                    } else {
                        Flash.create('danger', NotificationMessages.SIGN_IN_FAIL, 0, { id: 'sign-in-failed' }, true);
                    }

                    
                }, function errorCallback(errorResponse) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.
                    self.message = JSON.stringify(errorResponse);
                });
        };


    };

})();



