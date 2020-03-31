using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OneEyed.Attributes;

namespace OneEyed.Events
{
    public class GameEventType : ScriptableObject
    {
        public static GameEventType Create(int value)
        {
            var instance = ScriptableObject.CreateInstance<GameEventType>();
            instance.value = value;
            return instance;
        }

        [SerializeField] [ReadOnly] private int value;
        public int Value { get => value; }
    }
}
