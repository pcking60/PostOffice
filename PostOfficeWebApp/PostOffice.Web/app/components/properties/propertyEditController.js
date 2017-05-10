(function (app) {
    app.controller('propertyEditController', propertyEditController);
    propertyEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state', '$stateParams', 'commonService'];
    function propertyEditController($scope, apiService, notificationService, $state, $stateParams, commonService) {
        $scope.property = {
            CreatedDate: new Date(),
            Status: true,
        }
        $scope.EditProperty = EditProperty;
        
        function loadPropertyDetail() {
            apiService.get('/api/property/getbyid/' + $stateParams.id, null, function (result) {
                $scope.property = result.data
            }, function (error) {
                notificationService.displayError(error.data)
            });
        }
        function EditProperty() {
            apiService.put('/api/property/update', $scope.property,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' được cập nhật thành công');
                    $state.go('properties');
                }, function (error) {
                    notificationService.displayError('Cập nhật thất bại');
                });
        }
        function loadServices() {
            apiService.get('/api/property/getallnoparam', null, function (result) {
                $scope.services = result.data;
            }, function () {
                console.log('Can not load services!');
            });
        }

        loadServices();
        loadPropertyDetail();
    }
})(angular.module('postoffice.properties'));