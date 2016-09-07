$(document)
    .ready(function() {
        $('#beerForm')
            .validate({
                rules: {
                    //Name: { required: true },
                    //ABV: { required: true, number: true, range: [0, 100] },
                    //IBU: { required: false, number: true },
                    //ReleaseDate: { required: true, date: true },
                    //Description: { required: true },
                    //ImgPath: { required: false, url: true },
                    StyleId: { required: '#existingStyleRadio:checked' },
                    StyleName: { required: '#newStyleRadio:checked' },
                    StyleDescription: { required: '#newStyleRadio:checked' },
                    SeriesId: { required: '#existingSeriesRadio:checked' },
                    SeriesName: { required: '#newSeriesRadio:checked' },
                    SeriesDescription: { required: '#newSeriesRadio:checked' },
                    CollabId: { required: '#existingCollabRadio:checked' },
                    CollabName: { required: '#newCollabRadio:checked' },
                    CollabDescription: { required: '#newCollabRadio:checked' },
                    CollabStreetAddress: { required: '#newCollabRadio:checked' },
                    CollabCity: { required: '#newCollabRadio:checked' },
                    CollabState: { required: '#newCollabRadio:checked' },
                    CollabZip: {
                        required: '#newCollabRadio:checked',
                        digits: true,
                        minlength: 5,
                        maxlength: 5
                    },
                    CollabWebsite: { required: '#newCollabRadio:checked' }
                },
                messages: {
                    //Name: 'Enter a name',
                    //ABV: {
                    //    required: 'Enter an ABV',
                    //    number: 'Enter only numbers',
                    //    range: 'ABV must be between 0 and 100'
                    //},
                    //IBU: {
                    //    number: 'Enter a valid number'
                    //},
                    //ReleaseDate: {
                    //    required: 'Enter a release date',
                    //    date: 'Enter a valid date'
                    //},
                    //Description: 'Enter a description',
                    //ImgPath: {
                    //    url: 'Enter a valid URL'
                    //},
                    StyleId: 'Choose a style',
                    StyleName: 'Enter a name',
                    StyleDescription: 'Enter a description',
                    SeriesId: 'Choose a series',
                    SeriesName: 'Enter a name',
                    SeriesDescription: 'Enter a description',
                    CollabId: 'Choose a collaborator',
                    CollabName: 'Enter a name',
                    CollabDescription: 'Enter a description',
                    CollabStreetAddress: 'Enter a street address',
                    CollabCity: 'Enter a city',
                    CollabState: 'Enter a state',
                    CollabZip: {
                        required: 'Enter a zip code',
                        digits: 'Enter only numbers',
                        minlength: 'Enter a 5-digit zip code',
                        maxlength: 'Enter a 5-digit zip code'
                    },
                    CollabWebsite: 'Enter a website URL'
                }
            });
    });