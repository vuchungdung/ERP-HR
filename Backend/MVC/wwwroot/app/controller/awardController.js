(function (app) {
    app.controller('awardController', awardController);

    awardController.$inject = ['$scope', 'ajaxService','notificationService','$http'];

    function awardController($scope, ajaxService, notificationService, $http) {

        $scope.award = {};

        $scope.create = function () {
            var formData = new FormData();
            for (var key in $scope.award) {
                formData.append(key, $scope.award[key]);
            }
            $http({
                method: 'POST',
                url: '/award/create',
                headers: {
                    'Content-Type': undefined
                },
                data: formData
            }).then(function (res) {
                if (res.data == true) {
                    $scope.get();
                    notificationService.displaySuccess('Bạn đã thêm thành công!');
                    $scope.award = angular.copy({});
                }
                else {
                    notificationService.displayError('Bạn đã thêm thất bại!');
                }
            });
        }


        $scope.get = function () {
            ajaxService.get('/award/get', null, function (res) {
                if (res.data != null) {
                    $scope.awards = res.data;
                }
            }, function (err) {
                console.log(err);
            })
        }

        $scope.get();
    }
})(angular.module('erp'));