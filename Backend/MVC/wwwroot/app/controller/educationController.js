(function (app) {
    app.controller('educationController', educationController);

    educationController.$inject = ['$scope', 'ajaxService', '$http','notificationService'];

    function educationController($scope, ajaxService, $http, notificationService) {

        $scope.education = {};

        $scope.create = function () {
            var formData = new FormData();
            for (var key in $scope.education) {
                formData.append(key, $scope.education[key]);
            }
            $http({
                method: 'POST',
                url: '/education/create',
                headers: {
                    'Content-Type': undefined
                },
                data: formData
            }).then(function (res) {
                if (res.data == true) {
                    $scope.get();
                    notificationService.displaySuccess('Bạn đã thêm thành công!');
                    $scope.education = angular.copy({});
                }
                else {
                    notificationService.displayError('Bạn đã thêm thất bại!');
                }
            });
        }
        

        $scope.get = function () {
            ajaxService.get('/education/get', null, function (res) {
                if (res.data != null) {
                    $scope.educations = res.data;
                }
            }, function (err) {
                console.log(err);
            })
        }

        $scope.get();
    }
})(angular.module('erp'));