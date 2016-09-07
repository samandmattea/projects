$(document)
    .ready(function() {
        $('#venueForm')
            .validate({
                rules: {
                    Name: { required: true },
                    StreetAddress: { required: true },
                    City: { required: true },
                    State: { required: true },
                    Zip: { required: true, digits: true, minlength: 5, maxlength: 5 },
                    Phone: { required: false, phoneUS: true },
                    Email: { required: false, email: true }
                },
                messages: {
                    Name: 'Enter the name of the venue',
                    StreetAddress: 'Enter a street address',
                    City: 'Enter a city',
                    State: 'Enter a state',
                    Zip: {
                        required: 'Enter a zip code',
                        digits: 'Only enter numbers',
                        minlength: 'Enter a 5-digit zip code',
                        maxlength: 'Enter a 5-digit zip code'
                    },
                    Phone: {
                        phoneUS: 'Enter a valid phone number'
                    },
                    Email: {
                        email: 'Enter a valid email address'
                    }
                }
            });
    });