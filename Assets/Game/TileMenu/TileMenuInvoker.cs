using Attributes;
using Services;
using UnityEngine;

namespace Game.TileMenu
{
    public class TileMenuInvoker : MonoBehaviour
    {
        [SerializeField] private ProximityTrigger proximityTrigger;
        [Header("TileMenuSettings")]
        [SerializeField] private bool useInfoButton;
        [ShowWhen("useInfoButton", true)]
        [SerializeField] private ETileMenuButtonPosition infoButtonPosition = ETileMenuButtonPosition.Middle;
        [ShowWhen("useInfoButton", true)] 
        [SerializeField] private InfoText infoText;
        
        [SerializeField] private bool useActionButton;
        [ShowWhen("useActionButton", true)]
        [SerializeField] private ETileMenuButtonPosition actionButtonPosition = ETileMenuButtonPosition.Middle;
        [ShowWhen("useActionButton", true)]
        [SerializeField] private TileMenuActionSetup actionButtonSetup;


        public bool UseInfoButton => useInfoButton;
        public ETileMenuButtonPosition InfoButtonPosition => infoButtonPosition;
        public bool UseActionButton => useActionButton;
        public ETileMenuButtonPosition ActionButtonPosition => actionButtonPosition;
        public InfoText InfoText => infoText;
        public TileMenuActionSetup ActionButtonSetup => actionButtonSetup;

        private void OnEnable()
        {
            proximityTrigger.OnEnterIntoProximity.AddListener(InvokeTileMenu);
        }

        public void InvokeTileMenu()
        {
            EventBroker.TriggerOnTileMenuInvoked(transform.position, this);
        }

        public void DismissTileMenu()
        {
            if (useActionButton && actionButtonSetup.typeOfAction == ETileMenuActionType.InvokeTerminal)
            {
                EventBroker.TriggerOnTerminalDismissed();
            }
            EventBroker.TriggerOnTileMenuDismissed();
        }
        
        //TODO: Test whn middle button is selected, that only that one button is to be used
        //TODO: If no middle button is selected, check uniqueness of positions for buttons
        private void OnDisable()
        {
            proximityTrigger.OnExitOutOfDistance.AddListener(DismissTileMenu);
        }
    }
}
