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
    public class TweenFloat : Tween<float>
    {
        public float start;
        public float end;
        public Option option;
        public Info info;
        [ReadOnly] public float current;
        public OnFloatEvent onProgressEvent;
        public OnFloatEvent onLoopEvent;
        public OnFloatEvent onCompletedEvent;

        public override Option Option => option;
        public override Info Info => info;
        public override UnityEvent<float> OnProgressEvent => onProgressEvent;
        public override UnityEvent<float> OnLoopEvent => onLoopEvent;
        public override UnityEvent<float> OnCompletedEvent => onCompletedEvent;
        public override float Current { get => current; protected set => current = value; }
        public override Func<float, float> Mapper => MapToCurrent;

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

        public float MapToCurrent(float progress)
        {
            return Mathf.Lerp(start, end, progress);
        }
    }
}
