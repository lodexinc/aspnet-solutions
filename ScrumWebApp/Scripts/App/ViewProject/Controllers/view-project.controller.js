
(function () {
    'use strict';

    angular.module('ViewProjectModule').controller("ViewProjectController", ViewProjectController);

    ViewProjectController.$inject = ['$scope', '$http', 'toastr', 'Urls', 'Flash', 'NotificationMessages'];
    function ViewProjectController($scope, $http, toastr, Urls, Flash, NotificationMessages) {
        var regex = new RegExp('/project/searchProject', 'i');
        $scope.blockPattern = regex.toString();
        var self = this;
        self.projects = [];
        
        self.searchProject = function (tableState) {
            self.isLoading = true;
            $http.get('/project/searchProject')
                .then(function successCallback(response) {
                    self.projects = response.data;
                    self.isLoading = false;
                }, function errorCallback(errorResponse) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.                   
                    toastr.error("Sorry! We cannot register you for now.");
                });
        };
    };    
})();



