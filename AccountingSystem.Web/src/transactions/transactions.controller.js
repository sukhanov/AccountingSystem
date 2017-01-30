moduleControllers
    .controller('TransactionsController', ['$scope', 'transactionsService', 'clientService', 'currencyService', TransactionsController]);
moduleServices
    .service('transactionsService', ['$http', TransactionsService])
    .service('currencyService', ['$http', CurrencyService])
    .service('balanceService', ['$http', BalanceService])
    .service('clientService', ['$http', ClientService]);

TransactionsController.resolve = {
    clients: function (clientService) {
        return clientService.getForSelect();
    },
    currencies: function (currencyService) {
        return currencyService.getForSelect();
    },
    types: function (transactionsService) {
        return transactionsService.getTypesForSelect();
    }
}

function TransactionsController($scope, transactionsService, currencyService, balanceService, clientService, clients, currencies, types) {
    if (clients == undefined || currencies == undefined || types == undefined) {
        window.location = "error401.html";
    }

    var defaultTr = {
        amount: 0,
        client: 0,
        currency: 0,
        balance: 0,
        type: undefined
    };

    var self = this;
    self.newTransaction = {};
    self.transactions = [];
    self.clients = clients;
    self.currencies = currencies;
    self.balances = [];
    self.types = types;
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
        if (self.newTransaction.amount <= 0) {
            alert("Amount must be > 0");
            return;
        }
        transactionsService.create(self.newTransaction).then(function (response) {
                self.updateTransactionsList();
                setDefaulTransaction();
        }, function(response) {
            alert(response.data.Message);
        });
    };
    self.changeClient = function () {
        balanceService.getByClient(self.newTransaction.client).then(function (data) {
            self.balances = data;
            if (self.balances.length > 0)
                self.newTransaction.balance = self.balances[0].Value;

        });
    };
    self.updateTransactionsList();

    if (self.clients.length > 0) {
        defaultTr.client = self.clients[0].Value;

        balanceService.getByClient(defaultTr.client).then(function (data) {
            self.balances = data;
            if (self.balances.length > 0)
                defaultTr.balance = self.balances[0].Value;

            setDefaulTransaction(); 
        });
    }
    if (self.currencies.length > 0)
        defaultTr.currency = self.currencies[0].Value;
    if (self.types.length > 0)
        defaultTr.type = self.types[0].Value;

    setDefaulTransaction();

    function setDefaulTransaction() {
        self.newTransaction = {
            amount: defaultTr.amount,
            client: defaultTr.client,
            currency: defaultTr.currency,
            type: defaultTr.type,
            balance: defaultTr.balance
        };
    }
}

function TransactionsService($http) {
    return {
        getTransactions: function () {
            var req = {
                method: 'GET',
                url: '/api/transactions/getAll',
                headers: {
                    'X-Application': 'Accounting-System'
                }
            }
            return $http(req);
        },
        getTypesForSelect: function () {
            var req = {
                method: 'GET',
                url: '/api/transactions/getTypesForSelect',
                headers: {
                    'X-Application': 'Accounting-System'
                }
            }
            return $http(req).then(function (response) {
                return response.data;
            }
             , function (response) {
                 return undefined;
             });
        },
        moveToArchive: function () {
            var req = {
                method: 'GET',
                url: '/api/transactions/MoveToArchive',
                headers: {
                    'X-Application': 'Accounting-System'
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
                Balance: parseInt(form.balance)
            }
            var req = {
                method: 'POST',
                url: '/api/transactions/add',
                headers: {
                    'X-Application': 'Accounting-System'
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
                    'X-Application': 'Accounting-System'
                }
            }
            return $http(req).then(function (response) {
                return response.data;
            }
            , function (response) {
                return undefined;
            });
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
                    'X-Application': 'Accounting-System'
                }
            }
            return $http(req).then(function (response) {
                return response.data;
            }
            , function (response) {
                return undefined;
            });
        }
    }
}

function BalanceService($http) {
    return {
        getByClient: function (clientId) {
            var req = {
                method: 'GET',
                url: '/api/balance/GetForClient?clientId=' + clientId,
                headers: {
                    'X-Application': 'Accounting-System'
                }
            }
            return $http(req).then(function (response) {
                return response.data;
            }
            , function (response) {
                return undefined;
            });
        }
    }
}