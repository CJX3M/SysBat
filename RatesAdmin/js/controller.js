ratesAdmin.controller('loginRegisterController', function ($scope, loginService) {
    $scope.pageClass = "register";
    $scope.IsNewUser = true;

    CargarObjetos();

    $scope.Register = function (isValid) {
        if (isValid) {
            var Usuario = {
                Oid: $scope.Oid,
                Username: $scope.Username,
                Password: $scope.Password,
                Email: $scope.Email,
                Type: $scope.Type
            };
            var promisePost = loginService.post(Usuario);
            promisePost.then(function (pl) {
                $scope.Oid = pl.data.Oid;
                //loadRecords();
                // Redirect to profile edit page
            }, function (err) {
                console.log("Err" + err);
            });
        }        
    };

    //Clear the Scopr models
    $scope.clear = function () {
        $scope.IsNewUser = true;
        $scope.Oid = 0;
        $scope.Username = "";
        $scope.Password = "";
        $scope.Email = "";
        $scope.Type = 0;
    }

    function CargarObjetos() {
        var promiseGet = loginService.obtenerObjetos(); //The MEthod Call from service

        promiseGet.then(function (pl) {
            $scope.Objetos = pl.data.$values
        }, function (errorPl) {
            console.error('failure loading Objetos', errorPl);
        });
    }
});

ratesAdmin.controller("loginController", function ($scope, loginService) {
    $scope.pageClass = "login";
    //Method to Get Single Employee based on EmpNo
    $scope.login = function () {
        var usuario = {
            Oid: 0,
            Username: $scope.user,
            Password: $scope.password,
            Email: "",
            Type: 0
        };
        var promiseGetSingle = crudService.get(usuario);
 
        promiseGetSingle.then(function (pl) {
            var res = pl.data;
            $scope.Oid = res.Oid;
            $scope.Username = res.Username;
            $scope.Email = res.Email;
            $scope.Type = res.Type; 
            // Redirect to user's profile
        },
        function (errorPl) {
            console.log('failure loading Employee', errorPl);
        });
    }

        //Clear the Scopr models
    $scope.clear = function () {
        $scope.IsNewUser = true;
        $scope.Oid = 0;
        $scope.Username = "";
        $scope.Password = "";
        $scope.Email = "";
        $scope.Type = 0;
    }
});

ratesAdmin.controller("adminController", function ($scope, adminService) {
    $scope.pageClass = "admin";
    $scope.updateUser = function () {
        var Usuario = {
            Oid: $scope.Oid,
            Username: $scope.Username,
            Password: $scope.Password,
            Email: $scope.Email,
            Type: $scope.Type
        };
        var promisePut = adminService.updateUser($scope.Oid, Usuario);
        promisePut.then(function (pl) {
            //$scope.Message = "Updated Successfuly";
            //loadRecords();
            // Update profile
        }, function (err) {
            console.log("Err" + err);
        });
    };

    //Method to Delete
    $scope.deleteUser = function () {
        var promiseDelete = loginService.deleteUser($scope.Oid);
        promiseDelete.then(function (pl) {
            //$scope.Message = "Deleted Successfuly";
            //loadRecords();
            // Confirm message page redirect. Destroy session cookie
        }, function (err) {
            console.log("Err" + err);
        });
    }

    //Method to Get Single Employee based on EmpNo
    $scope.get = function (username, password) {
        var usuario = {
            Oid: 0,
            Username: username,
            Password: password,
            Email: "",
            Type: 0
        };
        var promiseGetSingle = crudService.get(usuario);
 
        promiseGetSingle.then(function (pl) {
            var res = pl.data;
            $scope.Oid = res.Oid;
            $scope.Username = res.Username;
            $scope.Email = res.Email;
            $scope.Type = res.Type; 
            // Redirect to user's profile
        },
        function (errorPl) {
            console.log('failure loading Employee', errorPl);
        });
    }

        //Clear the Scopr models
    $scope.clear = function () {
        $scope.IsNewUser = true;
        $scope.Oid = 0;
        $scope.Username = "";
        $scope.Password = "";
        $scope.Email = "";
        $scope.Type = 0;
    }
});