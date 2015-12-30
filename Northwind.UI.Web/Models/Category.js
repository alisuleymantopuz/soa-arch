var categoriesListZone = angular.module("categories", []);

categoriesListZone.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.defaults.useXDomain = true;
    delete $httpProvider.defaults.headers.common['X-Requested-With'];
}
]);

categoriesListZone.controller("categoriesListController", function ($scope, $http) {

    $http.get("http://localhost:6622/api/categories")
        .success(function (data, status, headers, config) {

            $scope.categories = data;

        })
        .error(function (data, status, headers, config) {

            alert("list error!");
        });


});

categoriesListZone.controller("categoriesDeleteController", function ($scope, $http) {



    $http.get("http://localhost:6622/api/categories")
       .success(function (data, status, headers, config) {

           $scope.categories = data;

       })
       .error(function (data, status, headers, config) {

           alert("list error!");
       });


    $scope.delete = function () {

        var category = $scope.selectedCategory;

        if (category.categoryId > 0) {

            $http.delete("http://localhost:6622/api/categories/" + category.categoryId)
                      .success(function (data, status, headers, config) {
                          alert("success.");
                      })
                     .error(function (data, status, headers, config) {
                         alert("delete error!");
                     });
        }
    };
});

categoriesListZone.controller("categoriesAddController", function ($scope, $http) {

    $scope.submit = function () {

        if ($scope.Name) {
            var categoryInfo = {
                "CategoryId": 0,
                "Name": $scope.Name,
                "Description": $scope.Description
            };

            $http.post("http://localhost:6622/api/categories", categoryInfo)
                .success(function (data, status, headers, config) {
                    alert("success.");
                })
                .error(function (data, status, headers, config) {
                    alert("add error!");
                });

        }
    };

});
