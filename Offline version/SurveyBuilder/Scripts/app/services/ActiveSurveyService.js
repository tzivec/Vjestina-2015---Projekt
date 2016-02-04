var app = angular.module('SurveyBuilderApp');
app.factory('ActiveSurveyService', ['$resource', function ($resource) {
    return $resource("/api/ActiveSurveys", {}, {
        'query': {
            method: 'GET',
            isArray: true
        }
    });
}]);