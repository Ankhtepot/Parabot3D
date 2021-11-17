using System;
using UnityEngine.Events;

internal interface IActionReceiver {
    void SetAction(UnityAction action);
}