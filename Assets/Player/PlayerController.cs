using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] GameController GC;

        private void Start() {
            GC = FindObjectOfType<GameController>();
        }
        
        public void Death() {
            OnDying();
        }
    
        private void OnDying() {
            // print("OnDying reporting. RespawnPosition = " + (GC.hasActiveRespawnPoint == true ? GC.getActiveRespawnPointPosition().ToString() : "no respawnpoint active"));
            if (GC.hasActiveRespawnPoint) transform.position = GC.getActiveRespawnPointPosition();
        }
    }
}
