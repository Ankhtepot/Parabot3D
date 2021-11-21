using UnityEngine.Events;

namespace Triggers
{
    internal interface IActionReceiver {
        void SetAction(UnityAction action);
    }
}