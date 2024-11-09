using UnityEngine;

public class TriggerBossFight : MonoBehaviour
{
    [SerializeField] private Koshei _koshei;
    [SerializeField] private Canvas _bossHealthBar;
    [SerializeField] private GameObject _bossBorder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _koshei.gameObject.SetActive(true);
            _bossHealthBar.gameObject.SetActive(true);
            _bossBorder.gameObject.SetActive(true);

            Destroy(gameObject);
        }
    }
}
