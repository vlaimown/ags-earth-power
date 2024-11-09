using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private HeroController _heroController;

    public void Active()
    {
        gameObject.SetActive(true);
        _heroController.gameObject.SetActive(false);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MenuMain");
    }
}
