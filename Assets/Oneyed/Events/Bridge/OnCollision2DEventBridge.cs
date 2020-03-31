using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OneEyed.Extensions;

namespace OneEyed.Events
{
    public class OnCollision2DEventBridge : PhysicsEventBridge<Collision2D>
    {
        public OnCollision2DEvent bridgeEvent;

        public override UnityEvent<Collision2D> BridgeEvent => bridgeEvent;

        public override Converter<Collision2D, int> Converter => (arg => arg.gameObject.layer);

        private void Start()
        {
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (physicsEventType == PhysicsEventType.Enter)
            {
                base.RaiseBridgeEvent(collision);
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (physicsEventType == PhysicsEventType.Stay)
            {
                base.RaiseBridgeEvent(collision);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (physicsEventType == PhysicsEventType.Exit)
            {
                base.RaiseBridgeEvent(collision);
            }
        }
    }
}
