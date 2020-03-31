using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneEyed.Events
{
    public class OnEnableEventBridge : MonoBehaviour
    {
        public OnGameObjectEvent onEnableEvent;
        public OnGameObjectEvent onDisableEvent;

        private void OnEnable()
        {
            onEnableEvent.Invoke(gameObject);
        }

        private void OnDisable()
        {
            onDisableEvent.Invoke(gameObject);
        }
    }
}

