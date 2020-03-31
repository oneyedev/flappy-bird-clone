using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OneEyed.Events
{
    public class GameEventMask : PropertyAttribute
    {
        public string refer;

        public GameEventMask() { }

        public GameEventMask(string refer = "gameEventSystem")
        {
            this.refer = refer;
        }
    }
}
