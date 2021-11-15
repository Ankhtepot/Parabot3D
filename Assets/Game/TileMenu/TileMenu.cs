using System;
using System.Collections;
using System.Collections.Generic;
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
        [Header("Used buttons")] [ReadOnly] [SerializeField]
        private bool upperLeftButtonAvailable = true;

        [ReadOnly] [SerializeField] private bool upperRightButtonAvailable;
        [ReadOnly] [SerializeField] private bool lowerLeftButtonAvailable;
        [ReadOnly] [SerializeField] private bool lowerRightButtonAvailable;
        [ReadOnly] [SerializeField] private bool middleButtonAvailable;
        [Header("Buttons")] [SerializeField] private TileMenuButton upperLeft;
        [SerializeField] private TileMenuButton upperRight;
        [SerializeField] private TileMenuButton lowerLeft;
        [SerializeField] private TileMenuButton lowerRight;
        [SerializeField] private TileMenuButton middle;
        [SerializeField] private List<TileMenuButton> buttons = new List<TileMenuButton>();

        [Header("Pivots")] [SerializeField] private Transform upperLeftPivot;
        [SerializeField] private Transform upperRightPivot;
        [SerializeField] private Transform lowerLeftPivot;
        [SerializeField] private Transform lowerRightPivot;
        [SerializeField] private Transform middlePivot;

        [ReadOnly][SerializeField] private bool canBeInvoked = true;

        private void Awake()
        {
            EventBroker.OnTileMenuInvoked += SetUp;
            EventBroker.OnTileMenuDismissed += Dismiss;
        }

        private void Start()
        {
            if (middle)
            {
                if (middleButtonAvailable) buttons.Add(middle);
            }
            else
            {
                if (upperLeft && upperLeftButtonAvailable) buttons.Add(upperLeft);
                if (upperRight && upperRightButtonAvailable) buttons.Add(upperRight);
                if (lowerLeft && lowerLeftButtonAvailable) buttons.Add(lowerLeft);
                if (lowerRight && lowerRightButtonAvailable) buttons.Add(lowerRight);
            }

            if (upperLeft) upperLeft.transform.position = upperLeftPivot.position;
            if (upperRight) upperRight.transform.position = upperRightPivot.position;
            if (lowerLeft) lowerLeft.transform.position = lowerLeftPivot.position;
            if (lowerRight) lowerRight.transform.position = lowerRightPivot.position;
            if (middle) middle.transform.position = middlePivot.position;
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

        public void ChangeLowerLeftButtonAccessibility(bool isAccessible)
        {
            if (isAccessible)
            {
                lowerLeftButtonAvailable = true;
                if (lowerLeft) buttons.Add(lowerLeft);
            }
            else
            {
                lowerLeftButtonAvailable = false;
                if (buttons.Contains(lowerLeft)) buttons.Remove(lowerLeft);
            }
        }

        public void ChangeLowerRightButtonAccessibility(bool isAccessible)
        {
            if (isAccessible)
            {
                lowerRightButtonAvailable = true;
                if (lowerRight) buttons.Add(lowerRight);
            }
            else
            {
                lowerLeftButtonAvailable = false;
                if (buttons.Contains(lowerRight)) buttons.Remove(lowerLeft);
            }
        }

        public void ChangeUpperLeftButtonAccessibility(bool isAccessible)
        {
            if (isAccessible)
            {
                upperRightButtonAvailable = true;
                if (upperLeft) buttons.Add(upperLeft);
            }
            else
            {
                upperRightButtonAvailable = false;
                if (buttons.Contains(upperLeft)) buttons.Remove(upperLeft);
            }
        }

        public void ChangeUpperRightButtonAccessibility(bool isAccessible)
        {
            if (isAccessible)
            {
                upperRightButtonAvailable = true;
                if (upperRight) buttons.Add(upperRight);
            }
            else
            {
                upperRightButtonAvailable = false;
                if (buttons.Contains(upperRight)) buttons.Remove(upperRight);
            }
        }

        public void ChangeMiddleButtonAccessibility(bool isAccessible)
        {
            if (isAccessible)
            {
                middleButtonAvailable = true;
                if (middle) buttons.Add(middle);
            }
            else
            {
                upperRightButtonAvailable = false;
                if (buttons.Contains(middle)) buttons.Remove(middle);
            }
        }
        
        private void SetUp(Vector3 position, TileMenuInvoker setting)
        {
            if (!canBeInvoked) return;

            // Debug.Log("Tile menu invoked.");
        }
        
        private void Dismiss()
        {
            // Debug.Log("Tile menu dismissed.");
        }
    }
}