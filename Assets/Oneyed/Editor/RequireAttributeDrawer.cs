using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using OneEyed.Attributes;
using OneEyed.Events;

namespace OneEyed.Editor
{
    [CustomPropertyDrawer(typeof(RequireAttribute), true)]
    public class RequireAttributeDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return HasRequireValue(property) ? EditorGUI.GetPropertyHeight(property, label) : 0;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (HasRequireValue(property))
            {
                EditorGUI.PropertyField(position, property, label);
            }
        }

        private bool HasRequireValue(SerializedProperty property)
        {
            var require = attribute as RequireAttribute;
            var requireProperty = property.serializedObject.FindProperty(require.field);
            var actualValue = GetValue(requireProperty);
            return actualValue != null && actualValue.Equals(require.value);
        }

        private object GetValue(SerializedProperty property)
        {
            if (property.propertyType == SerializedPropertyType.Boolean)
                return property.boolValue;
            if (property.propertyType == SerializedPropertyType.Float)
                return property.floatValue;
            if (property.propertyType == SerializedPropertyType.String)
                return property.stringValue;
            if (property.propertyType == SerializedPropertyType.Integer)
                return property.intValue;
            if (property.propertyType == SerializedPropertyType.Color)
                return property.colorValue;
            if (property.propertyType == SerializedPropertyType.Vector3)
                return property.vector3Value;
            if (property.propertyType == SerializedPropertyType.Vector3Int)
                return property.vector3IntValue;
            if (property.propertyType == SerializedPropertyType.Vector2)
                return property.vector2Value;
            if (property.propertyType == SerializedPropertyType.Vector2Int)
                return property.vector2IntValue;
            if (property.propertyType == SerializedPropertyType.Vector4)
                return property.vector4Value;
            if (property.propertyType == SerializedPropertyType.ExposedReference)
                return property.exposedReferenceValue;
            if (property.propertyType == SerializedPropertyType.ObjectReference)
                return property.objectReferenceValue;
            if (property.propertyType == SerializedPropertyType.Rect)
                return property.rectValue;
            if (property.propertyType == SerializedPropertyType.RectInt)
                return property.rectIntValue;
            if (property.propertyType == SerializedPropertyType.Quaternion)
                return property.quaternionValue;
            return property.objectReferenceValue;
        }
    }
}

