(function(app) {
    app.filter('typeFilter', function () {
        return function (input) {
            if (input == 1) {
                return 'Full Time'
            }
            else {
                return 'Part Time'
            }
        }
    })
}) (angular.module('erp'));