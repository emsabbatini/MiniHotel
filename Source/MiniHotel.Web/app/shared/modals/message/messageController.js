(function () {
    'use strict';

    angular.module('minihotelpmsApp').controller('messageController', function ($scope, $uibModalInstance, icon, message) {
        
        $scope.icon = icon;
        $scope.message = message;

        $scope.ok = function () {
            $uibModalInstance.dismiss('cancel');
        };

        $uibModalInstance.close();

    });
})();