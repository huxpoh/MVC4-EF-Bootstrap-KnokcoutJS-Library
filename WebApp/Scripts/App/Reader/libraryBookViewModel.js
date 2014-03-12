(function (libApp) {
    function libraryBookViewModel() {
        var self = this;

        self.selectedBook = new libApp.model.Book();

        self.books = ko.observableArray();

        self.PopulatBooks = function () {
            libApp.datacontext.ajaxRequest("GET", "/api/user/GetAllMyBooks?isMyBook=false", null, "json",
                function (data) {
                    self.books(data);
                });
        };

        self.SetCurrentBook = function (id, name, author, publishDate) {
            self.selectedBook.Id(id);
            self.selectedBook.Name(name);
            self.selectedBook.Author(author);
            self.selectedBook.PublishedDate(publishDate);
        };

        self.TakeBook = function (data, event) {
            libApp.datacontext.ajaxRequest("PUT", "/api/user/takebook?id=" + data.Id,
               
                null, "json", function () {
                    self.PopulatBooks();
                window.LibApp.reader.readerBookViewModel.PopulatBooks();
            });
        };

        self.PopulatBooks();
    }
    libApp.model.LibraryBookViewModel = libraryBookViewModel;
}(window.LibApp));
