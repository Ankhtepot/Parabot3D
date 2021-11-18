using System;
using System.Collections.Concurrent;
using Attributes;
using Game.Components.RespawnPoint;
using Player;
using UnityEngine;

public class GameController : MonoBehaviour
{
#pragma warning disable 649    
    [SerializeField] private RespawnPoint activeRespawnPoint;
    [Header("States")]
    [ReadOnly][SerializeField] public bool hasActiveRespawnPoint = false;

    [Header("Reference Subscribers")] 
    [ReadOnly] [SerializeField] private PlayerController playerController;

    public static GameController _Instance;
    public static bool _HasActiveRespawnPoint;
    private static ConcurrentDictionary<Type, Component> subscriberStore = new ConcurrentDictionary<Type, Component>();
#pragma warning restore 649

    private void OnEnable()
    {
        _Instance = this;
        SetHasActiveRespawnPoint(false);
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
        hasActiveRespawnPoint = true;
        _HasActiveRespawnPoint = true;
    }

    public static void Subscribe<T>(T subscriber) where T : Component
    {
        subscriberStore.TryAdd(typeof(T), subscriber);
    }

    public static T GetSubscriber<T>() where T : Component
    {
        return subscriberStore.TryGetValue(typeof(T), out var go) ? (T)go : null;
    }

    public static void Unsubscribe<T>() where T : Component
    {
        subscriberStore.TryRemove(typeof(T), out _);
    }
}
