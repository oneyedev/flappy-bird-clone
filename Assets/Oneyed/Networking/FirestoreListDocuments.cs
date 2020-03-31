using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

namespace OneEyed.Networking
{
    public class FirestoreListDocuments
    {
        public string nextPageToken;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }
    }

    public class FirestoreListDocuments<T> : FirestoreListDocuments
    {
        public List<T> documents;
    }

}
