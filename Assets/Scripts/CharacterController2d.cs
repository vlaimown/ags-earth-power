/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]

public class CharacterController2d : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 movementInput;

    [SerializeField]
    private float force = 2;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    public void OnMove(InputValue value)
    {
        movementInput = (value.Get<Vector2>().normalized);
        //Debug.Log(movementInput.ToString());

    }

    public void OnJump(InputValue value)
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // body.AddForce(movementInput*force);
        //Vector2 newPosition = body.position.x + force*Time.fixedDeltaTime;
        body.MovePosition(newPosition);
    }
}
*/



using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]


public class CharacterController2d : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float speedJump = 10;


    [Header("Gravity Settings")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private CircleCollider2D groundCollider;
    private ContactFilter2D groundFilter;

    private Rigidbody2D body;
    private bool isJump;
    private Vector2 movementInput;
    [SerializeField]private bool isGrounded;
    private void OnJump()
    {
        isJump = true;
    }
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        groundFilter.SetLayerMask(groundLayer);
        groundFilter.useLayerMask = true;
        groundFilter.useTriggers = false;
    }
    public void OnMove(InputValue input)
    {
        movementInput = input.Get<Vector2>();
    }
    private void GroundCheck()
    {
        Collider2D[] colliders = new Collider2D[16]; 
        var count = groundCollider.OverlapCollider(groundFilter, colliders);
        isGrounded = count > 0;
    }
    private void FixedUpdate()
    {
        GroundCheck();
        if (isJump && isGrounded)
        {
            body.AddForce(speedJump * Vector2.up, ForceMode2D.Impulse);
        }
        isJump = false;

        body.AddForce(movementInput * speed * Vector2.right * Time.deltaTime);
    }
}
