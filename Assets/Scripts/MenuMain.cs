using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour
{
    public void LaunchGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
}
