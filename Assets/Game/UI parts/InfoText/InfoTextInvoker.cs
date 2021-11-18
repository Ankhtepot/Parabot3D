using Services;
using UnityEngine;
using UnityEngine.Events;

namespace Game.UI_parts.InfoText
{
    public class InfoTextInvoker : MonoBehaviour, IActionReceiver
    {
#pragma warning disable 649
        [SerializeField] private global::InfoText providedText;
#pragma warning restore 649

        //Caches
        private UnityAction postDismissAction;

        public void SetAction(UnityAction action) {
            //String infoText = "InfoTextInvoker received action. postDismissAction is ";
            postDismissAction = action;
            //infoText += (postDismissAction != null ? "set " : "null ") + "in InfoTextInvoker";
            //print(infoText);
        
        }

        public void InvokeInfoText() {
            EventBroker.TriggerOnInfoTextInvoked(providedText.Text, postDismissAction);
            // print("InvokeInfoText: postDismissAction is " + (postDismissAction == null ? "null" : "assigned and should be sent to infoText"));
        }
    }
}
