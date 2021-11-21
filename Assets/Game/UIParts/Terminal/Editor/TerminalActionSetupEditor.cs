using UnityEditor;

namespace Game.UIParts.Terminal.Editor
{
    [CustomEditor(typeof(TerminalActionSetup))]
    public class TerminalActionEditor : UnityEditor.Editor
    {
        private SerializedProperty actionType;
        private SerializedProperty operationType;

        private SerializedProperty openDoorOperationSetting;
        private SerializedProperty messageOperationSetting;

        private void OnEnable()
        {
            actionType = serializedObject.FindProperty("actionType");
            operationType = serializedObject.FindProperty("operationType");
            openDoorOperationSetting = serializedObject.FindProperty("openDoorOperationSetting");
            messageOperationSetting = serializedObject.FindProperty("messageOperationSetting");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(actionType);

            #region Message Action

            if (actionType.enumValueIndex == 1) // ETerminalActionType.Message
            {
                EditorGUILayout.PropertyField(messageOperationSetting);
            }
            
            #endregion Message Action

            #region Operation Action
            
            if (actionType.enumValueIndex == 2) // ETerminalActionType.Operation
            {
                EditorGUI.indentLevel += 1;
                EditorGUILayout.PropertyField(operationType);

                if (operationType.enumValueIndex == 1) // ETerminalOperationType.OpenDoor
                {
                    EditorGUILayout.PropertyField(openDoorOperationSetting);
                }
                EditorGUI.indentLevel -= 1;
            }

            #endregion Operation Action


            serializedObject.ApplyModifiedProperties();
        }
    }
}