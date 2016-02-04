var SurveyBuilderApp = angular.module('SurveyBuilderApp',
    [   'ngResource',
        'ngRoute',
        'ui.sortable',
        'LocalStorageModule'
    ]);

SurveyBuilderApp.config(function ($routeProvider, localStorageServiceProvider, $httpProvider) {

    //Setup local storage
    localStorageServiceProvider
        .setPrefix("SurveyBuilder")
        .setStorageCookieDomain('localhost:56971');

    //Setup interceptor
    $httpProvider.interceptors.push('authInterceptorService');
});

SurveyBuilderApp.run(['authService', function (authService) {
    authService.fillAuthData();
}]);