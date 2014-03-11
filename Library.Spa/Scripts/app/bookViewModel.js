(function (libApp) {
    function bookViewModel() {
        var self = this;

        self.selectedBook = ko.observable();

        self.books = ko.observableArray();
    }
    libApp.model.BookViewModel = bookViewModel;
}(window.LibApp));
