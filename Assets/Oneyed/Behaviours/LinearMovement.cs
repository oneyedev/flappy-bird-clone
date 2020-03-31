using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneEyed.Behaviours
{
    public class LinearMovement : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 direction;
        [SerializeField] private float speed;
        [SerializeField] private Space space = Space.Self;

        public Transform Target { get => target; set => target = value; }
        public Vector3 Direction { get => direction; set => direction = value; }
        public float Speed { get => speed; set => speed = value; }
        public Space Space { get => space; set => space = value; }

        void Start()
        {
        }

        void Update()
        {
            Target.Translate(direction * speed * Time.deltaTime, space);
        }
    }

}

