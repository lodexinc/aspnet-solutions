
(function () {
    angular.module('ProjectPlanModule', ['appCore']);

    angular.module('ProjectPlanModule')
        .run(Config);

    Config.$inject = ['ngLaddaService', 'Urls'];
    function Config(ngLaddaService, Urls) {

        // link a httpRequest to a unique event/name
        ngLaddaService.register('GET', '/project/SearchProject', 'searchProject');
    }
})();
