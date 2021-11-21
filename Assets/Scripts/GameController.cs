using Attributes;
using Game.Components.RespawnPoint;
using Player;
using UnityEngine;
using Utilities.ObjectPool;

public class GameController : MonoBehaviour
{
#pragma warning disable 649    
    [SerializeField] private RespawnPoint activeRespawnPoint;
    [SerializeField] private ObjectPool pool;
    [Header("States")]
    [ReadOnly] public bool hasActiveRespawnPoint;

    public static GameController Instance;
    public static PlayerController PlayerController;
    public static ObjectPool ObjectPool;
#pragma warning restore 649

    private void OnEnable()
    {
        Instance = this;
        SetHasActiveRespawnPoint(false);
        ObjectPool = pool;
    }

    public void SetRespawnPoint(RespawnPoint RP) {
        SetHasActiveRespawnPoint(true);
        activeRespawnPoint = RP;
    }

    public Vector3 getActiveRespawnPointPosition() {
        return activeRespawnPoint.getPointOfRespawn();
    }

    private void SetHasActiveRespawnPoint(bool state)
    {
        hasActiveRespawnPoint = state;
    }
}
