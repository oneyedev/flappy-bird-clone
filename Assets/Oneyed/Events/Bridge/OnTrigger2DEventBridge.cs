using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OneEyed.Extensions;
using UnityEngine.Events;

namespace OneEyed.Events
{
    public class OnTrigger2DEventBridge : PhysicsEventBridge<Collider2D>
    {
        public OnCollider2DEvent bridgeEvent;

        public override UnityEvent<Collider2D> BridgeEvent => bridgeEvent;

        public override Converter<Collider2D, int> Converter => (arg => arg.gameObject.layer);

        private void Start()
        {

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (physicsEventType == PhysicsEventType.Enter)
            {
                base.RaiseBridgeEvent(other);
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (physicsEventType == PhysicsEventType.Stay)
            {
                base.RaiseBridgeEvent(other);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (physicsEventType == PhysicsEventType.Exit)
            {
                base.RaiseBridgeEvent(other);
            }
        }
    }
}

