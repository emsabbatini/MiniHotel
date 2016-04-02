(function () {
    'use strict';

    angular.module('minihotelpmsApp').controller('reservationController', function ($scope) {
        var vm = this;

        vm.isVisible = false;

        $scope.loadReservation = function (data) {
            vm.reservationsRS = data;
            if (data == []) vm.isVisible = false;
            else vm.isVisible = true;
        };

    });
})();