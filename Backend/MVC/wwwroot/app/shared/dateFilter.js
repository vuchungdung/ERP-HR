(function (app) {
    app.filter('dateFilter', function () {
        return function (result, input) {
            input = input.substr(0, 10);
            result = input;
            return result;
        }
    })
})(angular.module('erp'));