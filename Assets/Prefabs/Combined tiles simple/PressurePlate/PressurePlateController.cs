using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlateController : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] int massToPress = 0;
    [SerializeField] float returnDelay = 0;
    [SerializeField] Animator animator;
    [SerializeField] UnityEvent OnPress;
    [SerializeField] UnityEvent OnReturn;
#pragma warning restore 649

    

    public void OnWeighted(float delayedPress=0) {
        int weightedMass = massToPress > 0 ? measureWeight() : 0;
        if (weightedMass < massToPress) return;

        Action Down = () => {
            animator.SetBool(triggers.PRESSED, true);            
            };

        if (delayedPress > 0) StartCoroutine(delayedAction(Down, delayedPress));
        else Down();
    }

    public void OnWeightRemoved() {
        int weightedMass = massToPress > 0 ? measureWeight() : 0;
        if (weightedMass > massToPress) return;

        Action Up = () => {
            animator.SetBool(triggers.PRESSED, false);
        };

        if (returnDelay > 0) StartCoroutine(delayedAction(Up, returnDelay));
        else Up();
    }

    private int measureWeight() {
        return 0;
    }

    IEnumerator delayedAction(Action action, float delay) {
        yield return new WaitForSecondsRealtime(delay);
        action();
    }

    public void OnPressFinished() {
        OnPress.Invoke();
    }

    public void OnReturnFinished() {
        OnReturn.Invoke();
    }

}
