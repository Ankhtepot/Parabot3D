using System.Collections.Generic;
using UnityEngine;

namespace Prefabs.Combined_tiles_simple._1TGrid_plus_rollOver
{
    [RequireComponent(typeof(JumpLandReceiver))]
    public class GridController : MonoBehaviour {
#pragma warning disable 649
        [SerializeField] private int landCount;
        [SerializeField] private GameObject[] Group1;
        [SerializeField] private GameObject[] Group2;
        [SerializeField] private GameObject[] Group3;    
#pragma warning restore 649
        private readonly List<GameObject[]> parts = new List<GameObject[]>();

        private void Start() {
            parts.Add(Group1);
            parts.Add(Group2);
            parts.Add(Group3);
        }

        public void OnJumpLand() {
            // print("Grid reporting landCount: " + landCount);
            if(landCount < parts.Count) {
                disableParts(parts[landCount++]);
            }
        }

        private static void disableParts(GameObject[] group) {
            foreach(var part in group) {
                part.SetActive(false);
            }
        }
    }
}
