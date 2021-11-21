using Attributes;
using Game.CombinedTilesSimple.SlidingDoors;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UIParts.Terminal
{
    public class DoorsOperationItemController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI doorsLocationAtLabelTMP;
        [SerializeField] private LabelText doorsAtLocationAtText;
        [SerializeField] private TextMeshProUGUI doorsLocationTMP;
        [SerializeField] private ButtonController openButton;
        [SerializeField] private ButtonController closeButton;
        [SerializeField] private GameObject cameraHolder;
        [SerializeField] private RawImage cameraTargetImage;
        [ReadOnly] [SerializeField] private DoorController doorController;

        public void Set(TerminalActionSetup settings)
        {
            if (settings.operationType != ETerminalOperationType.OpenDoor) return;
        }

    }
}
