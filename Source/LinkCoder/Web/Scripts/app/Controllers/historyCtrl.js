linksShortinerControllers.controller('historyCtrl', [
    '$scope', '$rootScope', 'Links', '$location',
    function ($scope, $rootScope, Links, $location) {
        $rootScope.currentTab = 'history';
        $scope.baseUrl = $location.protocol() + '://' + $location.host() + ':' + $location.port() + '/';

        $scope.search = function() {
            $scope.historyEntityPage = Links.query({ pageNumber: $scope.pageNumber, pageSize: $scope.pageSize, userId: $rootScope.UserId }, function() {
                $scope.history = $scope.historyEntityPage.List;
            });
        };

        $scope.reset = function() {
            $scope.pageNumber = 0;
            $scope.pageSize = 10;
            $scope.search();
        };

        $scope.onShortLinkClick = function(item) {
            item.Visits++;
        };

        $scope.onPrevClick = function () {
            if ($scope.pageNumber > 0) {
                $scope.pageNumber--;
                $scope.search();
            }

        };

        $scope.onNextClick = function () {
            if ($scope.pageNumber + 1 < $scope.historyEntityPage.PageCount) {
                $scope.pageNumber++;
                $scope.search();
            }
        };


        $scope.reset();

    }
]);

