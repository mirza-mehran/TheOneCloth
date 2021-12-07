

function ShowImagePreview(imageUploader, previewImage) {
    if (imageUploader.files && imageUploader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUploader.files[0]);
    }
}

$("#changeimg").change(function () {
    var element = this;
    var formData = new FormData();
    var totalFiles = element.files.length;

    for (var i = 0; i < totalFiles; i++) {
        var file = element.files[i];
        formData.append("Photo", file);
    }

    $.ajax({
        type: 'POST',
        url: '/Shared/UploadImage',
        dataType: 'json',
        data: formData,
        contentType: false,
        processData: false
    }).done(function (response) {

        if (response.Success) {
            $("#ImageURL").val(response.ImageURL);
            $("#imageshow").attr("src", response.ImageURL);
        }

    }).fail(function (XMLHttpRequest, textStatus, errorThrown) {
        alert("FAIL");
    })

})

$(function () {
    $("#loaderbody").hide();
    $(document).bind('ajaxStart', function () {
        $("#loaderbody").show();
    }).bind('ajaxStop', function () {
        $("#loaderbody").hide();
    });
});

$("#savebtn").click(function () {
    var url = $(this).data('request-url');
    $.ajax({
        type: 'POST',
        url: url,
        data: $("#createCategory").serialize()
    }).done(function (response) {

        $("#createCategory").each(function () {
            this.reset();
            $("#imageshow").attr("src", " ");
        });

    }).fail(function (XMLHttpRequest, textStatus, errorThrown) {
        swal({
            title: "Warning",
            text: "Please enter all required fields",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        });
    });

})

function jQueryAjaxPost(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        var ajaxConfig = {                                                  
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            success: function (response) {
                if (response.success) {
                    $("#firstTab").html(response.html);
                    refreshAddNewTab($(form).attr('data-restUrl'), true);
                    $.notify(response.message, "success");
                    if (typeof activatejQueryTable !== 'undefined' && $.isFunction(activatejQueryTable))
                        activatejQueryTable();
                }
                else {
                    $.notify(response.message, "error");
                }
            }
        }
        if ($(form).attr('enctype') == "multipart/form-data") {
            ajaxConfig["contentType"] = false;
            ajaxConfig["processData"] = false;
        }
        $.ajax(ajaxConfig);

    }
    return false;
}

function refreshAddNewTab(resetUrl, showViewTab) {
    $.ajax({
        type: 'GET',
        url: resetUrl,
        success: function (response) {
            $("#secondTab").html(response);
            $('ul.nav.nav-tabs a:eq(1)').html('Add New');
            if (showViewTab)
                $('ul.nav.nav-tabs a:eq(0)').tab('show');
        }
    });
}

function Edit(url) {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {
            $("#secondTab").html(response);
            $('ul.nav.nav-tabs a:eq(1)').html('Edit');
            $('ul.nav.nav-tabs a:eq(1)').tab('show');
        }
    });
}

function Delete(url) {
    if (confirm('Are you sure to delete this record ?') == true) {
        $.ajax({
            type: 'POST',
            url: url,
            success: function (response) {
                if (response.success) {
                    $("#firstTab").html(response.html);
                    $.notify(response.message, "warn");
                    if (typeof activatejQueryTable !== 'undefined' && $.isFunction(activatejQueryTable))
                        activatejQueryTable();
                }
                else {
                    $.notify(response.message, "error");
                }
            }

        });

    }
}