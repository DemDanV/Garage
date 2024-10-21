using UnityEngine;

namespace Garage
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed = 5.0f;
        [SerializeField] float gravity = -9.81f;
        [SerializeField] float jumpHeight = 2.0f;

        private CharacterController controller;
        private Vector3 velocity;
        private bool isGrounded;

        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            HandleMovementAndGravity();
        }

        private void HandleMovementAndGravity()
        {
            isGrounded = controller.isGrounded;
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            Vector3 move = transform.right * moveX + transform.forward * moveZ;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}