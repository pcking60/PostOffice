(function (app) {
    app.controller('propertyListController', propertyListController);
    propertyListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox'];
    function propertyListController($scope, apiService, notificationService, $ngBootbox) {
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.properties = [];
        $scope.getProperties = getProperties;
        $scope.keyword = '';
        $scope.search = search;
        $scope.deleteProperty = deleteProperty;
        function deleteProperty(id) {
            $ngBootbox.confirm('Bạn có chắc xóa không?')
                .then(
                    function () {
                        config =
                            {
                                params: {
                                    id: id
                            }
                    }

                apiService.del(
                    '/api/property/delete',
                    config,
                    function () {
                        notificationService.displaySuccess('Xóa dữ liệu thành công');
                        search();
                    },
                    function () {
                        notificationService.displaySuccess('Xóa dữ liệu thất bại');
                    }

                );

            }, function () {
                console.log('Command was cancel!');
            });
        }
        function search() {
            getProperties();
        }
        function getProperties(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 20
                }
            }
            apiService.get('/api/property/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning("Chưa có dữ liệu");
                }
                $scope.properties = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            },
            function () {
                console.log('Load properties failed');
            });
        } $scope.getProperties();
    }
})(angular.module('postoffice.properties'));
