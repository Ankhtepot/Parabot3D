using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightOfObject : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] float weight;
#pragma warning restore 649

    public float getWeight() {
        return weight;
    }
}
