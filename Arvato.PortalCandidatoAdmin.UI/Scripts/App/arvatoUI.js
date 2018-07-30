jQuery.fn.Spinner = function (activo) {
    if (activo != undefined && !activo) {
        $(this).find(".spinner").remove();
    }
    else {
        $(this).prepend("<div class='spinner'>");
    }

}

jQuery.fn.emptyValidation = function () {
    var input = $(this);

    input.parent().find('.form-control-feedback').remove();
    input.parent().find('.infoEstado').remove();
    input.removeClass('valid')
        .removeClass('error');

    if (input.is("select")) {
        input = input.next('.select2');
        input.find('.select2-selection').removeClass('select2error');
    }
}



jQuery.fn.addInfo = function (msg) {
    var input = $(this);
    input.emptyValidation();
    var spanInfo = $('<span class="infoEstado" aria-hidden="true">' + msg + '</span>');
    input.after(spanInfo);
}


jQuery.fn.disabled = function () {
    var input = $(this);
    input.emptyValidation();
    input.parent().find('label').addClass('disabled');
    input.prop({
        disabled: 'disabled'
    });
}

jQuery.fn.enabled = function () {
    var input = $(this);
    input.emptyValidation();
    input.parent().find('label').removeClass('disabled');
    input.prop({
        disabled: 'false'
    });
}

jQuery.fn.addOk = function () {
    var input = $(this);
    input.emptyValidation();
    input.addClass('valid');
}


jQuery.fn.addError = function (msg) {
    var input = $(this);
    if (input.is("select")) {
        input = input.next('.select2');
        input.emptyValidation();
        input.find('.select2-selection').addClass('select2error');
        var spanInfo = $('<span class="infoEstado error" aria-hidden="true">' + msg + '</span>');
        input.parent().append(spanInfo);
    }
    else if (input.is("textarea")) {
        input.emptyValidation();
        input.addClass('error');        
        var spanInfo = $('<span class="infoEstado error" aria-hidden="true">' + msg + '</span>');
        input.parent().append(spanInfo);
    }
    else {
        input.emptyValidation();
        input.addClass('error');
        var spanMarkQuestion = $('<span class="form-control-feedback error" aria-hidden="true">?</span>');
        input.after(spanMarkQuestion);
        var spanInfo = $('<span class="infoEstado error" aria-hidden="true">' + msg + '</span>');
        input.parent().append(spanInfo);
    }
};

jQuery(".form-control")
.on("focus", function () {
    // set background color on focus
    $(this).parent().find('i').addClass('focus');
})
    .on({
        mouseenter: function () {
            $(this).parent().find('i').addClass('focus');
        },
        mouseleave: function () {
            $(this).parent().find('i').removeClass('focus');
        }
    })
.on("blur", function () {
    // remove background color on blur
    $(this).parent().find('i').removeClass('focus');
});



jQuery('*[data-search="true"]')
.on("focus", function () {
    // set background color on focus
    $(this).css('background-image', 'none');
})
.on("blur", function () {
    // remove background color on blur
    $(this).css({
        'background-image': 'url(../../img/icons/icon-search.svg)',
        " background-repeat": "no-repeat"
    });
});
