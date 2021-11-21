using System;
using Game.CombinedTilesSimple.SlidingDoors;
using ScriptableObjects;
using UnityEngine;

namespace Game.UIParts.Terminal
{
    public enum ETerminalActionType
    {
        None = 0,
        Message = 1,
        Operation = 2,
    }

    public enum ETerminalOperationType
    {
        None = 0,
        OpenDoor = 1
    }

    public class TerminalActionSetup : MonoBehaviour
    {
        public ETerminalActionType actionType = ETerminalActionType.None;

        //Operations
        public ETerminalOperationType operationType = ETerminalOperationType.None;
        //OpenDoors
        public OpenDoorOperationSetting openDoorOperationSetting;
        //Messages
        public MessageOperationSetting messageOperationSetting;

        [Serializable]
        public class MessageOperationSetting
        {
            public LabelText messageFrom;
            public LabelText messageTo;
            public InfoText messageText;
        }
        
        [Serializable]
        public class OpenDoorOperationSetting
        {
            public DoorController targetDoor;
            public LabelText location;
            public Transform cameraHolder;
            //Set on Open
            public bool unlockOnOpen = true;
            public bool unblockUponOpen;
            public bool blockAfterOpen;
            //Set on Close
            public bool closeAndLock = true;
            public bool unblockUponClose;
            public bool blockAfterClose;
        }
    }
}