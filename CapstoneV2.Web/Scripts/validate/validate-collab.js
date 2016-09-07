$(document)
    .ready(function () {
        $('#collabForm')
            .validate({
                rules: {
                    Name: { required: true },
                    Description: { required: true }
                },
                messages: {
                    Name: 'Enter a name',
                    Description: 'Enter a description'
                }
            });
    });