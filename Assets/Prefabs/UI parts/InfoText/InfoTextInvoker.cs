using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTextInvoker : MonoBehaviour, IActionReceiver
{
#pragma warning disable 649
    [SerializeField] InfoText infoText;
    [SerializeField] InfoTextProvider providedText;
#pragma warning restore 649
    [TextArea] public string message;

    //Caches
    Action postDismissAction = null;

    private void Start() {
        infoText = FindObjectOfType<InfoText>();
    }

    public void SetAction(Action action) {
        //String infotext = "InfoTextInvoker received action. postDismissAction is ";
        postDismissAction = action;
        //infotext += (postDismissAction != null ? "set " : "null ") + "in InfoTextInvoker";
        //print(infotext);
        
    }

    public void InvokeInfoText() {
        if (providedText) message = providedText.getText() ;
        infoText.ShowUp(message, postDismissAction);
        //print("InvokeInfotext: postDismissAction is " + (postDismissAction == null ? "null" : "assigned and shuld be sent to infoText"));
    }
}
