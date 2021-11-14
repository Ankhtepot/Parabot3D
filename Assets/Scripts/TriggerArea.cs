using UnityEngine;
using UnityEngine.Events;

public class TriggerArea : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private UnityEvent OnRollOver_Collision;
    [SerializeField] private UnityEvent OnRollAway_Collision;
    [SerializeField] private UnityEvent OnRollOver_Trigger;
    [SerializeField] private UnityEvent OnRollAway_Trigger;
#pragma warning restore 649

    private void OnCollisionEnter(Collision collision) {
      //  print("TriggerArea: collision fired with: " + collision.gameObject.name);
        OnRollOver_Collision.Invoke();
    }

    private void OnCollisionExit(Collision collision) {
        OnRollAway_Collision.Invoke();
    }

    private void OnTriggerEnter(Collider other) {
       // print("TriggerArea: trigger fired with: " + other.name);
        OnRollOver_Trigger.Invoke();
    }

    private void OnTriggerExit(Collider other) {
        OnRollAway_Trigger.Invoke();
    }
}
