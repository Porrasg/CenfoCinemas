// Clase que controla la vista Users.cshtml

// Definir una clase JS utilizando prototype

function TicketViewController() {
    this.ViewName = "Tickets";

    //API que vamos a consumir desde esta vista
    this.API_ControllerName = "Tickets";

    //metodo constructor
    this.InitView = function () {
        //Invocar la carga de la tabla
        this.LoadTable();

        // Asignar evento al boton de crear
        $('#btnCreate').on('click', function () {
            var vc = new TicketViewController();
            vc.Create();
        })

        // Asignar evento al boton de update
        $('#btnUpdate').on('click', function () {
            var vc = new TicketViewController();
            vc.Update();
        })

        // Asignar evento al boton de eliminar
        $('#btnDelete').on('click', function () {
            var vc = new TicketViewController();
            vc.Delete();
        })

    }

    // metodo de carga de la tabla
    this.LoadTable = function () {

        var ca = new ControlActions();

        // https://localhost:7031/api/Tickets/RetrieveAll
        //Endpoint que vamos a consumir
        var endPoint = this.API_ControllerName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(endPoint);

        // Match de las columnas
        var columns = [];
        columns[0] = { 'data': 'id', title: 'Id' }
        columns[1] = { 'data': 'price', title: 'Precio' }
        columns[2] = { 'data': 'schedule', title: 'Horario' }
        columns[3] = { 'data': 'date', title: 'Fecha' }
        columns[4] = { 'data': 'type', title: 'Tipo' }
        columns[5] = { 'data': 'movieId', title: 'Pelicula Id' }
        columns[6] = { 'data': 'status', title: 'Estado' }
        columns[7] = { 'data': 'created', title: 'Fecha de Creación' }

        // convertir la tabla plana en una tabla mas dinamica
        $("#tblTickets").dataTable({
            "ajax": {
                url: urlService,
                "dataSrc": ""
            },
            "columns": columns
        });

        // ASIGNAR EVENTO DE MAPEO DEL DTO SELECCIONADO CON EL FORM
        $('#tblTickets tbody').on('click', 'tr', function () {
            var row = $(this).closest('tr');

            // vamos a extraer el dto
            var ticketDTO = $('#tblTickets').DataTable().row(row).data();

            //cargamos el DTO en el form
            $('#txtId').val(ticketDTO.id);
            $('#txtPrice').val(ticketDTO.price);
            $('#txtSchedule').val(ticketDTO.schedule);
            $('#txtType').val(ticketDTO.type);
            $('#txtMovieId').val(ticketDTO.movieId);
            $('#txtStatus').val(ticketDTO.status);

            //formato
            var onlyDate = ticketDTO.date.split("T");
            $('#txtDate').val(onlyDate[0]);
        })
    }

    // Limpiar el formulario
    this.ClearForm = function () {
        $('#txtId').val('');
        $('#txtPrice').val('');
        $('#txtSchedule').val('');
        $('#txtDate').val('');
        $('#txtType').val('');
        $('#txtMovieId').val('');
        $('#txtStatus').val('');
    }

    this.ValidateForm = function () {

        if (
            $('#txtPrice').val().trim() === "" ||
            $('#txtSchedule').val().trim() === "" ||
            $('#txtDate').val().trim() === "" ||
            $('#txtType').val().trim() === "" ||
            $('#txtMovieId').val().trim() === "" ||
            $('#txtStatus').val().trim() === ""
        ) {

            Swal.fire({
                icon: 'warning',
                title: 'Campos obligatorios',
                text: 'Todos los campos son obligatorios.'
            });

            return false;
        }

        if (parseFloat($('#txtPrice').val()) <= 0) {

            Swal.fire({
                icon: 'warning',
                title: 'Precio inválido',
                text: 'El precio debe ser mayor que cero.'
            });

            return false;
        }

        return true;
    }


    this.Create = function () {

        if (!this.ValidateForm()) {
            return;
        }

        var ticketDTO = {};

        //Set con valores default
        ticketDTO.id = 0;
        ticketDTO.created = "2026-01-01";
        ticketDTO.updated = "2026-01-01";

        // Set de valores capturados en el form/pantalla
        ticketDTO.price = $('#txtPrice').val();
        ticketDTO.schedule = $('#txtSchedule').val();
        ticketDTO.date = $('#txtDate').val();
        ticketDTO.type = $('#txtType').val();
        ticketDTO.movieId = $('#txtMovieId').val();
        ticketDTO.status = $('#txtStatus').val();

        // Enviar data al API
        var ca = new ControlActions();
        var urlEndpoint = this.API_ControllerName + "/Create";

        var vc = this;

        ca.PostToAPI(urlEndpoint, ticketDTO, function (response) {

            Swal.fire({
                icon: 'success',
                title: '¡Tiquete creado!',
                text: 'El tiquete se registró correctamente.'
            });

            //Recargar la tabla
            $('#tblTickets').DataTable().ajax.reload();

            // Limpiar el formulario
            vc.ClearForm();
        })
    }

    this.Update = function () {

        if (!this.ValidateForm()) {
            return;
        }

        var ticketDTO = {};

        //Set con valores default
        ticketDTO.created = "2026-01-01";
        ticketDTO.updated = "2026-01-01";

        // Set de valores capturados en el form/pantalla
        ticketDTO.id = $('#txtId').val();
        ticketDTO.price = $('#txtPrice').val();
        ticketDTO.schedule = $('#txtSchedule').val();
        ticketDTO.date = $('#txtDate').val();
        ticketDTO.type = $('#txtType').val();
        ticketDTO.movieId = $('#txtMovieId').val();
        ticketDTO.status = $('#txtStatus').val();

        // Enviar data al API
        var ca = new ControlActions();
        var urlEndpoint = this.API_ControllerName + "/Update";

        var vc = this;

        ca.PutToAPI(urlEndpoint, ticketDTO, function (response) {

            Swal.fire({
                icon: 'success',
                title: '¡Tiquete actualizado!',
                text: 'Los datos del tiquete fueron actualizados correctamente.'
            });

            //Recargar la tabla
            $('#tblTickets').DataTable().ajax.reload();

            // Limpiar el formulario
            vc.ClearForm();
        })
    }

    this.Delete = function () {
        var ticketDTO = {};

        //Set con valores default
        ticketDTO.created = "2026-01-01";
        ticketDTO.updated = "2026-01-01";

        // Set de valores capturados en el form/pantalla
        ticketDTO.id = $('#txtId').val();
        ticketDTO.price = $('#txtPrice').val();
        ticketDTO.schedule = $('#txtSchedule').val();
        ticketDTO.date = $('#txtDate').val();
        ticketDTO.type = $('#txtType').val();
        ticketDTO.movieId = $('#txtMovieId').val();
        ticketDTO.status = $('#txtStatus').val();

        // Enviar data al API
        var ca = new ControlActions();
        var urlEndpoint = this.API_ControllerName + "/Delete";

        var vc = this;

        ca.DeleteToAPI(urlEndpoint, ticketDTO, function (response) {

            Swal.fire({
                icon: 'success',
                title: '¡Tiquete eliminado!',
                text: 'El tiquete fue eliminado correctamente.'
            });

            //Recargar la tabla
            $('#tblTickets').DataTable().ajax.reload();

            // Limpiar el formulario
            vc.ClearForm();
        })
    }

}

// Instancia de la clase
$(document).ready(function () {
    var vc = new TicketViewController();
    vc.InitView();
});