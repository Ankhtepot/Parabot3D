using Attributes;
using UnityEngine;
using UnityEngine.Events;

namespace Game.TileMenu
{
    public class InfoTextInvoker : MonoBehaviour, IActionReceiver
    {
#pragma warning disable 649
        [ReadOnly][SerializeField] private InfoText infoText;
        [ReadOnly][SerializeField] private InfoTextProvider providedText;
#pragma warning restore 649
        [TextArea] public string message;

        //Caches
        private UnityAction postDismissAction;

        private void Start() {
            infoText = FindObjectOfType<InfoText>();
        }

        public void SetAction(UnityAction action) {
            //String infoText = "InfoTextInvoker received action. postDismissAction is ";
            postDismissAction = action;
            //infoText += (postDismissAction != null ? "set " : "null ") + "in InfoTextInvoker";
            //print(infoText);
        
        }

        public void InvokeInfoText() {
            if (providedText) message = providedText.Text ;
            infoText.ShowUp(message, postDismissAction);
            // print("InvokeInfoText: postDismissAction is " + (postDismissAction == null ? "null" : "assigned and should be sent to infoText"));
        }

        public void Set(InfoTextProvider textProvider, UnityAction action = null)
        {
            providedText = textProvider;
            SetAction(action);
        }
    }
}
