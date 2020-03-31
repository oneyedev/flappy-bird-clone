using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OneEyed.Tweens;
using OneEyed.Networking;
using System;
using UnityEngine.Networking;
using RSG;
using Proyecto26;
using UnityEngine.Events;

public class RankEditor : MonoBehaviour
{
    public VerticalLayoutGroup layoutGroup;
    public GameObject header;
    public GameObject[] ranks;
    public GameObject fail;
    public GameObject loading;

    public InputBoard input;

    public FirebaseNetwork network;
    public RecordDocuments records;
    public RecordDocument newRecord;

    public UnityEvent onRankNewRecordEvent;
    public UnityEvent onRankFailEvent;

    void Start()
    {

    }

    public void SetScore(int score)
    {
        newRecord.fields.score.integerValue = score.ToString();
    }

    public void FetchFromFirebase()
    {
        ShowLoading();
        newRecord.fields.timestamp.SetValue(DateTime.UtcNow);
        records.Clear();
        network.SignInAnonymouslyIfNot()
            .Then(network => network.GetIdToken())
            .Then(network => newRecord.fields.uid.stringValue = network.state.Current.uid)
            .Then(network => records.CreateDocument(newRecord))
            .Then(doc => records.List())
            .Then(list => ShowRanking())
            .Catch(ShowError)
            .Finally(HideLoading);
    }

    private void ShowLoading()
    {
        loading.SetActive(true);
        header.SetActive(false);
        fail.SetActive(false);
    }

    private void HideLoading()
    {
        loading.SetActive(false);
    }

    private void ShowRanking()
    {
        layoutGroup.childAlignment = TextAnchor.UpperCenter;
        fail.SetActive(false);
        header.SetActive(true);
        var ranked = false;
        for (int i = 0; i < ranks.Length; i++)
        {
            if (i < records.list.Count)
            {
                ranks[i].SetActive(true);
                SyncRankWithDocument(ranks[i], records.list[i]);
                if (records.list[i].name.Equals(newRecord.name))
                {
                    ranked = true;
                    onRankNewRecordEvent.Invoke();
                    input.Open(i, newRecord);
                }
            }
            else
            {
                ranks[i].SetActive(false);
            }
        }
        if (!ranked)
        {
            onRankFailEvent.Invoke();
        }
    }

    public void ShowError(Exception ex)
    {
        layoutGroup.childAlignment = TextAnchor.MiddleCenter;
        loading.SetActive(false);
        header.SetActive(false);
        fail.SetActive(true);
    }

    public void SyncRankWithDocument(GameObject rank, RecordDocument document)
    {
        var name = document.fields.name.stringValue;
        var score = document.fields.score.integerValue;
        var nameText = rank.transform.Find("Name").GetComponent<Text>();
        var scoreText = rank.transform.Find("Score").GetComponent<Text>();
        nameText.text = name;
        scoreText.text = score;
    }

    public void OnSaveRecord()
    {
        SyncRankWithDocument(ranks[input.rank], input.document);
    }
}
