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
    }
}

// Instancia de la clase
$(document).ready(function () {
    var vc = new UserViewController();
    vc.InitView();
});