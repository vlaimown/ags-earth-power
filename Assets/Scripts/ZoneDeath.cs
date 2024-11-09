using UnityEngine;

public class ZoneDeath : MonoBehaviour
{
    [SerializeField] private GameObject _loseScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Dead by DeathZone");
            _loseScreen.SetActive(true);
            collision.GetComponent<HeroController>().enabled = false;
        }
    }
}
