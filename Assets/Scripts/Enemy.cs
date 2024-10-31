using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Параметры боя")]
    [SerializeField] public Health health;
    [SerializeField] public float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float damage;

    [Header("Досягаемость атаки")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Область зрения")]
    [SerializeField] private float visionDistance;
    //[SerializeField] private BoxCollider2D visionCollider;
    //[SerializeField] private float visionrange;
    [SerializeField] private float speed = 5;
    Transform startPoint;
     

    [Header("Player Layer")]
    public float cooldownTimer = Mathf.Infinity;
    public LayerMask playerLayer;
    private Transform player;

    private Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        //health.currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Awake()
    {
        //player = gameObject.GetComponent<Transform>();
        startPoint = gameObject.transform;
    }
    public void TakeDamage(float damage)
    {
        health.ChangeHealth(-1*damage);
        print(health.GetHealth());

        if(health.GetHealth() <= 0)
        {
            Die();
        }
    }
    private void Die() 
    {
        //GetComponent<Collider2D>().enabled = false;
        //GameObject.SetActive(false);
        Debug.Log(this.name + " умер");
        Destroy(this.gameObject);
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        /*if(Vector2.Distance(transform.position, player.position) < visionDistance)
        {
            Angry();
        }
        if(Vector2.Distance(transform))*/
    }


    public void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.ChangeHealth(-damage);
        }
    }
    public bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * transform.localScale.x * colliderDistance,
            new Vector2(boxCollider.bounds.size.x * range, boxCollider.size.y), 0, Vector2.left, 0, playerLayer);

        if(hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }

    void Chill()
    {

    }

    void Angry()
    {

    }
    void GoBack()
    {

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * transform.localScale.x * colliderDistance,
            new Vector2(boxCollider.bounds.size.x * range, boxCollider.size.y));
        /*Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(visionCollider.bounds.center + transform.right * transform.localScale.x * visionDistance,
            new Vector2(visionCollider.bounds.size.x * visionrange, visionCollider.size.y));*/
    }
    /*public void OnTriggerEnter2D(Collider2D collision)
    {
         RaycastHit2D target = Physics2D.BoxCast(visionCollider.bounds.center + transform.right * transform.localScale.x * visionDistance,
             new Vector2(visionCollider.bounds.size.x * visionrange, visionCollider.size.y), 0, Vector2.left, 0, playerLayer);
        print("HOBA");
    }*/
   /* public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HOBA");
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        RaycastHit2D target = Physics2D.BoxCast(visionCollider.bounds.center + transform.right * transform.localScale.x * visionDistance,
            new Vector2(visionCollider.bounds.size.x * visionrange, visionCollider.size.y), 0, Vector2.left, 0, playerLayer);
        print("кидаю луч");

        if (!PlayerInSight() && target.collider != null)
        {
            //transform.position = Vector2.MoveTowards(transform.position, collision.transform.position, speed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed);
            print("Вижу игрока");
        }
    }*/
}
