

(function (angular) {
    'use strict';

    angular.module('appCore').directive('compileAfter', function ($parse, $compile, angularLoad) {
        return {
            terminal: true,
            compile: function (element, attrs) {
                var contents = element.contents();
                element.empty();
                var compileAfterExp = $parse(attrs.compileAfter);
                return {
                    post: function (scope, element, iAttrs) {
                        compileAfterExp(scope).then(function (response) {

                            angularLoad.loadScript(iAttrs.scriptUrl)
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


   

}(angular));