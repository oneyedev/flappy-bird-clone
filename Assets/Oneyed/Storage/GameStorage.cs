using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OneEyed.Storage
{
    public abstract class GameStorage : MonoBehaviour
    {

    }

    public abstract class GameStorage<T> : GameStorage
    {
        public T current;

        public abstract UnityEvent<T> CommitEvent { get; }

        public virtual void Commit(T value)
        {
            this.current = value;
            CommitEvent.Invoke(value);
        }
    }
}
