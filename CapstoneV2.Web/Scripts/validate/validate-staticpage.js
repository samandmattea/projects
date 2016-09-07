$(document)
    .ready(function () {
        $('#pageForm')
            .validate({
                rules: {
                    Title: { required: true },
                    Body: { required: true }
                },
                messages: {
                    Title: 'Enter a title',
                    Body: 'Enter body content for the page'
                }
            });
    });