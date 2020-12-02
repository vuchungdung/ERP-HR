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

        $scope.cadidate = {};

        $scope.postCadidate = function () {
            var formData = new FormData();
            for (var key in $scope.cadidate) {
                formData.append(key, item[key]);
            }
            $scope.listFile.forEach(file => {
                formData.append('files', file);
            });

            ajaxService.post('/')
        }

        $scope.removeImg = function () {
            $scope.img = '';           
        }

        $scope.removePdf = function () {
            $scope.pdf = '';
        }

        $scope.listFile = [];

        $scope.getFile = function (element) {
            var file = element.files[0];
            if (typeof (file) == 'undefined') {
            }
            else {
                $scope.listFile.push(file);
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