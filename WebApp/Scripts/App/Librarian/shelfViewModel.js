(function (libApp) {
    function shelfViewModel() {
        var self = this;

        self.selectedShelf = new libApp.model.Shelf();

        self.shelfs = ko.observableArray();

        self.PopulatShelfs = function () {
            libApp.datacontext.ajaxRequest("GET", "/api/shelf/getallshelfs", null, "json",
           function (data) {
               self.shelfs(data);
           });
        };

        self.PopulatShelfs();

        self.DeleteShelf = function (data, event) {
            self.SetCurrentShelf(data.Id, data.Number);
        };

        self.RemoveShelf = function (data) {
            var inItems = self.shelfs().filter(function (elem) { return elem.Id === self.selectedShelf.Id(); })[0];
            if (inItems == undefined) { return; }

            libApp.datacontext.ajaxRequest("DELETE", "/api/shelf/deleteshelf/?guid=" + self.selectedShelf.Id(), null, "json", function () {
                self.shelfs.remove(inItems);
            });

        };

        self.DetailsShelf = function (data, event) {
            self.SetCurrentShelf(data.Id, data.Number);
        };

        self.EditShelf = function (data, event) {
            self.SetCurrentShelf(data.Id, data.Number);
        };

        self.UpdateShelf = function (data, event) {
            var inItems = self.shelfs().filter(function (elem) { return elem.Id === self.selectedShelf.Id(); })[0];
            if (inItems == undefined) { return; }

            libApp.datacontext.ajaxRequest("PUT", "/api/shelf/updateshelf",
                {
                    "Id": self.selectedShelf.Id(),
                    "Number": self.selectedShelf.Number(),
                    "StorageId": $("#storageId1>option:selected").attr('ShelfId')
                }, "json", function () {
                    self.PopulatShelfs();
                });
        };

        self.CreateShelf = function (data, event) {
            libApp.datacontext.ajaxRequest("POST", "/api/shelf/addshelf",
                {
                    "Id": self.selectedShelf.Id(),
                    "Number": self.selectedShelf.Number(),
                    "StorageId": $("#storageId2>option:selected").attr('ShelfId')
                }, "json", function () {
                    self.PopulatShelfs();
                });;
        };

        self.SetCurrentShelf = function (id, number) {
            self.selectedShelf.Id(id);
            self.selectedShelf.Number(number);
        };
    }
    libApp.model.ShelfViewModel = shelfViewModel;
}(window.LibApp));
