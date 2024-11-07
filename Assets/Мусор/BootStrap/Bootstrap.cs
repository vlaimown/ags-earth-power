using System.Collections;
using UnityEngine;
using Platformer;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Canvas))]
public class Bootstrap : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string mainScene;
    public IEnumerator Start()
    {
        yield return new WaitForSeconds(5f);
        yield return SceneManager.LoadSceneAsync(mainScene);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
