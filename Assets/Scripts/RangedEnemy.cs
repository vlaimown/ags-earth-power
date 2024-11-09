using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    private Animator animator;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;
    // private Transform point;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Shoot()    
    {
        Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

    }
    
    public void FixedUpdate()
    {
        enemy.cooldownTimer += Time.deltaTime;
        //print("Spawnpoint:" + bulletInst.transform.position);
        if (enemy.PlayerInSight())
        {
           // point.position = bulletSpawnPoint.position;

            if (enemy.cooldownTimer >= enemy.attackCooldown)
            {
                enemy.cooldownTimer = 0;
                animator.SetTrigger("rangedAttack");
                Shoot();
            }
        }
    }
}
