window.LibApp = window.LibApp || {};
window.LibApp.model = window.LibApp.model || {};

window.LibApp.datacontext = (function () {

    var datacontext = {
        ajaxRequest: ajaxRequest
    };

    return datacontext;

    function ajaxRequest(type, url, data, dataType,success,error) {
        var options = {
            dataType: dataType || "json",
            contentType: "application/json",
            cache: false,
            type: type,
            async: true,
            crossDomain: true,
            success: success,
            //complete :success,
            error:function(result) {
                console.log(result);
            },
            data: data ? JSON.stringify(data) : null
        };
        return $.ajax(url, options);
    }
})();

