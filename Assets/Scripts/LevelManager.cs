using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoretext;
    [SerializeField] private List<PickUps> coinlist = new List<PickUps>();

    private LevelProgress progress;
    public void UpdateScore(int score)
    {
        progress.LevelScore += score;
        scoretext.text = score.ToString();

    }
    public void Awake()
    {
        progress = new LevelProgress();

        coinlist = FindObjectsOfType<PickUps>().ToList();

    }
}
