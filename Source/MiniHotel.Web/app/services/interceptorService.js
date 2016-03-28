(function () {
    'use strict';

    angular.module('minihotelpmsApp').factory('httpinterceptor', function ($q, $rootScope, $log) {

        var numLoadings = 0;

        return {
            request: function (config) {

                numLoadings++;

                // Show loader
                $rootScope.$broadcast("spinner_show");
                return config || $q.when(config)

            },
            response: function (response) {

                if ((--numLoadings) === 0) {
                    // Hide loader
                    $rootScope.$broadcast("spinner_hide");
                }

                return response || $q.when(response);

            },
            responseError: function (response) {

                if (!(--numLoadings)) {
                    // Hide loader
                    $rootScope.$broadcast("spinner_hide");
                }

                return $q.reject(response);
            }
        };
    });
})();