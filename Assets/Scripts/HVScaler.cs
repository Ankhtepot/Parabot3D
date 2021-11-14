using UnityEngine;

public class HVScaler : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private Transform targetObject;
#pragma warning restore 649
    [SerializeField] private float xZScale = 1;
    [SerializeField] private float yScale = 1;

    private void OnValidate() {
        targetObject.localScale = new Vector3(targetObject.localScale.x, yScale, targetObject.localScale.z);
        targetObject.localScale = new Vector3(xZScale, targetObject.localScale.y, xZScale);
    }
}
