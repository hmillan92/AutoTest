$(document).ready(function () {
    $("#BusinessEntityID").change(function () {
        $("#SubCategoryID").empty();
        $("#SubCategoryID").append('<option value="0">[Select a SubCategory...]</option>');
        $.ajax({
            type: 'POST',
            url: Url,
            dataType: 'json',
            data: { businessEntityID: $("#BusinessEntityID").val() },
            success: function (data) {
                $.each(data, function (i, data) {
                    $("#SubCategoryID").append('<option value="'
                        + data.SubCategoryID + '">'
                        + data.SubCategoryName + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed to retrieve SubCategories.' + ex);
            }
        });
        return false;
    })
});