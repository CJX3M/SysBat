var ratesAdmin;
(function () {
    ratesAdmin = angular.module("ratesAdmin", ["ngRoute", 'ngMessages', 'ngAnimate']);

    ratesAdmin.config(function($routeProvider){
        $routeProvider

            .when('/', {
                templateUrl: "pages/main.html",
                controller: "loginController"
            })

            .when('/register', {
                templateUrl: "pages/register.html",
                controller: "loginRegisterController"
            })

            .when('/admin', {
                templateUrl: "pages/admin.html",
                controller: "adminController"
            })
    });
})();