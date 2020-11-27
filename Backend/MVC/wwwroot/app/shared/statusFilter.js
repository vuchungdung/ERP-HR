(function (app) {
    app.filter('statusFilter', function () {
        return function (input) {
            if (input == 0) {
                return 'Đang tuyển'
            }
            else if (input == 1) {
                return 'Ngừng tuyển'
            }
        }
    })
})(angular.module('erp'));