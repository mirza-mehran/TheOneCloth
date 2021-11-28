
function jQueryAjaxPost() {
    
    $.validator.unobtrusive.parse(form);
    if ($(form).valid())
    {
        var ajaxConfig = {

            type: 'POST',
            url: form.action,
            data: new FormData(form),
            success: function (response) {
                $("#home").html(response);
            },
            error: function () {
                swal({
                    title: "Warning",
                    text: "Please enter all required fields",
                    icon: "warning",
                    buttons: true,
                    dangerMode: true,
                });
            }
        }
        if ($(form).attr('enctype') == "multipart/form-data") {
            ajaxConfig["contentType"] = false;
            ajaxConfig["processData"] = false;
        }
        $.ajax(ajaxConfig);

    }
}
