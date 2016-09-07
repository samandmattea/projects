$(document)
    .ready(function() {
        $('#contactForm')
            .validate({
                rules: {
                    Name: { required: true },
                    Email: { required: true, email: true },
                    Message: { required: true }
                },
                messages: {
                    Name: 'Please enter your name',
                    Email: {
                        required: 'Please enter an email so we can get back to you',
                        email: 'Please enter a valid email address'
                    },
                    Message: 'Please enter the message you would like to send to us'
                }
            });
    });