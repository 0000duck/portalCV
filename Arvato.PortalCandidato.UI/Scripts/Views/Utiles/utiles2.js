var Utiles = function () {

    var miCatalogoValores;

    ///Cuando Inicia automaticamente rellenar el catalogo de valores

    var init = function (idioma) {
        //catalogoValoresServices.get(function (catalogoValores) {
        //    miCatalogoValores = catalogoValores;

        //}, fail);

        var option = {
            lng: idioma,
            getAsync: false,
            ns: 'translation',
            resGetPath: ruta + '/__lng__/__ns__.json'
        };
        i18n.init(option);
        moment.tz.setDefault("Europe/Madrid");



    }

    ///Rellena con autocomplete un input y en un hidden pone el valor(o no)
    var rellenarAutocompletePlataforma = function (contenedor, contenedorOculto, done) {
        plataformaService.getPlataformas(function (plataformas) {
            var source = [];
            for (var i = 0; i < plataformas.length; i++) {
                if (esCDE != "False" || (esCDE == "False" && valor_plataformaPk == plataformas[i].id)) {
                    source.push({
                        label: plataformas[i].name,
                        value: plataformas[i].id
                    });
                    if (valor_plataformaPk == plataformas[i].id) {
                        contenedor.val(plataformas[i].name);
                        contenedorOculto.val(plataformas[i].id);
                    }
                }
            }
            rellenarAutocomplete(source, contenedor, contenedorOculto)
            if (done != undefined) done();
        }, fail);
    }

    var rellenarAutocompleteSubproyectos = function (contenedor, contenedorOculto, plataforma) {
        subproyectoServices.getBySite(plataforma, function (subproyectos) {
            var source = [];
            for (var i = 0; i < subproyectos.length; i++) {
                source.push({
                    label: subproyectos[i].name,
                    value: subproyectos[i].id
                });
            }
            rellenarAutocomplete(source, contenedor, contenedorOculto)
        }, fail);
    }


    var rellenarSubproyectoService = function (contenedor, site, id) {
        subproyectoServices.getBySite(site, function (resultado) {
            rellenarCombo(contenedor, resultado, id);
        }, fail);
    }


    var rellenarComboServicios = function (contenedor, subproyecto, id) {
        serviceService.getBySubproyect(subproyecto, function (resultado) {
            rellenarCombo(contenedor, resultado, id);
        }, fail);
    }

    var rellenarCombo = function (contenedor, source, id) {
        contenedor.empty();
        $.each(source, function (item, index) {
            var combo = $('<option />')
                .attr('value', this.id)
                .text(this.name).appendTo(contenedor);
        });

        if (id != undefined) {
            contenedor.val(id);
        }
        contenedor.select2();
    }


    var rellenarAutocomplete = function (source, contenedor, contenedorOculeto) {
        contenedor.autocomplete({
            source: source,
            focus: function (event, ui) {
                event.preventDefault();
                contenedor.val(ui.item.label);
            },
            select: function (event, ui) {
                event.preventDefault();
                if (contenedorOculeto != undefined) contenedorOculeto.val(ui.item.value);
                else contenedor.val(ui.item.value);
                contenedor.val(ui.item.label);
                contenedor.trigger("change")
            }
        });
    }

    //fechas

    //obtiene la fecha actual y calcula dias DD/MM/YYY DD-MM-YYYY
    obtenerFecha = function (format, days) {
        if (format == undefined) format = "DD/MM/YYYY";
        if (days == undefined) days = 0;
        var date = new Date();
        return moment(date.toISOString()).add(days, 'days').format(format);
    }


    //formatea una fecha a un formato, pudiendo indicar el formato en el que se inserta la fecha
    formatearFecha = function (fecha, format, formatoEntrada, days) {
        if (fecha == undefined || fecha == null) return "";
        if (format == undefined) format = "DD/MM/YYYY";
        if (days == undefined) days = 0;
        if (formatoEntrada != undefined)
            return moment(moment(fecha, formatoEntrada).format("MM-DD-YYYY")).add(days, "days").format(format);
        else
            return moment(moment(fecha).format("MM-DD-YYYY")).add(days, "days").format(format);
    }

    compararFechas = function (fecha1, fecha2, format, esMayor) {
        if (fecha1 == undefined || fecha1 == null) return "";
        if (fecha2 == undefined || fecha2 == null) return "";
        if (format == undefined) format = "DD/MM/YYYY";
        if (esMayor == undefined || esMayor)
            return moment(fecha1, format).isAfter(moment(fecha2, format));
        else
            return moment(fecha1, format).isBefore(moment(fecha2, format));




    }

    formatearFechaTexto = function (fecha, formatOrigen, formatDestino) {
        if (formatDestino == undefined) formatDestino = "DD/MM/YYYY";

        return formatearFecha($.datepicker.parseDate(formatOrigen.toLowerCase(), fecha, formatDestino));
    }

    dateRangeFecha = function (fechadesde, fechahasta, fecha1Restriccion, fecha2Restriccion) {
        $(fechadesde).datepicker({
            format: 'dd-mm-yyyy',
            language: 'es'
        }).on('changeDate', function (ev) {
            $(fechadesde + ',' + fechahasta).addOk();
            if (ev.date > $.datepicker.parseDate('dd-mm-yy', $(fechahasta).val()) && $(fechahasta).val() != '') {
                $(fechahasta).addError('Fecha inicio es mayor que fecha fin');
                $(fechahasta).val('');
            }

            $.each(fecha1Restriccion, function (i, n) {
                switch (i) {
                    case 0:
                        if (ev.date < $.datepicker.parseDate('dd-mm-yy', n.date)) $(fechadesde).addError(n.notifica);
                        break;
                    case 1:
                        if (ev.date > $.datepicker.parseDate('dd-mm-yy', n.date)) $(fechadesde).addError(n.notifica);
                        break;
                }
                if ($(fechadesde + ' span').hasClass('error')) $(fechadesde).val('');
            });
        });

        $(fechahasta).datepicker({
            format: 'dd-mm-yyyy',
            language: 'es'
        }).on('changeDate', function (ev) {
            $(fechadesde + ',' + fechahasta).addOk();
            if (ev.date < $.datepicker.parseDate('dd-mm-yy', $(fechadesde).val()) && $(fechadesde).val() != '') {
                $(fechadesde).addError('Fecha fin es mayor que fecha inicio');
                $(fechadesde).val('');
            }
            $.each(fecha2Restriccion, function (i, n) {
                if (ev.date > $.datepicker.parseDate('dd-mm-yy', n.date)) $(fechahasta).addError(n.notifica);
                if ($(fechahasta + ' span').hasClass('error')) $(fechahasta).val('');
            });
        });
    }

    /**Funciones catalogo de valores**/
    //rellena el combo con catalogo de vales
    //Contendor --> Select
    //Tipo de combo es el tipo
    //valor seleccionado(opcional)
    ///campoBlanco opcional
    var obtenerCombo = function (Contenedor, TipoCombo, valorSeleccionado, campoBlanco) {

        Contenedor.empty();
        if (campoBlanco != undefined && campoBlanco == true) {
            var combo = $('<option />')
                          .attr('value', -1)
                          .text("");
            combo.appendTo(Contenedor)
        }

        $.each(miCatalogoValores, function (i, item) {
            if (this.campo == TipoCombo) {
                var combo = $('<option />')
                            .attr('value', this.idCampo)
                            .text(this.valor);
                combo.appendTo(Contenedor);
            }
        });

        if (valorSeleccionado != undefined) {
            Contenedor.val(valorSeleccionado);
        }
        Contenedor.select2();
    }


    //hace lo mismo que el de arriba pero el campo seleccionado es el idValorCampo
    var obtenerComboPorIdValidacion = function (Contenedor, TipoCombo, valorSeleccionado, campoBlanco) {
        if (campoBlanco != undefined && campoBlanco == true) {
            var combo = $('<option />')
                          .attr('value', -1)
                          .text("");
            combo.appendTo(Contenedor)
        }

        $.each(miCatalogoValores, function (i, item) {
            if (this.campo == TipoCombo) {
                var combo = $('<option />')
                            .attr('value', this.idValidacionCampo)
                            .text(this.valor);
                combo.appendTo(Contenedor);
            }
        });

        if (valorSeleccionado != undefined) {
            Contenedor.val(valorSeleccionado);
        }
        Contenedor.select2();
    }

    ///Obtiene un Vlaor del Catalogo
    var obtenerValorCatalogo = function (tipo, valorBusqueda) {
        var res;
        try {
            res = miCatalogoValores.filter(function (valor) {
                return valor.campo == tipo && valor.idCampo == valorBusqueda;
            })[0].valor
        }
        catch (e) {//para IE8
            return "";
        }
        return res;
    }

    //Obtiene el valor exacto del catlogo
    var obtenerValorExactoCatalogo = function (valorBusqueda) {
        var res;
        try {
            res = miCatalogoValores.filter(function (valor) {
                return valor.idValidacionCampo == valorBusqueda;
            })[0].valor
        }
        catch (e) {//para IE8
            return "";
        }
        return res;
    }

    //Obtener valores de un tipo
    var obtenerValoes = function (tipo) {
        var res;
        try {
            res = miCatalogoValores.filter(function (valor) {
                return valor.campo == tipo;
            });
        }
        catch (e) {//para IE8
            return "";
        }
        return res;
    }



    //Excel

    var exportarCSV = function (tabla, nombrefichero) {
        var $headers = $(tabla).find('tr:has(th)')
        var $rows = $(tabla).find('tr:has(td)')


        var tmpColDelim = String.fromCharCode(11) // separador 
        var tmpRowDelim = String.fromCharCode(0) // nulo

        //delimitador csv
        var colDelim = '";"'
        var rowDelim = '"\r\n"';

        // Formatear en cadena
        var csv = '"';
        csv += formatRows($headers.map(grabRow));
        csv += rowDelim;
        csv += formatRows($rows.map(grabRow)) + '"';




        try {
            var csvData = '\ufeff' + csv;
            var blobdata = new Blob([csvData], { type: ' type: "text/csv;charset=UTF-8"' });//Here, I also tried charset=GBK , and it does not work either
            var link = document.createElement("a");
            link.setAttribute("href", window.URL.createObjectURL(blobdata));
            link.setAttribute("download", nombrefichero + ".csv");
            document.body.appendChild(link);
            link.click();
        }
        catch (e)//Solucion IE
        {
            var csvData = '\ufeff' + csv;

            // For IE (tested 10+)
            if (window.navigator.msSaveOrOpenBlob) {
                var blob = new Blob([csvData], { type: ' type: "text/csv;charset=UTF-8"' });//Here, I also tried charset=GBK , and it does not work either
                navigator.msSaveBlob(blob, nombrefichero + ".csv");
            } else {
                $(this)
                    .attr({
                        'download': nombrefichero + ".csv"
                        , 'href': csvData
                        //,'target' : '_blank' 
                    });
            }
        }


        //formato columnas

        function formatRows(rows) {
            return rows.get().join(tmpRowDelim)
                .split(tmpRowDelim).join(rowDelim)
                .split(tmpColDelim).join(colDelim);
        }


        //obtenerFila
        function grabRow(i, row) {
            var $row = $(row);
            var $cols = $row.find('td');
            if (!$cols.length) $cols = $row.find('th');

            return $cols.map(grabCol).get().join(tmpColDelim);
        }
        //obtenerColumna
        function grabCol(j, col) {
            var $col = $(col),
                $text = $col.text();
            return $text.replace('"', '""'); //escape

        }
    }


    ///Funciones Internas
    var fail = function (e, error) {
        mostrarAviso("Ha ocurrido un error accediendo a los datos", "error");
    }


    return {
        rellenarAutocompletePlataforma: rellenarAutocompletePlataforma,
        rellenarAutocompleteSubproyectos: rellenarAutocompleteSubproyectos,
        rellenarCombo: rellenarCombo,
        rellenarSubproyectoService: rellenarSubproyectoService,
        rellenarComboServicios: rellenarComboServicios,
        rellenarAutocomplete: rellenarAutocomplete,
        obtenerCombo: obtenerCombo,
        obtenerComboPorIdValidacion: obtenerComboPorIdValidacion,
        obtenerValorCatalogo: obtenerValorCatalogo,
        obtenerValorExactoCatalogo: obtenerValorExactoCatalogo,
        obtenerValoes: obtenerValoes,
        obtenerFecha: obtenerFecha,
        formatearFecha: formatearFecha,
        dateRangeFecha: dateRangeFecha,
        compararFechas: compararFechas,
        formatearFechaTexto: formatearFechaTexto,
        exportarCSV: exportarCSV,
        init: init
    }


}();

var $U = Utiles;