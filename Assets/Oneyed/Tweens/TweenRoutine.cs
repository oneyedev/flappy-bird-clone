using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using OneEyed.Events;
using OneEyed.Attributes;
using static OneEyed.Tweens.Option;

namespace OneEyed.Tweens
{
    public class TweenRoutine
    {
        public IEnumerator Routine(Option option, Info info, Action<float> callback, Action<float> completed)
        {
            yield return option.WaitForDelay();
            while (info.CheckTweenCondition())
            {
                yield return null;
                info.time += option.GetDeltaTime();
                info.progress = option.Interpolate(info.CalcTimeProgress(option.duration));
                callback.Invoke(info.progress);
            }
            completed.Invoke(info.progress);
        }
    }
}
