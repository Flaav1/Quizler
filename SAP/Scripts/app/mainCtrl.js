
var correct = false;
var length = 2;
var score = 0;
var interval;




myApp.controller("myController", ["$scope", "$http", function ($scope, http) {
    $scope.over = false;
    $scope.text = "Your Score : " + (score);
    $scope.inbetween = "Press start, to start..."
   
    var time = false;

    function timer(time, update, complete) {
        var start = new Date().getTime();
        interval = setInterval(function () {
            var now = time - (new Date().getTime() - start);
            if (now <= 0) {
                clearInterval(interval);
                complete();
            }
            else update(Math.floor(now / 1000));
        }, 100); 
    }

    
    $scope.Start = function () {
 
        time = true;
        $scope.over = false;
        clearInterval(interval);
        $scope.initialized = true;
        pos = 0;
        score = 0;
        count = 30;
        $scope.answered = false;
        $scope.fade = 'hide';
        $scope.Next();
        $scope.inprogress = true;
       
        //timer 
        timer( 25000,function (timeleft) { 
                    document.getElementById('clock').innerHTML = timeleft + " seconds";
                    time = true;
                },function () {
                    document.getElementById('clock').innerHTML = "Last question";
                    time = false;
                });
        //end timer 

    };


    $scope.Next = function () {
        $scope.answered = false;
        getQuestion();
        
        if (time === true) {
            $scope.inprogress = true;
           
        }
        else {
            $scope.inprogress = false;
            $scope.initialized = false;
            $scope.over = true;
            $scope.inbetween = "Game over! your score is : " + score;
        }

        
    };

    $scope.CheckAnswer = function (ans) {

        if (ans === $scope.question.Answer) {
            $scope.inbetween = 'Correct!';
            $scope.correct = true;
            score++;
        }
        else {
            $scope.inbetween = 'Wrong!';
            $scope.correct = false;
        }

        $scope.answered = true;
        $scope.inprogress = false;
    };
    var getQuestion = function () {

        var req = {
            method: 'GET',
            url: '/api/values',
            headers: {
                'Accept': 'application/json'
            }
        };

        console.log("dw started");
        $scope.loading = true;
        return http(req).then(function successCallback(response) {
            $scope.question = response.data;
            length = $scope.question.length;

            $scope.loading = false;
        }, function errorCallback(response) {
            $scope.question = response;
            $scope.loading = false;
        });


    };

    $scope.submit = function () {
        var userdata = {
            name: $scope.txt,
            score : score
        }

        userdata = JSON.stringify(userdata);

        
       
        http({
            method: 'POST',
            url: '/api/user',
            data: userdata,
            timeout: 4000,
            headers: { 'Content-Type': 'application/json' }
        }).then(function (response) {

            $scope.respons = "User Updated Sccessfully!";
           
        }, function (error) {

            $scope.respons = "Something went wrong man...";
        });



    };

   

}]);

