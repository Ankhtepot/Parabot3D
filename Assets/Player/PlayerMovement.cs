using Constants;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpPower;
        [SerializeField] private Transform feetPivot;
        [SerializeField] private Collider[] feetSphereIncludes;

        [Header("Assignables")] 
        [SerializeField] private Rigidbody RB;
        [SerializeField] private SphereCollider ownCollider;

        //Caches
        [SerializeField] private bool isJumping = false;
        [SerializeField] private bool acceptJumpLand;
        private VirtualJoystick joystick;

        private void Start()
        {
            RB = GetComponent<Rigidbody>();
            joystick = FindObjectOfType<VirtualJoystick>();
        }

        private void Update()
        {
            JumpHandler();
        }

        private void FixedUpdate()
        {
            if (RB.velocity.y < -2f) acceptJumpLand = true;
            Movement();
        }


        private void Movement()
        {
            var newVelocity = new Vector3(joystick.GetHorizontal() * moveSpeed * Time.deltaTime, RB.velocity.y
                , joystick.GetVertical() * moveSpeed * Time.deltaTime);
            // print($"Movement/newVelocity: {newVelocity}");
            RB.velocity = newVelocity;
        }

        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position, -Vector3.up, ownCollider.radius + 0.1f);
        }

        private void TriggerJumpLandReceivers()
        {
            //String receivers = "Contact on jumpLand with: ";
            foreach (Collider col in feetSphereIncludes)
            {
                //receivers += col.name + " || ";
                if (col.GetComponentInParent<JumpLandReceiver>())
                {
                    col.GetComponentInParent<JumpLandReceiver>().OnJumpLand();
                }
            }
            //print(receivers);
        }

        private void JumpHandler()
        {
            if (!isJumping && Input.GetAxis(system.JUMP) > 0)
            {
                JumpExecute();
            }

            if (IsGrounded() && isJumping)
            {
                if (acceptJumpLand)
                {
                    //TriggerJumpLandReceivers();
                    acceptJumpLand = false;
                }

                isJumping = false;
            }
        }

        private void JumpExecute()
        {
            isJumping = true;
            acceptJumpLand = false;
            Vector3 jumpVector = new Vector3(0, jumpPower * Time.deltaTime, 0);
            RB.velocity += jumpVector;
        }

        // private void OnDrawGizmos() {
        //     Gizmos.DrawCube(feetPivot.transform.position, transform.localScale / feetOBoxReductor);
        // }

        private void OnCollisionEnter(Collision collision)
        {
            GameObject otherObject = collision.gameObject;
            if (acceptJumpLand)
            {
                acceptJumpLand = false;
                if (otherObject.GetComponentInParent<JumpLandReceiver>())
                {
                    //print("Detected JumpLandReceiver on jumpLand.");
                    otherObject.GetComponentInParent<JumpLandReceiver>().OnJumpLand();
                }
            }
        }
    }
}