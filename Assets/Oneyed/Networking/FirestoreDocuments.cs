using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Text;
using UnityEngine.Events;
using Proyecto26;
using RSG;
using OneEyed.DevOps;

namespace OneEyed.Networking
{
    public class FirestoreDocuments<T> : ScriptableObject where T : FirestoreDocument
    {
        public FirebaseNetwork network;
        public DevOpsBool logging;
        public string baseUrl;
        public DevOpsString parent;
        public string collectionId;
        public string collectionUrl { get => string.Format("{0}{1}{2}", baseUrl, parent.Current, collectionId); }
        public int pageSize = 5;
        public string pageToken, orderBy;
        public List<T> list;

        public void Clear()
        {
            list.Clear();
            pageToken = string.Empty;
        }

        public IPromise<T> CreateDocument(T document)
        {
            var promise = new Promise<T>();
            RestClient.Post(collectionUrl, document.ToRequestBodyString(), (ex, response) =>
            {
                if (IsError(ex, response.Request))
                {
                    LogWarningIfLoggable(response.Request);
                    promise.Reject(ex);
                }
                else
                {
                    LogIfLoggable(response.Request);
                    JsonUtility.FromJsonOverwrite(response.Request.downloadHandler.text, document);
                    promise.Resolve(document);
                }
            });
            return promise;
        }

        public IPromise<List<T>> List()
        {
            var query = string.Format("?pageSize={0}&pageToken={1}&orderBy={2}", pageSize, pageToken, orderBy);
            var url = collectionUrl + query;
            var promise = new Promise<List<T>>();
            RestClient.Get(url, (ex, response) =>
            {
                if (IsError(ex, response.Request))
                {
                    LogWarningIfLoggable(response.Request);
                    promise.Reject(ex);
                }
                else
                {
                    LogIfLoggable(response.Request);
                    var listDocuments = JsonUtility.FromJson<FirestoreListDocuments<T>>(response.Request.downloadHandler.text);
                    pageToken = listDocuments.nextPageToken;
                    list.AddRange(listDocuments.documents);
                    promise.Resolve(listDocuments.documents);
                }
            });
            return promise;
        }

        public IPromise<T> Patch(T document)
        {
            var url = baseUrl + document.name;
            var promise = new Promise<T>();
            var option = new RequestHelper
            {
                Uri = url,
                Method = "PATCH",
                BodyString = document.ToRequestBodyString()
            };
            RestClient.Request(option, (ex, response) =>
            {
                if (IsError(ex, response.Request))
                {
                    LogWarningIfLoggable(response.Request);
                    promise.Reject(ex);
                }
                else
                {
                    LogIfLoggable(response.Request);
                    JsonUtility.FromJsonOverwrite(response.Request.downloadHandler.text, document);
                    promise.Resolve(document);
                }
            });
            return promise;
        }

        private bool IsError(Exception exception, UnityWebRequest response)
        {
            return exception != null || response.isNetworkError || !response.responseCode.Equals(200);
        }

        private void LogWarningIfLoggable(UnityWebRequest response)
        {
            if (logging.Current)
            {
                Debug.LogWarning(GetWebResponseMessage(response));
            }
        }

        private void LogIfLoggable(UnityWebRequest response)
        {
            if (logging.Current)
            {
                Debug.Log(GetWebResponseMessage(response));
            }
        }

        private string GetWebResponseMessage(UnityWebRequest response)
        {
            var requestBody = response.uploadHandler != null ? Encoding.UTF8.GetString(response.uploadHandler.data) : "";
            var responseBody = response.downloadHandler.text;
            return string.Format("[{0}] {1}\n{2}\nAuthroization : {3}\n{4}\n{5}", response.method, response.url, requestBody, response.GetRequestHeader("Authorization"), response.error, responseBody);
        }
    }
}
