using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMain : MonoBehaviour
{
    public void LaunchGame()
    {
        SceneManager.LoadScene("Game");
    }
}
