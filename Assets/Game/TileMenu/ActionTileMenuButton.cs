using System;
using Services;
using UnityEngine;

namespace Game.TileMenu
{
    public enum ETileMenuActionType
    {
        None = 0,
        InvokeTerminal = 1,
    }
    public class ActionTileMenuButton : TileMenuButton
    {
        private TileMenuActionSetup setup;
        
        protected override void OnMouseDown()
        {
            if (!setup)
            {
                Debug.LogWarning("Action button was not set up.");
                return;
            };
            
            switch (setup.typeOfAction)
            {
                case ETileMenuActionType.None:
                    break;
                case ETileMenuActionType.InvokeTerminal:
                    EventBroker.TriggerOnTerminalInvoked(setup.terminalActions);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public void Set(TileMenuActionSetup newSetup)
        {
            setup = newSetup;
            switch (setup.typeOfAction)
            {
                case ETileMenuActionType.None:
                    break;
                case ETileMenuActionType.InvokeTerminal:
                    OnPress.AddListener(() => EventBroker.TriggerOnTerminalInvoked(setup.terminalActions));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}