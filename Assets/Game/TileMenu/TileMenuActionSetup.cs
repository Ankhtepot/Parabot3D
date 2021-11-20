using System;
using System.Collections.Generic;
using Attributes;
using Game.UI_parts.Terminal;
using UnityEngine;

namespace Game.TileMenu
{
    public class TileMenuActionSetup : MonoBehaviour
    {
        public ETileMenuActionType typeOfAction = ETileMenuActionType.None;

        public List<TerminalActionSetup> terminalActions = new List<TerminalActionSetup>();
        
    }
}