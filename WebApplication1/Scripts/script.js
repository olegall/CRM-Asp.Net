function sendAjax(url, data, callback) {
    var params = JSON.stringify(data);
    $.ajax({
        type: 'POST',
        url: url,
        dataType: 'json',
        cache: false,
        contentType: 'application/json; charset=utf-8',
        data: params,
        success: function (data, status) {
            var response = data;
            if (data.d != undefined) response = data.d;
            if (callback) callback(response);
        },
        complete: function () {
        },
        beforeSend: function (xhr) {
        }
    });
}