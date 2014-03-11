(function (libApp) {
    function book() {
        var self = this;

        self.guid = ko.observable("");

        self.Name = ko.observable("");

        self.Author = ko.observable("");

        self.Date = ko.observable("");
    }
    libApp.model.Book = book;
}(window.LibApp));
