var app = angular.module('SurveyBuilderApp');

app.controller('FilledSurveysController', ['$scope', '$resource', '$location', 'FilledSurveyService', 'authService', 'surveys', function ($scope, $resource, $location, filledSurveyService, authService, surveys) {
    //Use an angular resource object since we're restful
    $scope.surveys = surveys;
}]);