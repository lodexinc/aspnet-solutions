
(function () {
    'use strict';

    angular.module('ProjectPlanModule').controller("CreateSprintController", CreateSprintController);

    CreateSprintController.$inject = ['$scope', '$http', 'toastr', 'Urls', 'Flash',
        'NotificationMessages', 'ObserverService', 'dragularService', '$window', 'valdr'];
    function CreateSprintController($scope,
        $http, toastr, Urls, Flash, NotificationMessages, ObserverService, dragularService, $window, valdr) {

        var regex = new RegExp('/project/searchProject', 'i');
        $scope.blockPattern = regex.toString();
        var self = this;


        self.Sprint = {
            ProjectID: "",
            Name: "",
            Goal: ""
        };

        self.Issues = [];

        self.init = init;

        function init(sprint) {
            self.Sprint = sprint;

        }                

        watchWindowHeight(self, $scope, $window);

        valdr.addConstraints(sprintValidationProvider());

        self.createSprint = createSprint;

        function sprintValidationProvider() {
            return {
                'CreateSprint': {
                    'sprintName': {
                        'required': {
                            'message': 'You need to provide a sprint name.'
                        }
                    }
                }
            };
        }

        function createSprint() {
            $http.post('/ProjectPlanning/CreateSprint', self.Sprint)
                .then(function successCallback(response) {
                    $scope.ok();
                    toastr.success("Sprint have been created successfully.");
                    ObserverService.notify('sprint_created', response.data);
                }, function errorCallback(errorResponse) {
                    toastr.error("Sorry! We cannot create sprint for now.");
                });
        }
    };
})();



