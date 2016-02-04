var app = angular.module('SurveyBuilderApp');
app.factory('FilledSurveyService', ['$resource', function ($resource) {
    return $resource("/api/FilledSurveys", {}, {
        'query': {
            method: 'GET',
            isArray: true
        }
    });
}]);