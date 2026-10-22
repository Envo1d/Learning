// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#add").click(function () {
    event.preventDefault();
    var $combo = $('#select');
    var value = $('#tag').val();
    let f = false;
    for (let i = 0; i < document.getElementById("select").length; ++i) {
        if (document.getElementById("select").options[i].value == value) {
            f = true;
            break;
        }
    }
    if (!f) {
        var $option = $('<option>').html(value);
        $combo.append($option);
        $('#tag').val('');
    }
});