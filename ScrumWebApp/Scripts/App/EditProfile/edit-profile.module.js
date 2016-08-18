
(function () {
    angular.module('EditProfileModule', ['appCore']);

    angular.module('EditProfileModule')
        .config(validationCofig);

    angular.module('EditProfileModule')
        .run(Config);

    Config.$inject = ['ngLaddaService', 'Urls'];
    function Config(ngLaddaService, Urls) {

        // link a httpRequest to a unique event/name
        ngLaddaService.register('POST', Urls.EDIT_PROFILE, 'editProfile');
    }

    function validationCofig(valdrProvider, valdrMessageProvider, ValidationMessages) {
        valdrProvider.addConstraints({
            'EditProfile': {
                'firstName': {
                    'required': {
                        'message': ValidationMessages.FIRST_NAME_REQUIRED
                    }
                },
                'lastName': {
                    'required': {
                        'message': ValidationMessages.LAST_NAME_REQUIRED
                    }
                }
            }
        });
    }
})();
