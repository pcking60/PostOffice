/// <reference path="~/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('postoffice.properties', ['postoffice.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('properties', {
                url: "/properties",
                templateUrl: "/app/components/properties/propertyListView.html",
                parent: 'base',
                controller: "propertyListController"
            }).state('property_add', {
                url: "/property_add",
                templateUrl: "/app/components/properties/propertyAddView.html",
                parent: 'base',
                controller: "propertyAddController"
            }).state('property_edit', {
                url: "/property_edit/:id",
                templateUrl: "/app/components/properties/propertyEditView.html",
                parent: 'base',
                controller: "propertyEditController"
            });
    }
})();