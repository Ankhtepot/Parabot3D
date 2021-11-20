using System.Collections;
using Constants;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Combined_tiles_simple._1tileWide2sidesSlidingDoor
{
    [RequireComponent(typeof(Animator))]
    [SelectionBase]
    public class DoorController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private bool unlocked;
        [SerializeField] private bool blocked;
        [SerializeField] UnityEvent ReactionOnBlocked;

        delegate void delayedAction();
    
        public void Open(float delay = 0)
        {
            if (!unlocked || blocked) {
                ReactionOnBlocked.Invoke();
                return;
            }
            delayedAction open = () => { animator.SetBool(triggers.OPEN, true); };
            if (delay > 0) StartCoroutine(delayedProcess(open, delay));
            else open();
        }

        public void Close(float delay = 0)
        {
            if (blocked) {
                ReactionOnBlocked.Invoke();
                return;
            }
            delayedAction close = () => { animator.SetBool(triggers.OPEN, false); };
            if (delay > 0) StartCoroutine(delayedProcess(close, delay));
            else close();
        }    

        private IEnumerator delayedProcess(delayedAction action, float delay) {
            yield return new WaitForSecondsRealtime(delay);
            //print("delayedProcess was delayed by " + delay + "s");
            action();
        }

        public void Lock() {
            if (blocked) {
                ReactionOnBlocked.Invoke();
                return;
            }
            unlocked = false;
        }

        public void Unlock() {
            if (blocked) {
                ReactionOnBlocked.Invoke();
                return;
            }
            unlocked = true;
        }

        public void SetBlocked(bool Blocked) {
            blocked = Blocked;
        }
    }
}
