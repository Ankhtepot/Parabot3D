using System;
using System.ComponentModel;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

namespace Game.TileMenu.Editor
{
    [CustomEditor(typeof(TileMenuActionSetup))]
    public class TileMenuActionSetupEditor : UnityEditor.Editor
    {
        private SerializedProperty typeOfAction;
        private SerializedProperty terminalActions;
        
        private void OnEnable()
        {
            typeOfAction = serializedObject.FindProperty("typeOfAction");
            terminalActions = serializedObject.FindProperty("terminalActions");
        }
    
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
    
            EditorGUILayout.PropertyField(typeOfAction);
    
            var tOa = typeOfAction;
    
            if (typeOfAction.enumValueIndex == 1)
            {
                EditorGUILayout.PropertyField(terminalActions, true);
            }
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}
