using Assets.Scripts.Constants;
using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
#pragma warning disable 649
    [SerializeField] private float moveMultiplier;
    [SerializeField] float jumpPower;
    [Range(0f, 5f)][SerializeField] float feetOBoxReductor;
    [SerializeField] GameObject[] staticObjects = { };
    [SerializeField] Vector3 feetPivotPositionAdjustment;
    [SerializeField] GameObject feetPivot;
#pragma warning restore 649
    [SerializeField] private PlayerController player;
    [SerializeField] Collider[] feetSphereIncludes;
    [SerializeField] bool isJumping = false;

    //Caches
    private Rigidbody RB;
    private VirtualJoystick joystick;
    [SerializeField] bool acceptJumpLand = false;

    private void Start() {
        player = FindObjectOfType<PlayerController>();
        RB = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<VirtualJoystick>();
    }

    private void Update() {
        if (RB.velocity.y < -2f) acceptJumpLand = true;
        Jump();
    }

    private void FixedUpdate() {
        Movement();
    }


    private void Movement() {
        
        var newVelocity = new Vector3(joystick.GetHorizontal() * moveMultiplier * Time.deltaTime, RB.velocity.y
                                     , joystick.GetVertical() * moveMultiplier * Time.deltaTime);
        //print($"Movement/newVelocity: {newVelocity}");
        RB.velocity = newVelocity;
    }

    private bool IsTouchingGround() {
        feetSphereIncludes = Physics.OverlapBox(feetPivot.transform.position, transform.localScale / feetOBoxReductor/2);
        return Array.Find(feetSphereIncludes, col => col.tag == system.GROUND);
    }

    private void TriggerJumpLandReceivers() {
        //String receivers = "Contact on jumpLand with: ";
        foreach(Collider col in feetSphereIncludes) {
            //receivers += col.name + " || ";
            if(col.GetComponentInParent<JumpLandReceiver>()) col.GetComponentInParent<JumpLandReceiver>().OnJumpLand();
        }
        //print(receivers);
    }

    public void Jump() {
        if(!isJumping && Input.GetAxis(system.JUMP) > 0) {
            JumpExecute();
        }
        if (IsTouchingGround() && isJumping) {
            if (acceptJumpLand) {
                //        //TriggerJumpLandReceivers();
                acceptJumpLand = false;
            }
            isJumping = false;
        }

    }

    private void JumpExecute() {
        if(!isJumping) {
            isJumping = true;
            acceptJumpLand = false;
            Vector3 jumpVector = new Vector3(0, jumpPower * Time.deltaTime, 0);
            RB.velocity += jumpVector;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawCube(feetPivot.transform.position, transform.localScale / feetOBoxReductor);
    }

    private void OnCollisionEnter(Collision collision) {
        GameObject otherObject = collision.gameObject;
        if(acceptJumpLand) {
            acceptJumpLand = false;
            if (otherObject.GetComponentInParent<JumpLandReceiver>()) {
                //print("Detected JumpLandReceiver on jumpLand.");
                otherObject.GetComponentInParent<JumpLandReceiver>().OnJumpLand();
            }
        }
    }
}
