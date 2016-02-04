'use strict';
var SurveyBuilderApp = angular.module('SurveyBuilderApp');

SurveyBuilderApp.config(function($routeProvider, localStorageServiceProvider, $httpProvider) {
    //Setup routes
    $routeProvider
        .when("/", {
            templateUrl: "/Home/Home"
        })
        .when("/surveys", {
            templateUrl: "/Home/Surveys",
            controller: "SurveysController",
            resolve: {
                surveys: [
                    'SurveyService', '$route', function(surveyService, $route) {
                        return surveyService.query().$promise;
                    }
                ]
            }
        }).when("/surveys/new", {
            templateUrl: "/Home/NewSurvey",
            controller: "SurveyDetailsController",
            resolve: {
                surveyToEdit: [
                    'SurveyService', function(surveyService) {
                        return {};
                    }
                ]
            }
        }).when("/surveys/:surveyId", {
            templateUrl: "/Home/NewSurvey",
            controller: "SurveyDetailsController",
            resolve: {
                surveyToEdit: [
                    'SurveyService', '$route', function(surveyService, $route) {
                        if ($route.current.params["surveyId"]) {
                            return surveyService.get($route.current.params).$promise;
                        }
                    }
                ]
            }
        })
        .when("/take-survey/:surveyId", {
            templateUrl: "/Home/TakeSurvey",
            controller: "TakeSurveyController",
            resolve: {
                surveyToTake: [
                    'SurveyService', '$route', function(surveyService, $route) {
                        if ($route.current.params["surveyId"]) {
                            return surveyService.get($route.current.params).$promise;
                        }
                    }
                ]
            }
        })
        .when("/take-survey/:surveyId/success", {
            templateUrl: "/Home/SurveyComplete",
            controller: "TakeSurveyController",
            resolve: {
                surveyToTake: [
                    'SurveyService', '$route', function (surveyService, $route) {
                        if ($route.current.params["surveyId"]) {
                            return surveyService.get($route.current.params).$promise;
                        }
                    }
                ]
            }
        })

        .when("/closedsurveys", {
            templateUrl: "/Home/ClosedSurveys",
            controller: "ClosedSurveysController",
            resolve: {
                surveys: [
                    'ClosedSurveyService', '$route', function (closedSurveyService, $route) {
                        return closedSurveyService.query().$promise;
                    }
                ]
            }
        }).when("/activesurveys", {
            templateUrl: "/Home/ActiveSurveys",
            controller: "ActiveSurveysController",
            resolve: {
                surveys: [
                    'ActiveSurveyService', '$route', function (activeSurveyService, $route) {
                        return activeSurveyService.query().$promise;
                    }
                ]
            }
        }).when("/filledsurveys", {
            templateUrl: "/Home/FilledSurveys",
            controller: "FilledSurveysController",
            resolve: {
                surveys: [
                    'FilledSurveyService', '$route', function (filledSurveyService, $route) {
                        return filledSurveyService.query().$promise;
                    }
                ]
            }
        }).when("/statistics/:surveyId", {
            templateUrl: "/Home/Statistics",
            controller: "StatisticsController",
            resolve: {
                surveyToTake: [
                    'FilledSurveyService', '$route', function (filledSurveyService, $route) {
                        if ($route.current.params["surveyId"]) {
                            return filledSurveyService.get($route.current.params).$promise;
                        }
                    }
                ]
            }
        })
    
        .when("/login", {
            templateUrl: "/Account/Login",
            controller: "loginController",
        })
        .when("/register", {
            templateUrl: "/Account/Register",
            controller: "registerController",
        })
        .otherwise("/");
});