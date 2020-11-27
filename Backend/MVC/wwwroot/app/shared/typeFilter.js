(function(app) {
    app.filter('typeFilter', function () {
        return function (input) {
            if (input == 0) {
                return 'Full Time'
            }
            else {
                return 'Part Time'
            }
        }
    })
}) (angular.module('erp'));