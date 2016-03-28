(function() {
  'use strict';

  angular.module('minihotelpmsApp').config(function ($routeProvider, $httpProvider) {

    $routeProvider
      .when('/', {
          templateUrl : 'app/components/available/available.html',
          controller: 'availableController'
      })
      .when('/reservation', {
          templateUrl : 'app/components/reservation/reservation.html',
          controller  : 'reservationController'
      });

    $httpProvider.interceptors.push('httpinterceptor');

  });

})();
