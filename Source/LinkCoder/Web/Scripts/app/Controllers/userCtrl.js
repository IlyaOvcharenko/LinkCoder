linksShortinerControllers.controller('userCtrl', [
    '$scope', '$rootScope', 'Users',
function ($scope, $rootScope, Users) {
    $rootScope.auth = function () {
        $rootScope.UserId = localStorage.getItem('userId');
        $rootScope.Token = localStorage.getItem('token');
        if (!$rootScope.UserId || !$rootScope.Token) {
            Users.create({}, function(data) {
                localStorage.setItem('userId', data.user.Id);
                localStorage.setItem('token', data.token);
                $rootScope.UserId = data.user.Id;
                $rootScope.Token = data.token;
            });
        } 
        
    }

    $rootScope.auth();
}
]);

