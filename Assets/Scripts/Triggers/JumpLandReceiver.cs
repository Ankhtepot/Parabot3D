using UnityEngine;
using UnityEngine.Events;

namespace Triggers
{
    public class JumpLandReceiver : MonoBehaviour
    {
#pragma warning disable 649
        [SerializeField] private UnityEvent OnJumpLandReceived;
#pragma warning restore 649

        public void OnJumpLand() {
            // print("JumpLandReceiver: OnJumpLand Invoking");
            OnJumpLandReceived?.Invoke();
        }
    }
}
