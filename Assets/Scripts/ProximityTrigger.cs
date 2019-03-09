using Assets.Scripts.Constants;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProximityTrigger : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] UnityEvent OnEnterIntoProximity;
    [SerializeField] UnityEvent OnExitOutOfDistance;
    [SerializeField] UnityEvent OnStayInProximity;
#pragma warning restore 649
    [SerializeField] List<string> AcceptedTags = new List<string>();

    private void Start() {
        AcceptedTags.Add(system.PROXIMITYTRIGGER);
    }

    private void OnTriggerEnter(Collider other) {
        triggerEventOnAcceptedTag(other.tag, FireOnEnter, "Enter");
    }

    private void OnTriggerExit(Collider other) {
        triggerEventOnAcceptedTag(other.tag, FireOnExit, "Exit");
    }

    private void OnTriggerStay(Collider other) {
        triggerEventOnAcceptedTag(other.tag, FireOnStay, "Stay");
    }

    private void triggerEventOnAcceptedTag(string tag, Action action, string messageText = "noText") {
        if (AcceptedTags.Contains(tag)) {
            //print("Accepted tag trigger fired on: " + messageText);
            action();
        }
    }

    public void FireOnEnter() {
        OnEnterIntoProximity.Invoke();
    }

    public void FireOnExit() {
        OnExitOutOfDistance.Invoke();
    }

    public void FireOnStay() {
        OnStayInProximity.Invoke();
    }

}
