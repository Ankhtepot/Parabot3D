using Constants;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.UIParts.ButtonAnimated
{
    public class ButtonUI : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler {
#pragma warning disable 649
        [SerializeField] LabelText Label;
        [SerializeField] private Image[] ColorChangeImages;
        [SerializeField] float colorChangeSpeed = 0.1f;
        [SerializeField] Color normalColor;
        [SerializeField] Color hoverColor;
        [SerializeField] Color clickColor;
        [SerializeField] Color disabledColor = Color.grey;
        [SerializeField] UnityEvent OnMouseDown;
        [SerializeField] UnityEvent OnMouseUp;
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] Animator animator;
#pragma warning restore 649

        //caches
        private bool RuntimeEnabled = true;
        [SerializeField] Color targetColor = Color.white;

        private void Start() {
            text.text = Label.Text;
            if (!RuntimeEnabled) Disable();
            if (RuntimeEnabled) Enable();
        }

        private void Update() {
            handleColors();
        }

        public void OnPointerDown(PointerEventData eventData) {
            if (RuntimeEnabled) {
                handleMouseDown(); 
            }
        }

        public void OnPointerUp(PointerEventData eventData) {
            if (RuntimeEnabled) {
                handleMouseUp(); 
            }
        }

        public void OnPointerEnter(PointerEventData eventData) {
            if (RuntimeEnabled) {
                //print("OnPointerEnter");
                handleMouseEnter(); 
            }
        }

        public void OnPointerExit(PointerEventData eventData) {
            if (RuntimeEnabled) {
                handleMouseExit(); 
            }
        }

        private void Enable() {
            RuntimeEnabled = true;
            animator.SetBool(triggers.ENABLED, true);
            targetColor = normalColor;
        }

        private void Disable() {
            RuntimeEnabled = false;
            animator.SetBool(triggers.ENABLED, false);
            targetColor = disabledColor;
        }

        private void handleMouseUp() {
            targetColor = hoverColor;
            animator.SetBool(triggers.ONCLICK, false);
            OnMouseUp.Invoke();
        }

        private void handleColors() {
            if (ColorChangeImages[0].color != targetColor) {
                foreach (var image in ColorChangeImages) {
                    image.color = Color.Lerp(image.color, targetColor, colorChangeSpeed); 
                }
                text.color = Color.Lerp(text.color, targetColor, colorChangeSpeed);
            }
        }

        private void handleMouseDown() {
            targetColor = clickColor;
            animator.SetBool(triggers.ONCLICK, true);
            OnMouseDown.Invoke();
        }

        private void handleMouseEnter() {
            //print("handleMouseEnter");
            targetColor = hoverColor;
            animator.SetBool(triggers.FOCUSED, true);
        }

        private void handleMouseExit() {
            targetColor = normalColor;
            animator.SetBool(triggers.FOCUSED, false);
        }
    }
}
