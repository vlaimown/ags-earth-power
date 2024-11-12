using UnityEngine;

public class KosheiDeath : MonoBehaviour, IDamagebale
{
    [SerializeField] private Koshei _koshei;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        //_animator.SetTrigger("Hurt");
        _koshei.StartDamageBlinkAnim();
        _koshei.Damaged(damage);
    }
}
