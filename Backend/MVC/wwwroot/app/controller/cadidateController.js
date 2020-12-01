(function (app) {

    app.controller('cadidateController', cadidateController);

    cadidateController.$inject = ['$scope', 'ajaxService','$http'];

    function cadidateController($scope, ajaxService, $http) {

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

        $scope.logOut = function () {
            ajaxService.get('/Cadidate/LogOut', null, function (res) {
                if (res.data == true) {
                    window.location.reload();
                }
            })
        }



        $scope.img = '';
        $scope.pdf = '';
        $scope.postCadidate = function () {
            console.log($scope.cadidate.img);
            console.log($scope.cadidate.pdf);
        }

        $scope.remove = function () {
            $scope.img = '';
            $scope.pdf = '';
            alert("Gì cơ")
        }

        $scope.getFile = function (element) {
            var file = element.files[0];
            if (typeof (file) == 'undefined') {
                alert("Gì đấy")
            }
            else {
                var formData = new FormData();
                formData.append('file', file);
                $http({
                    url: '/File/UpLoad',
                    method: 'POST',
                    data: formData,
                    headers: { 'Content-Type': undefined }
                }).then(function (res) {
                    if (res.data.fileType == ".jpg") {
                        $scope.img = res.data.fileName;
                    }
                    else {
                        $scope.pdf = res.data.fileName;
                    }
                })
            }
        };
    }

})(angular.module('erp'));