using UnityEngine;

namespace Game.Components.RespawnPoint
{
    public class RespawnPoint : MonoBehaviour {
        [SerializeField] private GameController GC;
        [SerializeField] private bool activated;
        [SerializeField] private GameObject centerPointOfRespawn;
        [SerializeField] private MeshRenderer body;

        //caches
        private readonly Color activeColor = Color.green;
        private readonly Color deactivatedColor = Color.red;

        private void Start() {
            GC = FindObjectOfType<GameController>();
        }

        public Vector3 getPointOfRespawn() {
            return centerPointOfRespawn.transform.position;
        }

        public void ActivateRespawnPoint() {
            if (activated) return;

            activated = true;
            body.materials[7].color = activeColor;
            GC.SetRespawnPoint(this);
        }

        public void DeactivateRespawnPoint() {
            activated = false;
            body.materials[7].color = deactivatedColor;
        }
    }
}
