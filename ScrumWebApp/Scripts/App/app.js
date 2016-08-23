(function () {
    var dependencies = [
            'ui.bootstrap',
            'ui.select',
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
            'smart-table'
    ];

    angular.module('appCore', dependencies);
    angular.module('appCore').factory('ObserverService', [ObserverService]);
    angular.module('appCore').controller('NavController', NavController);
    angular.module('appCore').controller('CreateModalInstanceController', CreateModalInstanceController);
    angular.module('appCore').controller('CreateIssueController', CreateIssueController);
    angular.module('appCore').controller('CreateProjectController', CreateProjectController);
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

CreateProjectController.$inject = ['$scope', '$http', '$window', 'ngLaddaService', 'Urls', 'valdr', 'valdrMessage', 'ValidationMessages', 'toastr', 'ObserverService'];
function CreateProjectController($scope, $http, $window, ngLaddaService, Urls, valdr, valdrMessage, ValidationMessages, toastr, ObserverService) {
    var self = this;
    watchWindowHeight(self, $scope, $window);
    ngLaddaService.register('POST', '/Project/CreateProject', 'createProject');

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

CreateIssueController.$inject = ['$scope', '$window'];
function CreateIssueController($scope, $window) {
    var self = this;
    watchWindowHeight(self, $scope, $window);

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