using System;
using System.Collections.Generic;
using Game.TileMenu;
using Game.UIParts.Terminal;
using Player;
using UnityEngine;
using UnityEngine.Events;

namespace Services
{
    public static class EventBroker
    {
        //Events
        public static Action<Vector3, TileMenuInvoker> OnTileMenuInvoked;
        public static Action OnTileMenuDismissed;
        public static UnityAction<string, UnityAction> OnInfoTextInvoked;
        public static UnityAction<IEnumerable<TerminalActionSetup>> OnTerminalInvoked;
        public static UnityAction OnTerminalDismissed;
        
        //Triggers
        // TileMenu Triggers 
        public static void TriggerOnTileMenuInvoked(Vector3 position, TileMenuInvoker setting) => OnTileMenuInvoked?.Invoke(position, setting);
        public static void TriggerOnTileMenuDismissed() => OnTileMenuDismissed?.Invoke();
        // InfoText Triggers
        public static void TriggerOnInfoTextInvoked(string text, UnityAction action) => OnInfoTextInvoked?.Invoke(text, action);
        // Terminal Triggers
        public static void TriggerOnTerminalInvoked(IEnumerable<TerminalActionSetup> actions) => OnTerminalInvoked?.Invoke(actions);
        public static void TriggerOnTerminalDismissed() => OnTerminalDismissed?.Invoke();
    }
}
