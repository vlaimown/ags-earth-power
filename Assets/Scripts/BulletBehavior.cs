using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private float bulletDamage = 55f;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        SetDestroyTime();
        
        SetVelocity();
    }
    private void SetVelocity()
    {
        body.velocity = transform.right * bulletSpeed;
    }
    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<HeroController>() != null) 
        {
            collision.gameObject.GetComponent<HeroController>().TakeDamage(bulletDamage);
        }
        Destroy(gameObject);
    }
}
