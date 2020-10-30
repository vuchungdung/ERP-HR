(function (app) {
    app.controller('jobdescriptionController', jobdescriptionController);

    jobdescriptionController.$inject = ['$scope','ajaxService'];

    function jobdescriptionController($scope, ajaxService) {
        $scope.keyword = '';
        $scope.page = 1;
        $scope.pageSize = 10;
        $scope.curPage = 0;
        $scope.getPaging = function (page) {
            $scope.curPage = page;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    pageSize: $scope.pageSize,
                    pageIndex: page
                }
            }
            ajaxService.post('/JobDescription/GetAllPaging', config.params, function (res) {
                console.log(res.data);
            }, function (err) {
                console.log(err);
            })
        };

        $scope.getPaging($scope.page);
    }
})(angular.module('erp'));