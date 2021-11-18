using System;
using System.Collections.Generic;
using Game.TileMenu;
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
        
        //Triggers
        public static void TriggerOnTileMenuInvoked(Vector3 position, TileMenuInvoker setting) => OnTileMenuInvoked?.Invoke(position, setting);
        public static void TriggerOnTileMenuDismissed() => OnTileMenuDismissed?.Invoke();
        public static void TriggerOnInfoTextInvoked(string text, UnityAction action) => OnInfoTextInvoked?.Invoke(text, action);
    }
}
