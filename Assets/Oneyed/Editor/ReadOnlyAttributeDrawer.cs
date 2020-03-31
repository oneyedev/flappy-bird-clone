using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using OneEyed.Attributes;

namespace OneEyed.Editor
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute), true)]
    public class ReadOnlyAttributeDrawer : PropertyDrawer
    {
        // Necessary since some properties tend to collapse smaller than their content
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        // Draw a disabled property field
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = ToBeEditable(property);
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }

        private bool ToBeEditable(SerializedProperty property)
        {
            var attr = attribute as ReadOnlyAttribute;
            var path = property.propertyPath.Replace(property.name, attr.field);
            var conditionProperty = property.serializedObject.FindProperty(path);
            if (conditionProperty == null)
                return false;
            if (conditionProperty.propertyType == SerializedPropertyType.Enum)
                return conditionProperty.intValue != (int)attr.value;
            if (conditionProperty.propertyType == SerializedPropertyType.Boolean)
                return conditionProperty.boolValue != (bool)attr.value;
            return true;
        }
    }
}

