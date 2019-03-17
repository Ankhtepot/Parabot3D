using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour {
    [SerializeField] GameController GC;
    [SerializeField] bool activated = false;
#pragma warning disable 649
    [SerializeField] MeshRenderer body;
#pragma warning restore 649

    //caches
    Color activeColor = Color.green;
    Color deactivatedColor = Color.red;

    private void Start() {
        GC = FindObjectOfType<GameController>();
    }

    public void ActivateRespawnPoint() {
        if (activated) return;

        activated = true;
        body.materials[7].color = activeColor;
        GC.SetRespawnPoint(this);
    }

    public void DeactiveteRespawnPoint() {
        activated = false;
        body.materials[7].color = deactivatedColor;
    }
}
