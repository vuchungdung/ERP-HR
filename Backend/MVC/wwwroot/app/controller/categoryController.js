(function (app) {
    app.controller('categoryController', categoryController);

    categoryController.$inject = ['$scope', 'ajaxService'];

    function categoryController($scope, ajaxService) {

        $scope.getAllCategory = function () {
            ajaxService.get('/Category/GetAll', null, function (res) {
                $scope.listCategory = res.data;
                console.log(res.data);
            }, function (err) {
                console.log(err);
            })
        }
        $scope.getAllCategory();
    }
}) (angular.module('erp'));