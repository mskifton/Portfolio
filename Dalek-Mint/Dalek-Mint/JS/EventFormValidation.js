
    $(document).ready(function () {
        //checking if name is empty
        $('#eventName').on('keyup', function (event) {
            if ($('#eventName').val() == "") {
                $('#eNameError').text("The Name is required.");
            }
            else {
                $('#eNameError').text("");
            }

        });
    //checking if date is empty
    $('#eventDate').on('keyup', function (event) {
            if ($('#eventDate').val() == "") {
        $('#eDateError').text("The Date is required.");
    }
            else {
        $('#eDateError').text("");
    }


    });
//Checking if description is emtpy
        $('#eventDesc').on('keyup', function (event) {
            if ($('#eventDesc').val() == "") {
        $('#eDescError').text("The Description is required.");
    }
            else {
        $('#eDescError').text("");
    }


        });
//Checking if address is empty
        $('#eventAddress').on('keyup', function (event) {
            if ($('#eventAddress').val() == "") {
        $('#eAddressError').text("The Address is required.");
    }
            else {
        $('#eAddressError').text("");
    }


        });
//Checking if city is empty
        $('#eventCity').on('keyup', function (event) {
            if ($('#eventCity').val() == "") {
        $('#eCityError').text("The City is required.");
    }
            else {
        $('#eCityError').text("");
    }


        });

//Checking that state field is only 2 letter abbreviation
        $('#eventState').on('keyup', function (event) {
            var regEx = new RegExp("^[a-zA-Z]{2}$");
            if ($('#eventState').val() == "") {
        $('#eStateError').text("The State is required.");
    }
            else if (regEx.test($('#eventState').val()) == false) {
        $('#eStateError').text("Enter the two letter State Abbreviation.");
    }
            else {
        $('#eStateError').text("");
    }


        });
//Checking if zipcode is only 5 digits long AND only digits
        $('#eventZip').on('keyup', function (event) {
            var reEx = new RegExp("^[0-9]{5}$");
            if ($('#eventZip').val() == "") {
        $('#eZipError').text("The Zip Code is required.");
    }
            else if (reEx.test($('#eventZip').val()) == false) {
        $('#eZipError').text("The 5 Digit Zip Code Only.");
    }
            else {
        $('#eZipError').text("");
    }

        });

        $('#eventContact').on('keyup', function (event) {
            if ($('#eventContact').val() == "") {
        $('#eContactError').text("The Contact is required.");
    }
            else {
        $('#eContactError').text("");
    }

        });

        // Shows the naem of the uploaded file
        $('#fileUpload').on('change', function () {
            //get the file name
            var fileName = $(this).val();
            //replace the "Choose a file" label
            $(this).next('.custom-file-label').html(fileName);
        })

    });
