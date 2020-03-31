mergeInto(LibraryManager.library, {
  Open: function(url){
    var str_url = Pointer_stringify(url);
    window.open(str_url)
  }
});