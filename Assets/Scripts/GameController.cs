using System;
using System.Collections.Concurrent;
using Attributes;
using Game.Components.RespawnPoint;
using UnityEngine;

public class GameController : MonoBehaviour
{
#pragma warning disable 649    
    [SerializeField] private RespawnPoint activeRespawnPoint;
    [Header("States")]
    [ReadOnly] public bool hasActiveRespawnPoint;

    public static GameController _Instance;
    private static readonly ConcurrentDictionary<Type, Component> subscriberStore = new ConcurrentDictionary<Type, Component>();
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
        hasActiveRespawnPoint = state;
    }

    public static void Subscribe<T>(T subscriber) where T : Component
    {
        subscriberStore.TryAdd(typeof(T), subscriber);
    }

    public static T GetSubscriber<T>() where T : Component
    {
        if (subscriberStore.TryGetValue(typeof(T), out var go))
        {
            return (T)go;
        }

        throw new ArgumentOutOfRangeException($"No Component of type {typeof(T)} found amongs subscribers in GameController");
    }

    public static void Unsubscribe<T>() where T : Component
    {
        subscriberStore.TryRemove(typeof(T), out _);
    }
}
