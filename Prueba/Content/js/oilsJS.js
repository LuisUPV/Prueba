$(document).ready(function () {
    $("#datoFecha").val($("#fechaInicio").text());
});

if ($("select.chosen-select").length > 0) {
    $("select.chosen-select").each(function () {
        if ($(this).attr('required') !== undefined) {
            $(this).on("change", function () {
                $(this).valid();
            });
        }
    });
}

$.validator.setDefaults({ ignore: ":hidden:not(.select-chosen)" })

$("#Create_OILs").validate({
    rules: {
        id_responsability: "required",
        id_area: "required",
        id_priority: "required",
        id_tipo_oil: "required",
        line: "required",
        Issue: "required",
        Action_Plan: "required",
        Cause_Effect: "required",
    },
    messages: {
        id_responsability: "Seleccione un 'Responsable' por favor *",
        id_area: "Seleccione un 'Área' por favor *",
        id_priority: "Seleccione la 'Prioridad' por favor *",
        id_tipo_oil: "Seleccione el 'Tipo' por favor *",
        line: "Ingrese la 'Linea' por favor *",
        Issue: "Describa el 'Problema' por favor *",
        Action_Plan: "Describa el 'Plan de acción' por favor *",
        Cause_Effect: "Describa la 'Causa y efecto' por favor *"
    },
    errorPlacement: function (error, element) {
        console.log("placement");
        if (element.is("select.select-chosen")) {
            console.log("placement for chosen");
            // placement for chosen
            element.next("div.chosen-container").append(error);
        } else {
            // standard placement
            error.insertAfter(element);
        }
    },
    submitHandler: function (form) {
        form.submit();
    }
});


$("#btnCancelar").on("click", function (event) {
    event.preventDefault();
    parent.$.fancybox.close();
});

$("#btnGuardarfromToc").on("click", function (event) {
    $.post('/oils/Create/', function (result) {
        // Do something with the result like for example inject it into
        // some placeholder and update the DOM.
        // This obviously assumes that your controller action returns
        // a partial view otherwise you will break your markup
        event.preventDefault();
        parent.$.fancybox.close();
    });
    event.preventDefault();
    parent.$.fancybox.close();
});

$("#selecTipo").change(function () {
    var value = $(this).children("option:selected").val();
    $("#tipoDato").val(value);
});

//Obtener Id area y Nombre Area
$("#id_responsability").change(function () {
    var emp = $(this).val();
    $.ajax({
        type: "GET",
        url: "area_empleado/" + emp,
        success: function (data) {
            //$("#areaEmpleado").text(data.nombre);
            //$("#id_area").val(data.id_area);
            //$("#areaEmpleado").css("font-weight", "Bold");
            $("#lineaInput").show();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (jqXHR.status === 0) { console.log('Not connect: Verify Network.'); }
            else if (jqXHR.status == 404) { console.log('Requested page not found [404]'); }
            else if (jqXHR.status == 500) { console.log('Internal Server Error [500].'); }
            else if (textStatus === 'parsererror') { console.log('Requested JSON parse failed.'); }
            else if (textStatus === 'timeout') { console.log('Time out error.'); }
            else if (textStatus === 'abort') { console.log('Ajax request aborted.'); }
            else { console.log('Uncaught Error: ' + jqXHR.responseText); }
        }
    });
});

$("#id_priority").change(function () {

    var id = $(this).val();
    $.ajax({
        type: "GET",
        url: "fechaFinal_por_DiasLaborales/" + id,
        success: function (data) {

            //CONVERTIR FECHA JSON A FORMATO dd/mm/yyyy

            var dateString = data.fechaDaysToFix.substr(6);
            var currentTime = new Date(parseInt(dateString));
            var month = currentTime.getMonth() + 1;
            var day = currentTime.getDate();
            var year = currentTime.getFullYear();
            var date = day + "/" + month + "/" + year;

            $("#fechaFinal").text(date);
            $("#fechaFinal").css("font-weight", "Bold");
            $("#Target_Date").val(date);

            $("#DiasLaborales").text(data.DaysFix);
            $("#DiasLaborales").css("font-weight", "Bold");
            $("#Atention_Days").val(data.DaysFix);

            $("#id_Status").val(data.id_Status);
            $("#Estatus").text(data.letra);
            $("#divStatus").removeClass();
            $("#divStatus").css('color', 'white');
            $("#divStatus").css('text-align', 'center');

            switch (data.letra) {
                case 'R':
                    $("#divStatus").css('background-color', 'rgb(255, 0, 0)');
                    break;
                case 'Y':
                    $("#divStatus").css('background-color', 'rgb(255, 255, 0)');
                    $("#divStatus").css('color', 'black');
                    break;
                case 'B':
                    $("#divStatus").css('background-color', 'rgb(83, 141, 213)');
                    break;
                case 'G':
                    $("#divStatus").css('background-color', 'rgb(0, 176, 80)');
                    break;
                default:
                    alert('ERROR JSON data ');
                    break;

            }



        },
        error: function (jqXHR, textStatus, errorThrown) {
            if (jqXHR.status === 0) { console.log('Not connect: Verify Network.'); }
            else if (jqXHR.status == 404) { console.log('Requested page not found [404]'); }
            else if (jqXHR.status == 500) { console.log('Internal Server Error [500].'); }
            else if (textStatus === 'parsererror') { console.log('Requested JSON parse failed.'); }
            else if (textStatus === 'timeout') { console.log('Time out error.'); }
            else if (textStatus === 'abort') { console.log('Ajax request aborted.'); }
            else { console.log('Uncaught Error: ' + jqXHR.responseText); }
        }
    });

});