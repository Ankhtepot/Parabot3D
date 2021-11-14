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
        private static Action<Vector3, IEnumerable<TileMenuButtonSetting>> OnTileMenuInvoked;
        
        //Triggers
        public static void TriggerOnTileMenuInvoked(Vector3 position, IEnumerable<TileMenuButtonSetting> settings) => OnTileMenuInvoked?.Invoke(position, settings);
    }
}
