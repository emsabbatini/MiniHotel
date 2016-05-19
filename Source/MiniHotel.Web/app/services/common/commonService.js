(function () {
    'use strict';

    angular.module('minihotelpmsApp').service('commonservice', function ($http) {

        var service = {
            getDateAdd: getDateAdd,
            getDateYYYYMMDD: getDateYYYYMMDD
        };

        return service;

        function getDateAdd(date, days) {
            if (date) return date.setDate(date.getDate() + days);
            else return new Date().setDate(new Date().getDate() + days);
        }

        function getDateYYYYMMDD(dateParam) {
            var date = new Date(dateParam);
            var y = date.getFullYear().toString();
            var m = (date.getMonth() + 1).toString();
            var d = date.getDate().toString();
            return y + "-" + m + "-" + d;
        }

    });

})();