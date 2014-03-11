(function (libApp) {
    function storage() {
        var self = this;

        self.Id = ko.observable("");

        self.Name = ko.observable("");

        self.Number = ko.observable("");
    }
    libApp.model.Storage = storage;
}(window.LibApp));
