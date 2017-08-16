var linksShortinerApp = angular.module('linksShortinerApp', ['ngRoute', 'linksShortinerControllers', 'ngResource', 'ngCookies']);

linksShortinerApp.factory('Users', ['$resource',
    function ($resource) {
        return $resource('api/Users', {  }, { create: { method: 'POST' } });
    }
]);

var linksShortinerControllers = angular.module('linksShortinerControllers', []);

