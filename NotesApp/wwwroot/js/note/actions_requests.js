$(document).ready(function () {
    function deleteNote(id) {
        $.ajax({
            type: 'POST',
            url: `Notes/Delete/${id}`,
            success: function (response) {
                if (response.ok) {
                    $("div[data-id='" + id + "']").remove();
                }
            },
            failure: function (response) {
                console.log('ERROR', response);
            }
        });
    }
})