(function (app) {
    app.controller('jobdetailController', jobdetailController);

    jobdetailController.$inject = ['$scope', 'ajaxService'];

    function jobdetailController($scope, ajaxService) {

        $scope.getDetail = function () {
            ajaxService.get('/JobDescription/Detail', null, function (res) {
                $scope.jobdetail = res.data;
                $scope.getSimilar();
            }, function (err) {
                console.log(err);
            });
        }

        $scope.getSimilar = function () {
            ajaxService.get('/JobDescription/SimilarJob', null, function (res) {
                $scope.jobsimilar = res.data;
                console.log($scope.jobsimilar);
            }, function (err) {
                console.log(err);
            });
        }
        $scope.getDetail();
        
    }
})(angular.module('erp'));