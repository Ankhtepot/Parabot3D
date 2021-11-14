using System;
using UnityEngine;

namespace Game.TileMenu
{
    public class InfoTextInvoker : MonoBehaviour, IActionReceiver
    {
#pragma warning disable 649
        [SerializeField] private InfoText infoText;
        [SerializeField] private InfoTextProvider providedText;
#pragma warning restore 649
        [TextArea] public string message;

        //Caches
        private Action postDismissAction = null;

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
}
