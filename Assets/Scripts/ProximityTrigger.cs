using System;
using System.Collections.Generic;
using Constants;
using UnityEngine;
using UnityEngine.Events;

public class ProximityTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent OnEnterIntoProximity;
    [SerializeField] private UnityEvent OnExitOutOfDistance;
    [SerializeField] private UnityEvent OnStayInProximity;
    [SerializeField] private List<string> AcceptedTags = new List<string>();

    private void Start() {
        AcceptedTags.Add(system.PROXIMITYTRIGGER);
    }

    private void OnTriggerEnter(Collider other) {
        triggerEventOnAcceptedTag(other.tag, () => OnEnterIntoProximity.Invoke(), "Enter");
    }

    private void OnTriggerExit(Collider other) {
        triggerEventOnAcceptedTag(other.tag, () => OnExitOutOfDistance?.Invoke(), "Exit");
    }

    private void OnTriggerStay(Collider other) {
        triggerEventOnAcceptedTag(other.tag, () => OnStayInProximity?.Invoke(), "Stay");
    }

    private void triggerEventOnAcceptedTag(string tagOfTheOther, Action action, string messageText) {
        if (AcceptedTags.Contains(tagOfTheOther)) {
            print("Accepted tag trigger fired on: " + messageText);
            action();
        }
    }
}
