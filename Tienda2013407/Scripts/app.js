var ViewIndex = function () {
    var self = this;
    //creacion de objetos observables
    self.listaUsuarios = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();
    self.listaProductos = ko.observableArray();
    self.listaCompras = ko.observableArray();
    self.editar = ko.observable();
    //definir las rutas del api
    var usuariosUri = '/api/Usuarios/';
    var productosUri = '/api/Productoes/';
    var comprasUri = '/api/Compras/';

    //Definicion de una Funcion que ejecuta las acciones (la ruta del api, metodo http a utilizar, datos a enviar)
    function ajaxHelper(uri, method, data) {
        self.error(''); //Clear error mensaje
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? alert(JSON.stringify(data)) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    //DETALLES DE LOS Productos(PRODUCTO A VER)
    self.getProductoDetail = function (item) {
        ajaxHelper(productosUri + item.ID, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    self.getProductoEditar = function (item) {
        ajaxHelper(productosUri + item.ID, 'PUT').done(function (data) {
            self.edit(data);
        });
    }

    //---->LISTA PRODUCTOS

    //OBTIENE TODOS LOS PRODUCTOS
    function getAllProductos() {
        ajaxHelper(productosUri, 'GET').done(function (data) {
            self.listaProductos(data);
        });
    }
    // CARGA TODOS LOS PRODUCTOS A MEMORIA
    getAllProductos();

    //-->END LISTA Productos



    //--> AGREGAR Productos

    
    //DEFINO UNA PLANTILLA PARA PODER CARGAR DATOS DE MI FORMULARIO
    self.newProducto = {
        nombre: ko.observable(),
        precio: ko.observable(),
        existencia: ko.observable(),
        imagen: ko.observable(),
        descripcion: ko.observable(),
        categoria: ko.observable()

    }

    //SE CARGAN LOS DATOS EN LA VARIABLE producto Y SE AGREGAN A LA BD
    self.addProducto = function (formElement) {
        var producto = {
            nombre: self.newProducto.nombre(),
            precio: self.newProducto.precio(),
            existencia: self.newProducto.existencia(),
            imagen: self.newProducto.imagen(),
            descripcion: self.newProducto.descripcion(),
            categoria: self.newProducto.categoria()
        };
        //AGREGA A LA BD LOS DATOS
        //ajaxHelper(productosUri, 'POST', producto).done(function (item) {
        //    //SE ACTUALIZA LA LISTA DE LOS Productos
        //    self.listaProductos.push(item);


        //});

        $.ajax({
            type: 'POST',
            url: productosUri + 'PostProducto',
            data: producto,
            success: function (item) {
                self.listaProductos.push(item);

                self.newProducto.nombre('');
                self.newProducto.precio(0);
                self.newProducto.existencia(0);
                self.newProducto.imagen('');
                self.newProducto.descripcion('');
                self.newProducto.categoria('');
            }
        });

    }



};

//REALIZA EL BINDING DE LA VISTA CON JS
ko.applyBindings(new ViewIndex());