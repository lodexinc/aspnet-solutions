
(function () {
    angular.module('HomeModule', ['appCore'])
        .run(function ($rootScope, $timeout, $q, $http) {
            // Attach any promises to the `appReady` expression which
            // will be picked up by the `compile-after` directive
            $rootScope.homeModuleReady = $q.all([
                $http.get("/Home/Home")
            ]);
        });
})();



