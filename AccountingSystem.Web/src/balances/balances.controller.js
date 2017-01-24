 moduleControllers
    .controller('BalancesController', ['$scope', 'balancesService', 'clientService', BalancesController]);
moduleServices
    .service('balancesService', ['$http', BalancesService]);

function BalancesController($scope, balancesService, clientService) {
    var self = this;
    self.client = 0;
    self.clients = [];
    self.balances = [];
    self.changeClient = function () {
        balancesService.getBalances(self.client).then(function (dataResponse) {
            self.balances = dataResponse.data;
        });
    };

    function getSelects() {
        clientService.getForSelect().then(function (dataResponse) {
            self.clients = dataResponse.data;
            if (self.clients.length > 0) {
                self.client = self.clients[0].Value;
                self.changeClient();
            }
        });
    }

    getSelects();
}

function BalancesService($http) {
    return {
        getBalances: function (clientId) {
            var req = {
                method: 'GET',
                url: '/api/balance/getForClient?clientId=' + clientId,
                headers: {
                    'X-Application': 'Accounting-System'
                }
            }
            return $http(req);
        }
    }
}