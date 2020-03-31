using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using OneEyed.Attributes;

namespace OneEyed.Tweens
{
    [Serializable]
    public class Option
    {
        public float duration = 5f;
        public float delay = 0;
        public Easings.Functions easeType = Easings.Functions.CubicEaseInOut;
        public enum LoopType { None, Loop, PingPong }
        public LoopType loopType = LoopType.None;
        public bool ignoreTimeScale;
        public bool playOnStart;
        public bool playOnEnable;
        public bool stopOnDisable;
        public bool resetOnDisable;

        public IEnumerator WaitForDelay()
        {
            if (ignoreTimeScale)
                yield return new WaitForSecondsRealtime(delay);
            else
                yield return new WaitForSeconds(delay);
        }

        public float GetDeltaTime()
        {
            return ignoreTimeScale ? Time.deltaTime : Time.unscaledDeltaTime;
        }

        public float Interpolate(float progress)
        {
            return Easings.Interpolate(progress, easeType);
        }
    }

    [Serializable]
    public class Info
    {
        [ReadOnly] public bool reversed;
        [ReadOnly] public float time;
        [ReadOnly] public float progress;

        public void Reset(bool reversed)
        {
            this.reversed = reversed;
            time = 0;
            progress = reversed ? 1 : 0;
        }

        public bool CheckTweenCondition()
        {
            return reversed ? (progress > 0) : (progress < 1);
        }

        public float CalcTimeProgress(float duration)
        {
            return reversed ? (1 - time / duration) : (time / duration);
        }
    }

    public abstract class Tween : MonoBehaviour
    {
        public abstract Option Option { get; }
        public abstract Info Info { get; }
        public abstract bool IsPlaying { get; }
        protected TweenRoutine routine = new TweenRoutine();
        protected Coroutine coroutine;
        public abstract void Play();
        public abstract void Stop();
        public abstract void Replay();
        public abstract void ReversePlay();
        public abstract void Reset(bool reversed);
    }

    public abstract class Tween<T> : Tween
    {

        public abstract UnityEvent<T> OnProgressEvent { get; }
        public abstract UnityEvent<T> OnLoopEvent { get; }
        public abstract UnityEvent<T> OnCompletedEvent { get; }
        public abstract T Current { get; protected set; }
        public abstract Func<float, T> Mapper { get; }

        public override bool IsPlaying => coroutine != null;

        public override void Play()
        {
            if (coroutine != null || !gameObject.activeInHierarchy)
                return;
            coroutine = StartCoroutine(routine.Routine(Option, Info, OnProgress, OnCompleted));
        }

        public override void Stop()
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = null;
        }

        public override void Replay()
        {
            Stop();
            Reset(false);
            Play();
        }

        public override void ReversePlay()
        {
            Stop();
            Reset(!Info.reversed);
            Play();
        }

        public override void Reset(bool reversed)
        {
            Info.Reset(reversed);
        }

        public void OnProgress(float progress)
        {
            Current = Mapper.Invoke(progress);
            OnProgressEvent.Invoke(Current);
        }

        public void OnCompleted(float progress)
        {
            if (Option.loopType == Option.LoopType.None)
            {
                Current = Mapper.Invoke(progress);
                OnCompletedEvent.Invoke(Current);
                Stop();
            }
            else if (Option.loopType == Option.LoopType.Loop)
            {
                OnLoopEvent.Invoke(Current);
                Replay();
            }
            else if (Option.loopType == Option.LoopType.PingPong)
            {
                if (Info.reversed)
                    OnLoopEvent.Invoke(Current);
                ReversePlay();
            }
        }
    }
}
