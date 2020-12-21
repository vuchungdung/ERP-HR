(function (app) {
    app.controller('workhistoryController', workhistoryController);

    workhistoryController.$inject = ['$scope', 'ajaxService','notificationService','$http'];

    function workhistoryController($scope, ajaxService, notificationService, $http) {

        $scope.workhistory = {};

        $scope.create = function () {            
            console.log($scope.workhistory);
            var formData = new FormData();
            for (var key in $scope.workhistory) {
                formData.append(key, $scope.workhistory[key]);
            }
            $http({
                method: 'POST',
                url: '/workhistory/create',
                headers: {
                    'Content-Type': undefined
                },
                data: formData
            }).then(function (res) {
                if (res.data == true) {
                    $scope.get();
                    notificationService.displaySuccess('Bạn đã thêm thành công!');
                    $scope.workhistory = angular.copy({});
                }
                else {
                    notificationService.displayError('Bạn đã thêm thất bại!');
                }
            });
        }


        $scope.get = function () {
            ajaxService.get('/workhistory/get', null, function (res) {
                if (res.data != null) {
                    $scope.workhistories = res.data;
                }
            }, function (err) {
                console.log(err);
            })
        }

        $scope.get();
    }
})(angular.module('erp'));