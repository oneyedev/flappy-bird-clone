using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using OneEyed.Events;

namespace OneEyed.Editor
{
    [CustomPropertyDrawer(typeof(GameEventMask))]
    public class GameEventMaskPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            var mask = attribute as GameEventMask;
            var refer = GetRefer(property, mask);
            if (refer == null)
            {
                string message = string.Format("There is no {0} <{1}>", mask.refer, typeof(GameEventSystem));
                EditorGUI.HelpBox(position, message, MessageType.Warning);
            }
            else
            {
                var layers = ReferToLayers(refer);
                property.intValue = EditorGUI.MaskField(position, label, property.intValue, layers);
            }
            EditorGUI.EndProperty();
        }

        Object GetRefer(SerializedProperty property, GameEventMask mask)
        {
            if (string.IsNullOrEmpty(mask.refer))
                return property.serializedObject.targetObject;
            var eventSystemProperty = property.serializedObject.FindProperty(mask.refer);
            if (eventSystemProperty == null)
                return null;
            return eventSystemProperty.objectReferenceValue;
        }

        string[] ReferToLayers(Object refer)
        {
            var layers = new string[32];
            var children = AssetDatabase.LoadAllAssetRepresentationsAtPath(AssetDatabase.GetAssetPath(refer));
            foreach (var child in children)
            {
                var no = int.Parse(child.name.Substring(0, 2));
                layers[no] = child.name;
            }
            return layers;
        }

        int layersToMaskValue(string[] layers)
        {
            var result = 0;
            for (int i = 0; i < layers.Length; i++)
            {
                var no = int.Parse(layers[i].Substring(0, 2));
                result |= 1 << no;
            }
            return result;
        }
    }
}
