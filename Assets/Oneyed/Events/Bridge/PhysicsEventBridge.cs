using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OneEyed.Extensions;

namespace OneEyed.Events
{
    public enum PhysicsEventType { Enter, Stay, Exit }
    public abstract class PhysicsEventBridge<T> : EventBridge<T>
    {
        public PhysicsEventType physicsEventType = PhysicsEventType.Enter;
        public LayerMask layerMask;
        public abstract Converter<T, int> Converter { get; }

        public override void RaiseBridgeEvent(T arg)
        {
            if (layerMask.IsSet(Converter.Invoke(arg)))
            {
                base.RaiseBridgeEvent(arg);
            }
        }
    }
}

