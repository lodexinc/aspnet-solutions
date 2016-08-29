
(function () {
    'use strict';

    angular.module('ProjectPlanModule').controller("ProjectPlanOverviewController", ProjectPlanOverviewController);

    ProjectPlanOverviewController.$inject = ['$scope', '$http', 'toastr', 'Urls', 'Flash',
        'NotificationMessages', 'ObserverService', 'dragularService', 'eehNavigation'];
    function ProjectPlanOverviewController($scope,
        $http, toastr, Urls, Flash, NotificationMessages, ObserverService, dragularService, eehNavigation) {

        var regex = new RegExp('/project/searchProject', 'i');
        $scope.blockPattern = regex.toString();
        var self = this;

        eehNavigation
          .menuItem('myMenu.backlog', {
              text: 'Backlog',
              iconClass: 'glyphicon-equalizer',
              weight: -10,
              href: '#'
          })
          .menuItem('myMenu.issues', {
              text: 'Issues',
              iconClass: 'glyphicon-tasks',
              weight: -8,
              href: '#'
          })
          .menuItem('myMenu.projectSettings', {
              text: 'Project Settings',
              iconClass: 'glyphicon-cog',
              weight: -6,
              href: '#'
          });


        self.ProjectDetailView = {
        };

        self.Sprints = [
            {
                SprintID: 1,
                SprintName: "Sprint_1",
                Issues: [
                {
                    Key: 'Issue 1 - ' + "Sprint_1"
                },
                {
                    Key: 'Issue 2 - ' + "Sprint_1"
                }
                ]
            },
            {
                SprintID: 2,
                SprintName: "Sprint_2",
                Issues: [
                {
                    Key: 'Issue 1 - ' + "Sprint_2"
                },
                {
                    Key: 'Issue 2 - ' + "Sprint_2"
                }
                ]
            },
            {
                SprintID: 3,
                SprintName: "Sprint_3",
                Issues: [
                {
                    Key: 'Issue 1 - ' + "Sprint_3"
                },
                {
                    Key: 'Issue 2 - ' + "Sprint_3"
                }
                ]
            },
        ];

        self.init = init;

        $scope.$on('ngRepeatFinished', function (ngRepeatFinishedEvent) {
            var container1 = document.querySelector('#Sprint_1'),
                container2 = document.querySelector('#Sprint_2'),
                container3 = document.querySelector('#Sprint_3');
            dragularService([container1], {
                containersModel: [self.Sprints[0].Issues]
            });

            dragularService([container2], {
                containersModel: [self.Sprints[1].Issues]
            });

            dragularService([container3], {
                containersModel: [self.Sprints[2].Issues]
            });
        });



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



