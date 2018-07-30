

//Politica Modal
$('#idPolitica').click(function () {
    $('#idModalPolitica').modal();

});


//Funcion de seleccionar el archivo
$("#btnExaminar").click(function () {
    $("#archivo").click();
});

$("#archivo").change(function () {
    var nombreArchivo = $(this).val().split('\\');
    $("#nameArchivo").val(nombreArchivo[nombreArchivo.length - 1]);
});

$('#IdRegiones').select2({
    placeholder: i18n.t("ph_sel_region"),
    allowClear: true
});


// Limpiamos los errores
function limpiarErrores() {
    $('.form-group input').each(function () {
        $(this).keyup(function () {
            $(this).emptyValidation();
            $(this).click(function () {
                $(this).emptyValidation();
            });
        });

    });

    $('#btnExaminar').click(function () {
        $('#IdInputExaminar').emptyValidation();
    });

    $('#IdRegioness').click(function () {
        $('#IdRegiones').emptyValidation();

    });

    $('#idCheck').click(function () {
        $('#IdCheckPolitica').emptyValidation()
    });
};

limpiarErrores();

//Limpiamos los inputs
function LimpiarFormulario() {
    $('#formulario')[0].reset();
    $('#IdRegiones').val(null).trigger('change');
    grecaptcha.reset();
};

// Enviar Formularios
$('#idEnviarForm').click(function () {

    var Name, Surname, IdRegiones, Telephone, Email, nameArchivo
    ///////validaciones///////////
    // Nombre
    if ($('#Name').val().trim().length < 2) {
        $('#Name').addError(i18n.t("errNombre"))
        $('#Name').focus();
        return false
    }
    Name = $('#Name').val().trim();
    // Apellidos
    if ($('#Surname').val().trim().length < 1) {
        //i18n.t("nombre")
        $('#Surname').addError(i18n.t("errApellido"))
        $('#Surname').focus();
        return false
    }
    Surname = $('#Surname').val().trim();
    //Regiones
    if ($('#IdRegiones').val().length < 1) {
        $('#IdRegiones').addError(i18n.t("errRegion"))
        $('#IdRegiones').focus();
        return false
    }
    IdRegiones = $('#IdRegiones').val();
    // Telefono
    if (!/^([0-9]+){9}$/.test($('#Telephone').val())) {
        $('#Telephone').addError(i18n.t("errTelefono"));
        $('#Telephone').focus();
        return false
    }
    Telephone = $('#Telephone').val().trim();
    //Email
    if (!/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/.test($('#Email').val())){
        $('#Email').addError(i18n.t("errEmail"));
        $('#Email').focus();
        return false
    }
    Email = $('#Email').val().trim();

    // que viene archivo
    var file = $("#archivo").get(0).files[0];
    if (!file) {
        $('#IdInputExaminar').addError(i18n.t("errArchivo"));
        return false
    }// tamaño archivo

    var namearchivo = file.name.split('.')
    var extension = namearchivo[namearchivo.length - 1]
    var extensiones = ["doc", "docx", "pdf"]

    //nombre del archivo
    if (extensiones.indexOf(extension) == -1) {
        $('#IdInputExaminar').addError(i18n.t("errArchivo"));
        return false
    }// tamaño archivo
    if (file.size > 5000000) {
        $('#IdInputExaminar').addError(i18n.t("errArchivoTamaño"));
        return false
    }
    // check
    if (!$('#idCheck').is(':checked')) {
        $('#IdCheckPolitica').addError(i18n.t("errPolitica"));
        $('#idCheck').focus();
        return false
    }
    //captcha
    
    if ($('#g-recaptcha-response').val()=='') {
        $('#captcha').addError('Comprueba que no eres un robot');
       
        return false
    }
    
    $('#spiner').Spinner();
    var formData = new FormData();
    formData.append("Name", Name);
    formData.append("Surname", Surname);
    formData.append("Regiones", IdRegiones);
    formData.append("Telephone", Telephone);
    formData.append("Email", Email);
    formData.append("Email", Email);
    formData.append("archivo", $("#archivo").get(0).files[0]);
    formData.append("g-recaptcha-response", $('#g-recaptcha-response').val());


    $.ajax({
        async: true,
        url: '/portalcandidato/Candidate/Create',
        type: 'POST',
        contentType: false,
        data: formData,
        processData: false,
        cache: false,
        success: function (data) {
         
            if (data == 'OK') {
                $('#AlertOK').show()
                $('#AlertKO').hide()
               
            }
            else {
                $('#AlertKO').show()
                $('#AlertOK').hide()
                
            }
            LimpiarFormulario();
            limpiarErrores();
            $('#spiner').Spinner(false);
            $('#miModal').modal()
          

        }
    });

    // $('#formulario').submit();
    //

});


