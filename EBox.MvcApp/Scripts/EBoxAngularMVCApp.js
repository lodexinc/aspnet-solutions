var EBoxAngularMVCApp = angular.module('EBoxAngularMVCApp', ['ui.router', 'ui.bootstrap']);

EBoxAngularMVCApp.controller('HomePageController', HomePageController);
EBoxAngularMVCApp.controller('LoginController', LoginController);
EBoxAngularMVCApp.controller('RegisterController', RegisterController);

EBoxAngularMVCApp.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);
EBoxAngularMVCApp.factory('LoginFactory', LoginFactory);
EBoxAngularMVCApp.factory('RegistrationFactory', RegistrationFactory);



var configFunction = function ($stateProvider, $httpProvider, $locationProvider) {

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });

    $stateProvider
        .state('index', {
            url: '/index?donuts',
            views: {
                "containerOne": {
                    templateUrl: '/Home/Index'
                },
                "containerTwo": {
                    templateUrl: function (params) {
                        if (params.donuts) {
                            return '/Home/About?donuts=' + params.donuts;
                        }
                        else {
                            return "/Home/About";
                        }
                    }
                }
            }
        })
        .state('about', {
            url: '/about',
            views: {
                "containerOne": {
                    templateUrl: '/Home/About'
                },
                "containerTwo": {
                    templateUrl: '/Home/Contact'
                }
            }
        })
        .state('contact', {
            url: '/contact?donuts',
            views: {
                "containerOne": {
                    templateUrl: function (params) { return '/Home/About?donuts=' + params.donuts; }
                },
                "containerTwo": {
                    templateUrl: '/Home/Contact'
                }
            }
        })
        .state('loginRegister', {
            url: '/loginRegister',            
            templateUrl: '/Account/Login',
            controller: LoginController               
        })
        .state('resetPassword', {
            url: '/resetPassword',
            templateUrl: '/Account/ResetPassword',
            controller: LoginController
        })
        .state('register', {
            url: '/register',            
            templateUrl: '/Account/Register',
            controller: RegisterController               
        })
        .state('RequireActiveEmail', {
            url: '/requireactivemail?email',
            templateUrl: function (params) {
                return '/Account/RequireActiveEmail'+params.email;
            },
            controller: RegisterController               
        }).
        state('verifyaccount', {
            url: '/verifyaccount?t&c',
            templateUrl: function (params) {
                return '/Account/Verify?t='+params.t+"&c="+params.c;
            },
            controller: RegisterController               
        })
        .state('externalLoginConfirm', {
            url: '/externalLoginConfirm',
            templateUrl: '/Account/ExternalLoginConfirm',
            controller: LoginController
        })
        .state('externalLoginFailure', {
            url: '/externalLoginFailure',
            templateUrl: '/Account/ExternalLoginFailure',
            controller: LoginController
        })
        .state('externalLoginCallback', {
            url: '/login-external',
            templateUrl: '/Account/ExternalLoginCallback',
            controller: LoginController
        });
    


    $httpProvider.interceptors.push('AuthHttpResponseInterceptor');


}
configFunction.$inject = ['$stateProvider', '$httpProvider', '$locationProvider'];
var runFunction = function ($rootScope, $location, $injector) {
    $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams, options) {

    });
};
runFunction.$inject = ['$rootScope', '$location', '$injector'];
EBoxAngularMVCApp.config(configFunction).run(runFunction);