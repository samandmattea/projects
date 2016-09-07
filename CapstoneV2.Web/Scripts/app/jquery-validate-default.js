$.validator.setDefaults({
    highlight: function (element) {
        $(element).closest('.form-group').removeClass('success').addClass('error');
    },
    unhighlight: function (element) {
        $(element).closest('.form-group').removeClass('error').addClass('success');
    },
    errorElement: 'span',
    errorClass: 'help-block',
    errorPlacement: function (error, element) {
        if (element.parent('.input-group').length) {
            error.insertAfter(element.parent());
        } else {
            error.insertAfter(element);
        }
    }
});

