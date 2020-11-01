(function (app) {

    app.controller('cadidateUserController', cadidateUserController);

    cadidateUserController.$inject = ['$scope','ajaxService'];

    function cadidateUserController($scope, ajaxService) {

        $scope.user = {
            Username: "",
            Password: ""
        };

        $scope.register = function () {
            ajaxService.post('/CadidateUser/Register', $scope.user, function (res) {
                console.log(res.data);
            }, function (err) {
                console.log(err);
            });
        }

        $scope.login = function () {
            ajaxService.post('/CadidateUser/Login', $scope.user, function (res) {
                console.log(res.data);
            }, function (err) {
                console.log(err);
            });
        }
    }

})(angular.module('erp'));