using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JumpLandReceiver : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] UnityEvent OnJumpLandReceived;
#pragma warning restore 649

    public void OnJumpLand() {
        //print("JumpLandReceiver: OnJumpLand Invoking");
        OnJumpLandReceived.Invoke();
    }
}
