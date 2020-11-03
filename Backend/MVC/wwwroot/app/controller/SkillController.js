(function (app) {
    app.controller('skillController', skillController);

    skillController.$inject = ['$scope', 'ajaxService'];

    function skillController($scope, ajaxService) {

        if (localStorage.getItem('keyword') == null) {
            $scope.keyword = '';
        }
        else {
            $scope.keyword = localStorage.getItem('keyword');
        }
        $scope.getAllSkill = function () {
            ajaxService.get('/Skill/GetAll', null, function (res) {
                $scope.listSkill = res.data;
                console.log(res.data);
            }, function (err) {
                console.log(err);
            })
        }
        $scope.getAllSkill();

        $scope.setKeyword = function () {
            localStorage.setItem('keyword', $scope.keyword);
        }
    }
})(angular.module('erp'));