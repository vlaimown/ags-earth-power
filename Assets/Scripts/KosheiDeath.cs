using UnityEngine;

public class KosheiDeath : MonoBehaviour, IDamagebale
{
    [SerializeField] private Koshei _koshei;
    public void TakeDamage(float damage)
    {
        _koshei.StartDamageBlinkAnim();
        _koshei.Damaged(damage);
    }
}
