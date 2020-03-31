using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OneEyed.Events
{
    public abstract class EventBridge : MonoBehaviour
    {
        public bool once;
        public int count;
    }

    public abstract class EventBridge<T> : EventBridge
    {
        public abstract UnityEvent<T> BridgeEvent { get; }
        public virtual void RaiseBridgeEvent(T arg)
        {
            if (IsInvokable)
            {
                count++;
                BridgeEvent.Invoke(arg);
            }
        }

        public bool IsInvokable
        {
            get
            {
                if (!enabled)
                    return false;
                if (once && count > 0)
                    return false;
                return true;
            }

        }
    }
}

