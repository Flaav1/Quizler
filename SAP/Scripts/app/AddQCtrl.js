


myApp.controller("AddQCtrl", ["$scope", "$http", function (model, rest) {

    model.question = "";
    model.answer1 = "";
    model.answer2 = "";
    model.answer3 = "";
    model.answer4 = "";
    var data = [];


    model.entities = [{
        name: 1,
        checked: false
    }, {
        name: 2,
        checked: false
    }, {
        name: 3,
        checked: true
    }, {
        name: 4,
        checked: false
    }]

    model.updateSelection = function (position, entities) {
        angular.forEach(entities, function (subscription, index) {
            if (position != index)
                subscription.checked = false;
        });
    }

    var getit = function () {

        for (var item in model.entities) {
            
            if (model.entities[item].checked) {
               
                return (++item);
            }
        }
    };
   

    model.Submit = function () {
        console.log("click");
       
        model.ans = getit();
         
        userdata = {
            question:model.question,
            answer1:model.answer1,
            answer2:model.answer2,
            answer3:model.answer3,
            answer4:model.answer4,
            correct:model.ans
        };

        //userdata = JSON.stringify(userdata);

        rest({
            method: 'POST',
            url: '/api/values',
            data: userdata,
            timeout: 5000,
            headers: { 'Content-Type': 'application/json' }
        }).then(function (response) {

            model.fdbck = true;
           model.respons = "Your Question Has Been Added Sccessfully!";

        }, function (error) {
            model.fdbck = false;
            model.respons = error.data.Message;
        });
       
    };



}]);