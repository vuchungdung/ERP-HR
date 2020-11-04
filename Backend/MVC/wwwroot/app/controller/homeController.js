(function (app) {
    app.controller('homeController', homeController);

    homeController.$inject = ['$scope', 'ajaxService'];

    function homeController($scope, ajaxService) {

        $scope.getAllNew = function () {
            ajaxService.get('/JobDescription/GetAllNew', null, function (res) {
                $scope.listJobNew = res.data;
                console.log($scope.listJobNew);
            }, function (err) {
                console.log(err);
            });
        }

        $scope.getAllNew();
    }
})(angular.module('erp'));