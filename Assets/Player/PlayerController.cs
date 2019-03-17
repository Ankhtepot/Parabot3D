using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public GameObject feetPivot;

    public void Death() {
        OnDying();
    }
    
    private void OnDying() {

    }
}
