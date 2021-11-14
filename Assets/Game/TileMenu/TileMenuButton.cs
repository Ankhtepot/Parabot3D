using Constants;
using UnityEngine;
using UnityEngine.Events;

namespace Game.TileMenu
{
    [RequireComponent(typeof(Animator))]
    public class TileMenuButton : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnPress;
        [SerializeField] private Animator animator;

        private void OnMouseDown() {
            //print("OnPress button invoked");
            OnPress.Invoke();
        }

        public void ShowUp() {
            //print("buton level: Button showing up");
            animator.SetBool(triggers.SHOW, true);
        }

        public void Hide() {
            animator.SetBool(triggers.SHOW, false);
        }
    }
}
