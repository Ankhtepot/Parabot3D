using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HVScaler : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] Transform targetObject;
#pragma warning restore 649
    [SerializeField] float xZScale = 1;
    [SerializeField] float yScale = 1;

    private void OnValidate() {
        targetObject.localScale = new Vector3(targetObject.localScale.x, yScale, targetObject.localScale.z);
        targetObject.localScale = new Vector3(xZScale, targetObject.localScale.y, xZScale);
    }
}
