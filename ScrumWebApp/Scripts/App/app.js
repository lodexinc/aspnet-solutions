(function () {
    var dependencies = [
            'ui.bootstrap',
            'ngSanitize',
            'ui.checkbox',
            'ngAnimate', // needed by toastr
            'valdr',
            'blockUI',
            'angularMoment',
            'toastr',
            'ngIdle',
            'io.dennis.ladda',
            'angular-spinkit',
            'ngFlash',
            'ng.deviceDetector',
            'textAngular',
            'smart-table',
            'selectize',
            'dragularModule',
            'pascalprecht.translate',
            'pageslide-directive',
            'ui.bootstrap.contextMenu'
    ];

    angular.module('appCore', dependencies);
    angular.module('appCore').factory('ObserverService', [ObserverService]);
    angular.module('appCore').controller('NavController', NavController);
    angular.module('appCore').controller('CreateModalInstanceController', CreateModalInstanceController);
    angular.module('appCore').controller('CreateIssueController', CreateIssueController);
    angular.module('appCore').controller('CreateProjectController', CreateProjectController);

    angular.module('appCore').directive('onFinishRender', function ($timeout) {
        return {
            restrict: 'A',
            link: function (scope, element, attr) {
                if (scope.$last === true) {
                    $timeout(function () {
                        scope.$emit(attr.onFinishRender);
                    });
                }
            }
        }
    });
})();

NavController.$inject = ['$scope', '$http', '$uibModal', '$log', '$window', '$compile'];
function NavController($scope, $http, $uibModal, $log, $window, $compile) {

    $scope.toggled = function (open) {
        $log.log('Dropdown is now: ', open);
    };

    $scope.animationsEnabled = true;
    $scope.open = function (size, url) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'myModalContent.html',
            controller: 'CreateModalInstanceController',
            size: size,
            resolve: {
                url: function () {
                    return url;
                }
            }
        });

        modalInstance.rendered.then(function (selectedItem) {

        }, function () {

        });
    };
}

CreateModalInstanceController.$inject = ['$scope', '$http', '$uibModalInstance', 'url', '$compile'];
function CreateModalInstanceController($scope, $http, $uibModalInstance, url, $compile) {
    $scope.url = url;

    $http.get(url).then(function successCallback(response) {
        var element = angular.element($("#spinInModal"));
        var compiledHtml = $compile(response.data)($scope);
        element.replaceWith(compiledHtml);
    }, function errorCallback(errorResponse) {

    });

    $scope.ok = function () {
        $uibModalInstance.close($scope.url);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}

CreateProjectController.$inject = ['$scope', '$http', '$window', 'Urls', 'valdr', 'toastr', 'ObserverService'];
function CreateProjectController($scope, $http, $window, Urls, valdr, toastr, ObserverService) {
    var self = this;
    watchWindowHeight(self, $scope, $window);
    

    valdr.addConstraints(projectValidationProvider());

    self.CreateProjectCommand = {
        name: "",
        key: ""
    };

    self.createProject = createProject;

    function projectValidationProvider() {
        return {
            'CreateProject': {
                'projectName': {
                    'required': {
                        'message': 'You need to provide a project name.'
                    }
                },
                'projectKey': {
                    'required': {
                        'message': 'You need to provide a project key.'
                    }
                }
            }
        };
    }

    function createProject() {
        $http.post('/Project/CreateProject', self.CreateProjectCommand)
            .then(function successCallback(response) {
                $scope.ok();
                toastr.success("Project have been created successfully.");
                ObserverService.notify('project_created');
            }, function errorCallback(errorResponse) {
                toastr.error("Sorry! We cannot register you for now.");
            });
    }
}

CreateIssueController.$inject = ['$scope', '$http', '$window', 'Urls', 'valdr', 'toastr', 'ObserverService'];
function CreateIssueController($scope, $http, $window, Urls, valdr, toastr, ObserverService) {

    var self = this;
    watchWindowHeight(self, $scope, $window);
    valdr.addConstraints(issueValidationProvider());

    self.CreateIssueCommand = {
        ProjectID: "",
        IssueTypeID: "",
        Summary: "",
        ReporterID: "",
        Description: "",
        PriorityID: "",
        Attachment: "",
        AssigneeID: "",
        SprintID: ""
    };

    self.createIssue = createIssue;
    self.projectConfig = createSelectizeConfig('Select a project', '/project/SearchProject');
    
    self.issueTypeConfig = createSelectizeConfig('Select a issue type', '/Issue/IssueTypes');
    self.reporterConfig = createSelectizeConfig('Select a reporter', '/project/GetMembers');
    self.priorityConfig = createSelectizeConfig('Select a priority', '/Issue/Priorities');
    self.sprintConfig = createSelectizeConfig('Select a sprint', '/ProjectPlanning/SprintOfProject?project=' + self.CreateIssueCommand.ProjectID);
    self.sprintConfig.valueField = "ID";

    self.assigneeConfig = createSelectizeConfig('Select a assignee', '/project/GetMembers');


    function createSelectizeConfig(placeHolder, url) {
        return {
            persist: false,
            selectOnTab: true,
            openOnFocus: true,
            labelField: 'Name',
            valueField: 'Value',
            sortField: 'Name',
            searchField: 'Name',
            loadingClass: 'loading',
            placeholder: placeHolder,
            preload: 'focus',
            load: function (query, callback) {
                $http.get(url, { q: query })
                    .then(function (response) {
                        callback(response.data);
                    });
            }
        };
    }

    

    function issueValidationProvider() {
        return {
            'CreateIssue': {
                'ProjectID': {
                    'required': {
                        'message': 'You need to select a project.'
                    }
                },
                'IssueTypeID': {
                    'required': {
                        'message': 'You need to provide a issue type.'
                    }
                },
                'Summary': {
                    'required': {
                        'message': 'You need to enter summary.'
                    }
                },
                'ReporterID': {
                    'required': {
                        'message': 'You need to assign a reporter.'
                    }
                }
            }
        };
    }

    function createIssue() {
        $http.post('/Issue/CreateIssue', self.CreateIssueCommand)
            .then(function successCallback(response) {
                if (response.status !== 200) {
                    toastr.error('<div style="max-height: 400px; font-size:small; max-width: 100%; overflow: auto;">' + response.data + '</div>');
                } else {
                    $scope.ok();
                    toastr.success("Issue have been created successfully.");
                    ObserverService.notify('issue_created', response.data);
                }

            }, function errorCallback(errorResponse) {
                toastr.error("Sorry!.");
            });
    }
}

function watchWindowHeight(controller, scope, window) {

    controller.modalHeight = "div.modal-body { max-height: " + (window.innerHeight - 200) + "px; overflow: auto  }";

    var w = angular.element(window);
    scope.$watch(
      function () {
          return window.innerHeight;
      },
      function (value) {
          controller.modalHeight = "div.modal-body { max-height: " + (value - 200) + "px; overflow: auto }";
      },
      true
    );

    w.bind('resize', function () {
        scope.$apply();
    });
}