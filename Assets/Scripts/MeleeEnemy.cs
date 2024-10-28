using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    private Enemy enemy;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemy.cooldownTimer += Time.deltaTime;
        if (enemy.PlayerInSight())
        {
            if (enemy.cooldownTimer >= enemy.attackCooldown)
            {
                enemy.cooldownTimer = 0;
                animator.SetTrigger("meleeAttack");
                //Debug.Log("���� ��������");
            }
        }
    }
}
