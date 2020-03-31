using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using OneEyed.Events;

namespace OneEyed.Editor
{
    [CustomEditor(typeof(GameEventSystem))]
    public class GameEventSystemEditor : UnityEditor.Editor
    {
        Object[] children = new Object[32];
        GameEventSystem gameEventSystem;

        private void OnEnable()
        {
            readChildren();
            gameEventSystem = target as GameEventSystem;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            base.OnInspectorGUI();
            // var layers = serializedObject.FindProperty("layers");
            // for (int i = 0; i < 32; i++)
            // {
            //     var property = layers.GetArrayElementAtIndex(i);
            //     layers.GetArrayElementAtIndex(i).stringValue = EditorGUILayout.TextField("Event Layer " + i, layers.GetArrayElementAtIndex(i).stringValue);
            // }
            // EditorGUILayout.PropertyField(serializedObject.FindProperty("current"));
            // EditorGUILayout.PropertyField(serializedObject.FindProperty("logging"));
            if (GUILayout.Button("Save"))
            {
                Save();
            }
            if (GUILayout.Button("Raise Event"))
            {
                gameEventSystem.RaiseEvent(gameEventSystem.current);
            }
            serializedObject.ApplyModifiedProperties();
        }

        public void readChildren()
        {
            var loaded = AssetDatabase.LoadAllAssetRepresentationsAtPath(AssetDatabase.GetAssetPath(target));
            for (int i = 0; i < loaded.Length; i++)
            {
                var target = loaded[i];
                var no = GetEventLayer(target);
                var name = GetEventName(target);
                children[no] = target;
                serializedObject.FindProperty("layers").GetArrayElementAtIndex(no).stringValue = name;
            }
        }

        private string GetEventName(Object target)
        {
            if (target == null)
                return string.Empty;
            return target.name.Substring(4);
        }

        private int GetEventLayer(Object target)
        {
            if (target == null)
                return -1;
            return int.Parse(target.name.Substring(0, 2));
        }

        private void Save()
        {
            var layers = serializedObject.FindProperty("layers");
            for (int i = 0; i < 32; i++)
            {
                var newLayer = layers.GetArrayElementAtIndex(i).stringValue;
                if (string.IsNullOrEmpty(newLayer))
                {
                    if (children[i] != null)
                    {
                        AssetDatabase.RemoveObjectFromAsset(children[i]);
                    }
                }
                else
                {
                    if (children[i] == null)
                    {
                        children[i] = GameEventType.Create(i);
                        AssetDatabase.AddObjectToAsset(children[i], target);
                    }
                    children[i].name = string.Format("{0:D2}. {1}", i, newLayer);
                }
            }
            AssetDatabase.SaveAssets();
        }
    }
}
