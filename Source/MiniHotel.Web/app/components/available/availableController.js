(function () {
    'use strict';

    angular.module('minihotelpmsApp').controller('availableController', function ($scope) {
        var vm = this;

        vm.isVisible = false;

        vm.expandAll = function (expanded) {
            $scope.$broadcast('onExpandAll', { expanded: expanded });
        };

        $scope.loadAvailable = function (data) {
            vm.availableRaters = data;
            if (data == []) vm.isVisible = false;
            else vm.isVisible = true;
        };

    });
})();