
(function () {
    'use strict';

    angular.module('PetModule').controller("PetController", PetController);

    PetController.$inject = ['$scope', '$http', 'toastr', 'Urls', 'Flash',
        'NotificationMessages', 'ObserverService', 'dragularService'];
    function PetController($scope,
        $http, toastr, Urls, Flash, NotificationMessages, ObserverService, dragularService) {
        var self = this;

        self.init = init;
        self.createPet = createPet;



        function init(pet) {
            self.Pet = pet;
        }

        function createPet() {
            $http.post("/Pet/CreatePet", self.Pet)
                .then(function (response) {

                    self.Pet = response.data;

                },
                function (res) { });
        }
    };
})();



