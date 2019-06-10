$(document).ready(function () {

    $('#adClubName').on('keyup', function (event) {
        if ($('#adClubName').val() == "") {
            $('#adNameError').text("The Name is required.");
        }
        else {
            $('#adNameError').text("");
        }

    });
    $('#adClubDesc').on('keyup', function (event) {
        if ($('#adClubDesc').val() == "") {
            $('#adClubDescError').text("The Description is required.");
        }
        else {
            $('#adClubDescError').text("");
        }

    });

});


