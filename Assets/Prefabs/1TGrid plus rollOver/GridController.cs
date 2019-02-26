using Assets.Scripts;
using Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GridController : MonoBehaviour, IJumpLandReceiver {
#pragma warning disable 649
    [SerializeField] int landCount = 0;
    [SerializeField] GameObject[] Group1;
    [SerializeField] GameObject[] Group2;
    [SerializeField] GameObject[] Group3;    
#pragma warning restore 649
    [SerializeField] List<GameObject[]> parts = new List<GameObject[]>();

    private void Start() {
        parts.Add(Group1);
        parts.Add(Group2);
        parts.Add(Group3);
    }

    public void OnJumpLand() {
        //print("Grid reporting landCount: " + landCount);
        if(landCount < parts.Count) {
            disableParts(parts[landCount++]);
        }
    }

    public void OnRollOver() {
        print("RollOver reporting");
    }

    private void disableParts(GameObject[] group) {
        foreach(GameObject part in group) {
            part.SetActive(false);
        }
    }
}
