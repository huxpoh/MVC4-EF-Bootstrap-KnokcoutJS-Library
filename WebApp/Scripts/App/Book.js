(function (libApp) {
    function book() {
        var self = this;

        self.Id = ko.observable("");

        self.Name = ko.observable("");

        self.Author = ko.observable("");

        self.PublishedDate = ko.observable("");
        
        self.BookShelfId = ko.observable("");
    }
    libApp.model.Book = book;
}(window.LibApp));
