(function (app) {
    app.controller('managejobController', managejobController);

    managejobController.$inject = ['$scope', 'ajaxService'];

    function managejobController($scope, ajaxService) {

        $scope.manages = {};

        $scope.get = function () {
            ajaxService.get('/candidate/GetApplyJob', null, function (res) {
                if (res.data != null) {
                    console.log(res.data);
                    $scope.manages = res.data;
                }
            })
        }

        $scope.get();
    }
})(angular.module('erp'));