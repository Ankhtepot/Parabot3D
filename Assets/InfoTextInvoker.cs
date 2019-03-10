using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTextInvoker : MonoBehaviour
{
    [SerializeField] InfoText infoText;
    [TextArea] public string message;

    private void Start() {
        infoText = FindObjectOfType<InfoText>();
    }
    public void InvokeInfoText() {
        infoText.ShowUp(message);
    }
}
