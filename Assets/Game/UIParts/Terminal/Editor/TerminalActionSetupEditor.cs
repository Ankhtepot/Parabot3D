using UnityEditor;

namespace Game.UIParts.Terminal.Editor
{
    [CustomEditor(typeof(TerminalActionSetup))]
    public class TerminalActionEditor : UnityEditor.Editor
    {
        private SerializedProperty actionType;
        private SerializedProperty operationType;

        // Door action
        private SerializedProperty targetDoor;
        private SerializedProperty unlockOnOpen;
        private SerializedProperty unblockUponOpen;
        private SerializedProperty blockOnOpen;
        private SerializedProperty lockOnClose;
        private SerializedProperty unblockUponClose;
        private SerializedProperty blockOnClose;
        
        //Messages
        private SerializedProperty messageOperationSetting;

        private void OnEnable()
        {
            actionType = serializedObject.FindProperty("actionType");
            operationType = serializedObject.FindProperty("operationType");
            targetDoor = serializedObject.FindProperty("targetDoor");
            unlockOnOpen = serializedObject.FindProperty("unlockOnOpen");
            unblockUponOpen = serializedObject.FindProperty("unblockUponOpen");
            blockOnOpen = serializedObject.FindProperty("blockAfterOpen");
            lockOnClose = serializedObject.FindProperty("lockOnClose");
            unblockUponClose = serializedObject.FindProperty("unblockUponClose");
            blockOnClose = serializedObject.FindProperty("blockAfterClose");
            messageOperationSetting = serializedObject.FindProperty("messageOperationSetting");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(actionType);

            #region Message Action

            if (actionType.enumValueIndex == 1)
            {
                EditorGUILayout.PropertyField(messageOperationSetting);
            }
            
            #endregion Message Action

            #region Operation Action
            
            if (actionType.enumValueIndex == 2)
            {
                EditorGUI.indentLevel += 1;
                EditorGUILayout.PropertyField(operationType);

                if (operationType.enumValueIndex == 1)
                {
                    EditorGUI.indentLevel += 1;
                    EditorGUILayout.PropertyField(targetDoor);

                    if (targetDoor.objectReferenceValue != null)
                    {
                        EditorGUI.indentLevel += 1;
                        
                        EditorGUILayout.LabelField("Open action settings:");
                        EditorGUI.indentLevel += 1;
                        EditorGUILayout.PropertyField(unlockOnOpen);
                        EditorGUILayout.PropertyField(unblockUponOpen);
                        EditorGUILayout.PropertyField(blockOnOpen);
                        EditorGUI.indentLevel -= 1;
                        EditorGUILayout.LabelField("Close action settings:");
                        EditorGUI.indentLevel += 1;
                        EditorGUILayout.PropertyField(lockOnClose);
                        EditorGUILayout.PropertyField(unblockUponClose);
                        EditorGUILayout.PropertyField(blockOnClose);
                        EditorGUI.indentLevel -= 1;
                    }
                    
                    EditorGUI.indentLevel -= 1;
                }
                EditorGUI.indentLevel -= 1;
            }

            #endregion Operation Action


            serializedObject.ApplyModifiedProperties();
        }
    }
}