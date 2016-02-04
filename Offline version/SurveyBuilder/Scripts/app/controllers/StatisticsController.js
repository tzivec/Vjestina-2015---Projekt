var app = angular.module('SurveyBuilderApp');

app.controller('StatisticsController', ['$scope', '$resource', '$location', 'FilledSurveyService', 'authService', 'surveyToTake', function ($scope, $resource, $location, filledSurveyService, authService, surveyToTake) {
    //Use an angular resource object since we're restful

    $scope.survey = surveyToTake;

    $scope.goToSurveys = function () {
        $location.path("/filledsurveys");
    }

}]);