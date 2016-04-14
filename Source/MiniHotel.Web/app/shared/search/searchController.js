(function () {
    'use strict';

    angular.module('minihotelpmsApp').controller('searchController', function ($scope, minihotelpmsservice, constants, $location, $uibModal) {
        var vm = this;

        vm.exportIsDisabled = true;
        vm.exportDataHeader = [];
        vm.exportData = [];
        
        vm.isReservationsView = $location.$$path != constants.partialView['AVAILABLE'] ? true : false;

        vm.dateFromLabel = vm.isReservationsView ? 'Arrival From:' : 'Date From:';
        vm.dateFromOpened = false;
        vm.dateFromOpen = function () { vm.dateFromOpened = true; };
        vm.dateFromMin = new Date();
        
        vm.dateToLabel = vm.isReservationsView ? 'Arrival To:' : 'Date To:';
        vm.dateToOpened = false;
        vm.dateToOpen = function () { vm.dateToOpened = true; };
        vm.dateToSetMin = function () {
            vm.dateToMin = vm.dateFrom;
            vm.dateToInit = vm.dateFrom;
            vm.dateToMin.setDate(vm.dateToMin.getDate() + 1);

        };

        vm.dateDepFromOpened = false;
        vm.dateDepFromOpen = function () { vm.dateDepFromOpened = true; };
        vm.dateDepFromMin = new Date();

        vm.dateDepToOpened = false;
        vm.dateDepToOpen = function () { vm.dateDepToOpened = true; };
        vm.dateDepToSetMin = function () {
            vm.dateDepToMin = vm.dateDepFrom;
            vm.dateDepToInit = vm.dateDepFrom;
            vm.dateDepToMin.setDate(vm.dateDepToMin.getDate() + 1);
        };

        vm.isRequired = vm.isReservationsView ? true : false;
       
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
                    vm.exportIsDisabled = false;
                    parseExportaData(data.DataObject);
                } 
                    
                else {
                    $scope.loadAvailable([]);
                    showModal(constants.iconType['WARNING'], data.ErrorMessage);
                    vm.exportIsDisabled = true;
                    
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
                    vm.exportIsDisabled = false;
                    parseExportaData(data.DataObject);
                }
                else {
                    $scope.loadReservation([]);
                    vm.exportIsDisabled = true;
                    showModal(constants.iconType['WARNING'], data.ErrorMessage);
                }
            }, function (error) {
                $scope.loadReservation([]);
                alert("TODO: ERROR SERVER!!!");
            });

        }

        function parseExportaData(data) {

            vm.exportData = [];
            vm.exportDataHeader = [];
            
            var res = {};

            switch ($location.$$path) {
                case constants.partialView['AVAILABLE']:
                    vm.exportDataHeader = ['ROOM TYPE', 'BOARD CODE', 'BOARD DESCRIPTION', 'VALUE'];
                    for (var i = 0; i < data.RoomType.length; i++) {
                        for (var j = 0; j < data.RoomType[i].Price.length; j++)
                        {
                            res = {
                                roomtype: data.RoomType[i].Name_H,
                                code: data.RoomType[i].Price[j].Board,
                                description: data.RoomType[i].Price[j].BoardDesc,
                                value: data.RoomType[i].Price[j].Value
                            };
                            vm.exportData.push(res);
                        }                        
                    }
                    break;
                case constants.partialView['RESERVATION']:
                    vm.exportDataHeader = ['NUMBER', 'OTA NUMBER', 'FIRST NAME', 'LAST NAME', 'PASSPORT', 'CREATE DATE', 'ARRIVAL DATE', 'DEPARTURE DATE'];
                    for (var i = 0; i < data.Reservation.length; i++) {
                        res = {
                            number: data.Reservation[i].ResNumbers.Number,
                            otanumber: data.Reservation[i].ResNumbers.OtaNumber,
                            firstname: data.Reservation[i].MainGuest.FirstName,
                            lastname: data.Reservation[i].MainGuest.LastName,
                            passport: data.Reservation[i].MainGuest.Passport,
                            createdate: data.Reservation[i].ResDates.CreateDate,
                            arrivaldate: data.Reservation[i].ResDates.Arrival,
                            departuredate: data.Reservation[i].ResDates.Departure,
                        };
                        vm.exportData.push(res);
                    }
                    break;
            }
        };

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