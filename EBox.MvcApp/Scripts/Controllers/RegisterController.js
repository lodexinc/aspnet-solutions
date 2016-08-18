var RegisterController = function ($rootScope,$scope, $location, RegistrationFactory) {

    $scope.emailFormat = '/^[A-Za-z0-9._%+-]+@("@")[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$/';

    $scope.registerForm = {
        firstName: '',
        lastName:"",
        emailAddress: '',
        password: '',
        confirmPassword: '',
        registrationFailure: false
    };
    $rootScope.hideMenuBar = true;
    $scope.register = function () {
        var result = RegistrationFactory($scope.registerForm);
        result.then(function (response) {
            console.log(response);
            if (response.success) {
                $scope.emailAddress = response.Email;
                $location.path('/Account/RequireActivEmail');
            } else {
                $scope.registerForm.registrationFailure = true;
            }
        });

    }
}

RegisterController.$inject = ['$rootScope', '$scope', '$location', 'RegistrationFactory'];
