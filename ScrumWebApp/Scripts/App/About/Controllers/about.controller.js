
(function () {

    angular.module('AboutModule').controller("AboutController", AboutController);
    AboutController.$inject = ['$scope'];
    function AboutController($scope) {
        $scope.pageHeading = "About Section - THanh Tran";
    }
})();
