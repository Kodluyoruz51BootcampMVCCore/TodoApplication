// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    
    $('#add-item-error').hide();
    $('#add-item-successful').hide();

    //TODO: JQUERY iptal edilecek
    
    $('#add-item-button').on('click', addItem);
    $('.done-checkbox').on('click', function (e) {
        markCompleted(e.target);
    });

});

function addItem() {
    
    var newTitle = $('#add-item-title').val();
    var success="Eklendi";

    $.post('/Todo/AddItem', { title: newTitle }, function () {
            
        $('#add-item-successful').text(success);
        $('#add-item-successful').show();
  
        window.setTimeout(function(){
            $('#add-item-successful').hide();
            location.reload(true);
            $('#add-item-title').val("");
        },1000);        
        
    })
        .fail(function (data) {
            if (data && data.responseJSON) {
                var firstError = data.responseJSON[Object.keys(data.responseJSON)[0]];
                $('#add-item-error').text(firstError);
                $('#add-item-error').show();
            }
        });

         
}

function markCompleted(checkbox) {
    checkbox.disabled = true;

    $.post('/Todo/MarkDone', { id: checkbox.name }, function () {
        var row = checkbox.parentElement.parentElement;
        $(row).addClass('done'); 
        location.reload();
    });
    //window.location.reload(); // Checkbox tiklandıktan sonra sayfa otomatık yenilenip true donen degeri göstermıyecek
}