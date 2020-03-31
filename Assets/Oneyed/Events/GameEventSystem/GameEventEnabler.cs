using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OneEyed.Events
{
    public class GameEventEnabler : MonoBehaviour
    {
        public GameEventSystem gameEventSystem;

        [GameEventMask(refer = "gameEventSystem")]
        public int eventMask;

        public MonoBehaviour[] targets = { null };

        private void OnEnable()
        {
            if (gameEventSystem != null)
            {
                gameEventSystem.AddListner(OnInvokeGameEvent);
            }
        }

        private void OnInvokeGameEvent(int eventMask)
        {
            var value = (this.eventMask & eventMask) != 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i] != null)
                {
                    targets[i].enabled = value;
                }
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
