window.LibApp.librarian = (function () {

    var bookViewModel = new window.LibApp.model.BookViewModel();
    var storageViewModel = new window.LibApp.model.StorageViewModel();
    var shelfViewModel = new window.LibApp.model.ShelfViewModel();
   

    var datacontext = {
        bookViewModel: bookViewModel,
        storageViewModel: storageViewModel,
        shelfViewModel: shelfViewModel
    };
    ko.applyBindings(datacontext);
    return datacontext;
})();

