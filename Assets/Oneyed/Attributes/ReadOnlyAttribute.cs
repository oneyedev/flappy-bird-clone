using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OneEyed.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ReadOnlyAttribute : PropertyAttribute
    {
        public readonly string field;
        public readonly object value;

        public ReadOnlyAttribute(string field = null, object value = null)
        {
            this.field = field;
            this.value = value;
        }
    }
}

