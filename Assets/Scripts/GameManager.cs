using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loseWindow;
    
    //public GameObject PosolWindow;

    private void Start()
    {
        instance = this;
        //tutorialPart = 0;
    }
    public void RestartScene()
    {
        //PosolZone.tutorialPart = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void lose()
    {
        loseWindow.SetActive(true);
    }
    /*public void ShowTutorial(int num)
    {
        Images[num].gameObject.SetActive(true);
        tutorialPart++;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") 
        { 
            ShowTutorial(tutorialPart); 
            //this.gameObject.SetActive(false);
            
        }
    }*/


}
