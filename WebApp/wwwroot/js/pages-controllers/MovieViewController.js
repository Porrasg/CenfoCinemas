// Clase que controla la vista Movies.cshtml

// Definir una clase JS utilizando prototype

function MovieViewController() {
    this.ViewName = "Movies";

    //API que vamos a consumir desde esta vista
    this.API_ControllerName = "Movies";

    //metodo constructor
    this.InitView = function () {
        //Invocar la carga de la tabla
        this.LoadTable();

        // Asignar evento al boton de crear
        $('#btnCreate').on('click', function () {
            var vc = new MovieViewController();
            vc.Create();
        })

        // Asignar evento al boton de update
        $('#btnUpdate').on('click', function () {
            var vc = new MovieViewController();
            vc.Update();
        })

        // Asignar evento al boton de eliminar
        $('#btnDelete').on('click', function () {
            var vc = new MovieViewController();
            vc.Delete();
        })

    }

    // metodo de carga de la tabla
    this.LoadTable = function () {

        var ca = new ControlActions();

        // https://localhost:7031/api/Movies/RetrieveAll
        //Endpoint que vamos a consumir
        var endPoint = this.API_ControllerName + "/RetrieveAll";

        var urlService = ca.GetUrlApiService(endPoint);

        // Match de las columnas
        var columns = [];
        columns[0] = { 'data': 'id', title: 'Id' }
        columns[1] = { 'data': 'title', title: 'Título' }
        columns[2] = { 'data': 'sinopsis', title: 'Sinopsis' }
        columns[3] = { 'data': 'genre', title: 'Género' }
        columns[4] = { 'data': 'duration', title: 'Duración' }
        columns[5] = { 'data': 'classification', title: 'Clasificación' }
        columns[6] = { 'data': 'image', title: 'Imagen' }
        columns[7] = { 'data': 'status', title: 'Estado' }
        columns[8] = { 'data': 'created', title: 'Fecha de Creación' }

        // convertir la tabla plana en una tabla mas dinamica
        $("#tblMovies").dataTable({
            "ajax": {
                url: urlService,
                "dataSrc": ""
            },
            "columns": columns
        });

        // ASIGNAR EVENTO DE MAPEO DEL DTO SELECCIONADO CON EL FORM
        $('#tblMovies tbody').on('click', 'tr', function () {

            var row = $(this).closest('tr');

            // vamos a extraer el dto
            var movieDTO = $('#tblMovies').DataTable().row(row).data();

            //cargamos el DTO en el form
            $('#txtId').val(movieDTO.id);
            $('#txtTitle').val(movieDTO.title);
            $('#txtSinopsis').val(movieDTO.sinopsis);
            $('#txtGenre').val(movieDTO.genre);
            $('#txtDuration').val(movieDTO.duration);
            $('#txtClassification').val(movieDTO.classification);
            $('#txtImage').val(movieDTO.image);
            $('#txtStatus').val(movieDTO.status);

        });
    }

    // Limpiar el formulario
    this.ClearForm = function () {
        $('#txtId').val('');
        $('#txtTitle').val('');
        $('#txtSinopsis').val('');
        $('#txtGenre').val('');
        $('#txtDuration').val('');
        $('#txtClassification').val('');
        $('#txtImage').val('');
        $('#txtStatus').val('');
    }

    this.ValidateForm = function () {

        // Campos obligatorios
        if (
            $('#txtTitle').val().trim() === "" ||
            $('#txtSinopsis').val().trim() === "" ||
            $('#txtGenre').val().trim() === "" ||
            $('#txtDuration').val().trim() === "" ||
            $('#txtClassification').val().trim() === "" ||
            $('#txtImage').val().trim() === "" ||
            $('#txtStatus').val().trim() === ""
        ) {

            Swal.fire({
                icon: 'warning',
                title: 'Campos obligatorios',
                text: 'Todos los campos son obligatorios.'
            });

            return false;
        }

        // Duración positiva
        if (parseInt($('#txtDuration').val()) <= 0) {

            Swal.fire({
                icon: 'warning',
                title: 'Duración inválida',
                text: 'La duración debe ser mayor que cero.'
            });

            return false;
        }

        return true;
    }

    this.Create = function () {

        if (!this.ValidateForm()) {
            return;
        }

        var movieDTO = {};

        //Set con valores default
        movieDTO.id = 0;
        movieDTO.created = "2026-01-01";
        movieDTO.updated = "2026-01-01";

        // Set de valores capturados en el form/pantalla
        movieDTO.title = $('#txtTitle').val();
        movieDTO.sinopsis = $('#txtSinopsis').val();
        movieDTO.genre = $('#txtGenre').val();
        movieDTO.duration = $('#txtDuration').val();
        movieDTO.classification = $('#txtClassification').val();
        movieDTO.image = $('#txtImage').val();
        movieDTO.status = $('#txtStatus').val();

        // Enviar data al API
        var ca = new ControlActions();
        var urlEndpoint = this.API_ControllerName + "/Create";

        var vc = this;

        ca.PostToAPI(urlEndpoint, movieDTO, function (response) {

            Swal.fire({
                icon: 'success',
                title: '¡Película creada!',
                text: 'La película se registró correctamente.'
            });

            //Recargar la tabla
            $('#tblMovies').DataTable().ajax.reload();

            // Limpiar el formulario
            vc.ClearForm();
        })
    }

    this.Update = function () {

        if (!this.ValidateForm()) {
            return;
        }

        var movieDTO = {};

        //Set con valores default
        movieDTO.created = "2026-01-01";
        movieDTO.updated = "2026-01-01";

        // Set de valores capturados en el form/pantalla
        movieDTO.id = $('#txtId').val();
        movieDTO.title = $('#txtTitle').val();
        movieDTO.sinopsis = $('#txtSinopsis').val();
        movieDTO.genre = $('#txtGenre').val();
        movieDTO.duration = $('#txtDuration').val();
        movieDTO.classification = $('#txtClassification').val();
        movieDTO.image = $('#txtImage').val();
        movieDTO.status = $('#txtStatus').val();

        // Enviar data al API
        var ca = new ControlActions();
        var urlEndpoint = this.API_ControllerName + "/Update";

        var vc = this;

        ca.PutToAPI(urlEndpoint, movieDTO, function (response) {

            Swal.fire({
                icon: 'success',
                title: '¡Película actualizada!',
                text: 'Los datos de la película fueron actualizados correctamente.'
            });

            //Recargar la tabla
            $('#tblMovies').DataTable().ajax.reload();

            // Limpiar el formulario
            vc.ClearForm();
        })
    }

    this.Delete = function () {
        var movieDTO = {};

        //Set con valores default
        movieDTO.created = "2026-01-01";
        movieDTO.updated = "2026-01-01";

        // Set de valores capturados en el form/pantalla
        movieDTO.id = $('#txtId').val();
        movieDTO.title = $('#txtTitle').val();
        movieDTO.sinopsis = $('#txtSinopsis').val();
        movieDTO.genre = $('#txtGenre').val();
        movieDTO.duration = $('#txtDuration').val();
        movieDTO.classification = $('#txtClassification').val();
        movieDTO.image = $('#txtImage').val();
        movieDTO.status = $('#txtStatus').val();

        // Enviar data al API
        var ca = new ControlActions();
        var urlEndpoint = this.API_ControllerName + "/Delete";

        var vc = this;

        ca.DeleteToAPI(urlEndpoint, movieDTO, function (response) {

            Swal.fire({
                icon: 'success',
                title: '¡Película eliminada!',
                text: 'La película fue eliminada correctamente.'
            });

            //Recargar la tabla
            $('#tblMovies').DataTable().ajax.reload();

            // Limpiar el formulario
            vc.ClearForm();
        })
    }

}

// Instancia de la clase
$(document).ready(function () {
    var vc = new MovieViewController();
    vc.InitView();
});




