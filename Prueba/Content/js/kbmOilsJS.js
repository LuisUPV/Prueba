//Obtener Id area y Nombre Area
$("#btnFiltrar").click(function () {    
    var year = $("#kbmAno option:selected").val();
    window.location.href = '../KBM/' + year;    
});
$("#exportarBusqueda").click(function () {
    var year = $("#añolbl").text();
    window.location.href = '../ExportarExcel/101' + year;
});

var $g1 = [], $g2 = [], $g3 = [], $g4 = [], $g5 = [], $g6 = [];

$(document).ready(function () {
    var year = $("#idkbm").val();
    if (year != null) {
        
        $.ajax({
            type: "GET",
            url: "../kbmTables/" + year,
            success: function (data) {
                orderArrays(data);
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
    }    
});

function orderArrays(data) {    
    var $aux1, $aux2, $aux3, $aux4, $aux5,$aux6;
    var $data = data;
    //PRIMER GRAFICA-----------------------------------------------------------------------------------
    $aux1 = data.general1;
    $aux2 = data.general2;
    $aux3 = data.general3;
    $aux4 = data.general4;    
    for (var i = 1; i < ($aux1.length - 1) ; i++) {
        if ($aux1[i] == null) {
            $g1[i - 1] = 0;
            $g2[i - 1] = 0;
            $g3[i - 1] = 0;
            $g4[i - 1] = 0;
        }
        else {
            $g1[i - 1] = parseInt($aux1[i]);
            $g2[i - 1] = parseInt($aux2[i]);
            $g3[i - 1] = parseInt($aux3[i]);
            $g4[i - 1] = parseInt($aux4[i]);            
        }
    }    
    graficaGENERAL($aux1[0], $aux2[0], $aux3[0], $aux4[0], $g1, $g2, $g3, $g4);

    //SEGUNDA GRAFICA-----------------------------------------------------------------------------------
    $aux1 = data.safetySC1;
    $aux2 = data.safetySC2;
    $aux3 = data.safetySC3;
    $aux4 = data.safetySC4;
    $aux5 = data.safetySC5;
    $aux6 = data.safetySC6;
    for (var i = 1; i < ($aux1.length - 1) ; i++) {
        if ($aux1[i] == null) {
            $g1[i - 1] = 0;
            $g2[i - 1] = 0;
            $g3[i - 1] = 0;
            $g4[i - 1] = 0;
            $g5[i - 1] = 0;
            $g6[i - 1] = 0;
        }
        else {
            $g1[i - 1] = parseInt($aux1[i]);
            $g2[i - 1] = parseInt($aux2[i]);
            $g3[i - 1] = parseInt($aux3[i]);
            $g4[i - 1] = parseInt($aux4[i]);
            $g5[i - 1] = parseInt($aux5[i]);
            $g6[i - 1] = parseInt($aux6[i]);
        }
    }
    graficaSafetyJCSC($aux1[0], $aux2[0], $aux3[0], $aux4[0], $aux5[0], $aux6[0], $g1, $g2, $g3, $g4, $g5, $g6);

    //TERCER GRAFICA-----------------------------------------------------------------------------------
    $aux1 = data.sfty1;
    $aux2 = data.sfty2;
    $aux3 = data.sfty3;
    $aux4 = data.sfty4;
    $aux5 = data.sfty5;
    for (var i = 1; i < ($aux1.length - 1) ; i++) {
        if ($aux1[i] == null) {
            $g1[i - 1] = 0;
            $g2[i - 1] = 0;
            $g3[i - 1] = 0;
            $g4[i - 1] = 0;
            $g5[i - 1] = 0;
        }
        else {
            $g1[i - 1] = parseInt($aux1[i]);
            $g2[i - 1] = parseInt($aux2[i]);
            $g3[i - 1] = parseInt($aux3[i]);
            $g4[i - 1] = parseInt($aux4[i]);
            $g5[i - 1] = parseInt($aux5[i]);
        }
    }
    graficaSafety($aux1[0], $aux2[0], $aux3[0], $aux4[0], $aux5[0], $g1, $g2, $g3, $g4, $g5);
    //CUARTA GRAFICA-----------------------------------------------------------------------------------
    $aux1 = data.jhsc1;
    $aux2 = data.jhsc2;
    $aux3 = data.jhsc3;
    $aux4 = data.jhsc4;
    $aux5 = data.jhsc5;
    for (var i = 1; i < ($aux1.length - 1) ; i++) {
        if ($aux1[i] == null) {
            $g1[i - 1] = 0;
            $g2[i - 1] = 0;
            $g3[i - 1] = 0;
            $g4[i - 1] = 0;
            $g5[i - 1] = 0;
        }
        else {
            $g1[i - 1] = parseInt($aux1[i]);
            $g2[i - 1] = parseInt($aux2[i]);
            $g3[i - 1] = parseInt($aux3[i]);
            $g4[i - 1] = parseInt($aux4[i]);
            $g5[i - 1] = parseInt($aux5[i]);
        }
    }
    graficaJHSC($aux1[0], $aux2[0], $aux3[0], $aux4[0], $aux5[0], $g1, $g2, $g3, $g4, $g5);
    //QUINTA GRAFICA-----------------------------------------------------------------------------------
    $aux1 = data.ergo1;
    $aux2 = data.ergo2;
    $aux3 = data.ergo3;
    $aux4 = data.ergo4;
    $aux5 = data.ergo5;
    for (var i = 1; i < ($aux1.length - 1) ; i++) {
        if ($aux1[i] == null) {
            $g1[i - 1] = 0;
            $g2[i - 1] = 0;
            $g3[i - 1] = 0;
            $g4[i - 1] = 0;
            $g5[i - 1] = 0;
        }
        else {
            $g1[i - 1] = parseInt($aux1[i]);
            $g2[i - 1] = parseInt($aux2[i]);
            $g3[i - 1] = parseInt($aux3[i]);
            $g4[i - 1] = parseInt($aux4[i]);
            $g5[i - 1] = parseInt($aux5[i]);
        }
    }
    graficaERGO($aux1[0], $aux2[0], $aux3[0], $aux4[0], $aux5[0], $g1, $g2, $g3, $g4, $g5);

    //SEXTA GRAFICA-----------------------------------------------------------------------------------
    $aux1 = data.ohsas1;
    $aux2 = data.ohsas2;
    $aux3 = data.ohsas3;
    $aux4 = data.ohsas4;
    $aux4 = data.ohsas5;
    for (var i = 1; i < ($aux1.length - 1) ; i++) {
        if ($aux1[i] == null) {
            $g1[i - 1] = 0;
            $g2[i - 1] = 0;
            $g3[i - 1] = 0;
            $g4[i - 1] = 0;
            $g5[i - 1] = 0;
        }
        else {
            $g1[i - 1] = parseInt($aux1[i]);
            $g2[i - 1] = parseInt($aux2[i]);
            $g3[i - 1] = parseInt($aux3[i]);
            $g4[i - 1] = parseInt($aux4[i]);
            $g5[i - 1] = parseInt($aux5[i]);
        }
    }
    graficaOHSAS($aux1[0], $aux2[0], $aux3[0], $aux4[0], $aux5[0], $g1, $g2, $g3, $g4, $g5);    
}
function graficaGENERAL(name1, name2, name3, name4, data1, data2, data3, data4) {
    
    Highcharts.chart('container1', {

        title: {
            text: 'KBM METRIC'
        },

        subtitle: {
            text: 'Open Issue List'
        },

        yAxis: {
            title: {
                text: 'OILS x Month'
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle'
        },
        xAxis: {
            min: 0,
            categories: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre']
        },

        plotOptions: {
            series: {
                label: {
                    connectorAllowed: false
                },
                pointStart: 0
            }
        },

        series: [{
            name: name1,
            data: data1
        }, {
            name: name2,
            data: data2
        }, {
            name: name3,
            data: data3
        }, {
            name: name4,
            data: data4
        }],

        responsive: {
            rules: [{
                condition: {
                    maxWidth: 500
                },
                chartOptions: {
                    legend: {
                        layout: 'horizontal',
                        align: 'center',
                        verticalAlign: 'bottom'
                    }
                }
            }]
        }

    });
}
function graficaSafetyJCSC(name1, name2, name3, name4, name5, name6, data1, data2, data3, data4, data5, data6) {

    Highcharts.chart('container2', {

        title: {
            text: 'Total H&S Issues Safety & JHSC'
        },

        subtitle: {
            text: 'Open Issue List'
        },

        yAxis: {
            title: {
                text: 'OILS x Month'
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle'
        },
        xAxis: {
            min: 0,
            categories: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre']
        },

        plotOptions: {
            series: {
                label: {
                    connectorAllowed: false
                },
                pointStart: 0
            }
        },

        series: [{
            name: name1,
            data: data1
        }, {
            name: name2,
            data: data2
        }, {
            name: name3,
            data: data3
        }, {
            name: name4,
            data: data4
        }, {
            name: name5,
            data: data5
        }, {
            name: name6,
            data: data6
        }],

        responsive: {
            rules: [{
                condition: {
                    maxWidth: 500
                },
                chartOptions: {
                    legend: {
                        layout: 'horizontal',
                        align: 'center',
                        verticalAlign: 'bottom'
                    }
                }
            }]
        }

    });
}
function graficaSafety(name1, name2, name3, name4, name5, data1, data2, data3, data4,data5) {

    Highcharts.chart('container3', {

        title: {
            text: 'Safety OIL'
        },

        subtitle: {
            text: 'Open Issue List'
        },

        yAxis: {
            title: {
                text: 'OILS x Month'
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle'
        },
        xAxis: {
            min: 0,
            categories: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre']
        },

        plotOptions: {
            series: {
                label: {
                    connectorAllowed: false
                },
                pointStart: 0
            }
        },

        series: [{
            name: name1,
            data: data1
        }, {
            name: name2,
            data: data2
        }, {
            name: name3,
            data: data3
        }, {
            name: name4,
            data: data4
        }, {
            name: name5,
            data: data5
        }],

        responsive: {
            rules: [{
                condition: {
                    maxWidth: 500
                },
                chartOptions: {
                    legend: {
                        layout: 'horizontal',
                        align: 'center',
                        verticalAlign: 'bottom'
                    }
                }
            }]
        }

    });
}
function graficaJHSC(name1, name2, name3, name4, name5, data1, data2, data3, data4, data5) {

    Highcharts.chart('container4', {

        title: {
            text: 'Join Healt & Safety Committe'
        },

        subtitle: {
            text: 'Open Issue List'
        },

        yAxis: {
            title: {
                text: 'OILS x Month'
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle'
        },
        xAxis: {
            min: 0,
            categories: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre']
        },

        plotOptions: {
            series: {
                label: {
                    connectorAllowed: false
                },
                pointStart: 0
            }
        },

        series: [{
            name: name1,
            data: data1
        }, {
            name: name2,
            data: data2
        }, {
            name: name3,
            data: data3
        }, {
            name: name4,
            data: data4
        }, {
            name: name5,
            data: data5
        }],

        responsive: {
            rules: [{
                condition: {
                    maxWidth: 500
                },
                chartOptions: {
                    legend: {
                        layout: 'horizontal',
                        align: 'center',
                        verticalAlign: 'bottom'
                    }
                }
            }]
        }

    });
}
function graficaERGO(name1, name2, name3, name4, name5, data1, data2, data3, data4, data5) {

    Highcharts.chart('container5', {

        title: {
            text: 'Ergo OIL'
        },

        subtitle: {
            text: 'Open Issue List'
        },

        yAxis: {
            title: {
                text: 'OILS x Month'
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle'
        },
        xAxis: {
            min: 0,
            categories: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre']
        },

        plotOptions: {
            series: {
                label: {
                    connectorAllowed: false
                },
                pointStart: 0
            }
        },

        series: [{
            name: name1,
            data: data1
        }, {
            name: name2,
            data: data2
        }, {
            name: name3,
            data: data3
        }, {
            name: name4,
            data: data4
        }, {
            name: name5,
            data: data5
        }],

        responsive: {
            rules: [{
                condition: {
                    maxWidth: 500
                },
                chartOptions: {
                    legend: {
                        layout: 'horizontal',
                        align: 'center',
                        verticalAlign: 'bottom'
                    }
                }
            }]
        }

    });
}
function graficaOHSAS(name1, name2, name3, name4, name5, data1, data2, data3, data4, data5) {

    Highcharts.chart('container6', {

        title: {
            text: 'OHSAS OIL'
        },

        subtitle: {
            text: 'Open Issue List'
        },

        yAxis: {
            title: {
                text: 'OILS x Month'
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle'
        },
        xAxis: {
            min: 0,
            categories: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre']
        },

        plotOptions: {
            series: {
                label: {
                    connectorAllowed: false
                },
                pointStart: 0
            }
        },

        series: [{
            name: name1,
            data: data1
        }, {
            name: name2,
            data: data2
        }, {
            name: name3,
            data: data3
        }, {
            name: name4,
            data: data4
        }, {
            name: name5,
            data: data5
        }],

        responsive: {
            rules: [{
                condition: {
                    maxWidth: 500
                },
                chartOptions: {
                    legend: {
                        layout: 'horizontal',
                        align: 'center',
                        verticalAlign: 'bottom'
                    }
                }
            }]
        }

    });
}

