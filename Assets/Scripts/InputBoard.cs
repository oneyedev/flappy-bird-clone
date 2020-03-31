using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using OneEyed.Networking;
using System;
using UnityEngine.Networking;

public class InputBoard : MonoBehaviour
{
    public string[] rankText;
    public Text newRecordText, savingText, statusText;
    public InputField input;
    public GameObject loading;
    public int rank;
    public RecordDocument document;
    public RecordDocuments documents;

    public UnityEvent onSaveEvent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Open(int rank, RecordDocument document)
    {
        if (!string.IsNullOrEmpty(this.document.name))
        {
            return;
        }
        this.rank = rank;
        this.document = document;
        newRecordText.text = string.Format("New {0} Record !\nPlease Enter Your Name", rankText[rank]);
        input.text = document.fields.name.stringValue;
        input.Select();
        gameObject.SetActive(true);
    }

    public void SetRecordName(string text)
    {
        document.fields.name.stringValue = text;
    }

    public void Save()
    {
        ShowLoading();
        documents.Patch(document)
            .Then(document => OnSaveSucceed())
            .Catch(document => OnSaveFailed())
            .Finally(HideLoading);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    private void ShowLoading()
    {
        loading.SetActive(true);
        savingText.enabled = false;
        statusText.text = string.Empty;
    }

    private void HideLoading()
    {
        loading.SetActive(false);
        savingText.enabled = true;
    }

    private void OnSaveSucceed()
    {
        onSaveEvent.Invoke();
        statusText.text = "Saved";
    }

    private void OnSaveFailed()
    {
        statusText.text = "Failed to save due to network error";
    }

}
