function ControlActions() {

    //Ruta base del API
    this.URL_API = "https://localhost:7031/api/";
    //this.URL_API = "https://cenfocinemas-dcordoba-axhnembvfrema9b7.eastus2-01.azurewebsites.net/api/"

    this.GetUrlApiService = function (service) {
        return this.URL_API + service;
    }

    this.GetTableColumsDataName = function (tableId) {
        var val = $('#' + tableId).attr("ColumnsDataName");
        return val;
    }

    this.FillTable = function (service, tableId, refresh) {

        if (!refresh) {

            columns = this.GetTableColumsDataName(tableId).split(',');
            var arrayColumnsData = [];

            $.each(columns, function (index, value) {
                var obj = {};
                obj.data = value;
                arrayColumnsData.push(obj);
            });

            $('#' + tableId).DataTable({
                "processing": true,
                "ajax": {
                    "url": this.GetUrlApiService(service),
                    dataSrc: ''
                },
                "columns": arrayColumnsData
            });

        } else {

            $('#' + tableId).DataTable().ajax.reload();

        }

    }

    this.GetSelectedRow = function () {
        var data = sessionStorage.getItem(tableId + '_selected');
        return data;
    };

    this.BindFields = function (formId, data) {

        $('#' + formId + ' *').filter(':input').each(function (input) {

            var columnDataName = $(this).attr("ColumnDataName");
            this.value = data[columnDataName];

        });
    }

    this.GetDataForm = function (formId) {

        var data = {};

        $('#' + formId + ' *').filter(':input').each(function (input) {

            var columnDataName = $(this).attr("ColumnDataName");
            data[columnDataName] = this.value;

        });

        return data;
    }


    /* ===========================
       POST
    =========================== */

    this.PostToAPI = function (service, data, callBackFunction) {

        $.ajax({

            type: "POST",
            url: this.GetUrlApiService(service),
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",

            success: function (response) {

                if (callBackFunction) {
                    callBackFunction(response);
                }

            },

            error: function (jqXHR) {

                var message = "Ocurrió un error inesperado.";

                if (jqXHR.responseJSON) {

                    if (jqXHR.responseJSON.message) {

                        message = jqXHR.responseJSON.message;

                    } else if (jqXHR.responseJSON.errors) {

                        var errors = jqXHR.responseJSON.errors;
                        message = Object.values(errors).flat().join("<br>");

                    }

                } else if (jqXHR.responseText) {

                    // message = jqXHR.responseText;
                    message = "Ocurrió un error al procesar la solicitud. Intente nuevamente.";
                }

                Swal.fire({
                    icon: 'error',
                    title: 'No fue posible completar la operación',
                    html: message,
                    confirmButtonText: 'Aceptar'
                });

            }

        });

    }


    /* ===========================
       PUT
    =========================== */

    this.PutToAPI = function (service, data, callBackFunction) {

        $.put(this.GetUrlApiService(service), data, function (response) {

            if (callBackFunction) {
                callBackFunction(response);
            }

        })

            .fail(function (jqXHR) {

                var message = "Ocurrió un error inesperado.";

                if (jqXHR.responseJSON) {

                    if (jqXHR.responseJSON.message) {

                        message = jqXHR.responseJSON.message;

                    } else if (jqXHR.responseJSON.errors) {

                        var errors = jqXHR.responseJSON.errors;
                        message = Object.values(errors).flat().join("<br>");

                    }

                } else if (jqXHR.responseText) {

                    //message = jqXHR.responseText;
                    message = "Ocurrió un error al procesar la solicitud. Intente nuevamente.";

                }

                Swal.fire({

                    icon: 'error',
                    title: 'No fue posible completar la operación',
                    html: message,
                    confirmButtonText: 'Aceptar'

                });

            });

    };


    /* ===========================
       DELETE
    =========================== */

    this.DeleteToAPI = function (service, data, callBackFunction) {

        $.delete(this.GetUrlApiService(service), data, function (response) {

            if (callBackFunction) {
                callBackFunction(response);
            }

        })

            .fail(function (jqXHR) {

                var message = "Ocurrió un error inesperado.";

                if (jqXHR.responseJSON) {

                    if (jqXHR.responseJSON.message) {

                        message = jqXHR.responseJSON.message;

                    } else if (jqXHR.responseJSON.errors) {

                        var errors = jqXHR.responseJSON.errors;
                        message = Object.values(errors).flat().join("<br>");

                    }

                } else if (jqXHR.responseText) {

                    //message = jqXHR.responseText;
                    message = "Ocurrió un error al procesar la solicitud. Intente nuevamente.";

                }

                Swal.fire({

                    icon: 'error',
                    title: 'No fue posible completar la operación',
                    html: message,
                    confirmButtonText: 'Aceptar'

                });

            });

    };


    /* ===========================
       GET
    =========================== */

    this.GetToApi = function (service, callBackFunction) {

        $.get(this.GetUrlApiService(service), function (response) {

            if (callBackFunction) {
                callBackFunction(response);
            }

        });

    }

}



/* ===========================
   CUSTOM JQUERY
=========================== */

$.put = function (url, data, callback) {

    if ($.isFunction(data)) {

        callback = data;
        data = {};

    }

    return $.ajax({

        url: url,
        type: 'PUT',
        success: callback,
        data: JSON.stringify(data),
        contentType: 'application/json'

    });

}


$.delete = function (url, data, callback) {

    if ($.isFunction(data)) {

        callback = data;
        data = {};

    }

    return $.ajax({

        url: url,
        type: 'DELETE',
        success: callback,
        data: JSON.stringify(data),
        contentType: 'application/json'

    });

}