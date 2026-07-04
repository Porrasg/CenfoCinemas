// Clase que controla la vista Users.cshtml

// Definir una clase JS utilizando prototype

function UserViewController() {
    this.ViewName = "Users";

    //API que vamos a consumir desde esta vista
    this.API_ControllerName = "Users";

    //metodo constructor
    this.InitView = function () {
        //Invocar la carga de la tabla
        this.LoadTable();

        // Asignar evento al boton de crear
        $('#btnCreate').on('click', function () {
            var vc = new UserViewController();
            vc.Create();
        })

        // Asignar evento al boton de update
        $('#btnUpdate').on('click', function () {
            var vc = new UserViewController();
            vc.Update();
        })

        // Asignar evento al boton de eliminar
        $('#btnDelete').on('click', function () {
            var vc = new UserViewController();
            vc.Delete();
        })
    }

    // metodo de carga de la tabla
    this.LoadTable = function () {

        var ca = new ControlActions();

        // https://localhost:7031/api/Users/RetrieveAll
        //Endpoint que vamos a consumir
        var endPoint = this.API_ControllerName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(endPoint);

        // Match de las columnas
        var columns = [];
        columns[0] = { 'data': 'id', title: 'Id' }
        columns[1] = { 'data': 'userCode', title: 'Codigo' }
        columns[2] = { 'data': 'name', title: 'Nombre' }
        columns[3] = { 'data': 'email', title: 'Correo' }
        columns[4] = { 'data': 'birthDate', title: 'Fecha de Nacimiento' }
        columns[5] = { 'data': 'status', title: 'Estado' }
        columns[6] = { 'data': 'phoneNumber', title: 'Teléfono' }
        columns[7] = { 'data': 'created', title: 'Fecha de Creación' }

        // convertir la tabla plana en una tabla mas dinamica
        $("#tblUsers").dataTable({
            "ajax": {
                url: urlService,
                "dataSrc": ""
            },
            "columns": columns
        });

        // ASIGNAR EVENTO DE MAPEO DEL DTO SELECCIONADO CON EL FORM
        $('#tblUsers tbody').on('click', 'tr', function () {
            var row = $(this).closest('tr');

            // vamos a extraer el dto 
            var userDTO = $('#tblUsers').DataTable().row(row).data();

            //cargamos el DTO en el form
            $('#txtId').val(userDTO.id);
            $('#txtUserCode').val(userDTO.userCode);
            $('#txtName').val(userDTO.name);
            $('#txtEmail').val(userDTO.email);
            $('#txtStatus').val(userDTO.status);
            $('#txtPhoneNumber').val(userDTO.phoneNumber);
            $('#txtPassword').val(userDTO.password);

            //formato
            var onlyDate = userDTO.birthDate.split("T");
            $('#txtBirthDate').val(onlyDate[0]);
        })
    }

    // Limpiar el formulario
    this.ClearForm = function () {
        $('#txtId').val('');
        $('#txtUserCode').val('');
        $('#txtName').val('');
        $('#txtEmail').val('');
        $('#txtBirthDate').val('');
        $('#txtStatus').val('');
        $('#txtPhoneNumber').val('');
        $('#txtPassword').val('');
    }


    this.Create = function () {
        var userDTO = {};

        //Set con valores default 
        userDTO.id = 0;
        userDTO.created = "2026-01-01";
        userDTO.updated = "2026-01-01";

        // Set de valores capturados en el form/pantalla
        userDTO.userCode = $('#txtUserCode').val();
        userDTO.name = $('#txtName').val();
        userDTO.email = $('#txtEmail').val();
        userDTO.birthDate = $('#txtBirthDate').val();
        userDTO.status = $('#txtStatus').val();
        userDTO.phoneNumber = $('#txtPhoneNumber').val();
        userDTO.password = $('#txtPassword').val();

        // Enviar data al API
        var ca = new ControlActions();
        var urlEndpoint = this.API_ControllerName + "/Create";

        ca.PostToAPI(urlEndpoint, userDTO, function (response) {
            //Recargar la tabla
            $('#tblUsers').DataTable().ajax.reload();

            // Limpiar el formulario
            vc.ClearForm();
        })
    }


    this.Update = function () {
        var userDTO = {};

        //Set con valores default 
        userDTO.created = "2026-01-01";
        userDTO.updated = "2026-01-01";

        // Set de valores capturados en el form/pantalla
        userDTO.id = $('#txtId').val();
        userDTO.userCode = $('#txtUserCode').val();
        userDTO.name = $('#txtName').val();
        userDTO.email = $('#txtEmail').val();
        userDTO.birthDate = $('#txtBirthDate').val();
        userDTO.status = $('#txtStatus').val();
        userDTO.phoneNumber = $('#txtPhoneNumber').val();
        userDTO.password = $('#txtPassword').val();

        // Enviar data al API
        var ca = new ControlActions();
        var urlEndpoint = this.API_ControllerName + "/Update";

        ca.PutToAPI(urlEndpoint, userDTO, function (response) {
            //Recargar la tabla
            $('#tblUsers').DataTable().ajax.reload();

            // Limpiar el formulario
            vc.ClearForm();
        })
    }


    this.Delete = function () {
        var userDTO = {};

        //Set con valores default 
        userDTO.created = "2026-01-01";
        userDTO.updated = "2026-01-01";

        // Set de valores capturados en el form/pantalla
        userDTO.id = $('#txtId').val();
        userDTO.userCode = $('#txtUserCode').val();
        userDTO.name = $('#txtName').val();
        userDTO.email = $('#txtEmail').val();
        userDTO.birthDate = $('#txtBirthDate').val();
        userDTO.status = $('#txtStatus').val();
        userDTO.phoneNumber = $('#txtPhoneNumber').val();
        userDTO.password = $('#txtPassword').val();

        // Enviar data al API
        var ca = new ControlActions();
        var urlEndpoint = this.API_ControllerName + "/Delete";

        ca.DeleteToAPI(urlEndpoint, userDTO, function (response) {
            //Recargar la tabla
            $('#tblUsers').DataTable().ajax.reload();

            // Limpiar el formulario
            vc.ClearForm();
        })
    }

}

// Instancia de la clase
$(document).ready(function () {
    var vc = new UserViewController();
    vc.InitView();
});