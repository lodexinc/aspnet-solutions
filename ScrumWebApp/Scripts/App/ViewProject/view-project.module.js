
(function () {
    angular.module('ViewProjectModule', ['appCore']);

    angular.module('ViewProjectModule')
        .run(Config);

    Config.$inject = ['ngLaddaService', 'Urls'];
    function Config(ngLaddaService, Urls) {

        // link a httpRequest to a unique event/name
        ngLaddaService.register('GET', '/project/SearchProject', 'searchProject');
    }

})();
