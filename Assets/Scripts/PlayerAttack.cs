using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [Header("Ссылки")] 
    public Silushka silushka;
    public Transform attackPoint;
    public LayerMask enemyLayer;
   // [Space(3)]

    [Header("Параметры атаки")]
    [Space(3)]
    [SerializeField] float attackCost;
    [Space(3)]
    public float attackRange;
    [Space(3)]
    public int attackDamage = 10;
    [Space(3)]
    public float attackSpeed = 0.2f;
    [Space(3)]
    float nextAttackTime = 0f;
    void Start()
    {
        
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed && Time.time >= nextAttackTime)print("Attack performed");
        if(context.performed && Time.time >= nextAttackTime) 
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackSpeed;
        }
    }
    private void Attack()
    {
        Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        print("Количество целей - " + HitEnemies.Length);
        foreach (Collider2D enemy in HitEnemies)
        {
            //Debug.Log("Attack " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage * silushka.GetCurrentSilushka());
            silushka.LoseSilushka(attackCost);
            print($"{enemy.name} потерял {attackDamage * silushka.GetCurrentSilushka()}");
        }

    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //print(silushka.GetCurrentSilushka());
    }
}
