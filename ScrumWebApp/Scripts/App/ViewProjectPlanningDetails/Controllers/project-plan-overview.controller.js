
(function () {
    'use strict';

    angular.module('ProjectPlanModule').controller("ProjectPlanOverviewController", ProjectPlanOverviewController);

    ProjectPlanOverviewController.$inject = ['$scope', '$http', 'toastr', 'Urls', 'Flash',
        'NotificationMessages', 'ObserverService', 'dragularService'];
    function ProjectPlanOverviewController($scope,
        $http, toastr, Urls, Flash, NotificationMessages, ObserverService, dragularService) {

        var regex = new RegExp('/project/searchProject', 'i');
        $scope.blockPattern = regex.toString();
        var self = this;
        $scope.checked = false;
        $scope.toggle = function () {
            $scope.checked = !$scope.checked
        }

        $scope.menuOptions = [
            ['Edit issue', function ($itemScope) {
                $scope.player.gold -= $itemScope.issue.Key;
                $scope.open('md', '/Issue/CreateIssue');
            }],
            null,
            ['Delete issue', function ($itemScope) {
                $scope.player.gold += $itemScope.issue.Key;
            }, function ($itemScope) {
                return $itemScope.issue.Key.match(/Iron/) == null;
            }]
        ];

        // end context menu

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
                }]
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
                }]
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
                }]
            },
        ];

        self.Backlog = { };

        self.Backlog.Issues = [
            {
                Key: 'Issue 1 - ' + "back log"
            },
            {
                Key: 'Issue 2 - ' + "back log"
            }];

        self.init = init;

        self.openCreateSprint = openCreateSprint;

        $scope.$on('ngRepeatFinished', function (ngRepeatFinishedEvent) {
            var container1 = document.querySelector('#Sprint_1'),
                container2 = document.querySelector('#Sprint_2'),
                container3 = document.querySelector('#Sprint_3'),
                backlog = document.querySelector('#backLog');

            dragularService([container1], {
                containersModel: [self.Sprints[0].Issues]
            });

            dragularService([container2], {
                containersModel: [self.Sprints[1].Issues]
            });

            dragularService([container3], {
                containersModel: [self.Sprints[2].Issues]
            });

            dragularService([backlog], {
                containersModel: [self.Backlog.Issues]
            });
        });



        function init(projectDetailView) {
            self.ProjectDetailView = projectDetailView;
        }

        function openCreateSprint() {
            $scope.open('md', '/ProjectPlanning/CreateSprint?project=' + self.ProjectDetailView.ProjectID);
        }

        self.getProjectDetailView = function (callBackParams) {
            if (callBackParams.ProjectID === self.ProjectDetailView.ProjectID) {
                self.isLoading = true;
                $http.get('/ProjectPlanning/ViewDetail', { params: { project: self.ProjectDetailView.ProjectID } })
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
        ObserverService.attach(self.getProjectDetailView, 'sprint_created', 'viewProjectPlanDetail');
        $scope.$on('$destroy', function handler() {
            ObserverService.detachByEventAndId('issue_created', 'viewProjectPlanDetail');
            ObserverService.detachByEventAndId('sprint_created', 'viewProjectPlanDetail');
        });
    };
})();



