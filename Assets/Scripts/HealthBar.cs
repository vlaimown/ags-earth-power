using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {
        totalHealthBar.fillAmount = playerHealth.GetMaxHealth()/playerHealth.GetMaxHealth();
    }
    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.GetHealth()/playerHealth.GetMaxHealth();
    }
}
