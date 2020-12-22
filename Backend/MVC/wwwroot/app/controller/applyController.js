(function (app) {
    app.controller('applyController', applyController);

    applyController.$inject = ['$scope', '$http','notificationService'];

    function applyController($scope, $http, notificationService) {
        var formData = new FormData();

        $scope.apply = function () {           
            $http({
                method: 'POST',
                url: '/Candidate/Apply',
                headers: {
                    'Content-Type': undefined
                },
                data: formData
            }).then(function (res) {
                if (res.data == true) {
                    $scope.award = angular.copy({});
                    notificationService.displaySuccess('Bạn đã ứng tuyển thành công!');
                    window.location.href = "/Candidate/ManageJob";
                }
                else {
                    notificationService.displayError('Bạn đã ứng tuyển thất bại!');
                }
            });
        }


        $scope.getFile = function (element) {
            var file = element.files[0];
            if (typeof (file) == 'undefined') {
            }
            else {
                formData.append("file", file);
            }
        }
    }
})(angular.module('erp'));