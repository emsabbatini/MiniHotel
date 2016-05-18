(function() {
  'use strict';

  angular.module('minihotelpmsApp').config(function ($routeProvider, $httpProvider, constants) {

    $routeProvider
      .when(constants.partialView['AVAILABLE'], {
          templateUrl : 'app/components/available/available.html',
          controller: 'availableController',
          controllerAs: 'available'
      })
      .when(constants.partialView['RESERVATION'], {
          templateUrl : 'app/components/reservation/reservation.html',
          controller: 'reservationController',
          controllerAs: 'reservations'
      });

    $httpProvider.interceptors.push('httpinterceptor');

  });

})();
