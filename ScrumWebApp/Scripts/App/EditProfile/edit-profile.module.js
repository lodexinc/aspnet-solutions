
(function () {
    angular.module('EditProfileModule', ['appCore']);

    angular.module('EditProfileModule')
        .config(validationCofig);

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
