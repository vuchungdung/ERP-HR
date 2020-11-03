(function (app) {
    app.controller('bradcamController', bradcamController);

    bradcamController.$inject = ['$scope', 'ajaxService'];

    function bradcamController($scope, ajaxService) {

        $scope.getCount = function () {
            ajaxService.get('/JobDescription/GetAll', null, function (res) {
                $scope.count = res.data.length;
                console.log($scope.count);
            }, function (err) {
                console.log(err);
            })
        }
        $scope.getCount();
    }
})(angular.module('erp'));