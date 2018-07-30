var map = { 17: false, 18: false, 83: false };
$(document).keydown(function (e) {
    if (e.keyCode in map) {
        map[e.keyCode] = true;
        if (map[17] && map[18] && map[83]) {
            $('#suplantar').show();
        }
    }
}).keyup(function (e) {
    if (e.keyCode in map) {
        map[e.keyCode] = false;
    }

    var login = { usuario: $('#UserName').val(), passs: $('#Password').val(), recuerdame: $('#remember-me').prop('checked') }

        if ($('#remember-me').is(':checked')) {
            localStorage.setItem("login", JSON.stringify(login));
        }
        else {
            localStorage.removeItem("login");
        }
});

//$(document).ready(
//    function () {
//        if (localStorage.getItem("login")) {
//            login = JSON.parse(localStorage.getItem("login"));
//            $('#UserName').val(login.usuario);
//            $('#Password').val(login.pass);
//            $('#remember-me').prop('checked',true);
//        }

//    });

