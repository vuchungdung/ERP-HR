(function (app) {
    app.controller('sliderController', sliderController);

    sliderController.$inject = ['$scope', 'ajaxService'];

    function sliderController($scope, ajaxService) {

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