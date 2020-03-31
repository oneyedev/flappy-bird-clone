using UnityEngine;
using System;

namespace OneEyed.Extensions
{
    public static class LayerMaskExtension
    {
        public static bool IsSet(this LayerMask mask, LayerMask layer)
        {
            return (mask & layer) == layer;
        }

        public static bool IsSet(this LayerMask mask, int layer)
        {
            var target = new LayerMask();
            target.value = 1 << layer;
            return IsSet(mask, target);
        }

        public static bool IsUnset(this LayerMask mask, LayerMask layer)
        {
            return (mask & layer) != layer;
        }

        public static bool IsUnset(this LayerMask mask, int layer)
        {
            var target = new LayerMask();
            target.value = 1 << layer;
            return IsUnset(mask, target);
        }
    }

}

