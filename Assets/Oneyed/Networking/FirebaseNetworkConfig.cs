using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

namespace OneEyed.Networking
{
    [Serializable]
    public struct FirebaseNetworkConfig
    {
        public string apiKey;
        public string authDomain;
        public string databaseURL;
        public string projectId;
        public string storageBucket;
        public string messagingSenderId;
        public string appId;
        public string measurementId;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }

}
