var app = angular.module('SurveyBuilderApp');

app.controller('ActiveSurveysController', ['$scope', '$resource', '$location', 'ActiveSurveyService', 'authService', 'surveys', function ($scope, $resource, $location, activeSurveyService, authService, surveys) {
    //Use an angular resource object since we're restful
    $scope.surveys = surveys;

    $scope.goToStatistics = function () {
        $location.path("/activesurveys");
    }
}]);