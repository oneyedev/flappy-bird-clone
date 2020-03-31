using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

namespace OneEyed.Networking
{
    public abstract class FirestoreDocument
    {
        public string name;
        public string createTime;
        public string updateTime;

        public override string ToString()
        {
            return JsonUtility.ToJson(this);
        }

        public abstract string ToRequestBodyString();
    }

    public class FirestoreDocument<T> : FirestoreDocument
    {
        public T fields;

        public FirestoreDocument() { }

        public FirestoreDocument(T fields)
        {
            this.fields = fields;
        }

        public override string ToRequestBodyString()
        {
            return JsonUtility.ToJson(new RequestBody(fields));
        }

        [Serializable]
        public class RequestBody
        {
            public T fields;

            public RequestBody(T fields)
            {
                this.fields = fields;
            }
        }
    }
}
