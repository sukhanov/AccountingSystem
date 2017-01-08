moduleControllers
    .controller('TransactionsController', ['$scope', 'transactionsService', 'clientService', 'currencyService', TransactionsController]);
moduleServices
    .service('transactionsService', ['$http', TransactionsService])
    .service('currencyService', ['$http', CurrencyService])
    .service('clientService', ['$http', ClientService]);

function TransactionsController($scope, transactionsService, clientService, currencyService) {
    var defaultTr = {
        amount: 0,
        client: 0,
        currency: 0,
        type: undefined
    };

    var self = this;
    self.newTransaction = {};
    self.transactions = [];
    self.clients = [];
    self.currencies = [];
    self.types = [];
    self.updateTransactionsList = function () {
        transactionsService.getTransactions().then(function (dataResponse) {
            self.transactions = dataResponse.data;
        });
    };
    self.archiveTransactions = function () {
        transactionsService.moveToArchive().then(function (response) {
            if (response.data.success) {
                self.updateTransactionsList();
            }
            else
                alert(response.data.message);
        });
    };
    self.addTransaction = function () {
        transactionsService.create(self.newTransaction).then(function (response) {
            if (response.data.success) {
                self.updateTransactionsList();
                setDefaulTransaction();
            }
            else
                alert(response.data.message);
        });
    };

    self.updateTransactionsList();

    var currenciesLoad = false;
    var clientsLoad = false;
    var typesLoad = false;

    function getSelects() {
        clientService.getForSelect().then(function (dataResponse) {
            self.clients = dataResponse.data;
            if (self.clients.length > 0)
                defaultTr.client = self.clients[0].Value;
            clientsLoad = true;
            setDefaulTransaction();
        });
        currencyService.getForSelect().then(function (dataResponse) {
            self.currencies = dataResponse.data;
            if (self.currencies.length > 0)
                defaultTr.currency = self.currencies[0].Value;
            currenciesLoad = true;
            setDefaulTransaction();
        });
        transactionsService.getTypesForSelect().then(function (dataResponse) {
            self.types = dataResponse.data;
            if (self.types.length > 0)
                defaultTr.type = self.types[0].Value;
            typesLoad = true;
            setDefaulTransaction();
        });
    }

    function setDefaulTransaction() {
        if (currenciesLoad && clientsLoad && typesLoad)
            self.newTransaction = {
                amount: defaultTr.amount,
                client: defaultTr.client,
                currency: defaultTr.currency,
                type: defaultTr.type
            };
    }

    getSelects();
}

function TransactionsService($http) {
    return {
        getTransactions: function () {
            var req = {
                method: 'GET',
                url: '/api/transactions/getAll',
                headers: {
                    'Application': 'Accounting-System'
                }
            }
            return $http(req);
        },
        getTypesForSelect: function () {
            var req = {
                method: 'GET',
                url: '/api/transactions/getTypesForSelect',
                headers: {
                    'Application': 'Accounting-System'
                }
            }
            return $http(req);
        },
        moveToArchive: function () {
            var req = {
                method: 'GET',
                url: '/api/transactions/MoveToArchive',
                headers: {
                    'Application': 'Accounting-System'
                }
            }
            return $http(req);
        },
        create: function (form) {
            var data = {
                Amount: form.amount,
                Client: parseInt(form.client),
                Currency: parseInt(form.currency),
                Type: parseInt(form.type),
            }
            var req = {
                method: 'POST',
                url: '/api/transactions/add',
                headers: {
                    'Application': 'Accounting-System'
                },
                data: data
            }
            return $http(req);
        }
    }
}

function ClientService($http) {
    return {
        getForSelect: function () {
            var req = {
                method: 'GET',
                url: '/api/client/getForSelect',
                headers: {
                    'Application': 'Accounting-System'
                }
            }
            return $http(req);
        }
    }
}

function CurrencyService($http) {
    return {
        getForSelect: function () {
            var req = {
                method: 'GET',
                url: '/api/currency/getForSelect',
                headers: {
                    'Application': 'Accounting-System'
                }
            }
            return $http(req);
        }
    }
}