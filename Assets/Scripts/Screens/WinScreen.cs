using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private HeroController _heroController;
    [SerializeField] private GameObject _bossHealthBar;

    public void Active()
    {
        gameObject.SetActive(true);
        _bossHealthBar.SetActive(false);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MenuMain");
    }
}
