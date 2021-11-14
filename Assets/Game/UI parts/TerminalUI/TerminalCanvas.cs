using System.Collections;
using System.Collections.Generic;
using Constants;
using UnityEngine;

public class TerminalCanvas : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] Animator animator;
#pragma warning restore 649

    public void Show() {
        animator.SetBool(triggers.SHOW, true);
    }

    public void Hide() {
        animator.SetBool(triggers.SHOW, false);
    }

    public void SetTimescale(float value) {
        Time.timeScale = value;
    }
}
