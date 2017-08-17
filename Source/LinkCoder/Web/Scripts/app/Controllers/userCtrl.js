linksShortinerControllers.controller('userCtrl', [
    '$scope', '$rootScope', 'Users',
function ($scope, $rootScope, Users) {
    $scope.auth = function () {
        $rootScope.User = localStorage.getItem('userId');
        if (!$rootScope.User) {
            $rootScope.User = Users.create({}, function () {
                localStorage.setItem('userId', $rootScope.User.Id);
            });
        }
        
    }

    $scope.auth();
}
]);

