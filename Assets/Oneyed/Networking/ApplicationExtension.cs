using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;
namespace OneEyed.Networking
{
    [CreateAssetMenu(fileName = "ApplicationExtension", menuName = "Oneyed/ApplicationExtension", order = 1)]
    public class ApplicationExtension : ScriptableObject
    {
        [DllImport("__Internal")]
        public static extern void Open(string url);

        public void OpenURL(string url)
        {
            Application.OpenURL(url);
        }

        public void OpenUrlNewWindow(string url)
        {
            Open(url);
        }

    }

}
