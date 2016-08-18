
(function () {
    'use strict';

    angular.module('RegisterModule').controller("RegisterController", RegisterController);

    RegisterController.$inject = ['$scope', '$http', 'toastr', 'Urls', 'Flash', 'NotificationMessages'];
    function RegisterController($scope, $http, toastr, Urls, Flash, NotificationMessages) {
        var regex = new RegExp(Urls.REGISTER, 'i');
        $scope.blockPattern = regex.toString();

        var self = this;
        self.RegisterCommand = {
            email: "",
            password: "",
            firstName: "",
            lastName: "",
        }

        self.register = function () {
            $http.post(Urls.REGISTER, self.RegisterCommand)
                .then(function successCallback(response) {
                    // this callback will be called asynchronously
                    // when the response is available
                    // self.message = JSON.stringify(response);
                    // toastr.success("You have been registered successfully.");
                    var id = Flash.create('success', NotificationMessages.REGISTER_SUCCESS, 0, { id: 'register-success' }, true);
                }, function errorCallback(errorResponse) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.                   
                    toastr.error("Sorry! We cannot register you for now.");
                });
        };
    };    
})();



