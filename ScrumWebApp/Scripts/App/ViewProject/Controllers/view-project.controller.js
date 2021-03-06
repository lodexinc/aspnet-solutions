﻿
(function () {
    'use strict';

    angular.module('ViewProjectModule').controller("ViewProjectController", ViewProjectController);

    ViewProjectController.$inject = ['$scope', '$http', 'toastr', 'Urls', 'Flash', 'NotificationMessages', 'ObserverService'];
    function ViewProjectController($scope, $http, toastr, Urls, Flash, NotificationMessages, ObserverService) {
        var regex = new RegExp('/project/searchProject', 'i');
        $scope.blockPattern = regex.toString();
        var self = this;
        self.projects = [];

        self.searchProject = function (tableState) {
            self.tableState = tableState;
            self.isLoading = true;
            $http.get('/project/ViewProject')
                .then(function successCallback(response) {
                    self.projects = response.data;
                    self.isLoading = false;
                }, function errorCallback(errorResponse) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.                   
                    toastr.error("Sorry! We cannot register you for now.");
                });
        };

        self.globalSearch = function () {
            self.searchProject(self.tableState);
        }

        ObserverService.attach(self.globalSearch, 'project_created', 'viewProject');
        $scope.$on('$destroy', function handler() {
            ObserverService.detachByEventAndId('project_created', 'viewProject');
        });
    };
})();



