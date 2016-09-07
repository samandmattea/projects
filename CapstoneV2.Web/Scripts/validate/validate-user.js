$(document)
    .ready(function () {
        $('#userForm')
            .validate({
                rules: {
                    FirstName: { required: true },
                    LastName: { required: true },
                    Username: { required: true },
                    'Contact.Email': { required: true, email: true },
                    JobTitle: { required: true },
                    AccessLevel: { required: true },
                    Bio: { required: true }
                },
                messages: {
                    FirstName: 'Enter a first name',
                    LastName: 'Enter a last name',
                    Username: 'Enter a username',
                    'Contact.Email': {
                        required: 'Enter an email',
                        email: 'Enter a valid email address'
                    },
                    JobTitle: 'Enter a job title',
                    AccessLevel: 'Choose an access level',
                    Bio: 'Enter a user bio'
                }
            });
    });