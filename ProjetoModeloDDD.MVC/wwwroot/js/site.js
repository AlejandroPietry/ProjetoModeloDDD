// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('#AddObject').click(function () {
    var i = $(".thingRow").length;
    $.ajax({
        url: 'Add/' + i,
        method: 'GET',
        success: function (data) {
            $('#Table > tbody').append(data);
        },
        error: function (a, b, c) {
            console.log(a, b, c);
        }
    });
});