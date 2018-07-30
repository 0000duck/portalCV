//var day_data = [
//       { "elapsed": "1", "monito": 34, "pdi": 25 },
//       { "elapsed": "2", "monito": 24, "pdi": 13 },
//       { "elapsed": "3", "monito": 3, "pdi": 18 },
//       { "elapsed": "4", "monito": 12, "pdi": 29 },
//       { "elapsed": "5", "monito": 13, "pdi": 32 },
//       { "elapsed": "6", "monito": 22, "pdi": 50 },
//       { "elapsed": "7", "monito": 5, "pdi": 2 },
//       { "elapsed": "8", "monito": 26, "pdi": 3 },
//       { "elapsed": "9", "monito": 12, "pdi": 1 },
//       { "elapsed": "10", "monito": 19, "pdi": 12 },
//       { "elapsed": "11", "monito": 34, "pdi": 25 },
//       { "elapsed": "12", "monito": 24, "pdi": 13 },
//       { "elapsed": "13", "monito": 3, "pdi": 18 },
//       { "elapsed": "14", "monito": 12, "pdi": 29 },
//       { "elapsed": "15", "monito": 13, "pdi": 32 },
//       { "elapsed": "16", "monito": 22, "pdi": 50 },
//       { "elapsed": "17", "monito": 5, "pdi": 2 },
//       { "elapsed": "18", "monito": 26, "pdi": 3 },
//       { "elapsed": "19", "monito": 12, "pdi": 1 },
//       { "elapsed": "20", "monito": 19, "pdi": 12 },
//       { "elapsed": "21", "monito": 34, "pdi": 25 },
//       { "elapsed": "22", "monito": 24, "pdi": 13 },
//       { "elapsed": "23", "monito": 3, "pdi": 18 },
//       { "elapsed": "24", "monito": 12, "pdi": 29 },
//       { "elapsed": "25", "monito": 13, "pdi": 32 },
//       { "elapsed": "26", "monito": 22, "pdi": 50 },
//       { "elapsed": "27", "monito": 5, "pdi": 2 },
//       { "elapsed": "28", "monito": 26, "pdi": 3 },
//       { "elapsed": "29", "monito": 12, "pdi": 1 },
//       { "elapsed": "30", "monito": 19, "pdi": 12 }
//];



//var nReloads = 0;
//function data(offset) {
//    var ret = [];
//    if (offset % 2 == 0) {
//        for (var x = 0; x <= 360; x += 10) {
//            var v = (offset + x) % 360;
//            ret.push({
//                x: x,
//                z: Math.cos(Math.PI * v / 180).toFixed(4)
//            });
//        }
//    }
//    else {

//        for (var x = 0; x <= 360; x += 10) {
//            var v = (offset + x) % 360;
//            ret.push({
//                x: x,
//                y: Math.sin(Math.PI * v / 180).toFixed(4),
//            });
//        }
//    }
//    return ret;
//}
//var graph = Morris.Line({
//    element: 'myfirstchart2',
//    data: data(0),
//    xkey: 'x',
//    ykeys: ['y', 'z'],
//    labels: ['sin()', 'cos()'],
//    parseTime: false,
//    ymin: -1.0,
//    ymax: 1.0,
//    hideHover: true
//});
//function update() {
//    nReloads++;
//    graph.setData(data(5 * nReloads));
//}
//setInterval(update, 500);








//Morris.Line({
//    element: 'myfirstchart',
//    data: day_data,
//    xkey: 'elapsed',
//    ykeys: ['monito', 'pdi'],
//    labels: ['Monitorizaciones', 'PDI'],
//    parseTime: false
//}).on('click', function (i, row) {
//    alert(i + ' ' + row);
//});;

//new Morris.Donut({
//    element: 'donut',
//    data: [
//      { label: "Monitos Realizadas", value: 80 },
//      { label: "Monitos Restantes", value: 20 },
//    ]
//});


//new Morris.Line({
//    // ID of the element in which to draw the chart.
//    element: 'myfirstchart2',
//    // Chart data records -- each entry in this array corresponds to a point on
//    // the chart.
//    data: [
//      { year: '2008', value: 20 },
//      { year: '2009', value: 10 },
//      { year: '2010', value: 5 },
//      { year: '2011', value: 5 },
//      { year: '2012', value: 20 }
//    ],
//    // The name of the data record attribute that contains x-values.
//    xkey: 'year',
//    // A list of names of data record attributes that contain y-values.
//    ykeys: ['value'],
//    // Labels for the ykeys -- will be displayed when you hover over the
//    // chart.
//    labels: ['Value']
//});
