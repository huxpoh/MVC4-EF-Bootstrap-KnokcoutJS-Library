(function (libApp) {
    function storageViewModel() {
        var self = this;

        self.selectedStorage = new libApp.model.Storage();

        self.storages = ko.observableArray();

        self.PopulatStorage = function () {
            libApp.datacontext.ajaxRequest("GET", "/api/storage/getallstorages", null, "json",
                function (data) {
                    console.log(data);
                    self.storages(data);
                });
        };
        self.PopulatStorage();

        self.RemoveStorage = function (data) {
            var inItems = self.storages().filter(function (elem) { return elem.Id === self.selectedStorage.Id(); })[0];
            if (inItems == undefined) { return; }

            libApp.datacontext.ajaxRequest("DELETE", "/api/storage/deletestorage/?guid=" + self.selectedStorage.Id(), null, "json",
                function () {
                    self.storages.remove(inItems);
                });
        };

        self.DeleteStorage = function (data, event) {
            self.SetCurrentStorage(data.Id, data.Name, data.Number);
        };

        self.EditStorage = function (data, event) {
            self.SetCurrentStorage(data.Id, data.Name, data.Number);
        };

        self.SetCurrentStorage = function (id, name, number) {
            self.selectedStorage.Id(id);
            self.selectedStorage.Name(name);
            self.selectedStorage.Number(number);
        };

        self.UpdateStorage = function (data, event) {
            var inItems = self.storages().filter(function (elem) { return elem.Id === self.selectedStorage.Id(); })[0];
            if (inItems == undefined) { return; }

            libApp.datacontext.ajaxRequest("PUT", "/api/storage/updatestorage", {
                "Id": self.selectedStorage.Id(),
                "Name": self.selectedStorage.Name(),
                "Number": self.selectedStorage.Number()
            }, "json", function () {
                self.PopulatStorage();
            });
        };

        self.CreateStorage = function (data, event) {
            libApp.datacontext.ajaxRequest("POST", "/api/storage/addstorage",
                {
                    "Name": self.selectedStorage.Name(),
                    "Number": self.selectedStorage.Number()
                }, "json",
                function () {
                    self.PopulatStorage();
                });
        };

    }
    libApp.model.StorageViewModel = storageViewModel;
}(window.LibApp));
