
(function () {
    'use strict';

    angular.module('ProjectPlanModule').controller("ProjectPlanOverviewController", ProjectPlanOverviewController);

    ProjectPlanOverviewController.$inject = ['$scope', '$http', 'toastr', 'Urls', 'Flash', 'NotificationMessages', 'ObserverService'];
    function ProjectPlanOverviewController($scope, $http, toastr, Urls, Flash, NotificationMessages, ObserverService) {
        var regex = new RegExp('/project/searchProject', 'i');
        $scope.blockPattern = regex.toString();
        var self = this;

        self.ProjectDetailView = {
        };

        self.init = init;

        function init(projectDetailView) {
            self.ProjectDetailView = projectDetailView;
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



