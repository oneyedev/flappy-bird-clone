using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OneEyed.DevOps;

namespace OneEyed.Events
{
    [CreateAssetMenu(fileName = "GameEventSystem", menuName = "Oneyed/GameEventSystem", order = 1)]
    public class GameEventSystem : ScriptableObject
    {
        public DevOpsBool logging;
        public string[] layers = new string[32];
        [GameEventMask] public int current;
        [Serializable] public class GameEvent : UnityEvent<int> { }
        public GameEvent listeners;

        public void RaiseEvent(GameEventType eventType)
        {
            RaiseEvent(1 << eventType.Value);
        }

        public void RaiseEvent(int eventMask)
        {
            if (logging.Current)
                Debug.Log(String.Format("[{0}] Raise <{1}> Event", name, EventMaskToNames(eventMask)));
            current = eventMask;
            listeners.Invoke(eventMask);
        }

        public void AddListner(UnityAction<int> listener)
        {
            listeners.AddListener(listener);
        }

        public void RemoveListner(UnityAction<int> listener)
        {
            listeners.RemoveListener(listener);
        }

        public string EventMaskToNames(int eventMask)
        {
            var events = new List<string>();
            for (int i = 0; i < layers.Length; i++)
            {
                if ((eventMask & (1 << i)) != 0)
                {
                    events.Add(layers[i]);
                }
            }
            return string.Join("/", events);
        }
    }
}
