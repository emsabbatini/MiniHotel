(function () {
    'use strict';

    angular.module('minihotelpmsApp').controller('availableController', function ($scope) {
        var vm = this;

        vm.isVisible = false;

        $scope.expandAll = function (expanded) {
            $scope.$broadcast('onExpandAll', { expanded: expanded });
        };

        $scope.loadAvailable = function (data) {
            vm.isVisible = data ? true : false;
            vm.availableRaters = data;
        };

    });
})();