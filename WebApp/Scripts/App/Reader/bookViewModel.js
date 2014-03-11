(function (libApp) {
    function bookViewModel() {
        var self = this;

        self.selectedBook = new libApp.model.Book();

        self.books = ko.observableArray();

        self.PopulatBooks = function () {
            libApp.datacontext.ajaxRequest("GET", "/librarian/book/getallbooks")
                        .done(function(data) {
                             self.books(data);
                        });
        };
        
        self.PopulatBooks();
        
        self.DeleteBook = function (data, event) {
            self.SetCurrentBook(data.Id, data.Name, data.Author, data.PublishDate);
        };

        self.RemoveBook = function (data) {
            var inItems = self.books().filter(function (elem) {return elem.Id === self.selectedBook.Id(); })[0];
            if (inItems == undefined) { return; }

            libApp.datacontext.ajaxRequest("DELETE", "/librarian/book/deletebook", { "guid": self.selectedBook.Id() });
            self.books.remove(inItems);
        };

        self.DetailsBook = function (data, event) {
            console.log(data);
          };

        self.EditBook = function (data, event) {
            self.SetCurrentBook(data.Id, data.Name, data.Author, data.PublishDate);
        };

        self.UpdateBook = function (data, event) {
            var inItems = self.books().filter(function (elem) { return elem.Id === self.selectedBook.Id(); })[0];
            if (inItems == undefined) { return; }

            libApp.datacontext.ajaxRequest("PUT", "/librarian/book/updatebook",
                { "Id": self.selectedBook.Id(),
                  "Name": self.selectedBook.Name(),
                  "Author": self.selectedBook.Author(),
                  "PublishDate": self.selectedBook.PublishedDate(),
                  "BookShelfId": $("#bookDropDown1>option:selected").attr('ShelfId')
                });

            self.PopulatBooks();
        };

        self.CreateBook = function (data, event) {
            libApp.datacontext.ajaxRequest("POST", "/librarian/book/addbook",
                {
                    "Name": self.selectedBook.Name(),
                    "Author": self.selectedBook.Author(),
                    "BookShelfId": $("#bookDropDown2>option:selected").attr('ShelfId')
                });
            self.PopulatBooks();
        };

        self.SetCurrentBook = function(id,name,author,publishDate) {
            self.selectedBook.Id(id);
            self.selectedBook.Name(name);
            self.selectedBook.Author(author);
            self.selectedBook.PublishedDate(publishDate);
        };
    }
    libApp.model.BookViewModel = bookViewModel;
}(window.LibApp));
