using System.Collections.Generic;
using Prefabs.Components.TileMenu;
using UnityEngine;

public class TileMenu : MonoBehaviour
{
#pragma warning disable 649
    [Header("Buttons to use")] [SerializeField]
    private bool upperLeftButtonAvailable = true;

    [SerializeField] private TileMenuButton upperLeft;
    [SerializeField] private Transform upperLeftPivot;
    [SerializeField] private bool upperRightButtonAvailable = true;
    [SerializeField] private TileMenuButton upperRight;
    [SerializeField] private Transform upperRightPivot;
    [SerializeField] private bool lowerLeftButtonAvailable = true;
    [SerializeField] private TileMenuButton lowerLeft;
    [SerializeField] private Transform lowerLeftPivot;
    [SerializeField] private bool lowerRightButtonAvailable = true;
    [SerializeField] private TileMenuButton lowerRight;
    [SerializeField] private Transform lowerRightPivot;
    [SerializeField] private bool middleButtonAvailable = false;
    [SerializeField] private TileMenuButton middle;
    [SerializeField] private Transform middlePivot;
    [SerializeField] private List<TileMenuButton> buttons = new List<TileMenuButton>();
#pragma warning restore 649

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
}