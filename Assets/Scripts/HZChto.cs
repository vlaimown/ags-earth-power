using UnityEngine;

public class HZChto : MonoBehaviour
{
    [SerializeField] private int score = 0;
    
    public void AddScore(int additionalscore)
    {
        score += additionalscore;
    }
}
