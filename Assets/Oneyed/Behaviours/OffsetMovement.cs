using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneEyed.Behaviours
{
    public class OffsetMovement : MonoBehaviour
    {
        public Material target;
        [SerializeField] private string textureName = "_MainTex";
        [SerializeField] private float speedX;
        [SerializeField] private float speedY;
        public Vector2 offset;

        public float SpeedX { get => speedX; set => speedX = value; }
        public float SpeedY { get => speedY; set => speedY = value; }

        private void Start()
        {
            target.SetTextureOffset(textureName, Vector2.zero);
        }

        private void Update()
        {
            target.SetTextureOffset(textureName, new Vector2(Time.time * speedX, Time.time * speedY));
            offset = target.GetTextureOffset(textureName);
        }

        private void OnDestroy()
        {
            target.SetTextureOffset(textureName, Vector2.zero);
        }
    }
}
