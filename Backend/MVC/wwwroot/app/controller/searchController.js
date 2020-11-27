(function (app) {
    app.controller('searchController', searchController);

    searchController.$inject = ['$scope', 'ajaxService'];

    function searchController($scope, ajaxService) {
        $scope.keyword = "";
    }
})(angular.module('erp'));