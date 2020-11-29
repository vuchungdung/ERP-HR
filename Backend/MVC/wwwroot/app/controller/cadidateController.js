(function (app) {

    app.controller('cadidateController', cadidateController);

    cadidateController.$inject = ['$scope','ajaxService'];

    function cadidateController($scope, ajaxService) {

        $scope.user = {
            Username: "",
            Password: ""
        };

        $scope.register = function () {

            alert("Hello");

            ajaxService.post('/Cadidate/Register', $scope.user, function (res) {
                if (res.data == true) {
                    
                }
                else {
                    
                    
                }
            }, function (err) {                    
                console.log(err);
            });
        };

        $scope.login = function () {
            ajaxService.post('/Cadidate/Login', $scope.user, function (res) {
                if (res.data == true) {
                    window.location.reload();
                }
                else {

                }
            }, function (err) {
                console.log(err);
            });
        }
    }

})(angular.module('erp'));