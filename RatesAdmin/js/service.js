ratesAdmin.service("loginService", function ($http) {
//Create new record
    this.post = function (user) {
        var request = $http({
            method: "post",
            url: "/api/Usuarios",
            data:  user
        });
        return request;
    }
    //Get Single Records
    this.get = function (Oid) {
       return $http.get("/api/Usuarios/" + Oid);
    }
     //Get By user and password
    this.get = function (user) {
        var request = $http({
            method: "get",
            url: "/api/Usuarios/",
            data: user
        });
       return request;
    }
    //Get All Employees
    this.getEmployees = function () {
        return $http.get("/api/Usuarios"); 
    }
 
    //Update the Record
    this.put = function (Oid, user) {
        var request = $http({
            method: "put",
            url: "/api/Usuarios/" + Oid,
            data: user
        });
        return request;
    }
    //Delete the Record
    this.delete = function (Oid) {
        var request = $http({
            method: "delete",
            url: "/api/Usuarios/" + Oid
        });
        return request;
    }
    // Obtener los objetos
    this.obtenerObjetos = function() {
        return $http.get("/api/Objetos");
    }
});

ratesAdmin.service("adminService", function ($http) {
//Create new record
    this.post = function (user) {
        var request = $http({
            method: "post",
            url: "/api/Usuarios",
            data:  user
        });
        return request;
    }
    //Get Single Records
    this.get = function (Oid) {
       return $http.get("/api/Usuarios/" + Oid);
    }
     //Get By user and password
    this.get = function (user) {
        var request = $http({
            method: "get",
            url: "/api/Usuarios/",
            data: user
        });
       return request;
    } 
 
    //Update the User
    this.updateUser = function (Oid, user) {
        var request = $http({
            method: "put",
            url: "/api/Usuarios/" + Oid,
            data: user
        });
        return request;
    }
    //Delete the User
    this.deleteUser  = function (Oid) {
        var request = $http({
            method: "delete",
            url: "/api/Usuarios/" + Oid
        });
        return request;
    }
});