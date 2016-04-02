(function () {
    'use strict';

    angular.module('minihotelpmsApp').directive('search', function () {
          return {
              restrict: 'E',
              templateUrl: 'app/shared/search/search.html',
              controller: 'searchController',
              controllerAs: 'search'
          };
    });
})();