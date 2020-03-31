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
    public class TweenQuaternion : Tween<Quaternion>
    {
        public Vector3 start;
        public Vector3 end;
        public Option option;
        public Info info;
        [ReadOnly] public Quaternion current;
        public OnQuaternionEvent onProgressEvent;
        public OnQuaternionEvent onLoopEvent;
        public OnQuaternionEvent onCompletedEvent;

        public override Option Option => option;
        public override Info Info => info;
        public override UnityEvent<Quaternion> OnProgressEvent => onProgressEvent;
        public override UnityEvent<Quaternion> OnLoopEvent => onLoopEvent;
        public override UnityEvent<Quaternion> OnCompletedEvent => onCompletedEvent;
        public override Quaternion Current { get => current; protected set => current = value; }
        public override Func<float, Quaternion> Mapper => MapToCurrent;


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

        public Quaternion MapToCurrent(float progress)
        {
            return Quaternion.Euler(Vector3.Lerp(start, end, progress));
        }
    }
}
