using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OneEyed.Extensions;
using UnityEngine.Events;

namespace OneEyed.Events
{
    public class OnTriggerEventBridge : PhysicsEventBridge<Collider>
    {
        public OnColliderEvent bridgeEvent;

        public override UnityEvent<Collider> BridgeEvent => bridgeEvent;

        public override Converter<Collider, int> Converter => (arg => arg.gameObject.layer);

        private void Start()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (physicsEventType == PhysicsEventType.Enter)
            {
                base.RaiseBridgeEvent(other);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (physicsEventType == PhysicsEventType.Stay)
            {
                base.RaiseBridgeEvent(other);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (physicsEventType == PhysicsEventType.Exit)
            {
                base.RaiseBridgeEvent(other);
            }
        }
    }
}

