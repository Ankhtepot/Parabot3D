using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMenu : MonoBehaviour
{
#pragma warning disable 649
    [Header("Buttons to use")]
    [SerializeField] bool upperLeftButtonAvaiable = true;
    [SerializeField] TileMenuButton upperLeft;
    [SerializeField] Transform upperLeftPivot;
    [SerializeField] bool upperRightButtonAvaiable = true;
    [SerializeField] TileMenuButton upperRight;
    [SerializeField] Transform upperRightPivot;
    [SerializeField] bool lowerLeftButtonAvaiable = true;
    [SerializeField] TileMenuButton lowerLeft;
    [SerializeField] Transform lowerLeftPivot;
    [SerializeField] bool lowerRightButtonAvaiable = true;
    [SerializeField] TileMenuButton lowerRight;
    [SerializeField] Transform lowerRightPivot;
    [SerializeField] bool middleButtonAvaiable = false;
    [SerializeField] TileMenuButton middle;
    [SerializeField] Transform middlePivot;
    [SerializeField] List<TileMenuButton> buttons = new List<TileMenuButton>();
#pragma warning restore 649

    private void Start() {
        if(middle) {
            if(middleButtonAvaiable) buttons.Add(middle);
        } else {
            if (upperLeft && upperLeftButtonAvaiable) buttons.Add(upperLeft);
            if (upperRight && upperRightButtonAvaiable) buttons.Add(upperRight);
            if (lowerLeft && lowerLeftButtonAvaiable) buttons.Add(lowerLeft);
            if (lowerRight && lowerRightButtonAvaiable) buttons.Add(lowerRight);
        }
        if (upperLeft) upperLeft.transform.position = upperLeftPivot.position;
        if (upperRight) upperRight.transform.position = upperRightPivot.position;
        if (lowerLeft) lowerLeft.transform.position = lowerLeftPivot.position;
        if (lowerRight) lowerRight.transform.position = lowerRightPivot.position;
        if (middle) middle.transform.position = middlePivot.position;
    }

    public void ShowButtons() {
        foreach(TileMenuButton button in buttons) {
            //print("TileMenu level: buttons showing up");
            button.ShowUp();
        }
    }

    public void HideButtons() {
        foreach (TileMenuButton button in buttons) {
            //print("TileMenu level: hiding buttons");
            button.Hide();
        }
    }

    public void ChangeLowerLeftButtonAccesibility(bool isAccesible) {
        if(isAccesible) {
            lowerLeftButtonAvaiable = true;
            if(lowerLeft) buttons.Add(lowerLeft);
        } else {
            lowerLeftButtonAvaiable = false;
            if(buttons.Contains(lowerLeft)) buttons.Remove(lowerLeft);
        }
    }

    public void ChangeLowerRightButtonAccesibility(bool isAccesible) {
        if (isAccesible) {
            lowerRightButtonAvaiable = true;
            if(lowerRight) buttons.Add(lowerRight);
        } else {
            lowerLeftButtonAvaiable = false;
            if (buttons.Contains(lowerRight)) buttons.Remove(lowerLeft);
        }
    }

    public void ChangeUpperLeftButtonAccesibility(bool isAccesible) {
        if (isAccesible) {
            upperRightButtonAvaiable = true;
            if (upperLeft) buttons.Add(upperLeft);
        } else {
            upperRightButtonAvaiable = false;
            if (buttons.Contains(upperLeft)) buttons.Remove(upperLeft);
        }
    }

    public void ChangeUpperRightButtonAccesibility(bool isAccesible) {
        if (isAccesible) {
            upperRightButtonAvaiable = true;
            if (upperRight) buttons.Add(upperRight);
        } else {
            upperRightButtonAvaiable = false;
            if (buttons.Contains(upperRight)) buttons.Remove(upperRight);
        }
    }

    public void ChangeMiddleButtonAccesibility(bool isAccesible) {
        if (isAccesible) {
            middleButtonAvaiable = true;
            if (middle) buttons.Add(middle);
        } else {
            upperRightButtonAvaiable = false;
            if (buttons.Contains(middle)) buttons.Remove(middle);
        }
    }
}
