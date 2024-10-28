using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SiluskaBar : MonoBehaviour
{
    [SerializeField] private Silushka playerSilushka;
    [SerializeField] private Image totalSilushkahBar;
    [SerializeField] private Image currentSilushkaBar;

    private void Start()
    {
        totalSilushkahBar.fillAmount = playerSilushka.GetMaxSilushka()/playerSilushka.GetMaxSilushka();
    }
    private void Update()
    {
        currentSilushkaBar.fillAmount = playerSilushka.GetCurrentSilushka()/playerSilushka.GetMaxSilushka();
    }
}
