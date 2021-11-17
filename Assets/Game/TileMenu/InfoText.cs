using System;
using System.Collections;
using Attributes;
using Constants;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Game.TileMenu
{
    public class InfoText : MonoBehaviour {
        [SerializeField] private Animator animator;
        [SerializeField] private TextMeshProUGUI textArea;
        [ReadOnly][SerializeField] private string message;

        //Caches
        private UnityAction postDismissAction = null;

        private void Start() {
            animator = GetComponent<Animator>();
            // message = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.";
        }

        public void ActivateInfoText() {
            StopCoroutine(WriteMessage());
            StartCoroutine(WriteMessage());
        }

        public void ShowUp(string text, UnityAction action = null) {
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

        private IEnumerator WriteMessage() {
            int messageLength = message.Length;
            int writtenChars = 0;
            //print("Starting writing. MessageLength: " + messageLength + " writenChars: "+ writtenChars);
            if (messageLength <= 0) yield break;
            
            while (writtenChars < messageLength) {
                //print("will write " + message[writtenChars]);
                try {
                    textArea.text += message[writtenChars++];
                } catch {

                }
                yield return null;
                //writtenChars++;
            }
        }
    }
}
