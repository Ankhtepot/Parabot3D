using System.Collections;
using System.Collections.Generic;
using Constants;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class OpeningDoorActionTab : MonoBehaviour {
#pragma warning disable 649
    [SerializeField] Animator animator;
    [SerializeField] ButtonUI_Simple openButton;
    [SerializeField] ButtonUI_Simple closeButton;
    [SerializeField] TextMeshProUGUI LabelTMP;
    [SerializeField] LabelTextProvider labelTextProvider;
    [SerializeField] UnityEvent OnOpen;
    [SerializeField] UnityEvent OnClose;
#pragma warning restore 649

    private void Start() {
        openButton.setNonActiveColorsForChangableImages();
        closeButton.SetActiveColorForChangableImages();
        LabelTMP.text = labelTextProvider.GetText();
    }

    public void OpenDoors() {
        animator.SetBool(triggers.OPEN, true);
        OnOpen.Invoke();
    }

    public void CloseDoors() {
        animator.SetBool(triggers.OPEN, false);
        OnClose.Invoke();
    }

    public void setButtonsDisabled() {
        openButton.Disable();
        closeButton.Disable();
    }

    public void setButtonsEnabled() {
        //print("Setting buttons Enabled");
        openButton.Enable();
        closeButton.Enable();
    }
}
