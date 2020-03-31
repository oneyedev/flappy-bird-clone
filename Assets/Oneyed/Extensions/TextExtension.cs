using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace OneEyed.Extensions
{
    public class TextExtension : MonoBehaviour
    {
        public void SetText(int value)
        {
            GetComponent<Text>().SetText(value);
        }
    }

    public static class TextExtensionMethod
    {
        public static void SetText(this Text text, int value)
        {
            text.text = value.ToString();
        }
    }

}
