(function () {
    'use strict';

    angular.module('minihotelpmsApp').service('minihotelpmsservice', function ($http) {
    
        var service = {
            getAvailableRaters: getAvailableRaters
        };

        return service;

        function getAvailableRaters(data) {

            var config = {};

            return $http.post('http://localhost:54298/api/minihotelpms/availableraters', data, config).then(function (response) {
                return response.data.Data;
            }, function (error) {
                // TODO
            });
        }

    });

})();