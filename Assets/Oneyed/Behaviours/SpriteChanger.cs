using UnityEngine;
using UnityEngine.U2D;

using System.Collections;
using System.Collections.Generic;
using System;
using OneEyed.Attributes;

namespace OneEyed.Behaviours
{
    public class SpriteChanger : MonoBehaviour
    {
        public SpriteRenderer target;
        public bool readFromAtlas;
        [Require("readFromAtlas", true)] public SpriteAtlas atlas;

        public float speed;
        public float index;
        public Sprite[] sprites;

        private void Awake()
        {
            if (readFromAtlas)
            {
                sprites = new Sprite[atlas.spriteCount];
                atlas.GetSprites(sprites);
                Array.Sort(sprites, (s1, s2) => string.Compare(s1.name, s2.name, StringComparison.Ordinal));
            }
        }

        private void Update()
        {
            if (sprites.Length == 0)
                return;
            index += Time.deltaTime * speed;
            target.sprite = sprites[Mathf.FloorToInt(index) % sprites.Length];
        }

        public void ChangeTo(Sprite sprite)
        {
            target.sprite = sprite;
        }

        public void MoveNext()
        {
            if (sprites.Length == 0)
                return;
            target.sprite = sprites[Mathf.FloorToInt(++index) % sprites.Length];
        }
    }
}
