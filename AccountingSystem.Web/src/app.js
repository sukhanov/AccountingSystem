var moduleControllers = angular.module('controllers', []);
var moduleServices = angular.module('services', []);
var accountingSystemApp = angular
    .module('accounting-system', 
        [
        'ui.router',
        'controllers',
        'services'
        ])
    .config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
        $locationProvider.html5Mode(true).hashPrefix('!');
        $urlRouterProvider.otherwise('/transactions');
        $stateProvider
            .state('transactions',
            {
                url: '/transactions',
                controller: TransactionsController,
                controllerAs: '$ctrl',
                templateUrl: 'src/transactions/transactions.html',
                onEnter: function ($window) { $window.document.title = "Transactions"; },
                resolve: TransactionsController.resolve
            })
             .state('balances',
            {
                url: '/balances',
                controller: BalancesController,
                controllerAs: '$ctrl',
                templateUrl: 'src/balances/balances.html',
                onEnter: function ($window) { $window.document.title = "Balances"; },
                resolve: BalancesController.resolve
            })
            .state('validations',
            {
                url: '/validations',
                controller: ValidationsController,
                controllerAs: '$ctrl',
                templateUrl: 'src/validations/validations.html',
                onEnter: function ($window) { $window.document.title = "Transfer"; }
            });
    });

accountingSystemApp.directive('numbersOnly', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, ngModelCtrl) {
            function fromUser(text) {
                if (text) {
                    var transformedInput = text.replace(/[^0-9]/g, '');

                    if (transformedInput !== text) {
                        ngModelCtrl.$setViewValue(transformedInput);
                        ngModelCtrl.$render();
                    }
                    return transformedInput;
                }
                return undefined;
            }
            ngModelCtrl.$parsers.push(fromUser);
        }
    };
});

accountingSystemApp.directive('decimalOnly', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, ngModelCtrl) {
            function fromUser(text) {
                if (text) {
                    var transformedInput = text.replace(/[^0-9.]/g, '');

                    if (transformedInput !== text) {
                        ngModelCtrl.$setViewValue(transformedInput);
                        ngModelCtrl.$render();
                    }
                    return transformedInput;
                }
                return undefined;
            }
            ngModelCtrl.$parsers.push(fromUser);
        }
    };
});