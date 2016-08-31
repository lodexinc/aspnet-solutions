
(function () {
    angular.module('RegisterModule', ['appCore']);

    angular.module('RegisterModule')
        .config(validationCofig);

    function validationCofig(valdrProvider, valdrMessageProvider, ValidationMessages) {
        valdrProvider.addConstraints({
            'Register': {
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
                ,
                'firstName': {
                    'required': {
                        'message': ValidationMessages.FIRST_NAME_REQUIRED
                    }
                }
                ,
                'lastName': {
                    'required': {
                        'message': ValidationMessages.LAST_NAME_REQUIRED
                    }
                }
            }
        });
    }
})();
