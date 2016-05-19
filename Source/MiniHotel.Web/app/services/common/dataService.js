(function () {
    'use strict';

    angular.module('minihotelpmsApp').service('dataservice', function ($location, constants) {
    
        var service = { parseData: parseData };

        return service;

        function parseData(data){

            var returnData = {};
            returnData.exportData = [];
            returnData.exportDataHeader = [];
            
            var res = {};

            switch ($location.$$path) {
                case constants.partialView['AVAILABLE']:
                    returnData.exportDataHeader = ['ROOM TYPE', 'BOARD CODE', 'BOARD DESCRIPTION', 'VALUE'];
                    for (var i = 0; i < data.RoomType.length; i++) {
                        for (var j = 0; j < data.RoomType[i].Price.length; j++)
                        {
                            res = {
                                roomtype: data.RoomType[i].Name_H,
                                code: data.RoomType[i].Price[j].Board,
                                description: data.RoomType[i].Price[j].BoardDesc,
                                value: data.RoomType[i].Price[j].Value
                            };
                            returnData.exportData.push(res);
                        }                        
                    }
                    break;
                case constants.partialView['RESERVATION']:
                    returnData.exportDataHeader = ['RESERVATION NUMBER', 'OTA NUMBER', 'FIRST NAME', 'LAST NAME', 'PASSPORT', 'CREATION DATE', 'ARRIVAL DATE', 'DEPARTURE DATE'];
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
                        returnData.exportData.push(res);
                    }
                    break;
            }

            return returnData;
        }

    });

})();