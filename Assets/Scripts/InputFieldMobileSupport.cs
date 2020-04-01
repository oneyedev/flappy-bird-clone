using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;
using System;


public class InputFieldMobileSupport : MonoBehaviour, IPointerClickHandler
{
    public string message;

    [DllImport("__Internal")]
    private static extern void Prompt(string name, string message, string inputValue);

#if UNITY_WEBGL
    public void OnPointerClick(PointerEventData eventData)
    {
        Prompt(gameObject.name, message, GetComponent<InputField>().text);
    }

    public void OnPromptedOk(string value)
    {
        GetComponent<InputField>().text = value;
    }

    public void OnPromptedCancel()
    {
        WebGLInput.captureAllKeyboardInput = true;
    }
#endif
}
