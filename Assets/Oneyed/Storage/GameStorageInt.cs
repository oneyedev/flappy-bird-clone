using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OneEyed.Events;

namespace OneEyed.Storage
{
    public class GameStorageInt : GameStorage<int>
    {
        public OnIntEvent commitEvent;
        public override UnityEvent<int> CommitEvent => commitEvent;

        public void Add(int value)
        {
            base.Commit(current + value);
        }

        public void Min(int value)
        {
            base.Commit(System.Math.Min(value, current));
        }

        public void Max(int value)
        {
            base.Commit(System.Math.Max(value, current));
        }
    }

}
