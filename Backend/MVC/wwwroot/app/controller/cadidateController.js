(function (app) {

    app.controller('cadidateUserController', cadidateUserController);

    cadidateUserController.$inject = ['$scope','ajaxService'];

    function cadidateUserController($scope, ajaxService) {

        $scope.user = {
            Username: "",
            Password: ""
        };

        $scope.register = function () {
            ajaxService.post('/Cadidate/Register', $scope.user, function (res) {
                if (res.data == true) {
                    
                }
                else {
                    
                    
                }
            }, function (err) {
                    
                   
            });
        };

        $scope.login = function () {
            ajaxService.post('/Cadidate/Login', $scope.user, function (res) {
                if (res.data == true) {
                    window.location.reload();

                }
            }, function (err) {
                console.log(err);
            });
        }
    }

})(angular.module('erp'));