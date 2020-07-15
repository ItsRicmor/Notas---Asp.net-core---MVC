$(document).ready(function () {

    $(".note-button-edit-card").click(function () {
        const card = $(this).parent().parent();
        const id = card.data("id");
        $.ajax({
            url: 'Home/LoadEditForm?id=' + id,
            type: 'GET',
            cache: false,
        }).done(function (result) {
            $('#FormNote').html(result);
        });
    });

    $(".note-button-delete-card").click(function () {
        const card = $(this).parent().parent();
        const id = card.data("id");
        const token = $("#_note_wall input").val();
        $.ajax({
            type: 'DELETE',
            url: `Home/DeleteAjax?id=${id}`,
            success: function (response) {
                if (response.ok) {
                    card.remove();
                    console.log('ELIMINADO');
                }
            },
            failure: function (response) {
                console.log('ERROR', response);
            }
        });
    });
})