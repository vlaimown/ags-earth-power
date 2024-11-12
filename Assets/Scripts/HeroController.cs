using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class HeroController : MonoBehaviour
{
    [Header("Ссылки")]
    [SerializeField] public Health health;
    public Transform groundchecker;
    public LayerMask groundLayer;
    private Animator animator;
    public Silushka silushka;

    [Header("Параметры Прыжка")]
    [Space(3)]
    [SerializeField] float jumpCost;
    [Space(3)]
    [SerializeField] private float minjump = 11;
    [Space(3)]
    [SerializeField] private float jumpspeed = 2;
    private float _currentJumpSpeed = 0f;
    //[Space(3)]

    [Header("Параметры движения")]
    [Space(3)]
    [SerializeField] private float speed = 2;
    [Space(3)]
    [SerializeField] float moveCost;
    //[Space(3)]

    [Header("Воздействие Земли")]
    [Space(3)]
    [SerializeField] private Image _healthBarFill;
    [Space(3)]
    [SerializeField] private float restoreValue;
    [Space(3)]
    [SerializeField] private float curseValue;
    [SerializeField] private Color _curseColor = new Color(0f, 150f, 0f);

    [SerializeField] private UnityEvent _dead;

    private Rigidbody2D body;
    private Vector2 movementInput;
    private Vector2 rawInput;
    private bool grounded;
    private float realSpeed;
    private bool _moveEnable = false;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _moveEnable = true;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        rawInput = (context.ReadValue<Vector2>().normalized);
        movementInput.Set(rawInput.x, body.velocity.y);
        realSpeed = speed * silushka.GetCurrentSilushka();
        silushka.LoseSilushka(moveCost);
    }

    public void OnJump()
    {
        if (_moveEnable)
        {
            Collider2D checkGround = Physics2D.OverlapCircle(groundchecker.position, 0.2f, groundLayer);
            if (checkGround)
            {
                if (jumpspeed * silushka.GetCurrentSilushka() >= minjump)
                    body.velocity = new Vector2(body.velocity.x, jumpspeed * silushka.GetCurrentSilushka());
                else
                    body.velocity = new Vector2(body.velocity.x, minjump);
                animator.SetTrigger("Jump");
                silushka.LoseSilushka(jumpCost);
                grounded = false;
            }
        }
    }
    public void TakeDamage(float damage)
    {
        health.ChangeHealth(-1*damage);
        if (health.GetHealth() <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log(name + "умер");
        gameObject.SetActive(false);
        _dead.Invoke();
    }
    void Start()
    {
        realSpeed = speed * silushka.GetCurrentSilushka();
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(movementInput.x * realSpeed, body.velocity.y);

        // Переворот персонажа в сторону движения
        if(movementInput.x > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if(movementInput.x < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        animator.SetBool("Move", movementInput.x != 0); 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        animator.SetBool("Ground", true);
        //print("Тэг триггера: " +  collision.gameObject.tag);
       
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zemlitsa")) 
        {
            silushka.RestoreSilushka(restoreValue);
        }
        if (collision.gameObject.CompareTag("CursedLand"))
        {
            _healthBarFill.color = _curseColor;
            silushka.LoseSilushka(curseValue);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("Ground", false);
        if (collision.gameObject.CompareTag("CursedLand"))
            _healthBarFill.color = new Color(0f, 255f, 255f);

    }

    public void DisableMovement()
    {
        _moveEnable = false;
        realSpeed = 0f;
    }

    public void EnableMovement()
    {
        _moveEnable = true;
        realSpeed = speed * silushka.GetCurrentSilushka();
    }
}
