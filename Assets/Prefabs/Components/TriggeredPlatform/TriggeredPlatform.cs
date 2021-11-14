using System.Collections;
using System.Collections.Generic;
using Constants;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TriggeredPlatform : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] Animator animator;
#pragma warning restore 649

    public void MoveToTriggeredPosition() {
        animator.SetBool(triggers.ACTIVATE, true);
    }

    public void MoveBackToIdlePosition() {
        animator.SetBool(triggers.ACTIVATE, false);
    }
}
