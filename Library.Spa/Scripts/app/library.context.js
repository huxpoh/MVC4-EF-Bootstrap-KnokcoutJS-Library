window.LibApp = window.LibApp || {};
window.LibApp.model = window.LibApp.model || {};

window.LibApp.datacontext = (function () {

    var datacontext = {
        ajaxRequest: ajaxRequest
    };

    return datacontext;

    function ajaxRequest(type, url, data, dataType) {
        var options = {
            dataType: dataType || "json",
            contentType: "application/json",
            cache: false,
            type: type,
            async:false,
            data: data ? data.toJson() : null
        };
        var antiForgeryToken = $("#antiForgeryToken").val();
        if (antiForgeryToken) {
            options.headers = {
                'RequestVerificationToken': antiForgeryToken
            };
        }
        return $.ajax(url, options);
    }
})();

