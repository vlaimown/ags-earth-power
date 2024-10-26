using UnityEngine;
using UnityEngine.InputSystem;


    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerInput))]


    public class ControllerV2 : MonoBehaviour
    {
        [SerializeField] private float speed = 10;
        [SerializeField] private float speedJump = 10;
        private Rigidbody2D body;
        private bool isJump;
        private Vector2 movementInput;

        private void OnJump()
        {
            isJump = true;
        }
        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }
        public void OnMove(InputValue input)
        {
            movementInput = input.Get<Vector2>();
        }
        private void FixedUpdate()
        {
            if (isJump)
            {
                body.AddForce(speedJump * Vector2.up, ForceMode2D.Impulse);
            }
            isJump = false;

            body.AddForce(movementInput);
        }
}
