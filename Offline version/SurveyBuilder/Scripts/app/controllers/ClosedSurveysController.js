var app = angular.module('SurveyBuilderApp');

app.controller('ClosedSurveysController', ['$scope', '$resource', '$location', 'ClosedSurveyService', 'authService', 'surveys', function ($scope, $resource, $location, closedSurveyService, authService, surveys) {
    //Use an angular resource object since we're restful
    $scope.surveys = surveys;
}]);