moduleControllers
    .controller('ValidationsController', ['$scope', ValidationsController]
);

function ValidationsController($scope) {
    var defaultCardType = "Unknown";
    var self = this;
    self.cardNumber = "";
    self.cardType = defaultCardType;
    self.phone = "";
    self.checkCard = function() {
        var find = false;
        const types = [
            {
                name: "Visa",
                regx: /^4[0-9]{12}([0-9]{0,3})$/
            },
            {
                name: "American Express",
                regx: /^3[4,7][0-9]{13}$/
            },
            {
                name: "Master Card",
                regx: /^5[1-5][0-9]{14}$/
            },
            {
                name: "Visa Electron",
                regx: /(^(4026|4405|4508|4844|4913|4917)[0-9]{12}$)|(^417500[0-9]{10}$)/
            }
        ];
        types.forEach(function(item) {
            if (item.regx.test(self.cardNumber)) {
                self.cardType = item.name;
                find = true;
            }
            return false;
        });
        if (!find)
            self.cardType = defaultCardType;
    };
    self.checkPhone = function() {
        self.phone = self.phone.replace(/[^\d]/g, "");
        if (self.phone.length === 10) {
            self.phone = self.phone.replace(/(\d{3})(\d{3})(\d{4})/, "($1) $2-$3");
        }
    };
    self.checkNumber = function () {
        var parts = self.number.split(".");
        var decimal = parts.length > 1 ? "." + parts[1] : "";
        self.number = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + decimal;
    };
}