
(function () {

    angular.module('SignInModule', ['appCore']);

    angular.module('SignInModule')
        .run(Config);

    Config.$inject = ['ngLaddaService', 'Urls'];
    function Config(ngLaddaService, Urls) {

        // link a httpRequest to a unique event/name
        ngLaddaService.register('POST', Urls.LOG_IN, 'sign-in');
    }

    angular.module('SignInModule')
        .config(validationCofig);

    function validationCofig(valdrProvider, valdrMessageProvider, ValidationMessages) {
        valdrProvider.addConstraints({
            'SignIn': {
                'email': {
                    "email": {
                        "message": ValidationMessages.NOT_VALID_EMAIL
                    },
                    'required': {
                        'message': ValidationMessages.EMAIL_REQUIRED
                    }
                },
                'password': {
                    'required': {
                        'message': ValidationMessages.PASSWORD_REQUIRED
                    }
                }
            }
        });
    }


})();
