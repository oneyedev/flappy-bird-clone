using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using OneEyed.Attributes;
using OneEyed.Events;

namespace OneEyed.Editor
{
    [CustomPropertyDrawer(typeof(EnumMaskAttribute), true)]
    public class EnumMaskAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.intValue = EditorGUI.MaskField(position, label, property.intValue, property.enumNames);
        }
    }
}

