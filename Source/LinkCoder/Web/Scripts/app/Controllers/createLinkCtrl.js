linksShortinerControllers.controller('createLinkCtrl', [
    '$scope', '$rootScope', 'Links', '$location',
    function ($scope, $rootScope, Links, $location) {
        $rootScope.currentTab = 'create';

        $scope.onShortenBtnClick = function (createLinkForm) {
            if (createLinkForm.$valid) {
                Links.create({ originalLink: $scope.originalLink, userId: $rootScope.UserId }, function(data) {
                    $scope.shortLink = $location.protocol() + '://' + $location.host() + ':' + $location.port() + '/' + data.Id;
                });
            }
        };
    }
]);

