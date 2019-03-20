using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevelAction : MonoBehaviour
{
    IActionReceiver actionReceiver;

    void Start()
    {
        actionReceiver = GetComponent<IActionReceiver>();
        if (actionReceiver != null) {
            actionReceiver.SetAction(ResetLevel);
        }
    }

    void ResetLevel() {
        print("Level would reset now.");
    }

    
}
