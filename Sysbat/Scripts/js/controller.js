app.controller('ctrlObjProps', function ($scope, crudService) {
    
    $scope.IsNewRecord = 1; //The flag for the new record
    $scope.ObjetoOid = -1;

    CargarObjetos(); 
    
    //Function to load all Employee records
    function CargarObjetos() {
        var promiseGet = crudService.getObjetos(); //The MEthod Call from service
 
        promiseGet.then(function (pl) { 
            $scope.Objetos = pl.data.$values
        }, function (errorPl) {
            console.error('failure loading Objetos', errorPl);
        });
    }

    $scope.CargarPropiedades = function() {
        CargarPropiedadesObjeto();
        CargarPropiedadesLibres();    
    }

    function CargarPropiedadesObjeto() {
        var promiseGet = crudService.getObjetoProps($scope.Objeto.Oid); //The MEthod Call from service
 
        promiseGet.then(function (pl) { 
            $scope.PropsObjeto = pl.data.$values
        }, function (errorPl) {
           console.error('failure loading Objetos', errorPl);
        });
    }

    function CargarPropiedadesLibres() {
        var promiseGet = crudService.getPropsLibres($scope.Objeto.Oid); //The MEthod Call from service
 
        promiseGet.then(function (pl) { 
            $scope.PropLibres = pl.data.$values
        }, function (errorPl) {
            console.error('failure loading Objetos', errorPl);
        });
    }
     
    //The Save scope method use to define the Employee object.
    //In this method if IsNewRecord is not zero then Update Employee else 
    //Create the Employee information to the server
    $scope.save = function () {
        SalvarPropiedades(0);
    };
 
    //Method to Delete
    $scope.delete = function () {
        BorrarPropiedades(0);
    }
 
    //Method to Get Single Employee based on EmpNo
    $scope.get = function (objProp) {
        var promiseGetSingle = crudService.get(objPropOid);
 
        promiseGetSingle.then(function (pl) {
            var res = pl.data;
            $scope.Oid = -1;
            $scope.Objeto = -1;
            $scope.Propiedad = -1;
 
            $scope.IsNewRecord = 0;
        },
        function (errorPl) {
            console.error('failure loading Employee', errorPl);
        });
    }
    //Clear the Scopr models
    $scope.clear = function () {
        $scope.IsNewRecord = 1;
        $scope.Oid = -1;
        $scope.Objeto = -1;
        $scope.Propiedad = -1;
    }

    function SalvarPropiedades(indice) {
        if(!mensajeEspera.activo())
            mensajeEspera.mostrar("Asignando..");
        var ObjProp = {
            objetoOid: $scope.Objeto.Oid,
            propiedadOid: $scope.PropLibre[indice].Oid
        };
        var promisePost = crudService.post(JSON.stringify(ObjProp));
        promisePost.then(function (pl) {
            $scope.Oid = pl.data.Oid;
            //loadRecords();
            if(indice == $scope.PropLibre.length - 1) {
                mensajeEspera.ocultar();
                $scope.CargarPropiedades();
            } else {
                SalvarPropiedades(++indice);
            }
        }, function (err) {
            console.error("Err" + err);
        });
    }

    function BorrarPropiedades(indice){
        if(!mensajeEspera.activo())
            mensajeEspera.mostrar("DesAsignando..");
        var ObjProp = {
            objetoOid: $scope.Objeto.Oid,
            propiedadOid: $scope.PropAsig[indice].Oid
        };
        var promisePost = crudService.remove(JSON.stringify(ObjProp));
        promisePost.then(function (pl) {
            $scope.Oid = pl.data.Oid;
            if(indice == $scope.PropAsig.length - 1) {
                mensajeEspera.ocultar();
                $scope.CargarPropiedades();
            } else {
                BorrarPropiedades(++indice);
            }
        }, function (err) {
            console.error("Err" + err);
        });
    }
});