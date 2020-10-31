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

        $scope.getCount = function () {
            ajaxService.get('/JobDescription/GetAll', null, function (res) {
                $scope.count = res.data.length;
                console.log(res.data);
            }, function (err) {
                console.log(err);
            })
        }
        $scope.getAllNew = function () {
            ajaxService.get('/JobDescription/GetAllNew', null, function (res) {
                $scope.listJobNew = res.data;
                console.log(res.data);
            }, function (err) {
                console.log(err);
            });
        }

        $scope.getAllNew();
        $scope.getCount();
    }
})(angular.module('erp'));