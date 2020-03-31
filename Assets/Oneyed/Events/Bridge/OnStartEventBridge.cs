using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneEyed.Events
{
    public class OnStartEventBridge : MonoBehaviour
    {
        public OnGameObjectEvent onStartEvent;

        private void Start()
        {
            if (enabled)
            {
                onStartEvent.Invoke(gameObject);
            }
        }
    }
}

