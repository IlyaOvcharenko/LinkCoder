linksShortinerControllers.controller('userCtrl', [
    '$scope', '$rootScope', 'Users', '$location', '$cookies',
function ($scope, $rootScope, Users, $location, $cookies) {
    $scope.auth = function () {
        $rootScope.User = $cookies.get('userId');
        if (!$rootScope.User) {
            $rootScope.User = Users.create({}, function () {
                $cookies.put('userId', $rootScope.User.Id);
            });
        }
        
    }

    $scope.auth();
}
]);

