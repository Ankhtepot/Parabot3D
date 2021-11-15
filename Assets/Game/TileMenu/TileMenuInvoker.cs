using Attributes;
using Services;
using UnityEngine;

namespace Game.TileMenu
{
    public class TileMenuInvoker : MonoBehaviour
    {
        [Header("TileMenuSettings")]
        [SerializeField] private bool useInfoButton;
        [DrawIf("useInfoButton", true)]
        [SerializeField] private ETileMenuButtonPosition infoButtonPosition = ETileMenuButtonPosition.Middle;
        [SerializeField] private bool useActionButton;
        [DrawIf("useActionButton", true)]
        [SerializeField] private ETileMenuButtonPosition actionButtonPosition = ETileMenuButtonPosition.Middle;

        public bool UseInfoButton => useInfoButton;
        public ETileMenuButtonPosition InfoButtonPosition => infoButtonPosition;
        public bool UseActionButton => useActionButton;
        public ETileMenuButtonPosition ActionButtonPosition => actionButtonPosition;

        public void InvokeTileMenu()
        {
            EventBroker.TriggerOnTileMenuInvoked(transform.position, this);
        }

        public void DismissTileMenu()
        {
            EventBroker.TriggerOnTileMenuDismissed();
        }
    }
}
