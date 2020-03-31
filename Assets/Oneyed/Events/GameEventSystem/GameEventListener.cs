using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OneEyed.Events
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEventSystem gameEventSystem;

        [GameEventMask(refer = "gameEventSystem")]
        public int eventMask;

        public UnityEvent actions;

        private void OnEnable()
        {
            if (gameEventSystem != null)
            {
                gameEventSystem.AddListner(OnInvokeGameEvent);
            }
        }

        private void OnInvokeGameEvent(int eventMask)
        {
            if ((this.eventMask & eventMask) != 0)
            {
                actions.Invoke();
            }
        }

        private void OnDisable()
        {
            if (gameEventSystem != null)
            {
                gameEventSystem.RemoveListner(OnInvokeGameEvent);
            }
        }
    }
}
