/// <reference path="../angular.min.js" />


var myApp = angular.module("myApp", ['ngRoute', 'ngAnimate']);

myApp.config(["$routeProvider","$locationProvider",function ($routeProvider, $locationProvider) {
    $routeProvider.when("/Play", {
        templateUrl: "/Partial/Play",
        controller: "myController"
    }).when("/Score", {
        templateUrl: "/Partial/Scoreboard",
        controller: "ScoreCtrl"
    }).when("/AddQ", {
        templateUrl: "/Partial/AddQuestion",
        controller: "AddQCtrl"
    }).when("/About", {
        templateUrl: "/Partial/About",
        controller: "AboutCtrl"
    }).when("/Home", {
        templateUrl: "/Partial/Welcome",
        controller : "WelcomeCtrl"
    }).when("/", {
        templateUrl: "/Partial/Welcome",
        controller: "WelcomeCtrl"
    });

    //$locationProvider.html5Mode(true);
}]);
