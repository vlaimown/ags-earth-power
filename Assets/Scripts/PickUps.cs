using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    [SerializeField] private int score = 5;

    private LevelManager levelManager;

    public void SetLevelManager(LevelManager levelManager)
    {
        this.levelManager = levelManager;
        /*foreach (PickUps coin in coinlist)
        {
            coin.SetLevelManager(this.levelManager);
        }*/

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HZChto>(out var player)) 
        {
            levelManager.UpdateScore(score);
            player.AddScore(score);
            gameObject.SetActive(false);
        }
    }
}
