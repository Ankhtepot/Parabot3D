using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
#pragma warning disable 649    
    [SerializeField] RespawnPoint activeRespawnPoint;
    [Header("States")]
    [SerializeField] public bool hasActiveRespawnPoint = false;
#pragma warning restore 649

    public void SetRespawnPoint(RespawnPoint RP) {
        hasActiveRespawnPoint = true;
        activeRespawnPoint = RP;
    }

    public Vector3 getActiveRespawnPointPosition() {
        return activeRespawnPoint.getPointOfRespawn();
    }
}
