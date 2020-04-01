mergeInto(LibraryManager.library, {
  Open: function(url){
    var str_url = Pointer_stringify(url);
    window.open(str_url)
  },
  Prompt: function(name, message, defaultValue){
    if(UnityLoader.SystemInfo.mobile){
        const str_name = Pointer_stringify(name);
        const str_message = Pointer_stringify(message);
        const str_defaultValue = Pointer_stringify(defaultValue);
        const value = window.prompt(str_message, str_defaultValue);
        if(value === null){
          SendMessage(str_name, "OnPromptedCancel");
        } else {
          SendMessage(str_name, "OnPromptedOk", value);
        }
    }
  }
});