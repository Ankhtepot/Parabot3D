using System;
using Attributes;
using ScriptableObjects;
using Services;
using UnityEngine;
using UnityEngine.Events;

namespace Game.TileMenu
{
    public class InfoTileMenuButton : TileMenuButton
    {
        [ReadOnly, SerializeField] private InfoText infoText;
        private UnityAction postDismissAction;
        
        protected override void OnMouseDown()
        {
            EventBroker.TriggerOnInfoTextInvoked(infoText.Text, postDismissAction);
        }

        public void Set(InfoText settingInfoText, UnityAction settingPostDismissAction)
        {
            infoText = settingInfoText;
            postDismissAction = settingPostDismissAction;
        }
    }
}