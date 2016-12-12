myApp.controller("ScoreCtrl", ["$scope", "$http", function (model, rest) {
   
    model.loading = true;
    console.log(1);
    rest({
        method: 'GET',
        url: '/api/user',
    })
        .then(function (response) {
            
            model.respons = response.data;
            model.loading = false;
            console.log(0);
    }, function (error) {
        model.respons = "Something went wrong man...";
        model.loading = false;
    });
}]);