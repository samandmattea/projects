$('#blogForm')
    .validate({
        rules: {
            'Blog.Title': { required: true },
            'Blog.Body': { required: true }
        },
        messages: {
            'Blog.Title': 'Enter a title',
            'Blog.Body': 'Enter body content for the blog post'
        }
    });