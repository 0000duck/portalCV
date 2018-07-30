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
});