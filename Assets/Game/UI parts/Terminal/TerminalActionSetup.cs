using System;
using Attributes;
using Game.Combined_tiles_simple._1tileWide2sidesSlidingDoor;
using UnityEngine;

namespace Game.UI_parts.Terminal
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
            public DoorController targetDoor;
                //Set on Open
                public bool unlockOnOpen = true;
                public bool unblockUponOpen;
                public bool blockAfterOpen;
                //Set on Close
                public bool lockOnClose = true;
                public bool unblockUponClose;
                public bool blockAfterClose;
    }
}