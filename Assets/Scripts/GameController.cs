using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
#pragma warning disable 649    
    [SerializeField] RespawnPoint respawnPoint;
#pragma warning restore 649

    public void SetRespawnPoint(RespawnPoint RP) {
        respawnPoint = RP;
    }
}
