(function () {
    'use strict';

    angular.module('minihotelpmsApp').directive("spinner", function ($rootScope) {
        return function ($scope, element, attrs) {
            $scope.$on("spinner_show", function () {
                $scope.isSpinnerOn = true;
            });
            return $scope.$on("spinner_hide", function () {
                $scope.isSpinnerOn = false;
            });
        };

    });
})();