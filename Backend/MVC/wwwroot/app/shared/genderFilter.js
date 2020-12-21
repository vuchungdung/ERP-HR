(function (app) {
    app.filter('genderFilter', function () {
        return function (input) {
            if (input == 0) {
                return 'Nam'
            }
            else if (input == 1) {
                return 'Nữ'
            }
        }
    })
})(angular.module('erp'));