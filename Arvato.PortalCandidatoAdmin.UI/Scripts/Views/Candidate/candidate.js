

function VerCV(e) {

        $('embed').attr("type", 'application/pdf')
        // $('embed').attr("type", 'application/vnd.openxmlformats-officedocument.wordprocessingml.document')
       // $('embed').attr("src", "/Candidate/Descarga/" + e.id + "#toolbar=0&navpanes=0&scrollbar=0")
        $('iframe').attr("src", "/portalCandidatoAdmin/Candidate/Descarga/" + e.id + "#toolbar=0&navpanes=0&scrollbar=0")

     
        $("#ModalPDF").modal();
        $('#eye_'+e.id).html("<button class='btn btn-link'><i  class='fa fa-eye fa-2x'></i></button>");
}


function filtrarTablas() {
    var regiones = '';
    $('#IdRegiones option:selected').each(function () {
        if (regiones != "") {
            regiones += "|";
        }
        regiones += $(this).text();
    });


    var tabla = $('#tablaCandidate').dataTable();
    tabla.fnFilter(regiones, 3, true, true)
}



$('#tablaCandidate').dataTable(
    {

    "pagingType": "full_numbers"

}
    );

$('#IdRegiones').select2({
    placeholder: "",
    allowClear: true

});


$('#IdRegiones').on('select2:select', function (e) {
    filtrarTablas();
});

$('#IdRegiones').on('select2:unselect', function (e) {
    filtrarTablas();
});

$('#idExcel').click(function () {

    exportarExcel("candidatos.csv");

//    $U.exportarCSV($('#tablaCandidate'), "Candidatos")
    })
    


function exportarExcel(nombrefichero) {
            //delimitador csv
        var colDelim = '";"'
        var rowDelim = '"\r\n"';
    var csv = [];
    var rows = document.querySelectorAll("table tr");

    for (var i = 0; i < rows.length; i++) {
        var row = [], cols = rows[i].querySelectorAll("td, th");

        for (var j = 0; j < cols.length-3; j++) {
            row.push(cols[j].innerText);
        }
       
        csv.push(row.join(colDelim));
    }

    // Download CSV file
    downloadCSV(csv.join(rowDelim), nombrefichero);

}

function downloadCSV(csv, filename) {
    var csvFile;
    var downloadLink;

    // CSV file
    csvFile = new Blob([csv], { type: 'text/csv;charset=utf-8' });


    //si es internet explorer
    if (window.navigator && window.navigator.msSaveOrOpenBlob) {
        window.navigator.msSaveOrOpenBlob(csvFile, filename);
    } else {
        // Download link
        downloadLink = document.createElement("a");
        // File name
        downloadLink.download = filename;
        // Create a link to the file
        downloadLink.href = window.URL.createObjectURL(csvFile);
        // Hide download link
        downloadLink.style.display = "none";
        // Add the link to DOM
        document.body.appendChild(downloadLink);
        // Click download link
        downloadLink.click();
    }
}
