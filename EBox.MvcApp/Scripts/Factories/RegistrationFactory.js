var RegistrationFactory = function ($http, $q) {
    return function (registerForm) {

        var deferredObject = $q.defer();

        $http.post(
            '/Account/Register', registerForm
        ).
        then(function (response) {
            console.log(response);
            if (response.data === 'object') {
                deferredObject.resolve(response.data);
            } else {
                deferredObject.reject(response.data);
            }
        }, function (response) {
            deferredObject.reject(response.data);
        });

        return deferredObject.promise;
    }
}

RegistrationFactory.$inject = ['$http', '$q'];