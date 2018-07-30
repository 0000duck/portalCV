$(document).ready(function () {

    //Cors enabled
    $.support.cors = true;

    //config toastr
    toastr.options.positionClass = "toast-top-full-width";

    //config tooltip
    $('[data-toggle="tooltip"]').tooltip();


});



// open select2 dropdown on focus
//$(document).on('focus', '.select2-selection--single', function (e) {
//    var select2_open;
//    select2_open = $(this).parent().parent().siblings('select');
//    select2_open.select2('open');
//    if (/rv:11.0/i.test(navigator.userAgent)) {
//        $(document).on('blur', '.select2-search__field', function (e) {
//            select2_open.select2('close');
//        });
//    }
//});

// fix for ie11


function mostrarAviso(text, type) {

    if (type != "success" && type != "warning" && type != "error") type = "warning";

    switch (type) {
        case "success": toastr.success(text); break;
        case "error": toastr.error(text); break;
        default: toastr.warning(text);
    }
}
