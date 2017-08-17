var linksShortinerApp = angular.module('linksShortinerApp', ['ngRoute', 'linksShortinerControllers', 'ngResource']).config(['$locationProvider', function ($locationProvider) {
    $locationProvider.hashPrefix('');
}]);;

linksShortinerApp.factory('Users', ['$resource',
    function ($resource) {
        return $resource('api/Users', {}, { create: { method: 'POST' } });
    }
]);

linksShortinerApp.factory('Links', ['$resource',
    function ($resource) {
        return $resource('api/Links', {}, { create: { method: 'POST' } });
    }
]);

var linksShortinerControllers = angular.module('linksShortinerControllers', []);

