(function (app) {
    app.controller('jobdescriptionController', jobdescriptionController);

    jobdescriptionController.$inject = ['$scope','ajaxService'];

    function jobdescriptionController($scope, ajaxService) {

        $scope.page = 1;
        $scope.pageSize = 9;
        $scope.curPage = 0;
        $scope.pageCount = 0;
        $scope.getPaging = function (page) {
            $scope.curPage = page;
            var config = {
                params: {
                    keyword: localStorage.getItem('keyword'),
                    pageSize: $scope.pageSize,
                    pageIndex: page
                }
            }
            ajaxService.post('/JobDescription/GetAllPaging', config.params, function (res) {
                $scope.listPagingJob = res.data.listItems;
                $scope.totalRecords = res.data.totalRecords;
                $scope.pageCount = res.data.pageCount;
                console.log($scope.listPagingJob);
            }, function (err) {
                console.log(err);
            })
        };

        $scope.getDetail = function () {

        }

        $scope.searchJob = function () {
            $scope.getPaging($scope.page);        
        }

        $scope.addSession = function (id) {

        }

        $scope.getPaging($scope.page);
    }
})(angular.module('erp'));