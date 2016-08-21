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

        $scope.items = ['item1', 'item2', 'item3'];
        $scope.animationsEnabled = true;
        $scope.open = function (size) {
            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'myModalContent.html',
                controller: 'CreateModalInstanceController',
                size: size,
                resolve: {
                    items: function () {

                        return $scope.items;
                    }
                }
            });

            modalInstance.result.then(function (selectedItem) {

                $scope.selected = selectedItem;
            }, function () {
                $log.info('Modal dismissed at: ' + new Date());
            });

            modalInstance.rendered.then(function (selectedItem) {

                //$http.get('/Issue/CreateIssue').then(function successCallback(response) {
                //    var element = angular.element($("div.modal-content"));
                //    var compiledHtml = $compile(response.data)($scope);
                //    element.append(compiledHtml);
                //}, function errorCallback(errorResponse) {

                //});

            }, function () {

            });
        };
    }

    angular.module('appCore').controller('CreateModalInstanceController', CreateModalInstanceController);

    CreateModalInstanceController.$inject = ['$scope', '$http', '$uibModalInstance', 'items', '$compile'];
    function CreateModalInstanceController($scope, $http, $uibModalInstance, items, $compile) {
        $scope.items = items;
        $http.get('/Issue/CreateIssue').then(function successCallback(response) {
            var element = angular.element($("#spinInModal"));
            var compiledHtml = $compile(response.data)($scope);
            element.replaceWith(compiledHtml);
        }, function errorCallback(errorResponse) {

        });
        $scope.selected = {
            item: $scope.items[0]
        };

        $scope.ok = function () {
            $uibModalInstance.close($scope.selected.item);
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

    angular.module('appCore')
    .directive("remoteView", function ($templateRequest, $compile, $window) {
        return {
            replace: true,
            scope: true,
            link: function (scope, element, attrs) {
                element.append($compile('<cube-grid-spinner></cube-grid-spinner')(scope));
                $templateRequest(attrs.url).then(function (html) {
                    element.replaceWith($compile(html)(scope));
                });
            }
        };
    });

})();