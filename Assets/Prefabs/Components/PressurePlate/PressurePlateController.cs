using System;
using System.Collections;
using System.Collections.Generic;
using Constants;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlateController : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] float massToPress = 0;
    [SerializeField] float returnDelay = 0;
    [SerializeField] Animator animator;
    [SerializeField] UnityEvent OnPress;
    [SerializeField] UnityEvent OnReturn;
    [SerializeField] Vector3 overlapCubeOffset;
    [SerializeField] Vector3 overlapCubeScale = new Vector3(1, 1, 1);
    [SerializeField] int MeasuredWeight = 0;
    [SerializeField] Boolean isPressed = false;
#pragma warning restore 649

    public void OnWeighted(float delayedPress=0) {
        if (isPressed) return;
        //int weightedMass = massToPress > 0 ? measureWeight() : 0;
        int weightedMass = massToPress > 0 ? MeasureWeight() : 0;
        if (weightedMass < massToPress) return;

        isPressed = true;

        Action Down = () => {
            animator.SetBool(triggers.PRESSED, true);            
            };
        //print("Weigted mass: " + weightedMass);
        if (delayedPress > 0) StartCoroutine(delayedAction(Down, delayedPress));
        else Down();
    }

    public void OnWeightRemoved() {
        if (!isPressed) return;
        //int weightedMass = massToPress > 0 ? measureWeight() : 0;
        int weightedMass = massToPress > 0 ? MeasureWeight() : 0;
        if (weightedMass > massToPress) return;

        isPressed = false;

        Action Up = () => {
            animator.SetBool(triggers.PRESSED, false);
        };

        if (returnDelay > 0) StartCoroutine(delayedAction(Up, returnDelay));
        else Up();
    }

    public int MeasureWeight() {
        Collider[] hitObjects = Physics.OverlapBox(transform.position + overlapCubeOffset, overlapCubeScale /2);
        //print("hitObject length: " + hitObjects.Length);
        if (hitObjects.Length == 0) return 0;
        MeasuredWeight = 0;
        foreach (Collider hittedObject in hitObjects) {
            if (hittedObject.GetComponentInParent<WeightOfObject>()) {
                //print("Hitted object " + hittedObject.name + " is WightOfObject and has weight: " + hittedObject.GetComponentInParent<WeightOfObject>().getWeight() + ".");
                MeasuredWeight += (int)hittedObject.GetComponentInParent<WeightOfObject>().getWeight();
            }
        }
        //print("Measured weight: " + MeasuredWeight);
        return MeasuredWeight;
    }

    //public void MeasureWeight() {
    //    Collider[] hitObjects = Physics.OverlapBox(transform.position + overlapCubeOffset, overlapCubeScale / 4);
    //    //print("hitObject length: " + hitObjects.Length);
    //    if (hitObjects.Length == 0) MeasuredWeight = 0;
    //    MeasuredWeight = 0;
    //    foreach (Collider hittedObject in hitObjects) {
    //        if (hittedObject.GetComponentInParent<WeightOfObject>()) {
    //            //print("Hitted object " + hittedObject.name + " is WightOfObject and has weight: " + hittedObject.GetComponentInParent<WeightOfObject>().getWeight() + ".");
    //            MeasuredWeight += (int)hittedObject.GetComponentInParent<WeightOfObject>().getWeight();
    //        }
    //    }
    //    //print("Measured weight: " + MeasuredWeight);
    //    if (!isPressed && MeasuredWeight >= massToPress) OnWeighted(0);
    //    else if (isPressed && MeasuredWeight < massToPress) OnWeightRemoved();
    //}

    IEnumerator delayedAction(Action action, float delay) {
        yield return new WaitForSecondsRealtime(delay);
        action();
    }

    public void OnPressFinished() {
        //print("Pressure plate PRESSED. Invoking OnReturn.");
        OnPress.Invoke();
    }

    public void OnReturnFinished() {
        //print("Pressure plate RETURNED. Invoking OnReturn.");
        OnReturn.Invoke();
    }

    private void OnDrawGizmos() {
        //Gizmos.DrawCube(transform.position + overlapCubeOffset, overlapCubeScale/2);
    }

}
