
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private Transform targetpoint;

    private Vector2 originalpoint;
    private Vector2 currentTargetPoint;
    [SerializeField] private float speed = 5;

    private void Awake()
    {
        originalpoint = transform.position;
        currentTargetPoint = originalpoint;
        body = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        if(Vector2.Distance(body.position, currentTargetPoint) < 0.1f)
        {
            if(currentTargetPoint == originalpoint)
            {
                currentTargetPoint = targetpoint.position;
            }
            else
            {
                currentTargetPoint = originalpoint;
            }
            var Direction = (currentTargetPoint - body.position).normalized;
            body.velocity = Direction * speed;
        }
    }
    
}
