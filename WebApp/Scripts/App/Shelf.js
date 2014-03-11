(function (libApp) {
    function shelf() {
        var self = this;

        self.Id = ko.observable("");

        self.Number = ko.observable("");
        
        self.StorageId = ko.observable("");
    }
    libApp.model.Shelf = shelf;
}(window.LibApp));
