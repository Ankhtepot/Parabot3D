using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Attributes;
using Services;
using UnityEngine;

namespace Game.TileMenu
{
    public enum ETileMenuButtonPosition
    {
        UpperLeft,
        UpperRight,
        LowerLeft,
        LowerRight,
        Middle
    }

    public class TileMenu : MonoBehaviour
    {
        [Header("Buttons")] 
        [SerializeField] private InfoTileMenuButton infoButton;
        [SerializeField] private GameObject actionButton;
        [Header("Pivots")] 
        [SerializeField] private Transform upperLeftPivot;
        [SerializeField] private Transform upperRightPivot;
        [SerializeField] private Transform lowerLeftPivot;
        [SerializeField] private Transform lowerRightPivot;
        [SerializeField] private Transform middlePivot;

        [Header("Other assignables")] 
        [SerializeField] private GameObject root;
        [SerializeField] private Transform buttonStore;

        [ReadOnly][SerializeField] private bool canBeInvoked = true;

        private readonly List<TileMenuButton> buttons = new List<TileMenuButton>();
        private readonly Dictionary<ETileMenuButtonPosition, Transform> buttonPivots = new Dictionary<ETileMenuButtonPosition, Transform>();

        private void Awake()
        {
            EventBroker.OnTileMenuInvoked += SetUp;
            EventBroker.OnTileMenuDismissed += Dismiss;
            
            buttonPivots.Add(ETileMenuButtonPosition.UpperLeft, upperLeftPivot);
            buttonPivots.Add(ETileMenuButtonPosition.UpperRight, upperRightPivot);
            buttonPivots.Add(ETileMenuButtonPosition.LowerLeft, lowerLeftPivot);
            buttonPivots.Add(ETileMenuButtonPosition.LowerRight, lowerRightPivot);
            buttonPivots.Add(ETileMenuButtonPosition.Middle, middlePivot);
        }

        public void ShowButtons()
        {
            foreach (var button in buttons)
            {
                //print("TileMenu level: buttons showing up");
                button.ShowUp();
            }
        }

        public void HideButtons()
        {
            foreach (var button in buttons)
            {
                //print("TileMenu level: hiding buttons");
                button.Hide();
            }
        }

        private void SetUp(Vector3 position, TileMenuInvoker setting)
        {
            if (!canBeInvoked) return;

            root.SetActive(true);
            transform.position = position;

            if (setting.UseInfoButton)
            {
                infoButton.transform.parent = buttonPivots[setting.InfoButtonPosition];
                infoButton.Set(setting.InfoText, null);
                buttons.Add(infoButton);
            }

            foreach (var button in buttons)
            {
                button.ShowUp();
            }
        }
        
        private void Dismiss()
        {
            foreach (var button in buttons)
            {
                button.Hide();
            }

            StartCoroutine(RunAfterDismissCleaning());
        }

        private IEnumerator RunAfterDismissCleaning()
        {
            yield return new WaitForSeconds(1f);
            
            foreach (var child in buttons.Select(button => button.transform))
            {
                child.parent = buttonStore;
            }
            
            buttons.Clear();
            
            root.SetActive(false);
        }
    }
}