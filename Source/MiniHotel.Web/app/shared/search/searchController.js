(function () {
    'use strict';

    angular.module('minihotelpmsApp').controller('searchController', function ($scope, minihotelpmsservice, constants, $location, $uibModal, dataservice) {
        var vm = this;


            vm.datepickerOptions = { showTodayButton: true, format:"DD/MM/YYYY"

            };


        vm.isDisabled = true;
        vm.exportDataHeader = [];
        vm.exportData = [];
        
        vm.isReservationsView = $location.$$path != constants.partialView['AVAILABLE'] ? true : false;

        vm.dateFromLabel = vm.isReservationsView ? 'Arrival From:' : 'Date From:';
        vm.dateFromOpened = false;
        vm.dateFromOpen = function () { vm.dateFromOpened = true; };
        
        vm.dateToLabel = vm.isReservationsView ? 'Arrival To:' : 'Date To:';
        vm.dateToOpened = false;
        vm.dateToOpen = function () { vm.dateToOpened = true; };
        vm.dateToSetMin = function () {
            vm.dateToMin = vm.dateFrom;
            vm.dateToInit = vm.isReservationsView ? new Date() : vm.dateFrom;
            vm.dateToMin.setDate(vm.dateToMin.getDate() + 1);
        };

        vm.dateDepFromOpened = false;
        vm.dateDepFromOpen = function () { vm.dateDepFromOpened = true; };
        
        vm.dateDepToOpened = false;
        vm.dateDepToOpen = function () { vm.dateDepToOpened = true; };
        vm.dateDepToSetMin = function () {
            vm.dateDepToMin = vm.dateDepFrom;
            vm.dateDepToInit = vm.isReservationsView ? new Date() : vm.dateDepFrom;
            vm.dateDepToMin.setDate(vm.dateDepToMin.getDate() + 1);
        };
        
        vm.isRequired = vm.isReservationsView ? true : false;
       
        if (!vm.isReservationsView) {
            vm.dateFromMin = new Date();
        } else {
            vm.dateFromMin = new Date(0, 1, 1);
            vm.dateDepFromMin = new Date(0, 1, 1);
        }

        vm.search = function () {

            switch ($location.$$path) {
                case constants.partialView['AVAILABLE']:
                    getAvailableRaters();
                    break;
                case constants.partialView['RESERVATION']:
                    getReservations();
                    break;
            }
        };

        function getAvailableRaters() {

            var availableRequest = {
                'Username': 'test',
                'Password': '2222',
                'HotelId': 'testhotel',
                'HotelCurrency': 'USD',
                'DateFrom': vm.dateFrom,
                'DateTo': vm.dateTo,
                'Adults': '2',
                'Child': '0',
                'Babies': '0',
                'RateCode': '*ALL'
            };

            minihotelpmsservice.getAvailableRaters(availableRequest).then(function (data) {
                if (!data.HasError){
                    $scope.loadAvailable(data.DataObject);
                    vm.isDisabled = false;
                    parseExportaData(data.DataObject);
                } 
                    
                else {
                    $scope.loadAvailable([]);
                    showModal(constants.iconType['WARNING'], data.ErrorMessage);
                    vm.isDisabled = true;
                    
                }
            }, function (error) {
                $scope.loadAvailable([]);
                alert("TODO: ERROR SERVER!!!");
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
                if (!data.HasError){
                    $scope.loadReservation(data.DataObject);
                    vm.isDisabled = false;
                    parseExportaData(data.DataObject);
                }
                else {
                    $scope.loadReservation([]);
                    vm.isDisabled = true;
                    showModal(constants.iconType['WARNING'], data.ErrorMessage);
                }
            }, function (error) {
                $scope.loadReservation([]);
                alert("TODO: ERROR SERVER!!!");
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

    });
})();