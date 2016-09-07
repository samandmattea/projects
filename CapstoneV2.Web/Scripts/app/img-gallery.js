$(document)
    .ready(function () {
        var $fieldCount = 0;
        $('#addImg').on('click', function () {
            
            var $node = '<p><label for="[' + $fieldCount + '].imageFiles">Image ' + ($fieldCount + 1) + ': </label><input type="text" name="[' + $fieldCount + '].captions" id="[' + $fieldCount + '].captions" class="form-control" placeholder="Image Caption"/><input type="file" name="[' + $fieldCount + '].imageFiles" id="[' + $fieldCount + '].imageFiles"/></p>';

            $('#imgUploaders').append($node);
            $fieldCount++;
        });
        
        //TODO: Make 'remove image' work from image uploader
        //$('form').on('click', '.removeImg', function () {
        //    $(this).parent().remove();
        //});

        //Add this next line into the element to make the removal icon... or something
        // <span class="removeImg"><span class="glyphicon glyphicon-remove-circle"></span></span>
});