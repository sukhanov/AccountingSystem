 moduleControllers
    .controller('BalancesController', ['$scope', 'balancesService', 'clientService', BalancesController]);
moduleServices
    .service('balancesService', ['$http', BalancesService]);

BalancesController.resolve = {
    clients: function (clientService) {
        return clientService.getForSelect();
    }
}

function BalancesController($scope, balancesService, clientService, clients) {
    var self = this;
    self.client = 0;
    self.clients = clients;
    self.balances = [];
    self.changeClient = function () {
        balancesService.getBalances(self.client).then(function (dataResponse) {
            self.balances = dataResponse.data;
        });
    };

    function init() {
        if(self.clients == undefined)
            window.location = "error401.html";
        
        if (self.clients.length > 0) {
                self.client = self.clients[0].Value;
                self.changeClient();
            }
    }

    init();
}

function BalancesService($http) {
    return {
        getBalances: function (clientId) {
            var req = {
                method: 'GET',
                url: '/api/balance/getAmountForClient?clientId=' + clientId,
                headers: {
                    'X-Application': 'Accounting-System'
                }
            }
            return $http(req);
        }
    }
}