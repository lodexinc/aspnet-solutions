
var LoginController = function ($rootScope, $scope, $stateParams, $location, LoginFactory) {
    $scope.loginForm = {
        emailAddress: '',
        password: '',
        rememberMe: false,
        returnUrl: $stateParams.returnUrl,
        loginFailure: false,
        LoginErrMess: ""
    };
    $scope.resetPasswordForm = {
        email: ''
    };
    $scope.userConfirmLoginForm = {
        email: '',
        password: ''
    };

    $rootScope.hideMenuBar = true;
    $scope.login = function () {
        console.log($scope.loginForm);
        var result = LoginFactory.login($scope.loginForm.emailAddress, $scope.loginForm.password, $scope.loginForm.rememberMe);
        result.then(function (data) {
            if (data.success) {
                if ($scope.loginForm.returnUrl === undefined) {
                    $location.path('/about');
                } else {
                    $scope.loginForm.loginFailure = true;
                    $scope.loginForm.LoginErrMess = data.errMess;
                    $location.path($scope.loginForm.returnUrl);
                    $location.$$search = {};
                    
                }
            } else {
                $scope.loginForm.LoginErrMess = data.errMess;
                $scope.loginForm.loginFailure = true;
            }
        });
    }

    $scope.resetPassword = function () {
        console.log($scope.resetPasswordForm);
        var result = LoginFactory.resetPassword($scope.resetPasswordForm.email);
        result.then(function (data) {
           
        });
    }

    //Handle for confirm Login by external sign in (Google & Facebook);
    $scope.init = function (user) {
        $scope.userConfirmLoginForm.email = user.Email;
    }

    $scope.confirm = function () {
        var result = LoginFactory.confirmLogin($scope.userConfirmLoginForm.email, $scope.userConfirmLoginForm.password);
        result.then(function (data) {
            if (data.success) {
                $location.path('/about');
            } else {
                $location.path('/externalLoginFailure');
            }
        });
    }
}

LoginController.$inject = ['$rootScope', '$scope', '$stateParams', '$location','LoginFactory'];

