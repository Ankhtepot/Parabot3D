using Attributes;
using Services;
using UnityEngine;
using UnityEngine.Events;

namespace Game.TileMenu
{
    public class TileMenuInvoker : MonoBehaviour
    {
        [Header("TileMenuSettings")]
        [SerializeField] private bool useInfoButton;
        [DrawIf("useInfoButton", true)]
        [Header("Info Button Settings:")]
        [DrawIf("useInfoButton", true)]
        [SerializeField] private ETileMenuButtonPosition infoButtonPosition = ETileMenuButtonPosition.Middle;
        [DrawIf("useInfoButton", true)] 
        [SerializeField] private InfoTextProvider infoTextProvider;
        [DrawIf("useInfoButton", true)] 
        private UnityAction postDismissAction;
        
        [SerializeField] private bool useActionButton;
        [DrawIf("useActionButton", true)]
        [SerializeField] private ETileMenuButtonPosition actionButtonPosition = ETileMenuButtonPosition.Middle;

        public bool UseInfoButton => useInfoButton;
        public ETileMenuButtonPosition InfoButtonPosition => infoButtonPosition;
        public bool UseActionButton => useActionButton;
        public ETileMenuButtonPosition ActionButtonPosition => actionButtonPosition;
        public InfoTextProvider InfoTextProvider => infoTextProvider;
        public UnityAction PostDismissAction => postDismissAction;

        public void InvokeTileMenu()
        {
            EventBroker.TriggerOnTileMenuInvoked(transform.position, this);
        }

        public void DismissTileMenu()
        {
            EventBroker.TriggerOnTileMenuDismissed();
        }
        
        //TODO: Test whn middle button is selected, that only that one button is to be used
        //TODO: If no middle button is selected, check uniqueness of positions for buttons
    }
}
