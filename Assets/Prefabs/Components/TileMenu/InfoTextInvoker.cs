using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTextInvoker : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] InfoText infoText;
    [SerializeField] TextProvider providedText;
#pragma warning restore 649
    [TextArea] public string message;

    private void Start() {
        infoText = FindObjectOfType<InfoText>();
    }
    public void InvokeInfoText() {
        if (providedText) message = providedText.getText() ;
        infoText.ShowUp(message);
    }
}
