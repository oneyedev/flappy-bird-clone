using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OneEyed.Events
{
    public class GameEventActivator : MonoBehaviour
    {
        public enum ActivationType { GameObject, MonoBehaviour }
        public GameEventSystem gameEventSystem;

        [GameEventMask(refer = "gameEventSystem")]
        public int eventMask;

        public ActivationType activationType = ActivationType.GameObject;
        public float delay;

        public MonoBehaviour[] targets = { null };

        private void OnEnable()
        {
            if (gameEventSystem != null)
            {
                gameEventSystem.AddListner(OnInvokeGameEvent);
            }
        }

        private void OnInvokeGameEvent(int eventMask)
        {
            StartCoroutine(HandleGameEvent(eventMask));
        }

        private IEnumerator HandleGameEvent(int eventMask)
        {
            yield return new WaitForSeconds(delay);
            var value = (this.eventMask & eventMask) != 0;
            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i] == null)
                    continue;
                if (activationType == ActivationType.GameObject)
                {
                    targets[i].gameObject.SetActive(value);
                }
                else if (activationType == ActivationType.MonoBehaviour)
                {
                    targets[i].enabled = value;
                }
            }
        }

        private void OnDisable()
        {
            if (gameEventSystem != null)
            {
                gameEventSystem.RemoveListner(OnInvokeGameEvent);
            }
        }
    }
}
