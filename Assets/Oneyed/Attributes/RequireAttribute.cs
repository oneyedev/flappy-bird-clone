using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneEyed.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class RequireAttribute : PropertyAttribute
    {
        public readonly string field;
        public readonly object value;

        public RequireAttribute(string field, object value = null)
        {
            this.field = field;
            this.value = value;
        }
    }
}

