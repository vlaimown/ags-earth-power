using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]

public class HeroController : MonoBehaviour
{
    [SerializeField] public Health health;
    public Silushka silushka;
    [SerializeField] float jumpCost;
    [SerializeField] float moveCost;
    private Rigidbody2D body;
    private Vector2 movementInput;
    private Vector2 rawInput;
    //private bool grounded;
    private float realSpeed;
    [SerializeField] private float minjump = 11;
    //private int maxHealth = 100;
    //private int currentHealth;
    public Transform groundchecker;
    public LayerMask groundLayer;

    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private float jumpspeed = 2;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        rawInput = (context.ReadValue<Vector2>().normalized);
        movementInput.Set(rawInput.x, body.velocity.y);
        //Debug.Log("Move Speed: " + $"{rawInput.x * silushka.GetCurrentSilushka() * speed}");
        realSpeed = speed * silushka.GetCurrentSilushka();
        silushka.LoseSilushka(moveCost);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Collider2D checkGround = Physics2D.OverlapCircle(groundchecker.position, 0.2f, groundLayer);
        if(checkGround != null)
        {
            if(jumpspeed * silushka.GetCurrentSilushka() >= minjump)
                body.velocity = new Vector2(body.velocity.x, jumpspeed * silushka.GetCurrentSilushka());
            else
                body.velocity = new Vector2(body.velocity.x, minjump);
            silushka.LoseSilushka(jumpCost);
        }
        /*if (grounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpspeed * silushka.GetCurrentSilushka());
            //Debug.Log("Jump power: " + $"{jumpspeed * silushka.GetCurrentSilushka()}");
            silushka.LoseSilushka(jumpCost);

            

        }*/
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
        
    }*/
    public void TakeDamage(int damage)
    {
        health.ChangeHealth(-1*damage);

        if (health.GetHealth() <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        //GetComponent<Collider2D>().enabled = false;
        //GameObject.SetActive(false);
        Debug.Log(this.name + "умер");
        //Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        //currentHealth = maxHealth;
        realSpeed = speed * silushka.GetCurrentSilushka();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("Move Speed: " + $"{rawInput.x * silushka.GetCurrentSilushka() * speed}");
        //Debug.Log("Move Speed: " + realSpeed);
        //print("Силушка - " + silushka.GetCurrentSilushka());
        body.velocity = new Vector2(movementInput.x * realSpeed, body.velocity.y);
        
    }
}
