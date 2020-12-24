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

(function (app) {
    app.filter('processFilter', function () {
        return function (input) {
            if (input == 1) {
                return 'Thành công'
            }
            else if (input == 2) {
                return 'Thất bại'
            }
        }
    })
})(angular.module('erp'));