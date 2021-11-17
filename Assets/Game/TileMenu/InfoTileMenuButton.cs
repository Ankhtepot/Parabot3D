using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.TileMenu
{
    public class InfoTileMenuButton : TileMenuButton
    {
        [SerializeField] private InfoTextInvoker textInvoker;

        public void Set(InfoTextProvider textProvider, UnityAction postDismissAction)
        {
            textInvoker.Set(textProvider, postDismissAction);
        }
    }
}