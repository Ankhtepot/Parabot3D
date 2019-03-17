using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{

    private static Globals instance = null;

    private void Awake() {
        if(instance != null) {
            gameObject.SetActive(false);
            Destroy(this);
        } else {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
