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

        $scope.update = function () {
            var formData = new FormData();
            for (var key in $scope.e) {
                formData.append(key, $scope.e[key]);
            }
            $http({
                method: 'POST',
                url: '/education/update',
                headers: {
                    'Content-Type': undefined
                },
                data: formData
            }).then(function (res) {
                if (res.data == true) {
                    $scope.get();
                    notificationService.displaySuccess('Bạn cập nhật thành công!');
                    $scope.e = angular.copy({});
                }
                else {
                    notificationService.displayError('Bạn cập nhật thất bại!');
                }
            });
        }

        $scope.get = function () {
            ajaxService.get('/education/get', null, function (res) {
                if (res.data != null) {
                    console.log(res.data);
                    $scope.educations = res.data;
                }
            }, function (err) {
                console.log(err);
            })
        }

        $scope.get();

        $scope.getId = function (id) {
            $scope.e = {};
            ajaxService.get('/education/getid?id=' + id, null, function (res) {
                if (res.data != null) {
                    $scope.e = res.data;
                    console.log($scope.e);
                }
            })
        }

        $scope.delete = function (id) {
            $scope.e = {};
            ajaxService.get('/education/delete?id=' + id, null, function (res) {
                if (res.data == true) {
                    $scope.get();
                    notificationService.displaySuccess('Bạn cập nhật thành công!');
                }
            })
        }
    }
})(angular.module('erp'));