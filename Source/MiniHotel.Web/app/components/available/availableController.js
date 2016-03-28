(function () {
    'use strict';

    angular.module('minihotelpmsApp').controller("availableController", function ($scope, minihotelpmsservice, constants, $uibModal) {
        var vm = this;

        vm.isVisible = false

        $scope.expandAll = function (expanded) {
            $scope.$broadcast('onExpandAll', { expanded: expanded });
        };

        $scope.search = function () {

            var dataRequest = {
                'Username': 'test',
                'Password': '2222',
                'HotelId': 'testhotel',
                'HotelCurrency': 'USD',
                'DateFrom': $scope.dateFrom,
                'DateTo': $scope.dateTo,
                'Adults': '2',
                'Child': '0',
                'Babies': '0',
                'RateCode': '*ALL'
            };

            minihotelpmsservice.getAvailableRaters(dataRequest).then(function (data) {
                if (!data.HasError) {
                    $scope.isVisible = true
                    $scope.availableRaters = data.DataObject;
                } else {
                    $scope.isVisible = false
                    showModal(constants.iconType['WARNING'], data.ErrorMessage);
                }
            }, function (error) {
                $scope.isVisible = false
                $scope.availableRaters = [];
                alert("Error");
            });
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