(function () {
    'use strict';

    angular.module('minihotelpmsApp').controller('reservationController', function ($scope) {
        var vm = this;

        vm.isVisible = false;

        $scope.loadReservation = function (data) {
            vm.isVisible = data ? true : false;
            vm.reservationsRS = data;
        };

    });
})();