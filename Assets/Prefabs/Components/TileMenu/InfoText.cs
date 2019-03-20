using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoText : MonoBehaviour {
    [SerializeField] Animator animator;
#pragma warning disable 649
    [SerializeField] TextMeshProUGUI textArea;
#pragma warning restore 649
    [SerializeField] string message;
    [SerializeField] float writeSpeed = 0.05f;

    //Caches
    Action postDismissAction = null;

    private void Start() {
        animator = GetComponent<Animator>();
        message = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.";
    }

    public void ActivateInfoText() {
        StopCoroutine(WriteMessage());
        StartCoroutine(WriteMessage());
    }

    public void ShowUp(string text, Action action = null) {
        textArea.text = "";
        message = text;
        animator.SetBool(triggers.SHOW, true);
        if (action != null) {
            print("InfoText received action.");
            postDismissAction = action;
        }
    }

    public void HideInfoText() {
        StopCoroutine(WriteMessage());
        message = "";
        animator.SetBool(triggers.SHOW, false);
        postDismissAction?.Invoke();
    }

    IEnumerator WriteMessage() {
        int messageLength = message.Length;
        int writtenChars = 0;
        //print("Starting writing. MessageLength: " + messageLength + " writenChars: "+ writtenChars);
        if (messageLength > 0) {
            while (writtenChars < messageLength) {
                //print("will write " + message[writtenChars]);
                yield return new WaitForSecondsRealtime(writeSpeed);
                try {
                    textArea.text += message[writtenChars++];
                } catch {

                }
                //writtenChars++;
            } 
        }
    }
}
