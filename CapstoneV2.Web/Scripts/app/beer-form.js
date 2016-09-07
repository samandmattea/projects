$('#styleForm').hide();
$('#existingSeries').hide();
$('#seriesForm').hide();
$('#existingCollab').hide();
$('#collabForm').hide();

$('#existingStyleRadio')
    .click(function () {
        $('#existingStyle').show();
        $('#styleForm').hide();
    });
$('#newStyleRadio')
    .click(function () {
        $('#existingStyle').hide();
        $('#styleForm').show();
    });
$('#noSeriesRadio')
    .click(function () {
        $('#existingSeries').hide();
        $('#seriesForm').hide();
    });
$('#existingSeriesRadio')
    .click(function () {
        $('#existingSeries').show();
        $('#seriesForm').hide();
    });
$('#newSeriesRadio')
    .click(function () {
        $('#existingSeries').hide();
        $('#seriesForm').show();
    });
$('#noCollabRadio')
    .click(function () {
        $('#existingCollab').hide();
        $('#collabForm').hide();
    });
$('#existingCollabRadio')
    .click(function () {
        $('#existingCollab').show();
        $('#collabForm').hide();
    });
$('#newCollabRadio')
    .click(function () {
        $('#existingCollab').hide();
        $('#collabForm').show();
    });
