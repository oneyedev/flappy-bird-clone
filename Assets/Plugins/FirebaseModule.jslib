var firebaseModule = {
  SignInAnonymously: function (listener) {
    var str_listener = Pointer_stringify(listener);
    window.firebase.auth()
      .signInAnonymously()
      .then(function() {
        var uid = window.firebase.auth().currentUser.uid;
        SendMessage(str_listener, "OnSignedIn", uid);
      })
      .catch(function (error) {
        console.error(error);
      });
  },

  GetIdToken: function(listener) {
    var str_listener = Pointer_stringify(listener);
    window.firebase.auth().currentUser.getIdToken(true)
      .then(function (token) {
        SendMessage(str_listener, 'OnGetIdToken', token);
      })
      .catch(function (error) {
        console.error(error);
      });
  }
};
mergeInto(LibraryManager.library, firebaseModule);