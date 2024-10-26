using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Health health;
    //public int maxHealth = 100;
    //int currentHealth;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private float damage;
    private float cooldownTimer = Mathf.Infinity;
    public LayerMask playerLayer;
    [SerializeField] private BoxCollider2D boxCollider;

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
        cooldownTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                
                //Debug.Log("враг атаковал");
            }
        }
    }
    private void DamagePlayer()
    {

    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * transform.localScale.x * colliderDistance,
            new Vector2(boxCollider.bounds.size.x * range, boxCollider.size.y), 0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * transform.localScale.x * colliderDistance,
            new Vector2(boxCollider.bounds.size.x * range, boxCollider.size.y));
    }
}
