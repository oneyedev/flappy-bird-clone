using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OneEyed.Events;

namespace OneEyed.Utils
{
    public class Timer : MonoBehaviour
    {
        public float time = 1, startTime = 1;
        public bool repeat;
        public OnFloatEvent onTimeEvent;
        public UnityEvent onTimeOverEvent;

        void Start()
        {

        }

        void Update()
        {
            time -= Time.deltaTime;
            onTimeEvent.Invoke(time);
            if (time <= 0)
            {
                onTimeOverEvent.Invoke();
                if (repeat)
                {
                    time = startTime;
                }
                else
                {
                    enabled = false;
                }
            }
        }
    }
}

