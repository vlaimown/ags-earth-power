using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Platformer {
    public class NewLevelHUD : MonoBehaviour
    {
        [Header("Ãðóïïà UI")]
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private Button reloadButton;
        [SerializeField] private GameObject WinText;

        private readonly CommandQueue commandQueue = new CommandQueue();

        private void Start()
        {
            reloadButton.onClick.AddListener(() => commandQueue.TryEnqueueCommand(new ReloadCommand()));
            StartCoroutine(UpdateTask());
        }
        private void OnDestroy()
        {
            StopAllCoroutines();
            reloadButton.onClick.RemoveAllListeners();
        }
        private IEnumerator UpdateTask()
        {
            while (true)
            {
                if (commandQueue.TryDequeueCommand(out var command))
                {
                    switch (command)
                    {
                        case ReloadCommand _:
                        {
                                var currentScene = SceneManager.GetActiveScene();
                                SceneManager.LoadScene(currentScene.name);
                                break;
                        }
                        case WinCommand winCommand:
                            WinText.SetActive(true);
                            break;
                    }
                }

                yield return null;


            }
        }

    }
}
