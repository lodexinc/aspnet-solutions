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
            'textAngular'
    ];

    angular.module('appCore', dependencies);

    angular.module('appCore').controller('NavController', NavController);

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

    angular.module('appCore').controller('CreateModalInstanceController', CreateModalInstanceController);

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

    angular.module('appCore').controller('CreateIssueController', CreateIssueController);

    CreateIssueController.$inject = ['$scope', '$window'];
    function CreateIssueController($scope, $window) {
        var self = this;
        self.modalHeight = "div.modal-body { max-height: " + ($window.innerHeight - 200) + "px; overflow: auto  }";

        var w = angular.element($window);
        $scope.$watch(
          function () {
              return $window.innerHeight;
          },
          function (value) {
              self.modalHeight = "div.modal-body { max-height: " + (value - 200) + "px; overflow: auto }";
          },
          true
        );

        w.bind('resize', function () {
            $scope.$apply();
        });
    }

    angular.module('appCore').controller('CreateProjectController', CreateProjectController);

    CreateProjectController.$inject = ['$scope', '$http', '$window', 'ngLaddaService', 'Urls', 'valdr', 'valdrMessage', 'ValidationMessages', 'toastr'];
    function CreateProjectController($scope, $http, $window, ngLaddaService, Urls, valdr, valdrMessage, ValidationMessages, toastr) {
        ngLaddaService.register('POST', '/Project/CreateProject', 'createProject');

        valdr.addConstraints({
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
        });

        var self = this;
        self.CreateProjectCommand = {
            name: "",
            key: ""
        };

        self.createProject = function () {
            $http.post('/Project/CreateProject', self.CreateProjectCommand)
                .then(function successCallback(response) {
                    // this callback will be called asynchronously
                    // when the response is available
                    // self.message = JSON.stringify(response);

                    $scope.ok();
                    toastr.success("Project have been created successfully.");

                }, function errorCallback(errorResponse) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.                   
                    toastr.error("Sorry! We cannot register you for now.");
                });
        };



        self.modalHeight = "div.modal-body { max-height: " + ($window.innerHeight - 200) + "px; overflow: auto  }";

        var w = angular.element($window);
        $scope.$watch(
          function () {
              return $window.innerHeight;
          },
          function (value) {
              self.modalHeight = "div.modal-body { max-height: " + (value - 200) + "px; overflow: auto }";
          },
          true
        );

        w.bind('resize', function () {
            $scope.$apply();
        });
    }

})();