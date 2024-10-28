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

    [Header("Player Layer")]
    public float cooldownTimer = Mathf.Infinity;
    public LayerMask playerLayer;


    private Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        //health.currentHealth = maxHealth;
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * transform.localScale.x * colliderDistance,
            new Vector2(boxCollider.bounds.size.x * range, boxCollider.size.y));
    }
}
