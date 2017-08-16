linksShortinerApp.config([
    '$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            when('/', {
                templateUrl: 'Partials/CreateLink.html',
                controller: 'createLinkCtrl'
            }).
            when('/links', {
                templateUrl: 'Partials/LinksList.html',
                controller: 'linksListCtrl'
            }).
            when('/:id', {
                templateUrl: 'Partials/LinksList.html',
                controller: 'linksListCtrl'
            }).
            otherwise({
                redirectTo: '/'
            });
    }
]);