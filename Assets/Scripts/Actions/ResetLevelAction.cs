using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevelAction : MonoBehaviour
{
    IActionReceiver actionReceiver;

    void Start()
    {
        GetComponent<IActionReceiver>()?.SetAction(ResetLevel);
    }

    void ResetLevel() {
        //print("Level would reset now.");
        FindObjectOfType<SceneLoader>().LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    
}
