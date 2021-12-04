function datatable() {
    $("#example1").DataTable({
        "responsive": true, "lengthChange": false, "autoWidth": false,
        "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
    }).buttons().container().appendTo('#example1_wrapper .col-md-6:eq(0)');
    $('#example2').DataTable({
        "paging": true,
        "lengthChange": false,
        "searching": false,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "responsive": true,
    });
};

function SaveSub_Category(form) {

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
                    //if (typeof activatejQueryTable !== 'undefined' && $.isFunction(activatejQueryTable))
                    //    activatejQueryTable();
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
function EditSave(form) {
    debugger;
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        var AjaxConfig = {
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            success: function (response) {
                if (response.success) {
                    $("#firstTab").html(response.html);
                    refreshAddNewTab($(form).attr('data-restUrl'), true);
                    $.notify(response.message, "success");

                }
                else {
                    $.notify(response.message, "error");
                }
            }
        }
        if ($(form).attr('enctype') == "multipart/form-data") {
            AjaxConfig["contentType"] = false;
            AjaxConfig["processData"] = false;
        }

        $.ajax(AjaxConfig);
    }
    return false;
}

function refreshAddNewTab(resetUrl, showViewTab) {

    $.ajax({

        type: 'GET',
        url: resetUrl,
        success: function (response) {

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
            $("#ThTab").html(response);
            $('ul.nav.nav-tabs a:eq(2)').tab('show');

        }
    })
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
               
                }
                else {
                    $.notify(response.message, "error");
                }
            }
        });
    }
}

$("#cancelbtn").click(function () {

})


////////////////////////////////////////// End Sub Category


////////////////////////////////////////// Start Country


$('#modalbtn').click(function (event) {
    $.ajax({
        type: 'GET',
        url: $(this).data('url'),
        success: function (response) {
            $('#ShowModel').html(response);
            $('#ShowModel').find('.modal').modal('show');
        }
    });

})


function AddCountrySuccess(data) {
    if (data.success) {

        $("#ViewallCountry").html(data.html);
        $('#txtfiled').val('');
        this.reset();
        $("#myModal").modal('hide');
        $.notify(data.message, "success");
        datatable();
    }
}
function AddCountryFailure(err) {
    console.log(err);
    $.notify(err.message, "error");
}

function CountryEdit(url) {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {
            $('#ShowModel').html(response);
            $('#ShowModel').find('.modal').modal('show');
        }
    });
}

function EditCountrySuccess(data) {

    if (data.success) {
        $("#ViewallCountry").html(data.html);
        $('#txtfiled').val('');
        this.reset();
        $("#myModal").modal('hide');
        $.notify(data.message, "success");
        datatable();
    }
}

function EditCountryFailure(err) {
    $.notify(err.message, "error");
}

function CountryDelete(url) {
  
    if (confirm('Are you sure to delete this record ?') == true) {
      
        $.ajax({
            type: 'POST',
            url: url,
            success: function (response) {
                if (response.success) {
                    console.log(response.html);
                    $("#ViewallCountry").html(response.html);
                    $.notify(response.message, "success");
                    datatable();
                }
                else {
                    $.notify(response.message, "error");
                }
            }
        });
    }
}



////////////////////////////////////////// End Country


////////////////////////////////////////// Start 