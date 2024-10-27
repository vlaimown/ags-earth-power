using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silushka : MonoBehaviour
{
    [SerializeField] private float maxSilushka;
    private float currentSilushka;

    // Start is called before the first frame update
    void Start()
    {
        currentSilushka = maxSilushka;
    }
    public void LoseSilushka(float value)
    {
        if (currentSilushka >= value)
        {
            currentSilushka -= value;
            if (currentSilushka < 0.25) currentSilushka = 0.25f;
        }
        else if(currentSilushka < value || currentSilushka == 0.25f)
        {
            print("Силушки - " + currentSilushka + " Не хватает, надо " + value);
        }
    }
    public void RestoreSilushka(float value)
    {
        if (currentSilushka == maxSilushka)
        {
            currentSilushka += 0;
        }
        else if (currentSilushka + value > maxSilushka)
        {
            currentSilushka = maxSilushka;
        }
        else currentSilushka += value;
    }
    public void AddSilushka(float value)
    {
        currentSilushka += value;
        if(currentSilushka > maxSilushka)
        {
            currentSilushka = maxSilushka;
        }
    }
    public float GetCurrentSilushka()
    {
        return currentSilushka;
    }
    public float GetMaxSilushka()
    {
        return maxSilushka;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
