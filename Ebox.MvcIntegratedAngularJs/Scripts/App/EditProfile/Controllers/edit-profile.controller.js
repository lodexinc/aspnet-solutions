
(function () {
    'use strict';

    angular.module('EditProfileModule').controller("EditProfileController", EditProfileController);

    EditProfileController.$inject = ['$scope', '$http', 'toastr', 'Urls', 'Flash', 'NotificationMessages', 'moment'];
    function EditProfileController($scope, $http, toastr, Urls, Flash, NotificationMessages, moment) {
        var regex = new RegExp(Urls.EDIT_PROFILE, 'i');
        $scope.blockPattern = regex.toString();

        $scope.dateOptions = {
            formatYear: 'yy',
            startingDay: 1
        };

        $scope.open1 = function () {
            $scope.popup1.opened = true;
        };

        $scope.formats = ['yyyy-MM-dd', 'dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
        $scope.format = $scope.formats[3];
        $scope.altInputFormats = ['M!/d!/yyyy'];

        $scope.popup1 = {
            opened: false
        };

        var self = this;
        self.EditProfile = {
            Email: "",
            FirstName: "",
            LastName:  "",
            DateOfBirth: ""
        };

        $scope.init = function (EditProfile) {
            self.EditProfile = EditProfile;
            self.EditProfile.DateOfBirth = moment(self.EditProfile.DateOfBirth).toDate();;
        };


        self.saveProfile = function () {
            $http.post(Urls.EDIT_PROFILE, self.EditProfile)
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



