window.LibApp.reader = (function () {
   var readerBookViewModel = new window.LibApp.model.ReaderBookViewModel();
   var libraryBookViewModel = new window.LibApp.model.LibraryBookViewModel();

    var datacontext = {
        readerBookViewModel: readerBookViewModel,
        libraryBookViewModel: libraryBookViewModel
    };
    ko.applyBindings(datacontext);
    return datacontext;
})();

