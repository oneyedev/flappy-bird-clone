using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OneEyed.Events;
using UnityEngine.Networking;
using System;
using OneEyed.DevOps;

namespace OneEyed.Networking
{
    public class FirebaseNetworkListener : MonoBehaviour
    {
        public DevOpsBool logging;
        public OnStringEvent onSignedInEvent = new OnStringEvent();
        public OnStringEvent onGetIdTokenEvent = new OnStringEvent();

        public void OnSignedIn(string uid)
        {
            if (logging.Current)
                Debug.Log("Receive Message OnSignedIn " + uid);
            onSignedInEvent.Invoke(uid);
        }

        public void OnGetIdToken(string token)
        {
            if (logging.Current)
                Debug.Log("Receive Message OnGetIdToken " + token);
            onGetIdTokenEvent.Invoke(token);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
