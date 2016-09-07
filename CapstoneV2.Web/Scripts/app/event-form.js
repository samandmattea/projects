
//$('#DateStart').hide();
//$('#sdLabel').hide();
//$('#DateEnd').hide();
//$('#edLabel').hide();
$('#venueForm').hide();
$(document)
    .ready(function() {
        //$('#IsAllDay')
        //    .click(function () {
        //        $('#sdLabel').toggle();
        //        $('#DateStart').toggle();
        //        $('#edLabel').toggle();
        //        $('#DateEnd').toggle();
        //        $('#stLabel').toggle();
        //        $('#DateTimeStart').toggle();
        //        $('#etLabel').toggle();
        //        $('#DateTimeEnd').toggle();
        //    });
        $('#newVenueRadio')
            .click(function() {
                $('#venueForm').show();
                $('#VenueId').hide();
            });
        $('#existingVenueRadio').click(function() {
            $('#venueForm').hide();
            $('#VenueId').show();
        })
    });