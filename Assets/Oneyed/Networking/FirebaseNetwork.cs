using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.Networking;
using UnityEngine.Events;
using System.Text;
using System;
using OneEyed.Attributes;
using OneEyed.Events;
using RSG;
using Proyecto26;
using OneEyed.DevOps;

namespace OneEyed.Networking
{
    [CreateAssetMenu(fileName = "FirebaseNetwork", menuName = "Oneyed/FirebaseNetwork", order = 1)]
    public class FirebaseNetwork : ScriptableObject
    {
        [DllImport("__Internal")]
        public static extern void SignInAnonymously(string listener);
        [DllImport("__Internal")]
        public static extern void GetIdToken(string listener);
        [Serializable]
        public class State
        {
            public string uid;
            public string token;
        }
        [Serializable] public class DevOpsState : DevOpsConfig<State> { }
        public FirebaseNetworkConfig config;
        public DevOpsState state;
        public DevOpsBool stubMessage;

        public string listenerObjectName = "Firebase Network";

        private Promise<FirebaseNetwork> signInPromise, getIdTokenPromise;

        public void OnSignedIn(string uid)
        {
            state.Current.uid = uid;
            signInPromise?.Resolve(this);
        }

        public void OnGetIdToken(string token)
        {
            if (!string.IsNullOrEmpty(token))
                RestClient.DefaultRequestHeaders["Authorization"] = "Bearer " + token;
            state.Current.token = token;
            getIdTokenPromise?.Resolve(this);
        }

        public IPromise<FirebaseNetwork> SignInAnonymouslyIfNot()
        {
            var current = state.Current;
            if (!string.IsNullOrEmpty(current.uid))
                return Promise<FirebaseNetwork>.Resolved(this);
            signInPromise?.Done();
            signInPromise = new Promise<FirebaseNetwork>();
            if (stubMessage.Current)
                GameObject.Find(listenerObjectName).SendMessage("OnSignedIn", state.editor.uid);
            else
                SignInAnonymously(listenerObjectName);
            return signInPromise;
        }

        public IPromise<FirebaseNetwork> GetIdToken()
        {
            var current = state.Current;
            if (!string.IsNullOrEmpty(current.token))
                return Promise<FirebaseNetwork>.Resolved(this);
            getIdTokenPromise?.Done();
            getIdTokenPromise = new Promise<FirebaseNetwork>();
            if (stubMessage.Current)
                GameObject.Find(listenerObjectName).SendMessage("OnGetIdToken", state.editor.token);
            else
                GetIdToken(listenerObjectName);
            return getIdTokenPromise;
        }
    }
}
