using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OneEyed.Networking;

[Serializable]
public struct Record
{
    public StringValue uid, name;
    public IntegerValue score;
    public TimestampValue timestamp;
}

[Serializable]
public class RecordDocument : FirestoreDocument<Record>
{
    public RecordDocument(Record record) : base(record) { }
    public RecordDocument() : base() { }
}

[CreateAssetMenu(fileName = "Record Documents", menuName = "Record Documents", order = 1)]
public class RecordDocuments : FirestoreDocuments<RecordDocument>
{

}
