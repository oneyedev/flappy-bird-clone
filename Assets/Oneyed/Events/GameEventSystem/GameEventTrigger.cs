using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OneEyed.Events
{
    public class GameEventTrigger : MonoBehaviour
    {
        public GameEventSystem gameEventSystem;

        public void RaiseEvent(GameEventType eventType)
        {
            gameEventSystem.RaiseEvent(eventType);
        }

        public void RaiseEvent(int eventMask)
        {
            gameEventSystem.RaiseEvent(eventMask);
        }
    }
}
