var app = angular.module('SurveyBuilderApp');
app.factory('ClosedSurveyService', ['$resource', function ($resource) {
    return $resource("/api/ClosedSurveys", {}, {
        'query': {
            method: 'GET',
            isArray: true
        }
    });
}]);