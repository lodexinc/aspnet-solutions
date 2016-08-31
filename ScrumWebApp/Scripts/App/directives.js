angular.module('appCore').directive('compileAfter', function ($parse, $compile) {
    return {
        terminal: true,
        compile: function (element, attrs) {
            var contents = element.contents();
            element.empty();
            var compileAfterExp = $parse(attrs.compileAfter);
            return function postLink(scope, element) {
                compileAfterExp(scope).then(function (response) {
                    element.replaceWith($compile(response[0].data)(scope));
                });
            };
        }
    };
});