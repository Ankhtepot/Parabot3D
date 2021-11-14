using UnityEngine;

public class WeightOfObject : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private float weight;
#pragma warning restore 649

    public float getWeight() {
        return weight;
    }
}
