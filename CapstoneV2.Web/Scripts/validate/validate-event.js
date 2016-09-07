$(document)
    .ready(function () {
        $('#eventForm')
            .validate({
                rules: {
                    'Event.Name': { required: true },
                    'Event.Description': { required: true },
                    'Event.Venue': { required: true },
                    'Event.StartDate': { required: true, date: true },
                    'Event.EndDate': {required: false, date: true}
                    //TODO: Add validation for start/end time
                },
                messages: {
                    'Event.Name': 'Enter a name',
                    'Event.Description': 'Enter and event description',
                    'Event.Venue': 'Choose a venue',
                    'Event.StartDate': {
                        required: 'Enter a start date',
                        date: 'Enter a valid date'
                    },
                    'Event.EndDate': {date:'Enter a valid date'}
                }
            });
    });