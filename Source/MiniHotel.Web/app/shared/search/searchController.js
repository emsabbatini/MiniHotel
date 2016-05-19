(function () {
    'use strict';

    angular.module('minihotelpmsApp').controller('searchController', function ($scope, minihotelpmsservice, constants, $location, $uibModal, dataservice, commonservice) {
        var vm = this;

        vm.exportDataHeader = [];
        vm.exportData = [];

        vm.isReservation = $location.$$path != constants.partialView['AVAILABLE'] ? true : false;

        vm.buttonsStyle = vm.isReservation ? { 'margin': '10% auto' } : {};

        vm.dateFromLabel = vm.isReservation ? 'Arrival From:' : 'Date From:';
        vm.dpDateFromOptions = {
            format:"YYYY-MM-DD",
            showTodayButton: true,
            defaultDate: vm.isReservation ? false : commonservice.getDateYYYYMMDD(commonservice.getDateAdd(new Date(), 1))
        };

        vm.dateToLabel = vm.isReservation ? 'Arrival To:' : 'Date To:';
        vm.dpDateToOptions = {
            format: "YYYY-MM-DD",
            showTodayButton: true,
            defaultDate: vm.isReservation ? false : commonservice.getDateYYYYMMDD(commonservice.getDateAdd(new Date(), 2))
        };

        vm.isFieldRequired = !vm.isReservation ? true : false;

        vm.isDisabled = true;

        vm.search = function () {
            if (!vm.isReservation) getAvailableRaters();
            else getReservations();
        }
        vm.print = function () {

            if (!vm.isReservation) $scope.expandAll(true);

            setTimeout(function () { window.print(); }, 500);
        }
               
        function getAvailableRaters() {

            var availableRequest = {
                'Username': 'test',
                'Password': '2222',
                'HotelId': 'testhotel',
                'HotelCurrency': 'USD',
                'DateFrom': new Date(vm.dateFrom),
                'DateTo': new Date(vm.dateTo),
                'Adults': '2',
                'Child': '0',
                'Babies': '0',
                'RateCode': '*ALL'
            };

            minihotelpmsservice.getAvailableRaters(availableRequest).then(function (data) {
                if (!data.HasError){
                    $scope.loadAvailable(data.DataObject);
                    vm.isDisabled = false;
                    setData(data.DataObject);
                }  
                else showError(constants.iconType['WARNING'], data.ErrorMessage, $scope.loadAvailable(null));
            }, function (error) {
                showError(constants.iconType['ERROR'], "ERROR SERVER!!!", $scope.loadAvailable(null));
            });
        }

        function getReservations() {

            var reservationRequest = {
                'Username': 'test',
                'Password': '2222',
                'HotelId': 'testhotel',
                'CreateDateFrom': new Date(),   // Not implemented
                'CreateDateTo': new Date(),     // Not implemented
                'ArrivalDateFrom': vm.dateFrom,
                'ArrivalDateTo': vm.dateTo,
                'DepartureDateFrom': vm.dateDepFrom,
                'DepartureDateTo': vm.dateDepTo
            };

            minihotelpmsservice.getReservations(reservationRequest).then(function (data) {
                if (!data.HasError) {
                    $scope.loadReservation(data.DataObject);
                    vm.isDisabled = false;
                    setData(data.DataObject);
                }
                else showError(constants.iconType['WARNING'], data.ErrorMessage, $scope.loadReservation(null));
            }, function (error) {
                showError(constants.iconType['ERROR'], "ERROR SERVER!!!", $scope.loadReservation(null));
            });

        }

        function showModal(icon, message) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: 'app/shared/modals/message/message.html',
                controller: 'messageController',
                resolve: {
                    icon: function () {
                        return icon;
                    },
                    message: function () {
                        return message;
                    }
                }
            });
        }

        function showError(icon, message, callback) {
            vm.isDisabled = true;
            if (callback) callback();
            showModal(icon, message);
        }

        function setData(data) {
            var obj = dataservice.parseData(data);
            vm.exportData = obj.exportData;
            vm.exportDataHeader = obj.exportDataHeader;
        }

    });
})();