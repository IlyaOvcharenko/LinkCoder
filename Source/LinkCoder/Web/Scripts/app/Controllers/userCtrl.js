linksShortinerControllers.controller('userCtrl', [
    '$scope', '$rootScope', 'Users',
function ($scope, $rootScope, Users) {
    $scope.auth = function () {
        $rootScope.UserId = localStorage.getItem('userId');
        if (!$rootScope.UserId) {
            Users.create({}, function (data) {
                localStorage.setItem('userId', data.Id);
                $rootScope.UserId = data.Id;
            });
        }
        
    }

    $scope.auth();
}
]);

