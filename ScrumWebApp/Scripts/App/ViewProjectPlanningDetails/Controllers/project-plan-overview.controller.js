
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

        // 

        $scope.player = {
            gold: 100
        };

        $scope.items = [
            { name: 'Small Health Potion', cost: 4 },
            { name: 'Small Mana Potion', cost: 5 },
            { name: 'Iron Short Sword', cost: 12 }
        ];

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

        $scope.otherMenuOptions = [
            ['Favorite Color', function ($itemScope, $event, color) {
                alert(color);
            }]
        ];

        var customHtml = '<div style="cursor: pointer; background-color: pink"><i class="glyphicon glyphicon-ok-sign"></i> Testing Custom </div>';
        var customItem = {
            html: customHtml,
            click: function ($itemScope, $event, value) {
                alert("custom html");
            }
        };

        var customDisabledItem = {
            html: "I'm Disabled",
            click: function ($itemScope, $event, value) {
                console.log("expect to never get here!");
            },
            enabled: function ($itemScope, $event, value) {
                console.log("can't click");
                return false;
            }
        };

        $scope.customHTMLOptions = [customItem, customDisabledItem,
            ['Example 1', function ($itemScope, $event, value) {
                alert("Example 1");
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



