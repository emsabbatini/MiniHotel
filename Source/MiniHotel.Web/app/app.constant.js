(function () {
	'use strict';

	angular.module('minihotelpmsApp').constant('constants', {
		iconType: {
		    WARNING: 'fa fa-exclamation-triangle fa-3x',
		    ERROR: 'fa fa-times-circle fa-3x'
		},
		partialView: {
		    AVAILABLE: '/',
		    RESERVATION: '/reservation'
		}
	});

})();