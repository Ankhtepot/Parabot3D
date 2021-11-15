using System;
using System.Collections.Generic;
using Game.TileMenu;
using UnityEngine;
using UnityEngine.Events;

namespace Services
{
    public static class EventBroker
    {
        //Events
        public static Action<Vector3, TileMenuInvoker> OnTileMenuInvoked;
        public static Action OnTileMenuDismissed;
        
        //Triggers
        public static void TriggerOnTileMenuInvoked(Vector3 position, TileMenuInvoker settings) => OnTileMenuInvoked?.Invoke(position, settings);

        public static void TriggerOnTileMenuDismissed() => OnTileMenuDismissed?.Invoke();
    }
}
