(function (libApp) {
    function readerBookViewModel() {
        var self = this;

        self.selectedBook = new libApp.model.Book();

        self.books = ko.observableArray();

        self.PopulatBooks = function () {
            libApp.datacontext.ajaxRequest("GET", "/api/user/GetAllMyBooks", null, "json",
                function (data) {
                    self.books(data);
                });
        };

        self.ReturnBook = function (data, event) {
            libApp.datacontext.ajaxRequest("POST", "/api/user/returnbook?id=" + data.Id,

                null, "json", function () {
                    self.PopulatBooks();
                    window.LibApp.reader.libraryBookViewModel.PopulatBooks();
                });
        };

        self.PopulatBooks();
    }
    libApp.model.ReaderBookViewModel = readerBookViewModel;
}(window.LibApp));
