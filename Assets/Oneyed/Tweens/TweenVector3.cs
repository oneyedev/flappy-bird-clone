using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using OneEyed.Events;
using OneEyed.Attributes;

namespace OneEyed.Tweens
{
    public class TweenVector3 : Tween<Vector3>
    {
        public Vector3 start;
        public Vector3 end;
        public Option option;
        public Info info;
        [ReadOnly] public Vector3 current;
        public OnVector3Event onProgressEvent;
        public OnVector3Event onLoopEvent;
        public OnVector3Event onCompletedEvent;

        public override Option Option => option;
        public override Info Info => info;
        public override UnityEvent<Vector3> OnProgressEvent => onProgressEvent;
        public override UnityEvent<Vector3> OnLoopEvent => onLoopEvent;
        public override UnityEvent<Vector3> OnCompletedEvent => onCompletedEvent;
        public override Vector3 Current { get => current; protected set => current = value; }
        public override Func<float, Vector3> Mapper => MapToCurrent;


        private void OnEnable()
        {
            if (Option.playOnEnable)
            {
                Replay();
            }
        }

        private void Start()
        {
            if (Option.playOnStart)
            {
                Play();
            }
        }

        private void OnDisable()
        {
            if (Option.stopOnDisable)
            {
                Stop();
            }
            if (Option.resetOnDisable)
            {
                onProgressEvent.Invoke(MapToCurrent(0));
            }
        }

        private void OnDestroy()
        {
            Stop();
        }

        public Vector3 MapToCurrent(float progress)
        {
            return Vector3.Lerp(start, end, progress);
        }
    }
}
