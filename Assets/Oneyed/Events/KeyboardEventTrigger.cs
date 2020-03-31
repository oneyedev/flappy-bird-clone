using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OneEyed.Events.Triggers
{
    public class KeyboardEventTrigger : MonoBehaviour
    {
        public KeyCode keyCode;
        public enum EventType { Down, Stay, Up }
        public EventType eventType;

        public OnKeyCodeEvent keyCodeEvent;

        void Start()
        {

        }

        void Update()
        {
            if (Input.GetKeyDown(keyCode) && eventType == EventType.Down)
            {
                keyCodeEvent.Invoke(keyCode);
            }
            if (Input.GetKey(keyCode) && eventType == EventType.Stay)
            {
                keyCodeEvent.Invoke(keyCode);
            }
            if (Input.GetKeyUp(keyCode) && eventType == EventType.Up)
            {
                keyCodeEvent.Invoke(keyCode);
            }
        }
    }
}
