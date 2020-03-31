using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OneEyed.Extensions;

namespace OneEyed.Events
{
    public class OnCollisionEventBridge : PhysicsEventBridge<Collision>
    {
        public OnCollisionEvent bridgeEvent;

        public override UnityEvent<Collision> BridgeEvent => bridgeEvent;

        public override Converter<Collision, int> Converter => (arg => arg.gameObject.layer);

        private void Start()
        {
        }

        private void OnCollisionEnter(Collision other)
        {
            if (physicsEventType == PhysicsEventType.Enter)
            {
                base.RaiseBridgeEvent(other);
            }
        }

        private void OnCollisionStay(Collision other)
        {
            if (physicsEventType == PhysicsEventType.Stay)
            {
                base.RaiseBridgeEvent(other);
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (physicsEventType == PhysicsEventType.Exit)
            {
                base.RaiseBridgeEvent(other);
            }
        }
    }
}
