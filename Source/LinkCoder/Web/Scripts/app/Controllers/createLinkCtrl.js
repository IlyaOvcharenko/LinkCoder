linksShortinerControllers.controller('createLinkCtrl', [
    '$scope', '$rootScope', 'Links', '$location',
    function($scope, $rootScope, Links, $location) {
        $rootScope.currentTab = 'create';

        $scope.onShortenBtnClick = function(createLinkForm) {
            if (createLinkForm.$valid) {
                Links.create({ originalLink: $scope.originalLink, userId: $rootScope.UserId })
                    .$promise
                    .then(function(data) {
                            $scope.shortLink = $location.protocol() + '://' + $location.host() + ':' + $location.port() + '/' + data.shortLink.Id;
                            $scope.errorMessage = '';
                        },
                        function error(response) {
                            if (response.status == 400 && response.data && response.data.Errors) {
                                $scope.shortLink = '';
                                angular.forEach(response.data.Errors, function(value, key) {
                                    $scope.errorMessage = value.Message;
                                });


                            }
                        });

            }
        };
    }
]);

