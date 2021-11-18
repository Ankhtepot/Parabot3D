using Constants;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpPower;

        [Header("Assignables")] 
        [SerializeField] private Rigidbody RB;
        [SerializeField] private SphereCollider ownCollider;

        //Caches
        [SerializeField] private bool isJumping;
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
            var xMovement = joystick.GetHorizontal();
            var zMovement = joystick.GetVertical();
// #if UNITY_STANDALONE
            if (Input.GetKey(KeyCode.D)) xMovement = 1f;
            if (Input.GetKey(KeyCode.A)) xMovement = -1f;
            if (Input.GetKey(KeyCode.W)) zMovement = 1f;
            if (Input.GetKey(KeyCode.S)) zMovement = -1f;
// #endif
            var newVelocity = new Vector3( xMovement * moveSpeed * Time.deltaTime, RB.velocity.y
                , zMovement * moveSpeed * Time.deltaTime);
            // print($"Movement/newVelocity: {newVelocity}");
            RB.velocity = newVelocity;
        }

        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position, -Vector3.up, ownCollider.radius + 0.1f);
        }

        private void JumpHandler()
        {
            if (!isJumping && Input.GetAxis(system.JUMP) > 0)
            {
                JumpExecute();
            }

            if (isJumping && IsGrounded())
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
            var jumpVector = new Vector3(0, jumpPower * Time.deltaTime, 0);
            RB.velocity += jumpVector;
        }

        private void OnCollisionEnter(Collision collision)
        {
            var otherObject = collision.gameObject;
            
            if (!acceptJumpLand) return;
            
            acceptJumpLand = false;
            if (otherObject.CompareTag(tags.JumpLandReceiver))
            {
                // print("Detected JumpLandReceiver on jumpLand.");
                otherObject.GetComponentInParent<JumpLandReceiver>().OnJumpLand();
            }
        }
    }
}