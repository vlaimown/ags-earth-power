using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject _pauseWindow;
    private bool _isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseOrUnpause();
        }
    }

    public void PauseOrUnpause()
    {
        if (_isPaused)
        {
            _pauseWindow.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            _pauseWindow.SetActive(true);
            Time.timeScale = 0f;
        }

        _isPaused = !_isPaused;
    }
}
