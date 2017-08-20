var linksShortinerApp = angular.module('linksShortinerApp', ['ngRoute', 'linksShortinerControllers', 'ngResource']).config(['$locationProvider', function ($locationProvider) {
    $locationProvider.hashPrefix('');
}]);;

linksShortinerApp.factory('Users', ['$resource',
    function ($resource) {
        return $resource('api/Users', {}, { create: { method: 'POST' } });
    }
]);

linksShortinerApp.factory('Links', ['$resource', '$rootScope',
    function ($resource, $rootScope) {
        return $resource('api/Users/:userId/Links', { userId: '@userId' }, { create: { method: 'POST', headers: { 'Token': $rootScope.Token } }, query: { method: 'get', isArray: false, headers: { 'Token': $rootScope.Token } } });
    }
]);

var linksShortinerControllers = angular.module('linksShortinerControllers', []);

