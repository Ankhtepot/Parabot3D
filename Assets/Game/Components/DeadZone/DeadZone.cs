using Constants;
using Game.UI_parts.InfoText;
using Player;
using UnityEngine;

namespace Game.Components.DeadZone
{
    public class DeadZone : MonoBehaviour
    {
        [SerializeField] bool isZoneEffectActive = true;
        [SerializeField] ParticleSystem zoneEffect;

        private void Start()
        {
            if (zoneEffect && isZoneEffectActive) SetZoneEffectActiveState(true);
        }

        private void SetZoneEffectActiveState(bool state)
        {
            if (zoneEffect)
            {
                if (state)
                {
                    zoneEffect.Play();
                }
                else
                {
                    zoneEffect.Stop();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(tags.Player)) return;

            if (GameController.Instance.hasActiveRespawnPoint)
                GetComponent<InfoTextInvoker>().InvokeInfoText();
            else
                GameController.PlayerController.Death();
        }
    }
}