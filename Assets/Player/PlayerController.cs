using Attributes;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [ReadOnly][SerializeField] GameController GC;

        private void OnEnable()
        {
            GC = GameController.Instance;
            GameController.PlayerController = this;
        }

        public void Death() {
            OnDying();
        }
    
        private void OnDying() {
            // print("OnDying reporting. RespawnPosition = " + (GC.hasActiveRespawnPoint == true ? GC.getActiveRespawnPointPosition().ToString() : "no respawnpoint active"));
            if (GC.hasActiveRespawnPoint) transform.position = GC.getActiveRespawnPointPosition();
        }

        private void OnDisable()
        {
            GameController.PlayerController = null;
        }
    }
}
