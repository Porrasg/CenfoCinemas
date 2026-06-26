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
    }
}

// Instancia de la clase
$(document).ready(function () {
    var vc = new MovieViewController();
    vc.InitView();
});




