linksShortinerControllers.controller('createLinkCtrl', [
    '$scope', '$rootScope', 'Links',
    function ($scope, $rootScope, Links) {
        $rootScope.currentTab = 'create';

        $scope.onShortenBtnClick = function() {
            $scope.shortLink = Links.create({ originalLink: $scope.originalLink, userId: $rootScope.UserId }, function () {
            });
        };
    }
]);

