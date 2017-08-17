linksShortinerApp.config([
    '$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            when('/', {
                templateUrl: 'Partials/CreateLink.html',
                controller: 'createLinkCtrl'
            }).
            when('/history', {
                templateUrl: 'Partials/History.html',
                controller: 'historyCtrl'
            }).
            //when('/:id', {
            //    templateUrl: 'Partials/History.html',
            //    controller: 'historyCtrl'
            //}).
            otherwise({
                redirectTo: '/'
            });
    }
]);