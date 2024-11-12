using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Koshei : MonoBehaviour, IDamagebale
{
    [Header("Attack")]
    [SerializeField, Min(5f)] private float _attackForce = 5f;
    [SerializeField, Min(1f)] private float _attackRange = 1f;
    [SerializeField] private Transform _attackPoint;
    [SerializeField, Min(0.2f)] private float _damagedBlinkTime = 0.2f;
    [SerializeField, Min(2f)] private float _stunedBlinkTime = 2f;
    [SerializeField] private LayerMask _attackLayer;

    [Header("Movement")]
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Transform _target;

    [Space(5)]
    [SerializeField] private Image _healthBar;

    [SerializeField] private UnityEvent _dead;

    private Color _defaultColor;
    private SpriteRenderer _spriteRenderer;
    private Health _health;
    private Animator _animator;

    private bool _attacking = false;
    private bool _stuned = false;
    private bool _isFacingRight = false;
    private bool _undead = true;
    private void Start()
    {
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultColor = _spriteRenderer.color;

        _isFacingRight = false;
    }

    private void Update()
    {
        if (!_stuned)
        {
            if (Vector2.Distance(transform.position, _target.position) > _attackRange + 0.65f)
            {
                transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
            }

            if (_target.position.x > transform.position.x && !_isFacingRight)
                Flip();
            else if (_target.position.x < transform.position.x && _isFacingRight)
                Flip();
        }
    }

    public void Flip()
    {
        Vector2 flippedRotation = transform.localScale;
        flippedRotation.x *= -1f;
        transform.localScale = flippedRotation;
        _isFacingRight = !_isFacingRight;
    }

    public void Attack()
    {
        if (_attacking)
        {
            Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _attackLayer);

            foreach (Collider2D player in HitEnemies)
            {
                if (player.GetComponent<HeroController>() != null)
                    player.GetComponent<HeroController>().TakeDamage(_attackForce);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (!_undead)
        {
            Damaged(damage);
        }
        else
        {
            _animator.SetBool("Attack", false);
            _stuned = true;
            StartCoroutine(StanAnimation());
        }
    }

    public void StartDamageBlinkAnim()
    {
        StartCoroutine(DamagedBlink());
    }


    public void Damaged(float damage)
    {
        _health.ChangeHealth(-1 * damage);
        _healthBar.fillAmount = _health.GetHealth() / _health.GetMaxHealth();

        if (_health.GetHealth() <= 0)
            Death();
    }
    private void Death()
    {
        _dead.Invoke();
        _healthBar.gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private IEnumerator DamagedBlink()
    {
        _spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(_damagedBlinkTime);
        _spriteRenderer.color = _defaultColor;
    }

    private IEnumerator StanAnimation()
    {
        _spriteRenderer.color = Color.yellow;
        yield return new WaitForSeconds(_stunedBlinkTime);
        _spriteRenderer.color = _defaultColor;

        _stuned = false;

        if (Vector2.Distance(transform.position, _target.position) <= _attackRange + 0.75f)
        {
            _attacking = true;
            _animator.SetBool("Attack", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _attacking = true;
            _animator.SetBool("Attack", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _attacking = false;
            _animator.SetBool("Attack", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint != null)
            Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}
