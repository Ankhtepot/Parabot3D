using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class TileMenuButton : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] UnityEvent OnPress;
#pragma warning restore 649
    [SerializeField] Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown() {
        //print("OnPress button invoked");
        OnPress.Invoke();
    }

    public void ShowUp() {
        //print("buton level: Button showing up");
        animator.SetBool(triggers.SHOW, true);
    }

    public void Hide() {
        animator.SetBool(triggers.SHOW, false);
    }
}
