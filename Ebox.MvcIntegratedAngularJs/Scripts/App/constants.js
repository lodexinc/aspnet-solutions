(function () {
    angular.module('appCore')
        .constant('moment', moment);    

    var Urls = {
        LOG_IN: '/authentication/signin',
        REGISTER: '/Account/Register',
        EDIT_PROFILE: '/Profile/EditProfile'
    };

    var ValidationMessages = {
        NOT_VALID_EMAIL: "Not a valid email address.",
        EMAIL_REQUIRED: 'Please enter your email.',
        PASSWORD_REQUIRED: 'Please enter your password.',
        FIRST_NAME_REQUIRED: 'Please enter your first name.',
        LAST_NAME_REQUIRED: 'Please enter your last name.'
    };

    var NotificationMessages = {
        SIGN_IN_SUCCESS: "You have signed in successfully.",
        SIGN_IN_FAIL: "Invalid email or password.",
        REGISTER_SUCCESS: "Congratulation! You have registered successfully.",
        REGISTER_FAIL_DUPLICATED_EMAIL: "This email has been used by other user.",
        EDIT_PROFILE_SUCCESS: "Your profile has been updated."
    };

    angular.module('appCore')
        .constant('Urls', Urls);

    angular.module('appCore')
        .constant('ValidationMessages', ValidationMessages);

    angular.module('appCore')
    .constant('NotificationMessages', NotificationMessages);
})();