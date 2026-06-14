function CustomerViewModel($scope, $http) {
    $scope.Customer = {
        "CustomerCode": "",
        "CustomerName": "",
        "CustomerAmount": "",
        "CustomerAmountColor": ""
    }
    $scope.Errors = [];
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
            url: "/Api/Customer",
            headers: { 'Content-Type': 'application/json' }
        }).then(function (data) {
            if (data.isValid) {

                $scope.Customers = data.Data;
                //Load data in table

                $scope.Customer = {
                    "CustomerCode": "",
                    "CustomerName": "",
                    "CustomerAmount": "",
                    "CustomerAmountColor": ""
                }
            }
            else {
                $scope.Errors = data.Data.Errors;
            }
        });
    }
    $scope.Update = function () {
        $http({
            method: "PUT",``
            data: JSON.stringify($scope.Customer),
            url: "/Api/Customer",
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
    $scope.Delete = function () {

        
        $http({
            method: "DELETE",
            data: JSON.stringify($scope.Customer),
            url: "/Api/Customer",
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
            url: "/Api/Customer"
        }).then(function (response) {
            $scope.Customers = response.data;
        });
    }
    $scope.LoadByName = function () {
        var custSearch = $scope.Customer;
        $http({
            method: "GET",
            data: JSON.stringify(custSearch),
            url: "/Api/Customer?CustomerName=" + $scope.Customer.CustomerName
        }).then(function (response) {
            $scope.Customers = response.data;
        });
    }
    $scope.LoadByCode = function (CustomerCode) {
        $http({
            method: "GET",
            url: "/Api/Customer?CustomerCode=" + CustomerCode
        }).then(function (response) {
            if (response.data && response.data.length > 0) {
                $scope.Customer = response.data[0];
            }
        });
    };
    $scope.Load();

}