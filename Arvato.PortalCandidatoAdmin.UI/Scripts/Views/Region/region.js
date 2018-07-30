// $('#tabla').DataTable();



// Limpiamos los inputs 
$('.form-group input').each(function () {
    $(this).keyup(function () {
        $(this).emptyValidation()
        $('#idError').text("");
    });
});


$('#IdGuardarRegion').click(function () {
  
    // Validamos los campor a guardar:


    if ($('#IdNombreRegion').val().trim().length < 2) {
        $('#IdNombreRegion').addError(i18n.t("errNombre"));//i18n.t("errNombre")
        $('#IdNombreRegion').focus();
        return false;
    }
    if (!/^((\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+);?)+$/.test($('#IdEmailRegion').val())) {
        $('#IdEmailRegion').addError(i18n.t("error_emails"));
        $('#IdEmailRegion').focus();
        return false;
    }




    $('#formulario').submit();






});

