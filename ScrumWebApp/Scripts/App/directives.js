

(function (angular) {
    'use strict';

    angular.module('appCore').directive('compileAfter', function ($parse, $compile, LazyDirectiveLoader) {
        return {
            terminal: true,
            compile: function (element, attrs) {
                var contents = element.contents();
                element.empty();
                var compileAfterExp = $parse(attrs.compileAfter);
                return {
                    post: function (scope, element, iAttrs) {
                        compileAfterExp(scope).then(function (response) {

                            LazyDirectiveLoader.load(iAttrs.scriptUrl)
                                .then(function () {
                                    // Script loaded succesfully.
                                    // We can now start using the functions from someplugin.js

                                    element.replaceWith($compile(response[0].data)(scope));
                                }).catch(function () {
                                    // There was some error loading the script. Meh
                                });


                        });
                    }
                };

            }
        };
    });

    angular.module('appCore').service('LazyDirectiveLoader', ['$rootScope', '$q', '$compile', function ($rootScope, $q, $compile) {

        var _load = function (url) {


            var deferred = $q.defer();
            var directiveFile = url;

            // download the javascript file
            var script = document.createElement('script');
            script.src = directiveFile;
            script.onload = function () {
                $rootScope.$apply(deferred.resolve);
            };

            document.getElementsByTagName('body')[0].appendChild(script);
            return deferred.promise;
        };

        return {
            load: _load
        };

    }]);


}(angular));