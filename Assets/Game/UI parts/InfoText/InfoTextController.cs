using System.Collections;
using Attributes;
using Constants;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Game.UI_parts.InfoText
{
    public class InfoTextController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private TextMeshProUGUI textArea;
        [ReadOnly] [SerializeField] private string message;

        //Caches
        private UnityAction postDismissAction;

        private void OnEnable()
        {
            EventBroker.OnInfoTextInvoked += ShowUp;
        }

        public void ActivateInfoText()
        {
            StopCoroutine(WriteMessage());
            StartCoroutine(WriteMessage());
        }

        private void ShowUp(string text, UnityAction action = null)
        {
            textArea.text = "";
            message = text;
            animator.SetBool(triggers.SHOW, true);
            if (action != null)
            {
                print("InfoText received action.");
                postDismissAction = action;
            }
        }

        public void HideInfoText()
        {
            StopCoroutine(WriteMessage());
            message = "";
            animator.SetBool(triggers.SHOW, false);
            postDismissAction?.Invoke();
        }

        private IEnumerator WriteMessage()
        {
            int messageLength = message.Length;
            int writtenChars = 0;
            //print("Starting writing. MessageLength: " + messageLength + " writenChars: "+ writtenChars);
            if (messageLength <= 0) yield break;

            while (writtenChars < messageLength)
            {
                //print("will write " + message[writtenChars]);
                try
                {
                    textArea.text += message[writtenChars++];
                }
                catch
                {
                    //
                }

                yield return null;
                //writtenChars++;
            }
        }

        private void OnDisable()
        {
            EventBroker.OnInfoTextInvoked -= ShowUp;
        }
    }
}