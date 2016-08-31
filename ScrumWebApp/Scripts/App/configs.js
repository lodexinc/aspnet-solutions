(function () {

    angular.module('appCore').config([
        '$httpProvider', function ($httpProvider) {
            // Watch out! When you send requests via angular’s $http, IE could be caching and re-serving the result.
            // Initialize get if not there
            if (!$httpProvider.defaults.headers.get) {
                $httpProvider.defaults.headers.get = {};
            }

            // Enables Request.IsAjaxRequest() in ASP.NET MVC
            $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';

            // Disable IE ajax request caching
            $httpProvider.defaults.headers.get['If-Modified-Since'] = '0';
        }
    ]);

    angular.module('appCore')
        .config(function ($locationProvider) {
            $locationProvider.html5Mode({
                enabled: true,
                requireBase: false
            });
        });

    angular.module('appCore')
        .config(function (blockUIConfig) {
            blockUIConfig.message = 'Hang on!';
            blockUIConfig.delay = 0;
            blockUIConfig.autoInjectBodyBlock = false;
            blockUIConfig.blockBrowserNavigation = true;
            blockUIConfig.template = '<div class=\"block-ui-overlay\"></div><div class=\"block-ui-message-container\" aria-live=\"assertive\" aria-atomic=\"true\"><circle-spinner></circle-spinner></div>';
        });

    angular.module('appCore')
    .config(function (toastrConfig) {
        angular.extend(toastrConfig, {
            closeButton: true,
            timeOut: 0,
            extendedTimeOut: 0,
            autoDismiss: false,
            allowHtml: true,
            iconClasses: {
                error: 'toast-error',
                info: 'toast-info',
                success: 'toast-success',
                warning: 'toast-warning'
            },
            closeHtml: '<button>&times;</button>',
            positionClass: 'toast-bottom-full-width',
            target: 'body'
        });
    });

    angular.module('appCore').config(validationCofig);

    function validationCofig(valdrProvider, valdrMessageProvider) {
        valdrMessageProvider.setTemplate('<div class="valdr-message">{{ violation.message }}</div>');
    }

    angular.module('appCore')
    .config(flashMessageConfig);

    function flashMessageConfig(FlashProvider) {
        FlashProvider.setTimeout(0);
        FlashProvider.setShowClose(true);
    }

    angular.module('appCore')
        .run(laddaServiceConfig);

    laddaServiceConfig.$inject = ['ngLaddaService', 'Urls'];
    function laddaServiceConfig(ngLaddaService, Urls) {
        ngLaddaService.register('POST', Urls.LOG_IN, 'sign-in');
        ngLaddaService.register('POST', '/Issue/CreateIssue', 'CreateIssue');
        ngLaddaService.register('GET', '/Issue/IssueTypes', 'IssueTypes');
        ngLaddaService.register('GET', '/Issue/Priorities', 'Priorities');
        ngLaddaService.register('POST', '/Project/CreateProject', 'createProject');
        ngLaddaService.register('POST', Urls.REGISTER, 'register');
        ngLaddaService.register('POST', '/ProjectPlanning/CreateSprint', 'createSprint');
        ngLaddaService.register('GET', '/project/SearchProject', 'searchProject');
        ngLaddaService.register('POST', '/Pet/CreatePet', 'createPet');
        ngLaddaService.register('POST', Urls.EDIT_PROFILE, 'editProfile');
    }

})();