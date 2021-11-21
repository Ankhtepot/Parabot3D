using System.Collections;
using System.Collections.Generic;
using Triggers;
using UnityEngine;
using UnityEngine.Events;

public class RollOverController : MonoBehaviour, IRollOverReceiver {
#pragma warning disable 649
    [SerializeField] UnityEvent OnSwitched;
    [SerializeField] UnityEvent OffSwitched;
    [SerializeField] GameObject switchModelGameObject;
    [SerializeField] Color offStateColor;
    [SerializeField] Color onStateColor;
#pragma warning restore 649
    [SerializeField] bool isOnlyFromOffToOn = true;
    [SerializeField] public bool stateOfSwitch = false;

    public void OnRollOver() {
        if (isOnlyFromOffToOn || !stateOfSwitch) switchingOn();
        else if (stateOfSwitch) switchingOff();
    }

    private void switchingOn() {
        stateOfSwitch = true;
        switchModelGameObject.GetComponent<Renderer>().materials[2].color = onStateColor;
        OnSwitched.Invoke();
    }

    private void switchingOff() {
        stateOfSwitch = false;
        switchModelGameObject.GetComponent<Renderer>().materials[2].color = offStateColor;
        OffSwitched.Invoke();
    }
}
