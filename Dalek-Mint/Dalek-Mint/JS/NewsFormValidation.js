$(document).ready(function () {
    $('#newsTitle').on('keyup', function (event) {
        if ($('#newsTitle').val() == "") {
            $('#newsTitleErr').text("The Title is required.");
        }
        else {
            $('#newsTitleErr').text("");
        }

    });
    $('#newsDesc').on('keyup', function (event) {
        if ($('#newsDesc').val() == "") {
            $('#newsDescErr').text("The Description is required.");
        }
        else {
            $('#newsDescErr').text("");
        }

    });

    $('#newsArt').on('keyup', function (event) {
        if ($('#newsArt').val() == "") {
            $('#newsArtErr').text("The Article is required.");
        }
        else {
            $('#newsArtErr').text("");
        }

    });
    // Contact input field validation. Checks to see if it is empty.
    $('#eventContact').on('keyup', function (event) {
        if ($('#eventContact').val() == "") {
            $('#eContactError').text("The Contact is required.");
        }
        else {
            $('#eContactError').text("");
        }
    });
});
