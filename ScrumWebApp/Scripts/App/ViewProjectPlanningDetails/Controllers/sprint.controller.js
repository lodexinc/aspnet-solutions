
(function () {
    'use strict';

    angular.module('ProjectPlanModule').controller("SprintController", SprintController);

    SprintController.$inject = ['$scope', '$http', 'toastr', 'Urls', 'Flash',
        'NotificationMessages', 'ObserverService', 'dragularService'];
    function SprintController($scope,
        $http, toastr, Urls, Flash, NotificationMessages, ObserverService, dragularService) {

        var regex = new RegExp('/project/searchProject', 'i');
        $scope.blockPattern = regex.toString();
        var self = this;

        dragularService('.containerVertical');

        self.Sprint = {
        };

        self.Issues = [];

        self.init = init;

        function init(sprint) {
            self.Sprint = sprint;
            loadIssue(sprint);
            self.TotalIssues = self.Issues.length;
        }

        function loadIssue(sprint) {
            self.Issues = [
                //{
                //    Key: 'Issue 1 - ' + sprint.SprintName
                //},
                //{
                //    Key: 'Issue 2 - ' + sprint.SprintName
                //}
            ];
        }

        self.getProjectDetailView = function (callBackParams) {
            if (callBackParams.ProjectID === self.ProjectDetailView.ProjectID) {
                self.isLoading = true;
                $http.get('/ProjectPlaning/ViewDetail', { params: { project: self.ProjectDetailView.ProjectID } })
                    .then(function successCallback(response) {
                        self.isLoading = false;

                        if (response.status !== 200) {
                            toastr.error("Sorry! There is an error as we are trying to get detail for project: " + self.ProjectDetailView.ProjectName);
                        } else {

                            self.ProjectDetailView = response.data;
                        }

                    }, function errorCallback(errorResponse) {
                        // called asynchronously if an error occurs
                        // or server returns response with an error status.                   
                        toastr.error("Sorry! There is an error as we are trying to get detail for project: " + self.ProjectDetailView.ProjectName);
                    });
            }

        };


        ObserverService.attach(self.getProjectDetailView, 'issue_created', 'viewProjectPlanDetail');
        $scope.$on('$destroy', function handler() {
            ObserverService.detachByEventAndId('issue_created', 'viewProjectPlanDetail');
        });
    };
})();



