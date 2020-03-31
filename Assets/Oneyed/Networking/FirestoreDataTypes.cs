using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

namespace OneEyed.Networking
{
    [Serializable]
    public struct StringValue
    {
        public string stringValue;
    }

    [Serializable]
    public struct IntegerValue
    {
        public string integerValue;
        public int value { get => int.Parse(integerValue); }
    }

    [Serializable]
    public struct TimestampValue
    {
        public string timestampValue;

        public void SetValue(DateTime dateTime)
        {
            timestampValue = dateTime.ToUniversalTime()
                         .ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
        }
    }

}
