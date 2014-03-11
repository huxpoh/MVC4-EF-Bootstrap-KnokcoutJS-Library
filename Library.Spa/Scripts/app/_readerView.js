window.LibApp.view = (function () {

    var bookVoewModel = new window.LibApp.model.BookViewModel();

    window.LibApp.datacontext.ajaxRequest("GET", "api/Librarian/GetAllBooks");

    var view = {
        bookViewModel: bookVoewModel
    };

    return view;
})();
