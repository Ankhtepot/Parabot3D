using System.Collections;
using System.Collections.Generic;
using Player;
using Prefabs.Components.TileMenu;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] bool isZoneEffectActive = true;
    [SerializeField] ParticleSystem zoneEffect;
#pragma warning restore 649

    private void Start() {
        if (zoneEffect && isZoneEffectActive) SetZoneEffectActiveState(true);
    }

    public void SetZoneEffectActiveState(bool state) {
        if(zoneEffect) {
            if(state) {
                zoneEffect.Play();
            } else {
                zoneEffect.Stop();
            }
        }
    }

    private void OnTriggerEnter(Collider other) {

        if (!other.GetComponent<PlayerController>()) return;

        if (!FindObjectOfType<GameController>().hasActiveRespawnPoint)
            GetComponent<InfoTextInvoker>().InvokeInfoText();
        else
            other.GetComponent<PlayerController>().Death();
    }
}
