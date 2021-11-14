using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private UnityEvent OnEnter;
    [SerializeField] private UnityEvent OnExit;
#pragma warning restore 649

    private void OnTriggerEnter(Collider other)
    {
        OnEnter.Invoke();
    }    

    private void OnTriggerExit(Collider other)
    {
        OnExit.Invoke();
    }
}
