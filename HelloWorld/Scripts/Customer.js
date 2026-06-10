function CustomerViewModel($scope, $http) {
    $scope.Customer = {
        "CustomerCode": "",
        "CustomerName": "",
        "CustomerAmount": "",
        "CustomerAmountColor": ""
    }
    $scope.Customers = [];

    $scope.$watch("Customers", function () {
        for (var i = 0; i < $scope.Customers.length; i++) {
            var cust = $scope.Customers[i];
            cust.CustomerAmountColor = $scope.getColor(cust.CustomerAmount);
        }

    });
    $scope.getColor = function (Amount) {
        if (Amount == 1000) {
            return "";
        }
        else if (Amount > 1000) {
            return "blue";
        }
        else {
            return "red";
        }
    }
    $scope.$watch("Customer.CustomerAmount", function () {
        $scope.Customer.CustomerAmountColor = $scope.getColor($scope.Customer.CustomerAmount);
    });

    $scope.Add = function () {
        $http({
            method: "POST",
            data: JSON.stringify($scope.Customer),
            url: "Submit",
            headers: { 'Content-Type': 'application/json' }
        }).then(function (response) {
            $scope.Customers = response.data;
            //Load data in table

            $scope.Customer = {
                "CustomerCode": "",
                "CustomerName": "",
                "CustomerAmount": "",
                "CustomerAmountColor": ""
            }
        });
    }
    $scope.Load = function () {
        $http({
            method: "GET",
            url: "GetCustomers"
        }).then(function (response) {
            $scope.Customers = response.data;
        });
    }
    $scope.LoadByName = function (custname) {
        var custSearch = $scope.Customer;
        $http({
            method: "GET",
            data: JSON.stringify(custSearch),
            url: "GetCustomersByName?CustomerName=" + $scope.Customer.CustomerName
        }).then(function (response) {
            $scope.Customers = response.data;
        });
    }
    $scope.Load();

}