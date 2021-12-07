
    $(document).ready(function () {
        productList();
    });

function productList() {
    // Call Web API to get a list of Product
    $.ajax({
        url: 'http://localhost:49562/api/categories',
        type: 'GET',
        dataType: 'json',
        success: function (products) {
            console.log(products);
            productListSuccess(products);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function productListSuccess(products) {
    $.ajax({
        type: 'POST',
        url: '/Main_Category/ViewAll',
        data: JSON.stringify(products),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            console.log(data);
            data = JSON.parse(data);
            console.log(data);
        }
    });
}
