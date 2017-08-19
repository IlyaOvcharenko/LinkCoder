linksShortinerControllers.controller('historyCtrl', [
    '$scope', '$rootScope', 'Links', '$location',
    function ($scope, $rootScope, Links, $location) {
        $rootScope.currentTab = 'history';
        $scope.baseUrl = $location.protocol() + '://' + $location.host() + ':' + $location.port() + '/';

        $scope.search = function () {
            $scope.historyEntityPage = Links.query({ pageNumber: $scope.pageNumber, pageSize: $scope.pageSize, userId: $rootScope.UserId }, function () {
                $scope.history = $scope.historyEntityPage.List;
            });
        }

        $scope.reset = function () {
            $scope.pageNumber = 0;
            $scope.pageSize = 10;
            $scope.search();
        }

        $scope.onShortLinkClick = function(item) {
            item.Visits++;
        }

        $scope.reset();

    }
]);

