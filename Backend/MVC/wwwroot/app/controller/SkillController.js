(function (app) {
    app.controller('skillController', skillController);

    skillController.$inject = ['$scope', 'ajaxService'];

    function skillController($scope, ajaxService) {

        $scope.getAllSkill = function () {
            ajaxService.get('/Skill/GetAll', null, function (res) {
                $scope.listSkill = res.data;
                console.log(res.data);
            }, function (err) {
                console.log(err);
            })
        }
        $scope.getAllSkill();
    }
})(angular.module('erp'));