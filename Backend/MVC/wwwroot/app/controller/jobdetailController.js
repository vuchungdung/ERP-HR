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
        $scope.apply = function () {
            ajaxService.get('/Cadidate/Authen', null, function (res) {
                if (res.data == false) {
                    $scope.modal = "modal";
                    $scope.data_target = "#exampleModalCenter";
                }
                else {                
                    $scope.modal = "modal";
                    $scope.data_target = "#formModalCenter";
                }
            }, function (err) {

            });
        }
    }
})(angular.module('erp'));