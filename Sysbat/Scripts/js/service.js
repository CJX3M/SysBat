app.service('crudService', function ($http) {
     
    //Create new record
    this.post = function (ObjProp) {
        var request = $http({
            method: "post",
            url: "/api/ObjPropApi/AgregarPropiedadObjeto",
            data:  ObjProp
        });
        return request;
    }
    
    //Delete the Record
    this.remove = function (ObjProp) {
        var request = $http({
            method: "post",
            url: "/api/ObjPropApi/BorrarPropiedadObjeto",
            data:  ObjProp
        });
        return request;
    }

    //Get All Employees
    this.getObjetos = function () {
        return $http.get("/api/ObjPropApi/GetObjetos"); 
    }

    //Get All Employees
    this.getObjetoProps = function (oid) {
        return $http.get("/api/ObjPropApi/GetPropiedadesObjeto/" + oid); 
    } 

    //Get All Employees
    this.getPropsLibres = function (oid) {
        return $http.get("/api/ObjPropApi/GetPropiedadesLibres/" + oid); 
    }
});