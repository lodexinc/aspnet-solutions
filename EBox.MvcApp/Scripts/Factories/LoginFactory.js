var LoginFactory = function ($http, $q, $rootScope) {
    var login = function (emailAddress, password, rememberMe) {

        var deferredObject = $q.defer();

        $http.post(
            '/Account/Login', {
                Email: emailAddress,
                Password: password,
                RememberMe: rememberMe
            }
        ).
        success(function (response) {
            if (response.success) {
                deferredObject.resolve({ success: true });
                $rootScope.loggedInUser = {
                    email: emailAddress
                };
                console.log($rootScope);

            } else {
                deferredObject.resolve({ success: false, errMess : response.IdentityMessage});
            }
        }).
        error(function () {
            deferredObject.resolve({ success: false });
        });

        return deferredObject.promise;
    };

    var confirmLogin = function (email, password) {
        var deferredObject = $q.defer();
        $http.post(
            '/Account/ExternalLoginConfirmation', {
                Email: email,
                Password: password
            }
        ).
        success(function (response) {
            if (response == "True") {
                deferredObject.resolve({ success: true });
                $rootScope.loggedInUser = {
                    email: email
                };
            } else {
                deferredObject.resolve({ success: false });
            }
        }).
        error(function () {
            deferredObject.resolve({ success: false });
        });
        return deferredObject.promise;
    }

    var logout = function () {

        var deferredObject = $q.defer();

        $http.get('/Account/Logout').
        success(function (response) {
            if (response == "True") {
                deferredObject.resolve({ success: true });
                delete $rootScope.loggedInUser;
            } else {
                deferredObject.resolve({ success: false });
            }
        }).
        error(function () {
            deferredObject.resolve({ success: false });
        });

        return deferredObject.promise;
    };
    var resetPassword = function (email) {

        var deferredObject = $q.defer();

        $http.post('/Account/ResetPassword', { email: email }).
        success(function (response) {
            if (response == "True") {
                deferredObject.resolve({ success: true });                
            } else {
                deferredObject.resolve({ success: false });
            }
        }).
        error(function () {
            deferredObject.resolve({ success: false });
        });

        return deferredObject.promise;
    };
    return {
        login: login,
        logout: logout,
        resetPassword: resetPassword,
        confirmLogin: confirmLogin
    }

}

LoginFactory.$inject = ['$http', '$q', '$rootScope'];